using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AFIP.Business;

namespace Minimercado
{
    public partial class FrmFileAFIP : Form
    {
        public FrmFileAFIP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AFIP.Business.GetaudarSystem getaudarSys = new GetaudarSystem();
            //string res = getaudarSys.GenerateFiles();
            //MessageBox.Show(res);
            getaudarSys.EnviarMail("210608", "210614");
        }
    }
}
