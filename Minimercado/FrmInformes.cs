using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minimercado
{
    public partial class FrmInformes : Form
    {
        public FrmInformes()
        {
            InitializeComponent();
        }

        private void FrmInformes_Load(object sender, EventArgs e)
        {
            listBoxInformes.SelectedIndex = 0;
        }
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (listBoxInformes.SelectedIndex)
            {

                case 0:
                    RptArticuloPage rtpArticulo = new RptArticuloPage();
                    rtpArticulo.ShowDialog();
                    break;
                case 1:
                    RptVentaPage rtpVta = new RptVentaPage();
                    rtpVta.ShowDialog();
                    break;
                case 2:
                    RptResumenVentaPage rtpResumenVta = new RptResumenVentaPage();
                    rtpResumenVta.ShowDialog();
                    break;
                case 3:
                    RptResumenVentaPorRubroPage rtpResumenVtaRubro = new RptResumenVentaPorRubroPage();
                    rtpResumenVtaRubro.ShowDialog();
                    break;
                case 4:
                    RptDocElectronicoPage rtpArticulDocFiscales = new RptDocElectronicoPage();
                    rtpArticulDocFiscales.ShowDialog();
                    break;
                case 5:
                    RptStockMinimo rtpStockMin = new RptStockMinimo();
                    rtpStockMin.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Opción Incorrecta");
                    break;
            }


        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
