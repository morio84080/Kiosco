using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lista.Entities;
using Lista.Business;
 

namespace Minimercado
{
    public partial class FrmListaList : Form
    {
        ListaBUS Bus = new ListaBUS();

        public FrmListaList()
        {
            InitializeComponent();
            
        }

        private void FrmListaList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");
        }


        private void FrmListaList_Activated(object sender, EventArgs e)
        {
            ListListas();
        }

        private void ListListas()
        {
            dtGView.DataSource = Bus.getAllListas_DT();
            dtGView.Columns[4].Visible = false;

            dtGView.Columns[0].HeaderText = "Codigo";
            dtGView.Columns[1].HeaderText = "Nombre";
            dtGView.Columns[1].Width = 285;
            dtGView.Columns[1].HeaderText = "Nombre";
            dtGView.Columns[2].HeaderText = "Porcentaje (%)";
            dtGView.Columns[3].HeaderText = "Ganancia (%)";
            //dtGView.Rows[0].Visible = false;

            //dtGView.Refresh();

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[0].Value);
                FrmLista frm = new FrmLista();
                GlobalClass.ActionType = 2;
                frm.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmLista frm = new FrmLista();
            frm.ShowDialog();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            Deleted();
        }


        private void Deleted()
        {
            try
            {
                ListaEntity Ety = new ListaEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Ety = Bus.getListaID(reg);
                        Ety.ActivoList = false;
                        Bus.ListaUpdate(Ety);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListListas();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Lista");
                this.Hide();
            }
        }


        
    }
}
