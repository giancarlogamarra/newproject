﻿using DTOs.Servicio;
using Persistencia.Caracteristica;
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

namespace Presentacion.Servicios
{
    public partial class frmServicios : Form
    {

        ICaracteristicaCommandsHandler _Productoscommands;
        IServicioCommandsHandler _Servicioscommands;
        ServicioItem obj_Toupdate;
        public frmServicios(ICaracteristicaCommandsHandler _command, IServicioCommandsHandler _commandServicio)
        {
            InitializeComponent();
            this._Productoscommands = _command;
            this._Servicioscommands = _commandServicio;
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            GetTipoServicios();
            GetServicios("");
        }
        public async void GetServicios(string search)
        {
            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.DataSource = await _Servicioscommands.GET(search);
            dgvServicios.ClearSelection();

        }
        public async void GetTipoServicios()
        {
            this.cboTipoServicio.DataSource = await _Productoscommands.GET("SERVICIOS");

        }

        private void MenuItem_New_Click(object sender, EventArgs e)
        {
            InformacionGeneralPanel.Enabled = true;
            MenuItem_Save.Enabled = true;
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                ServicioItem s = new ServicioItem()
                {
                    ID = Guid.NewGuid(),
                    TIPO_ID = (Guid)(cboTipoServicio.SelectedValue == null ? Guid.Parse("00000000-0000-0000-0000-000000000000") : cboTipoServicio.SelectedValue),
                    DESCRIPCION = txtDescripcion.Text,
                    FECHA_SOLICITUD = dtpFechaSolicitud.Value,
                    FECHA_ENTREGA = dtpFechaEntrega.Value,
                    CANTIDAD = (int)txtCantidad.Value,
                    COSTO_TOTAL = txtCostoTotal.Value,
                    ADELANTO = txtAdelanto.Value,
                    CANCELADO = (rbYes.Checked ? true : false),
                    USUARIO = "user",
                    CLIENTE_NOMBRE=txtNombreCliente.Text.ToUpper(),
                    CLIENTE_TELEFONO=txtTelefonoCliente.Text
                };
                if (this.obj_Toupdate == null)
                {
                    var result = this._Servicioscommands.ADD(s);
                }
                else
                {
                    s.ID = this.obj_Toupdate.ID;
                    //s.USUARIO_MODIFICACION = "demo";
                    //s.FECHA_MODIFICACION = DateTime.Now;
                    this._Servicioscommands.UPDATE(s);
                }
                 GetServicios("");
                cleanControls();
                InformacionGeneralPanel.Enabled = false;
            }
        }

        public bool Validator()
        {
            errorProvider1.Clear();
            bool Validated = true;
            if (txtDescripcion.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtDescripcion, "Debe ingresar dealle de la descripcion");
                Validated = false;
            }
            if (dtpFechaSolicitud.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)dtpFechaSolicitud, "Fecha de Solicitud es requerido");
                Validated = false;
            }
            if (dtpFechaEntrega.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtDescripcion, "Fecha de Entrega es requerido");
                Validated = false;
            }
            if (txtCantidad.Text.Trim() == "" || txtCantidad.Value == 0)
            {
                errorProvider1.SetError((Control)txtCantidad, "Debe ingresar una cantidad");
                Validated = false;
            }
            if (txtCostoTotal.Text.Trim() == "")
            {
                errorProvider1.SetError((Control)txtCostoTotal, "Debe ingresar el costo total del servicio");
                Validated = false;
            }
            return Validated;
        }
        public void cleanControls()
        {
            dtpFechaEntrega.Text = string.Empty;
            dtpFechaSolicitud.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Value = 0;
            txtCostoTotal.Value = 0;
            // txtFechaCreacion.Text = string.Empty;
            //txtUsuarioModificacion.Text = string.Empty;
            //txtFechaModificacion.Text = string.Empty;
            txtAdelanto.Value = 0;
            rbYes.Checked = true;
        }

        private void InformacionGeneralPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ServicioItem valor = (ServicioItem)dgvServicios.Rows[e.RowIndex].DataBoundItem;
                FillControls(valor);
                this.obj_Toupdate = valor;
            }
            this.MenuItem_Delete.Enabled = true;
            this.MenuItem_Save.Enabled = true;
        }

        public void FillControls(ServicioItem s)
        {
            if (s != null)
            {
                txtNombreCliente.Text = s.CLIENTE_NOMBRE;
                txtTelefonoCliente.Text = s.CLIENTE_TELEFONO;
                cboTipoServicio.SelectedValue = s.TIPO_ID;
                txtDescripcion.Text = s.DESCRIPCION;
                dtpFechaSolicitud.Value = s.FECHA_SOLICITUD;
                dtpFechaEntrega.Value = s.FECHA_ENTREGA;
                txtCantidad.Value = s.CANTIDAD;
                txtCostoTotal.Value = s.COSTO_TOTAL;
                txtAdelanto.Value = s.ADELANTO;
                rbYes.Checked = (s.CANCELADO ? true : false);
                rbNo.Checked = (s.CANCELADO ? false : true);
                InformacionGeneralPanel.Enabled = true;

            }
        }

    }
}
