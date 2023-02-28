using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cliente.Business;
using Cliente.Entities;
using Localidad.Business;
using Vendedor.Business;
using Lista.Business;

namespace Minimercado
{
    public partial class FrmCliente : Form
    {
        private bool formLoad;
        ClienteBUS Bus = new ClienteBUS();
        LocalidadBUS locaBus = new LocalidadBUS();
        int codLoca = 0;
        int codClie = 0;

        ClienteEntity Ety = new ClienteEntity();
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetClienteByID();
                CompleteFiles();
            }
            this.LlenarCboLocalidad();
            LlenarCboCondicionIva();
            formLoad = true;
        }

        private void LlenarCboLocalidad()
        {
            if (locaBus.LlenarComboLocalidad(this.cboLocalidad) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                this.cboLocalidad.SelectedValue = Ety.LocaClie;

        }

        private void LlenarCboCondicionIva()
        {
            if (Bus.LlenarComboCondIva(this.cboCondIVA) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                this.cboCondIVA.SelectedValue = Ety.CondIvaClie;

        }
        void FrmCliente_Activated(object sender, EventArgs e)
        {
            this.cboLocalidad.Focus();
        }

        private void GetClienteByID()
        {
            try
            {
                Ety = Bus.getClienteID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Proveedor");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtRaSocial.Text = Ety.RasoClie.ToString();
                this.txtCUIT.Text = Ety.CuitClie.ToString();
                this.txtDireccion.Text = Ety.DireClie.ToString();
                this.txtTelefono.Text = Ety.TeleClie.ToString();
                this.txtEmail.Text = Ety.MailClie.ToString();
                codClie = Ety.IdClie;
                codLoca = Ety.LocaClie;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Proveedor");
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

        void cboCondIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
                e.Handled = true;
            }

        }

        void çboCondIVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.Focus();
                e.Handled = true;
            }
        }
        private void txtRaSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtCUIT.Focus();
                e.Handled = true;
            }
        }

        void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDireccion.Focus();
                e.Handled = true;
            }
        }

        void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtTelefono.Focus();
                e.Handled = true;
            }
           
        }

        void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtEmail.Focus();
                e.Handled = true;
            }
        }
        void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.cboCondIVA.Focus();
                e.Handled = true;
            }
        }


        void cboLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtRaSocial.Focus();
                e.Handled = true;
            }
        }

        private void txtRaSocial_LostFocus(object sender, EventArgs e)
        {
            txtRaSocial.SelectionStart = 0;
            txtRaSocial.SelectionLength = txtRaSocial.Text.Length;
        }

        void txtCUIT_LostFocus(object sender, EventArgs e)
        {
            txtCUIT.SelectionStart = 0;
            txtCUIT.SelectionLength = txtCUIT.Text.Length;
        }

        void txtDireccion_LostFocus(object sender, EventArgs e)
        {
            txtDireccion.SelectionStart = 0;
            txtDireccion.SelectionLength = txtDireccion.Text.Length;
        }

        void txtTelefono_LostFocus(object sender, EventArgs e)
        {
            txtTelefono.SelectionStart = 0;
            txtTelefono.SelectionLength = txtTelefono.Text.Length;
        }

        void txtEmail_LostFocus(object sender, EventArgs e)
        {
            txtEmail.SelectionStart = 0;
            txtEmail.SelectionLength = txtEmail.Text.Length;
        }

        private void Insert()
        {
            try
            {
                if (this.verifyInfo() == 0)
                {
                    ClienteEntity Ety = new ClienteEntity();
                    Ety.CuitClie = txtCUIT.Text;
                    Ety.DireClie = txtDireccion.Text;
                    Ety.LocaClie = Convert.ToInt32(cboLocalidad.SelectedValue);
                    Ety.RasoClie = txtRaSocial.Text;
                    Ety.TeleClie = txtTelefono.Text;
                    Ety.MailClie = txtEmail.Text;
                    Ety.CondIvaClie = (short)Convert.ToInt32(cboCondIVA.SelectedValue);
                    Bus.ClienteInsert(Ety);
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
                    Ety.IdClie = GlobalClass.IntPrimaryKey;
                    Ety.CuitClie = txtCUIT.Text;
                    Ety.DireClie = txtDireccion.Text;
                    Ety.LocaClie = Convert.ToInt32(cboLocalidad.SelectedValue);
                    Ety.RasoClie = txtRaSocial.Text;
                    Ety.TeleClie = txtTelefono.Text;
                    Ety.MailClie = txtEmail.Text;
                    Ety.CondIvaClie = (short)Convert.ToInt32(cboCondIVA.SelectedValue);
                    Bus.ClienteUpdate(Ety);
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
            if (txtRaSocial.Text == string.Empty)
            {
                MessageBox.Show("El campo Razón Social no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtRaSocial.Focus();
            }
            else if (Convert.ToInt32(cboLocalidad.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar una Localidad", "Dato Incorrecto");
                ret = 1;
                cboLocalidad.Focus();
            }
            return ret;
        }

        private void ClearFiles()
        {
            txtRaSocial.Text = string.Empty;
            txtCUIT.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboLocalidad.SelectedValue = -1;
            //Obtener Código de Cliente
            cboLocalidad.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
