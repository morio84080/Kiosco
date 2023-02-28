using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Proveedor.Entities;
using Proveedor.Business;
using Localidad.Business;
using Vendedor.Business;
 

namespace Minimercado
{
    public partial class FrmProveedorList : Form
    {
        ProveedorBUS Bus = new ProveedorBUS();
        LocalidadBUS locaBus = new LocalidadBUS();
        int perfilId = 0;
        private bool frmActivate = false;

        public FrmProveedorList()
        {
            InitializeComponent();
            
        }

        private void FrmProveedorList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del listado");
            perfilId = new VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;
            //if (perfilId < 2)
            //{
                this.LlenarCboLocalidad();
                try
                {
                    if (GlobalClass.CodiLoca > 0)
                    {
                        cboLocalidad.SelectedValue = GlobalClass.CodiLoca;
                    }
                }
                catch { }
            //}
            //else
            //{ 
            //    this.cboLocalidad.Visible = false;
            //    this.label14.Visible = false;
            //}

        }

        private void LlenarCboLocalidad()
        {
            if (locaBus.LlenarComboLocalidad(this.cboLocalidad) == -1)
                this.Hide();


            //if (GlobalClass.ActionType != 1)
                this.cboLocalidad.SelectedValue = -1;            
        }

        private void FrmProveedorList_Activated(object sender, EventArgs e)
        {
            frmActivate = true;
            ListProveedors();
        }

        void dtGView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {


                    DataGridViewRow currentRow = dtGView.SelectedRows[0];

                    GlobalClass.provGlobal = new ProveedorEntity();

                    GlobalClass.provGlobal.IdProv = Convert.ToInt32(currentRow.Cells[0].Value);
                    GlobalClass.provGlobal.LocaProv = Convert.ToInt32(currentRow.Cells[1].Value);
                    GlobalClass.provGlobal.NombLoca = currentRow.Cells[8].Value.ToString();
                    GlobalClass.provGlobal.RasoProv = currentRow.Cells[2].Value.ToString();
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

                        GlobalClass.provGlobal = new ProveedorEntity();

                        GlobalClass.provGlobal.IdProv = Convert.ToInt32(currentRow.Cells[0].Value);
                        GlobalClass.provGlobal.LocaProv = Convert.ToInt32(currentRow.Cells[1].Value);
                        GlobalClass.provGlobal.NombLoca = currentRow.Cells[8].Value.ToString();
                        GlobalClass.provGlobal.RasoProv = currentRow.Cells[2].Value.ToString();
                    }
                }
                catch { }
                this.Close();

            }
        }


        private void ListProveedors()
        {
            //dtGView.DataSource = Bus.getAllProveedors_DT();
            //if (perfilId<2)
                dtGView.DataSource = Bus.getByLoca_DT(Convert.ToInt32(cboLocalidad.SelectedValue));
            //else
            //    dtGView.DataSource = Bus.getByVend_DT(GlobalClass.UserID);


                dtGView.Columns[0].HeaderText = "ID";
                dtGView.Columns[0].Width = 50;
                dtGView.Columns[1].Visible = false; //COD LOCALIDAD
                dtGView.Columns[2].HeaderText = "Razón Social";
                dtGView.Columns[2].Width = 180;
                dtGView.Columns[3].HeaderText = "CUIT";
                dtGView.Columns[3].Width = 60;
                dtGView.Columns[4].HeaderText = "Dirección";
                dtGView.Columns[4].Width = 120;
                dtGView.Columns[5].HeaderText = "Teléfono";
                dtGView.Columns[6].HeaderText = "E-mail";
                dtGView.Columns[7].Visible = false; //Estado
                dtGView.Columns[8].HeaderText = "Localidad";
                dtGView.Columns[8].Width = 150;

            dtGView.Focus();
            //dtGView.Refresh();

        }

        private void ListProveedorsByDesc()
        {
            //dtGView.DataSource = Bus.getAllProveedors_DT();
            //if (perfilId <2)
                dtGView.DataSource = Bus.getByRasoAndLoca_DT(lblProveedor.Text.Trim(),Convert.ToInt32(cboLocalidad.SelectedValue));
            //else
            //    dtGView.DataSource = Bus.getByRasoAndVend_DT(lblProveedor.Text.Trim(),GlobalClass.UserID);


            dtGView.Columns[0].HeaderText = "ID";
            dtGView.Columns[0].Width = 50;
            dtGView.Columns[1].Visible = false; //COD LOCALIDAD
            dtGView.Columns[2].HeaderText = "Razón Social";
            dtGView.Columns[2].Width = 180;
            dtGView.Columns[3].HeaderText = "CUIT";
            dtGView.Columns[3].Width = 60;
            dtGView.Columns[4].HeaderText = "Dirección";
            dtGView.Columns[4].Width = 120;
            dtGView.Columns[5].HeaderText = "Teléfono";
            dtGView.Columns[6].HeaderText = "E-mail";
            dtGView.Columns[7].Visible = false; //Estado
            dtGView.Columns[8].HeaderText = "Localidad";
            dtGView.Columns[8].Width = 150;

            //dtGView.Refresh();

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[0].Value);
                FrmProveedor frmRu = new FrmProveedor();
                GlobalClass.ActionType = 2;
                frmRu.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmProveedor frmRu = new FrmProveedor();
            frmRu.ShowDialog();
        }

        void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frmActivate)
                ListProveedors();
        }


        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            Deleted();
        }


        private void Deleted()
        {
            try
            {
                ProveedorEntity Ety = new ProveedorEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el registro?",
                "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        Ety = Bus.getProveedorID(reg);
                        Ety.EstaProv = true;
                        Bus.ProveedorUpdate(Ety);
                        MessageBox.Show("Registro eliminado con éxito");
                        ListProveedors();
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Proveedor");
                this.Hide();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtGView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        void dtGView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                try
                {
                    lblProveedor.Text = lblProveedor.Text.Substring(0, lblProveedor.Text.Length - 1);
                }
                catch { }
            else if ((e.KeyChar >= 39 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 164 || e.KeyChar == 165 || e.KeyChar == 209 || e.KeyChar == 241) lblProveedor.Text += Convert.ToChar(e.KeyChar);

            ListProveedorsByDesc();
        }


        
    }
}
