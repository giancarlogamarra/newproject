using DTOs.Producto;
using Persistencia.Almacen;
using Persistencia.Producto;
using Persistencia.Proveedor;
using Persistencia.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Almacen
{
    public partial class frmAlmacen : Form
    {
        IProductoCommandsHandler _Productoscommands;
        IProveedorCommandsHandler _Proveedorescommands;
        IAlmacenCommandsHandler _Almacencommands;
        IServicioCommandsHandler _Servicioscommands;
        ProductoItem obj_Toupdate = null;
        public frmAlmacen(IProductoCommandsHandler prodcommands,
            IServicioCommandsHandler serviciocommand, 
            IProveedorCommandsHandler provcommands,
                          IAlmacenCommandsHandler almacencommands)
        {
            this._Productoscommands = prodcommands;
            this._Proveedorescommands = provcommands;
            this._Almacencommands = almacencommands;
            this._Servicioscommands = serviciocommand;
            InitializeComponent();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearch.Text.Trim().Length > 2)
                    this.GetProductos(txtSearch.Text.Trim());

            }
        }
        public async void GetProductos(string search)
        {
            dgvProductos.DataSource = null;
            dgvProductos.AutoGenerateColumns = false;
            var productos = await _Productoscommands.GET(search);
            dgvProductos.DataSource = productos;
            dgvProductos.ClearSelection();
            if (productos.Count() == 0)
            {
                cleanControls();
            }
            else
            {
                dgvProductos.Rows[0].Selected = true;
                FillControls((ProductoItem)dgvProductos.Rows[0].DataBoundItem);
            }
        }
        private void frmAlmacen_Load(object sender, EventArgs e)
        {
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
        public async void CalcularReposicionStock()
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

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ProductoItem valor = (ProductoItem)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                FillControls(valor);
                this.obj_Toupdate = valor;
            }
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }

        public async void FillControls(ProductoItem p)
        {
            if (p != null)
            {

                txtCodigo.Text = p.CODIGO.ToString();
                txtNombre.Text = p.NOMBRE;
                txtDescripcion.Text = p.DESCRIPCION;
                InformacionGeneralPanel.Enabled = true;
                lblStockMinTienda.Text = p.ALERTA_STOCK_MIN_TIENDA.ToString();
                int StockTotal = await this._Productoscommands.GET_STOCK_ALMACEN(p.ID);
                int Almacen = StockTotal - p.STOCK_ACTUAL_TIENDA;
                int Tienda =p.STOCK_ACTUAL_TIENDA;
                if (Almacen ==0)
                {
                    btnSalidaAlmacen.Enabled = false;
                    errorProvider1.SetError((Control)btnSalidaAlmacen, "No hay productos suficientes en Almacen");
                }
                else {
                    btnSalidaAlmacen.Enabled = true;
                }
                lblNroAlmacen.Text = Almacen.ToString();
                lblNroTienda.Text = Tienda.ToString();
                this.obj_Toupdate = p;
            }
            else
            {
                cleanControls();
            }
        }
        public void cleanControls()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnSalidaAlmacen_Click(object sender, EventArgs e)
        {
            this._Almacencommands.MOVER_ALMACEN_A_TIENDA(this.obj_Toupdate.ID, "user");
            this.GetProductos(txtSearch.Text);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolTipAlertStockTienda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolTipAlertStockTienda.Text + " PRODUCTOS CON STOCK MENOS DEL MINIMO EN TIENDA");
        }

        private void toolTipAlertProcesoServicios_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolTipAlertProcesoServicios.Text + " SERVICIOS EN PROCESO");
        }
    }
}
