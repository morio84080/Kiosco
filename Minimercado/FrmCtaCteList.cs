using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuentaCorriente.Entities;
using CuentaCorriente.Business;
using Localidad.Business;
using Cliente.Business;
using Vendedor.Business;
using System.Drawing.Printing;
 

namespace Minimercado
{
    public partial class FrmCtaCteList : Form
    {
        CtaCteBUS BUS = new CtaCteBUS();
        private int perfilID = 0;
        private string strSaldo = string.Empty;

        public FrmCtaCteList()
        {
            InitializeComponent();
            
        }

        private void FrmCtaCteList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            perfilID = new VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;

            LlenarCboProveedor();

        }

        private void LlenarCboProveedor()
        {
            Cliente.Business.ClienteBUS clieBus = new Cliente.Business.ClienteBUS();
            if (clieBus.LlenarComboCliente(this.cboProviders) == -1)
                this.Hide();


            //if (GlobalClass.ActionType != 1)
            this.cboProviders.SelectedValue = -1;
        }

        private void FrmCtaCteList_Activated(object sender, EventArgs e)
        {

            dtpFechaIni.Focus();

        }

        private void ListCtaCte()
        {

            try
            {
                if (cboProviders.SelectedIndex==0)
                {
                    MessageBox.Show("Debe selecciona un proveedor", "ERROR");
                    cboProviders.Focus();
                }
                else
                {
                    DateTime fechaIni = new DateTime(dtpFechaIni.Value.Year, dtpFechaIni.Value.Month, dtpFechaIni.Value.Day, 0, 0, 0);
                    DateTime fechaFin = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);
                    dtGView.DataSource = BUS.getAllCtaCtePorClie_DT(Convert.ToInt32(cboProviders.SelectedValue), fechaIni, fechaFin);

                    dtGView.Columns[0].HeaderText = "Fecha";
                    dtGView.Columns[1].HeaderText = "Detalle";
                    dtGView.Columns[1].Width = 300;
                    dtGView.Columns[2].Visible = false; //ESTADO
                    dtGView.Columns[3].HeaderText = "Debe";
                    dtGView.Columns[3].DefaultCellStyle.Format = "#,#.##";
                    dtGView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtGView.Columns[4].HeaderText = "Haber";
                    dtGView.Columns[4].DefaultCellStyle.Format = "#,#.##";
                    dtGView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtGView.Columns[5].HeaderText = "Saldo";
                    dtGView.Columns[5].DefaultCellStyle.Format = "#,#.##";
                    dtGView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    foreach (DataGridViewRow dgvr in dtGView.Rows)
                    {
                        if (dgvr.Cells[2].Value.ToString()=="0")                    
                            dgvr.DefaultCellStyle.BackColor = Color.PeachPuff;                    
                        else
                            dgvr.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    dtGView.Refresh();

                    SaldosEntity saldos = new SaldosEntity();
                    saldos = BUS.getSaldosBase(Convert.ToInt32(cboProviders.SelectedValue), fechaFin);
                    lblSaldo.Text = "Saldo: " + saldos.Saldo.ToString("$#,#.##");
                    strSaldo = saldos.Saldo.ToString("$#,#.##");
                }
                
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "La consulta no arrojo ningún resultado --> " + ex.Message;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.ListCtaCte();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalClass.Text = cboProviders.SelectedItem.ToString() + "|" +strSaldo + "|" + dtpFechaIni.Value.ToString("dd/MM/yyyy") + "|" + dtpFechaFin.Value.ToString("dd/MM/yyyy");
                //printDocument1.Print();    

                MessageBox.Show("En construcción..");
                //RptCtaCte rtp = new RptCtaCte();
                //rtp.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message,"Error Generando reporte");
            }
        }

        //private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
        //    this.InvokePaint(dtGView, myPaintArgs);
        //}
      
        
    }
}
