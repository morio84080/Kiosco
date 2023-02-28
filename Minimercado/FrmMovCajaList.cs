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
using Caja.Entities;

namespace Minimercado
{
    public partial class FrmMovCajaList : Form
    {
        CajaBUS Bus = new CajaBUS();
        int perfilId = 0;
        public FrmMovCajaList()
        {
            InitializeComponent();
        }

        private void FrmMovCajaList_Load(object sender, EventArgs e)
        {
            perfilId = new Vendedor.Business.VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;
            if (perfilId > 0)
            {
                lblTotal.Visible = false;
                txtTotal.Visible = false;
            }

            if (GlobalClass.IntPrimaryKey > 0) {
                btnCierre.Enabled = false;
                btnEgreso.Enabled = false;
                btnIngreso.Enabled = false;
            }
            cboCondicion.SelectedIndex = 0;
        }

        private void FrmMovCajaList_Activated(object sender, EventArgs e)
        {
            BuscarMovimientos();
        }

        private void BuscarMovimientos() {
            DateTime now = new DateTime();
            now = DateTime.Now;
            DateTime fechaIni = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            DateTime fechaFin = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            if (GlobalClass.IntPrimaryKey == 0)
            {
                try
                {
                    fechaIni = Bus.getLastCierreCaja().FechaCica;
                }
                catch { 
                    //fechaIni = fechaIni.AddMonths(-2);
                }
            }
            else
            {
                try
                {
                    CierreCajaEntity cierreCaja = new CierreCajaEntity();
                    cierreCaja = Bus.getCierreCajaByID(GlobalClass.IntPrimaryKey);
                    fechaFin = cierreCaja.FechaCica;
                    

                    try
                    {
                        if (GlobalClass.IntPrimaryKey - 1 ==0)
                            fechaIni = fechaIni.AddMonths(-2);
                        else
                        {
                            cierreCaja = new CierreCajaEntity();
                            cierreCaja = Bus.getCierreCajaByID(GlobalClass.IntPrimaryKey - 1);
                            fechaIni = cierreCaja.FechaCica;
                        }

                    }
                    catch { fechaIni = new DateTime(fechaFin.Year,fechaFin.Month,fechaFin.Day,0,0,0); }
                }
                catch { fechaIni = fechaIni.AddMonths(-2); }
            }

            dtGView.DataSource = Bus.MovimientosCajaXcierre_DT(fechaIni, fechaFin, 0, cboCondicion.SelectedIndex);
            dtGView.Columns[0].HeaderText = "FECHA";
            dtGView.Columns[0].Width = 120;
            dtGView.Columns[1].HeaderText = "DETALLE";
            dtGView.Columns[1].Width = 420;
            dtGView.Columns[2].HeaderText = "TIPO OPERACIÓN";
            dtGView.Columns[2].Width = 130;
            dtGView.Columns[3].HeaderText = "CONDICIÓN";
            dtGView.Columns[3].Width = 130;
            dtGView.Columns[4].HeaderText = "TOTAL $";
            dtGView.Columns[4].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[4].Width = 100;


            //dtGView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtTotal.Text = string.Empty;
            try
            {
                decimal total = dtGView.Rows.Cast<DataGridViewRow>()
                        .Sum(t => Convert.ToDecimal(t.Cells[4].Value));
                txtTotal.Text = total.ToString();
            }
            catch { }

        }

        private void cboCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarMovimientos();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            GlobalClass.tipoCaja = false;
            FrmCajaList frm = new FrmCajaList();
            frm.ShowDialog();
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            GlobalClass.tipoCaja = true;
            FrmCajaList frm = new FrmCajaList();
            frm.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            GlobalClass.IntPrimaryKey = 0;
            FrmCierre frm = new FrmCierre();
            frm.ShowDialog();
        }
    }
}
