using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cliente.Business;
using CuentaCorriente.Business;

namespace Minimercado
{
    public partial class RptCtaCteClientePage : Form
    {
        ClienteBUS clieBus = new ClienteBUS();
        public RptCtaCteClientePage()
        {
            InitializeComponent();
        }

        private void LlenarCboCliente()
        {
            if (clieBus.LlenarComboCliente(this.cboCliente) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                //this.cboCliente.SelectedValue = Ety.CobradorCHQ;
                cboCliente.SelectedIndex = 0;
            else
                cboCliente.SelectedIndex = 0;

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtpIniDate.Value > dtpFinDate.Value)
            {
                MessageBox.Show("La fecha de inicio debe ser menor a la de fin");
                return;
            }

            
            DateTime fechaIni = new DateTime(dtpIniDate.Value.Year, dtpIniDate.Value.Month, dtpIniDate.Value.Day, 0, 0, 0);
            DateTime fechaFin = new DateTime(dtpFinDate.Value.Year, dtpFinDate.Value.Month, dtpFinDate.Value.Day, 23, 59, 59);



            int clienteId = 0;
            string clienteNombre = string.Empty;
            if (Convert.ToInt32(cboCliente.SelectedValue) == -1 || cboCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Cliente válido", "Dato Incorrecto");
                cboCliente.Focus();
                return;
            }
            else
            {
                clienteId = Convert.ToInt32(cboCliente.SelectedValue);
                clienteNombre = cboCliente.Text;
     

            }

            if (!checkBoxFecha.Checked)
            {
                try
                {
                    DateTime fechaUltimoPago = new PagoClieBUS().getUltimoPagoPorCliente(clienteId).FechaPACL;
                    fechaIni = new DateTime(fechaUltimoPago.Year, fechaUltimoPago.Month, fechaUltimoPago.Day, 0, 0, 0);
                }
                catch { }
            }

            decimal saldoActual = 0;
            try
            {
                saldoActual = new CuentaCorriente.Business.CtaCteBUS().getSaldoActualClie(clienteId);

            }
            catch(Exception ctccte){
                MessageBox.Show("Error Obteniendo Saldo Actual", ctccte.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                GlobalClass.Text = fechaIni.ToString() + "|" + fechaFin.ToString() + "|" + clienteId.ToString() + "|" + clienteNombre + "|" + saldoActual.ToString();
                //printDocument1.Print();    

                RptCtaCteCliente rtp = new RptCtaCteCliente();
                rtp.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Generando reporte");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RptCtaCteClientePage_Load(object sender, EventArgs e)
        {
            LlenarCboCliente();
            dtpIniDate.Value = DateTime.Now;
            dtpFinDate.Value = DateTime.Now;
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFecha.Checked)
            {
                dtpIniDate.Enabled = true;
                dtpFinDate.Enabled = true;
            }
            else
            {
                dtpIniDate.Enabled = false;
                dtpFinDate.Enabled = false;
            }
        }
    }
}
