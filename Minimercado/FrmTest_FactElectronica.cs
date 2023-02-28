using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacturaElectronica.Business;
using FacturaElectronica.Entities;

namespace Minimercado
{
    public partial class FrmTest_FactElectronica : Form
    {
        public FrmTest_FactElectronica()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem(); //TESTING
                //wsaaProdSystem wasass = new wsaaProdSystem(); //PRODUCCION
                wasass.FEParamGetPtosVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem();
                //wsaaProdSystem wasass = new wsaaProdSystem(); //PRODUCCION
                wasass.FEParamGetTiposCbte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem();
                wasass.FEParamGetTiposConcepto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem();
                wasass.FEParamGetTiposDoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem();
                wasass.FEParamGetTiposIva();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem();
                wasass.FEParamGetTiposMonedas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //wsassSystem wasass = new wsassSystem();
                //List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                //AlicIvaEntity ety = new AlicIvaEntity();
                //ety.id = 5;
                //ety.Importe = 21;
                //ety.BaseImp = 100;
                //ivas.Add(ety);
                //ety = new AlicIvaEntity();
                //ety.id = 4;
                //ety.Importe = 5.25;
                //ety.BaseImp = 50;
                //ivas.Add(ety);
                //int ptoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);

                //FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                //res= wasass.FECAESolicitar(1,1,1,80,20281716078,176.25,150,26.25,ivas,DateTime.Now,"PES",ptoVta);

                //if (res.FeCabResp.Resultado != "A")
                //{
                //    if (res.Errors != null)
                //        MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                //    else
                //        MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //wsassSystem wasass = new wsassSystem();
                wsaaProdSystem wasass = new wsaaProdSystem(); //PRODUCCION
                wasass.FECompUltimoAutorizado(3,1);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                //wsassSystem wasass = new wsassSystem();
                //List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                //AlicIvaEntity ety = new AlicIvaEntity();
                //ety.id = 5;
                //ety.Importe = 21;
                //ety.BaseImp = 100;
                //ivas.Add(ety);
                //ety = new AlicIvaEntity();
                //ety.id = 4;
                //ety.Importe = 5.25;
                //ety.BaseImp = 50;
                //ivas.Add(ety);
                //int ptoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);

                //FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                //res = wasass.FECAESolicitar(1, 6, 1, 96, 28171607, 176.25, 150, 26.25, ivas, DateTime.Now, "PES",ptoVta);

                //if (res.FeCabResp.Resultado != "A")
                //{
                //    if (res.Errors != null)
                //        MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                //    else
                //        MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                //wsassSystem wasass = new wsassSystem();
                //List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                //AlicIvaEntity ety = new AlicIvaEntity();
                //ety.id = 5;
                //ety.Importe = 21;
                //ety.BaseImp = 100;
                //ivas.Add(ety);
                //ety = new AlicIvaEntity();
                //ety.id = 4;
                //ety.Importe = 5.25;
                //ety.BaseImp = 50;
                //ivas.Add(ety);
                //int ptoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);

                //FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                //res = wasass.FECAESolicitar(1, 3, 1, 80, 20281716078, 176.25, 150, 26.25, ivas, DateTime.Now, "PES",ptoVta);

                //if (res.FeCabResp.Resultado != "A")
                //{
                //    if (res.Errors != null)
                //        MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                //    else
                //        MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                //wsassSystem wasass = new wsassSystem();
                //List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                //AlicIvaEntity ety = new AlicIvaEntity();
                //ety.id = 5;
                //ety.Importe = 21;
                //ety.BaseImp = 100;
                //ivas.Add(ety);
                //ety = new AlicIvaEntity();
                //ety.id = 4;
                //ety.Importe = 5.25;
                //ety.BaseImp = 50;
                //ivas.Add(ety);
                //int ptoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);

                //FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                //res = wasass.FECAESolicitar(1, 8, 1, 96, 28171607, 176.25, 150, 26.25, ivas, DateTime.Now, "PES",ptoVta);

                //if (res.FeCabResp.Resultado != "A")
                //{
                //    if (res.Errors != null)
                //        MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                //    else
                //        MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmTest_FactElectronica_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                //wsassSystem wasass = new wsassSystem();
                wsaaProdSystem wasass = new wsaaProdSystem(); //PRODUCCION
                string res= wasass.FECompConsultar(long.Parse(txtNroComprobante.Text), Convert.ToInt32(txtTipoComprobante.Text), Convert.ToInt32(txtPtoVta.Text));
                MessageBox.Show(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem();
                //List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                //AlicIvaEntity ety = new AlicIvaEntity();
                //ety.id = 5; //IVA 21%
                //ety.Importe = 21000;
                //ety.BaseImp = 100000;
                //ivas.Add(ety);
                ////ety = new AlicIvaEntity();
                ////ety.id = 4; //IVA 10.5%
                ////ety.Importe = 5.25;
                ////ety.BaseImp = 50;
                ////ivas.Add(ety);
                //int ptoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);

                //FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                ////cuit: 33707366589 - Federacion Patronal
                //res = wasass.FECAESolicitar(1, 201, 1, 80, 33707366589, 121000, 100000, 21000, ivas, DateTime.Now, "PES",ptoVta);

                //if (res.FeCabResp.Resultado != "A")
                //{
                //    if (res.Errors != null)
                //        MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                //    else
                //        MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                wsassSystem wasass = new wsassSystem();

                //wsaaProdSystem wasass = new wsaaProdSystem(); //PRODUCCION
                wasass.FEParamGetTiposOpcionales();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                //wsassSystem wasass = new wsassSystem();
                //List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                //AlicIvaEntity ety = new AlicIvaEntity();
                //ety.id = 5; //IVA 21%
                //ety.Importe = 21000;
                //ety.BaseImp = 100000;
                //ivas.Add(ety);
                ////ety = new AlicIvaEntity();
                ////ety.id = 4; //IVA 10.5%
                ////ety.Importe = 5.25;
                ////ety.BaseImp = 50;
                ////ivas.Add(ety);
                //int ptoVta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PtoVta"]);

                //FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                ////cuit: 33707366589 - Federacion Patronal
                //res = wasass.FECAESolicitar(1, 203, 1, 80, 33707366589, 121000, 100000, 21000, ivas, DateTime.Now, "PES",ptoVta);

                //if (res.FeCabResp.Resultado != "A")
                //{
                //    if (res.Errors != null)
                //        MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                //    else
                //        MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
