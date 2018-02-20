using DTOs.Producto;
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

namespace Presentacion.Almacen
{
    public partial class frmAlmacen : Form
    {
        IProductoCommandsHandler _Productoscommands;
        IProveedorCommandsHandler _Proveedorescommands;
        ProductoItem obj_Toupdate = null;
        public frmAlmacen(IProductoCommandsHandler prodcommands, IProveedorCommandsHandler provcommands)
        {
            this._Productoscommands = prodcommands;
            this._Proveedorescommands = provcommands;
            InitializeComponent();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearch.Text.Trim().Length > 2)
                    this.GetProductos(txtSearch.Text.Trim());

                if (txtSearch.Text.Trim() == "")
                    this.GetProductos("");
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

                txtCodigo.Text = p.CODIGO;
                txtNombre.Text = p.NOMBRE;
                txtDescripcion.Text = p.DESCRIPCION;
                InformacionGeneralPanel.Enabled = true;
                int StockTotal = await this._Productoscommands.GET_STOCK(p.ID);
                int Almacen = StockTotal - p.STOCK_ACTUAL_TIENDA;
                int Tienda =p.STOCK_ACTUAL_TIENDA;

                lblNroAlmacen.Text = Almacen.ToString();
                lblNroTienda.Text = Tienda.ToString();
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

    }
}
