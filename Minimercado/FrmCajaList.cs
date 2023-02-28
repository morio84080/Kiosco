using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Caja.Entities;
using Caja.Business;
using Vendedor.Entities;
using Vendedor.Business;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Linq;
 

namespace Minimercado
{
    public partial class FrmCajaList : Form
    {
        CajaBUS Bus = new CajaBUS();
        VendedorEntity vendedor = new VendedorEntity();

        public FrmCajaList()
        {
            InitializeComponent();
            
        }

        private void FrmCajaList_Load(object sender, EventArgs e)
        {            
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del Listado");
            vendedor = new VendedorBusiness().getVendedorID(GlobalClass.UserID);

            int perfilId = new VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;
            if (perfilId != 0) cmdEliminar.Enabled = false;

            dtpFechaIni.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            dtpFechaFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23, 59, 59);
            //if (vendedor.PerfilVend > 0)
            //{
            //    cmdEliminar.Enabled = false;
            //    btnModificar.Enabled = false;
            //}
            //else
            //{
            //    cmdEliminar.Enabled = true;
            //    btnModificar.Enabled = true;

            //}

        }


        private void FrmCajaList_Activated(object sender, EventArgs e)
        {
            ListCajas();
        }

        private void ListCajas()
        {
            DateTime fechaIni = new DateTime(dtpFechaIni.Value.Year, dtpFechaIni.Value.Month, dtpFechaIni.Value.Day, 0, 0, 0);
            DateTime fechaFin = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

            dtGView.DataSource = Bus.CajaGetFecha_DT(fechaIni,fechaFin,GlobalClass.tipoCaja);
            dtGView.Columns[0].Visible = false; //ID Caja
            dtGView.Columns[1].HeaderText = "FECHA";
            dtGView.Columns[1].Width = 100;
            dtGView.Columns[2].HeaderText = "Nº FACTURA";
            dtGView.Columns[2].Width = 100;
            dtGView.Columns[3].Visible = false; //TIPO CAJA (INGRESO/EGRESO)
            dtGView.Columns[4].Visible = false; //ID ORIGEN DESTINO CAJA
            dtGView.Columns[5].HeaderText = (!GlobalClass.tipoCaja ?"ORIGEN":"DESTINO");
            dtGView.Columns[5].Width = 150;
            dtGView.Columns[6].HeaderText = "DETALLE";
            dtGView.Columns[6].Width = 260;
            dtGView.Columns[7].HeaderText = "SUBTOTAL $";
            dtGView.Columns[7].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[7].Width = 100;
            dtGView.Columns[8].HeaderText = "% IVA";
            dtGView.Columns[8].Width = 80;
            dtGView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[9].HeaderText = "IVA";
            dtGView.Columns[9].Width = 80;
            dtGView.Columns[9].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[10].HeaderText = "TOTAL $";
            dtGView.Columns[10].Width = 100;
            dtGView.Columns[10].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGView.Columns[11].HeaderText = "TIPO CTA";
            dtGView.Columns[11].Width = 60;

            dtGView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtGView.Refresh();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {

                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.DecimalNumber = Convert.ToDecimal(currentRow.Cells[0].Value.ToString());
                GlobalClass.ActionType = 2;
                FrmCaja frm = new FrmCaja();
                frm.ShowDialog();

            }
        }

 
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            GlobalClass.ActionType = 1;
            FrmCaja frm = new FrmCaja();
            frm.ShowDialog();

        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
                if (dtGView.SelectedRows.Count > 0)
                {
                    Deleted();
                }

        }


        private void Deleted()
        {
            try
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                decimal reg = Convert.ToDecimal(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Bus.EliminarCaja(reg,GlobalClass.UserID);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListCajas();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Caja");
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ListCajas();
        }

        
    }
}
