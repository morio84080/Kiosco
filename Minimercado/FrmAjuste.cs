using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Stock.Business;
using Stock.Entities;
using Articulo.Business;
using Articulo.Entities;

namespace Minimercado
{
    public partial class FrmAjuste : Form
    {
        StockBUS Bus = new StockBUS();
        ArticuloBUS artBus = new ArticuloBUS();
        StockEntity Ety = new StockEntity();
        ArticuloEntity articulo = new ArticuloEntity();
        public FrmAjuste()
        {
            InitializeComponent();
        }

        private void FrmAjuste_Load(object sender, EventArgs e)
        {
            if (GlobalClass.ActionType == 2)
            {
                GetAjusteByID();
                CompleteFiles();
            }
            GlobalClass.artiGlobal = new ArticuloEntity();
            this.Activated += FrmAjuste_Activated;

        }

        void FrmAjuste_Activated(object sender, EventArgs e)
        {
            try {
                this.txtIdArticulo.Text = GlobalClass.artiGlobal.IDArti.ToString();
                this.txtRubro.Text = GlobalClass.artiGlobal.RubrArti.ToString();
                this.txtArticulo.Text = GlobalClass.artiGlobal.IDArti.ToString();
                this.txtArticulo_LostFocus(sender,e);
                if (txtRubro.Text == "0")
                    txtRubro.Focus();
                else if (txtRubro.Text == string.Empty)
                        btnArticulo.Focus();
                    else
                        this.txtCantidad.Focus();
            }
            catch {
                this.txtIdArticulo.Text = "0";
                this.txtRubro.Focus();
            }
        }


        private void GetAjusteByID()
        {
            try
            {
                Ety = Bus.getStockID(GlobalClass.IntPrimaryKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Obteniendo Ajuste");
                this.Hide();
            }
        }

        private void CompleteFiles()
        {
            try
            {
                this.txtCantidad.Text = Ety.CantidadSTK.ToString();
                this.txtIdArticulo.Text = Ety.ArticuloSTK.ToString();
                this.txtDetalle.Text = Ety.DetalleSTK;
                articulo = new ArticuloBUS().getArticuloID(Ety.ArticuloSTK);
                this.txtRubro.Text = articulo.RubrArti.ToString();
                this.txtArticulo.Text = articulo.IDArti.ToString(); //articulo.CodiArti.ToString();
                this.dtpFecha.Value = Ety.FechaSTK;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error completando datos del Ajuste");
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDetalle.Focus();
                e.Handled = true;
            }
        }

        private void txtRubro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtArticulo.Focus();
                e.Handled = true;
            }
        }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtCantidad.Focus();
                e.Handled = true;
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
                this.btnArticulo.Focus();
                e.Handled = true;
            }
        }


        private void txtArticulo_LostFocus(object sender, EventArgs e)
        {
            try
            {
                articulo = new ArticuloBUS().getByCodiAndRubro_DT(Convert.ToInt32(this.txtRubro.Text), Convert.ToInt32(this.txtArticulo.Text));
                if (articulo == null) throw new Exception();
                txtIdArticulo.Text = articulo.IDArti.ToString();
                lblArticulo.Text = articulo.DescArti;
            }
            catch {
                lblArticulo.Text = "Artículo inexistente";
                txtIdArticulo.Text = "0";
            }
        }


        void txtCantidad_GotFocus(object sender, EventArgs e)
        {
            txtCantidad.SelectionStart = 0;
            txtCantidad.SelectionLength = txtCantidad.Text.Length;
        }

        private void txtRubro_GotFocus(object sender, EventArgs e)
        {
            txtRubro.SelectionStart = 0;
            txtRubro.SelectionLength = txtRubro.Text.Length;
        }
        private void txtArticulo_GotFocus(object sender, EventArgs e)
        {
            txtArticulo.SelectionStart = 0;
            txtArticulo.SelectionLength = txtArticulo.Text.Length;
        }
        private void txtDetalle_GotFocus(object sender, EventArgs e)
        {
            txtDetalle.SelectionStart = 0;
            txtDetalle.SelectionLength = txtDetalle.Text.Length;            
        }

        void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectionStart = 0;
            txtCantidad.SelectionLength = txtCantidad.Text.Length;
        }

        void txtRubro_Click(object sender, EventArgs e)
        {
            txtRubro.SelectionStart = 0;
            txtRubro.SelectionLength = txtRubro.Text.Length;
        }

        void txtArticulo_Click(object sender, EventArgs e)
        {
            txtArticulo.SelectionStart = 0;
            txtArticulo.SelectionLength = txtArticulo.Text.Length;
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
                    StockEntity Ety = new StockEntity();
                    Ety.CantidadSTK = Convert.ToInt32(txtCantidad.Text);
                    Ety.ArticuloSTK = Convert.ToInt32(txtIdArticulo.Text);
                    Ety.DetalleSTK = txtDetalle.Text.Trim();
                    Ety.FechaSTK = dtpFecha.Value;
                    Ety.TipoIngresoSTK = (this.rdoBtnIngreso.Checked?false:true); //0 - Ingreso, 1 - Egreso
                    Ety.TipoMovSTK = 4; //Ajuste

                    Bus.StockInsert(Ety, GlobalClass.UserID);
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
                    //Ety.CantidadSTK = Convert.ToInt32(txtCantidad.Text);
                    //Ety.ArticuloSTK = Convert.ToInt32(txtIdArticulo.Text);
                    //Ety.DetalleSTK = txtDetalle.Text.Trim();
                    //Ety.FechaSTK = dtpFecha.Value;
                    //Ety.TipoIngresoSTK = false; //Ingreso
                    //Ety.TipoMovSTK = 2; //Ajuste

                    ////ruBus.AjusteUpdate(ruEty);
                    //MessageBox.Show("Registro Modificado con éxito");
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
            if (txtCantidad.Text == string.Empty)
            {
                MessageBox.Show("El campo Cantidad no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtCantidad.Focus();
            }
            else if (txtRubro.Text == string.Empty)
            {
                MessageBox.Show("El campo Rubro no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtRubro.Focus();
            }
            else if (txtArticulo.Text == string.Empty)
            {
                MessageBox.Show("El campo Articulo no puede estar vacio", "Dato Incorrecto");
                ret = 1;
                txtArticulo.Focus();
            }
            else if (txtIdArticulo.Text == "0" || txtIdArticulo.Text == string.Empty)
            {
                MessageBox.Show("Articulo incorrecto", "Dato Incorrecto");
                ret = 1;
                txtRubro.Focus();
            }

            int cant = 0;
            try
            {
                cant = Convert.ToInt32(txtCantidad.Text);
            }
            catch
            {
                MessageBox.Show("El campo cantidad debe ser numérico", "Dato Incorrecto");
                txtCantidad.Focus();
            }


            return ret;

        }

        private void ClearFiles()
        {
            txtCantidad.Text = string.Empty;
            txtArticulo.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            txtIdArticulo.Text = string.Empty;
            txtRubro.Text = string.Empty;
            lblArticulo.Text = string.Empty;
            GlobalClass.artiGlobal = new ArticuloEntity();
            dtpFecha.Value = DateTime.Now;
            btnArticulo.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            FrmArticuloList frm = new FrmArticuloList();
            frm.ShowDialog();
        }
        

    }
}
