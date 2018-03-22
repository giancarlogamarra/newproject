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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtpVentas = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarVentas = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dtpFechaDiario = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarVentasDiario = new System.Windows.Forms.Button();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1083, 512);
            this.reportViewer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1097, 619);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1089, 586);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "VENTAS MENSUAL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtpVentas);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerarVentas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1083, 580);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.TabIndex = 3;
            // 
            // dtpVentas
            // 
            this.dtpVentas.Location = new System.Drawing.Point(21, 17);
            this.dtpVentas.Name = "dtpVentas";
            this.dtpVentas.Size = new System.Drawing.Size(200, 26);
            this.dtpVentas.TabIndex = 5;
            // 
            // btnGenerarVentas
            // 
            this.btnGenerarVentas.Location = new System.Drawing.Point(247, 10);
            this.btnGenerarVentas.Name = "btnGenerarVentas";
            this.btnGenerarVentas.Size = new System.Drawing.Size(126, 44);
            this.btnGenerarVentas.TabIndex = 0;
            this.btnGenerarVentas.Text = "GENERAR";
            this.btnGenerarVentas.UseVisualStyleBackColor = true;
            this.btnGenerarVentas.Click += new System.EventHandler(this.btnGenerarVentas_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1089, 586);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "VENTAS DIARIO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dtpFechaDiario);
            this.splitContainer2.Panel1.Controls.Add(this.btnGenerarVentasDiario);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.reportViewer2);
            this.splitContainer2.Size = new System.Drawing.Size(1083, 580);
            this.splitContainer2.SplitterDistance = 64;
            this.splitContainer2.TabIndex = 4;
            // 
            // dtpFechaDiario
            // 
            this.dtpFechaDiario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDiario.Location = new System.Drawing.Point(21, 17);
            this.dtpFechaDiario.Name = "dtpFechaDiario";
            this.dtpFechaDiario.Size = new System.Drawing.Size(183, 26);
            this.dtpFechaDiario.TabIndex = 5;
            // 
            // btnGenerarVentasDiario
            // 
            this.btnGenerarVentasDiario.Location = new System.Drawing.Point(247, 10);
            this.btnGenerarVentasDiario.Name = "btnGenerarVentasDiario";
            this.btnGenerarVentasDiario.Size = new System.Drawing.Size(126, 44);
            this.btnGenerarVentasDiario.TabIndex = 0;
            this.btnGenerarVentasDiario.Text = "GENERAR";
            this.btnGenerarVentasDiario.UseVisualStyleBackColor = true;
            this.btnGenerarVentasDiario.Click += new System.EventHandler(this.btnGenerarVentasDiario_Click);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(1083, 512);
            this.reportViewer2.TabIndex = 2;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 619);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnGenerarVentas;
        private System.Windows.Forms.DateTimePicker dtpVentas;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DateTimePicker dtpFechaDiario;
        private System.Windows.Forms.Button btnGenerarVentasDiario;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}