using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Users.Business;
using System.Diagnostics;
using ctc3DES;
using MaterialSkin;


namespace Minimercado
{
    public partial class FrmPassword :  MaterialSkin.Controls.MaterialForm
    {
        public FrmPassword()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue600, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GlobalClass.UserRS = System.Configuration.ConfigurationManager.AppSettings["UserRS"].ToString();
            GlobalClass.PasswordRS = System.Configuration.ConfigurationManager.AppSettings["PasswordRS"].ToString();
            GlobalClass.RS_url = System.Configuration.ConfigurationManager.AppSettings["RS_url"].ToString();

            ctc3DES.TripleDESUtil ctc = new TripleDESUtil();
            try
            {
                GlobalClass.UserRS = ctc.DesEncriptar(GlobalClass.UserRS);
                GlobalClass.PasswordRS = ctc.DesEncriptar(GlobalClass.PasswordRS);
                GlobalClass.RS_url = ctc.DesEncriptar(GlobalClass.RS_url);

            }
            catch { }
            UsersBusiness userBUS = new UsersBusiness();
            try
            {
                int res = userBUS.LoginUser(this.txtUserName.Text, this.txtPassword.Text);
                switch (res)
                {
                    case 0:
                        GlobalClass.GlobalVar = this.txtUserName.Text;
                        FrmMain frMain = new FrmMain(this);
                        frMain.Show(this);
                        this.Hide();
                        break;
                    case 1:
                        MessageBox.Show("Contraseña incorrecta", "Error Login");
                        this.txtPassword.Focus();
                        break;
                    case 2:
                        MessageBox.Show("Nombre de Usuario incorrecto", "Error Login");
                        this.txtUserName.Focus();
                        break;
                    default:
                        MessageBox.Show("Excepción no prevista", "Error Login");
                        break;

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Login");
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPassword.Focus();
                e.Handled = true;
            }         
        }



        private void txtUserName_LostFocus(object sender, System.EventArgs e)
        {
            txtUserName.SelectionStart = 0;
            txtUserName.SelectionLength = txtUserName.Text.Length;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.PerformClick();
                e.Handled = true;
            }
        }

        private void txtPassword_LostFocus(object sender, System.EventArgs e)
        {
            txtPassword.SelectionStart = 0;
            txtPassword.SelectionLength = txtPassword.Text.Length;
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("La aplicación ya se encuentra en ejecucion", "Info");
                Application.Exit();
            }
            txtUserName.Focus();
        }


    }
 }
