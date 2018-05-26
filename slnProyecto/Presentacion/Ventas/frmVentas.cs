using DTOs.Producto;
using DTOs.Venta;
using Persistencia.Producto;
using Persistencia.Proveedor;
using Persistencia.Servicios;
using Persistencia.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Ventas
{
    public partial class frmVentas : Form
    {
        IProductoCommandsHandler _Productoscommands;
        IProveedorCommandsHandler _Proveedorescommands;
        IVentasCommandsHandler _Ventascommands;
        ProductoItem productoVender;
        List<VentaItem> ListVentas = new List<VentaItem>();
        IServicioCommandsHandler _Servicioscommands;
        public frmVentas(IProductoCommandsHandler prodcommands, IServicioCommandsHandler serviciocommand,
            IProveedorCommandsHandler provcommands, IVentasCommandsHandler ventascommands)
        {
            this._Productoscommands = prodcommands;
            this._Servicioscommands = serviciocommand;
            this._Proveedorescommands = provcommands;
            this._Ventascommands = ventascommands;
            InitializeComponent();
            this.dgvCompras.AutoGenerateColumns = false;
        }


    

        public async void FillControls(ProductoItem producto)
        {
            int stockyaagregado = producto.STOCK_ACTUAL_TIENDA;
            if (this.ListVentas.Count > 0) {
                foreach (var p in this.ListVentas) {
                    if (producto.ID == p.PRODUCTO_ID)
                    {
                        producto.STOCK_ACTUAL_TIENDA = producto.STOCK_ACTUAL_TIENDA - p.CANTIDAD;
                    }
               }
            }
            txtCantidad.Maximum = 0;
            txtNombre.Text = producto.NOMBRE;
            txtDescripcion.Text = producto.DESCRIPCION;
            txtPVenta.Value = producto.PRECIO_VENTA;
            txtPVenta.Minimum = productoVender.DSCTO_MAX;
            lbldscMax.Text = productoVender.DSCTO_MAX.ToString();
            cboProveedores.SelectedValue = producto.PROVEEDOR_ID;

            MenuItem_AddItem.Enabled = true;
            int stockAlmacen= await  CalcularStockAlmacen(producto);
            int stockTienda = await CalcularStockTienda(producto.ID);

          
            txtCantidad.Maximum = producto.STOCK_ACTUAL_TIENDA;
            lblStockAlmacen.Text = stockAlmacen.ToString();
            lblStockTienda.Text = producto.STOCK_ACTUAL_TIENDA.ToString();

            if (producto.STOCK_ACTUAL_TIENDA == 0)
            {
                MessageBox.Show("Este producto no contiene Stock en Tienda\n Existen " + stockAlmacen + " Productos en Almacen", ".:: Mensaje del Sistema ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanControls();
                this.productoVender = null;
                return;
            }
        }

        public async Task<int> CalcularStockAlmacen(ProductoItem p)
        {
            int StockTotal = await this._Productoscommands.GET_STOCK_ALMACEN(p.ID);
            int Almacen = StockTotal - p.STOCK_ACTUAL_TIENDA;
            return Almacen;
        }
        public Task<int> CalcularStockTienda(Guid PRODUCTO_ID)
        {
            return this._Productoscommands.GET_STOCK_TIENDA(PRODUCTO_ID);
        }
       

        public void CleanControls()
        {
            txtPVenta.Minimum = 0;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPVenta.Value = 0;
            cboProveedores.SelectedValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
            txtCantidad.Value = 0;
            MenuItem_AddItem.Enabled = false;
            lblStockAlmacen.Text = "0";
            lblStockTienda.Text = "0";
            lbldscMax.Text = "0.00";
            
        }

        private void MenuItem_AddItem_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                VentaItem item = new VentaItem()
                {
                    PRODUCTO_ID = this.productoVender.ID,
                    CODIGO = this.productoVender.CODIGO.ToString(),
                    NOMBRE = this.productoVender.NOMBRE,
                    DESCRIPCION = this.productoVender.DESCRIPCION,
                    PROVEEDOR_ID = (Guid)cboProveedores.SelectedValue,
                    FECHA_VENTA = dtpFechaCompra.Value,
                    CANTIDAD = (int)txtCantidad.Value,
                    PRECIO_VENTA_DSCTO = this.productoVender.DSCTO_MAX,
                    PRECIO_VENTA = txtPVenta.Value,
                    TOTAL = txtPVenta.Value * txtCantidad.Value
                };
                foreach (var p in this.ListVentas) {
                    if (p.PRODUCTO_ID == item.PRODUCTO_ID)
                    {
                        MessageBox.Show("Este producto ya fue agregado, retirarlo y volverlo a agregar" ,".:Mensaje del Sistema::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                dgvCompras.DataSource = null;
                this.ListVentas.Add(item);
                dgvCompras.DataSource = this.ListVentas;
                this.CleanControls();
                this.CalcularTotal(this.ListVentas);
                txtCodigo.Focus();
            }
            if (this.ListVentas.Count > 0)
                this.MenuItem_GrabarVenta.Enabled = true;
            else
                this.MenuItem_GrabarVenta.Enabled = false;
        }

        public bool Validator()
        {
            errorProvider1.Clear();
            bool Validated = true;
            if (txtCantidad.Text.Trim() == "" || txtCantidad.Value == 0)
            {
                errorProvider1.SetError((Control)txtCantidad, "Debe ingresar una Cantidad valida");
                Validated = false;
            }
            if (txtPVenta.Text.Trim() == "" || txtPVenta.Value == 0)
            {
                errorProvider1.SetError((Control)txtPVenta, "Debe ingresar un Precio de Venta");
                Validated = false;
            }

            return Validated;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            GetProveedores();
            CalcularReposicionStock();
            CalcularServiciosEnProceso();
        }

        public async void CalcularServiciosEnProceso()
        {
            int nro_servicios = await _Servicioscommands.GET_SERVICIOS_EN_PROCESO();
            if (nro_servicios == 0)
                toolTipAlertProcesoServicios.Visible = false;
            else
            {
                toolTipAlertProcesoServicios.Visible = true;
                toolTipAlertProcesoServicios.Text = nro_servicios.ToString();
            }
        }


        public async  void CalcularReposicionStock()
        {
            int nro_prod = await _Productoscommands.GET_VERIFICAR_STOCKS_TIENDA_ALARMA();
            if (nro_prod == 0)
                toolTipAlertStockTienda.Visible = false;
            else
            {
                toolTipAlertStockTienda.Visible = true;
                toolTipAlertStockTienda.Text = nro_prod.ToString();
            }
        }

        public async void GetProveedores()
        {
            cboProveedores.DataSource = await _Proveedorescommands.GET("");
            cboProveedores.SelectedItem = null;

        }
        public void CalcularTotal(List<VentaItem> compras)
        {
            decimal total = 0;
            foreach (var item in compras)
            {
                total += item.TOTAL;
            }
            txtTotal.Text = total.ToString();
        }

        private async void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsNumeric(txtCodigo.Text))
                {
                    string codigo = txtCodigo.Text.Substring(0, txtCodigo.Text.Length - 1);
                    int CODIGO = Convert.ToInt32(codigo);
                    foreach (var item in this.ListVentas) {
                        if (item.CODIGO == CODIGO.ToString()) {
                            MessageBox.Show("Este producto ya fue agregado, retirarlo y volverlo a agregar", ".:Mensaje del Sistema::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }


                ProductoItem producto = await this._Productoscommands.GETPRODUCTO(txtCodigo.Text.ToString());
                if (producto != null)
                {
                    
                    this.productoVender = producto;
                    FillControls(this.productoVender);
                }
                else
                {
                    this.productoVender = null;
                    CleanControls();
                }
            }
        }

        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }


        private void MenuItem_GrabarVenta_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (MessageBox.Show("Esta seguro de registrar la venta?" , ".::Mensaje del Sistema::.",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
             
                  int result = this._Ventascommands.ADD(this.ListVentas);
                  this.CleanControls();
                  this.ListVentas.Clear();
                  dgvCompras.DataSource = null;
                  txtCodigo.Text = string.Empty;
                  this.MenuItem_GrabarVenta.Enabled = false;
                  txtTotal.Text = "0.00";
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItem_New_Click(object sender, EventArgs e)
        {
            cboProveedores.Enabled = true;
        }

        private void toolTipAlertStockTienda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolTipAlertStockTienda.Text + " PRODUCTOS CON STOCK MENOS DEL MINIMO EN TIENDA");
        }

        private void toolTipAlertProcesoServicios_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolTipAlertProcesoServicios.Text + " SERVICIOS EN PROCESO");

        }

        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex > -1)
            {

                VentaItem item = (VentaItem)dgvCompras.Rows[e.RowIndex].DataBoundItem;
                dgvCompras.DataSource = null;
                this.ListVentas.Remove(item);
                dgvCompras.DataSource = this.ListVentas;
                this.CalcularTotal(this.ListVentas);
            }
        }

      
    }
}
