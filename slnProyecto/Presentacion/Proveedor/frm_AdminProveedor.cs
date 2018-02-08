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
    public partial class frm_AdminProveedor : Form
    {
        public frm_AdminProveedor(IProveedorQueryHandler query)
        {
            string result= query.GET();
            InitializeComponent();
        }
        private void frm_AdminProveedor_Load(object sender, EventArgs e)
            {

        }
    }
}
