using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Proveedor.Business;
using Proveedor.Entities;
using Localidad.Business;
using Vendedor.Business;
using Lista.Business;

namespace Minimercado
{
    public partial class FrmProveedor : Form
    {
        private bool formLoad;
        ProveedorBUS Bus = new ProveedorBUS();
        LocalidadBUS locaBus = new LocalidadBUS();
        int codLoca = 0;
        int codClie = 0;

        ProveedorEntity Ety = new ProveedorEntity();
        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetProveedorByID();
                CompleteFiles();
            }
            this.LlenarCboLocalidad();
            formLoad = true;
        }

        private void LlenarCboLocalidad()
        {
            if (locaBus.LlenarComboLocalidad(this.cboLocalidad) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                this.cboLocalidad.SelectedValue = Ety.LocaProv;

        }


        void FrmProveedor_Activated(object sender, EventArgs e)
        {
            this.cboLocalidad.Focus();
        }

        private void GetProveedorByID()
        {
            try
            {
                Ety = Bus.getProveedorID(GlobalClass.IntPrimaryKey);
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
                this.txtRaSocial.Text = Ety.RasoProv.ToString();
                this.txtCUIT.Text = Ety.CuitProv.ToString();
                this.txtDireccion.Text = Ety.DireProv.ToString();
                this.txtTelefono.Text = Ety.TeleProv.ToString();
                this.txtEmail.Text = Ety.MailProv.ToString();
                codClie = Ety.IdProv;
                codLoca = Ety.LocaProv;
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
                this.btnAceptar.Focus();
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
                    ProveedorEntity Ety = new ProveedorEntity();
                    Ety.CuitProv = txtCUIT.Text;
                    Ety.DireProv = txtDireccion.Text;
                    Ety.LocaProv = Convert.ToInt32(cboLocalidad.SelectedValue);
                    Ety.RasoProv = txtRaSocial.Text;
                    Ety.TeleProv = txtTelefono.Text;
                    Ety.MailProv = txtEmail.Text;
                    Bus.ProveedorInsert(Ety);
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
                    Ety.IdProv = GlobalClass.IntPrimaryKey;
                    Ety.CuitProv = txtCUIT.Text;
                    Ety.DireProv = txtDireccion.Text;
                    Ety.LocaProv = Convert.ToInt32(cboLocalidad.SelectedValue);
                    Ety.RasoProv = txtRaSocial.Text;
                    Ety.TeleProv = txtTelefono.Text;
                    Ety.MailProv = txtEmail.Text;
                    Bus.ProveedorUpdate(Ety);
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
            //Obtener Código de Proveedor
            cboLocalidad.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
