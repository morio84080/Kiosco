using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rubros.Business;
using Rubros.Entities;

namespace Minimercado
{
    public partial class FrmRubro : Form
    {
        RubroBusiness ruBus = new RubroBusiness();
        RubroEntity ruEty = new RubroEntity();
        RubroEntity oldRuEty = new RubroEntity();
        public FrmRubro()
        {
            InitializeComponent();
        }

        private void FrmRubro_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetRubroByID();
                CompleteFiles();
            }

        }

        private void GetRubroByID()
        {
            try
            {
                ruEty = ruBus.getRubroID(GlobalClass.IntPrimaryKey);
                oldRuEty = ruBus.getRubroID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Rubro");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtDesc.Text = ruEty.DescRubr;
                this.txtPorcGanancia.Text = Convert.ToString(ruEty.PorcGananciaRubr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del rubro");
                this.Hide();
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (GlobalClass.ActionType)
            {

                case 1: //Nuevo
                    Insert();
                    break;
                case 2: //Modificar
                    Update();
                    break;
                default:
                    MessageBox.Show("Opción Incorrecta");
                    break;
            }


        }

        

        private void txtAbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDesc.Focus();
                e.Handled = true;
            }
            
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPorcGanancia.Focus();
                e.Handled = true;
            }
        }

        private void txtDesc_LostFocus(object sender, EventArgs e)
        {
            txtDesc.SelectionStart = 0;
            txtDesc.SelectionLength = txtDesc.Text.Length;
        }

        private void txtPorcGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                this.txtPorcDto.Focus();
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
        private void txtPorcGanancia_LostFocus(object sender, EventArgs e)
        {
            txtPorcGanancia.SelectionStart = 0;
            txtPorcGanancia.SelectionLength = txtPorcGanancia.Text.Length;
        }

        private void Insert()
        {
            try
            {
                if (this.verifyInfo() == 0)
                {
                    RubroEntity ruEty = new RubroEntity();
                    ruEty.DescRubr = txtDesc.Text.Trim();
                    ruEty.PorcGananciaRubr = Convert.ToDecimal(txtPorcGanancia.Text);
                    ruEty.PorcDtoRubr = Convert.ToDecimal(txtPorcDto.Text);
                    ruBus.RubroInsert(ruEty,GlobalClass.UserID);
                    MessageBox.Show("Registro guardado con éxito");
                    this.ClearFiles();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Insertando Datos");
            }
        }

        private void Update()
        {
            try
            {
                if (this.verifyInfo() == 0)
                {
                    //AdministratorEntity usEty = new AdministratorEntity();
                    ruEty.DescRubr = txtDesc.Text.Trim();
                    ruEty.PorcGananciaRubr = Convert.ToDecimal(txtPorcGanancia.Text);
                    ruEty.PorcDtoRubr = Convert.ToDecimal(txtPorcDto.Text);
                    ruBus.RubroUpdate(ruEty,oldRuEty,GlobalClass.UserID,checkBoxActualiza.Checked);

                    MessageBox.Show("Registro Modificado con éxito");
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Insertando Datos");
            }
        }

        private int verifyInfo()
        {
            int ret = 0;
            if (string.IsNullOrEmpty(txtPorcGanancia.Text)) txtPorcGanancia.Text = "0";
            if (string.IsNullOrEmpty( txtDesc.Text))
            {
                MessageBox.Show("El campo Descripción no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtDesc.Focus();
            }
            else if (Convert.ToDecimal(txtPorcGanancia.Text)<=0)
            {
                MessageBox.Show("El % de Ganancia de ser > 0", "Dato Incorrecto");
                ret = 1;
                txtPorcGanancia.Focus();
            }

            return ret;

        }

        private void ClearFiles()
        {
            txtDesc.Text = string.Empty;            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPorcDto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
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
    }
}
