namespace Presentacion
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemProducto,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.MenuItemCompras,
            this.MenuItemVentas,
            this.MenuItemServicios,
            this.toolStripMenuItem6,
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.MenuItemWarehouse});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.MenuItemProducto;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(180, 765);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemProducto
            // 
            this.MenuItemProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemProducto.Image = global::Presentacion.Properties.Resources.product;
            this.MenuItemProducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemProducto.Name = "MenuItemProducto";
            this.MenuItemProducto.Size = new System.Drawing.Size(167, 72);
            this.MenuItemProducto.Text = "PRODUCTOS";
            this.MenuItemProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuItemProducto.Click += new System.EventHandler(this.MenuItemProducto_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem2.Image = global::Presentacion.Properties.Resources.proveedor;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 72);
            this.toolStripMenuItem2.Text = "PROVEEDORES";
            this.toolStripMenuItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem1.Image = global::Presentacion.Properties.Resources.categories;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 72);
            this.toolStripMenuItem1.Text = "CARACTERISTICAS";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MenuItemCompras
            // 
            this.MenuItemCompras.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemCompras.Image = global::Presentacion.Properties.Resources.compras;
            this.MenuItemCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemCompras.Name = "MenuItemCompras";
            this.MenuItemCompras.Size = new System.Drawing.Size(167, 72);
            this.MenuItemCompras.Text = "COMPRAS";
            this.MenuItemCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuItemCompras.Click += new System.EventHandler(this.MenuItemCompras_Click);
            // 
            // MenuItemVentas
            // 
            this.MenuItemVentas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemVentas.Image = global::Presentacion.Properties.Resources.ventas;
            this.MenuItemVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemVentas.Name = "MenuItemVentas";
            this.MenuItemVentas.Size = new System.Drawing.Size(167, 72);
            this.MenuItemVentas.Text = "VENTAS";
            this.MenuItemVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuItemVentas.Click += new System.EventHandler(this.MenuItemVentas_Click);
            // 
            // MenuItemServicios
            // 
            this.MenuItemServicios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemServicios.Image = global::Presentacion.Properties.Resources.service;
            this.MenuItemServicios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemServicios.Name = "MenuItemServicios";
            this.MenuItemServicios.Size = new System.Drawing.Size(167, 72);
            this.MenuItemServicios.Text = "SERVICIOS";
            this.MenuItemServicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuItemServicios.Click += new System.EventHandler(this.MenuItemServicios_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem6.Image = global::Presentacion.Properties.Resources.exit;
            this.toolStripMenuItem6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(167, 72);
            this.toolStripMenuItem6.Text = "SALIR";
            this.toolStripMenuItem6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem8.Image = global::Presentacion.Properties.Resources.users;
            this.toolStripMenuItem8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(167, 72);
            this.toolStripMenuItem8.Text = "USUARIOS";
            this.toolStripMenuItem8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem7.Image = global::Presentacion.Properties.Resources.report;
            this.toolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(167, 72);
            this.toolStripMenuItem7.Text = "REPORTES";
            this.toolStripMenuItem7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // MenuItemWarehouse
            // 
            this.MenuItemWarehouse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemWarehouse.Image = global::Presentacion.Properties.Resources.warehouse;
            this.MenuItemWarehouse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemWarehouse.Name = "MenuItemWarehouse";
            this.MenuItemWarehouse.Size = new System.Drawing.Size(167, 72);
            this.MenuItemWarehouse.Text = "MOVER DE ALMACEN";
            this.MenuItemWarehouse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuItemWarehouse.Click += new System.EventHandler(this.MenuItemWarehouse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 765);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProducto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCompras;
        private System.Windows.Forms.ToolStripMenuItem MenuItemVentas;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWarehouse;
        private System.Windows.Forms.ToolStripMenuItem MenuItemServicios;
    }
}

