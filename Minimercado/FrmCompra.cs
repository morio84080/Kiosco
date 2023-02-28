using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Compras.Business;
using Compras.Entities;
using Localidad.Business;
using Proveedor.Business;
using Vendedor.Business;

namespace Minimercado
{
    public partial class FrmCompra : Form
    {
        private decimal nroCompra = 0;
        int lastAction = 0;
        CompraSystem comSys = new CompraSystem();
        CompraEntity compra = new CompraEntity();
        ProveedorBUS provBus = new ProveedorBUS();
        Articulo.Entities.ArticuloEntity arti;
        private int perfilId = 0;
        private List<CompraArticuloEntity> compraArticulo = new List<CompraArticuloEntity>();
        private List<CompraArticuloEntity> compraArticuloOld = new List<CompraArticuloEntity>();
        private double porcLista = 0;
        public FrmCompra()
        {
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {

            perfilId = new VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;
            lastAction = GlobalClass.ActionType;
            LlenarCboProveedor();

            if (GlobalClass.ActionType == 2)
            {
                GetCompraByID();
                CompleteFiles();
            }
            else
            {
                dtpFecha.Value = DateTime.Now;
                cboIVA.SelectedIndex = 0;
                cboProviders.Focus();
                
            }
        }

        private void LlenarCboProveedor()
        {
            if (provBus.LlenarComboProveedor(this.cboProviders) == -1)
                this.Hide();


            //if (GlobalClass.ActionType != 1)
            this.cboProviders.SelectedValue = -1;
        }


        private void getTotales()
        {

            try
            {
                double subtotal = Convert.ToDouble(txtSubtotal.Text);
                double retenciones = (string.IsNullOrEmpty(txtRetenciones.Text)?0:Convert.ToDouble(txtRetenciones.Text));
                double totalIva = 0;
                try {
                    totalIva = Math.Round((Convert.ToDouble(cboIVA.Text) / 100) * subtotal,2);
                }
                catch { totalIva = 0; }
                txtIVA.Text = totalIva.ToString();
                txtTotal.Text = Convert.ToString(subtotal+totalIva+retenciones);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obteniendo Totales --> " + ex.Message, "Error");
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
                    object sender = new object();
                    EventArgs e = new EventArgs();
                    txtCodBarra_LostFocus(sender,e);
                    txtCantidad.Focus();
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

        void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtCantidad.Focus();
                e.Handled = true;
            }
        }

        void txtCodBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.F6)
            {
                FrmArticuloList frm = new FrmArticuloList();
                frm.ShowDialog();
                obtenerArticulo();
                GlobalClass.ActionType = lastAction;
            }
            else if (e.KeyValue == 38)
            { txtCantidad.Focus(); }
            else if (e.KeyValue == 40)
            { txtPrecioUnitario.Focus(); }


        }

        void txtCodBarra_LostFocus(object sender, EventArgs e)
        {
            txtCodBarra.BackColor = Color.FromArgb(235,235,235);
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

        void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
            { txtPrecioUnitario.Focus(); }
            else if (e.KeyValue == 40)
            { txtCodBarra.Focus(); }
        }

        void txtArticulo_LostFocus(object sender, EventArgs e)
        {

            BuscarArticulo(0);
        }


        void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCantidad.Focus();
                e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }


        void txtCantidad_GotFocus(object sender, EventArgs e)
        {
            txtCantidad.SelectionStart = 0;
            txtCantidad.SelectionLength = txtCantidad.Text.Length;
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
                btnAgregar_Click(sender,e);
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
                txtCantidad.Focus();
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


        void txtPorcIVA_GotFocus(object sender, EventArgs e)
        {
            txtPorcIVA.SelectionStart = 0;
            txtPorcIVA.SelectionLength = txtPorcIVA.Text.Length;
        }

        void txtPorcIVA_Click(object sender, EventArgs e)
        {
            txtPorcIVA.SelectionStart = 0;
            txtPorcIVA.SelectionLength = txtPorcIVA.Text.Length;
        }

        void txtPorcIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCantidad.Focus();
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

        void txtPorcGanancia_GotFocus(object sender, EventArgs e)
        {
            txtPorcGanancia.SelectionStart = 0;
            txtPorcGanancia.SelectionLength = txtPorcGanancia.Text.Length;
        }

        void txtPorcGanancia_Click(object sender, EventArgs e)
        {
            txtPorcGanancia.SelectionStart = 0;
            txtPorcGanancia.SelectionLength = txtPorcGanancia.Text.Length;
        }

        void txtPorcGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCantidad.Focus();
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

        private void calcularPrecioVta()
        {
            try
            {
                double porGanancia = Convert.ToDouble(txtPorcGanancia.Text);
                double precioUnitario = Convert.ToDouble(txtPrecioUnitario.Text);
                double porcIVA = Math.Round((Convert.ToDouble(txtPorcIVA.Text) / 100), 3);
                double precioConIVA = precioUnitario + (precioUnitario * porcIVA);
                double precioVta = precioConIVA + (precioConIVA * (porGanancia / 100));
                txtPrecioVenta.Text = Math.Round(precioVta, 2).ToString();
            }
            catch { }
        }

        private void GetCompraByID()
        {
            try
            {
                compra= comSys.getCompraID(GlobalClass.IntPrimaryKey);
                nroCompra = compra.NumeComp;
                CompraArticuloEntity[] compArt = comSys.getCompArtByID(GlobalClass.IntPrimaryKey);
                foreach (CompraArticuloEntity compArticulo in compArt)
                {
                    compArticulo.PrecCoar = Math.Round(compArticulo.PrecCoar, 2);
                    compraArticulo.Add(compArticulo);
                    compraArticuloOld.Add(compArticulo);
                }
                ListarArticulos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Compra");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                dtpFecha.Value = compra.FechComp;
                cboProviders.SelectedValue = compra.ProveComp;
                txtObs.Text = compra.ObsComp;
                txtSubtotal.Text = Math.Round(compra.SubtotalComp, 2).ToString();
                txtTotal.Text = Math.Round(compra.TotalComp, 2).ToString();
                txtRetenciones.Text = Math.Round(compra.RetComp, 2).ToString();
                txtIVA.Text = Math.Round(compra.IvaComp, 2).ToString();
                double porcIVA = (compra.IvaComp * 100) / compra.SubtotalComp;
                //cboIVA.Text = Math.Round(porcIVA, 2).ToString();
                cboIVA.SelectedItem = Math.Round(porcIVA, 2).ToString();
                object sender = new object();
                EventArgs e = new EventArgs();
                btnHabilitar.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del compra");
                this.Hide();
            }
            finally
            {
                btnHabilitar.Focus();
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
       
        private void Insert()
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {
                    CompraEntity Ety = new CompraEntity();
                    Ety.ProveComp = Convert.ToInt32(cboProviders.SelectedValue);
                    Ety.FechComp = dtpFecha.Value;
                    Ety.SubtotalComp = Convert.ToDouble(txtSubtotal.Text);
                    Ety.TotalComp = Convert.ToDouble(txtTotal.Text);
                    Ety.IvaComp = Convert.ToDouble(txtIVA.Text);
                    Ety.RetComp = Convert.ToDouble(txtRetenciones.Text);
                    Ety.ObsComp = txtObs.Text;
                    nroCompra = comSys.ProcesarCompra(compraArticulo, Ety,checkBoxActualizar.Checked, GlobalClass.UserID);
                    MessageBox.Show("Registro guardado con éxito");
                    this.ClearFiles();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error grabando compra");
            }
        }

        private void Update()
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {
                    CompraEntity Ety = new CompraEntity();
                    Ety.NumeComp = compra.NumeComp;
                    Ety.ProveComp = Convert.ToInt32(cboProviders.SelectedValue);
                    Ety.FechComp = dtpFecha.Value;
                    Ety.SubtotalComp = Convert.ToDouble(txtSubtotal.Text);
                    Ety.TotalComp = Convert.ToDouble(txtTotal.Text);
                    Ety.IvaComp = Convert.ToDouble(txtIVA.Text);
                    Ety.RetComp = Convert.ToDouble(txtRetenciones.Text);
                    Ety.ObsComp = txtObs.Text;
                    comSys.ModificarCompra(compraArticulo, compraArticuloOld, Ety,checkBoxActualizar.Checked, GlobalClass.UserID);
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
            compraArticulo.Clear();
            dtpFecha.Value = DateTime.Now;
            //txtLocalidad.Text = string.Empty;
            txtSubtotal.Text = "0";
            txtTotal.Text ="0";
            txtIVA.Text = "0";
            txtObs.Text = string.Empty;
           
            ListarArticulos();
            groupBox3.Enabled = false;
            groupBox1.Enabled = true;
            cboProviders.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (cboProviders.SelectedIndex==0)
            {
                MessageBox.Show("Debe selecciona un proveedor", "ERROR");
                cboProviders.Focus();
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox3.Enabled = true;
                txtCodBarra.Focus();
            }

        }

        private void pBoxArticulos_Click(object sender, EventArgs e)
        {
            FrmArticuloList frm = new FrmArticuloList();
            frm.ShowDialog();
            obtenerArticulo();
            GlobalClass.ActionType = lastAction;
        }

        private void BuscarArticulo(int tipo)
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = "";
            try
            {

                arti = new Articulo.Business.ArticuloBUS().getArticuloPorCodBarra(txtCodBarra.Text);

                lblArticulo.Text = arti.DescArti;
                txtIdArticulo.Text = arti.IDArti.ToString();
                txtCodBarra.Text = arti.CoBaArti;
                txtPorcIVA.Text = Math.Round(arti.porcIVAArti,2).ToString();
                txtPorcGanancia.Text = Math.Round(arti.PorcGananciaArti,2).ToString();
                txtPrecioVenta.Text = Math.Round(arti.SugeArti,2).ToString();
                txtPrecioUnitario.Text = Convert.ToString(Math.Round(arti.BaseArti,2));                   
                txtCantidad.Text = "1";
            }
            catch
            {
                txtIdArticulo.Text = "0";
                lblArticulo.Text = "Articulo inexistente";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                CompraArticuloEntity entity = new CompraArticuloEntity();
                entity.CantCoar = Convert.ToInt32(txtCantidad.Text);
                entity.PrecCoar = Convert.ToDouble(txtPrecioUnitario.Text);
                entity.PorcIVA = Convert.ToDouble(txtPorcIVA.Text);
                entity.PorcGanancia = Convert.ToDouble(txtPorcGanancia.Text);
                entity.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                entity.DescArti = lblArticulo.Text.Trim();
                entity.IdArtiCoar = Convert.ToInt32(txtIdArticulo.Text);
                compraArticulo.Add(entity);
                ListarArticulos();
                double totalRemito = Convert.ToDouble(txtSubtotal.Text);
                totalRemito += Math.Round(entity.PrecCoar * entity.CantCoar, 2);
                txtSubtotal.Text = totalRemito.ToString();
                getTotales();
                limpiarSubCampos();
            }

        }       

        private void limpiarSubCampos()
        {
            txtCodBarra.Text = "0";
            txtIdArticulo.Text = "0";
            txtCantidad.Text = "0";
            txtPorcIVA.Text = "0";
            txtPorcGanancia.Text = "0";
            txtPrecioVenta.Text = "0";
            txtPrecioUnitario.Text = "0";
            lblArticulo.Text = "";
            txtCodBarra.Focus();
        }

        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtIdArticulo.Text) || txtIdArticulo.Text == "0")
            {
                MessageBox.Show("Artículo inexistente", "ERROR");
                txtCodBarra.Focus();
                return false;
            }
            else
            {
                foreach (CompraArticuloEntity arti in compraArticulo)
                {
                    if (Convert.ToInt32(txtIdArticulo.Text) == arti.IdArtiCoar)
                    {
                        MessageBox.Show("El articulo ya esta ingresado en el listado. Si desea agregar mas cantidad debe primero eliminarlo de la lista", "Advertencia");
                        txtCodBarra.Focus();
                        return false;
                    }
                }
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
            dtGView.DataSource = compraArticulo;
            dtGView.Columns[0].HeaderText = "Artículo";
            dtGView.Columns[1].Visible = false; //NumeCoar
            dtGView.Columns[2].Visible = false; //IdArtiCoar
            dtGView.Columns[3].HeaderText = "Cantidad";
            dtGView.Columns[3].Width = 20;
            dtGView.Columns[4].HeaderText = "P/Unit.";
            dtGView.Columns[4].Width = 20;
            dtGView.Columns[5].Visible = false; //TotaCoar           
            dtGView.Columns[6].Visible = false; //Porc IVA  
            dtGView.Columns[7].Visible = false; //Porc Ganancia
            dtGView.Columns[8].Visible = false; //Precio Venta

            dtGView.Refresh();
        }

        private void btnElminar_Click(object sender, EventArgs e)
        {
            if (dtGView.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dtGView.SelectedRows[0];
                int cantidad = Convert.ToInt32(currentRow.Cells[3].Value);
                int idArti = Convert.ToInt32(currentRow.Cells[2].Value);
                double precio = Convert.ToDouble(currentRow.Cells[4].Value);

                foreach (CompraArticuloEntity item in compraArticulo)
                {
                    if (item.IdArtiCoar == idArti && item.CantCoar == cantidad && item.PrecCoar == precio)
                    {
                        compraArticulo.Remove(item);

                        double totalRemito = Convert.ToDouble(txtSubtotal.Text);
                        totalRemito -= Math.Round(item.PrecCoar * item.CantCoar, 2);
                        txtSubtotal.Text = totalRemito.ToString();
                        getTotales();
                        break;
                    }
                }

                ListarArticulos();
            }
        }

        private void txtCodBarra_TextChanged(object sender, EventArgs e)
        {
            //BuscarArticulo(1);
           
        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            calcularPrecioVta();
        }

        private void cboIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTotales();
        }

        private void txtRetenciones_TextChanged(object sender, EventArgs e)
        {
            getTotales();            
        }

        void txtRetenciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //btnAceptar.Focus();
                //e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtPorcIVA_TextChanged(object sender, EventArgs e)
        {
            calcularPrecioVta();
        }

        private void txtPorcGanancia_TextChanged(object sender, EventArgs e)
        {
            calcularPrecioVta();
        }

        private void picNuevoCobrador_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = new FrmProveedor();
            frm.ShowDialog();
            LlenarCboProveedor();
            GlobalClass.ActionType = lastAction;
        }
    }
}
