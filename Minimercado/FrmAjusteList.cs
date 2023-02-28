using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Stock.Entities;
using Stock.Business;
 

namespace Minimercado
{
    public partial class FrmAjusteList : Form
    {
        StockBUS Bus = new StockBUS();

        public FrmAjusteList()
        {
            InitializeComponent();
            
        }

        private void FrmAjusteList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");
        }


        private void FrmAjusteList_Activated(object sender, EventArgs e)
        {
            ListAjustes();
        }

        private void ListAjustes()
        {
            dtGView.DataSource = Bus.getAllStockPorTipoMov_DT(4);

            dtGView.Columns[0].Visible= false; //IDSTK
            dtGView.Columns[1].Visible = false; //TIPOINGRESOSTK
            dtGView.Columns[2].Visible = false; //TIPOMOVSTK
            dtGView.Columns[3].Visible = false; //ARTICULOSTK
            dtGView.Columns[9].Visible = false; //ELIMINADOSTK
            dtGView.Columns[5].HeaderText = "Tipo de Ajuste";
            dtGView.Columns[5].Width = 100;
            dtGView.Columns[4].HeaderText = "Fecha";
            dtGView.Columns[6].HeaderText = "Artículo";
            dtGView.Columns[6].Width = 250;
            dtGView.Columns[7].HeaderText = "Cantidad";
            dtGView.Columns[7].Width = 60;
            dtGView.Columns[8].HeaderText = "Detalle";
            dtGView.Columns[8].Width = 260;

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmAjuste frmRu = new FrmAjuste();
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
                StockEntity Ety = new StockEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Ety = Bus.getStockID(reg);
                        Ety.EliminadoSTK = true;
                        Bus.StockEliminar(Ety, GlobalClass.UserID);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListAjustes();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Ajuste");
                this.Hide();
            }
        }


        
    }
}
