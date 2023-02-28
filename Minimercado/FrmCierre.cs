using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caja.Entities;
using Caja.Business;

namespace Minimercado
{
    public partial class FrmCierre : Form
    {
        CajaBUS Bus = new CajaBUS();
        int perfilId = 0;
        public FrmCierre()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCierre_Load(object sender, EventArgs e)
        {
            obtenerInfo();
            txtSaldo.Focus();
            perfilId = new Vendedor.Business.VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;
            if (perfilId > 0) groupBox2.Visible = true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            try
            {
                if (string.IsNullOrEmpty(txtSaldo.Text)) txtSaldo.Text = "0";
                CierreCajaEntity cierreCaja = new CierreCajaEntity();
                cierreCaja.CtaCteCica = Convert.ToDecimal(txtCtaCte.Text);
                cierreCaja.EfectivoCica = Convert.ToDecimal(txtEfectivo.Text);
                cierreCaja.EgresoCajaCica = Convert.ToDecimal(txtEgreso.Text);
                cierreCaja.IngresoCajaCica = Convert.ToDecimal(txtIngreso.Text);
                cierreCaja.SaldoCica = Convert.ToDecimal(txtSaldo.Text);
                cierreCaja.TarjCreditoCica = Convert.ToDecimal(txtTarjetaCredito.Text);
                cierreCaja.TarjDebitoCica = Convert.ToDecimal(txtTarjetaDebito.Text);
                cierreCaja.TotalNotaCreditoCica = Convert.ToDecimal(txtNotaCredito.Text);
                cierreCaja.TotalVtaCica = Convert.ToDecimal(txtTotalVtas.Text);
                cierreCaja.MercadoPagoCica= Convert.ToDecimal(txtMercadoPago.Text);
                Bus.ProcesarCierreCaja(cierreCaja,GlobalClass.UserID);
                MessageBox.Show("Cierre Guardado con éxito", "Cierre Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error procesando cierre de caja --> " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerInfo() {

            try
            {
                CierreCajaEntity cierreCaja = new CierreCajaEntity();
                cierreCaja = Bus.getCierreCajaByID(GlobalClass.IntPrimaryKey);

                txtTotalVtas.Text = cierreCaja.TotalVtaCica.ToString();
                txtNotaCredito.Text = cierreCaja.TotalNotaCreditoCica.ToString();
                txtEfectivo.Text = cierreCaja.EfectivoCica.ToString();
                txtTarjetaDebito.Text = cierreCaja.TarjDebitoCica.ToString();
                txtTarjetaCredito.Text = cierreCaja.TarjCreditoCica.ToString();
                txtMercadoPago.Text = cierreCaja.MercadoPagoCica.ToString();
                txtIngreso.Text = cierreCaja.IngresoCajaCica.ToString();
                txtEgreso.Text = cierreCaja.EgresoCajaCica.ToString();
                txtCtaCte.Text = cierreCaja.CtaCteCica.ToString();
                txtSaldoAnterior.Text = cierreCaja.SaldoCica.ToString();

                txtTotal.Text = Convert.ToString(cierreCaja.TotalVtaCica - cierreCaja.TotalNotaCreditoCica);
                txtTotalCaja.Text = Convert.ToString(cierreCaja.EfectivoCica + cierreCaja.TarjDebitoCica + cierreCaja.TarjCreditoCica + cierreCaja.IngresoCajaCica + cierreCaja.MercadoPagoCica -cierreCaja.EgresoCajaCica + cierreCaja.CtaCteCica + cierreCaja.SaldoCica);
                txtSaldoEfectivo.Text = (cierreCaja.EfectivoCica - cierreCaja.EgresoCajaCica + cierreCaja.SaldoCica+cierreCaja.IngresoCajaCica).ToString();
                txtSaldo.Text = "2000";// txtSaldoEfectivo.Text;
            }
            catch (Exception ex) {
                MessageBox.Show("Error obteniendo info de cierre de caja", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
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
    }
}
