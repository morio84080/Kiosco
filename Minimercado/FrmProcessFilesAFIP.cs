using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AFIP.Business;

namespace Minimercado
{
    public partial class FrmProcessFilesAFIP : Form
    {
        public string param1;
        public string param2;
        public FrmProcessFilesAFIP()
        {
            InitializeComponent();
        }

        private void FrmProcessFilesAFIP_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            Delay(0.5);
            try {
                GetaudarSystem getaudarSys = new GetaudarSystem();
                getaudarSys.CreateFiles(param1, param2);
                MessageBox.Show("Archivos Generados y enviados con éxito ", "Proceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando Archivos --> " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Delay(double second)
        {
            Application.DoEvents();
            Thread.Sleep((int)TimeSpan.FromSeconds(second).TotalMilliseconds);
            Application.DoEvents();

        }
    }
}
