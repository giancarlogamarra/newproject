namespace Presentacion.Reportes
{
    partial class frmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemProducto,
            this.toolStripMenuItem2,
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
            this.menuStrip1.Size = new System.Drawing.Size(1097, 76);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemProducto
            // 
            this.MenuItemProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemProducto.Image = global::Presentacion.Properties.Resources.product;
            this.MenuItemProducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemProducto.Name = "MenuItemProducto";
            this.MenuItemProducto.Size = new System.Drawing.Size(109, 72);
            this.MenuItemProducto.Text = "PRODUCTOS";
            this.MenuItemProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem2.Image = global::Presentacion.Properties.Resources.proveedor;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 72);
            this.toolStripMenuItem2.Text = "PROVEEDORES";
            this.toolStripMenuItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuItemCompras
            // 
            this.MenuItemCompras.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemCompras.Image = global::Presentacion.Properties.Resources.compras;
            this.MenuItemCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemCompras.Name = "MenuItemCompras";
            this.MenuItemCompras.Size = new System.Drawing.Size(93, 72);
            this.MenuItemCompras.Text = "COMPRAS";
            this.MenuItemCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuItemVentas
            // 
            this.MenuItemVentas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemVentas.Image = global::Presentacion.Properties.Resources.ventas;
            this.MenuItemVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemVentas.Name = "MenuItemVentas";
            this.MenuItemVentas.Size = new System.Drawing.Size(78, 72);
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
            this.MenuItemServicios.Size = new System.Drawing.Size(95, 72);
            this.MenuItemServicios.Text = "SERVICIOS";
            this.MenuItemServicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem6.Image = global::Presentacion.Properties.Resources.exit;
            this.toolStripMenuItem6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(63, 72);
            this.toolStripMenuItem6.Text = "SALIR";
            this.toolStripMenuItem6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem8.Image = global::Presentacion.Properties.Resources.users;
            this.toolStripMenuItem8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(96, 72);
            this.toolStripMenuItem8.Text = "USUARIOS";
            this.toolStripMenuItem8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem7.Image = global::Presentacion.Properties.Resources.report;
            this.toolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(94, 72);
            this.toolStripMenuItem7.Text = "REPORTES";
            this.toolStripMenuItem7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // MenuItemWarehouse
            // 
            this.MenuItemWarehouse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuItemWarehouse.Image = global::Presentacion.Properties.Resources.warehouse;
            this.MenuItemWarehouse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemWarehouse.Name = "MenuItemWarehouse";
            this.MenuItemWarehouse.Size = new System.Drawing.Size(174, 72);
            this.MenuItemWarehouse.Text = "MOVER DE ALMACEN";
            this.MenuItemWarehouse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(57, 104);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(818, 336);
            this.reportViewer1.TabIndex = 2;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 619);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProducto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCompras;
        private System.Windows.Forms.ToolStripMenuItem MenuItemVentas;
        private System.Windows.Forms.ToolStripMenuItem MenuItemServicios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWarehouse;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}