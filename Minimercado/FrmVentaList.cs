using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ventas.Entities;
using Ventas.Business;
using Vendedor.Entities;
using Vendedor.Business;
 

namespace Minimercado
{
    public partial class FrmVentaList : Form
    {
        VentaBUS Bus = new VentaBUS();
        VendedorEntity vendedor = new VendedorEntity();


        public FrmVentaList()
        {
            InitializeComponent();
            
        }

        private void FrmVentaList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del Ventado");
            vendedor = new VendedorBusiness().getVendedorID(GlobalClass.UserID);
            dtpFechaIni.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            dtpFechaFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23, 59, 59);
            btnNuevo.Focus();
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


        private void FrmVentaList_Activated(object sender, EventArgs e)
        {
            ListVentas();
            btnNuevo.Focus();
        }

        private void ListVentas()
        {

            dtGView.DataSource = Bus.VentasGetFechaAndVend_DT(dtpFechaIni.Value,dtpFechaFin.Value);

            dtGView.Columns[0].HeaderText = "Nº Remito";
            dtGView.Columns[1].HeaderText = "Fecha";
            dtGView.Columns[2].HeaderText = "Letra";
            dtGView.Columns[3].HeaderText = "Total $";
            dtGView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtGView.Columns[4].HeaderText = "Tipo Vta";
            dtGView.Columns[4].Visible = false;
            dtGView.Columns[5].Visible = false; //TIPO PAGO
            dtGView.Columns[6].HeaderText = "Condición";
            dtGView.Columns[7].HeaderText = "Nº Factura";
            dtGView.Columns[8].Visible = false;

            //dtGView.Refresh();

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.LongPrimaryKey=long.Parse(currentRow.Cells[0].Value.ToString());
                FrmVenta frm = new FrmVenta();
                GlobalClass.ActionType = 2;
                frm.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmVenta frm = new FrmVenta();
            frm.ShowDialog();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.LongPrimaryKey = long.Parse(currentRow.Cells[0].Value.ToString());
                if (Convert.ToBoolean(currentRow.Cells[8].Value))
                    MessageBox.Show("La venta ya tiene generada una Nota de Credito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    FrmVenta frm = new FrmVenta();
                    GlobalClass.ActionType = 3;
                    frm.ShowDialog();
                }
            }
        }


        private void Deleted()
        {
            try
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Bus.EiminarVenta(reg);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListVentas();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Venta");
                this.Hide();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ListVentas();
        }

        private void dtGView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int count = 0; count < dtGView.Rows.Count; count++)
                {
                    if (Convert.ToBoolean(dtGView.Rows[count].Cells[8].Value))
                    {
                        dtGView.Rows[count].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        dtGView.Rows[count].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                        dtGView.Rows[count].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
