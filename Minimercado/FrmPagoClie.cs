using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using CuentaCorriente.Business;
using CuentaCorriente.Entities;
using Cliente.Business;
using Cliente.Entities;

namespace Minimercado
{
    public partial class FrmPagoClie : Form
    {
        private Font printFont;
        private Font printFontTitulo;

        PagoClieBUS Bus = new PagoClieBUS();
        ClienteBUS clieBus = new ClienteBUS();
        PagoClieEntity Ety = new PagoClieEntity();
        ClienteEntity cliente = new ClienteEntity();
        public FrmPagoClie()
        {
            InitializeComponent();
        }

        private void FrmPagoClie_Load(object sender, EventArgs e)
        {
            LlenarCboCliente();
            LlenarCboCondicion();
            GlobalClass.clieGlobal = new ClienteEntity();
            if (GlobalClass.ActionType == 2)
            {
                GetPagoClieByID();
                CompleteFiles();
            }                       
        }

        void FrmPagoClie_Activated(object sender, EventArgs e)
        {
            
        }

        private void LlenarCboCondicion()
        {
            if (Bus.LlenarComboCondicion(this.cboCondicion, 2) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                cboCondicion.SelectedValue = Ety.TipoPACL;

        }

        private void GetPagoClieByID()
        {
            try
            {
                Ety = Bus.getByID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Pago Proveedor");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtImporte.Text = Math.Round(Ety.ImpoPACL,2).ToString();                
                this.txtDetalle.Text = Ety.DetaPACL;
                cboCliente.SelectedValue = Ety.CliePACL;
                GlobalClass.clieGlobal = cliente;
                this.dtpFecha.Value = Ety.FechaPACL;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Pago");
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

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDetalle.Focus();
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

        private void txtDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
                e.Handled = true;
            }            
        }

        void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboCliente.Focus();
                e.Handled = true;
            }
        }

        private void cboCondicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtImporte.Focus();
                e.Handled = true;
            }
        }

        private void cboCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtImporte.Focus();
                e.Handled = true;
            }

        }

        void txtImporte_GotFocus(object sender, EventArgs e)
        {
            txtImporte.SelectionStart = 0;
            txtImporte.SelectionLength = txtImporte.Text.Length;
        }

        private void txtDetalle_GotFocus(object sender, EventArgs e)
        {
            txtDetalle.SelectionStart = 0;
            txtDetalle.SelectionLength = txtDetalle.Text.Length;            
        }

        void txtImporte_Click(object sender, EventArgs e)
        {
            txtImporte.SelectionStart = 0;
            txtImporte.SelectionLength = txtImporte.Text.Length;
        }

        void txtDetalle_Click(object sender, EventArgs e)
        {
            txtDetalle.SelectionStart = 0;
            txtDetalle.SelectionLength = txtDetalle.Text.Length;
        }
        

        private void Insert()
        {
            try
            {
                if (this.verifyInfo() == 0)
                {
                    PagoClieEntity Ety = new PagoClieEntity();
                    Ety.ImpoPACL = Convert.ToDouble(txtImporte.Text.Replace('.', ','));
                    Ety.DetaPACL = txtDetalle.Text.Trim();
                    Ety.FechaPACL = dtpFecha.Value;
                    Ety.CliePACL = Convert.ToInt32(cboCliente.SelectedValue);
                    Ety.TipoPACL = (short)Convert.ToInt32(cboCondicion.SelectedValue);

                    Bus.Insert(Ety, GlobalClass.UserID);

                    ImprimirNoFiscal();
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
                    PagoClieEntity pagoClieNew = new PagoClieEntity();
                    pagoClieNew.ImpoPACL = Convert.ToDouble(txtImporte.Text.Replace('.', ','));
                    pagoClieNew.DetaPACL = txtDetalle.Text.Trim();
                    pagoClieNew.FechaPACL = dtpFecha.Value;
                    pagoClieNew.CliePACL = Convert.ToInt32(cboCliente.SelectedValue);
                    pagoClieNew.NumePACL = Ety.NumePACL;
                    pagoClieNew.TipoPACL = (short)Convert.ToInt32(cboCondicion.SelectedValue);
                    Bus.Update(pagoClieNew,Ety,GlobalClass.UserID);
                    MessageBox.Show("Registro Modificado con éxito");
                    ImprimirNoFiscal();
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
            if (Convert.ToInt32(cboCliente.SelectedValue) == -1 || cboCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe selecciona un cliente", "ERROR");
                cboCliente.Focus();
            }
            else if (txtImporte.Text == string.Empty)
            {
                MessageBox.Show("El campo Importe no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtImporte.Focus();
            }
            else if (string.IsNullOrEmpty(txtImporte.Text))
            {
                MessageBox.Show("El campo Importe no puede estar vacio", "Dato Incorrecto");
                txtImporte.Focus();

            }


            return ret;

        }

        private void ClearFiles()
        {
            txtImporte.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            GlobalClass.clieGlobal = new ClienteEntity();
            dtpFecha.Value = DateTime.Now;
            //btnCliente.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClienteList frm = new FrmClienteList();
            frm.ShowDialog();
            txtImporte.Focus();
        }

        private void LlenarCboCliente()
        {
            if (clieBus.LlenarComboCliente(this.cboCliente) == -1)
                this.Hide();


            //if (GlobalClass.ActionType != 1)
            this.cboCliente.SelectedValue = -1;
        }

        private bool IsNumeric(char keyAscii)
        {
            if (keyAscii < 48 || keyAscii > 57)
            {
                if (keyAscii == 8 || keyAscii == 44 || keyAscii == 45)
                    return true;
                else
                    return false;
            }
            return true;

        }


        private void ImprimirNoFiscal()
        {
            try
            {

                printFontTitulo = new Font("Arial", 10);
                printFont = new Font("Arial", 8);
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();

                
            }
            catch (Exception ex)
            {
                //respuestas();
                MessageBox.Show(ex.Message);
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                Pen blackPen = new Pen(Color.Black, 3);

                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();

                string lineaBlanco = ".";
                //ENCABEZADO
                ev.Graphics.DrawString("RECIBO DE PAGO", printFontTitulo, Brushes.Black, 80, 10, new StringFormat());
                ev.Graphics.DrawString("CLIENTE: " +  cboCliente.Text.Trim(), printFont, Brushes.Black, 5, 40, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 5, 60, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm:ss"), printFont, Brushes.Black, 150, 60, new StringFormat());
                //LINEA
                ev.Graphics.DrawLine(blackPen, 5, 90, 400, 90);

                //IMPORTE
                int line = 110;
                ev.Graphics.DrawString((cboCondicion.Text.Trim().Length > 30 ? cboCondicion.Text.Trim().Substring(0, 30) : cboCondicion.Text.Trim()), printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString("$ " + txtImporte.Text, printFont, Brushes.Black, 220, line, new StringFormat());

                //DETALLE
                line += 25;
                ev.Graphics.DrawString(txtDetalle.Text.Trim(), printFont, Brushes.Black, 5, line, new StringFormat());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }

    }
}
