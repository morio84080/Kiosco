using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ventas.Business;
using Core.Business;
using System.Threading;
using ctc3DES;
using FTP;
using HasarArgentina;
using AFIP.Business;

namespace Minimercado
{
    public partial class FrmHasar : Form
    {
        int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["port"]);
        int IpPuertoHasar = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IpPuertoHasar"]);
        string IpHasar = System.Configuration.ConfigurationManager.AppSettings["IpHasar"].ToString();

        HasarArgentina.ImpresoraFiscalRG3561 ocxHasar;


        public FrmHasar()
        {
            InitializeComponent();
        }
        private bool openPort = false;


        private void inicializarHasar()
        {
            try
            {
                ocxHasar = new HasarArgentina.ImpresoraFiscalRG3561();
                ocxHasar.Conectar(IpHasar, IpPuertoHasar);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,"Error conectando impresora --> " + ex.Message);
            }
        }
        

        private void FrmHasar_Load(object sender, EventArgs e)
        {
            lblLeyenda.Text = "";
            inicializarHasar();
        }

        private void btnCierreX_Click(object sender, EventArgs e)
        {

        }

        private void btnCierreZ_Click(object sender, EventArgs e)
        {
            ctc3DES.TripleDESUtil ctc = new TripleDESUtil();
            groupBox2.Visible = true;
            Delay(1);
            try
            {
                VentaBUS bus = new VentaBUS();
                bus.BackupBD();
            }
            catch (Exception exB)
            {
                Logger.Log.LogInFile("Error Generando Backup --> " + exB.Message, "log");
            }

            string pathB = System.Configuration.ConfigurationManager.AppSettings["pathBackup"].ToString();
            string PathBackup = pathB + DateTime.Now.ToString("dd-MM-yyyy") + ".bak";

            try
            {
                ZipSystem.CompressFile(PathBackup, PathBackup.Replace(".bak", ".zip"));
            }
            catch (Exception exZ)
            {
                Logger.Log.LogInFile("Error Zipiando Backup --> " + exZ.Message, "log");
            }

            try
            {
                System.IO.File.Delete(PathBackup);
            }
            catch (Exception exDir)
            {
                try { Logger.Log.LogInFile("<<<<<<<<ERROR ELIMINANDO ARCHIVOS DE BD>>>>>>> " + PathBackup + " - ERROR --> " + exDir.Message, "backupAutomatic.log"); }
                catch { }
            }

            try
            {
                try { Logger.Log.LogInFile("*************COMIENZA Cierre  Z**********" , "IF.log"); }
                catch { }

                string texto = "CIERRE Z\n";
                RespuestaCerrarJornadaFiscal res = new RespuestaCerrarJornadaFiscal();
                CerrarJornadaFiscalZ zeta = new CerrarJornadaFiscalZ();
                res = ocxHasar.CerrarJornadaFiscal(TipoReporte.ReporteZ);
                zeta = res.Z;

                texto += "Cierre Z Nº =[" + zeta.Numero + "]\n";
                texto += "Fecha del Cierre        =[" + zeta.Fecha + "]\n";
                texto += "DF Emitidos             =[" + zeta.DF_CantidadEmitidos + "]\n";
                texto += "DF Cancelados           =[" + zeta.DF_CantidadCancelados + "]\n";
                texto += "DF Total                =[" + zeta.DF_Total + "]\n";
                texto += "DF Total Gravado        =[" + zeta.DF_TotalGravado + "]\n";
                texto += "DF Total No Gravado     =[" + zeta.DF_TotalNoGravado + "]\n";
                texto += "DF Total Exento         =[" + zeta.DF_TotalExento + "]\n";
                texto += "DF Total IVA            =[" + zeta.DF_TotalIVA + "]\n";
                texto += "DF Total Otros Tributos =[" + zeta.DF_TotalTributos + "]\n";
                texto += "NC Emitidas             =[" + zeta.NC_CantidadEmitidos + "]\n";
                texto += "NC Canceladas           =[" + zeta.NC_CantidadCancelados + "]\n";
                texto += "NC Total                =[" + zeta.NC_Total + "]\n";
                texto += "NC Total Gravado        =[" + zeta.NC_TotalGravado + "]\n";
                texto += "NC Total No Gravado     =[" + zeta.NC_TotalNoGravado + "]\n";
                texto += "NC Total Exento         =[" + zeta.NC_TotalExento + "]\n";
                texto += "NC Total IVA            =[" + zeta.NC_TotalIVA + "]\n";
                texto += "NC Total Otros Tributos =[" + zeta.NC_TotalTributos + "]\n";
                texto += "DNFH Emitidos           =[" + zeta.DNFH_CantidadEmitidos + "]\n";
                texto += "DNFH Total              =[" + zeta.DNFH_Total + "]\n";

                //MessageBox.Show(texto);

                try { Logger.Log.LogInFile(texto, "IF.log"); }
                catch { }

            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("error emitiendo cierre Z -->: " + ex.Message, "IF.log"); }
                catch { }
                MessageBox.Show(ex.Message, "error emitiendo cierre Z");
            }

            //SUBE LOS ARCHIVOS AL FTP
            try
            {
                string DatabaseName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"].ToString();
                string strUser = System.Configuration.ConfigurationManager.AppSettings["userFTP"].ToString();
                string strPassword = System.Configuration.ConfigurationManager.AppSettings["passFTP"].ToString();
                string strPathFTP = System.Configuration.ConfigurationManager.AppSettings["pathFTP"].ToString();
                string fileName = DatabaseName + DateTime.Now.ToString("dd-MM-yyyy") + ".zip";

                try { strUser = ctc.DesEncriptar(strUser); }
                catch { strUser = System.Configuration.ConfigurationManager.AppSettings["userFTP"].ToString(); }
                try { strPassword = ctc.DesEncriptar(strPassword); }
                catch { strPassword = System.Configuration.ConfigurationManager.AppSettings["passFTP"].ToString(); }
                try { strPathFTP = ctc.DesEncriptar(strPathFTP); }
                catch { strPathFTP = System.Configuration.ConfigurationManager.AppSettings["pathFTP"].ToString(); }

                FTP.SystemFTP ftp = new SystemFTP();
                ftp.Upload(strUser, strPassword, PathBackup.Replace(".bak", ".zip"), strPathFTP + "/" + fileName);
            }
            catch (Exception exFTP)
            {
                try { Logger.Log.LogInFile("<<<<<<<<ERROR SUBIENDO ARCHIVOS AL FTP>>>>>>> " + PathBackup + " - ERROR --> " + exFTP.Message, "backupAutomatic.log"); }
                catch { }
            }

            #region FILES AFIP
            bool generaArchivosAFIP = false;

            try
            {
                generaArchivosAFIP = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["generateFileAFIP"]);
            }
            catch { }

            if (generaArchivosAFIP)
            {
                GetaudarSystem getaudarSys = new GetaudarSystem();

                string[] res = getaudarSys.ProcessFiles().Split('|');

                if (res[0] == "1")
                {
                    FrmProcessFilesAFIP frm = new FrmProcessFilesAFIP();
                    frm.param1 = res[1];
                    frm.param2 = res[2];
                    frm.ShowDialog();
                }
            }
            #endregion
            groupBox2.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delay(double second)
        {
            Application.DoEvents();
            Thread.Sleep((int)TimeSpan.FromSeconds(second).TotalMilliseconds);
            Application.DoEvents();

        }

    }
}
