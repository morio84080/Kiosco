using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rubros.Entities;
using Rubros.Business;
 

namespace Minimercado
{
    public partial class FrmRubroList : Form
    {
        RubroBusiness rBus = new RubroBusiness();

        public FrmRubroList()
        {
            InitializeComponent();
            
        }

        private void FrmRubroList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");
            btnNuevo.Focus();
        }


        private void FrmRubroList_Activated(object sender, EventArgs e)
        {
            ListRubros();
        }

        private void ListRubros()
        {
            dtGView.DataSource = rBus.getAllRubros_DT();
            dtGView.Columns[3].Visible = false;

            dtGView.Columns[0].HeaderText = "Codigo";
            dtGView.Columns[1].HeaderText = "Descripción";
            dtGView.Columns[1].Width = 185;
            dtGView.Columns[2].HeaderText = "% Ganancia";
            dtGView.Columns[2].Width = 100;
            dtGView.Columns[4].HeaderText = "% Dto.";
            dtGView.Columns[4].Width = 100;
            dtGView.Focus();
            //dtGView.Rows[0].Visible = false;

            //dtGView.Refresh();

        }

        void dtGView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {

                    DataGridViewRow currentRow = dtGView.SelectedRows[0];

                    GlobalClass.rubroGlobal = new RubroEntity();

                    GlobalClass.rubroGlobal.CodiRub = Convert.ToInt32(currentRow.Cells[0].Value);
                    GlobalClass.rubroGlobal.DescRubr = currentRow.Cells[1].Value.ToString();
                }
            }
            catch { }
            this.Close();
        }
        void dtGView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //int row = dtGView.CurrentCell.RowIndex;
                //dtGView.CurrentCell = dtGView.Rows[row].Cells[6];

                try
                {
                    if (dtGView.SelectedRows.Count > 0)
                    {


                        DataGridViewRow currentRow = dtGView.SelectedRows[0];

                        GlobalClass.rubroGlobal = new RubroEntity();

                        GlobalClass.rubroGlobal.CodiRub = Convert.ToInt32(currentRow.Cells[0].Value);
                        GlobalClass.rubroGlobal.DescRubr = currentRow.Cells[1].Value.ToString();
                    }
                }
                catch { }
                this.Close();

            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[0].Value);
                FrmRubro frmRu = new FrmRubro();
                GlobalClass.ActionType = 2;
                frmRu.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmRubro frmRu = new FrmRubro();
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
                RubroEntity ruEty = new RubroEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        ruEty = rBus.getRubroID(reg);
                        ruEty.ActivoRubr = false;
                        rBus.RubroUpdate(ruEty,ruEty,GlobalClass.UserID,false);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListRubros();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Rubro");
                this.Hide();
            }
        }


        
    }
}
