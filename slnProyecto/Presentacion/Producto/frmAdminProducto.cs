﻿using DTOs.Producto;
using DTOs.Proveedor;
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

namespace Presentacion.Producto
{
    public partial class frmAdminProducto : Form
    {
        IProductoCommandsHandler _Productoscommands;
        IProveedorCommandsHandler _Proveedorescommands;
        IServicioCommandsHandler _Servicioscommands;
        ProductoItem obj_Toupdate = null;
        public frmAdminProducto(IProductoCommandsHandler prodcommands, IProveedorCommandsHandler provcommands, IServicioCommandsHandler serviciocommand)
        {
            InitializeComponent();
            this._Productoscommands = prodcommands;
            this._Proveedorescommands = provcommands;
            this._Servicioscommands = serviciocommand;
        }

        private void frmAdminProducto_Load(object sender, EventArgs e)
        {
            this.GetProductos("");
            this.GetProveedores();
            CalcularReposicionStock();
            CalcularServiciosEnProceso();
        }
        
       
        public async void GetProductos(string search)
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = await _Productoscommands.GET(search);
            dgvProductos.ClearSelection();
        }

        public async void GetProveedores()
        {
            cboProveedores.DataSource = await _Proveedorescommands.GET("");
            cboProveedores.SelectedItem = null;

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItem_New_Click(object sender, EventArgs e)
        {
            InformacionGeneralPanel.Enabled = true;
            this.MenuItem_Save.Enabled = true;
            this.MenuItem_Delete.Enabled = false;
            txtCodigo.Focus();
            this.obj_Toupdate = null;
            dgvProductos.ClearSelection();
            cleanControls();
            InformacionGeneralPanel.Enabled = true;
            cboProveedores.SelectedItem = null;
            btnGenerarCodigo.Visible = true;
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                ProductoItem p = new ProductoItem()
                {
                    ID = Guid.NewGuid(),
                    CODIGO = Convert.ToInt32(txtCodigo.Text),
                    NOMBRE = txtNombre.Text.ToUpper(),
                    DESCRIPCION = txtDescripcion.Text,
                    CODIGO_PROVEEDOR = txtCodigoProveedor.Text,
                    PROVEEDOR_ID = (Guid)(cboProveedores.SelectedValue == null ? Guid.Parse("00000000-0000-0000-0000-000000000000") : cboProveedores.SelectedValue),
                    PRECIO_VENTA = txtPVenta.Value,
                    DSCTO_MAX = txtDsctoMax.Value,
                    FECHA_CREACION = DateTime.Now,
                    USUARIO_CREACION = "demo",
                    ESTADO = true,
                    ALERTA_STOCK_MIN_TIENDA = (int)txtMinSctock.Value
                };
                if (this.obj_Toupdate == null)
                {
                    var result = this._Productoscommands.ADD(p);
                }
                else
                {
                    p.ID = this.obj_Toupdate.ID;
                    p.USUARIO_MODIFICACION = "demo";
                    p.FECHA_MODIFICACION = DateTime.Now;
                    this._Productoscommands.UPDATE(p);
                }
                GetProductos("");
                cleanControls();
                InformacionGeneralPanel.Enabled = false;
            }
        }
        public bool Validator() {
            errorProvider1.Clear();
            bool Validated = true;
            if (txtCodigo.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtCodigo, "El Codigo es Requerido");
                Validated = false;
            }
            if (txtNombre.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtNombre, "El Nombre del Producto es requerido");
                Validated = false;
            }
            if (txtDescripcion.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtDescripcion, "La Descripcion del Producto es requerido");
                Validated = false;
            }
            if (txtPVenta.Text.Trim() == "" || txtPVenta.Value == 0)
            {
                errorProvider1.SetError((Control)txtPVenta, "El Precio de venta del Producto es requerido");
                Validated = false;
            }
            if (txtDsctoMax.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtDsctoMax, "El Descuento del Producto es requerido");
                Validated = false;
            }
            return Validated;
        }
        public void cleanControls() {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCodigoProveedor.Text = string.Empty;
            txtUsuarioCreacion.Text = string.Empty;
            txtFechaCreacion.Text = string.Empty;
            txtUsuarioModificacion.Text = string.Empty;
            txtFechaModificacion.Text = string.Empty;
            cboProveedores.SelectedItem = null;
            txtPVenta.ResetText();
            txtDsctoMax.ResetText();
            txtMinSctock.Value = 2;
        }



        public void FillControls(ProductoItem p) {
            if (p != null)
            {
                txtPVenta.Value = 0;
                txtDsctoMax.Value = 0;

                txtCodigo.Text = p.CODIGO.ToString().PadLeft(7, '0');
                txtNombre.Text = p.NOMBRE;
                txtDescripcion.Text = p.DESCRIPCION;
                txtCodigoProveedor.Text = p.CODIGO_PROVEEDOR;
                InformacionGeneralPanel.Enabled = true;
                //tab auditoria
                txtUsuarioCreacion.Text = p.USUARIO_CREACION;
                txtFechaCreacion.Text = p.FECHA_CREACION.ToString();
                txtUsuarioModificacion.Text = p.USUARIO_MODIFICACION;
                cboProveedores.SelectedValue = p.PROVEEDOR_ID;

                txtPVenta.Value = p.PRECIO_VENTA;
                txtDsctoMax.Value = p.DSCTO_MAX;
                txtMinSctock.Value = p.ALERTA_STOCK_MIN_TIENDA;
                if (p.FECHA_MODIFICACION != DateTime.MinValue)
                    txtFechaModificacion.Text = p.FECHA_MODIFICACION.ToString();
            }
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ProductoItem valor = (ProductoItem)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                FillControls(valor);
                this.obj_Toupdate = valor;
                btnGenerarCodigo.Visible = false;
            }
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }
        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            ProductoItem valor = null;
            if (e.KeyData == Keys.Down)
            {
                if (dgvProductos.Rows.Count == dgvProductos.CurrentRow.Index + 1)
                    valor = (ProductoItem)dgvProductos.Rows[dgvProductos.CurrentRow.Index].DataBoundItem;
                else
                    valor = (ProductoItem)dgvProductos.Rows[dgvProductos.CurrentRow.Index + 1].DataBoundItem;
            }
            if (e.KeyData == Keys.Up)
            {
                if (dgvProductos.CurrentRow.Index == 0)
                    valor = (ProductoItem)dgvProductos.Rows[0].DataBoundItem;
                else
                    valor = (ProductoItem)dgvProductos.Rows[dgvProductos.CurrentRow.Index - 1].DataBoundItem;
            }
            FillControls(valor);
            this.obj_Toupdate = valor;
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }

        private void MenuItem_Cancel_Click(object sender, EventArgs e)
        {
            this.MenuItem_Save.Enabled = false;
            this.MenuItem_Delete.Enabled = false;
            this.obj_Toupdate = null;
        }

        private void MenuItem_Delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Estas seguro de eliminar este producto?",
                                     ".:: Mensaje del Sistema ::.",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this._Productoscommands.DELETE(this.obj_Toupdate.ID);
                this.cleanControls();
                this.obj_Toupdate = null;
                MenuItem_Save.Enabled = false;
                MenuItem_Delete.Enabled = false;
                this.GetProductos("");
            }
        }

       

        private async void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            int ultimo_codigo = _Productoscommands.GENERAR_CODIGO();
            string codigo = (ultimo_codigo + 1).ToString();
            txtCodigo.Text = codigo.PadLeft(7, '0');
        }

        private async void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetProductos(txtSearch.Text.Trim());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // if(txtSearch.Text.Trim().Length>2)
            this.GetProductos(txtSearch.Text.Trim());

            /*if (txtSearch.Text.Trim()=="")
                    this.GetProductos("");*/
        }

        private void txtDsctoMax_ValueChanged(object sender, EventArgs e)
        {
            txtDsctoMax.Maximum = txtPVenta.Value;
        }

        private void txtPVenta_ValueChanged(object sender, EventArgs e)
        {
            txtDsctoMax.Maximum = txtPVenta.Value;
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
        private void toolTipAlertStockTienda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolTipAlertStockTienda.Text + " PRODUCTOS CON STOCK MENOS DEL MINIMO EN TIENDA");
        }

        private void toolTipAlertProcesoServicios_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolTipAlertProcesoServicios.Text + " SERVICIOS EN PROCESO");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
