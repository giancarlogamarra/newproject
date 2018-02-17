using Presentacion.Compras;
using Presentacion.Producto;
using Presentacion.Ventas;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var BL=Program.container.GetInstance<frmAdminProducto>();
            
            BL.Show();
        }

        private void MenuItemProducto_Click(object sender, EventArgs e)
        {   
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmAdminProducto)) {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            
            var BL = Program.container.GetInstance<frmAdminProducto>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        private void MenuItemCompras_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmCompras))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmCompras>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        private void MenuItemVentas_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmVentas))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmVentas>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        
    }
}
