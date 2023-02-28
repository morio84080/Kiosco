using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vendedor.Entities;
using Vendedor.Business;
 

namespace Minimercado
{
    public partial class FrmVendedorList : Form
    {
        VendedorBusiness rBus = new VendedorBusiness();

        public FrmVendedorList()
        {
            InitializeComponent();
            
        }

        private void FrmVendedorList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");
        }


        private void FrmVendedorList_Activated(object sender, EventArgs e)
        {
            ListVendedors();
        }

        private void ListVendedors()
        {
            dtGView.DataSource = rBus.getAllVendedores_DT();
            

            dtGView.Columns[0].HeaderText = "Codigo";
            dtGView.Columns[0].Width = 50;
            dtGView.Columns[1].HeaderText = "Apellido";
            dtGView.Columns[1].Width = 145;
            dtGView.Columns[2].HeaderText = "Nombre";
            dtGView.Columns[2].Width = 100;
            dtGView.Columns[3].HeaderText = "Direccion";
            dtGView.Columns[3].Width = 138;
            dtGView.Columns[4].HeaderText = "Teléfono";
            dtGView.Columns[5].Visible = false;
            dtGView.Columns[6].HeaderText = "Nombre Usuario";
            dtGView.Columns[6].Width = 110;
            dtGView.Columns[7].Visible = false;
            dtGView.Columns[8].Visible = false;
            dtGView.Columns[9].HeaderText = "Mail";
            dtGView.Columns[9].Width = 140;
            dtGView.Columns[10].HeaderText = "Perfil";
            
            

            //dtGView.Refresh();

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[0].Value);
                FrmVendedor frmRu = new FrmVendedor();
                GlobalClass.ActionType = 2;
                frmRu.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmVendedor frm = new FrmVendedor();
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
                VendedorEntity Ety = new VendedorEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Ety = rBus.getVendedorID(reg);
                        Ety.EstaVend = true;
                        rBus.VendedorUpdate(Ety);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListVendedors();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Vendedor");
                this.Hide();
            }
        }


        
    }
}
