using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caja.Business;

namespace Minimercado
{
    public partial class FrmCierreCajaList : Form
    {
        CajaBUS Bus = new CajaBUS();
        public FrmCierreCajaList()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[0].Value.ToString());

                try
                {

                    FrmMovCajaList rtp = new FrmMovCajaList();
                    rtp.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Generando reporte");
                }


            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ListarCierres();
        }

        private void ListarCierres()
        {
            DateTime fechaIni = new DateTime(dtpFechaIni.Value.Year, dtpFechaIni.Value.Month, dtpFechaIni.Value.Day, 0, 0, 0);
            DateTime fechaFin = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

            dtGView.DataSource = Bus.CierreCajaGetFecha_DT(fechaIni, fechaFin);
            dtGView.Columns[0].Visible = false; //NUME NotaCompra
            dtGView.Columns[1].HeaderText = "FECHA";
            dtGView.Columns[2].HeaderText = "Efectivo $";
            dtGView.Columns[2].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[3].HeaderText = "Cuenta DNI $";
            dtGView.Columns[3].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[4].HeaderText = "T. Débito/Crédito $";
            dtGView.Columns[4].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtGView.Columns[5].HeaderText = "M. Pago $";
            dtGView.Columns[5].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dtGView.Columns[6].HeaderText = "Cta. Cte. $";
            dtGView.Columns[6].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[7].HeaderText = "Saldo Prox. Cierre $";
            dtGView.Columns[7].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[8].HeaderText = "Ventas $";
            dtGView.Columns[8].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[9].HeaderText = "Notas de Crédito $";
            dtGView.Columns[9].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[10].HeaderText = "Ingresos $";
            dtGView.Columns[10].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[11].HeaderText = "Egresos $";
            dtGView.Columns[11].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtGView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtGView.Refresh();
        }

        private void FrmCierreCajaList_Load(object sender, EventArgs e)
        {
           
        }

        void FrmCierreCajaList_Activated(object sender, EventArgs e)
        {
            ListarCierres();
        }
    }
}
