using DTOs.Caracteristicas;
using Persistencia.Caracteristica;
using Persistencia.Producto;
using Persistencia.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Caracteristicas
{
    public partial class frmAdminCaracteristicas : Form
    {
        ICaracteristicaCommandsHandler _CommandCaracteristicas;
        IProductoCommandsHandler _Productoscommands;
        IServicioCommandsHandler _Servicioscommands;
        CaracteristicaItem obj_Toupdate = null;

        public frmAdminCaracteristicas(ICaracteristicaCommandsHandler commandCaracteristicas,
            IProductoCommandsHandler prodcommands,IServicioCommandsHandler serviciocommand)
        {
            InitializeComponent();
            this._CommandCaracteristicas = commandCaracteristicas;
            this._Productoscommands = prodcommands;
            this._Servicioscommands = serviciocommand;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 2)
                this.GetCaracteristicas(txtSearch.Text.Trim());

            if (txtSearch.Text.Trim() == "")
                this.GetCaracteristicas("");
        }

        public async void GetCaracteristicas(string search)
        {
            dgvCaracteristicas.AutoGenerateColumns = false;
            dgvCaracteristicas.DataSource = await _CommandCaracteristicas.GET(search);
            dgvCaracteristicas.ClearSelection();
        }

        private void frmAdminCaracteristicas_Load(object sender, EventArgs e)
        {
            GetCaracteristicas("");
            CalcularServiciosEnProceso();
            CalcularReposicionStock();
        }
        public async void CalcularServiciosEnProceso()
        {
            int nro_servicios = await _Servicioscommands.GET_SERVICIOS_EN_PROCESO();
            if (nro_servicios == 0)
                toolTipAlertProcesoServicios.Visible = false;
            else
            {
                toolTipAlertProcesoServicios.Visible = true;
                toolTipAlertProcesoServicios.Text = nro_servicios.ToString();
            }
        }
        public async void CalcularReposicionStock()
        {
            int nro_prod = await _Productoscommands.GET_VERIFICAR_STOCKS_TIENDA_ALARMA();
            if (nro_prod == 0)
                toolTipAlertStockTienda.Visible = false;
            else
            {
                toolTipAlertStockTienda.Visible = true;
                toolTipAlertStockTienda.Text = nro_prod.ToString();
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItem_New_Click(object sender, EventArgs e)
        {
            InformacionGeneralPanel.Enabled = true;
            this.MenuItem_Save.Enabled = true;
            this.MenuItem_Delete.Enabled = false;
            txtValor.Focus();
            this.obj_Toupdate = null;
            dgvCaracteristicas.ClearSelection();
            cleanControls();
            InformacionGeneralPanel.Enabled = true;
            cbCaracteristica.SelectedItem = null;
        }

        public void cleanControls()
        {
            cbCaracteristica.Text = string.Empty;
            txtValor.Text = string.Empty; 
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                CaracteristicaItem p = new CaracteristicaItem()
                {
                    ID = Guid.NewGuid(),
                    CARACTERISTICA = cbCaracteristica.Text,
                    VALOR = txtValor.Text.ToUpper(),
                    ESTADO = true
                };
                if (this.obj_Toupdate == null)
                {
                    var result = this._CommandCaracteristicas.ADD(p);
                }
                else
                {
                    p.ID = this.obj_Toupdate.ID;
                    this._CommandCaracteristicas.UPDATE(p);
                }
                GetCaracteristicas("");
                cleanControls();
                InformacionGeneralPanel.Enabled = false;
            }
        }

        public bool Validator()
        {
            errorProvider1.Clear();
            bool Validated = true;
            if (txtValor.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtValor, "Ingrese el Valor para la Caracteristica");
                Validated = false;
            }
            if (cbCaracteristica.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)cbCaracteristica, "Seleccione una Caracteristica");
                Validated = false;
            }
            
            return Validated;
        }

        private void MenuItem_Delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Estas seguro de eliminar esta caracteristica?",
                                    ".:: Mensaje del Sistema ::.",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this._CommandCaracteristicas.DELETE(this.obj_Toupdate.ID);
                this.cleanControls();
                this.obj_Toupdate = null;
                MenuItem_Save.Enabled = false;
                MenuItem_Delete.Enabled = false;
                this.GetCaracteristicas("");
            }
        }

        private void dgvCaracteristicas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                CaracteristicaItem valor = (CaracteristicaItem)dgvCaracteristicas.Rows[e.RowIndex].DataBoundItem;
                FillControls(valor);
                this.obj_Toupdate = valor;
            }
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }

        public void FillControls(CaracteristicaItem p)
        {
            if (p != null)
            {
                
                InformacionGeneralPanel.Enabled = true;
                //tab auditoria
                txtValor.Text = p.VALOR;
                cbCaracteristica.Text = p.CARACTERISTICA;
            }
        }

    }
}
