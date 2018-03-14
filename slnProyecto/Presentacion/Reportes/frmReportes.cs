using DTOs.Reportes;
using Microsoft.Reporting.WinForms;
using Persistencia.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class frmReportes : Form
    {
        IReportesCommandsHandler _Commands;
        public frmReportes(IReportesCommandsHandler reporteCommands)
        {
            InitializeComponent();
            this._Commands = reporteCommands;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void MenuItemVentas_Click(object sender, EventArgs e)
        {

            IEnumerable<SP_REP_INGRESOS> data= this._Commands.GET_REP_INGRESOS();
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.files.rep_Ingresos.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", data);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport();
        }
    }
}
