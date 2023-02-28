using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localidad.Business;
using Localidad.Entities;

namespace Minimercado
{
    public partial class FrmLocalidad : Form
    {
        LocalidadBUS Bus = new LocalidadBUS();
        LocalidadEntity Ety = new LocalidadEntity();
        public FrmLocalidad()
        {
            InitializeComponent();
        }

        private void FrmLocalidad_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetLocalidadByID();
                CompleteFiles();
            }

        }

        private void GetLocalidadByID()
        {
            try
            {
                Ety = Bus.getLocalidadID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Localidad");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtDesc.Text = Ety.NombLoca;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Localidad");
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
                this.btnAceptar.Focus();
                e.Handled = true;
            }
        }

        private void txtDesc_LostFocus(object sender, EventArgs e)
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
                    LocalidadEntity loEty = new LocalidadEntity();
                    loEty.NombLoca = txtDesc.Text.Trim();
                    Bus.LocalidadInsert(loEty);
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
                    Ety.NombLoca = txtDesc.Text.Trim();
                    Bus.LocalidadUpdate(Ety);
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
            if (txtDesc.Text == string.Empty)
            {
                MessageBox.Show("El campo Descripción no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtDesc.Focus();
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


    }
}
