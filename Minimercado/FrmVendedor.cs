using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vendedor.Business;
using Vendedor.Entities;
using Localidad.Business;
using Localidad.Entities;

namespace Minimercado
{
    public partial class FrmVendedor : Form
    {
        VendedorBusiness sys = new VendedorBusiness();
        LocalidadBUS locaBUS = new LocalidadBUS();
        VendedorEntity ety = new VendedorEntity();
        public FrmVendedor()
        {
            InitializeComponent();
        }

        private void FrmVendedor_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetVendedorByID();
                CompleteFiles();
            }
            this.LlenarCboPerfil();
            txtNombre.Focus();
        }

        private void LlenarCboPerfil()
        {
            if (sys.LlenarComboPerfil(this.cboPerfil) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                this.cboPerfil.SelectedValue = ety.PerfilVend;
            //this.cboProviders.SelectedIndex = biEty.ProviderID - 1;

        }


        private void GetVendedorByID()
        {
            try
            {
                ety = sys.getVendedorID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Vendedor");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtApellido.Text = ety.ApelVend;
                this.txtDireccion.Text = ety.DireVend;
                this.txtMail.Text = ety.MailVend;
                this.txtPassword.Text = ety.PassVend;
                this.txtRepetirPass.Text = ety.PassVend;
                this.txtTelefono.Text = ety.TeleVend;
                this.txtUsuario.Text = ety.UserVend;
                this.txtNombre.Text = ety.NombVend;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Vendedor");
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



        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtApellido.Focus();
                e.Handled = true;
            }
            
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtMail.Focus();
                e.Handled = true;
            }
        }

        void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.cboPerfil.Focus();
                e.Handled = true;
            }
           
        }

        void cboPerfil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtUsuario.Focus();
                e.Handled = true;
            }
        }
        void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPassword.Focus();
                e.Handled = true;
            }
        }

        void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtRepetirPass.Focus();
                e.Handled = true;
            }
        }

        void txtRepetirPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
                e.Handled = true;
            }
        }

        

        private void txtNombre_LostFocus(object sender, EventArgs e)
        {
            txtNombre.SelectionStart = 0;
            txtNombre.SelectionLength = txtNombre.Text.Length;
        }

        private void txtApellido_LostFocus(object sender, EventArgs e)
        {
            txtApellido.SelectionStart = 0;
            txtApellido.SelectionLength = txtApellido.Text.Length;
            txtUsuario.Text =  txtNombre.Text.Substring(0, 1).ToLower() + txtApellido.Text.Trim().ToLower();
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

        void txtMail_LostFocus(object sender, EventArgs e)
        {
            txtMail.SelectionStart = 0;
            txtMail.SelectionLength = txtMail.Text.Length;
        }

        void txtUsuario_LostFocus(object sender, EventArgs e)
        {
            txtUsuario.SelectionStart = 0;
            txtUsuario.SelectionLength = txtUsuario.Text.Length;
        }

        void txtPassword_LostFocus(object sender, EventArgs e)
        {
            txtPassword.SelectionStart = 0;
            txtPassword.SelectionLength = txtPassword.Text.Length;
        }

        void txtRepetirPass_LostFocus(object sender, EventArgs e)
        {
            txtRepetirPass.SelectionStart = 0;
            txtRepetirPass.SelectionLength = txtRepetirPass.Text.Length;

        }


        private void Insert()
        {
            try
            {
                if (this.verifyInfo() == 0)
                {
                    VendedorEntity veEty = new VendedorEntity();
                    veEty.ApelVend = txtApellido.Text.Trim();
                    veEty.DireVend = txtDireccion.Text.Trim();
                    veEty.MailVend = txtMail.Text.Trim();
                    veEty.NombVend = txtNombre.Text.Trim();
                    veEty.PassVend = txtPassword.Text.Trim();
                    veEty.PerfilVend = Convert.ToInt32(cboPerfil.SelectedValue);
                    veEty.TeleVend = txtTelefono.Text.Trim();
                    veEty.UserVend = txtUsuario.Text.Trim();
                    sys.VendedorInsert(veEty);
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
                    ety.ApelVend = txtApellido.Text.Trim();
                    ety.DireVend = txtDireccion.Text.Trim();
                    ety.MailVend = txtMail.Text.Trim();
                    ety.NombVend = txtNombre.Text.Trim();
                    ety.PassVend = txtPassword.Text.Trim();
                    ety.PerfilVend = Convert.ToInt32(cboPerfil.SelectedValue);
                    ety.TeleVend = txtTelefono.Text.Trim();
                    ety.UserVend = txtUsuario.Text.Trim();
                    sys.VendedorUpdate(ety);
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
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("El campo Nombre no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtNombre.Focus();
            }
            else if (txtApellido.Text == string.Empty)
            {
                MessageBox.Show("El campo Apellido no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtApellido.Focus();
            }
            else if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("El campo Usuario no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtUsuario.Focus();
            }
            else if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("El campo Contraseña no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtPassword.Focus();
            }
            else if (txtPassword.Text != txtRepetirPass.Text)
            {
                MessageBox.Show("Las contraseñas deben ser iguales", "Dato Incorrecto");
                ret = 1;
                txtPassword.Focus();
            }
            else if (Convert.ToInt32(cboPerfil.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar un perfil", "Dato Incorrecto");
                ret = 1;
                cboPerfil.Focus();
            }

            return ret;

        }

        private void ClearFiles()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtRepetirPass.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            cboPerfil.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
