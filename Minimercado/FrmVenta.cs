using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using Ventas.Business;
using Ventas.Entities;
using Localidad.Business;
using Cliente.Business;
using Vendedor.Business;
using System.IO;
using System.Threading;
using Logger;
using HasarArgentina;
using Cliente.Entities;
using CuentaCorriente.Business;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using FacturaElectronica.Entities;
using FacturaElectronica.Business;
using Articulo.Entities;
using Articulo.Business;

namespace Minimercado
{
    public partial class FrmVenta : Form
    {
        private bool nuevo = true;
        private double timeDelay = double.Parse(System.Configuration.ConfigurationManager.AppSettings["delay"]);
        private bool facturaElectronica = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["FacturaElectronica"]);
        private bool ComanderaAlternativa = false;
        private  string sCmd = string.Empty;
        private  string sCmdExt = string.Empty;
        private decimal porcDtoArt = 0;
        private  bool bAnswer = true;
        private bool changeQuantity = false;
        private bool openPort = false;
        int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["port"]);
        int ActivateIF = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ActivateIF"]);

        int IpPuertoHasar = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IpPuertoHasar"]);
        string IpHasar = System.Configuration.ConfigurationManager.AppSettings["IpHasar"].ToString();
        string sonido = System.Configuration.ConfigurationManager.AppSettings["sonido"].ToString();
        int produccion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["produccion"]);
        static string RazonSocial = System.Configuration.ConfigurationManager.AppSettings["RazonSocial"].ToString();
        static string CUIT = System.Configuration.ConfigurationManager.AppSettings["CUIT"].ToString();
        static string IngresosBrutos = System.Configuration.ConfigurationManager.AppSettings["IngresosBrutos"].ToString();
        static string FechaIniActividades = System.Configuration.ConfigurationManager.AppSettings["FechaIniActividades"].ToString();
        static string PtoVta = System.Configuration.ConfigurationManager.AppSettings["PtoVta"].ToString();
        static string DomicilioComercial = System.Configuration.ConfigurationManager.AppSettings["DomicilioComercial"].ToString();
        string nombreImpresora = string.Empty;
        bool esC = false;
        int cantPage = 0;
        int acumCantPage = 0;
        int cnt = 0;
        int acumulado = 0;
        int inicio = 0;
        int fin = 0;

        HasarArgentina.ImpresoraFiscalRG3561 ocxHasar;



        private Font printFont;
        private Font printFontTitulo;
        private decimal nroVenta = 0;
        VentaBUS ruBus = new VentaBUS();
        Rubros.Business.RubroBusiness rubroBus = new Rubros.Business.RubroBusiness();
        ClienteBUS clieBus = new ClienteBUS();
        VentaEntity venta = new VentaEntity();
        PagoClieBUS pagoBus = new PagoClieBUS();
        ArticuloBUS artBus = new ArticuloBUS();
        Articulo.Entities.ArticuloEntity arti;
        private int perfilId = 0;
        private List<VtaArtEntity> vtaArticulo = new List<VtaArtEntity>();
        private List<VtaArtEntity> vtaArticuloOld = new List<VtaArtEntity>();
        NotaDeCreditoEntity notaCredito = new NotaDeCreditoEntity();
        private bool load = false;
        int idclie = -1;
        bool imprime = true;

        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            try
            {
                ComanderaAlternativa = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ComanderaAlternativa"]);
            }
            catch {}

            try {
               nombreImpresora = System.Configuration.ConfigurationManager.AppSettings["nombreComandera"].ToString();
            }
            catch { nombreImpresora = string.Empty; }

            try { esC = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["FacturaC"]); } catch { esC = false; }
            CheckForIllegalCrossThreadCalls = false;
            perfilId = new VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;
            //if (perfilId != 0)
            //{ 
            //    txtPrecioUnitario.Enabled = false;
            //}

                if (GlobalClass.ActionType > 1)
                {
                    GetVentaByID();
                    CompleteFiles();
                    //groupBox3.Enabled = false;
                    txtCodBarra.Enabled = false;
                    txtPrecioUnitario.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnElminar.Enabled = false;
                    pBoxArticulos.Enabled = false;
                    idclie = venta.IdClie;
                    if (idclie > 0)
                    {
                        ClienteEntity clie = new ClienteEntity();
                        clie = clieBus.getClienteID(idclie);
                        autoCompleteTxtCliente.Text = clie.RasoClie + "|" + clie.IdClie;
                    }
                    
                    if (GlobalClass.ActionType == 3) btnAceptar.Text = "Nota de crédito";
                    if (GlobalClass.ActionType == 2) btnAceptar.Text = "Salir";
                    btnNoFiscal.Text = "Imprimir";
                }
                else
                    txtCodBarra.Focus();

            //ConectarIF();                
                LlenarCboCliente();
                LlenarCboCondicion();
                LlenarCboTipoFactura();

            autocompleteClient();
        }

        void FrmVenta_Resize(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width / 2;
            groupBox3.Width = this.Width / 2;
            groupBox3.Left = this.Width - groupBox3.Width - 28;
            label21.Width = this.Width - 40;
            dtGView.Width = this.Width - 40;
            dtGView.Height = this.Height - groupBox1.Height - panelIzquierdo.Height - 145;
            panelIzquierdo.Top = this.Height - panelIzquierdo.Height - 80;
            panelDerecho.Top = this.Height - panelIzquierdo.Height - 80;
            panelDerecho.Left = this.Width - panelDerecho.Width - 30;

        }

        void FrmVenta_Activated(object sender, EventArgs e)
        {
            if (!load)
            {
                if (ActivateIF==1)
                    openPortHasar();
                txtCodBarra.Focus();
            }
            load = true;
            
        }

        void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            string step = "1";
            try
            {
                try { Logger.Log.LogInFile("cerrando pantalla venta" , "IF.log"); }
                catch { }
                Delay(1);
                step = "2";
                ocxHasar = null;
                step = "3";
                
                //ocxHasar.Cancelar();
            }
            catch (Exception ex) {
                try { Logger.Log.LogInFile("Error cerrando pantalla de venta ()"+(step) +" -->" + ex.Message, "IF.log"); }
                catch { }
            }
        }

        private void autocompleteClient()
        {
            // create the list to use as the custom source.            
            this.autoCompleteTxtCliente.AutoCompleteList = clieBus.ClienteGetCombo_DT();
            this.autoCompleteTxtCliente.aux = groupBox1.Width + autoCompleteTxtCliente.Left - 30;
        }


        private void openPortHasar()
        {
            try
            {
                try { Logger.Log.LogInFile("Conectando..","IF.log"); }
                catch { }

                try { Logger.Log.LogInFile("IP: " + IpHasar + " - Puerto: " + IpPuertoHasar, "IF.log"); }
                catch { }
                ocxHasar = new HasarArgentina.ImpresoraFiscalRG3561();
                ocxHasar.Conectar(IpHasar, IpPuertoHasar);
                try { Logger.Log.LogInFile("Conectado con éxito!!", "IF.log"); }
                catch { }
                Diagnostico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error conectando impresora fiscal HASAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

             
        private void Diagnostico()
        {

            string strTemp = string.Empty;
            if (ActivateIF==1)
                try
                {
                    //try { Logger.Log.LogInFile("Diagnostico..", "IF.log"); }
                    //catch { }
                    HasarArgentina.RespuestaConsultarEstado r = new RespuestaConsultarEstado();
                    r= ocxHasar.ConsultarEstado();
                    //try { Logger.Log.LogInFile("Rta..", "IF.log"); }
                    //catch { }
                    strTemp = "Estado Interno: " + r.EstadoInterno.ToString() + "|Nº Ult. Ticket: " + r.NumeroUltimoComprobante.ToString();
                    lblStatus.Text = strTemp;
                }
                catch (Exception ex)
                {
                    try { Logger.Log.LogInFile("Error Diagnostico.." + ex.Message, "IF.log"); }
                    catch { }
                    //MessageBox.Show(ex.Message, "Error obteniendo Diagnostico");
                }

        }

        private void obtenerArticulo()
        {
            try
            {
                if (GlobalClass.artiGlobal != null)
                {
                    lblArticulo.Text = GlobalClass.artiGlobal.DescArti.ToString();
                    txtCodBarra.Text = GlobalClass.artiGlobal.CoBaArti.ToString();
                    txtIdArticulo.Text = GlobalClass.artiGlobal.IDArti.ToString();
                    txtPrecioUnitario.Text = GlobalClass.artiGlobal.SugeArti.ToString();
                    txtCantidad.Text = "1";
                    //object sender = new object();
                    //EventArgs e = new EventArgs();
                    //txtCodBarra_LostFocus(sender,e);
                    BuscarArticulo(0);
                    agregarArticulo();
                }
            }
            catch
            {
            }
            finally
            {
                GlobalClass.locaGlobal = null;
                GlobalClass.clieGlobal = null;
            }
        }

        private void LlenarCboCliente()
        {
            if (clieBus.LlenarComboCliente(this.cboCliente) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                //this.cboCliente.SelectedValue = Ety.CobradorCHQ;
                cboCliente.SelectedIndex = 0;
            else
                cboCliente.SelectedIndex = 0;

        }

        private void LlenarCboCondicion()
        {
            if (pagoBus.LlenarComboCondicion(this.cboCondicion,1) == -1)
                this.Close();

            if (GlobalClass.ActionType != 1)
                cboCondicion.SelectedValue = venta.TipoPagoVta;


        }

        private void LlenarCboTipoFactura()
        {
            if (ruBus.LlenarComboTipoFactura(this.cboTipoFact,facturaElectronica) == -1)
                this.Close();

            //if (GlobalClass.ActionType != 1)
            //    cboTipoFact.SelectedValue = venta.ti;
            if (facturaElectronica)
            {
                if (esC)
                    cboTipoFact.SelectedValue = 5;
                else
                    cboTipoFact.SelectedValue = 4;
            }                
            else
                cboTipoFact.SelectedValue =2;

        }

        void FrmVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.F6)
            {
                GlobalClass.artiGlobal = null;
                GlobalClass.LastActionType = GlobalClass.ActionType;
                FrmArticuloList frm = new FrmArticuloList();
                frm.ShowDialog();
                GlobalClass.ActionType = GlobalClass.LastActionType;
                obtenerArticulo();


            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F1)
            {
                btnAceptar_Click(sender, e);
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F5)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F12)
            {
                btnNoFiscal_Click(sender, e);
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F8)
            {
                imprime = false;
                btnNoFiscal_Click(sender, e);
            }
        }

        
        void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //this.txtCantidad.Focus();
                //btnAgregar_Click(sender, e);                
                if (!string.IsNullOrEmpty(txtCodBarra.Text) && txtCodBarra.Text != "0")
                {
                    txtCodBarra.Text = txtCodBarra.Text.Replace("'","") ;
                    BuscarArticulo(1);
                    agregarArticulo();
                }
                e.Handled = true;
            }
        }

        void txtCodBarra_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == System.Windows.Forms.Keys.F6)
            //{
            //    FrmArticuloList frm = new FrmArticuloList();
            //    frm.ShowDialog();
            //    obtenerArticulo();
            //    agregarArticulo();
            //}
            //else if (e.KeyCode == System.Windows.Forms.Keys.F1)
            //{
            //    btnAceptar_Click(sender,e);
            //}
            //else if (e.KeyCode == System.Windows.Forms.Keys.F5)
            //{
            //    btnCancelar_Click(sender, e);
            //}
            //else if (e.KeyCode == System.Windows.Forms.Keys.F12)
            //{
            //    btnNoFiscal_Click(sender, e);
            //}
            if (e.KeyValue == 38)
            { txtCantidad.Focus(); }
            else if (e.KeyValue == 40)
            { txtPrecioUnitario.Focus(); }


        }

        void txtCodBarra_LostFocus(object sender, EventArgs e)
        {
            txtCodBarra.BackColor = System.Drawing.Color.White;
            txtCodBarra.ForeColor = System.Drawing.Color.Black;

            if (!string.IsNullOrEmpty(txtCodBarra.Text) && txtCodBarra.Text!="0")  BuscarArticulo(1);
        }

        void txtCodBarra_GotFocus(object sender, EventArgs e)
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "F6 -> Para ver listado de artículos";
            txtCodBarra.SelectionStart = 0;
            txtCodBarra.SelectionLength = txtCodBarra.Text.Length;
            txtCodBarra.BackColor = System.Drawing.Color.Red;
            txtCodBarra.ForeColor = System.Drawing.Color.White;
        }

        void txtCodBarra_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "F6 -> Para ver listado de artículo";
            txtCodBarra.SelectionStart = 0;
            txtCodBarra.SelectionLength = txtCodBarra.Text.Length;
        }        


        void txtPrecioUnitario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 38)
            { txtCodBarra.Focus(); }
            else if (e.KeyValue == 40)
            { txtCantidad.Focus(); }

        }

        void txtPrecioUnitario_LostFocus(object sender, EventArgs e)
        {
            txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            txtPrecioUnitario.ForeColor = System.Drawing.Color.Black;
        }

        void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
            { txtPrecioUnitario.Focus(); }
            else if (e.KeyValue == 40)
            { txtCodBarra.Focus(); }
        }

        void txtCantidad_LostFocus(object sender, EventArgs e)
        {
            txtCantidad.BackColor = System.Drawing.Color.White;
            txtCantidad.ForeColor = System.Drawing.Color.Black;
        }

        void txtCantidad_GotFocus(object sender, EventArgs e)
        {
            txtCantidad.SelectionStart = 0;
            txtCantidad.SelectionLength = txtCantidad.Text.Length;
            txtCantidad.BackColor = System.Drawing.Color.Red;
            txtCantidad.ForeColor = System.Drawing.Color.White;
        }

        void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectionStart = 0;
            txtCantidad.SelectionLength = txtCantidad.Text.Length;
        }

        void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //changeQuantity = true;
                agregarArticulo();
                e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }


        void txtPrecioUnitario_GotFocus(object sender, EventArgs e)
        {
            txtPrecioUnitario.SelectionStart = 0;
            txtPrecioUnitario.SelectionLength = txtPrecioUnitario.Text.Length;
            txtPrecioUnitario.BackColor = System.Drawing.Color.Red;
            txtPrecioUnitario.ForeColor = System.Drawing.Color.White;
        }

        void txtPrecioUnitario_Click(object sender, EventArgs e)
        {
            txtPrecioUnitario.SelectionStart = 0;
            txtPrecioUnitario.SelectionLength = txtPrecioUnitario.Text.Length;
        }

        void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //txtCantidad.Focus();
                agregarArticulo();
                e.Handled = true;
            }
            else if (e.KeyChar == 46)
            {
                e.KeyChar =Convert.ToChar(44);
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }

        void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {


        }

        void txtCliente_LostFocus(object sender, EventArgs e)
        {
            txtCliente.BackColor = System.Drawing.Color.White;
            txtCliente.ForeColor = System.Drawing.Color.Black;
            BuscarCliente();
        }

        void txtCliente_GotFocus(object sender, EventArgs e)
        {
            txtCliente.SelectionStart = 0;
            txtCliente.SelectionLength = txtCliente.Text.Length;
            txtCliente.BackColor = System.Drawing.Color.Red;
            txtCliente.ForeColor = System.Drawing.Color.White;
        }

        void txtCliente_Click(object sender, EventArgs e)
        {
            txtCliente.SelectionStart = 0;
            txtCliente.SelectionLength = txtCliente.Text.Length;
        }

        void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRetira.Focus();
                e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }

        void autoCompleteTxtCliente_Click(object sender, EventArgs e)
        {
            autoCompleteTxtCliente.SelectionStart = 0;
            autoCompleteTxtCliente.SelectionLength = autoCompleteTxtCliente.Text.Length;
        }

        void autoCompleteTxtCliente_GotFocus(object sender, EventArgs e)
        {
            autoCompleteTxtCliente.BackColor = System.Drawing.Color.White;
            autoCompleteTxtCliente.SelectionStart = 0;
            autoCompleteTxtCliente.SelectionLength = autoCompleteTxtCliente.Text.Length;
        }

        void autoCompleteTxtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodBarra.Focus();
                e.Handled = true;
            }
        }

        void autoCompleteTxtCliente_LostFocus(object sender, EventArgs e)
        {
            autoCompleteTxtCliente.BackColor = System.Drawing.Color.GhostWhite;
            autoCompleteTxtCliente.SelectionStart = 0;
            autoCompleteTxtCliente.SelectionLength = autoCompleteTxtCliente.Text.Length;
        }

        private void autoCompleteTxtCliente_TextChanged(object sender, EventArgs e)
        {
            cambioCliente();
        }

        private void cambioCliente()
        {

            idclie = -1;
            try
            {
                idclie = Convert.ToInt32(autoCompleteTxtCliente.Text.Split('|')[1]);
            }
            catch
            {
            }
        }

        private void BuscarCliente() {
            try { 
                if (string.IsNullOrEmpty(txtCliente.Text)) txtCliente.Text="0";
                
                lblCliente.Text= clieBus.getClienteID(Convert.ToInt32(txtCliente.Text)).RasoClie;
            }
            catch { lblCliente.Text = "Cliente inexistente!"; }
        }

        private void GetVentaByID()
        {
            try
            {
                venta= ruBus.getVentaID(GlobalClass.LongPrimaryKey);
                nroVenta = venta.NumeVta;
                VtaArtEntity[] vtaArt = new VtaArtBUS().getVtaArtByID(GlobalClass.LongPrimaryKey);
                foreach (VtaArtEntity ventaArticulo in vtaArt)
                {
                    ventaArticulo.PrecVear = Math.Round(ventaArticulo.PrecVear, 2);
                    vtaArticulo.Add(ventaArticulo);
                    vtaArticuloOld.Add(ventaArticulo);
                }
                lblTotal.Text = venta.TotaVta.ToString();
                ListarArticulos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Venta");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                //txtTotalRemito.Text = Math.Round(venta.TotaVta,2).ToString();
                object sender = new object();
                EventArgs e = new EventArgs();
                txtCodBarra.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Venta");
                this.Hide();
            }
            finally
            {
                txtCodBarra.Focus();
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            
            switch (GlobalClass.ActionType)
            {

                case 1: //Nuevo

                    Insert(false);
                    break;
                case 2: //Modificar
                    //Update();
                    this.Hide();
                    break;
                case 3: //Nota de crédito  
                    NotadeCredito(false);
                    break;
                default:
                    MessageBox.Show("Opción Incorrecta");
                    break;
            }
            btnAceptar.Enabled = true;

        }

        private void pd_PrintPageEpson220(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                //ev.PageSettings.PaperSize.Height += 1000;
                //ev.PageSettings.PaperSize = new PaperSize("Custom", 500, 2000);
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();

                string lineaBlanco = ".";
                //ENCABEZADO
                ev.Graphics.DrawString("PRESUPUESTO", printFontTitulo, Brushes.Black, 80, 10, new StringFormat());
                ev.Graphics.DrawString("XXXXX XXXXX XXXXX", printFont, Brushes.Black, 5, 40, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: 30-99999999-5", printFont, Brushes.Black, 5, 60, new StringFormat());
                ev.Graphics.DrawString("I.B.:", printFont, Brushes.Black, 5, 75, new StringFormat());
                ev.Graphics.DrawString("IVA RESPONSABLE INCRIPTO", printFont, Brushes.Black, 5, 90, new StringFormat());
                ev.Graphics.DrawString("A CONSUMIDOR FINAL", printFont, Brushes.Black, 5, 105, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 5, 120, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm:ss"), printFont, Brushes.Black, 150, 120, new StringFormat());
                if (!string.IsNullOrEmpty(autoCompleteTxtCliente.Text)) {
                    ev.Graphics.DrawString("CLIENTE: (" + autoCompleteTxtCliente.Text.Split('|')[0] + ") " + lblCliente.Text.Trim() , printFont, Brushes.Black, 5, 135, new StringFormat());
                }


                //ITEMS
                int line = 145;
                int x =1;
                inicio++;
                //Logger.Log.LogInFile("inicio: " + inicio + " - fin: " + fin , "Borrar");
                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    
                    if (x >= inicio && x <= fin)
                    {
                        //Logger.Log.LogInFile(" x: " + x, "Borrar");
                        //Logger.Log.LogInFile("PRecio: " + vtaArt.PrecVear.ToString("0.00"), "Borrar");
                        ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 5, line, new StringFormat());
                        ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")" + (vtaArt.PorcDtoVear > 0 ? " % Dto: " + (Convert.ToInt32(vtaArt.PorcDtoVear)).ToString() : ""), printFont, Brushes.Black, 150, line, new StringFormat());

                        line = line + 15;
                        ev.Graphics.DrawString((vtaArt.DescArti.Length > 30 ? vtaArt.DescArti.Substring(0, 30) : vtaArt.DescArti), printFont, Brushes.Black, 5, line, new StringFormat());
                        ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 220, line, new StringFormat());
                        line = line + 15;
                        //if (line > 1100)
                        //ev.PageSettings.PaperSize.Height += 1000;
                    }
                    x++;
                }

                //TOTAL
                line += 15;
                ev.Graphics.DrawString("TOTAL", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFont, Brushes.Black, 220, line, new StringFormat());
                line = line + 20;
                //PIE DE PAGINA
                ev.Graphics.DrawString("Efectivo", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFont, Brushes.Black, 220, line, new StringFormat());
                line = line + 15;
                ev.Graphics.DrawString("CAMBIO", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString("0,00", printFont, Brushes.Black, 220, line, new StringFormat());
                line += 15;
                ev.Graphics.DrawString("Pagina " + acumCantPage.ToString() + " de " + (cantPage + 1).ToString(), printFontTitulo, Brushes.Black, 5, line, new StringFormat());
                line = line + 15;
                //line = line + 30;
                //ev.Graphics.DrawString("At al consumidor Pcia B.A. 0800-222-9042", printFont, Brushes.Black, 5, line, new StringFormat());
                //line = line + 15;
                //ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 5, line, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }

        private void pd_PrintAlternativa(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                //ev.PageSettings.PaperSize.Height += 1000;
                //ev.PageSettings.PaperSize = new PaperSize("Custom", 500, 2000);
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();

                string lineaBlanco = ".";
                //ENCABEZADO
                ev.Graphics.DrawString("PRESUPUESTO", printFontTitulo, Brushes.Black, 40, 10, new StringFormat());
                ev.Graphics.DrawString("XXXXX XXXXX XXXXX", printFont, Brushes.Black, 5, 40, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: 30-99999999-5", printFont, Brushes.Black, 5, 60, new StringFormat());
                ev.Graphics.DrawString("I.B.:", printFont, Brushes.Black, 5, 75, new StringFormat());
                ev.Graphics.DrawString("IVA RESPONSABLE INCRIPTO", printFont, Brushes.Black, 5, 90, new StringFormat());
                ev.Graphics.DrawString("A CONSUMIDOR FINAL", printFont, Brushes.Black, 5, 105, new StringFormat());
                ev.Graphics.DrawString("Fecha: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 5, 120, new StringFormat());
                ev.Graphics.DrawString("Hora: " + System.DateTime.Now.ToString("hh:mm:ss"), printFont, Brushes.Black, 110, 120, new StringFormat());
                if (!string.IsNullOrEmpty(autoCompleteTxtCliente.Text))
                {
                    ev.Graphics.DrawString("CLIENTE: (" + autoCompleteTxtCliente.Text.Split('|')[0] + ") " + lblCliente.Text.Trim(), printFont, Brushes.Black, 5, 135, new StringFormat());
                }


                //ITEMS
                int line = 145;
                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 5, line, new StringFormat());
                    ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")" + (vtaArt.PorcDtoVear > 0 ? " % Dto: " + (Convert.ToInt32(vtaArt.PorcDtoVear)).ToString() : ""), printFont, Brushes.Black, 115, line, new StringFormat());

                    line = line + 15;
                    ev.Graphics.DrawString((vtaArt.DescArti.Length > 22 ? vtaArt.DescArti.Substring(0, 22) : vtaArt.DescArti), printFont, Brushes.Black, 5, line, new StringFormat());
                    ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 147, line, new StringFormat());
                    line = line + 15;
                    //if (line > 1100)
                    //ev.PageSettings.PaperSize.Height += 1000;
                }

                //TOTAL
                line += 15;
                ev.Graphics.DrawString("TOTAL", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFont, Brushes.Black, 147, line, new StringFormat());
                line = line + 20;
                //PIE DE PAGINA
                ev.Graphics.DrawString("Efectivo", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFont, Brushes.Black, 147, line, new StringFormat());
                line = line + 15;
                ev.Graphics.DrawString("CAMBIO", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString("0,00", printFont, Brushes.Black, 147, line, new StringFormat());
                line = line + 15;
                //line = line + 30;
                //ev.Graphics.DrawString("At al consumidor Pcia B.A. 0800-222-9042", printFont, Brushes.Black, 5, line, new StringFormat());
                line = line + 15;
                ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 5, line, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
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
                //ev.PageSettings.PaperSize.Height += 1000;
                //ev.PageSettings.PaperSize = new PaperSize("Custom", 500, 2000);
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

                string lineaBlanco = ".";
                //ENCABEZADO
                ev.Graphics.DrawString("PRESUPUESTO", printFontTitulo, Brushes.Black, 160, 10, new StringFormat());
                ev.Graphics.DrawString("XXXXX XXXXX XXXXX", printFont, Brushes.Black, 5, 40, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: 30-99999999-5", printFont, Brushes.Black, 5, 70, new StringFormat());
                ev.Graphics.DrawString("I.B.:", printFont, Brushes.Black, 5, 90, new StringFormat());
                ev.Graphics.DrawString("IVA RESPONSABLE INCRIPTO", printFont, Brushes.Black, 5, 110, new StringFormat());
                ev.Graphics.DrawString("A CONSUMIDOR FINAL", printFont, Brushes.Black, 5, 130, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 5, 150, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm:ss"), printFont, Brushes.Black, 190, 150, new StringFormat());

                
                //ITEMS
                int line = 170;
                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 5, line, new StringFormat());
                    ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")", printFont, Brushes.Black, 190, line, new StringFormat()); 

                    line = line + 20;
                    ev.Graphics.DrawString((vtaArt.DescArti.Length>30?vtaArt.DescArti.Substring(0,30):vtaArt.DescArti) , printFont, Brushes.Black, 5, line, new StringFormat());
                    ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 350, line, new StringFormat());
                    line = line + 20;
                    //if (line > 1100)
                        //ev.PageSettings.PaperSize.Height += 1000;
                }

                //TOTAL
                line += 10;
                ev.Graphics.DrawString("TOTAL", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFont, Brushes.Black, 350, line, new StringFormat());
                line = line + 30;
                //PIE DE PAGINA
                ev.Graphics.DrawString("Efectivo", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFont, Brushes.Black, 350, line, new StringFormat());
                line = line + 20;
                ev.Graphics.DrawString("CAMBIO", printFont, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString("0,00", printFont, Brushes.Black, 350, line, new StringFormat());
                line = line + 30;
                //ev.Graphics.DrawString("At al consumidor Pcia B.A. 0800-222-9042", printFont, Brushes.Black, 5, line, new StringFormat());
                line = line + 30;
                ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 5, line+140, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }

        private void ImprimirNoFiscal(VentaEntity vta)
        {
            try
            {
                int i = 0;
                cantPage = vtaArticulo.Count / 30;
                acumCantPage = 1;

                while (i <= cantPage)
                {
                    inicio = i * 30;
                    fin = (cantPage == 0 ? vtaArticulo.Count : (vtaArticulo.Count > inicio + 30 ? inicio + 30 : vtaArticulo.Count));

                    if (ComanderaAlternativa)
                    {
                        //System.Drawing.Printing.PaperSize paperSize = new PaperSize("Custom", 500, 2000);
                        venta = vta;
                        //printFontTitulo = new Font("Arial", 9);                        
                        //printFontTitulo = new Font(FontFamily.GenericMonospace, 9);
                        printFontTitulo = new Font("MonospaceTypewriter", 8);
                        //printFont = new Font("Arial", 8);
                        //printFont = new Font(FontFamily.GenericMonospace, 8);
                        printFont = new Font("MonospaceTypewriter", 7);
                        PrintDocument pd = new PrintDocument();
                        //pd.DefaultPageSettings.PaperSize = paperSize;
                        //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        //if (!string.IsNullOrEmpty(nombreImpresora))
                        //    pd.PrinterSettings.PrinterName = nombreImpresora;

                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintAlternativa);
                        pd.Print();
                    }
                    else
                    {
                        //System.Drawing.Printing.PaperSize paperSize = new PaperSize("Custom", 500, 2000);
                        venta = vta;
                        printFontTitulo = new Font("MonospaceTypewriter", 8);
                        printFont = new Font("MonospaceTypewriter", 7);
                        PrintDocument pd = new PrintDocument();
                        //if (!string.IsNullOrEmpty(nombreImpresora))
                        //pd.DefaultPageSettings.PaperSize = paperSize;
                        //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageEpson220);
                        pd.Print();

                    }

                    i++;
                    acumCantPage++;
                }


            }
            catch (Exception ex)
            {
                //respuestas();
                MessageBox.Show(ex.Message);
            }
        }

        private int FacturaA()
        {
            Int32 n = 0;                    // Para mostrar números de comprobantes
            decimal monto = 0;                // Para mostrar montos
            int ret = 0;

            double cantidadArt = 0;
            double montoArt = 0;
            double alicuotaIva = 0;
            double impuestosInternosArt = 0;
            double magnitudImpuestoInterno = 0;
            string art = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(autoCompleteTxtCliente.Text)) throw new Exception("Debe Seleccionar un cliente");
                ClienteEntity cliente = new ClienteEntity();
                cliente = new ClienteBUS().getClienteID(idclie);
                if (cliente == null)
                {

                    MessageBox.Show("Debe Seleccionar un Cliente del Cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;

                }
                else if (string.IsNullOrEmpty(cliente.CuitClie))
                {
                    MessageBox.Show("Debe Ingresar el Nro de Cuit/Cuil al cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;
                }
                else if (cliente.CuitClie.Length != 11)
                {
                    MessageBox.Show("Debe Ingresar un Nro de Cuit/Cuil Correcto (numérico de 11 dígitos)", "Cuit/Cuil Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;
                }
                else if (string.IsNullOrEmpty(cliente.DireClie))
                {
                    MessageBox.Show("Debe Ingresar el Domicilio del cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;
                }


                RespuestaAbrirDocumento respAbrir = new RespuestaAbrirDocumento();
                try
                {
                    try { Logger.Log.LogInFile("Comienza Facturacion A", "IF.log"); }
                    catch { }

                    ocxHasar.CargarDatosCliente(cliente.RasoClie, cliente.CuitClie, TiposDeResponsabilidadesCliente.ResponsableInscripto, TiposDeDocumentoCliente.TipoCUIT, cliente.DireClie, "", "", "");
                    try { Logger.Log.LogInFile("DatosCliente A", "IF.log"); }
                    catch { }

                    respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.TiqueFacturaA);
                    try { Logger.Log.LogInFile("AbrirComprobanteFiscal A", "IF.log"); }
                    catch { }
                }
                catch (Exception exx)
                {
                    try { Logger.Log.LogInFile("Error iniciando Factura A --> " + exx.Message, "IF.log"); }
                    catch { }
                    openPortHasar();

                    try { Logger.Log.LogInFile("Comienza Facturacion A", "IF.log"); }
                    catch { }

                    ocxHasar.CargarDatosCliente(cliente.RasoClie, cliente.CuitClie, TiposDeResponsabilidadesCliente.ResponsableInscripto, TiposDeDocumentoCliente.TipoCUIT, cliente.DireClie, "", "", "");
                    try { Logger.Log.LogInFile("DatosCliente A", "IF.log"); }
                    catch { }

                    respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.TiqueFacturaA);
                    try { Logger.Log.LogInFile("AbrirComprobanteFiscal A", "IF.log"); }
                    catch { }
                }

                foreach (VtaArtEntity arti in vtaArticulo)
                {
                    cantidadArt = (double)(arti.CantVear);
                    montoArt = (double)arti.PrecVear / 1.21;
                    alicuotaIva = 21;//(double)(arti.IvaVear);
                    art = arti.DescArti.Trim().ToLower() + (arti.PorcDtoVear > 0 ? " % Dto: " + (Convert.ToInt32(arti.PorcDtoVear)).ToString() : "");
                    try
                    {
                        Logger.Log.LogInFile("Articulo --> " + art, "IF.log");
                        Logger.Log.LogInFile("cantidadArt A --> " + cantidadArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("PrecVear --> " + arti.PrecVear.ToString(), "IF.log");
                        Logger.Log.LogInFile("montoArt --> " + montoArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("ivaArt --> " + alicuotaIva.ToString(), "IF.log");
                    }
                    catch { }
                    ocxHasar.ImprimirItem(art, cantidadArt, montoArt, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, arti.ArtiVear.ToString(), "", UnidadesMedida.Unidad);
                    try
                    {
                        Logger.Log.LogInFile("hasarOCX.ImprimirItem --> OK", "IF.log");
                    }
                    catch { }
                }
                try { Logger.Log.LogInFile("comienza imprimir sutotal: ", "IF.log"); }
                catch { }

                try { Logger.Log.LogInFile("Cerrar Comprobante A:::", "IF.log"); }
                catch { }
                ocxHasar.CerrarDocumento();

                try
                {
                    try { Logger.Log.LogInFile("Obtiene nrocomp", "IF.log"); }
                    catch { }

                    RespuestaConsultarEstado res = new RespuestaConsultarEstado();
                    res = ocxHasar.ConsultarEstado();
                    n = res.NumeroUltimoComprobante;

                    try { Logger.Log.LogInFile("nrocomp --> " + n.ToString(), "IF.log"); }
                    catch { }

                }
                catch (Exception exn)
                {
                    try { Logger.Log.LogInFile("Error Obteniendo n --> " + exn.Message, "IF.log"); }
                    catch { }
                    n = 0;
                }

                try { Logger.Log.LogInFile("Nro. de Comprobante ::: TFA" + " ::: " + n.ToString(), "IF.log"); }
                catch { }

                ret = n;

                // Se cierra el puerto serie abierto con 'Comenzar()'...
                //hasarOCX.Finalizar();

            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("Error Imprimiendo Factura A --> " + ex.Message, "IF.log"); }
                catch { }
                MessageBox.Show("Error Imprimiendo Factura A --> " + ex.Message);
                ret = -1;
            }
            return ret;
        }

        private int NotaCreditoA()
        {
            Int32 n = 0;                    // Para mostrar números de comprobantes
            decimal monto = 0;                // Para mostrar montos
            int ret = 0;

            double cantidadArt = 0;
            double montoArt = 0;
            double alicuotaIva = 0;
            double impuestosInternosArt = 0;
            double magnitudImpuestoInterno = 0;
            string art = string.Empty;
            try
            {

                ClienteEntity cliente = new ClienteEntity();
                cliente = new ClienteBUS().getClienteID(venta.IdClie);
                if (cliente == null)
                {

                    MessageBox.Show("Debe Seleccionar un Cliente del Cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;

                }
                else if (string.IsNullOrEmpty(cliente.CuitClie))
                {
                    MessageBox.Show("Debe Ingresar el Nro de Cuit/Cuil al cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;
                }
                else if (cliente.CuitClie.Length != 11)
                {
                    MessageBox.Show("Debe Ingresar un Nro de Cuit/Cuil Correcto (numérico de 11 dígitos)", "Cuit/Cuil Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;
                }
                else if (string.IsNullOrEmpty(cliente.DireClie))
                {
                    MessageBox.Show("Debe Ingresar el Domicilio del cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    autoCompleteTxtCliente.Focus();
                    return -1;
                }


                RespuestaAbrirDocumento respAbrir = new RespuestaAbrirDocumento();
                try
                {
                    try { Logger.Log.LogInFile("Comienza NOTA DE CREDITO A", "IF.log"); }
                    catch { }

                    ocxHasar.CargarDatosCliente(cliente.RasoClie, cliente.CuitClie, TiposDeResponsabilidadesCliente.ResponsableInscripto, TiposDeDocumentoCliente.TipoCUIT, cliente.DireClie, "", "", "");
                    try { Logger.Log.LogInFile("DatosCliente A", "IF.log"); }
                    catch { }

                    respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.TiqueNotaCreditoA);
                    try { Logger.Log.LogInFile("AbrirComprobanteFiscal A", "IF.log"); }
                    catch { }
                }
                catch (Exception exx)
                {
                    try { Logger.Log.LogInFile("Error iniciando NOTA DE CREDITO A --> " + exx.Message, "IF.log"); }
                    catch { }
                    openPortHasar();

                    try { Logger.Log.LogInFile("NOTA DE CREDITO A", "IF.log"); }
                    catch { }

                    ocxHasar.CargarDatosCliente(cliente.RasoClie, cliente.CuitClie, TiposDeResponsabilidadesCliente.ResponsableInscripto, TiposDeDocumentoCliente.TipoCUIT, cliente.DireClie, "", "", "");
                    try { Logger.Log.LogInFile("DatosCliente A", "IF.log"); }
                    catch { }

                    respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.TiqueNotaCreditoA);
                    try { Logger.Log.LogInFile("AbrirComprobanteFiscal A", "IF.log"); }
                    catch { }
                }

                foreach (VtaArtEntity arti in vtaArticulo)
                {
                    cantidadArt = (double)(arti.CantVear);
                    montoArt = (double)arti.PrecVear / 1.21;
                    alicuotaIva = (double)(arti.IvaVear);
                    art = arti.DescArti.Trim().ToLower();
                    try
                    {
                        Logger.Log.LogInFile("Articulo --> " + art, "IF.log");
                        Logger.Log.LogInFile("cantidadArt A --> " + cantidadArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("PrecVear --> " + arti.PrecVear.ToString(), "IF.log");
                        Logger.Log.LogInFile("montoArt --> " + montoArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("ivaArt --> " + alicuotaIva.ToString(), "IF.log");
                    }
                    catch { }
                    ocxHasar.ImprimirItem(art, cantidadArt, montoArt, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, arti.ArtiVear.ToString(), "", UnidadesMedida.Unidad);
                    try
                    {
                        Logger.Log.LogInFile("hasarOCX.ImprimirItem --> OK", "IF.log");
                    }
                    catch { }
                }
                try { Logger.Log.LogInFile("comienza imprimir sutotal: ", "IF.log"); }
                catch { }

                try { Logger.Log.LogInFile("Cerrar Comprobante A:::", "IF.log"); }
                catch { }
                ocxHasar.CerrarDocumento();

                try
                {
                    try { Logger.Log.LogInFile("Obtiene nrocomp", "IF.log"); }
                    catch { }

                    RespuestaConsultarEstado res = new RespuestaConsultarEstado();
                    res = ocxHasar.ConsultarEstado();
                    n = res.NumeroUltimoComprobante;

                    try { Logger.Log.LogInFile("nrocomp --> " + n.ToString(), "IF.log"); }
                    catch { }

                }
                catch (Exception exn)
                {
                    try { Logger.Log.LogInFile("Error Obteniendo n --> " + exn.Message, "IF.log"); }
                    catch { }
                    n = 0;
                }

                try { Logger.Log.LogInFile("Nro. de Comprobante ::: TFA" + " ::: " + n.ToString(), "IF.log"); }
                catch { }

                ret = n;

                // Se cierra el puerto serie abierto con 'Comenzar()'...
                //hasarOCX.Finalizar();

            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("Error Imprimiendo Factura A --> " + ex.Message, "IF.log"); }
                catch { }
                MessageBox.Show("Error Imprimiendo Factura A --> " + ex.Message);
                ret = -1;
            }
            return ret;
        }

        private int FacturaB()
        {

            Int32 n;                    // Para mostrar números de comprobantes
            decimal monto = 0;                // Para mostrar montos
            int ret = 0;

            object nrocomp;             // Argumento de salida CerrarComprobanteFiscal() y CerrarDNFH()

            object items;               // Argumento de salida Subtotal()
            object ventas;              // Argumento de salida Subtotal(), ReporteX(), ReporteZ()
            object iva;                 // Argumento de salida Subtotal()
            object pagado;              // Argumento de salida Subtotal()
            object ivanoi;              // Argumento de salida Subtotal()
            object impint;              // Argumento de salida Subtotal()
            object Copias = 1;
            double cantidadArt = 0;
            double montoArt = 0;
            double alicuotaIva = 0;
            double impuestosInternosArt = 0;
            string art = string.Empty;
            string cuit = string.Empty;
            string domicilio = string.Empty;
            string razonSocial = string.Empty;
            double magnitudImpuestoInterno = 0;
            try
            {
                if (idclie != -1)
                {
                    ClienteEntity cliente = new ClienteEntity();
                    cliente = new ClienteBUS().getClienteID(idclie);
                    if (cliente == null)
                    {

                        MessageBox.Show("Debe Seleccionar un Cliente del Cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;

                    }
                    else if (string.IsNullOrEmpty(cliente.CuitClie))
                    {
                        MessageBox.Show("Debe Ingresar el Nro de Cuit/Cuil al cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;
                    }
                    else if (cliente.CuitClie.Length != 11)
                    {
                        MessageBox.Show("Debe Ingresar un Nro de Cuit/Cuil Correcto (numérico de 11 dígitos)", "Cuit/Cuil Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;
                    }
                    else if (string.IsNullOrEmpty(cliente.DireClie))
                    {
                        MessageBox.Show("Debe Ingresar el Domicilio del cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;
                    }

                    razonSocial = cliente.RasoClie;
                    cuit = cliente.CuitClie;
                    domicilio = cliente.DireClie;
                }
                else
                {
                    razonSocial = "Consumidor Final";
                    cuit = "99999999995";
                    domicilio = "-";
                }


                try { Logger.Log.LogInFile("Comienza Facturacion B", "IF.log"); }
                catch { }

                RespuestaAbrirDocumento respAbrir = new RespuestaAbrirDocumento();

                try
                {
                    //CONSUMIDOR FINAL  
                    ocxHasar.CargarDatosCliente(razonSocial, cuit, (cuit=="27348379149" || cuit== "33999242109" ? TiposDeResponsabilidadesCliente.ResponsableExento: TiposDeResponsabilidadesCliente.Monotributo), TiposDeDocumentoCliente.TipoCUIT, domicilio, "", "", "");

                }
                catch (Exception exx)
                {
                    try { Logger.Log.LogInFile("Error iniciando Factura B --> " + exx.Message, "IF.log"); }
                    catch { }
                    Delay(0.5);
                    try
                    {
                        ocxHasar.Cancelar();
                        ocxHasar.CerrarDocumento();
                    }
                    catch (Exception exCerrar)
                    {
                        try { Logger.Log.LogInFile("Error Cerrando documento B --> " + exCerrar.Message, "IF.log"); }
                        catch { }
                    }
                    
                    openPortHasar();

                    //CONSUMIDOR FINAL
                    ocxHasar.CargarDatosCliente(razonSocial, cuit, TiposDeResponsabilidadesCliente.Monotributo, TiposDeDocumentoCliente.TipoCUIT, domicilio, "", "", "");

                }

                try { Logger.Log.LogInFile("DatosCliente B", "IF.log"); }
                catch { }
                respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.TiqueFacturaB);
                try { Logger.Log.LogInFile("AbrirComprobanteFiscal B", "IF.log"); }
                catch { }
                //hasarOCX.ImprimirItem("Art. Vendido...", 1.0, 1.0, 21.0, 0.0);
                foreach (VtaArtEntity arti in vtaArticulo)
                {
                    cantidadArt = (double)(arti.CantVear);
                    montoArt = (double)arti.PrecVear / 1.21;
                    alicuotaIva = 21;//(double)(arti.IvaVear);
                    //art = arti.DescArti.Trim().ToLower();
                    art = arti.DescArti.Trim().ToLower() + (arti.PorcDtoVear > 0 ? " % Dto: " + (Convert.ToInt32(arti.PorcDtoVear)).ToString() : "");
                    //hasarOCX.ImprimirItem(arti.DescArti, 1.0, 1.0, 21.0, 0.0);
                    try
                    {
                        Logger.Log.LogInFile("Articulo --> " + art, "IF.log");
                        Logger.Log.LogInFile("cantidadArt B --> " + cantidadArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("PrecVear --> " + arti.PrecVear.ToString(), "IF.log");
                        Logger.Log.LogInFile("montoArt --> " + montoArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("ivaArt --> " + alicuotaIva.ToString(), "IF.log");
                    }
                    catch { }
                    ocxHasar.ImprimirItem(art, cantidadArt, montoArt, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, "7791234500001", "00001", UnidadesMedida.Unidad);
                    try
                    {
                        Logger.Log.LogInFile("hasarOCX.ImprimirItem --> OK", "IF.log");
                    }
                    catch { }
                }


                try { Logger.Log.LogInFile("Cerrar Comprobante B:::", "IF.log"); }
                catch { }
                ocxHasar.CerrarDocumento();
                Delay(0.5);
                try
                {
                    try { Logger.Log.LogInFile("Obtiene nrocomp", "IF.log"); }
                    catch { }

                    RespuestaConsultarEstado res = new RespuestaConsultarEstado();
                    res = ocxHasar.ConsultarEstado();
                    n = res.NumeroUltimoComprobante;

                    try { Logger.Log.LogInFile("nrocomp --> " + n.ToString(), "IF.log"); }
                    catch { }

                }
                catch (Exception exn)
                {
                    try { Logger.Log.LogInFile("Error Obteniendo n --> " + exn.Message, "IF.log"); }
                    catch { }
                    n = 0;
                }

                try { Logger.Log.LogInFile("Nro. de Comprobante ::: TFB" + " ::: " + n.ToString(), "IF.log"); }
                catch { }
                ret = n;
                // Se cierra el puerto serie abierto con 'Comenzar()'...
                //hasarOCX.Finalizar();
            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("Error Imprimiendo Factura B --> " + ex.Message, "IF.log"); }
                catch { }
                MessageBox.Show("Error Imprimiendo Factura B --> " + ex.Message);
                ret = -1;
            }
            return ret;
        }

        private int NotaCreditoB()
        {
            Int32 n;                    // Para mostrar números de comprobantes
            decimal monto = 0;                // Para mostrar montos
            int ret = 0;

            object nrocomp;             // Argumento de salida CerrarComprobanteFiscal() y CerrarDNFH()

            object items;               // Argumento de salida Subtotal()
            object ventas;              // Argumento de salida Subtotal(), ReporteX(), ReporteZ()
            object iva;                 // Argumento de salida Subtotal()
            object pagado;              // Argumento de salida Subtotal()
            object ivanoi;              // Argumento de salida Subtotal()
            object impint;              // Argumento de salida Subtotal()
            object Copias = 1;
            double cantidadArt = 0;
            double montoArt = 0;
            double alicuotaIva = 0;
            double impuestosInternosArt = 0;
            string art = string.Empty;
            string cuit = string.Empty;
            string domicilio = string.Empty;
            string razonSocial = string.Empty;
            double magnitudImpuestoInterno = 0;
            try
            {

                if (venta.IdClie > 0)
                {
                    ClienteEntity cliente = new ClienteEntity();
                    cliente = new ClienteBUS().getClienteID(venta.IdClie);
                    if (cliente == null)
                    {

                        MessageBox.Show("Debe Seleccionar un Cliente del Cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;

                    }
                    else if (string.IsNullOrEmpty(cliente.CuitClie))
                    {
                        MessageBox.Show("Debe Ingresar el Nro de Cuit/Cuil al cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;
                    }
                    else if (cliente.CuitClie.Length != 11)
                    {
                        MessageBox.Show("Debe Ingresar un Nro de Cuit/Cuil Correcto (numérico de 11 dígitos)", "Cuit/Cuil Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;
                    }
                    else if (string.IsNullOrEmpty(cliente.DireClie))
                    {
                        MessageBox.Show("Debe Ingresar el Domicilio del cliente", "Falta ingresar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        autoCompleteTxtCliente.Focus();
                        return -1;
                    }

                    razonSocial = cliente.RasoClie;
                    cuit = cliente.CuitClie;
                    domicilio = cliente.DireClie;
                }
                else
                {
                    razonSocial = "Consumidor Final";
                    cuit = "99999999995";
                    domicilio = "-";
                }


                try { Logger.Log.LogInFile("Comienza NOTA DE CREDITO B", "IF.log"); }
                catch { }

                RespuestaAbrirDocumento respAbrir = new RespuestaAbrirDocumento();

                try
                {
                    //CONSUMIDOR FINAL  
                    ocxHasar.CargarDatosCliente(razonSocial, cuit, TiposDeResponsabilidadesCliente.Monotributo, TiposDeDocumentoCliente.TipoCUIT, domicilio, "", "", "");

                }
                catch (Exception exx)
                {
                    try { Logger.Log.LogInFile("Error iniciando NOTA DE CREDITO B --> " + exx.Message, "IF.log"); }
                    catch { }
                    Delay(0.5);
                    openPortHasar();

                    //CONSUMIDOR FINAL
                    ocxHasar.CargarDatosCliente(razonSocial, cuit, TiposDeResponsabilidadesCliente.Monotributo, TiposDeDocumentoCliente.TipoCUIT, domicilio, "", "", "");

                }

                try { Logger.Log.LogInFile("DatosCliente B", "IF.log"); }
                catch { }
                respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.TiqueNotaCreditoB);
                try { Logger.Log.LogInFile("Abrir NOTA DE CREDITO B", "IF.log"); }
                catch { }
                //hasarOCX.ImprimirItem("Art. Vendido...", 1.0, 1.0, 21.0, 0.0);
                foreach (VtaArtEntity arti in vtaArticulo)
                {
                    cantidadArt = (double)(arti.CantVear);
                    montoArt = (double)arti.PrecVear / 1.21;
                    alicuotaIva = 21;//(double)(arti.IvaVear); ;
                    art = arti.DescArti.Trim().ToLower();
                    //hasarOCX.ImprimirItem(arti.DescArti, 1.0, 1.0, 21.0, 0.0);
                    try
                    {
                        Logger.Log.LogInFile("Articulo --> " + art, "IF.log");
                        Logger.Log.LogInFile("cantidadArt B --> " + cantidadArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("PrecVear --> " + arti.PrecVear.ToString(), "IF.log");
                        Logger.Log.LogInFile("montoArt --> " + montoArt.ToString(), "IF.log");
                        Logger.Log.LogInFile("ivaArt --> " + arti.IvaVear.ToString(), "IF.log");
                    }
                    catch { }
                    ocxHasar.ImprimirItem(art, cantidadArt, montoArt, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, "7791234500001", "00001", UnidadesMedida.Unidad);
                    try
                    {
                        Logger.Log.LogInFile("hasarOCX.ImprimirItem --> OK", "IF.log");
                    }
                    catch { }
                }


                try { Logger.Log.LogInFile("Cerrar Comprobante B:::", "IF.log"); }
                catch { }
                ocxHasar.CerrarDocumento();
                Delay(0.5);
                try
                {
                    try { Logger.Log.LogInFile("Obtiene nrocomp", "IF.log"); }
                    catch { }

                    RespuestaConsultarEstado res = new RespuestaConsultarEstado();
                    res = ocxHasar.ConsultarEstado();
                    n = res.NumeroUltimoComprobante;

                    try { Logger.Log.LogInFile("nrocomp --> " + n.ToString(), "IF.log"); }
                    catch { }

                }
                catch (Exception exn)
                {
                    try { Logger.Log.LogInFile("Error Obteniendo n --> " + exn.Message, "IF.log"); }
                    catch { }
                    n = 0;
                }

                try { Logger.Log.LogInFile("Nro. de Comprobante ::: TFB" + " ::: " + n.ToString(), "IF.log"); }
                catch { }
                ret = n;
                // Se cierra el puerto serie abierto con 'Comenzar()'...
                //hasarOCX.Finalizar();
            }
            catch (Exception ex)
            {
                try { Logger.Log.LogInFile("Error Imprimiendo Factura B --> " + ex.Message, "IF.log"); }
                catch { }
                MessageBox.Show("Error Imprimiendo Factura B --> " + ex.Message);
                ret = -1;
            }
            return ret;
        }

        private void  Insert(bool tipoVta)
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {

                    int clienteId = 0;
                    long nroTicket = 1;
                    string cae = string.Empty;
                    string fecVtoCae = string.Empty;
                    string barCodeName = string.Empty;
                    string retira = string.Empty;
                    short condicion = (short)Convert.ToInt32(cboCondicion.SelectedValue);
                    int tipoFact = Convert.ToInt32(cboTipoFact.SelectedValue);
                    bool avanza = true;
                    retira = txtRetira.Text.Trim();
                    if (idclie == -1 && (condicion == 2 || (tipoFact == 1 || tipoFact == 3)))
                    {
                        DialogResult dr = MessageBox.Show("Debe seleccionar un cliente cuando la condición de venta es CUENTA CORRIENTE o FACTURA A, ¿Desea enviar la venta a la cuenta corriente? ", "Venta", MessageBoxButtons.OKCancel);
                        //switch (dr)
                        //{
                        //    case DialogResult.OK:
                        //        //condicion = 2;
                        //        //retira = txtRetira.Text.Trim();
                        //        break;
                        //    default:
                        //        avanza = false;
                        //        break;
                        //}
                        MessageBox.Show("Debe seleccionar un cliente cuando la condición de venta es CUENTA CORRIENTE o FACTURA A, ¿Desea enviar la venta a la cuenta corriente? ", "Venta", MessageBoxButtons.OKCancel);
                        txtCliente.Focus();
                        avanza = false;
                    }
                    else avanza = true;

                    if (esC && tipoFact!=5)
                    {
                        tipoFact = 5;
                        cboTipoFact.SelectedValue = 5;
                    }

                    if (!avanza) return;

                    //if (condicion==2)
                    //{
                    //    retira = txtRetira.Text.Trim();
                    //    //if (Convert.ToInt32(cboCliente.SelectedValue) == -1 || cboCliente.SelectedValue == null)
                    //    //if (string.IsNullOrEmpty(txtCliente.Text) || lblCliente.Text == "Cliente inexistente!" || txtCliente.Text == "0")
                    //    if (idclie==-1)
                    //    {
                    //        MessageBox.Show("Debe seleccionar un Cliente válido", "Dato Incorrecto");
                    //        cboCliente.Focus();
                    //        return;
                    //    }

                    //}
                    clienteId = idclie;

                    

                    VentaEntity Ety = new VentaEntity();
                    Ety.TipoVta = tipoVta;
                    Ety.TotaVta = Convert.ToDouble(lblTotal.Text);
                    Ety.TipoPagoVta = condicion;
                    if (tipoVta)
                        Ety.LetraVta = "X";
                    else
                    {
                        if (tipoFact == 1)
                            Ety.LetraVta = "A";
                        else if (tipoFact == 2)
                            Ety.LetraVta = "B";
                        else if (tipoFact == 3)
                            Ety.LetraVta = "FEA";
                        else if (tipoFact == 4)
                            Ety.LetraVta = "FEB";
                        else
                            Ety.LetraVta = "FEC";
                    }


                    if (vtaArticulo.Count <= 0) throw new Exception("No hay productos cargados");
                    if (!tipoVta) //VENTA EN BLANCO
                    {

                        switch(tipoFact)
                        {
                            default:
                            case 1:
                                Ety.TicketFiscal = FacturaA();
                                break;
                            case 2:
                                Ety.TicketFiscal = FacturaB();
                                break;
                            case 3:
                            case 4:
                                #region FACTURA ELECTRÓNICA B Y A
                                try
                                {
                                    List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                                    AlicIvaEntity etyIva = new AlicIvaEntity();
                                    int idIVA = 0;
                                    double BaseImp21 = 0;
                                    double BaseImp0 = 0;
                                    double BaseImpReal = 0;
                                    double importe = 0;
                                    double impuestoInterno = 0;
                                    double IvaExento = 0;
                                    /*
                                    3 - 0
                                    4 - 10.5
                                    5 - 21
                                    6 - 27
                                    8 - 5
                                    9 - 2.5
                                    */
                                    ArticuloEntity arti = new ArticuloEntity();
                                    ImpuestoInternoEntity impuesto = new ImpuestoInternoEntity();
                                    double totalIva = 0;
                                    foreach (VtaArtEntity articulo in vtaArticulo)
                                    {
                                        arti = new ArticuloEntity();
                                        arti = artBus.getArticuloID(articulo.ArtiVear);
                                        if (arti.RubrArti == 3)
                                        {
                                            BaseImp0 +=  articulo.SubtotalVear;
                                            //IvaExento += 0;// articulo.SubtotalVear;
                                            IvaExento +=  articulo.SubtotalVear;
                                        }                                            
                                        else if (arti.RubrArti == 2)
                                        {
                                            impuesto = new ImpuestoInternoEntity();
                                            impuesto = getNetoImpuestoInterno((decimal)articulo.SubtotalVear);
                                            BaseImp21 += (double)(impuesto.Neto + impuesto.Neto * 0.21m);
                                            impuestoInterno += (double)impuesto.ImpuestoInterno;

                                        }
                                        else
                                            BaseImp21 += articulo.SubtotalVear;                                        

                                    }

                                    if (BaseImp21>0)
                                    {
                                        BaseImpReal = Math.Round(BaseImp21 / 1.21, 2);
                                        importe = Math.Round(BaseImp21 - (BaseImp21 / 1.21), 2);
                  
                                        idIVA = 5;

                                        etyIva.id = idIVA;
                                        etyIva.Importe = importe;
                                        etyIva.BaseImp = BaseImpReal;
                                        totalIva += importe;
 
                                        ivas.Add(etyIva);
                                        //Logger.Log.LogInFile("etyIva.id: " + etyIva.id, "borrarVta");
                                        //Logger.Log.LogInFile("etyIva.Importe: " + etyIva.Importe, "borrarVta");
                                        //Logger.Log.LogInFile("etyIva.BaseImp: " + etyIva.BaseImp, "borrarVta");
                                    }



                                    IvaExento = Math.Round(IvaExento, 2);
                                    impuestoInterno = Math.Round(impuestoInterno, 2);


                                    //Logger.Log.LogInFile("totalIva: " + totalIva, "borrarVta");
                                    //Logger.Log.LogInFile("impuestoInterno: " + impuestoInterno, "borrarVta");
                                    //Logger.Log.LogInFile("IvaExento: " + IvaExento, "borrarVta");
                                    //Logger.Log.LogInFile("neto: " + Math.Round((double)(Ety.TotaVta - totalIva - impuestoInterno-IvaExento), 2).ToString(), "borrarVta");
                                    

                                    //string cuitClie = "20222222223";
                                    string cuitClie = "0";

                                    if (tipoFact ==3 && idclie == -1)
                                    {
                                        throw new Exception("Debe Seleccionar un Cliente IVA Responsable Inscripto");
                                    }

                                    if (idclie != -1)
                                    {
                                        ClienteEntity clie = new ClienteEntity();
                                        clie = new ClienteBUS().getClienteID(idclie);
                                        cuitClie = clie.CuitClie;
                                        if (tipoFact == 3 && clie.CondIvaClie != 2)
                                            throw new Exception("El Cliente debe ser IVA Responsable Inscripto");

                                        if (tipoFact == 3 && clie.CuitClie.Length < 11)
                                            throw new Exception("CUIT " + clie.CuitClie + " Incorrecto");
                                    }

                                    if (produccion == 0)
                                    {
                                        //*******************************************************************************************
                                        //TESTING
                                        //*******************************************************************************************
                                        wsassSystem wasass = new wsassSystem(); //TESTING
                                        FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse(); //TESTING                                    
                                        res = wasass.FECAESolicitar(1, (tipoFact == 3 ? 1 : 6), 1, (cuitClie.Length >= 11 ? 80 : (cuitClie.Length==1?99:96)), long.Parse(cuitClie), (double)Ety.TotaVta, Math.Round((double)(Ety.TotaVta - totalIva), 2), totalIva, ivas, DateTime.Now, "PES", venta,impuestoInterno,IvaExento);

                                        if (res.FeCabResp.Resultado != "A")
                                        {
                                            nroTicket = -1;
                                            if (res.Errors != null)
                                            {
                                                MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                            }

                                        }
                                        else
                                        {
                                            nroTicket = res.FeDetResp[0].CbteDesde;
                                            cae = res.FeDetResp[0].CAE.ToString();
                                            fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                            Ety.CAEVta = cae;
                                            Ety.FechVtoCAEVta = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                            Ety.TicketFiscal = nroTicket;
                                            //11 Posiciones CUIT
                                            //02 Posiciones Código Comprobante
                                            //04 Posiciones Pto de Vta
                                            //14 Posiciones CAE
                                            //08 Posiciones Fecha Vto CAE
                                            char pad = '0';
                                            barCodeName = CUIT + "06" + PtoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                            //generarCodBarra(barCodeName);
                                            ImprimirFacturaElectronica(Ety);
                                        }
                                    }
                                    else
                                    {
                                        //*******************************************************************************************
                                        //PRODUCCION
                                        //*******************************************************************************************
                                        try { Logger.Log.LogInFile("Request FECAESolicitar", "IF.log"); }
                                        catch { }
                                        wsaaProdSystem wasass = new wsaaProdSystem(); // PRODUCCION
                                        FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse res = new FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse(); //PRODUCCION
                                        res = wasass.FECAESolicitar(1, (tipoFact == 3 ? 1 : 6), 1, (cuitClie.Length >= 11 ? 80 : (cuitClie.Length == 1 ? 99 : 96)), long.Parse(cuitClie), (double)Ety.TotaVta, Math.Round((double)(Ety.TotaVta - totalIva-impuestoInterno-IvaExento), 2), totalIva, ivas, DateTime.Now, "PES", venta, impuestoInterno, IvaExento);
                                        try { Logger.Log.LogInFile("Response FECAESolicitar --> " + res, "IF.log"); }
                                        catch { }


                                        if (res.FeCabResp.Resultado != "A")
                                        {
                                            nroTicket = -1;
                                            if (res.Errors != null)
                                            {
                                                MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                            }

                                        }
                                        else
                                        {
                                            nroTicket = res.FeDetResp[0].CbteDesde;
                                            cae = res.FeDetResp[0].CAE.ToString();
                                            fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                            Ety.CAEVta = cae;
                                            Ety.FechVtoCAEVta = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                            Ety.TicketFiscal = nroTicket;
                                            //11 Posiciones CUIT
                                            //02 Posiciones Código Comprobante
                                            //04 Posiciones Pto de Vta
                                            //14 Posiciones CAE
                                            //08 Posiciones Fecha Vto CAE
                                            char pad = '0';
                                            barCodeName = CUIT + "06" + PtoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                            //generarCodBarra(barCodeName);
                                            ImprimirFacturaElectronica(Ety);
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Error generando Factura Electrónica " + Ety.LetraVta + " --> " + ex.Message);
                                }
                                Ety.TicketFiscal = nroTicket;
                                break;
                            #endregion
                            case 5:
                                #region FACTURA ELECTRÓNICA C
                                try
                                {
                                    List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                                    AlicIvaEntity etyIva = new AlicIvaEntity();
                                    int idIVA = 0;
                                    double BaseImp = 0;
                                    double BaseImpReal = 0;
                                    double importe = 0;
                                    /*
                                    3 - 0
                                    4 - 10.5
                                    5 - 21
                                    6 - 27
                                    8 - 5
                                    9 - 2.5
                                    */


                                    string cuitClie = "99999995";


                                    if (produccion == 0)
                                    {
                                        //*******************************************************************************************
                                        //TESTING
                                        //*******************************************************************************************
                                        wsassSystem wasass = new wsassSystem(); //TESTING
                                        FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse(); //TESTING                                    
                                        res = wasass.FECAESolicitar(1, 11, 1,  96, long.Parse(cuitClie), (double)Ety.TotaVta, Math.Round((double)(Ety.TotaVta - etyIva.Importe), 2), etyIva.Importe, ivas, DateTime.Now, "PES", venta,0,0);

                                        if (res.FeCabResp.Resultado != "A")
                                        {
                                            nroTicket = -1;
                                            if (res.Errors != null)
                                            {
                                                MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                            }

                                        }
                                        else
                                        {
                                            nroTicket = res.FeDetResp[0].CbteDesde;
                                            cae = res.FeDetResp[0].CAE.ToString();
                                            fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                            Ety.CAEVta = cae;
                                            Ety.FechVtoCAEVta = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                            Ety.TicketFiscal = nroTicket;
                                            //11 Posiciones CUIT
                                            //02 Posiciones Código Comprobante
                                            //04 Posiciones Pto de Vta
                                            //14 Posiciones CAE
                                            //08 Posiciones Fecha Vto CAE
                                            char pad = '0';
                                            barCodeName = CUIT + "11" + PtoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                            //generarCodBarra(barCodeName);
                                            ImprimirFacturaElectronica(Ety);
                                        }
                                    }
                                    else
                                    {
                                        //*******************************************************************************************
                                        //PRODUCCION
                                        //*******************************************************************************************
                                        try { Logger.Log.LogInFile("Request FECAESolicitar", "IF.log"); }
                                        catch { }
                                        wsaaProdSystem wasass = new wsaaProdSystem(); // PRODUCCION
                                        FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse res = new FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse(); //PRODUCCION
                                        res = wasass.FECAESolicitar(1, 11, 1, 96, long.Parse(cuitClie), (double)Ety.TotaVta, Math.Round((double)(Ety.TotaVta - etyIva.Importe), 2), etyIva.Importe, ivas, DateTime.Now, "PES", venta,0,0);
                                        try { Logger.Log.LogInFile("Response FECAESolicitar --> " + res, "IF.log"); }
                                        catch { }


                                        if (res.FeCabResp.Resultado != "A")
                                        {
                                            nroTicket = -1;
                                            if (res.Errors != null)
                                            {
                                                MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                            }

                                        }
                                        else
                                        {
                                            nroTicket = res.FeDetResp[0].CbteDesde;
                                            cae = res.FeDetResp[0].CAE.ToString();
                                            fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                            Ety.CAEVta = cae;
                                            Ety.FechVtoCAEVta = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                            Ety.TicketFiscal = nroTicket;
                                            //11 Posiciones CUIT
                                            //02 Posiciones Código Comprobante
                                            //04 Posiciones Pto de Vta
                                            //14 Posiciones CAE
                                            //08 Posiciones Fecha Vto CAE
                                            char pad = '0';
                                            barCodeName = CUIT + "06" + PtoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                            //generarCodBarra(barCodeName);
                                            ImprimirFacturaElectronicaC(Ety);
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Error generando Factura Electrónica " + Ety.LetraVta + " --> " + ex.Message);
                                }
                                Ety.TicketFiscal = nroTicket;
                                break;
                                #endregion

                        }

                        //Ety.TicketFiscal = imprimirTicketFiscalHASAR(vtaArticulo); //NO EMITE TICKET C

                        try { Logger.Log.LogInFile("Ety.TicketFiscal: " + Ety.TicketFiscal.ToString() , "IF.log"); }
                        catch { }

                        if (Ety.TicketFiscal >= 0)
                        {
                            if (!checkBoxCalculadora.Checked)
                                nroVenta = ruBus.ProcesarVenta(vtaArticulo, Ety, GlobalClass.UserID,clienteId,retira);
                                //MessageBox.Show("Registro guardado con éxito");
                            this.ClearFiles();
                        }
                    }
                    else {
                        if (!checkBoxCalculadora.Checked)
                            nroVenta = ruBus.ProcesarVenta(vtaArticulo, Ety, GlobalClass.UserID,clienteId,retira);
                        //if (tipoVta) imprimirTicketNoFiscalHASAR(vtaArticulo);
                        if (tipoVta && imprime && checkBoxImprime.Checked) ImprimirNoFiscal(Ety);
                        //MessageBox.Show("Registro guardado con éxito");
                        this.ClearFiles();
                    }
                    imprime = true;
                    Diagnostico();

                }
                else {
                    MessageBox.Show("Debe seleccionar al menos un producto", "Info Venta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error grabando venta");
                try { Logger.Log.LogInFile("Insert Venta. Tipo Vta: "+tipoVta.ToString()+" --> " + ex.Message, "IF.log"); }
                catch { }
            }
        }

        private Ventas.Entities.ImpuestoInternoEntity getNetoImpuestoInterno(decimal total)
        {
            ImpuestoInternoEntity ii = new ImpuestoInternoEntity();

            try
            {
                decimal dummy = 0;
                ii.ImpuestoInterno = total * 0.7458m;
                dummy = total - ii.ImpuestoInterno;
                ii.Neto = dummy / 1.21m;
                ii.Iva = ii.Neto * 0.21m;
            }
            catch (Exception)
            {

                ii = null;
            }
            return ii;

        }

        private void Delay()
        {
            Application.DoEvents();
            Thread.Sleep((int)TimeSpan.FromSeconds(timeDelay).TotalMilliseconds);
            Application.DoEvents();                    

        }

        private void Delay(double second)
        {
            Application.DoEvents();
            Thread.Sleep((int)TimeSpan.FromSeconds(second).TotalMilliseconds);
            Application.DoEvents();

        }
        void FrmVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            //axEpsonFPHostControl1.Dispose();

        }                      

        private void Update()
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {
                    //VentaEntity Ety = new VentaEntity();
                    //Ety.NumeVta = venta.NumeVta;
                    //Ety.ClieVta = Convert.ToInt32(txtCliente.Text);
                    //Ety.FechVta = dtpFecha.Value;
                    //Ety.LocaVta = Convert.ToInt32(txtLocalidad.Text);
                    //Ety.TotaVta = Convert.ToDouble(txtTotalRemito.Text);
                    //ruBus.ModificarVenta(vtaArticulo,vtaArticuloOld, Ety, GlobalClass.UserID);
                    //MessageBox.Show("Registro Modificado con éxito");
                    //GenerarReporte();
                    //this.Hide();
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
            //if (txtDesc.Text == string.Empty)
            //{
            //    MessageBox.Show("El campo Descripción no puede estar vacio", "Dato Incorrecto");
            //    ret = 1;
            //    txtDesc.Focus();
            //}

            return ret;

        }

        private void ClearFiles()
        {
            vtaArticulo.Clear();
            //txtLocalidad.Text = string.Empty;

            txtCodBarra.Text = string.Empty;
            txtPrecioUnitario.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtRecibido.Text = "0";
            lblArticulo.Text = string.Empty;
            txtIdArticulo.Text = string.Empty;
            cboCondicion.SelectedValue = 1;
            txtRetira.Text = string.Empty;
            autoCompleteTxtCliente.Text = string.Empty;
            idclie = -1;
            //lblTotal.Text = "0";
            ListarArticulos();
            //groupBox3.Enabled = false;
            //groupBox1.Enabled = true;
            checkBoxCalculadora.Checked = false;
            if (facturaElectronica)
                cboTipoFact.SelectedValue = 4;
            else
                cboTipoFact.SelectedValue = 2;
            txtCodBarra.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void pBoxArticulos_Click(object sender, EventArgs e)
        {
            GlobalClass.artiGlobal = null;
            GlobalClass.LastActionType = GlobalClass.ActionType;
            FrmArticuloList frm = new FrmArticuloList();
            frm.ShowDialog();
            GlobalClass.ActionType = GlobalClass.LastActionType;
            obtenerArticulo();

        }

        private void BuscarArticulo(int tipo)
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = "";
            try
            {
                //lblArticulo.Text = new Articulo.Business.ArticuloBUS().getArticuloID(Convert.ToInt32(txtIdArticulo.Text)).DescArti;
                if (tipo==0)
                    arti = new Articulo.Business.ArticuloBUS().getArticuloID(Convert.ToInt32(txtIdArticulo.Text));
                    //arti = new Articulo.Business.ArticuloBUS().getByCodiAndRubro_DT(GlobalClass.artiGlobal.RubrArti, GlobalClass.artiGlobal.CodiArti);
                else if (tipo==1)
                {
                    arti = new Articulo.Business.ArticuloBUS().getArticuloPorCodBarra(txtCodBarra.Text);
                }
                else
                {
                    arti = new Articulo.Business.ArticuloBUS().getArticuloID(Convert.ToInt32(txtIdArticulo.Text));
                }

                porcDtoArt = 0;
                try {
                    porcDtoArt = Math.Round(rubroBus.getRubroID(arti.RubrArti).PorcDtoRubr / 100, 2);
                } 
                catch { }

                lblArticulo.Text = arti.DescArti;
                txtIdArticulo.Text = arti.IDArti.ToString();
                txtCodBarra.Text = arti.CoBaArti;
                txtPrecioUnitario.Text = Math.Round(arti.SugeArti-(arti.SugeArti*(double)porcDtoArt), 0).ToString();
                    
                txtCantidad.Text = "1";

                //agregarArticulo();
            }
            catch
            {
                txtIdArticulo.Text = "0";
                lblArticulo.Text = "Articulo inexistente";;
            }
        }

        private  bool VerificarStock()
        {
            bool hayStock=true;
            //try
            //{
            //    if (arti.StockArti <= Convert.ToInt32(txtCantidad.Text))
            //    {
            //        DialogResult dr = MessageBox.Show("¿Stock Insuficiente ("+arti.StockArti.ToString()+"), desea cargar el artículo de todas formas?",
            //        "Agregar Artículo", MessageBoxButtons.OKCancel);
            //        switch (dr)
            //        {
            //            case DialogResult.Cancel:  
            //            case DialogResult.No:
            //                hayStock = false;
            //                break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error obteniendo stock");
            //}
            return hayStock;
        }

        private void limpiarSubCampos()
        {
            txtCodBarra.Text = "";
            //txtIdArticulo.Text = "0";
            //txtCantidad.Text = "1";
            //txtPrecioUnitario.Text = "0";
            //lblArticulo.Text = "";
            txtCodBarra.Focus();
            txtCodBarra.SelectionStart = 0;
            txtCodBarra.SelectionLength = txtCodBarra.Text.Length;
            txtCodBarra.Focus();
        }

        private bool validarCampos()
        {
            if (txtIdArticulo.Text == "0")
            {
                //MessageBox.Show("Artículo inexistente", "ERROR");
                panelError.Visible = true;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(sonido);
                player.Play();
                txtCodBarra.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
            {
                MessageBox.Show("Falta ingresar precio unitario", "ERROR");
                txtPrecioUnitario.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Falta ingresar la cantidad", "ERROR");
                txtCantidad.Focus();
                return false;
            }
            return true;
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

        private void ListarArticulos()
        {
            dtGView.DataSource = null;
            dtGView.DataSource = vtaArticulo;
            dtGView.Columns[0].Visible = false; //Nume Vta
            dtGView.Columns[1].Visible = false; //ID Articulo
            dtGView.Columns[2].HeaderText = "Artículo";
            dtGView.Columns[3].HeaderText = "P/Unit.";
            dtGView.Columns[3].Width = 20;
            dtGView.Columns[4].HeaderText = "Cantidad";
            dtGView.Columns[4].Width = 20;
            dtGView.Columns[5].HeaderText = "Subtotal";
            dtGView.Columns[5].Width = 60;
            dtGView.Columns[6].HeaderText = "% IVA";
            dtGView.Columns[6].Width = 60;
            dtGView.Columns[7].HeaderText = "% DTO";
            dtGView.Columns[7].Width = 60;

            dtGView.Refresh();
            //dtGView.Rows[dtGView.RowCount-1].Selected=true;
        }

        private void btnElminar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                int cant = 0;
                try
                {
                    cant = Convert.ToInt32(lblCantidad.Text);
                }
                catch { 

                }

                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int IdArti = Convert.ToInt32(currentRow.Cells[1].Value);
                int cantidad = Convert.ToInt32(currentRow.Cells[4].Value);
                double precio = Convert.ToDouble(currentRow.Cells[3].Value);

                foreach (VtaArtEntity item in vtaArticulo)
                {
                    if (item.ArtiVear == IdArti && item.CantVear == cantidad && item.PrecVear == precio)
                    {
                        vtaArticulo.Remove(item);

                        double totalRemito = Convert.ToDouble(lblTotal.Text);
                        totalRemito -= Math.Round(item.PrecVear * item.CantVear, 2);
                        cant -= item.CantVear;
                        lblTotal.Text = totalRemito.ToString();
                        lblCantidad.Text = cant.ToString();
                        break;
                    }
                }

                ListarArticulos();
                txtCodBarra.Focus();
            }
        }

        private void txtCodBarra_TextChanged(object sender, EventArgs e)
        {
            //BuscarArticulo(1);
           
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void imgPrinterNofiscal_Click(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 1)
                Insert(true);
            else
                ImprimirNoFiscal(venta);
        }


        private void NotadeCredito(bool tipoVta)
        {
            try
            {
                long nroTicket = 1;

                DialogResult dr = MessageBox.Show("¿Esta seguro generar la Nota de crédito?",   "Nota de crédito", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                        //decimal numeNC = 0;
                        //if (!tipoVta)
                        //{
                        //    string letra = venta.LetraVta;
                        //    if (letra == "B")
                        //        numeNC = NotaCreditoB();
                        //    else
                        //        numeNC = 1;// NotaCreditoA();
                        //}                            
                        //if (numeNC >= 0)
                        //{
                        //    ruBus.AgregarNotaCredito(GlobalClass.LongPrimaryKey, numeNC);
                        //    this.Hide();
                        //}
                        decimal numeNC = 0;
                        string cae = string.Empty;
                        string barCodeName = string.Empty;
                        string fecVtoCae = string.Empty;
                        notaCredito.NumeVtaNocr = venta.NumeVta;

                        if (!tipoVta)
                        {
                            string letra = venta.LetraVta;
                            switch (letra)
                            {
                                case "FEA":
                                case "FEB":
                                    #region NOTAS DE CRÉDITO ELECTRÓNICA A Y B
                                    try
                                    {
                                        List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                                        AlicIvaEntity etyIVA = new AlicIvaEntity();
                                        int idIVA = 0;

                                        string cuitClie = "0";

                                        if (venta.IdClie > 0)
                                        {
                                            ClienteEntity clie = new ClienteEntity();
                                            clie = clieBus.getClienteID(venta.IdClie);
                                            cuitClie = clie.CuitClie;
                                        }


                                        /*
                                        3 - 0
                                        4 - 10.5
                                        5 - 21
                                        6 - 27
                                        8 - 5
                                        9 - 2.5
                                        */

                                        idIVA = 5;

                                        etyIVA.id = idIVA;
                                        etyIVA.Importe = Math.Round(venta.TotaVta - (venta.TotaVta / 1.21), 2);
                                        etyIVA.BaseImp = Math.Round(venta.TotaVta / 1.21, 2);
                                        ivas.Add(etyIVA);

                                        if (produccion == 0)
                                        {
                                            //*******************************************************************************************
                                            //TESTING
                                            //*******************************************************************************************
                                            wsassSystem wasass = new wsassSystem();
                                            FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                                            res = wasass.FECAESolicitar(1, (venta.LetraVta == "FEA" ? 3 : 8), 1, (cuitClie.Length >= 11 ? 80 : (cuitClie.Length == 1 ? 99 : 96)), long.Parse(cuitClie), (double)venta.TotaVta, etyIVA.BaseImp, etyIVA.Importe, ivas, DateTime.Now, "PES", venta,0,0);

                                            if (res.FeCabResp.Resultado != "A")
                                            {
                                                nroTicket = -1;
                                                if (res.Errors != null)
                                                {
                                                    MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                                }

                                            }
                                            else
                                            {
                                                nroTicket = res.FeDetResp[0].CbteDesde;
                                                cae = res.FeDetResp[0].CAE.ToString();
                                                fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                                notaCredito.CaeNocr = cae;
                                                notaCredito.FechaVtoCaeNocr = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                                numeNC = nroTicket;
                                                notaCredito.TicketFiscalNocr = nroTicket;

                                                //11 Posiciones CUIT
                                                //02 Posiciones Código Comprobante
                                                //04 Posiciones Pto de Vta
                                                //14 Posiciones CAE
                                                //08 Posiciones Fecha Vto CAE
                                                //char pad = '0';
                                                //string ptoVta = System.Configuration.ConfigurationManager.AppSettings["PtoVta"];
                                                //barCodeName = CUIT + "03" + ptoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                                //generarCodBarra(barCodeName);
                                            }

                                        }
                                        else
                                        {
                                            //*******************************************************************************************
                                            //PRODUCCION
                                            //*******************************************************************************************
                                            wsaaProdSystem wasass = new wsaaProdSystem(); // PRODUCCION
                                            FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse res = new FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse(); //PRODUCCION

                                            res = wasass.FECAESolicitar(1, (venta.LetraVta == "FEA" ? 3 : 8), 1, (cuitClie.Length >= 11 ? 80 : (cuitClie.Length == 1 ? 99 : 96)), long.Parse(cuitClie), (double)venta.TotaVta, etyIVA.BaseImp, etyIVA.Importe, ivas, DateTime.Now, "PES", venta,0,0);

                                            if (res.FeCabResp.Resultado != "A")
                                            {
                                                nroTicket = -1;
                                                if (res.Errors != null)
                                                {
                                                    MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                                }

                                            }
                                            else
                                            {
                                                nroTicket = res.FeDetResp[0].CbteDesde;
                                                cae = res.FeDetResp[0].CAE.ToString();
                                                fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                                notaCredito.CaeNocr = cae;
                                                notaCredito.FechaVtoCaeNocr = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                                numeNC = nroTicket;
                                                notaCredito.TicketFiscalNocr = nroTicket;

                                                //11 Posiciones CUIT
                                                //02 Posiciones Código Comprobante
                                                //04 Posiciones Pto de Vta
                                                //14 Posiciones CAE
                                                //08 Posiciones Fecha Vto CAE
                                                //char pad = '0';
                                                //string ptoVta = System.Configuration.ConfigurationManager.AppSettings["PtoVta"];
                                                //barCodeName = CUIT + "03" + ptoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                                //generarCodBarra(barCodeName);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception("Error generando Factura Electrónica A --> " + ex.Message);
                                    }
                                    notaCredito.TicketFiscalNocr = nroTicket;
                                    numeNC = nroTicket;
                                    break;
                                #endregion
                                case "FEC":
                                    #region NOTAS DE CRÉDITO ELECTRÓNICA C
                                    try
                                    {
                                        List<AlicIvaEntity> ivas = new List<AlicIvaEntity>();
                                        AlicIvaEntity etyIVA = new AlicIvaEntity();
                                        int idIVA = 0;

                                        string cuitClie = "99999995";

                                        if (venta.IdClie > 0)
                                        {
                                            ClienteEntity clie = new ClienteEntity();
                                            clie = clieBus.getClienteID(venta.IdClie);
                                            cuitClie = clie.CuitClie;
                                        }


                                        /*
                                        3 - 0
                                        4 - 10.5
                                        5 - 21
                                        6 - 27
                                        8 - 5
                                        9 - 2.5
                                        */

                                        //idIVA = 5;

                                        //etyIVA.id = idIVA;
                                        //etyIVA.Importe = Math.Round(venta.TotaVta - (venta.TotaVta / 1.21), 2);
                                        etyIVA.BaseImp =venta.TotaVta;
                                        //ivas.Add(etyIVA);

                                        if (produccion == 0)
                                        {
                                            //*******************************************************************************************
                                            //TESTING
                                            //*******************************************************************************************
                                            wsassSystem wasass = new wsassSystem();
                                            FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse res = new FacturaElectronica.ar.gov.afip.wswhomo.FECAEResponse();
                                            res = wasass.FECAESolicitar(1, (venta.LetraVta == "FEA" ? 3 : 8), 1, (cuitClie.Length >= 11 ? 80 : 96), long.Parse(cuitClie), (double)venta.TotaVta, etyIVA.BaseImp, etyIVA.Importe, ivas, DateTime.Now, "PES", venta,0,0);

                                            if (res.FeCabResp.Resultado != "A")
                                            {
                                                nroTicket = -1;
                                                if (res.Errors != null)
                                                {
                                                    MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                                }

                                            }
                                            else
                                            {
                                                nroTicket = res.FeDetResp[0].CbteDesde;
                                                cae = res.FeDetResp[0].CAE.ToString();
                                                fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                                notaCredito.CaeNocr = cae;
                                                notaCredito.FechaVtoCaeNocr = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                                numeNC = nroTicket;
                                                notaCredito.TicketFiscalNocr = nroTicket;

                                                //11 Posiciones CUIT
                                                //02 Posiciones Código Comprobante
                                                //04 Posiciones Pto de Vta
                                                //14 Posiciones CAE
                                                //08 Posiciones Fecha Vto CAE
                                                //char pad = '0';
                                                //string ptoVta = System.Configuration.ConfigurationManager.AppSettings["PtoVta"];
                                                //barCodeName = CUIT + "03" + ptoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                                //generarCodBarra(barCodeName);
                                            }

                                        }
                                        else
                                        {
                                            //*******************************************************************************************
                                            //PRODUCCION
                                            //*******************************************************************************************
                                            wsaaProdSystem wasass = new wsaaProdSystem(); // PRODUCCION
                                            FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse res = new FacturaElectronica.ar.gov.afip.servicios1.FECAEResponse(); //PRODUCCION

                                            res = wasass.FECAESolicitar(1, 13, 1, 96, long.Parse(cuitClie), (double)venta.TotaVta, etyIVA.BaseImp, etyIVA.Importe, ivas, DateTime.Now, "PES", venta,0,0);

                                            if (res.FeCabResp.Resultado != "A")
                                            {
                                                nroTicket = -1;
                                                if (res.Errors != null)
                                                {
                                                    MessageBox.Show("Error --> Code: " + res.Errors[0].Code + " --> Desc: " + res.Errors[0].Msg);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Observación --> Code: " + res.FeDetResp[0].Observaciones[0].Code + " --> Desc: " + res.FeDetResp[0].Observaciones[0].Msg);
                                                }

                                            }
                                            else
                                            {
                                                nroTicket = res.FeDetResp[0].CbteDesde;
                                                cae = res.FeDetResp[0].CAE.ToString();
                                                fecVtoCae = res.FeDetResp[0].CAEFchVto.ToString();
                                                notaCredito.CaeNocr = cae;
                                                notaCredito.FechaVtoCaeNocr = DateTime.ParseExact(fecVtoCae, "yyyyMMdd", null);
                                                numeNC = nroTicket;
                                                notaCredito.TicketFiscalNocr = nroTicket;

                                                //11 Posiciones CUIT
                                                //02 Posiciones Código Comprobante
                                                //04 Posiciones Pto de Vta
                                                //14 Posiciones CAE
                                                //08 Posiciones Fecha Vto CAE
                                                //char pad = '0';
                                                //string ptoVta = System.Configuration.ConfigurationManager.AppSettings["PtoVta"];
                                                //barCodeName = CUIT + "03" + ptoVta.PadLeft(4, pad) + cae + fecVtoCae;
                                                //generarCodBarra(barCodeName);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception("Error generando Factura Electrónica A --> " + ex.Message);
                                    }
                                    notaCredito.TicketFiscalNocr = nroTicket;
                                    numeNC = nroTicket;
                                    break;
                                #endregion
                                case "B":
                                    numeNC = NotaCreditoB();
                                    break;
                                case "A":
                                    numeNC = 1;// NotaCreditoA();
                                    break;
                                case "X":
                                    numeNC = 0;// NotaCreditoA();
                                    break;
                                default:
                                    numeNC = -1;
                                    break;

                            }
                        }
                        if (numeNC >= 0)
                        {
                            ruBus.AgregarNotaCredito(notaCredito, GlobalClass.UserID);
                            if (!tipoVta)
                                if (venta.LetraVta=="FEA" || venta.LetraVta == "FEB")
                                    ImprimirNotaCreditoElectronica();
                                else if (venta.LetraVta == "FEC")
                                    ImprimirNotaCreditoElectronicaC();

                            this.Hide();
                        }
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error generando Nota de crédito");
                this.Hide();
            }
        }

        private void dtGView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {
                    DataGridViewRow currentRow = dtGView.SelectedRows[0];
                    txtIdArticulo.Text = currentRow.Cells[1].Value.ToString();
                    BuscarArticulo(3);
                    txtCantidad.Text = currentRow.Cells[4].Value.ToString();
                    txtPrecioUnitario.Text = currentRow.Cells[3].Value.ToString();
                    changeQuantity = true;
                    txtCantidad.Focus();
                }
            }
            catch { }

            
        }

        void dtGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {
                    DataGridViewRow currentRow = dtGView.SelectedRows[0];
                    txtIdArticulo.Text = currentRow.Cells[1].Value.ToString();
                    BuscarArticulo(3);
                    txtCantidad.Text = currentRow.Cells[4].Value.ToString();
                    txtPrecioUnitario.Text = currentRow.Cells[3].Value.ToString();
                    porcDtoArt = Convert.ToDecimal(currentRow.Cells[7].Value.ToString());
                    changeQuantity = true;
                    txtCantidad.Focus();
                }
            }
            catch { }            
        }

        private void agregarArticulo()
        {
            if (checkBoxCalculadora.Checked)
            {

                VtaArtEntity entity = new VtaArtEntity();
                entity.ArtiVear = 14144;
                entity.CantVear = 1;
                entity.PrecVear = Convert.ToDouble(txtPrecioUnitario.Text);
                entity.DescArti = "ART. VARIOS";
                entity.SubtotalVear = Convert.ToDouble(txtPrecioUnitario.Text);
                entity.IvaVear = 0;
                entity.PorcDtoVear = porcDtoArt*100;

                vtaArticulo.Insert(0, entity);

                //****************************************************
                //CALCULA EL TOTAL
                //****************************************************
                if (nuevo) lblTotal.Text = "0";
                nuevo = false;
                double totalRemito = Convert.ToDouble(lblTotal.Text);

                totalRemito = 0;
                foreach (VtaArtEntity articulo in vtaArticulo)
                {
                    totalRemito += articulo.SubtotalVear;

                }
                lblTotal.Text = totalRemito.ToString();
                //****************************************************

                ListarArticulos();
                txtPrecioUnitario.Text = string.Empty;
                txtPrecioUnitario.Focus();
            }
            else
            { 
                int cant = 0;
                if (validarCampos())
                {
                    if (Convert.ToDouble(txtPrecioUnitario.Text) <= 0)
                    {
                        lblMensaje.Text = "Debe Ingresar precio unitario";
                        txtPrecioUnitario.Focus();
                        lblMensaje.Text = "Debe Ingresar precio unitario";
                    }
                    else
                    {

                        if (VerificarStock())
                        {
                            VtaArtEntity entity = new VtaArtEntity();
                            entity.ArtiVear = Convert.ToInt32(txtIdArticulo.Text);
                            entity.CantVear = Convert.ToInt32(txtCantidad.Text);
                            entity.PrecVear = Convert.ToDouble(txtPrecioUnitario.Text);
                            entity.DescArti = lblArticulo.Text.Trim();
                            entity.SubtotalVear = Math.Round(Convert.ToDouble(txtPrecioUnitario.Text) * Convert.ToInt32(txtCantidad.Text), 2);
                            entity.IvaVear = arti.porcIVAArti;
                            entity.PorcDtoVear = porcDtoArt*100;
                            var index = vtaArticulo.FindIndex(c => c.ArtiVear == entity.ArtiVear && c.PrecVear==entity.PrecVear);
                            if (index >= 0)
                            {
                                if (!changeQuantity && !string.IsNullOrEmpty(txtCodBarra.Text.Trim()))
                                {
                                    entity.CantVear += vtaArticulo[index].CantVear;
                                    entity.SubtotalVear = Math.Round(Convert.ToDouble(txtPrecioUnitario.Text) * entity.CantVear, 2);
                                }
                                vtaArticulo[index] = entity;
                            }
                            else
                                //vtaArticulo.Add(entity);
                                vtaArticulo.Insert(0,entity);

                            //****************************************************
                            //CALCULA EL TOTAL
                            //****************************************************
                            if (nuevo) lblTotal.Text = "0";
                            nuevo = false;
                            double totalRemito = Convert.ToDouble(lblTotal.Text);
                            //if (!changeQuantity)
                            //    totalRemito += Math.Round(entity.PrecVear * entity.CantVear, 2);
                            //else
                            //{
                            totalRemito = 0;
                            foreach (VtaArtEntity articulo in vtaArticulo)
                            {
                                totalRemito += articulo.SubtotalVear;
                                cant += articulo.CantVear;

                            }
                            //}
                            lblTotal.Text = totalRemito.ToString();

                            lblCantidad.Text = cant.ToString();
                            //****************************************************

                            if (string.IsNullOrEmpty(txtRecibido.Text)) txtRecibido.Text = "0";
                            double recibido = Convert.ToDouble(txtRecibido.Text);
                            recibido = recibido - totalRemito;
                            lblVuelto.Text = Math.Round(recibido, 2).ToString();

                            ListarArticulos();
                            limpiarSubCampos();

                        }
                    }
                }
                changeQuantity = false;
            }
        }

        private void btnNoFiscal_Click(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 1)
                Insert(true);
            else
            {
                int condicion = Convert.ToInt32(cboCondicion.SelectedValue);
                if (condicion == 2)
                {
                    try
                    {
                        if (idclie==-1)
                        {
                            MessageBox.Show("Debe seleccionar un Cliente válido", "Dato Incorrecto");
                            cboCliente.Focus();
                            return;
                        }
                        else { 

                            ruBus.AgregarVentaEnCtaCte(venta.NumeVta, idclie, txtRetira.Text.Trim());
                            MessageBox.Show("Cuenta Corriente Actualizada con Éxito", "Cuenta Corriente");
                            this.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Cuenta Corriente");
                    }
                }
                //else
                if (venta.TipoVta == true)
                    ImprimirNoFiscal(venta);
                else
                    ImprimirFacturaElectronica(venta);

            }
        }

        private void checkCtcCte_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxCalculadora_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCalculadora.Checked) txtPrecioUnitario.Focus();
            else txtCodBarra.Focus();
        }

        private void picNuevoCobrador_Click(object sender, EventArgs e)
        {
            GlobalClass.LastActionType = GlobalClass.ActionType;
            FrmCliente frm = new FrmCliente();
            frm.ShowDialog();
            GlobalClass.ActionType = GlobalClass.LastActionType;
            autocompleteClient();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            panelError.Visible = false;
            txtCodBarra.Focus();
        }

        private void ImprimirNotaCreditoElectronica()
        {
            try
            {
                System.Drawing.Printing.PaperSize paperSize = new PaperSize("Custom", 500, 2000);
                printFontTitulo = new Font("Arial", 10, FontStyle.Bold);
                printFont = new Font("Arial", 8);
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = paperSize;
                if (!string.IsNullOrEmpty(nombreImpresora))
                    pd.PrinterSettings.PrinterName = nombreImpresora;

                //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageNotaCreditoElectronica);
                pd.Print();
            }
            catch (Exception ex)
            {
                //respuestas();
                MessageBox.Show(ex.Message);
            }
        }

        private void pd_PrintPageNotaCreditoElectronica(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                //Dibujar una linea
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);


                string cuitClie = "20222222223";
                string rasoClie = "CONSUMIDOR FINAL";
                string domicilioClie = "-";
                string CondicionIVA = "CONSUMIDOR FINAL";

                if (venta.IdClie > 0)
                {
                    ClienteEntity clie = new ClienteEntity();
                    clie = new ClienteBUS().getClienteID(venta.IdClie);
                    cuitClie = clie.CuitClie;
                    rasoClie = clie.RasoClie;
                    domicilioClie = clie.DireClie;
                    CondicionIVA = clie.NombCondicionIVA;
                }


                string lineaBlanco = ".";
                //ENCABEZADO
                //ev.Graphics.DrawString("FACTURA B", printFontTitulo, Brushes.Black, 140, 10, new StringFormat());
                ev.Graphics.DrawString(RazonSocial.ToUpper(), printFontTitulo, Brushes.Black, 70, 10, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: " + CUIT, printFont, Brushes.Black, 70, 25, new StringFormat());
                ev.Graphics.DrawString("I.B.: " + IngresosBrutos, printFont, Brushes.Black, 70, 40, new StringFormat());
                ev.Graphics.DrawString("INICIO ACTIVIDADES: " + FechaIniActividades, printFont, Brushes.Black, 70, 55, new StringFormat());
                ev.Graphics.DrawString("IVA RESPONSABLE INCRIPTO", printFont, Brushes.Black, 70, 70, new StringFormat());

                ev.Graphics.DrawString("A " + CondicionIVA, printFont, Brushes.Black, 70, 100, new StringFormat());
                ev.Graphics.DrawString("NOTA DE CRÉDITO \"" + (venta.LetraVta=="FEA"?"A":"B") + "\"", printFont, Brushes.Black, 70, 115, new StringFormat());
                ev.Graphics.DrawString("Nº " + PtoVta.PadLeft(4, '0') + "-" + notaCredito.TicketFiscalNocr.ToString().PadLeft(8, '0'), printFont, Brushes.Black, 70, 130, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 70, 145, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm"), printFont, Brushes.Black, 215, 145, new StringFormat());

                ev.Graphics.DrawString("ANULA FACTURA  \"" + venta.LetraVta + "\" Nº: " + venta.TicketFiscal, printFont, Brushes.Black, 70, 165, new StringFormat());

                int line = 190;
                if (venta.IdClie > 0)
                {
                    //LINEA
                    ev.Graphics.DrawLine(blackPen, 50, line, 500, line);
                    line += 15;
                    ev.Graphics.DrawString("CLIENTE: " + rasoClie, printFont, Brushes.Black, 70, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString((cuitClie.Length >= 11 ? "CUIT: " : "DNI: ") + cuitClie, printFont, Brushes.Black, 70, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("DOMICILIO: " + domicilioClie, printFont, Brushes.Black, 70, line, new StringFormat());
                    line += 15;

                }

                //LINEA
                ev.Graphics.DrawLine(blackPen, 50, line, 500, line);
                line += 15;

                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 70, line, new StringFormat());
                    ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")", printFont, Brushes.Black, 215, line, new StringFormat());

                    line = line + 15;
                    ev.Graphics.DrawString((vtaArt.DescArti.Length > 22 ? vtaArt.DescArti.Substring(0, 22) : vtaArt.DescArti), printFont, Brushes.Black, 70, line, new StringFormat());
                    ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());
                    line = line + 15;
                    //if (line > 1100)
                    //ev.PageSettings.PaperSize.Height += 1000;
                }
                //LINEA
                line += 15;
                ev.Graphics.DrawLine(blackPen, 50, line, 500, line);

                if (venta.LetraVta == "FEA")
                {
                    line += 15;
                    ev.Graphics.DrawString("SUBTOTAL: ", printFont, Brushes.Black, 70, line, new StringFormat());
                    ev.Graphics.DrawString((venta.TotaVta / 1.21).ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("% IVA: 21", printFont, Brushes.Black, 70, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("IVA: ", printFont, Brushes.Black, 70, line, new StringFormat());
                    ev.Graphics.DrawString((venta.TotaVta - (venta.TotaVta / 1.21)).ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());

                }


                //TOTAL
                line += 15;
                ev.Graphics.DrawString("TOTAL", printFontTitulo, Brushes.Black, 70, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFontTitulo, Brushes.Black, 235, line, new StringFormat());
                line += 30;
                //CAE
                ev.Graphics.DrawString("CAE: " + notaCredito.CaeNocr, printFont, Brushes.Black, 70, line, new StringFormat());
                line += 15;
                //FECHA VTO
                ev.Graphics.DrawString("VTO. CAE: " + notaCredito.FechaVtoCaeNocr.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 70, line, new StringFormat());
                line += 15;
                //Código QR
                string dataQR = "{\"ver\":1,\"fecha\":\"" + venta.FechVta.ToString("yyyy-MM-dd") + "\",\"cuit\":" + CUIT + ",\"ptoVta\":" + PtoVta + ",\"tipoCmp\":" + (venta.LetraVta == "FEA" ? "3" : "8") + ",\"nroCmp\":" + venta.TicketFiscal + ",\"importe\":" + venta.TotaVta.ToString("0.00") + ",\"moneda\":\"PES\",\"ctz\":1,\"tipoDocRec\":80,\"nroDocRec\":" + cuitClie + ",\"tipoCodAut\":\"E\",\"codAut\":" + venta.CAEVta + "}";
                ev.Graphics.DrawImage(QrSys.GenerarCodigoQR(venta.CAEVta, dataQR), 50, line);
                line += 15;
                ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 70, line, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }

        private void ImprimirNotaCreditoElectronicaC()
        {
            try
            {
                System.Drawing.Printing.PaperSize paperSize = new PaperSize("Custom", 500, 2000);
                printFontTitulo = new Font("Arial", 10, FontStyle.Bold);
                printFont = new Font("Arial", 8);
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = paperSize;
                if (!string.IsNullOrEmpty(nombreImpresora))
                    pd.PrinterSettings.PrinterName = nombreImpresora;

                //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageNotaCreditoElectronicaC);
                pd.Print();
            }
            catch (Exception ex)
            {
                //respuestas();
                MessageBox.Show(ex.Message);
            }
        }

        private void pd_PrintPageNotaCreditoElectronicaC(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                //Dibujar una linea
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);


                string cuitClie = "99999995";
                string rasoClie = "CONSUMIDOR FINAL";
                string domicilioClie = "-";
                string CondicionIVA = "CONSUMIDOR FINAL";

                //if (venta.IdClie > 0)
                //{
                //    ClienteEntity clie = new ClienteEntity();
                //    clie = new ClienteBUS().getClienteID(venta.IdClie);
                //    cuitClie = clie.CuitClie;
                //    rasoClie = clie.RasoClie;
                //    domicilioClie = clie.DireClie;
                //    CondicionIVA = clie.NombCondicionIVA;
                //}


                string lineaBlanco = ".";
                //ENCABEZADO
                //ev.Graphics.DrawString("FACTURA B", printFontTitulo, Brushes.Black, 140, 10, new StringFormat());
                ev.Graphics.DrawString(RazonSocial.ToUpper(), printFontTitulo, Brushes.Black, 70, 10, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: " + CUIT, printFont, Brushes.Black, 70, 25, new StringFormat());
                ev.Graphics.DrawString("I.B.: " + IngresosBrutos, printFont, Brushes.Black, 70, 40, new StringFormat());
                ev.Graphics.DrawString("INICIO ACTIVIDADES: " + FechaIniActividades, printFont, Brushes.Black, 70, 55, new StringFormat());
                ev.Graphics.DrawString("MONOTRIBUTISTA", printFont, Brushes.Black, 70, 70, new StringFormat());

                ev.Graphics.DrawString("A CONSUMIDOR FINAL", printFont, Brushes.Black, 70, 100, new StringFormat());
                ev.Graphics.DrawString("NOTA DE CRÉDITO C", printFont, Brushes.Black, 70, 115, new StringFormat());
                ev.Graphics.DrawString("Nº " + PtoVta.PadLeft(4, '0') + "-" + notaCredito.TicketFiscalNocr.ToString().PadLeft(8, '0'), printFont, Brushes.Black, 70, 130, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 70, 145, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm"), printFont, Brushes.Black, 215, 145, new StringFormat());

                ev.Graphics.DrawString("ANULA FACTURA  \"" + venta.LetraVta + "\" Nº: " + venta.TicketFiscal, printFont, Brushes.Black, 70, 165, new StringFormat());

                int line = 190;
                //if (venta.IdClie > 0)
                //{
                //    //LINEA
                //    ev.Graphics.DrawLine(blackPen, 50, line, 500, line);
                //    line += 15;
                //    ev.Graphics.DrawString("CLIENTE: " + rasoClie, printFont, Brushes.Black, 70, line, new StringFormat());
                //    line += 15;
                //    ev.Graphics.DrawString((cuitClie.Length >= 11 ? "CUIT: " : "DNI: ") + cuitClie, printFont, Brushes.Black, 70, line, new StringFormat());
                //    line += 15;
                //    ev.Graphics.DrawString("DOMICILIO: " + domicilioClie, printFont, Brushes.Black, 70, line, new StringFormat());
                //    line += 15;

                //}

                //LINEA
                ev.Graphics.DrawLine(blackPen, 50, line, 500, line);
                line += 15;

                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 70, line, new StringFormat());
                    //ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")", printFont, Brushes.Black, 215, line, new StringFormat());

                    line = line + 15;
                    ev.Graphics.DrawString((vtaArt.DescArti.Length > 22 ? vtaArt.DescArti.Substring(0, 22) : vtaArt.DescArti), printFont, Brushes.Black, 70, line, new StringFormat());
                    ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());
                    line = line + 15;
                    //if (line > 1100)
                    //ev.PageSettings.PaperSize.Height += 1000;
                }
                //LINEA
                line += 15;
                ev.Graphics.DrawLine(blackPen, 50, line, 500, line);

                //if (venta.LetraVta == "FEA")
                //{
                //    line += 15;
                //    ev.Graphics.DrawString("SUBTOTAL: ", printFont, Brushes.Black, 70, line, new StringFormat());
                //    ev.Graphics.DrawString((venta.TotaVta / 1.21).ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());
                //    line += 15;
                //    ev.Graphics.DrawString("% IVA: 21", printFont, Brushes.Black, 70, line, new StringFormat());
                //    line += 15;
                //    ev.Graphics.DrawString("IVA: ", printFont, Brushes.Black, 70, line, new StringFormat());
                //    ev.Graphics.DrawString((venta.TotaVta - (venta.TotaVta / 1.21)).ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());

                //}


                //TOTAL
                line += 15;
                ev.Graphics.DrawString("TOTAL", printFontTitulo, Brushes.Black, 70, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFontTitulo, Brushes.Black, 235, line, new StringFormat());
                line += 30;
                //CAE
                ev.Graphics.DrawString("CAE: " + notaCredito.CaeNocr, printFont, Brushes.Black, 70, line, new StringFormat());
                line += 15;
                //FECHA VTO
                ev.Graphics.DrawString("VTO. CAE: " + notaCredito.FechaVtoCaeNocr.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 70, line, new StringFormat());
                line += 15;
                //Código QR
                string dataQR = "{\"ver\":1,\"fecha\":\"" + venta.FechVta.ToString("yyyy-MM-dd") + "\",\"cuit\":" + CUIT + ",\"ptoVta\":" + PtoVta + ",\"tipoCmp\":13,\"nroCmp\":" + venta.TicketFiscal + ",\"importe\":" + venta.TotaVta.ToString("0.00") + ",\"moneda\":\"PES\",\"ctz\":1,\"tipoDocRec\":80,\"nroDocRec\":" + cuitClie + ",\"tipoCodAut\":\"E\",\"codAut\":" + venta.CAEVta + "}";
                ev.Graphics.DrawImage(QrSys.GenerarCodigoQR(venta.CAEVta, dataQR), 50, line);
                line += 15;
                ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 70, line, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }
        private void ImprimirFacturaElectronica(VentaEntity vta)
        {
            if (checkBoxImprime.Checked)
            try
            {
                int i = 0;
                cantPage = vtaArticulo.Count / 30;
                acumCantPage = 1;

                while (i <= cantPage)
                {
                    inicio = i * 30;
                    fin = (cantPage == 0 ? vtaArticulo.Count : (vtaArticulo.Count > inicio + 30 ? inicio + 30 : vtaArticulo.Count));
                    System.Drawing.Printing.PaperSize paperSize = new PaperSize("Custom", 500, 2000);
                    venta = vta;
                    //printFontTitulo = new Font("Arial", 10, FontStyle.Bold);
                    //printFont = new Font("Arial", 8);
                    printFontTitulo = new Font("MonospaceTypewriter", 8);
                    printFont = new Font("MonospaceTypewriter", 7);
                    PrintDocument pd = new PrintDocument();
                    pd.DefaultPageSettings.PaperSize = paperSize;
                        //if (!string.IsNullOrEmpty(nombreImpresora))
                        //    pd.PrinterSettings.PrinterName = nombreImpresora;
                        //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                    if (ComanderaAlternativa)
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageFacturaElectronicaAlternativa);
                    else
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageFacturaElectronica);
                    
                    pd.Print();

                    i++;
                    acumCantPage++;
                }

            }
            catch (Exception ex)
            {
                //respuestas();
                MessageBox.Show(ex.Message);
            }
        }

        private void ImprimirFacturaElectronicaC(VentaEntity vta)
        {
            try
            {
                System.Drawing.Printing.PaperSize paperSize = new PaperSize("Custom", 500, 2000);
                venta = vta;
                printFontTitulo = new Font("Arial", 10, FontStyle.Bold);
                printFont = new Font("Arial", 8);
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = paperSize;
                if (!string.IsNullOrEmpty(nombreImpresora))
                    pd.PrinterSettings.PrinterName = nombreImpresora;

                //pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPageFacturaElectronicaC);
                pd.Print();
            }
            catch (Exception ex)
            {
                //respuestas();
                MessageBox.Show(ex.Message);
            }
        }
        private void pd_PrintPageFacturaElectronica(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();
                //Dibujar una linea
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                //ev.PageSettings.PaperSize.Height += 1000;
                //ev.PageSettings.PaperSize = new PaperSize("Custom", 500, 2000);
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);


                string cuitClie = "20222222223";
                string rasoClie = "CONSUMIDOR FINAL";
                string domicilioClie = "-";
                string CondicionIVA = "CONSUMIDOR FINAL";

                if (idclie != -1)
                {
                    ClienteEntity clie = new ClienteEntity();
                    clie = new ClienteBUS().getClienteID(idclie);
                    cuitClie = clie.CuitClie;
                    rasoClie = clie.RasoClie;
                    domicilioClie = clie.DireClie;
                    CondicionIVA = clie.NombCondicionIVA;
                }


                string lineaBlanco = ".";
                //ENCABEZADO
                //ev.Graphics.DrawString("FACTURA B", printFontTitulo, Brushes.Black, 140, 10, new StringFormat());
                ev.Graphics.DrawString(RazonSocial.ToUpper(), printFontTitulo, Brushes.Black, 20, 10, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: " + CUIT, printFont, Brushes.Black, 20, 25, new StringFormat());
                ev.Graphics.DrawString("I.B.: " + IngresosBrutos, printFont, Brushes.Black, 20, 40, new StringFormat());
                ev.Graphics.DrawString("INICIO ACTIVIDADES: " + FechaIniActividades, printFont, Brushes.Black, 20, 55, new StringFormat());
                ev.Graphics.DrawString("IVA RESPONSABLE INCRIPTO", printFont, Brushes.Black, 20, 70, new StringFormat());

                ev.Graphics.DrawString("A " + CondicionIVA, printFont, Brushes.Black, 20, 100, new StringFormat());
                ev.Graphics.DrawString("FACTURA \"" + (venta.LetraVta=="FEA"?"A":"B") + "\"", printFont, Brushes.Black, 20, 115, new StringFormat());
                ev.Graphics.DrawString("Nº " + PtoVta.PadLeft(4, '0') + "-" + venta.TicketFiscal.ToString().PadLeft(8, '0'), printFont, Brushes.Black, 20, 130, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 20, 145, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm"), printFont, Brushes.Black, 215, 145, new StringFormat());
                

                int line = 170;
                if (idclie != -1)
                {
                    //LINEA
                    ev.Graphics.DrawLine(blackPen, 20, line, 500, line);
                    line += 15;
                    ev.Graphics.DrawString("CLIENTE: " + rasoClie, printFont, Brushes.Black, 20, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString((cuitClie.Length >= 11 ? "CUIT: " : "DNI: ") + cuitClie, printFont, Brushes.Black, 20, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("DOMICILIO: " + domicilioClie, printFont, Brushes.Black, 20, line, new StringFormat());
                    line += 15;

                }

                //LINEA
                ev.Graphics.DrawLine(blackPen, 20, line, 500, line);
                line += 15;
                int x = 1;
                inicio++;
                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    if (x>=inicio && x<=fin)
                    {
                        ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 20, line, new StringFormat());
                        ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")", printFont, Brushes.Black, 215, line, new StringFormat());

                        line = line + 15;
                        ev.Graphics.DrawString((vtaArt.DescArti.Length > 22 ? vtaArt.DescArti.Substring(0, 22) : vtaArt.DescArti), printFont, Brushes.Black, 20, line, new StringFormat());
                        ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());
                        line = line + 15;
                    }
                    x++;
                    //if (line > 1100)
                    //ev.PageSettings.PaperSize.Height += 1000;
                }
                //LINEA
                line += 15;
                ev.Graphics.DrawLine(blackPen, 20, line, 500, line);

                if (venta.LetraVta == "FEA")
                {
                    line += 15;
                    ev.Graphics.DrawString("SUBTOTAL: ", printFont, Brushes.Black, 20, line, new StringFormat());
                    ev.Graphics.DrawString((venta.TotaVta / 1.21).ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("% IVA: 21", printFont, Brushes.Black, 20, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("IVA: ", printFont, Brushes.Black, 20, line, new StringFormat());
                    ev.Graphics.DrawString((venta.TotaVta - (venta.TotaVta / 1.21)).ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());

                }


                //TOTAL
                line += 15;
                ev.Graphics.DrawString("TOTAL", printFontTitulo, Brushes.Black, 20, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFontTitulo, Brushes.Black, 235, line, new StringFormat());
                line += 30;
                //CAE
                ev.Graphics.DrawString("CAE: " + venta.CAEVta, printFont, Brushes.Black, 20, line, new StringFormat());
                line += 15;
                //FECHA VTO
                ev.Graphics.DrawString("VTO. CAE: " + venta.FechVtoCAEVta.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 20, line, new StringFormat());
                line += 15;
                //Código QR
                string dataQR = "{\"ver\":1,\"fecha\":\"" + venta.FechVta.ToString("yyyy-MM-dd") + "\",\"cuit\":" + CUIT + ",\"ptoVta\":" + PtoVta + ",\"tipoCmp\":"+ (venta.LetraVta == "FEA"?"1":"6") + ",\"nroCmp\":" + venta.TicketFiscal + ",\"importe\":" + venta.TotaVta.ToString("0.00") + ",\"moneda\":\"PES\",\"ctz\":1,\"tipoDocRec\":80,\"nroDocRec\":" + cuitClie + ",\"tipoCodAut\":\"E\",\"codAut\":" + venta.CAEVta + "}";
                ev.Graphics.DrawImage(QrSys.GenerarCodigoQR(venta.CAEVta, dataQR), 50, line);

                line += 15;
                ev.Graphics.DrawString("Pagina " + acumCantPage.ToString() + " de " + (cantPage+1).ToString(), printFontTitulo, Brushes.Black, 20, line, new StringFormat());

                line += 15;
                ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 20, line, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }

        private void pd_PrintPageFacturaElectronicaAlternativa(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();
                //Dibujar una linea
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                //ev.PageSettings.PaperSize.Height += 1000;
                //ev.PageSettings.PaperSize = new PaperSize("Custom", 500, 2000);
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);


                string cuitClie = "0";
                string rasoClie = "CONSUMIDOR FINAL";
                string domicilioClie = "-";
                string CondicionIVA = "CONSUMIDOR FINAL";

                if (idclie != -1)
                {
                    ClienteEntity clie = new ClienteEntity();
                    clie = new ClienteBUS().getClienteID(idclie);
                    cuitClie = clie.CuitClie;
                    rasoClie = clie.RasoClie;
                    domicilioClie = clie.DireClie;
                    CondicionIVA = clie.NombCondicionIVA;
                }


                string lineaBlanco = ".";
                //ENCABEZADO
                //ev.Graphics.DrawString("FACTURA B", printFontTitulo, Brushes.Black, 140, 10, new StringFormat());
                ev.Graphics.DrawString(RazonSocial.ToUpper(), printFontTitulo, Brushes.Black, 10, 10, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: " + CUIT, printFont, Brushes.Black, 5, 25, new StringFormat());
                ev.Graphics.DrawString("I.B.: " + IngresosBrutos, printFont, Brushes.Black, 5, 40, new StringFormat());
                ev.Graphics.DrawString("INICIO ACTIVIDADES: " + FechaIniActividades, printFont, Brushes.Black, 5, 55, new StringFormat());
                ev.Graphics.DrawString("IVA RESPONSABLE INCRIPTO", printFont, Brushes.Black, 5, 70, new StringFormat());

                ev.Graphics.DrawString("A " + CondicionIVA, printFont, Brushes.Black, 5, 100, new StringFormat());
                ev.Graphics.DrawString("FACTURA \"" + (venta.LetraVta == "FEA" ? "A" : "B") + "\"", printFont, Brushes.Black, 5, 115, new StringFormat());
                ev.Graphics.DrawString("Nº " + PtoVta.PadLeft(4, '0') + "-" + venta.TicketFiscal.ToString().PadLeft(8, '0'), printFont, Brushes.Black, 5, 130, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 5, 145, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm"), printFont, Brushes.Black, 110, 145, new StringFormat());


                int line = 170;
                if (idclie != -1)
                {
                    //LINEA
                    ev.Graphics.DrawLine(blackPen, 20, line, 500, line);
                    line += 15;
                    ev.Graphics.DrawString("CLIENTE: " + rasoClie, printFont, Brushes.Black, 5, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString((cuitClie.Length >= 11 ? "CUIT: " : "DNI: ") + cuitClie, printFont, Brushes.Black, 5, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("DOMICILIO: " + domicilioClie, printFont, Brushes.Black, 5, line, new StringFormat());
                    line += 15;

                }

                //LINEA
                ev.Graphics.DrawLine(blackPen, 5, line, 500, line);
                line += 15;
                int x = 1;
                inicio++;
                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    if (x >= inicio && x <= fin)
                    {
                        ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 5, line, new StringFormat());
                        ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")", printFont, Brushes.Black, 115, line, new StringFormat());

                        line = line + 15;
                        ev.Graphics.DrawString((vtaArt.DescArti.Length > 22 ? vtaArt.DescArti.Substring(0, 22) : vtaArt.DescArti), printFont, Brushes.Black, 5, line, new StringFormat());
                        ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 147, line, new StringFormat());
                        line = line + 15;
                    }
                    x++;
                    //if (line > 1100)
                    //ev.PageSettings.PaperSize.Height += 1000;
                }
                //LINEA
                line += 15;
                ev.Graphics.DrawLine(blackPen, 20, line, 500, line);

                if (venta.LetraVta == "FEA")
                {
                    line += 15;
                    ev.Graphics.DrawString("SUBTOTAL: ", printFont, Brushes.Black, 5, line, new StringFormat());
                    ev.Graphics.DrawString((venta.TotaVta / 1.21).ToString("0.00"), printFont, Brushes.Black, 147, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("% IVA: 21", printFont, Brushes.Black, 5, line, new StringFormat());
                    line += 15;
                    ev.Graphics.DrawString("IVA: ", printFont, Brushes.Black, 5, line, new StringFormat());
                    ev.Graphics.DrawString((venta.TotaVta - (venta.TotaVta / 1.21)).ToString("0.00"), printFont, Brushes.Black, 147, line, new StringFormat());

                }


                //TOTAL
                line += 15;
                ev.Graphics.DrawString("TOTAL", printFontTitulo, Brushes.Black, 5, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFontTitulo, Brushes.Black, 147, line, new StringFormat());
                line += 30;
                //CAE
                ev.Graphics.DrawString("CAE: " + venta.CAEVta, printFont, Brushes.Black, 5, line, new StringFormat());
                line += 15;
                //FECHA VTO
                ev.Graphics.DrawString("VTO. CAE: " + venta.FechVtoCAEVta.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 5, line, new StringFormat());
                line += 15;
                //Código QR
                string dataQR = "{\"ver\":1,\"fecha\":\"" + venta.FechVta.ToString("yyyy-MM-dd") + "\",\"cuit\":" + CUIT + ",\"ptoVta\":" + PtoVta + ",\"tipoCmp\":" + (venta.LetraVta == "FEA" ? "1" : "6") + ",\"nroCmp\":" + venta.TicketFiscal + ",\"importe\":" + venta.TotaVta.ToString("0.00") + ",\"moneda\":\"PES\",\"ctz\":1,\"tipoDocRec\":80,\"nroDocRec\":" + cuitClie + ",\"tipoCodAut\":\"E\",\"codAut\":" + venta.CAEVta + "}";
                ev.Graphics.DrawImage(QrSys.GenerarCodigoQR(venta.CAEVta, dataQR), 25, line);

                line += 15;
                ev.Graphics.DrawString("Pagina " + acumCantPage.ToString() + " de " + (cantPage + 1).ToString(), printFontTitulo, Brushes.Black, 5, line, new StringFormat());

                line += 15;
                ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 5, line, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }

        private void pd_PrintPageFacturaElectronicaC(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Core.Business.QRSystem QrSys = new Core.Business.QRSystem();
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                //Dibujar una linea
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                //ev.PageSettings.PaperSize.Height += 1000;
                //ev.PageSettings.PaperSize = new PaperSize("Custom", 500, 2000);
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);


                string cuitClie = "99999995";
                string rasoClie = "CONSUMIDOR FINAL";
                string domicilioClie = "-";
                string CondicionIVA = "CONSUMIDOR FINAL";

                if (idclie != -1)
                {
                    ClienteEntity clie = new ClienteEntity();
                    clie = new ClienteBUS().getClienteID(idclie);
                    cuitClie = clie.CuitClie;
                    rasoClie = clie.RasoClie;
                    domicilioClie = clie.DireClie;
                    CondicionIVA = clie.NombCondicionIVA;
                }


                string lineaBlanco = ".";
                //ENCABEZADO
                //ev.Graphics.DrawString("FACTURA B", printFontTitulo, Brushes.Black, 140, 10, new StringFormat());
                ev.Graphics.DrawString(RazonSocial.ToUpper(), printFontTitulo, Brushes.Black, 70, 10, new StringFormat());
                ev.Graphics.DrawString("CUIT Nro.: " + CUIT, printFont, Brushes.Black, 70, 25, new StringFormat());
                ev.Graphics.DrawString("I.B.: " + IngresosBrutos, printFont, Brushes.Black, 70, 40, new StringFormat());
                ev.Graphics.DrawString("INICIO ACTIVIDADES: " + FechaIniActividades, printFont, Brushes.Black, 70, 55, new StringFormat());
                ev.Graphics.DrawString("MONOTRIBUTISTA", printFont, Brushes.Black, 70, 70, new StringFormat());

                ev.Graphics.DrawString("A CONSUMIDOR FINAL", printFont, Brushes.Black, 70, 100, new StringFormat());
                ev.Graphics.DrawString("FACTURA C", printFont, Brushes.Black, 70, 115, new StringFormat());
                ev.Graphics.DrawString("Nº " + PtoVta.PadLeft(4, '0') + "-" + venta.TicketFiscal.ToString().PadLeft(8, '0'), printFont, Brushes.Black, 70, 130, new StringFormat());
                ev.Graphics.DrawString("FECHA: " + System.DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 70, 145, new StringFormat());
                ev.Graphics.DrawString("HORA: " + System.DateTime.Now.ToString("hh:mm"), printFont, Brushes.Black, 215, 145, new StringFormat());

                int line = 170;
                //if (idclie != -1)
                //{
                //    //LINEA
                //    ev.Graphics.DrawLine(blackPen, 50, line, 500, line);
                //    line += 15;
                //    ev.Graphics.DrawString("CLIENTE: " + rasoClie, printFont, Brushes.Black, 70, line, new StringFormat());
                //    line += 15;
                //    ev.Graphics.DrawString((cuitClie.Length >= 11 ? "CUIT: " : "DNI: ") + cuitClie, printFont, Brushes.Black, 70, line, new StringFormat());
                //    line += 15;
                //    ev.Graphics.DrawString("DOMICILIO: " + domicilioClie, printFont, Brushes.Black, 70, line, new StringFormat());
                //    line += 15;

                //}

                //LINEA
                ev.Graphics.DrawLine(blackPen, 50, line, 500, line);
                line += 15;

                foreach (VtaArtEntity vtaArt in vtaArticulo)
                {
                    ev.Graphics.DrawString(vtaArt.CantVear.ToString() + " X " + vtaArt.PrecVear.ToString("0.00"), printFont, Brushes.Black, 70, line, new StringFormat());
                    //ev.Graphics.DrawString("(" + vtaArt.IvaVear.ToString() + ")", printFont, Brushes.Black, 215, line, new StringFormat());

                    line = line + 15;
                    ev.Graphics.DrawString((vtaArt.DescArti.Length > 22 ? vtaArt.DescArti.Substring(0, 22) : vtaArt.DescArti), printFont, Brushes.Black, 70, line, new StringFormat());
                    ev.Graphics.DrawString(vtaArt.SubtotalVear.ToString("0.00"), printFont, Brushes.Black, 235, line, new StringFormat());
                    line = line + 15;
                    //if (line > 1100)
                    //ev.PageSettings.PaperSize.Height += 1000;
                }
                //LINEA
                line += 15;
                ev.Graphics.DrawLine(blackPen, 50, line, 500, line);


                //TOTAL
                line += 15;
                ev.Graphics.DrawString("TOTAL", printFontTitulo, Brushes.Black, 70, line, new StringFormat());
                ev.Graphics.DrawString(venta.TotaVta.ToString("0.00"), printFontTitulo, Brushes.Black, 235, line, new StringFormat());
                line += 30;
                //CAE
                ev.Graphics.DrawString("CAE: " + venta.CAEVta, printFont, Brushes.Black, 70, line, new StringFormat());
                line += 15;
                //FECHA VTO
                ev.Graphics.DrawString("VTO. CAE: " + venta.FechVtoCAEVta.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 70, line, new StringFormat());
                line += 15;
                //Código QR
                string dataQR = "{\"ver\":1,\"fecha\":\"" + venta.FechVta.ToString("yyyy-MM-dd") + "\",\"cuit\":" + CUIT + ",\"ptoVta\":" + PtoVta + ",\"tipoCmp\":11,\"nroCmp\":" + venta.TicketFiscal + ",\"importe\":" + venta.TotaVta.ToString("0.00") + ",\"moneda\":\"PES\",\"ctz\":1,\"tipoDocRec\":80,\"nroDocRec\":" + cuitClie + ",\"tipoCodAut\":\"E\",\"codAut\":" + venta.CAEVta + "}";
                ev.Graphics.DrawImage(QrSys.GenerarCodigoQR(venta.CAEVta, dataQR), 50, line);
                line += 15;
                ev.Graphics.DrawString(lineaBlanco, printFont, Brushes.Black, 70, line, new StringFormat());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir");
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecibido.Text)) txtRecibido.Text = "0";
            if (string.IsNullOrEmpty(lblTotal.Text)) lblTotal.Text = "0";

            double total = Convert.ToDouble(lblTotal.Text);
            double recibido = Convert.ToDouble(txtRecibido.Text);

            total = recibido - total;

            lblVuelto.Text = Math.Round(total, 2).ToString();
        }

        void txtRecibido_GotFocus(object sender, EventArgs e)
        {
            txtRecibido.SelectionStart = 0;
            txtRecibido.SelectionLength = txtRecibido.Text.Length;
        }

        private void txtRecibido_Click(object sender, EventArgs e)
        {
            txtRecibido.SelectionStart = 0;
            txtRecibido.SelectionLength = txtRecibido.Text.Length;
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
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
