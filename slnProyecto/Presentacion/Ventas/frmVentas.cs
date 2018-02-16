using DTOs.Producto;
using DTOs.Venta;
using Persistencia.Producto;
using Persistencia.Proveedor;
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
        public frmVentas(IProductoCommandsHandler prodcommands, IProveedorCommandsHandler provcommands, IVentasCommandsHandler ventascommands)
        {
            this._Productoscommands = prodcommands;
            this._Proveedorescommands = provcommands;
            this._Ventascommands = ventascommands;
            InitializeComponent();
            this.dgvCompras.AutoGenerateColumns = false;
        }


        private async void txtCodigo_TextChanged(object sender, EventArgs e)
        {
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

        public void FillControls(ProductoItem producto)
        {
            txtNombre.Text = producto.NOMBRE;
            txtDescripcion.Text = producto.DESCRIPCION;
            txtPVenta.Value = producto.PRECIO_VENTA;
            txtPVenta.Minimum = productoVender.DSCTO_MAX;
            lbldscMax.Text = productoVender.DSCTO_MAX.ToString();
            cboProveedores.SelectedValue = producto.PROVEEDOR_ID;

            MenuItem_AddItem.Enabled = true;
        }
        public void CleanControls()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPVenta.Value = 0;
            cboProveedores.SelectedValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
            txtCantidad.Value = 0;
            MenuItem_AddItem.Enabled = false;
        }

        private void MenuItem_AddItem_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                dgvCompras.DataSource = null;
                VentaItem item = new VentaItem()
                {
                    PRODUCTO_ID = this.productoVender.ID,
                    CODIGO = this.productoVender.CODIGO,
                    NOMBRE = this.productoVender.NOMBRE,
                    DESCRIPCION = this.productoVender.DESCRIPCION,
                    PROVEEDOR_ID = (Guid)cboProveedores.SelectedValue,
                    FECHA_VENTA = dtpFechaCompra.Value,
                    CANTIDAD = (int)txtCantidad.Value,
                    PRECIO_VENTA = txtPVenta.Value
                };
                this.ListVentas.Add(item);
                dgvCompras.DataSource = this.ListVentas;
                this.CleanControls();
                this.CalcularTotal(this.ListVentas);
                txtCodigo.Focus();
            }
            if (this.ListVentas.Count > 0)
                this.MenuItem_GrabarCompra.Enabled = true;
            else
                this.MenuItem_GrabarCompra.Enabled = false;
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

        }
        public void CalcularTotal(List<VentaItem> compras)
        {
            decimal total = 0;
            foreach (var item in compras)
            {
                total += item.PRECIO_VENTA;
            }
            txtTotal.Text = total.ToString();
        }
    }
}
