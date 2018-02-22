using DTOs.Producto;
using Persistencia.Compras;
using Persistencia.Producto;
using Persistencia.Proveedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Compras
{
    public partial class frmCompras : Form
    {
        IProductoCommandsHandler _Productoscommands;
        IProveedorCommandsHandler _Proveedorescommands;
        IComprasCommandsHandler _Comprascommands;
        
        ProductoItem productoAgregar;
        List<CompraItem> ListCompras = new List<CompraItem>();
        public frmCompras(IProductoCommandsHandler prodcommands, IProveedorCommandsHandler provcommands, IComprasCommandsHandler comprascommands)
        {
            this._Productoscommands = prodcommands;
            this._Proveedorescommands = provcommands;
            this._Comprascommands = comprascommands;
            InitializeComponent();
            this.dgvCompras.AutoGenerateColumns = false;
        }

       

        private void frmCompras_Load(object sender, EventArgs e)
        {
            GetProveedores();
            CalcularReposicionStock();
        }
        public async void CalcularReposicionStock()
        {
            int nro_prod = await _Productoscommands.GET_VERIFICAR_STOCKS_TIENDA_ALARMA();
            toolTipAlertStockTienda.Text = nro_prod.ToString();
        }
        public void GetProveedores()
        {
            cboProveedores.DataSource = _Proveedorescommands.GET();
            cboProveedores.SelectedItem = null;

        }
        private async void txtCodigo_TextChanged(object sender, EventArgs e)
        {
           /* ProductoItem producto = await this._Productoscommands.GETPRODUCTO(txtCodigo.Text.ToString());
            if (producto != null)
            {
                this.productoAgregar = producto;
                FillControls(this.productoAgregar);
            }
            else {
                this.productoAgregar = null;
                CleanControls();
            }*/

        }
        public void FillControls(ProductoItem producto)
        {
            txtNombre.Text = producto.NOMBRE;
            txtDescripcion.Text = producto.DESCRIPCION;
            txtPCompra.Value = producto.PRECIO_VENTA;
            cboProveedores.SelectedValue = producto.PROVEEDOR_ID;

            MenuItem_AddItem.Enabled = true;
        }
        public void CleanControls( )
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPCompra.Value = 0;
            cboProveedores.SelectedValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
            txtCantidad.Value = 0;
            MenuItem_AddItem.Enabled = false;
        }

        private void MenuItem_AddItem_Click(object sender, EventArgs e)
        {
            if (Validator()) {
                dgvCompras.DataSource = null;
                CompraItem item = new CompraItem() {
                    PRODUCTO_ID = this.productoAgregar.ID,
                    CODIGO=this.productoAgregar.CODIGO,
                    NOMBRE=this.productoAgregar.NOMBRE,
                    DESCRIPCION=this.productoAgregar.DESCRIPCION,
                    PROVEEDOR_ID = (Guid)cboProveedores.SelectedValue,
                    FECHA_COMPRA = dtpFechaCompra.Value,
                    CANTIDAD= (int)txtCantidad.Value,
                    PRECIO_COMPRA = txtPCompra.Value
                };
                this.ListCompras.Add(item);
                dgvCompras.DataSource=this.ListCompras;
                this.CleanControls();
                this.CalcularTotal(this.ListCompras);
                txtCodigo.Focus();
            }
            if (this.ListCompras.Count > 0)
                this.MenuItem_GrabarCompra.Enabled = true;
            else
                this.MenuItem_GrabarCompra.Enabled = false;
        }
        public void CalcularTotal(List<CompraItem> compras) {
            decimal total = 0;
            foreach (var item in compras)
            {
                total += item.PRECIO_COMPRA;
            }
            txtTotal.Text = total.ToString();
        }

        public bool Validator()
        {
            errorProvider1.Clear();
            bool Validated = true;
            if (txtCantidad.Text.Trim() == "" || txtCantidad.Value==0)
            {
                errorProvider1.SetError((Control)txtCantidad, "Debe ingresar una Cantidad valida");
                Validated = false;
            }
            if (txtPCompra.Text.Trim() == "" || txtPCompra.Value == 0)
            {
                errorProvider1.SetError((Control)txtPCompra, "Debe ingresar un Precio de Compra");
                Validated = false;
            }

            return Validated;
        }

        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6 && e.RowIndex >-1)
            {
                
                CompraItem item = (CompraItem)dgvCompras.Rows[e.RowIndex].DataBoundItem;
                dgvCompras.DataSource = null;
                this.ListCompras.Remove(item);
                dgvCompras.DataSource = this.ListCompras;
                this.CalcularTotal(this.ListCompras);
            }
           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItem_GrabarCompra_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtNroComprobante.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtNroComprobante, "Debe ingresar un Nro de Comprobante");
            }
            else {
                if (ValidarComprobanteExiste(txtNroComprobante.Text.Trim()))
                {
                    errorProvider1.SetError((Control)txtNroComprobante, "Numero de Comprobante ya esta registrado.");
                }
                else {
                    int result = this._Comprascommands.ADD(this.ListCompras, txtNroComprobante.Text.Trim());
                    this.CleanControls();
                    this.ListCompras.Clear();
                    dgvCompras.DataSource = null;
                    txtNroComprobante.Text = string.Empty;
                    txtCodigo.Text = string.Empty;
                    this.MenuItem_GrabarCompra.Enabled = false;
                    txtTotal.Text = "0.00";
                }
            }
        }
        public bool ValidarComprobanteExiste(string nroComprobante){

            return this._Comprascommands.COMPRA_EXISTE(nroComprobante);
        }

        private async void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                ProductoItem producto = await this._Productoscommands.GETPRODUCTO(txtCodigo.Text.ToString());
                if (producto != null)
                {
                    this.productoAgregar = producto;
                    FillControls(this.productoAgregar);
                }
                else
                {
                    this.productoAgregar = null;
                    CleanControls();
                }
            }
        }
    }
}
