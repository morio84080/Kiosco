using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Marcas.Entities;
using Marcas.Business;
using Vendedor.Business; 

namespace Minimercado
{
    public partial class FrmMarcaList : Form
    {
        MarcaBusiness rBus = new MarcaBusiness();

        public FrmMarcaList()
        {
            InitializeComponent();
            
        }

        private void FrmMarcaList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");

            int perfilId = new VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;
            if (perfilId != 0) cmdEliminar.Enabled = false;

            btnNuevo.Focus();

        }


        private void FrmMarcaList_Activated(object sender, EventArgs e)
        {
            ListMarcas();
        }

        private void ListMarcas()
        {
            dtGView.DataSource = rBus.getAllMarcas_DT();
            dtGView.Columns[2].Visible = false;

            dtGView.Columns[0].HeaderText = "Codigo";
            dtGView.Columns[1].HeaderText = "Descripción";
            dtGView.Columns[1].Width = 285;
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

                    GlobalClass.marcaGlobal = new MarcaEntity();

                    GlobalClass.marcaGlobal.CodiMarc = Convert.ToInt32(currentRow.Cells[0].Value);
                    GlobalClass.marcaGlobal.DescMarc = currentRow.Cells[1].Value.ToString();
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

                        GlobalClass.marcaGlobal = new MarcaEntity();

                        GlobalClass.marcaGlobal.CodiMarc = Convert.ToInt32(currentRow.Cells[0].Value);
                        GlobalClass.marcaGlobal.DescMarc = currentRow.Cells[1].Value.ToString();
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
                FrmMarca frmRu = new FrmMarca();
                GlobalClass.ActionType = 2;
                frmRu.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmMarca frmRu = new FrmMarca();
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
                MarcaEntity ruEty = new MarcaEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        ruEty = rBus.getMarcaID(reg);
                        ruEty.ActivoMarc = false;
                        rBus.MarcaUpdate(ruEty);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListMarcas();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Marca");
                this.Hide();
            }
        }


        
    }
}
