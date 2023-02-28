using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Minimercado
{
    public partial class FrmImpresoraFiscal : Form
    {
        private string sCmd = string.Empty;
        private string sCmdExt = string.Empty;
        private bool bAnswer = true;
        private double timeDelay = double.Parse(System.Configuration.ConfigurationSettings.AppSettings["delay"]);

        public FrmImpresoraFiscal()
        {
            InitializeComponent();
        }

        private void FrmImpresoraFiscal_Load(object sender, EventArgs e)
        {
            ConectarIF();
        }

        void FrmImpresoraFiscal_Activated(object sender, EventArgs e)
        {
            
        }

        private void Delay()
        {
            Application.DoEvents();
            Thread.Sleep((int)TimeSpan.FromSeconds(timeDelay).TotalMilliseconds);
            Application.DoEvents();

        }
        private bool ConectarIF()
        {
            bool res = true;
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Test Printer - Error Conectado impresora Fiscal");
                res = false;
            }
            finally {
                Delay();
                RefreshStatus();
            }
            return res;
        }

        private void RefreshStatus()
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {

        }

        private void btnCierreX_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("ERROR Cierre  X -> " + ex.Message, "IF.log"); }
                catch { }
                MessageBox.Show("Exception --> " + ex.Message);
            }
            finally
            {
                RefreshStatus();
            }
        }

        private void btnCierreZ_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("ERROR Cierre  Z -> " + ex.Message, "IF.log"); }
                catch { }
                MessageBox.Show("Exception --> " + ex.Message);
            }
            finally
            {
                RefreshStatus();
            }
        }

        private void btnInformeCierreZ_Click(object sender, EventArgs e)
        {
            string step = "";
            try
            {


            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("ERROR Informe Cierre  Z -> " + ex.Message + " --> Step: " + step, "IF.log"); }
                catch { }
                MessageBox.Show("Exception --> " + ex.Message);
            }
            finally
            {
                RefreshStatus();
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string step = "";
            try
            {


            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("ERROR Informe Cierre  Z -> " + ex.Message + " --> Step: " + step, "IF.log"); }
                catch { }
                MessageBox.Show("Exception --> " + ex.Message);
            }
            finally
            {
                RefreshStatus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
