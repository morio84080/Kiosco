using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proveedor.Business;
using Proveedor.Entities;
using Caja.Business;
using Caja.Entities;

namespace Minimercado
{
    public partial class FrmCaja : Form
    {
        CajaBUS cajaSys = new CajaBUS();
        int idOriDes = -1;
        bool cargoFormulario = false;
        CajaEntity caja = new CajaEntity();

        public FrmCaja()
        {
            InitializeComponent();
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            if (!GlobalClass.tipoCaja) 
                lblOrigenDestino.Text = "Origen";
            else
                lblOrigenDestino.Text = "Destino";

            LlenarCboOrigenDestino();
            
            if (GlobalClass.ActionType == 2) {
                CajaGetById();
                CompletarCampos();
            }

            cboOrigenDestino.Focus();
        }

        void FrmCaja_Activated(object sender, EventArgs e)
        {
            cargoFormulario = true;
        }


        private void CajaGetById() {
            try
            {
                caja = cajaSys.getCajaByID(GlobalClass.DecimalNumber);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error obteniendo movimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            } 
        }

        private void CompletarCampos() {
            try
            {
                dtpFecha.Value = caja.FechaCaja;
                cboOrigenDestino.SelectedValue = caja.OriDesCaja;
                txtNroFact.Text = caja.NroFactCaja;
                txtImporte.Text = caja.SubtotalCaja.ToString();
                cboIvaArt.Text = caja.PorcIvaCaja.ToString();
                txtTotal.Text = caja.TotalCaja.ToString();
                txtIVA.Text = caja.IvaCaja.ToString();
                txtDetalle.Text = caja.DetalleCaja;
                txtNroFact.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error obteniendo movimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LlenarCboOrigenDestino()
        {
            if (cajaSys.LlenarComboOrigenDestino(this.cboOrigenDestino, GlobalClass.tipoCaja) == -1)
                this.Close();


            if (GlobalClass.ActionType == 1)
                this.cboOrigenDestino.SelectedValue = -1;
        }
        void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtImporte.Focus();
                e.Handled = true;
            }
        }


        void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboIvaArt.Focus();
                e.Handled = true;
            }
            else if (e.KeyChar == 46)
            {
                e.KeyChar = Convert.ToChar(44);
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }

        void txtImporte_GotFocus(object sender, EventArgs e)
        {
            txtImporte.BackColor = System.Drawing.Color.LightCyan;
            txtImporte.SelectionStart = 0;
            txtImporte.SelectionLength = txtImporte.Text.Length;
        }

        void txtImporte_Click(object sender, EventArgs e)
        {
            txtImporte.SelectionStart = 0;
            txtImporte.SelectionLength = txtImporte.Text.Length;
        }

        void txtImporte_LostFocus(object sender, EventArgs e)
        {
            txtImporte.BackColor = System.Drawing.Color.GhostWhite;
            txtImporte.SelectionStart = 0;
            txtImporte.SelectionLength = txtImporte.Text.Length;
        }

        private bool IsNumeric(char keyAscii)
        {
            if (keyAscii < 48 || keyAscii > 57)
            {
                if (keyAscii == 8 || keyAscii == 44)
                    return true;
                else
                    return false;
            }
            return true;

        }

        void txtNroFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboOrigenDestino.Focus();
                e.Handled = true;
            }

        }

        void txtNroFact_GotFocus(object sender, EventArgs e)
        {
            txtNroFact.BackColor = System.Drawing.Color.LightCyan;
            txtNroFact.SelectionStart = 0;
            txtNroFact.SelectionLength = txtNroFact.Text.Length;
        }

        void txtNroFact_Click(object sender, EventArgs e)
        {
            txtNroFact.SelectionStart = 0;
            txtNroFact.SelectionLength = txtNroFact.Text.Length;
        }

        void txtNroFact_LostFocus(object sender, EventArgs e)
        {
            txtNroFact.BackColor = System.Drawing.Color.GhostWhite;
            txtNroFact.SelectionStart = 0;
            txtNroFact.SelectionLength = txtNroFact.Text.Length;
        }


        void txtDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAceptar.Focus();
                e.Handled = true;
            }

        }

        void txtDetalle_GotFocus(object sender, EventArgs e)
        {
            txtDetalle.BackColor = System.Drawing.Color.LightCyan;
            txtDetalle.SelectionStart = 0;
            txtDetalle.SelectionLength = txtDetalle.Text.Length;
        }

        void txtDetalle_Click(object sender, EventArgs e)
        {
            txtDetalle.SelectionStart = 0;
            txtDetalle.SelectionLength = txtDetalle.Text.Length;
        }

        void txtDetalle_LostFocus(object sender, EventArgs e)
        {
            txtDetalle.BackColor = System.Drawing.Color.GhostWhite;
            txtDetalle.SelectionStart = 0;
            txtDetalle.SelectionLength = txtDetalle.Text.Length;
        }

        void cboIvaArt_GotFocus(object sender, EventArgs e)
        {
            cboIvaArt.BackColor = System.Drawing.Color.LightCyan;
        }

        void cboIvaArt_LostFocus(object sender, EventArgs e)
        {
            cboIvaArt.BackColor = System.Drawing.Color.GhostWhite;
        }


        void cboIvaArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDetalle.Focus();
                e.Handled = true;
            }
        }

        private void cboIvaArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDetalle.Focus();
                e.Handled = true;
            }
        }

        private void cboIvaArti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargoFormulario)
                calcularSubtotal();
        }

        private void calcularSubtotal() { 

            if (string.IsNullOrEmpty( txtImporte.Text)) txtImporte.Text="0";
            if (string.IsNullOrEmpty( cboIvaArt.Text)) cboIvaArt.Text="21";
            decimal importe = Convert.ToDecimal(txtImporte.Text);
            decimal porcIva = Convert.ToDecimal(cboIvaArt.Text);
            decimal totalIVa = importe * (porcIva / 100);
            txtIVA.Text = Math.Round(totalIVa, 2).ToString();
            decimal total = importe + totalIVa;
            txtTotal.Text = Math.Round(total, 2).ToString();

        }

        private bool verifyInfo()
        {

            if (string.IsNullOrEmpty(txtImporte.Text))
            {
                MessageBox.Show("Debe ingresar un Importe", "Dato Incorrecto");
                txtImporte.Focus();
                return false;
            }
            else if (Convert.ToInt32(cboOrigenDestino.SelectedValue)<=0)
            {
                MessageBox.Show("Debe seleccionar el " + (GlobalClass.tipoCaja?"Destino": "Origen"), "Dato Incorrecto");
                cboOrigenDestino.Focus();
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (verifyInfo())
                switch (GlobalClass.ActionType)
                {

                    case 1: //Nuevo
                    case 3: //Presupuesto
                    case 4: //Pago
                        Insert();
                        break;
                    case 2: //Modificar
                        Update();
                        break;
                    default:
                        MessageBox.Show("Opción Incorrecta");
                        break;
                }
        }

        private void Insert()
        {
            try
            {
                double totalIVA = 0;
                CajaEntity Ety = new CajaEntity();

                Ety.FechaCaja = dtpFecha.Value;
                Ety.OriDesCaja = Convert.ToInt32(cboOrigenDestino.SelectedValue);
                Ety.SubtotalCaja = Convert.ToDecimal(txtImporte.Text);
                Ety.TotalCaja = Convert.ToDecimal(txtTotal.Text);
                Ety.PorcIvaCaja = Convert.ToDecimal(cboIvaArt.Text);
                Ety.NroFactCaja = txtNroFact.Text.Trim();
                Ety.IvaCaja = Convert.ToDecimal(txtIVA.Text);
                Ety.DetalleCaja = txtDetalle.Text;
                Ety.TipoCaja = GlobalClass.tipoCaja;
                Ety.TipoCtaCaja = checkBoxTipoCtaCaja.Checked;

                cajaSys.ProcesarCaja(Ety, GlobalClass.UserID);

                MessageBox.Show("Registro guardado con éxito");

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error grabando NotaCompra");
            }
        }

        private void Update()
        {
            try
            {
                double totalIVA = 0;
                CajaEntity Ety = new CajaEntity();

                Ety.FechaCaja = dtpFecha.Value;
                Ety.OriDesCaja = Convert.ToInt32(cboOrigenDestino.SelectedValue);
                Ety.SubtotalCaja = Convert.ToDecimal(txtImporte.Text);
                Ety.TotalCaja = Convert.ToDecimal(txtTotal.Text);
                Ety.PorcIvaCaja = Convert.ToDecimal(cboIvaArt.Text);
                Ety.NroFactCaja = txtNroFact.Text.Trim();
                Ety.IvaCaja = Convert.ToDecimal(txtIVA.Text);
                Ety.DetalleCaja = txtDetalle.Text;
                Ety.TipoCaja = GlobalClass.tipoCaja;
                Ety.IdCaja = caja.IdCaja;
                Ety.TipoCtaCaja = checkBoxTipoCtaCaja.Checked;

                cajaSys.ModificarCaja (Ety, GlobalClass.UserID);

                MessageBox.Show("Registro guardado con éxito");

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error grabando NotaCompra");
            }
        }

        private void ClearFiles() {
            txtImporte.Text = string.Empty;
            txtNroFact.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            txtNroFact.Focus();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            if (cargoFormulario)
                calcularSubtotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calcularIvaManual() {
            decimal iva = Convert.ToDecimal(txtIVA.Text);
            decimal importe = Convert.ToDecimal(txtImporte.Text);
            decimal total = iva + importe;
            txtTotal.Text = Math.Round(total, 2).ToString();
        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {
            calcularIvaManual();
        }
    }
}
