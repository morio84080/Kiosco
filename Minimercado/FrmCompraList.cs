using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Compras.Business;
 

namespace Minimercado
{
    public partial class FrmCompraList : Form
    {
        CompraSystem Bus = new CompraSystem();

        public FrmCompraList()
        {
            InitializeComponent();
            
        }

        private void FrmCompraList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");
            dtpFechaIni.Value = System.DateTime.Now;
            dtpFechaIni.Value = System.DateTime.Now;
        }


        private void FrmCompraList_Activated(object sender, EventArgs e)
        {
            ListCompras();
        }

        private void ListCompras()
        {
            DateTime fechaIni = new DateTime(dtpFechaIni.Value.Year, dtpFechaIni.Value.Month, dtpFechaIni.Value.Day, 0, 0, 0);
            DateTime fechaFin = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);

            dtGView.DataSource = Bus.getAllPorFecha_DT(fechaIni, fechaFin);

            dtGView.Columns[0].HeaderText = "Proveedor";
            dtGView.Columns[1].Visible = false; //IDCOMPRA
            dtGView.Columns[2].HeaderText = "Fecha";
            dtGView.Columns[3].Visible = false; //ID PROVEEDOR
            dtGView.Columns[4].HeaderText = "Subtotal";
            dtGView.Columns[5].HeaderText = "Total IVA";
            dtGView.Columns[6].HeaderText = "Total";
            dtGView.Columns[7].HeaderText = "Observaciones";
            dtGView.Columns[8].Visible = false; //DELETED

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[1].Value.ToString());
                FrmCompra frm = new FrmCompra();
                GlobalClass.ActionType = 2;
                frm.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmCompra frmRu = new FrmCompra();
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
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[1].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Bus.EiminarCompra(reg);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListCompras();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Compra");
                this.Hide();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ListCompras();
        }


        
    }
}
