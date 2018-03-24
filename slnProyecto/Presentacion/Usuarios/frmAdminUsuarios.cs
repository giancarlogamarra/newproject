using DTOs.Usuario;
using Persistencia.Producto;
using Persistencia.Servicios;
using Persistencia.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Usuarios
{
    public partial class frmAdminUsuarios : Form
    {
        IUsuarioCommandsHandler _UsuarioCommands;
        IProductoCommandsHandler _ProductoCommads;
        IServicioCommandsHandler _ServicioCommands;
       UsuarioItem obj_Toupdate = null;

        public frmAdminUsuarios(IUsuarioCommandsHandler usuarioCommand,
            IProductoCommandsHandler prodcommands, IServicioCommandsHandler serviciocommand)
        {
            InitializeComponent();
            this._UsuarioCommands = usuarioCommand;
            this._ProductoCommads = prodcommands;
            this._ServicioCommands = serviciocommand;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 2)
                this.GetUsuarios(txtSearch.Text.Trim());

            if (txtSearch.Text.Trim() == "")
                this.GetUsuarios("");
        }
        public async void GetUsuarios(string search)
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.DataSource = await _UsuarioCommands.GET(search);
            dgvUsuarios.ClearSelection();
        }
        private void frmAdminUsuarios_Load(object sender, EventArgs e)
        {
            GetUsuarios("");
            CalcularServiciosEnProceso();
            CalcularReposicionStock();
        }

        public async void CalcularServiciosEnProceso()
        {
            int nro_servicios = await _ServicioCommands.GET_SERVICIOS_EN_PROCESO();
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
            int nro_prod = await _ProductoCommads.GET_VERIFICAR_STOCKS_TIENDA_ALARMA();
            if (nro_prod == 0)
                toolTipAlertStockTienda.Visible = false;
            else
            {
                toolTipAlertStockTienda.Visible = true;
                toolTipAlertStockTienda.Text = nro_prod.ToString();
            }
        }

        private void MenuItem_New_Click(object sender, EventArgs e)
        {
            InformacionGeneralPanel.Enabled = true;
            this.MenuItem_Save.Enabled = true;
            this.MenuItem_Delete.Enabled = false;
            txtUsuario.Focus();
            this.obj_Toupdate = null;
            dgvUsuarios.ClearSelection();
            cleanControls();
            InformacionGeneralPanel.Enabled = true;
            cboRoles.SelectedItem = null;
        }
        public void cleanControls()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtRepetirPassword.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            cboRoles.SelectedItem = null;
            
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {

            if (Validator())
            {
                UsuarioItem p = new UsuarioItem()
                {
                    ID = Guid.NewGuid(),
                    NOMBRE_COMPLETO = txtNombreCompleto.Text,
                    PASSWORD = txtPassword.Text,
                    USUARIO = txtUsuario.Text,
                    ROL = cboRoles.Text,
                    ESTADO = true
                };
                if (this.obj_Toupdate == null)
                {
                    var result = this._UsuarioCommands.ADD(p);
                }
                else
                {
                    p.ID = this.obj_Toupdate.ID;
                    this._UsuarioCommands.UPDATE(p);
                }
                GetUsuarios("");
                cleanControls();
                InformacionGeneralPanel.Enabled = false;
            }
        }

        public bool Validator()
        {
            errorProvider1.Clear();
            bool Validated = true;
            if (txtUsuario.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtUsuario, "Debe ingresar Nombre del Usuario");
                Validated = false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtPassword, "Debe Ingresar el Password");
                Validated = false;
            }
            if (txtRepetirPassword.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtRepetirPassword, "Debe Ingresar repetir el password");
                Validated = false;
            }
            if (txtNombreCompleto.Text.Trim() == ""  )
            {
                errorProvider1.SetError((Control)txtNombreCompleto, "Debe ingresar nombre completo dle usuario");
                Validated = false;
            }
            if (cboRoles.Text.Trim() == "" || cboRoles.SelectedItem == null)
            {
                errorProvider1.SetError((Control)cboRoles, "Debe seleccionar un Rol");
                Validated = false;
            }
            if (txtPassword.Text.Trim() != txtRepetirPassword.Text.Trim())
            {
                errorProvider1.SetError((Control)txtPassword, "Los Password son diferentes");
                errorProvider1.SetError((Control)txtRepetirPassword, "Los Password son diferentes");
                Validated = false;
            }

            return Validated;
        }

        private void MenuItem_Delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Estas seguro de eliminar este usuario?",
                                     ".:: Mensaje del Sistema ::.",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this._UsuarioCommands.DELETE(this.obj_Toupdate.ID);
                this.cleanControls();
                this.obj_Toupdate = null;
                MenuItem_Save.Enabled = false;
                MenuItem_Delete.Enabled = false;
                this.GetUsuarios("");
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                UsuarioItem valor = (UsuarioItem)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
                FillControls(valor);
                this.obj_Toupdate = valor;
            }
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }

        public void FillControls(UsuarioItem p)
        {
            if (p != null)
            {
                txtUsuario.Text = p.USUARIO;
                txtPassword.Text= p.PASSWORD;
                txtRepetirPassword.Text = p.PASSWORD;
                txtNombreCompleto.Text = p.NOMBRE_COMPLETO;
                cboRoles.Text = p.ROL;
                InformacionGeneralPanel.Enabled = true;
            }
        }
    }
}
