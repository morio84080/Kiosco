using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lista.Business;
using Lista.Entities;

namespace Minimercado
{
    public partial class FrmLista : Form
    {
        ListaBUS Bus = new ListaBUS();
        ListaEntity Ety = new ListaEntity();
        public FrmLista()
        {
            InitializeComponent();
        }

        private void FrmLista_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetListaByID();
                CompleteFiles();
            }
        }

        void FrmLista_Activated(object sender, EventArgs e)
        {
            this.txtDesc.Focus();
        }

        private void GetListaByID()
        {
            try
            {
                Ety = Bus.getListaID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Lista");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtDesc.Text = Ety.NombList;
                this.txtPorc.Text = Ety.PorcList.ToString();
                this.txtPorcGanancia.Text = Ety.PosuList.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Lista");
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

        

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPorc.Focus();
                e.Handled = true;
            }
        }

        void txtPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPorcGanancia.Focus();
                e.Handled = true;
            }
        }

        void txtPorcGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
                e.Handled = true;
            }
        }

        private void txtDesc_LostFocus(object sender, EventArgs e)
        {
            txtDesc.SelectionStart = 0;
            txtDesc.SelectionLength = txtDesc.Text.Length;
        }

        void txtPorc_LostFocus(object sender, EventArgs e)
        {
            txtDesc.SelectionStart = 0;
            txtDesc.SelectionLength = txtDesc.Text.Length;
        }

        void txtPorcGanancia_LostFocus(object sender, EventArgs e)
        {
            txtDesc.SelectionStart = 0;
            txtDesc.SelectionLength = txtDesc.Text.Length;

        }


        private void Insert()
        {
            try
            {
                if (this.verifyInfo() == 0)
                {
                    ListaEntity lEty = new ListaEntity();
                    lEty.NombList = txtDesc.Text.Trim();
                    lEty.PorcList = Convert.ToDouble(txtPorc.Text.Replace('.',','));
                    lEty.PosuList = Convert.ToDouble(txtPorcGanancia.Text.Replace('.', ','));
                    Bus.ListaInsert(lEty);
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
                    Ety.NombList = txtDesc.Text.Trim();
                    Ety.PorcList = Convert.ToDouble(txtPorc.Text);
                    Ety.PosuList = Convert.ToDouble(txtPorcGanancia.Text);
                    Bus.ListaUpdate(Ety);
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
            double d = 0;
            if (txtDesc.Text == string.Empty)
            {
                MessageBox.Show("El campo Nombre no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtDesc.Focus();
            }
            else if (txtPorc.Text == string.Empty)
            {
                MessageBox.Show("El campo Porcentaje no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtPorc.Focus();
            }
            else if (txtPorcGanancia.Text == string.Empty)
            {
                MessageBox.Show("El campo Porc. Ganancia no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtPorcGanancia.Focus();
            }

            try { d = Convert.ToDouble(txtPorc.Text); }
            catch
            {
                MessageBox.Show("El campo Porcentaje debe ser numérico", "Dato Incorrecto");
                ret = 1;
                txtPorc.Focus();
            }

            try { d = Convert.ToDouble(txtPorcGanancia.Text); }
            catch
            {
                MessageBox.Show("El campo Porc. Ganancia debe ser numérico", "Dato Incorrecto");
                ret = 1;
                txtPorcGanancia.Focus();
            }


            return ret;

        }

        private void ClearFiles()
        {
            txtDesc.Text = string.Empty;
            txtPorc.Text = string.Empty;
            txtPorcGanancia.Text = string.Empty;
            txtDesc.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
