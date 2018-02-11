using DTOs.Producto;
using DTOs.Proveedor;
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

namespace Presentacion.Producto
{
    public partial class frmAdminProducto : Form
    {
        IProductoCommandsHandler _Productoscommands;
        IProveedorCommandsHandler _Proveedorescommands;
        ProductoItem obj_Toupdate =null;
        public frmAdminProducto(IProductoCommandsHandler prodcommands, IProveedorCommandsHandler provcommands)
        {
            this._Productoscommands = prodcommands;
            this._Proveedorescommands = provcommands;
            InitializeComponent();
        }

        private void frmAdminProducto_Load(object sender, EventArgs e)
        {
            this.GetProductos();
            this.GetProveedores();
        }
        public async void GetProductos()
        {
           dgvProductos.AutoGenerateColumns = false;           
           dgvProductos.DataSource= await _Productoscommands.GET();
           dgvProductos.ClearSelection();
        }

        public void GetProveedores()
        {
            cboProveedores.DataSource = _Proveedorescommands.GET();
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
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            ProductoItem p = new ProductoItem()
            {
                ID = Guid.NewGuid(),
                CODIGO = txtCodigo.Text,
                NOMBRE = txtNombre.Text.ToUpper(),
                DESCRIPCION = txtDescripcion.Text,
                CODIGO_PROVEEDOR = txtCodigoProveedor.Text,
                FECHA_CREACION = DateTime.Now,
                USUARIO_CREACION = "demo",
                ESTADO=true
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
           GetProductos();
           cleanControls();
           InformacionGeneralPanel.Enabled = false;

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
        }

       

        public void FillControls(ProductoItem p) {
            if (p != null)
            {
                txtCodigo.Text = p.CODIGO;
                txtNombre.Text = p.NOMBRE;
                txtDescripcion.Text = p.DESCRIPCION;
                txtCodigoProveedor.Text = p.CODIGO_PROVEEDOR;
                InformacionGeneralPanel.Enabled = true;
                //tab auditoria
                txtUsuarioCreacion.Text = p.USUARIO_CREACION;
                txtFechaCreacion.Text = p.FECHA_CREACION.ToString();
                txtUsuarioModificacion.Text = p.USUARIO_MODIFICACION;
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
            }
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }
        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            ProductoItem valor =null;
            if (e.KeyData == Keys.Down)
            {
                if(dgvProductos.Rows.Count == dgvProductos.CurrentRow.Index + 1)
                    valor = (ProductoItem)dgvProductos.Rows[dgvProductos.CurrentRow.Index ].DataBoundItem;
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
                this.GetProductos();
            }            
        }
    }
}
