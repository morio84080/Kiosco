using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulo.Business;
using Articulo.Entities;
using Rubros.Business;
using Marcas.Business;
using Movimiento.Business;

namespace Minimercado
{
    public partial class FrmArticulo : Form
    {
        ArticuloBUS Bus = new ArticuloBUS();
        ArticuloEntity Ety = new ArticuloEntity();
        ArticuloEntity oldEty = new ArticuloEntity();
        RubroBusiness rubroBus = new RubroBusiness();
        MarcaBusiness marcaBus = new MarcaBusiness();
        MovimientoBus movBus = new MovimientoBus();
        bool close = false;
        int codRubro = 0;
        int codArti = 0;
        int actionType = 1;
        int calculo = 0;


        private bool formLoad;
        public FrmArticulo()
        {
            InitializeComponent();
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            LlenarCboRubro();
            LlenarCboMarca();
            actionType = GlobalClass.ActionType;
            if (GlobalClass.ActionType == 2)
            {
                GetArticuloByID();
                CompleteFiles();
                txtStock.Enabled = false;
                label6.Text = "Stock Actual";
                
            }
            else
            {
                label6.Text = "Stock Inicial";
                txtStock.Enabled = true;
            }
            txtCodBarra.Focus();
            
        }

        void FrmArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                close = true;
                this.Close();
                this.Dispose();                
            }
        }

        void FrmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        void FrmArticulo_Activated(object sender, EventArgs e)
        {
            formLoad = true;

            if (GlobalClass.ActionType == 2)
                this.txtCodBarra.Focus();
            else
                this.cboRubro.Focus();
        }

        private void LlenarCboRubro()
        {
            if (rubroBus.LlenarComboRubro(this.cboRubro) == -1)
                this.Close();

            //if (GlobalClass.ActionType != 1)
            //    this.cboRubro.SelectedValue = Ety.RubrArti;

        }

        private void LlenarCboMarca()
        {
            if (marcaBus.LlenarComboMarca(this.cboMarca) == -1)
                this.Close();

            //if (GlobalClass.ActionType != 1)
            //    this.cboRubro.SelectedValue = Ety.RubrArti;

        }

        private void GetArticuloByID()
        {
            try
            {
                oldEty = Bus.getArticuloID(GlobalClass.IntPrimaryKey);
                Ety.BaseArti = oldEty.BaseArti;
                Ety.CoBaArti = oldEty.CoBaArti;
                Ety.DescArti = oldEty.DescArti;
                Ety.EstaArti = oldEty.EstaArti;
                Ety.PorcGananciaArti = oldEty.PorcGananciaArti;
                Ety.IDArti = oldEty.IDArti;
                Ety.RubrArti = oldEty.RubrArti;
                Ety.StockArti = oldEty.StockArti;
                Ety.SugeArti = oldEty.SugeArti;
                Ety.porcIVAArti = oldEty.porcIVAArti;

                try {
                    //txtLastUpdate.Text = movBus.getLastMovementUpdatedByProduct(Ety.IDArti).FechaMovi.ToString("dd-MM-yyyy");
                    txtLastUpdate.Text = Ety.FechaUpdArti.ToString("dd/MM/yyyy");
                }
                catch {
                    txtLastUpdate.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Articulo");
                this.Hide();
            }
        }

        private int GetArticuloByBarCode()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodBarra.Text.Trim()))
                {
                    oldEty = Bus.getArticuloPorCodBarra(txtCodBarra.Text.Trim());
                    if (oldEty != null)
                    {
                        if (GlobalClass.ActionType == 1)
                        {
                            DialogResult dr = MessageBox.Show("¿Ya existe un artículo con ese código de barra desea modificarlo?", "Alta artículo", MessageBoxButtons.OKCancel);
                            switch (dr)
                            {
                                case DialogResult.OK:
                                    GlobalClass.ActionType = 2;
                                    break;
                                case DialogResult.Cancel:
                                    return 0;
                                    break;
                            }

                        }
                        Ety.BaseArti = oldEty.BaseArti;
                        Ety.CoBaArti = oldEty.CoBaArti;
                        Ety.DescArti = oldEty.DescArti;
                        Ety.EstaArti = oldEty.EstaArti;
                        Ety.PorcGananciaArti = oldEty.PorcGananciaArti;
                        Ety.IDArti = oldEty.IDArti;
                        Ety.RubrArti = oldEty.RubrArti;
                        Ety.StockArti = oldEty.StockArti;
                        Ety.SugeArti = oldEty.SugeArti;
                        Ety.porcIVAArti = oldEty.porcIVAArti;
                        CompleteFiles();
                        return 1;

                    }
                    else
                    {
                        if (GlobalClass.ActionType == 2)
                        {
                            //MessageBox.Show("Artículo inexistente", "Modificar Artículo");
                            //txtCodBarra.Focus();
                            //return 0;
                            oldEty = Bus.getArticuloID(GlobalClass.IntPrimaryKey);
                            return 1;
                        }
                        else
                            return 1;
                    }

                }
                else
                {
                        return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Articulo");
                return 0;
            }
            
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtCodBarra.Text = oldEty.CoBaArti.ToString();
                this.txtDesc.Text = oldEty.DescArti.ToString();
                this.txtPrecioBase.Text = Math.Round(oldEty.BaseArti, 2).ToString();
                this.txtPrecioVta.Text =  Math.Round(oldEty.SugeArti,2).ToString();
                this.txtStock.Text = oldEty.StockArti.ToString();
                this.txtStockMínimo.Text = oldEty.StockMinArti.ToString();
                this.txtCodigo.Text = oldEty.IDArti.ToString();
                this.txtGanancia.Text = Math.Round(oldEty.PorcGananciaArti, 2).ToString();
                this.txtIVA.Text = Math.Round(oldEty.porcIVAArti, 2).ToString();
                codRubro = oldEty.RubrArti;
                cboRubro.SelectedValue = oldEty.RubrArti;
                cboMarca.SelectedValue = oldEty.MarcaArti;
                try
                {
                    //txtLastUpdate.Text = movBus.getLastMovementUpdatedByProduct(Ety.IDArti).FechaMovi.ToString("dd-MM-yyyy");
                    txtLastUpdate.Text=oldEty.FechaUpdArti.ToString("dd-MM-yyyy");
                }
                catch {
                    txtLastUpdate.Text = "";
                }

                this.txtDesc.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Articulo");
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
            GlobalClass.ActionType = actionType;

        }
        
        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPrecioBase.Focus();
                e.Handled = true;
            }
        }

        void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //int res = 1;
                ////if (GlobalClass.ActionType == 2)                
                //    res= GetArticuloByBarCode();
                
                //if (res == 1)
                    this.txtDesc.Focus();
                //else
                //    this.txtCodBarra.Focus();
                e.Handled = true;
            }
            //else
            //{

            //    if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            //}
            
        }

        void txtCodBarra_GotFocus(object sender, EventArgs e)
        {
            lblMensaje.Visible = true;
        }

        void txtCodBarra_LostFocus(object sender, EventArgs e)
        {
            if (close == false)
            {
                lblMensaje.Visible = false;
                txtCodBarra.SelectionStart = 0;
                txtCodBarra.SelectionLength = txtCodBarra.Text.Length;
                int res = 1;
                //if (GlobalClass.ActionType == 2)                
                res = GetArticuloByBarCode();

                if (res == 1)
                    this.txtDesc.Focus();
                else
                    this.txtCodBarra.Focus();
            }
        }

        void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtStockMínimo.Focus();
                e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }


        void txtPrecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtGanancia.Focus();
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

        void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPrecioVta.Focus();
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

        void txtGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (GlobalClass.ActionType == 2)
                    btnAceptar.Focus();
                else
                    this.txtIVA.Focus();

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

        private void txtDesc_LostFocus(object sender, EventArgs e)
        {
            txtDesc.SelectionStart = 0;
            txtDesc.SelectionLength = txtDesc.Text.Length;
        }
        

        void txtPrecioBase_LostFocus(object sender, EventArgs e)
        {
            txtPrecioBase.SelectionStart = 0;
            txtPrecioBase.SelectionLength = txtPrecioBase.Text.Length;
            //calcularPrecioVta();
        }

        void txtIVA_LostFocus(object sender, EventArgs e)
        {
            txtIVA.SelectionStart = 0;
            txtIVA.SelectionLength = txtIVA.Text.Length;
            calcularPrecioVta();
        }

        void txtGanancia_LostFocus(object sender, EventArgs e)
        {
            txtGanancia.SelectionStart = 0;
            txtGanancia.SelectionLength = txtGanancia.Text.Length;
            //calcularPrecioVta();
        }

        void txtStock_LostFocus(object sender, EventArgs e)
        {
            txtStock.SelectionStart = 0;
            txtStock.SelectionLength = txtStock.Text.Length;
        }



        private void Insert()
        {
            try
            {
                if (this.verifyInfo() == 0)
                {
                    ArticuloEntity aEty = new ArticuloEntity();
                    aEty.CoBaArti = txtCodBarra.Text;
                    aEty.DescArti = txtDesc.Text.Trim();
                    aEty.RubrArti = Convert.ToInt32(cboRubro.SelectedValue);
                    aEty.MarcaArti = Convert.ToInt32(cboMarca.SelectedValue);
                    aEty.BaseArti = Convert.ToDouble(txtPrecioBase.Text.Replace('.',','));
                    aEty.SugeArti = Convert.ToDouble(txtPrecioVta.Text.Replace('.', ','));
                    aEty.PorcGananciaArti = Convert.ToDouble(txtGanancia.Text.Replace('.', ','));
                    aEty.porcIVAArti = Convert.ToDecimal(txtIVA.Text.Replace('.', ','));
                    aEty.StockArti = Convert.ToInt32(txtStock.Text);
                    aEty.StockMinArti = Convert.ToInt32(txtStockMínimo.Text);
                    Bus.ArticuloInsert(aEty,GlobalClass.UserID);
                    MessageBox.Show("Registro Agregado con éxito");
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
                    Ety.CoBaArti = txtCodBarra.Text;
                    Ety.DescArti = txtDesc.Text.Trim();
                    Ety.RubrArti = Convert.ToInt32(cboRubro.SelectedValue);
                    Ety.MarcaArti = Convert.ToInt32(cboMarca.SelectedValue);
                    Ety.BaseArti = Convert.ToDouble(txtPrecioBase.Text.Replace('.', ','));
                    Ety.SugeArti = Convert.ToDouble(txtPrecioVta.Text.Replace('.', ','));
                    Ety.PorcGananciaArti = Convert.ToDouble(txtGanancia.Text.Replace('.', ','));
                    Ety.porcIVAArti = Convert.ToDecimal(txtIVA.Text.Replace('.', ','));
                    Ety.StockArti = Convert.ToInt32(txtStock.Text);
                    Ety.PrintArti = true;
                    Ety.StockMinArti = Convert.ToInt32(txtStockMínimo.Text);
                    Bus.ArticuloUpdate(Ety, oldEty, GlobalClass.UserID);
                    MessageBox.Show("Registro Modificado con éxito");
                    //this.Hide();
                    this.ClearFiles();
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
            if (Convert.ToInt32( cboRubro.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar un rubro", "Dato Incorrecto");
                ret = 1;
                cboRubro.Focus();
            }
            else if (txtCodBarra.Text == string.Empty)
            {
                MessageBox.Show("El campo Código de Barra no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtCodBarra.Focus();
            }
            else if (txtDesc.Text == string.Empty)
            {
                MessageBox.Show("El campo Descripción de Artículo no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtDesc.Focus();
            }
            else if (txtIVA.Text == string.Empty)
            {
                MessageBox.Show("El campo % IVA no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtIVA.Focus();
            }
            else if (txtPrecioBase.Text == string.Empty)
            {
                MessageBox.Show("El campo Precio Base no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtPrecioBase.Focus();
            }
            else if (txtGanancia.Text == string.Empty)
            {
                MessageBox.Show("El campo % Ganancia no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtGanancia.Focus();
            }
            //else if (txtPrecioSugerido.Text == string.Empty)
            //{
            //    MessageBox.Show("El campo Precio Sugerido no puede estar vacio", "Dato Incorrecto");
            //    ret = 1;
            //    txtPrecioSugerido.Focus();
            //}
            else if (txtStock.Text == string.Empty)
            {
                MessageBox.Show("El campo Stock Actual no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtStock.Focus();
            }
            else
            {
                try { d = Convert.ToDouble(txtPrecioBase.Text.Replace('.', ',')); }
                catch
                {
                    MessageBox.Show("El campo Precio Base debe ser numérico", "Dato Incorrecto");
                    ret = 1;
                    txtPrecioBase.Focus();
                }

                //try { d = Convert.ToDouble(txtPrecioSugerido.Text.Replace('.', ',')); }
                //catch
                //{
                //    MessageBox.Show("El campo Precio Sugerido debe ser numérico", "Dato Incorrecto");
                //    ret = 1;
                //    txtPrecioSugerido.Focus();
                //}

                try { d = Convert.ToInt32(txtStock.Text); }
                catch
                {
                    MessageBox.Show("El campo Stock Actual debe ser numérico", "Dato Incorrecto");
                    ret = 1;
                    txtStock.Focus();
                }
            }
            return ret;

        }

        private void ClearFiles()
        {
            GlobalClass.ActionType = actionType;
            txtCodBarra.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtPrecioBase.Text = "0";
            //txtPrecioSugerido.Text = "0";
            txtStock.Text = "0";
            txtStockMínimo.Text = "0";
            //txtCodigo.Text = "0";
            //cboRubro.SelectedIndex = 0;
            //cboRubro.Focus();
            obtenerCodRubro();
            //if (actionType == 1)
            //    this.txtCodigo.Text = Bus.ProximoCodigo(Convert.ToInt32(cboRubro.SelectedValue)).ToString();
            actionType = 1;
            GlobalClass.ActionType = 1;
            txtCodBarra.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void cboRubro_SelectedIndexChanged(object sender, EventArgs e)
        {

            obtenerCodRubro();
        }
        private void obtenerCodRubro()
        {
            if (formLoad)
            {
                //if (codRubro == Convert.ToInt32(cboRubro.SelectedValue))
                //    this.txtCodigo.Text = codArti.ToString();
                //else
                //    this.txtCodigo.Text = Bus.ProximoCodigo(Convert.ToInt32(cboRubro.SelectedValue)).ToString();

                txtGanancia.Text = rubroBus.getRubroID(Convert.ToInt32(cboRubro.SelectedValue)).PorcGananciaRubr.ToString();
            }
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

        private void calcularPrecioVta() {
        if (formLoad)
            try
            {
                if (calculo == 1 || calculo == 3)
                {
                        double porGanancia = Convert.ToDouble(txtGanancia.Text);
                        double precioUnitario = Convert.ToDouble(txtPrecioBase.Text);
                        //double porcIVA = Math.Round((Convert.ToDouble(txtIVA.Text) / 100), 3);
                        //double precioConIVA = precioUnitario + (precioUnitario * porcIVA);
                        //double precioVta = precioConIVA + (precioConIVA * (porGanancia / 100));                
                        //ES PRECIO DE COSTO (CON IVA INCLUIDO)
                        double precioVta = precioUnitario + (precioUnitario * (porGanancia / 100));
                        txtPrecioVta.Text = Math.Round(precioVta, 0).ToString();

                        //Math.Round(importe, 2, MidpointRounding.AwayFromZero);
                 }

            }
            catch{}
            finally { calculo = 0; }

        }

        private void txtPrecioBase_TextChanged(object sender, EventArgs e)
        {
            if (calculo == 0) calculo = 3;
            calcularPrecioVta();
        }

        private void txtGanancia_TextChanged(object sender, EventArgs e)
        {
            if (calculo == 0) calculo = 3;
            calcularPrecioVta();
        }

        void txtIVA_TextChanged(object sender, EventArgs e)
        {
            calcularPrecioVta();
        }

        private void txtPrecioVta_TextChanged(object sender, EventArgs e)
        {
            if (calculo == 0) calculo = 2;
            calcularPorcGanancia();
        }

        private void calcularPorcGanancia()
        {
            if (formLoad)
                try
                {
                    if (calculo == 2)
                    {
                        if (string.IsNullOrEmpty(txtIVA.Text)) txtIVA.Text = "0";
                        if (string.IsNullOrEmpty(txtPrecioBase.Text)) txtPrecioBase.Text = "0";
                        if (string.IsNullOrEmpty(txtGanancia.Text)) txtGanancia.Text = "0";
                        if (string.IsNullOrEmpty(txtPrecioVta.Text)) txtPrecioVta.Text = "0";
                        decimal costo = (string.IsNullOrEmpty(txtPrecioBase.Text) ? 0 : Convert.ToDecimal(txtPrecioBase.Text) * (1 + ((Convert.ToDecimal(txtIVA.Text) / 100))));
                        decimal precioPesoVta = (string.IsNullOrEmpty(txtPrecioVta.Text) ? 0 : Convert.ToDecimal(txtPrecioVta.Text));
                        decimal porcGanancia = Math.Round(((precioPesoVta / costo) - 1) * 100, 2);
                        txtGanancia.Text = porcGanancia.ToString();
                    }
                    //Math.Round(importe, 2, MidpointRounding.AwayFromZero);
                }
                catch { }
                finally { calculo = 0; }

        }

        private void txtPrecioVta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
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

        private void cboRubro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                cboMarca.Focus();
            }
        }

        private void cboMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodBarra.Focus();
            }
        }

        private void txtStockMínimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.Focus();
                e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtStockMínimo_GotFocus(object sender, EventArgs e)
        {
            txtStockMínimo.SelectionStart = 0;
            txtStockMínimo.SelectionLength = txtStockMínimo.Text.Length;
        }

        private void picNuevoRubro_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmRubro frm = new FrmRubro();
            frm.ShowDialog();
            GlobalClass.ActionType = actionType;
            LlenarCboRubro();
        }

        private void picNuevaMarca_Click(object sender, EventArgs e)
        {
            GlobalClass.ActionType = 1;
            FrmMarca frm = new FrmMarca();
            frm.ShowDialog();
            GlobalClass.ActionType = actionType;
            LlenarCboMarca();
        }
    }
}
