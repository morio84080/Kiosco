using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minimercado
{
    public partial class RptVentaPage : Form
    {
        public RptVentaPage()
        {
            InitializeComponent();
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

            try
            {
                GlobalClass.Text = fechaIni.ToString() + "|" + fechaFin.ToString();
                //printDocument1.Print();    

                RptVenta rtp = new RptVenta();
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
    }
}
