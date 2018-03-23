using DTOs.Proveedor;
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

namespace Presentacion.Proveedor
{
    public partial class frmAdminProveedor : Form
    {
        IProveedorCommandsHandler _Proveedorcommands;
        ProveedorItem obj_Toupdate = null;

        public frmAdminProveedor(IProveedorCommandsHandler commands)
        {
            InitializeComponent();
            this._Proveedorcommands = commands;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 2)
                this.GetProveedores(txtSearch.Text.Trim());

            if (txtSearch.Text.Trim() == "")
                this.GetProveedores("");
        }
        public async void GetProveedores(string search)
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.DataSource = await _Proveedorcommands.GET(search);
            dgvProveedores.ClearSelection();
        }

        private void frmAdminProveedor_Load(object sender, EventArgs e)
        {
            this.GetProveedores("");
        }

        private void MenuItem_New_Click(object sender, EventArgs e)
        {
            InformacionGeneralPanel.Enabled = true;
            this.MenuItem_Save.Enabled = true;
            this.MenuItem_Delete.Enabled = false;
            txtNombre.Focus();
            this.obj_Toupdate = null;
            dgvProveedores.ClearSelection();
            cleanControls();
            InformacionGeneralPanel.Enabled = true;
        }
        public void cleanControls()
        {
            txtNombre.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelFijo.Text = string.Empty;
            txtTelCel.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                ProveedorItem p = new ProveedorItem()
                {
                    ID = Guid.NewGuid(),
                    NOMBRE= txtNombre.Text.ToUpper(),
                    RAZON_SOCIAL = txtRazonSocial.Text,
                    RUC = txtRuc.Text,
                    DIRECCION = txtDireccion.Text,
                    TELEFONO_FIJO = txtTelFijo.Text,
                    TELEFONO_CELULAR= txtTelCel.Text,
                    EMAIL  = txtEmail.Text,
                    FECHA_CREACION = DateTime.Now,
                    USUARIO_CREACION = "demo",
                    ESTADO = true
                };
                if (this.obj_Toupdate == null)
                {
                    var result = this._Proveedorcommands.ADD(p);
                }
                else
                {
                    p.ID = this.obj_Toupdate.ID;
                    p.USUARIO_MODIFICACION = "demo";
                    p.FECHA_MODIFICACION = DateTime.Now;
                    this._Proveedorcommands.UPDATE(p);
                }
                GetProveedores("");
                cleanControls();
                InformacionGeneralPanel.Enabled = false;
            }
        }

        public bool Validator()
        {
            errorProvider1.Clear();
            bool Validated = true;
            if (txtNombre.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtNombre, "Ingrese Nombre del Proveedor");
                Validated = false;
            }
            return Validated;
        }

        private void MenuItem_Delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Estas seguro de eliminar este proveedor?",
                                     ".:: Mensaje del Sistema ::.",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this._Proveedorcommands.DELETE(this.obj_Toupdate.ID);
                this.cleanControls();
                this.obj_Toupdate = null;
                MenuItem_Save.Enabled = false;
                MenuItem_Delete.Enabled = false;
                this.GetProveedores("");
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ProveedorItem valor = (ProveedorItem)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
                FillControls(valor);
                this.obj_Toupdate = valor;
            }
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }

        public void FillControls(ProveedorItem p)
        {
            if (p != null)
            {
                txtNombre.Text = p.NOMBRE;
                txtRazonSocial.Text = p.RAZON_SOCIAL;
                txtRuc.Text = p.RUC;
                txtDireccion.Text = p.DIRECCION;
                txtTelFijo.Text = p.TELEFONO_FIJO;
                txtTelCel.Text = p.TELEFONO_CELULAR;
                txtEmail.Text = p.EMAIL;
                InformacionGeneralPanel.Enabled = true;
              
            }
        }

    }
}
