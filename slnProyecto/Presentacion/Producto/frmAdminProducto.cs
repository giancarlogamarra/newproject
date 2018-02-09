using DTOs.Proveedor;
using Persistencia.Producto;
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
        IProductoCommandsHandler _commands;
        ProductoItem obj_Toupdate=null;
        public frmAdminProducto(IProductoCommandsHandler commands)
        {
            this._commands = commands;
            InitializeComponent();
        }

        private void frmAdminProducto_Load(object sender, EventArgs e)
        {
            this.GetProductos();
        }
        public async void GetProductos()
        {
           dgvProductos.AutoGenerateColumns = false;
           dgvProductos.DataSource= await _commands.GET();
           dgvProductos.ClearSelection();

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
                DESCRIPCION=txtDescripcion.Text
            };
            if (this.obj_Toupdate == null)
            {
                var result = this._commands.ADD(p);
            }
            else
            {
                p.ID = this.obj_Toupdate.ID;
                var result = this._commands.UPDATE(p);
            }
           GetProductos();
           cleanControls();
            InformacionGeneralPanel.Enabled = false;

        }

        public void cleanControls() {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

       

        public void FillControls(ProductoItem p) {
            txtCodigo.Text = p.CODIGO;
            txtNombre.Text = p.NOMBRE;
            txtDescripcion.Text = p.DESCRIPCION;
            InformacionGeneralPanel.Enabled = true;
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
            ProductoItem valor=null;
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

        
    }
}
