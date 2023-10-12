using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Users.Business;
using Users.Entities;
using AFIP.Business;
using Stock.Business;

namespace Minimercado
{
    public partial class FrmMain : Form
    {
        public FrmPassword frmPadre = null;
        public FrmMain(FrmPassword padre)
        {           
            frmPadre = padre;
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, System.EventArgs e) 
        {
            int altoPantalla= Screen.PrimaryScreen.Bounds.Height; //Obtiene el alto de la pantalla principal en pixeles.
            int anchoPantalla= Screen.PrimaryScreen.Bounds.Width; //Obtiene el ancho de la pantalla principal en pixeles.

            Control c = this.tableLayoutPanel1.GetControlFromPosition(0, 0);
            tableLayoutPanel1.SetColumnSpan(c, 3);
            SetPermisos();

            bool stock = false;
            try
            {
              stock=  Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["stock"].ToString());
            }
            catch {}

            if (stock) {
                StockBUS stockBus = new StockBUS();
                int AlarmaStock = stockBus.AlarmaStockMinimo();
                if (AlarmaStock > 0)
                {
                    DialogResult dr = MessageBox.Show("Hay Productos que alcanzaron el Stock Mínimo, ¿Desea verlos?", "Alerta Stock Mínimo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    switch (dr)
                    {
                        case DialogResult.OK:
                            RptStockMinimo rpt = new RptStockMinimo();
                            rpt.ShowDialog();
                            break;
                    }
                }
            }


            //bool generaArchivosAFIP = false;

            //try {
            //    generaArchivosAFIP = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["generateFileAFIP"]);
            //}
            //catch { }

            //if (generaArchivosAFIP)
            //{
            //    GetaudarSystem getaudarSys = new GetaudarSystem();

            //    string[] res = getaudarSys.ProcessFiles().Split('|');

            //    if (res[0]=="1")
            //    {
            //        FrmProcessFilesAFIP frm = new FrmProcessFilesAFIP();
            //        frm.param1 = res[1];
            //        frm.param2 = res[2];
            //        frm.ShowDialog();
            //    }
            //}
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SetPermisos()
        {
            UsersBusiness usSystem = new UsersBusiness();
            UserEntity usEty = new UserEntity();

            try
            {
                usEty = usSystem.getByUserName(GlobalClass.GlobalVar);
                GlobalClass.UserID = usEty.CodigoVend;

                this.lblUserOnline.Text = "Bienvenido, " + usEty.NombVend + ", " + usEty.ApelVend + ". Usted opera como: " + usEty.NombPerfil;
                if (usEty.PerfilVend != 0)
                {
                    //RUBROS
                    if (usSystem.ExistsAction(usEty.CodigoVend, 1) == 0)
                    { 
                        this.RecorrerEstructuraMenu(this.menuStrip, "tablasGeneralesToolStripMenuItem", "rubrosToolStripMenuItem");
                        this.btnRubro.Enabled = false;
                    }
                    //VENDEDORES
                    if (usSystem.ExistsAction(usEty.CodigoVend, 2) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "tablasGeneralesToolStripMenuItem", "vendedoresToolStripMenuItem");
                        this.btnVendedor.Enabled = false;
                    }
                    //LISTAS
                    if (usSystem.ExistsAction(usEty.CodigoVend, 3) == 0)
                    {
                        //this.RecorrerEstructuraMenu(this.menuStrip, "tablasGeneralesToolStripMenuItem", "listasToolStripMenuItem");
                        //this.btnLista.Enabled = false;
                    }
                    //LOCALIDADES
                    if (usSystem.ExistsAction(usEty.CodigoVend, 4) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "tablasGeneralesToolStripMenuItem", "localidadesToolStripMenuItem");
                        this.btnLocalidad.Enabled = false;
                    }
                    //CLIENTES
                    if (usSystem.ExistsAction(usEty.CodigoVend, 5) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "tablasGeneralesToolStripMenuItem", "clientesToolStripMenuItem");
                        this.btnCliente.Enabled = false;
                    }
                    //ARTICULOS
                    if (usSystem.ExistsAction(usEty.CodigoVend, 6) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "tablasGeneralesToolStripMenuItem", "artículosToolStripMenuItem");
                        this.btnArticulos.Enabled = false;
                    }
                    //COMPRA ARTICULO
                    if (usSystem.ExistsAction(usEty.CodigoVend, 7) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "stockToolStripMenuItem", "compraArticuloToolStripMenuItem");
                        this.btnCompra.Enabled = false;
                    }
                    //AJUSTE DE STOCK
                    if (usSystem.ExistsAction(usEty.CodigoVend, 8) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "stockToolStripMenuItem", "ajusteManualToolStripMenuItem");
                        //this.btnArticulos.Enabled = false;
                    }
                    //VENTA ARTICULO
                    if (usSystem.ExistsAction(usEty.CodigoVend, 9) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "ventaToolStripMenuItem", "ventaArtículosToolStripMenuItem");
                        this.btnVenta.Enabled = false;
                    }
                    //CUENTA CORRIENTE
                    if (usSystem.ExistsAction(usEty.CodigoVend, 10) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "cuentacorrienteToolStripMenuItem", "obtenerCuentaToolStripMenuItem");
                        this.btnCtaCte.Enabled = false;
                    }
                    //PAGOS
                    if (usSystem.ExistsAction(usEty.CodigoVend, 11) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "cuentacorrienteToolStripMenuItem", "pagosToolStripMenuItem");
                        this.btnInformes.Enabled = false;
                    }
                    //INFORMES
                    if (usSystem.ExistsAction(usEty.CodigoVend, 12) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "reportesToolStripMenuItem", "generarToolStripMenuItem");
                        this.btnInformes.Enabled = false;
                    }

                    //INFORMES
                    if (usSystem.ExistsAction(usEty.CodigoVend, 13) == 0)
                    {
                        this.RecorrerEstructuraMenu(this.menuStrip, "cajaToolStripMenuItem", "cierresToolStripMenuItem");
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error obteniendo perfil de usuario");
                this.Close();
            }
        }

        private void RecorrerEstructuraMenu(MenuStrip oMenu, string Opcion, string sOpcion)
        {
            // en este método recorremos las opciones de la barra
            // principal (el primer nivel) de la colección de elementos
            // del menú del formulario
            foreach (ToolStripMenuItem oOpcionMenu in this.menuStrip.Items)
            {
                // si una opción de menú de la barra de primer nivel
                // tiene a su vez opciones, llamar a otro método que
                // será el que recorra estas subopciones
                if (oOpcionMenu.Name == Opcion)
                    if (oOpcionMenu.DropDownItems.Count > 0)
                        this.RecorrerSubmenu(oOpcionMenu.DropDownItems, sOpcion);
            }

        }

        private void RecorrerSubmenu(ToolStripItemCollection oSubmenuItems, string sOpcion)
        {
            //en este método recorremos las opciones de nivel inferior
            //de una opción de menú principal, y si alguna de estas opciones
            //tiene a su vez submenús, volvemos a llamar recursivamente a
            //este método para ir profundizando en el siguiente nivel,
            //y así sucesivamente
            foreach (ToolStripMenuItem oSubitem in oSubmenuItems)
            {
                // si encontramos la opción que necesitamos, habilitarla
                if (oSubitem.Name == sOpcion)
                    oSubitem.Visible = false;

                if (oSubitem.DropDownItems.Count > 0)
                    this.RecorrerSubmenu(oSubitem.DropDownItems, sOpcion);
            }
        }

        private void rubrosToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (btnRubro.Enabled)
            { 
                FrmRubroList frm = new FrmRubroList();
                frm.ShowDialog();
            }
        }

        private void btnRubro_Click(object sender, EventArgs e)
        {
            FrmRubroList frm = new FrmRubroList();
            frm.ShowDialog();
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnVendedor.Enabled)
            {
                FrmVendedorList frm = new FrmVendedorList();
                frm.ShowDialog();
            }

        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            FrmVendedorList frm = new FrmVendedorList();
            frm.ShowDialog();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnLocalidad.Enabled)
            {
                FrmLocalidadList frm = new FrmLocalidadList();
                frm.ShowDialog();
            }
        }

        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            FrmLocalidadList frm = new FrmLocalidadList();
            frm.ShowDialog();
        }

        private void listasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            FrmListaList frm = new FrmListaList();
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnCliente.Enabled)
            {
                FrmClienteList frm = new FrmClienteList();
                frm.ShowDialog();
            }


        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClienteList frm = new FrmClienteList();
            frm.ShowDialog();
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (btnArticulos.Enabled)
            {
                FrmArticuloList frm = new FrmArticuloList();
                frm.ShowDialog();
            }
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            FrmArticuloList frm = new FrmArticuloList();
            frm.ShowDialog();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            FrmCompraList frm = new FrmCompraList();
            frm.ShowDialog();
            //MessageBox.Show("en construcción...");
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmVenta frm = new FrmVenta();
            frm.ShowDialog();            
        }

        private void compraArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnCompra.Enabled)
            {
                FrmCompraList frm = new FrmCompraList();
                frm.ShowDialog();
            }
        }

        private void ajusteManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ajusteManualToolStripMenuItem.Enabled)
            {
                FrmAjusteList frm = new FrmAjusteList();
                frm.ShowDialog();
            }
        }

        private void btnCtaCte_Click(object sender, EventArgs e)
        {
            RptCtaCteClientePage frm = new RptCtaCteClientePage();
            frm.ShowDialog();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnPagos.Enabled)
            {
                FrmPagoClieList frm = new FrmPagoClieList();
                frm.ShowDialog();
            }
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            FrmPagoClieList frm = new FrmPagoClieList();
            frm.ShowDialog();
        }

        private void ventaArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmVenta frm = new FrmVenta();
            frm.ShowDialog(); 
        }

        private void obtenerCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnCtaCte.Enabled)
            {
                FrmCtaCteList frm = new FrmCtaCteList();
                frm.ShowDialog();
            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            if (btnInformes.Enabled)
            {
                FrmInformes frm = new FrmInformes();
                frm.ShowDialog();
            }
        }

        private void btnRecRegistros_Click(object sender, EventArgs e)
        {
            FrmHasar frm = new FrmHasar();
            frm.ShowDialog();

        }

        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnInformes.Enabled)
            {
                FrmInformes frm = new FrmInformes();
                frm.ShowDialog();
            }

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAjusteManual_Click(object sender, EventArgs e)
        {
            FrmPrecioList frm = new FrmPrecioList();
            frm.ShowDialog();
        }

        private void recuperarRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmImpresoraFiscal frm = new FrmImpresoraFiscal();
            FrmHasar frm = new FrmHasar();
            frm.ShowDialog();
        }

        private void imprimirPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrecioList frm = new FrmPrecioList();
            frm.ShowDialog();
        }

        private void listarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentaList frm = new FrmVentaList();
            frm.ShowDialog(); 
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProveedorList frm = new FrmProveedorList();
            frm.ShowDialog();

        }

        private void testImpresoraFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTestImpresoraFiscal frm = new FrmTestImpresoraFiscal();
            frm.Show();
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalClass.tipoCaja = false;
            FrmCajaList frm = new FrmCajaList();
            frm.ShowDialog();
        }

        private void egresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalClass.tipoCaja = true;
            FrmCajaList frm = new FrmCajaList();
            frm.ShowDialog();
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalClass.IntPrimaryKey = 0;
            FrmMovCajaList frm = new FrmMovCajaList();
            frm.ShowDialog();
        }

        private void cierresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCierreCajaList frm = new FrmCierreCajaList();
            frm.ShowDialog();
        }

        private void filesAFIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFileAFIP frm = new FrmFileAFIP();
            frm.Show();
        }

        private void testFactElectrónicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTest_FactElectronica frm = new FrmTest_FactElectronica();
            frm.ShowDialog();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarcaList frm = new FrmMarcaList();
            frm.ShowDialog();
        }
    }
}
