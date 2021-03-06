﻿using Presentacion.Almacen;
using Presentacion.Caracteristicas;
using Presentacion.Compras;
using Presentacion.Producto;
using Presentacion.Proveedor;
using Presentacion.Reportes;
using Presentacion.Servicios;
using Presentacion.Usuarios;
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
            var BL = Program.container.GetInstance<frmLogin>();
            BL.ShowDialog();
            InitializeComponent();
            if (BL.usuario.ROL == "user")
            {
                MenuItemProducto.Visible = false;// PRODUCTOS
                toolStripMenuItem2.Visible = false; //PROVEEDORES
                toolStripMenuItem8.Visible = false; //USUARIOS
                toolStripMenuItem1.Visible = false; // CARACTERISTICAS
                toolStripMenuItem7.Visible = false; // REPORTES
            }
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

        private void MenuItemWarehouse_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmAlmacen))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmAlmacen>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItemServicios_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmServicios))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmServicios>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmReportes))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmReportes>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmAdminProveedor))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmAdminProveedor>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmAdminCaracteristicas))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmAdminCaracteristicas>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmAdminUsuarios))
                {
                    form.Activate();
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            var BL = Program.container.GetInstance<frmAdminUsuarios>();
            BL.MdiParent = this;
            BL.StartPosition = FormStartPosition.CenterScreen;
            BL.Show();
        }
    }
}
