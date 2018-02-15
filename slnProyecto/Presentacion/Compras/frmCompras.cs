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

namespace Presentacion.Compras
{
    public partial class frmCompras : Form
    {
        IProductoCommandsHandler _Productoscommands;
        IProveedorCommandsHandler _Proveedorescommands;
        ProductoItem productoAgregar;
        List<CompraItem> ListCompras = new List<CompraItem>();
        public frmCompras(IProductoCommandsHandler prodcommands, IProveedorCommandsHandler provcommands)
        {
            this._Productoscommands = prodcommands;
            this._Proveedorescommands = provcommands;
            InitializeComponent();
            this.dgvCompras.AutoGenerateColumns = false;
        }

       

        private void frmCompras_Load(object sender, EventArgs e)
        {
            GetProveedores();
        }
        public void GetProveedores()
        {
            cboProveedores.DataSource = _Proveedorescommands.GET();
            cboProveedores.SelectedItem = null;

        }
        private async void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ProductoItem producto = await this._Productoscommands.GETPRODUCTO(txtCodigo.Text.ToString());
            if (producto != null)
            {
                this.productoAgregar = producto;
                FillControls(this.productoAgregar);
            }
            else {
                this.productoAgregar = null;
                CleanControls();
            }

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
                    ID = this.productoAgregar.ID,
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
            }
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

   
    }
}
