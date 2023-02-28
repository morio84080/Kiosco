using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Minimercado
{
    public partial class RptVenta : Form
    {
        public RptVenta()
        {
            InitializeComponent();
        }

        private void RptVenta_Load(object sender, EventArgs e)
        {

            try
            {
                string[] param;
                string[] columns; 

                param = GlobalClass.Text.Split('|');
                // Creo una colección de parámetros de tipo ReportParameter 
                // para añadirlos al control ReportViewer.

                List<ReportParameter> pa = new List<ReportParameter>();
                // Añado los parámetros necesarios.
                pa.Add(new ReportParameter("fechaIni", (param[0] == "" ? null : param[0])));
                pa.Add(new ReportParameter("fechaFin", (param[1] == "" ? null : param[1])));

                rptViewer.ShowCredentialPrompts = false;

                string UserRS = GlobalClass.UserRS;// System.Configuration.ConfigurationManager.AppSettings["UserRS"].ToString();
                string PasswordRS = GlobalClass.PasswordRS;// System.Configuration.ConfigurationManager.AppSettings["PasswordRS"].ToString();

                //rptViewer.ServerReport.ReportServerCredentials = new ReportCredentials(UserRS, PasswordRS, "");
                this.rptViewer.ServerReport.ReportServerCredentials.NetworkCredentials = new System.Net.NetworkCredential(UserRS, PasswordRS, "");
                rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
                //rptViewer.ServerReport.ReportServerUrl = new System.Uri(System.Configuration.ConfigurationManager.AppSettings["RS_url"].ToString());
                rptViewer.ServerReport.ReportServerUrl = new System.Uri(GlobalClass.RS_url);
                rptViewer.ServerReport.ReportPath = System.Configuration.ConfigurationSettings.AppSettings["RS_path"].ToString() + "/VentasPorFecha";

                rptViewer.ServerReport.SetParameters(pa);
                rptViewer.ServerReport.Refresh();

                this.rptViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Ejecutando Informe");
            }
        }

        #region
        public class ReportCredentials : Microsoft.Reporting.WinForms.IReportServerCredentials
        {
            string _userName, _password, _domain;

            public ReportCredentials(string userName, string password, string domain)
            {
                _userName = userName;
                _password = password;
                _domain = domain;
            }

            public System.Security.Principal.WindowsIdentity ImpersonationUser
            {
                get
                {
                    return null;
                }
            }



            public System.Net.ICredentials NetworkCredentials
            {
                get
                {
                    return new System.Net.NetworkCredential(_userName, _password, _domain);
                }
            }

            public bool GetFormsCredentials(out System.Net.Cookie authCoki, out string userName, out string password, out string authority)
            {
                userName = _userName;
                password = _password;
                authority = _domain;
                authCoki = new System.Net.Cookie(".ASPXAUTH", ".ASPXAUTH", "/", "Domain");
                return true;
            }
        }
        #endregion
    }
}
