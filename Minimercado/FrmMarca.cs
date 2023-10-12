using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Marcas.Business;
using Marcas.Entities;


namespace Minimercado
{
    public partial class FrmMarca : Form
    {
        MarcaBusiness ruBus = new MarcaBusiness();
        MarcaEntity ruEty = new MarcaEntity();
        public FrmMarca()
        {
            InitializeComponent();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetMarcaByID();
                CompleteFiles();
            }

        }

        private void GetMarcaByID()
        {
            try
            {
                ruEty = ruBus.getMarcaID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Marca");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtDesc.Text = ruEty.DescMarc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Marca");
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
                    MarcaEntity ruEty = new MarcaEntity();
                    ruEty.DescMarc = txtDesc.Text.Trim();
                    ruBus.MarcaInsert(ruEty);
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
                    ruEty.DescMarc = txtDesc.Text.Trim();
                    ruBus.MarcaUpdate(ruEty);
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
