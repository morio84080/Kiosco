using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulo.Entities;
using Articulo.Business;
using Rubros.Business;

 

namespace Minimercado
{
    public partial class FrmArticuloList : Form
    {
        ArticuloBUS Bus = new ArticuloBUS();
        RubroBusiness rubroBUS = new RubroBusiness();
        private bool frmActivate = false;
        private int perfilId = 0;
        private int filaActual = -1;

        public FrmArticuloList()
        {
            InitializeComponent();            
        }

        private void FrmArticuloList_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.btnModificar, "Seleccione un registro del Listado");
            perfilId = new Vendedor.Business.VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;

            LlenarCboRubro();
            LlenarCboRubroAccion();
            try
            {
                if (GlobalClass.CodiRubro > 0)
                {
                    //cboRubro.SelectedItem = GlobalClass.CodiRubro;
                    cboRubro.SelectedValue = GlobalClass.CodiRubro;
                }
            }
            catch { }
            
        }

        private void FrmArticuloList_KeyDown(object sender, KeyEventArgs e)
        {
            ////thisform.currentSetFocus = this.name
            //if (!txtCodBarra.Focused && !txtValor.Focused)
            //{
            //    if (e.KeyValue == 8)
            //        try
            //        {
            //            lblArticulo.Text = lblArticulo.Text.Substring(0, lblArticulo.Text.Length - 1);
            //        }
            //        catch { }
            //    else if ((e.KeyValue >= 39 && e.KeyValue <= 122) || e.KeyValue == 32 || e.KeyValue == 164 || e.KeyValue == 165 || e.KeyValue == 209 || e.KeyValue == 241) lblArticulo.Text += Convert.ToChar(e.KeyValue);

            //    getArticuloPorDesc();
            //}

        }

        void dtGView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {


                    DataGridViewRow currentRow = dtGView.SelectedRows[0];

                    GlobalClass.artiGlobal = new ArticuloEntity();

                    GlobalClass.artiGlobal.BaseArti = Convert.ToInt32(currentRow.Cells[7].Value);
                    GlobalClass.artiGlobal.CoBaArti = currentRow.Cells[5].Value.ToString();
                    //GlobalClass.artiGlobal.CodiArti = Convert.ToInt32(currentRow.Cells[2].Value);
                    GlobalClass.artiGlobal.DescArti = currentRow.Cells[6].Value.ToString();
                    GlobalClass.artiGlobal.IDArti = Convert.ToInt32(currentRow.Cells[0].Value);
                    GlobalClass.artiGlobal.RubrArti = Convert.ToInt32(currentRow.Cells[1].Value);
                    GlobalClass.artiGlobal.StockArti = Convert.ToInt32(currentRow.Cells[9].Value);
                    GlobalClass.artiGlobal.SugeArti = Convert.ToInt32(currentRow.Cells[8].Value);
                    GlobalClass.artiGlobal.porcIVAArti = Convert.ToDecimal(currentRow.Cells[12].Value);
                    GlobalClass.artiGlobal.MarcaArti = Convert.ToInt32(currentRow.Cells[3].Value);
                }
            
            }
            catch { }
            this.Close();
        }

        void dtGView_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == 8)
            //    try
            //    {
            //        lblArticulo.Text = lblArticulo.Text.Substring(0, lblArticulo.Text.Length - 1);
            //    }
            //    catch { }
            //else if ((e.KeyChar >= 39 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 164 || e.KeyChar == 165 || e.KeyChar == 209 || e.KeyChar == 241) lblArticulo.Text += Convert.ToChar(e.KeyChar);

            //getArticuloPorDesc();
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

                        GlobalClass.artiGlobal = new ArticuloEntity();

                        GlobalClass.artiGlobal.BaseArti = Convert.ToInt32(currentRow.Cells[7].Value);
                        GlobalClass.artiGlobal.CoBaArti = currentRow.Cells[5].Value.ToString();
                        //GlobalClass.artiGlobal.CodiArti = Convert.ToInt32(currentRow.Cells[2].Value);
                        GlobalClass.artiGlobal.DescArti = currentRow.Cells[6].Value.ToString();
                        GlobalClass.artiGlobal.IDArti = Convert.ToInt32(currentRow.Cells[0].Value);
                        GlobalClass.artiGlobal.RubrArti = Convert.ToInt32(currentRow.Cells[1].Value);
                        GlobalClass.artiGlobal.StockArti = Convert.ToInt32(currentRow.Cells[9].Value);
                        GlobalClass.artiGlobal.SugeArti = Convert.ToInt32(currentRow.Cells[8].Value);
                        GlobalClass.artiGlobal.porcIVAArti = Convert.ToDecimal(currentRow.Cells[12].Value);
                        GlobalClass.artiGlobal.MarcaArti= Convert.ToInt32(currentRow.Cells[3].Value);
                    }
                }
                catch { }
                this.Close();

            }
        }

        void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                getArticuloPorCodBarra();
                e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }

        void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAplicar.Focus();
                e.Handled = true;
            }
            else if (e.KeyChar == 46)
            {
                e.KeyChar = Convert.ToChar(44);
            }
            else
            {
                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }

        void txtValor_LostFocus(object sender, EventArgs e)
        {
            txtValor.SelectionStart = 0;
            txtValor.SelectionLength = txtValor.Text.Length;
        }

        private void txtValor_GotFocus(object sender, EventArgs e)
        {
            txtValor.SelectionStart = 0;
            txtValor.SelectionLength = txtValor.Text.Length;
        }

        private bool IsNumeric(char keyAscii)
        {
            if (keyAscii < 48 || keyAscii > 57)
            {
                if (keyAscii == 8 || keyAscii == 44)
                    return true;
                else
                    return false;
            }
            return true;

        }

        private void LlenarCboRubro()
        {
            if (rubroBUS.LlenarComboRubro(this.cboRubro) == -1)
                this.Hide();

            //if (GlobalClass.ActionType != 1)
            this.cboRubro.SelectedValue = -1;
        }

        private void LlenarCboRubroAccion()
        {
            if (rubroBUS.LlenarComboRubro(this.cboRubroAccion) == -1)
                this.Hide();

            //if (GlobalClass.ActionType != 1)
            this.cboRubroAccion.SelectedValue = -1;
        }

        void cboRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frmActivate)
                getArticuloPorRubro();
        }

        private void FrmArticuloList_Activated(object sender, EventArgs e)
        {
            //getArticuloPorRubro();
            frmActivate = true;
            if (GlobalClass.ActionType==2)
            {
                getArticuloPorDesc();
                try
                {
                    dtGView.CurrentCell = dtGView.Rows[filaActual].Cells[0];
                }
                catch { }
                
            }
            GlobalClass.ActionType = 0;
            txtBuscar.Focus();
        }

        private void getArticuloPorRubro()
        {
            txtBuscar.Text = string.Empty;
            ListArticulos(Bus.getByRubro_DT(Convert.ToInt32(cboRubro.SelectedValue)));
        }

        private void getArticuloPorCodBarra()
        {
            ListArticulos(Bus.getByCodBarra_DT(txtCodBarra.Text.Trim()));
        }

        private void getArticuloPorDesc()
        {
            int rubroId = -1;
            if (cboRubro.SelectedValue != null)
                rubroId = Convert.ToInt32(cboRubro.SelectedValue);

            ListArticulos(Bus.getByRubroAndLikeDesc_DT(txtBuscar.Text.Trim(), rubroId));
        }

        private void ListArticulos(DataTable dt)
        {
            //dtGView.DataSource = Bus.getAllArticulos_DT();
            dtGView.DataSource = dt;

            dtGView.Columns[0].HeaderText = "Cód";
            dtGView.Columns[0].Width = 50;
            dtGView.Columns[0].ReadOnly = true;
            dtGView.Columns[1].Visible = false; // COD RUBRO
            dtGView.Columns[2].HeaderText = "Rubro";
            dtGView.Columns[2].Width = 140;
            dtGView.Columns[2].ReadOnly = true;

            dtGView.Columns[3].Visible = false; // COD MARCA
            dtGView.Columns[4].HeaderText = "Marca";
            dtGView.Columns[4].Width = 140;
            dtGView.Columns[4].ReadOnly = true;


            dtGView.Columns[5].HeaderText = "Codigo Barra";
            dtGView.Columns[5].ReadOnly = true;
            dtGView.Columns[6].HeaderText = "Descripción";
            dtGView.Columns[6].Width = 280;
            dtGView.Columns[6].ReadOnly = true;
            dtGView.Columns[7].HeaderText = "Precio Lista $";
            dtGView.Columns[7].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[7].ReadOnly = true;
            dtGView.Columns[8].HeaderText = "Precio Venta $";
            dtGView.Columns[8].DefaultCellStyle.Format = "$ #,#.##";
            dtGView.Columns[8].ReadOnly = true;
            dtGView.Columns[9].HeaderText = "Stock Actual";
            dtGView.Columns[9].ReadOnly = true;
            dtGView.Columns[10].Visible = false; // Estado
            dtGView.Columns[11].Visible = false; // PRINT ARTI
            dtGView.Columns[12].HeaderText = "% IVA";            
            dtGView.Columns[12].DefaultCellStyle.Format = "#,#.##";
            dtGView.Columns[12].ReadOnly = true;
            dtGView.Columns[13].HeaderText = "% Gcia.";
            dtGView.Columns[13].DefaultCellStyle.Format = "#,#.##";
            dtGView.Columns[13].ReadOnly = true;
            dtGView.Columns[14].HeaderText = "Stock Mínimo";
            dtGView.Columns[14].ReadOnly = true;
            dtGView.Columns[15].HeaderText = "#";

            //dtGView.Refresh();

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                GlobalClass.IntPrimaryKey = Convert.ToInt32(currentRow.Cells[0].Value);

                filaActual = dtGView.CurrentRow.Index;
                FrmArticulo frm = new FrmArticulo();
                GlobalClass.ActionType = 2;
                //this.Hide();
                frm.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmArticulo frm = new FrmArticulo();
            this.Hide();
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
                ArticuloEntity Ety = new ArticuloEntity();
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int reg = Convert.ToInt32(currentRow.Cells[0].Value);
                DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar él o los registros seleccionados?",  "Eliminar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        int cnt = 0;
                        while (cnt < dtGView.RowCount)
                        {

                            if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[14].Value))
                            {
                                Ety = new ArticuloEntity();
                                Ety = Bus.getArticuloID(Convert.ToInt32(dtGView.Rows[cnt].Cells[0].Value));
                                Ety.EstaArti = true;
                                Bus.ArticuloUpdate(Ety, Ety, GlobalClass.UserID);
                            }
                            cnt++;
                        }


                        MessageBox.Show("Registro(s) eliminado(s) con éxito");
                        getArticuloPorRubro();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error eliminado Articulo");
                this.Hide();
            }
        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            getArticuloPorDesc();            
        }

        private void checkBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dtGView.Rows)
            {
                fila.Cells[14].Value = checkBoxTodos.Checked;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                IdsArticuloEntity idsArti = new IdsArticuloEntity();
                List<IdsArticuloEntity> idsArtiLst = new List<IdsArticuloEntity>(); 
                while (cnt < dtGView.RowCount)
                {

                    if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[14].Value))
                    {
                        idsArti = new IdsArticuloEntity();
                        idsArti.idArti=Convert.ToInt32(dtGView.Rows[cnt].Cells[0].Value);
                        idsArtiLst.Add(idsArti);
                    }
                    cnt++;
                }
                int tipo = Convert.ToInt32(cboAccion.SelectedIndex);
                switch (tipo)
                {
                    case 0: //Precio costo
                        DialogResult dr1 = MessageBox.Show("¿Esta seguro de Aplicar el Precio de Costo: $ "+ txtValor.Text+" a todos los productos seleccionados?", "Eliminar registro", MessageBoxButtons.OKCancel);                        
                        if (dr1==DialogResult.OK)
                        {
                            Bus.ArticuloUpdatePrecio(idsArtiLst, (short)tipo, GlobalClass.UserID, Convert.ToDecimal(txtValor.Text.Trim()));
                            MessageBox.Show("Actualización Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getArticuloPorDesc();
                        }
                        
                        break;
                    case 1: //Precio Venta
                        DialogResult dr2 = MessageBox.Show("¿Esta seguro de Aplicar el Precio de Venta: $ " + txtValor.Text + " a todos los productos seleccionados?", "Eliminar registro", MessageBoxButtons.OKCancel);
                        if (dr2 == DialogResult.OK)
                        {
                            Bus.ArticuloUpdatePrecio(idsArtiLst, (short)tipo, GlobalClass.UserID, Convert.ToDecimal(txtValor.Text.Trim()));
                            MessageBox.Show("Actualización Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getArticuloPorDesc();
                        }
                        break;
                    case 2: //% costo
                        DialogResult dr3 = MessageBox.Show("¿Esta seguro de Aplicar el % " + txtValor.Text + " al costo de todos los productos seleccionados?", "Eliminar registro", MessageBoxButtons.OKCancel);
                        if (dr3 == DialogResult.OK)
                        {
                            Bus.ArticuloUpdatePrecio(idsArtiLst, (short)tipo, GlobalClass.UserID, Convert.ToDecimal(txtValor.Text.Trim()));
                            MessageBox.Show("Actualización Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getArticuloPorDesc();
                        }

                        break;
                    case 3: //% venta
                        DialogResult dr4 = MessageBox.Show("¿Esta seguro de Aplicar el % " + txtValor.Text + " al Precio de Venta de todos los productos seleccionados?", "Eliminar registro", MessageBoxButtons.OKCancel);
                        if (dr4 == DialogResult.OK)
                        {
                            Bus.ArticuloUpdatePrecio(idsArtiLst, (short)tipo, GlobalClass.UserID, Convert.ToDecimal(txtValor.Text.Trim()));
                            MessageBox.Show("Actualización Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getArticuloPorDesc();
                        }
                        break;
                    case 4: //Cambio de Rubro
                        int rubroId = -1;
                        if (cboRubro.SelectedValue != null)
                            rubroId = Convert.ToInt32(cboRubro.SelectedValue);

                        if (rubroId < 0)
                        {
                            MessageBox.Show("Debe seleccionar un Rubro", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult dr5 = MessageBox.Show("¿Esta seguro cambiar de todos los productos seleccionados al rubro  " + cboRubroAccion.Text + "?", "Eliminar registro", MessageBoxButtons.OKCancel);
                            if (dr5 == DialogResult.OK)
                            {
                                Bus.ArticuloUpdateRubro(idsArtiLst, (short)tipo, GlobalClass.UserID, Convert.ToDecimal(cboRubroAccion.SelectedValue));
                                ArticuloEntity art = new ArticuloEntity();

                                MessageBox.Show("Actualización Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getArticuloPorDesc();
                            }

                        }
                        break;

                }
            }
            catch
            {

            }
        }

        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAccion.SelectedIndex == 4)
                cboRubroAccion.Visible = true;
            else
                cboRubroAccion.Visible = false;

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            getArticuloPorDesc();
        }

        void txtBuscar_LostFocus(object sender, EventArgs e)
        {
            txtBuscar.BackColor = System.Drawing.Color.White;
            txtBuscar.ForeColor = System.Drawing.Color.Black;
        }

        void txtBuscar_GotFocus(object sender, EventArgs e)
        {
            txtBuscar.SelectionStart = 0;
            txtBuscar.SelectionLength = txtCodBarra.Text.Length;
            txtBuscar.BackColor = System.Drawing.Color.Black;
            txtBuscar.ForeColor = System.Drawing.Color.Lime;
        }
    }
}
