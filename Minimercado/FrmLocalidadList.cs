using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localidad.Entities;
using Localidad.Business;
 

namespace Minimercado
{
    public partial class FrmLocalidadList : Form
    {
        LocalidadBUS Bus = new LocalidadBUS();

        public FrmLocalidadList()
        {
            InitializeComponent();
            
        }

        private void FrmLocalidadList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");
        }


        private void FrmLocalidadList_Activated(object sender, EventArgs e)
        {
            ListLocalidads();            
        }

        private void ListLocalidads()
        {
            dtGView.DataSource = Bus.getAllLocalidades_DT();
            dtGView.Columns[2].Visible = false;

            dtGView.Columns[0].HeaderText = "Codigo";
            dtGView.Columns[1].HeaderText = "Nombre";
            dtGView.Columns[1].Width = 285;
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

                    GlobalClass.locaGlobal = new LocalidadEntity();

                    GlobalClass.locaGlobal.CodiLoca = Convert.ToInt32(currentRow.Cells[0].Value);
                    GlobalClass.locaGlobal.NombLoca = currentRow.Cells[1].Value.ToString();
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

                        GlobalClass.locaGlobal = new LocalidadEntity();

                        GlobalClass.locaGlobal.CodiLoca = Convert.ToInt32(currentRow.Cells[0].Value);
                        GlobalClass.locaGlobal.NombLoca = currentRow.Cells[1].Value.ToString();
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
                FrmLocalidad frmRu = new FrmLocalidad();
                GlobalClass.ActionType = 2;
                frmRu.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmLocalidad frmRu = new FrmLocalidad();
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
                LocalidadEntity Ety = new LocalidadEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Ety = Bus.getLocalidadID(reg);
                        Ety.ActivoLoca = false;
                        Bus.LocalidadUpdate(Ety);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListLocalidads();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Localidad");
                this.Hide();
            }
        }


        
    }
}
