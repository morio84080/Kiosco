using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuentaCorriente.Entities;
using CuentaCorriente.Business;
using Vendedor.Business;
using Localidad.Business;
using Cliente.Business;
 

namespace Minimercado
{
    public partial class FrmPagoClieList : Form
    {
        PagoClieBUS rBus = new PagoClieBUS();
        private int perfilID = 0;

        public FrmPagoClieList()
        {
            InitializeComponent();
            
        }

        private void FrmPagoClieList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");

            perfilID = new VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;

            if (perfilID > 0)
            {
                cmdEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                cmdEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }

        }


        private void FrmPagoClieList_Activated(object sender, EventArgs e)
        {

            dtpFechaIni.Focus();
            ListPagoClie();
           
        }

        private void ListPagoClie()
        {
            try
            {

                    DateTime fechaIni = new DateTime(dtpFechaIni.Value.Year, dtpFechaIni.Value.Month, dtpFechaIni.Value.Day, 0, 0, 0);
                    DateTime fechaFin = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

                    dtGView.DataSource = rBus.getAllPorFiltros_DT(fechaIni, fechaFin);
                

                dtGView.Columns[0].HeaderText = "Nro. Pago";
                dtGView.Columns[0].Width = 100;
                dtGView.Columns[1].HeaderText = "Fecha";
                dtGView.Columns[1].Width = 100;
                dtGView.Columns[2].Visible = false; //ID PROVEEDOR
                dtGView.Columns[3].HeaderText = "Detalle";
                dtGView.Columns[3].Width = 400;
                dtGView.Columns[4].HeaderText = "Importe $";
                dtGView.Columns[4].DefaultCellStyle.Format = "#,#.##";
                dtGView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGView.Columns[4].Width = 100;
                dtGView.Columns[5].Visible = false; //ELIMINADO
                dtGView.Columns[6].HeaderText = "Cliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[0].Value);
                FrmPagoClie frmRu = new FrmPagoClie();
                GlobalClass.ActionType = 2;
                frmRu.ShowDialog();
                ListPagoClie();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmPagoClie frmRu = new FrmPagoClie();
            frmRu.ShowDialog();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            Deleted();
        }


        private void Deleted()
        {
            try
            {
                PagoClieEntity Ety = new PagoClieEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Ety = rBus.getByID(reg);
                        Ety.EliminadoPACL = true;
                        rBus.Update(Ety,Ety,GlobalClass.UserID);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListPagoClie();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Pago Proveedor");
                this.Hide();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ListPagoClie();
        }

        private void pboxLocalidad_Click(object sender, EventArgs e)
        {
            FrmLocalidadList frm = new FrmLocalidadList();
            frm.ShowDialog();
        }

        
    }
}
