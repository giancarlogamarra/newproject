using DTOs.Usuario;
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

namespace Presentacion
{
    public partial class frmLogin : Form
    {
        IUsuarioCommandsHandler Usuario_Command;
        public frmLogin(IUsuarioCommandsHandler command_usuario)
        {
            InitializeComponent();
            Usuario_Command = command_usuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            this.btnAcceder.Enabled = false;
            UsuarioItem usuario = await Usuario_Command.VALIDAR_ACCESO(txtUsuario.Text.Trim(), txtPassword.Text.Trim());
            if (usuario != null)
            {
                this.Close();
            }
            else
            {
                this.btnAcceder.Enabled = true;
                MessageBox.Show("Usuario o Contraseña incorrectas");
            }
        }
    }
}
