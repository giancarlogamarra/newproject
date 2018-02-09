using Persistencia.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Producto
{
    public partial class frmAdminProducto : Form
    {
        IProductoQueryHandler _queries;
        public frmAdminProducto(IProductoQueryHandler query)
        {
            this._queries = query;
            InitializeComponent();
        }

        private void frmAdminProducto_Load(object sender, EventArgs e)
        {

        }
        public async void GetProductos()
        {
            var result = await _queries.GET();
        }
    }
}
