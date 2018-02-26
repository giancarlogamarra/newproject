using Persistencia.Caracteristica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Servicios
{
    public partial class frmServicios : Form
    {
        
        ICaracteristicaCommandsHandler _Productoscommands;
        public frmServicios(ICaracteristicaCommandsHandler _command)
        {
            InitializeComponent();
            this._Productoscommands = _command;
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            GetTipoServicios();
        }
        public async void GetTipoServicios()
        {
            this.cboTipoServicio.DataSource = await _Productoscommands.GET("SERVICIOS");

        }
    }
}
