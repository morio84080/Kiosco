using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulo.Entities;
using Articulo.Business;
using Rubros.Business;
using System.Drawing.Printing;
using System.Data.Common;

 

namespace Minimercado
{
    public partial class FrmPrecioList : Form
    {
        string printName = System.Configuration.ConfigurationSettings.AppSettings["printName"].ToString();
        ArticuloBUS Bus = new ArticuloBUS();
        RubroBusiness rubroBUS = new RubroBusiness();
        private bool frmActivate = false;
        private int perfilId = 0;
        string listRubros = string.Empty;
        int cnt = 0;
        // Draw title 
        String drawArticulo = string.Empty;
        String drawImporte = string.Empty;

        String drawArticulo2 = string.Empty;
        String drawImporte2 = string.Empty;

        String drawArticulo3 = string.Empty;
        String drawImporte3 = string.Empty;

        String drawArticulo4 = string.Empty;
        String drawImporte4 = string.Empty;

        public FrmPrecioList()
        {
            InitializeComponent();            
        }

        private void FrmPrecioList_Load(object sender, EventArgs e)
        {
            perfilId = new Vendedor.Business.VendedorBusiness().getVendedorID(GlobalClass.UserID).PerfilVend;

            cboDiseñoImpresion.SelectedIndex = 0;
            LlenarCboRubro();
            try
            {
                printDocument1.PrinterSettings.PrinterName = printName;
                if (GlobalClass.CodiRubro > 0)
                {
                    //cboRubro.SelectedItem = GlobalClass.CodiRubro;
                    cboRubro.SelectedValue = GlobalClass.CodiRubro;
                }
                ArticulosParaImprimir();
            }
            catch { }
        }

        void dtGView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dtGView.SelectedRows.Count > 0)
                {


                    //DataGridViewRow currentRow = dtGView.SelectedRows[0];

                    //GlobalClass.artiGlobal = new ArticuloEntity();

                    //GlobalClass.artiGlobal.BaseArti = Convert.ToInt32(currentRow.Cells[5].Value);
                    //GlobalClass.artiGlobal.CoBaArti = currentRow.Cells[3].Value.ToString();
                    //GlobalClass.artiGlobal.CodiArti = Convert.ToInt32(currentRow.Cells[2].Value);
                    //GlobalClass.artiGlobal.DescArti = currentRow.Cells[4].Value.ToString();
                    //GlobalClass.artiGlobal.IDArti = Convert.ToInt32(currentRow.Cells[8].Value);
                    //GlobalClass.artiGlobal.RubrArti = Convert.ToInt32(currentRow.Cells[0].Value);
                    //GlobalClass.artiGlobal.StockArti = Convert.ToInt32(currentRow.Cells[6].Value);
                    ////GlobalClass.artiGlobal.SugeArti = Convert.ToInt32(currentRow.Cells[6].Value);
                }
            }
            catch { }
            this.Close();
        }

        void dtGView_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
                try
                {
                    lblArticulo.Text = lblArticulo.Text.Substring(0, lblArticulo.Text.Length - 1);
                }
                catch { }
            else if ((e.KeyChar >= 39 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 164 || e.KeyChar == 165 || e.KeyChar == 209 || e.KeyChar == 241) lblArticulo.Text += Convert.ToChar(e.KeyChar);

            ArticulosPorDesc();
        }

        void dtGView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //int row = dtGView.CurrentCell.RowIndex;
                //dtGView.CurrentCell = dtGView.Rows[row].Cells[6];

                try
                {
                    if (dtGView.SelectedRows.Count > 0)
                    {


                        //DataGridViewRow currentRow = dtGView.SelectedRows[0];

                        //GlobalClass.artiGlobal = new ArticuloEntity();

                        //GlobalClass.artiGlobal.BaseArti = Convert.ToInt32(currentRow.Cells[5].Value);
                        //GlobalClass.artiGlobal.CoBaArti = currentRow.Cells[3].Value.ToString();
                        //GlobalClass.artiGlobal.CodiArti = Convert.ToInt32(currentRow.Cells[2].Value);
                        //GlobalClass.artiGlobal.DescArti = currentRow.Cells[4].Value.ToString();
                        //GlobalClass.artiGlobal.IDArti = Convert.ToInt32(currentRow.Cells[8].Value);
                        //GlobalClass.artiGlobal.RubrArti = Convert.ToInt32(currentRow.Cells[0].Value);
                        //GlobalClass.artiGlobal.StockArti = Convert.ToInt32(currentRow.Cells[6].Value);
                        ////GlobalClass.artiGlobal.SugeArti = Convert.ToInt32(currentRow.Cells[6].Value);
                    }
                }
                catch { }
                this.Close();

            }
        }

        private void LlenarCboRubro()
        {
            if (rubroBUS.LlenarComboRubro(this.cboRubro) == -1)
                this.Hide();

            //if (GlobalClass.ActionType != 1)
            this.cboRubro.SelectedValue = -1;
        }

        void cboRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frmActivate) ArticulosPorRubro();
            //if (!checkBoxMantenerSeleccion.Checked)
            //{
            //listRubros = string.Empty;
            //ArticulosPorRubro();
            //}                    
            //else
            //{
            //    if (string.IsNullOrEmpty(listRubros))
            //        listRubros = cboRubro.SelectedValue.ToString();
            //    else
            //        listRubros+=","+ cboRubro.SelectedValue.ToString();

            //    ArticulosPorRubros(listRubros);

            //}
        }

        private void FrmPrecioList_Activated(object sender, EventArgs e)
        {
            //ListArticulos();
            frmActivate = true;
        }

        void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                getArticuloPorCodBarra();
                e.Handled = true;
            }
            else
            {

                if (!IsNumeric(e.KeyChar)) e.KeyChar = Convert.ToChar(0);
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

        private void getArticuloPorCodBarra()
        {
            ListArticulos(Bus.getByCodBarra_DT(txtCodBarra.Text.Trim()));
        }

        private void ArticulosParaImprimir()
        {
            ListArticulos(Bus.getByPrint_DT());
        }
        private void ArticulosPorRubro()
        {
            int valor = -1;
            try { valor= Convert.ToInt32(cboRubro.SelectedValue); } catch { }

            DataTable dt = new DataTable();

            checkBoxTodos.Checked = false;
            if (checkBoxMantenerSeleccion.Checked)
            {
                int v = 999;
                dt = Bus.getByRubrosParaPrint_DT(v);
                DataRow dr;
                int cnt = 0;
                while (cnt < dtGView.RowCount)
                {

                    if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[9].Value))
                    {
                        dr = dt.NewRow();
                        dr[0] = dtGView.Rows[cnt].Cells[0].Value;
                        dr[1] = dtGView.Rows[cnt].Cells[1].Value;
                        dr[2] = dtGView.Rows[cnt].Cells[2].Value;
                        dr[3] = dtGView.Rows[cnt].Cells[3].Value;
                        dr[4] = dtGView.Rows[cnt].Cells[4].Value;
                        dr[5] = dtGView.Rows[cnt].Cells[5].Value;
                        dr[6] = dtGView.Rows[cnt].Cells[6].Value;
                        dr[7] = dtGView.Rows[cnt].Cells[7].Value;
                        dr[8] = dtGView.Rows[cnt].Cells[8].Value;
                        dr[9] = dtGView.Rows[cnt].Cells[9].Value;
                        dr[10] = dtGView.Rows[cnt].Cells[10].Value;
                        dr[11] = dtGView.Rows[cnt].Cells[11].Value;
                        dr[12] = dtGView.Rows[cnt].Cells[12].Value;
                        dr[13] = dtGView.Rows[cnt].Cells[13].Value;

                        dt.Rows.Add(dr);
                    }
                    cnt++;
                }
                DataTable dt2 = new DataTable();
                dt2 = Bus.getByRubrosParaPrint_DT(valor);
                dt.Merge(dt2);
            }
            else
            {
                dt= Bus.getByRubrosParaPrint_DT(valor);
            }
            ListArticulos(dt);
        }

        private void ArticulosPorDesc()
        {
            ListArticulos(Bus.getByRubroAndLikeDesc_DT(lblArticulo.Text.Trim(), Convert.ToInt32(cboRubro.SelectedValue)));
        }
        private void ListArticulos(DataTable dt)
        {
            //dtGView.DataSource = Bus.getAllArticulos_DT();
            dtGView.DataSource = dt;

            
            dtGView.Columns[0].HeaderText = "ID";
            dtGView.Columns[0].ReadOnly = true;
            dtGView.Columns[0].Width = 50;

            dtGView.Columns[1].Visible = false; // cod. rubro

            dtGView.Columns[2].HeaderText = "Rubro";
            dtGView.Columns[2].ReadOnly = true;
            dtGView.Columns[2].Width = 140;

            dtGView.Columns[3].HeaderText = "Codigo Barra";

            dtGView.Columns[4].HeaderText = "Descripción";
            dtGView.Columns[4].Width = 280;

            dtGView.Columns[5].HeaderText = "Precio Lista $";
            dtGView.Columns[5].DefaultCellStyle.Format = "$ #,#.##";

            dtGView.Columns[6].HeaderText = "Precio Venta $";
            dtGView.Columns[6].DefaultCellStyle.Format = "$ #,#.##";

            dtGView.Columns[7].HeaderText = "Stock Actual";
            dtGView.Columns[8].Visible = false; // Estado
            dtGView.Columns[9].HeaderText = "Imprime";
            dtGView.Columns[9].Width = 50;
            dtGView.Columns[10].Visible = false; // Porc. iva
            dtGView.Columns[11].Visible = false; // Porc. ganancia
            dtGView.Columns[12].Visible = false; // stock minimo
            dtGView.Columns[13].Visible = false; //bit de seleccion


            //dtGView.Refresh();

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow fila in dtGView.Rows)
            //{ 
            //    if (Convert.ToBoolean(fila.Cells[9].Value))
            //    {
            //        MessageBox.Show(fila.Cells[4].Value.ToString());
            //    }
            //}
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            ArticulosPorDesc();            
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            bool error = false;

            try
            {
                PaperSize paperZ = new PaperSize();
                float x = 0;
                float y = 0;
                float linesPerPage = 0;
                Font printFont;
                Font drawFont;
                Font drawFontFecha;
                Font drawFontLeyenda;
                Font drawFontPrecio;
                SolidBrush drawBrush;
                float colPerPage = 0;
                float lenghCuadro = 0;
                int yRect = 0;
                int xRect = 0;
                float y1 = 0;
                float y2 = 0;
                int i = 1;
                Rectangle rect;
                int fila = 1;
                int r = 1;

                //Dibujar un rectangulo
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                switch (cboDiseñoImpresion.SelectedIndex)
                {
                    case 0:
                        #region NORMAL
                        printDocument1.PrinterSettings.PrinterName = printName;
                        paperZ = printDocument1.DefaultPageSettings.PaperSize;
                        ev.PageSettings.PaperSize = paperZ;

                        // Calculamos el número de líneas que caben en cada página.
                        printFont = new Font("Arial", 12);
                        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                        colPerPage = ev.MarginBounds.Width;
                        lenghCuadro = colPerPage / 3;

                        // Create font and brush.                         
                        drawFont = new Font("Arial", 12);
                        drawFontPrecio = new Font("Eras Bold ITC", 28, FontStyle.Bold);

                        drawBrush = new SolidBrush(Color.Black);

                        y1 = 28.0F;//30.0F;
                        y2 = 75.0F;
                        lenghCuadro = ev.Graphics.MeasureString("12345678901234567890123456789", drawFont).Width;

                        while (fila <= 8 && cnt < dtGView.RowCount)
                        {

                            if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[9].Value))
                            {
                                drawArticulo = dtGView.Rows[cnt].Cells[4].Value.ToString();
                                drawImporte = "$ " + Math.Round(Convert.ToDecimal((dtGView.Rows[cnt].Cells[6].Value)), 2).ToString();
                                if (i > 3)
                                {
                                    int borrar1 = r;
                                    i = 1;
                                    yRect += 130;
                                    y1 += 130.0F;
                                    y2 += 130.0F;
                                    fila++;
                                }

                                if (fila <= 8)
                                {
                                    switch (i)
                                    {
                                        case 1: //Columna 1
                                            xRect = 0;
                                            break;
                                        case 2: //Columna 2
                                            xRect = 275;
                                            break;
                                        case 3: //Columna 3
                                            xRect = 550;
                                            break;

                                    }

                                    // Create rectangle. 
                                    rect = new Rectangle(xRect, yRect, 275, 130);
                                    // Draw rectangle to screen. 
                                    ev.Graphics.DrawRectangle(blackPen, rect);


                                    //***************************
                                    //Descripcion Articulo
                                    //***************************
                                    string[] palabras = drawArticulo.Split(' ');
                                    int caracteres = 0;
                                    string frase1 = string.Empty;
                                    string frase2 = string.Empty;
                                    bool saltoLinea = false;

                                    //PARTICIONA EN 2 RENGLONES LA DESCRIPCION DEL PRODUCTO************************
                                    foreach (var palabra in palabras)
                                    {
                                        caracteres += (palabra.Length + 1);
                                        if (caracteres >= 20)
                                        {
                                            frase2 += " " + palabra;
                                        }
                                        else frase1 += " " + palabra;
                                    }

                                    //**********************************************************************
                                    //IMPRIME LA FECHA ACTUAL
                                    //**********************************************************************
                                    PointF drawPoint = new PointF(xRect, y1 - 25.0F);
                                    //ev.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), drawFont, drawBrush, drawPoint);

                                    //FRASE 1*****************************************************************
                                    float textWidthPxl = ev.Graphics.MeasureString(frase1, drawFont).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y1);
                                    ev.Graphics.DrawString(frase1, drawFont, drawBrush, drawPoint);

                                    //FRASE 2*******************************************************************
                                    if (!string.IsNullOrEmpty(frase2))
                                    {
                                        if (frase2.Length > 20) frase2 = frase2.Substring(0, 20);
                                        textWidthPxl = ev.Graphics.MeasureString(frase2, drawFont).Width;
                                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                        drawPoint = new PointF(x, y1 + 20.0F);
                                        ev.Graphics.DrawString(frase2, drawFont, drawBrush, drawPoint);
                                    }

                                    //IMPORTE*************************************************************
                                    textWidthPxl = ev.Graphics.MeasureString(drawImporte, drawFontPrecio).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y2);
                                    ev.Graphics.DrawString(drawImporte, drawFontPrecio, drawBrush, drawPoint);
                                    //IMPORTE*************************************************************


                                    cnt++;
                                    i++;
                                    r++;
                                }
                            }
                            else cnt++;
                        }
                        #endregion
                        break;
                    case 1:
                        #region OFERTA
                        printDocument1.PrinterSettings.PrinterName = printName;

                        paperZ = printDocument1.DefaultPageSettings.PaperSize;
                        ev.PageSettings.PaperSize = paperZ;

                        // Calculamos el número de líneas que caben en cada página.
                        printFont = new Font("Arial", 12);

                        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                        colPerPage = ev.MarginBounds.Width;
                        lenghCuadro = colPerPage / 3;

                        // Create font and brush.                         
                        drawFont = new Font("Arial", 12);
                        drawFontFecha = new Font("Arial", 10);
                        drawFontLeyenda = new Font("Eras Bold ITC", 24, FontStyle.Bold);
                        drawFontPrecio = new Font("Eras Bold ITC", 30, FontStyle.Bold);

                        drawBrush = new SolidBrush(Color.Black);

                        y1 = 90.0F;//40.0F;//30.0F;                        
                        y2 = 133.0F;//82.0F;
                        lenghCuadro = ev.Graphics.MeasureString("12345678901234567890123456789012345678901234", drawFont).Width;


                        while (fila <= 6 && cnt < dtGView.RowCount)
                        {

                            if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[9].Value))
                            {
                                drawArticulo = dtGView.Rows[cnt].Cells[4].Value.ToString();
                                drawImporte = "$ " + Math.Round(Convert.ToDecimal((dtGView.Rows[cnt].Cells[6].Value)), 2).ToString();
                                if (i > 2)
                                {
                                    int borrar1 = r;
                                    i = 1;
                                    yRect += 193;//130;
                                    y1 += 193.0F;
                                    y2 += 193.0F;
                                    fila++;
                                }

                                if (fila <= 6)
                                {
                                    switch (i)
                                    {
                                        case 1: //Columna 1
                                            xRect = 0;
                                            break;
                                        case 2: //Columna 2
                                            xRect = 412;
                                            break;
                                    }

                                    // Create rectangle. 
                                    rect = new Rectangle(xRect, yRect, 412, 193);
                                    // Draw rectangle to screen. 
                                    ev.Graphics.DrawRectangle(blackPen, rect);


                                    //***************************
                                    //Descripcion Articulo
                                    //***************************
                                    string[] palabras = drawArticulo.Split(' ');
                                    int caracteres = 0;
                                    string frase1 = string.Empty;
                                    string frase2 = string.Empty;
                                    bool saltoLinea = false;

                                    //PARTICIONA EN 2 RENGLONES LA DESCRIPCION DEL PRODUCTO************************
                                    foreach (var palabra in palabras)
                                    {
                                        caracteres += (palabra.Length + 1);
                                        if (caracteres > 38)
                                        {
                                            frase2 += " " + palabra;
                                        }
                                        else frase1 += " " + palabra;
                                    }

                                    //**********************************************************************
                                    //IMPRIME LA FECHA ACTUAL
                                    //**********************************************************************
                                    PointF drawPoint = new PointF(xRect, y1 - 87.0F);
                                    //ev.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), drawFontFecha, drawBrush, drawPoint);

                                    //**********************************************************************
                                    //LEYENDA DE OFERTA
                                    //**********************************************************************
                                    drawPoint = new PointF(xRect, y1 - 56.0F);
                                    ev.Graphics.DrawString("***** O F E R T A *****", drawFontLeyenda, drawBrush, drawPoint);


                                    //FRASE 1*****************************************************************
                                    float textWidthPxl = ev.Graphics.MeasureString(frase1, drawFont).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y1);
                                    ev.Graphics.DrawString(frase1, drawFont, drawBrush, drawPoint);

                                    //FRASE 2*******************************************************************
                                    if (!string.IsNullOrEmpty(frase2))
                                    {
                                        if (frase2.Length > 38) frase2 = frase2.Substring(0, 38);
                                        textWidthPxl = ev.Graphics.MeasureString(frase2, drawFont).Width;
                                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                        drawPoint = new PointF(x, y1 + 20.0F);
                                        ev.Graphics.DrawString(frase2, drawFont, drawBrush, drawPoint);
                                    }

                                    //IMPORTE*************************************************************
                                    textWidthPxl = ev.Graphics.MeasureString(drawImporte, drawFontPrecio).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y2);
                                    ev.Graphics.DrawString(drawImporte, drawFontPrecio, drawBrush, drawPoint);
                                    //IMPORTE*************************************************************


                                    cnt++;
                                    i++;
                                    r++;
                                }
                            }
                            else cnt++;
                        }
                        #endregion
                        break;
                }    

                if (cnt < dtGView.RowCount) ev.HasMorePages = true;

            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show(ex.Message, "Error imprimiendo");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            try
            {
                PaperSize paperZ = new PaperSize();
                float x = 0;
                float y = 0;
                float linesPerPage = 0;
                Font printFont;
                Font drawFont;
                Font drawFontPrecio;
                Font drawFontFecha;
                Font drawFontLeyenda;
                SolidBrush drawBrush;
                float colPerPage = 0;
                float lenghCuadro=0;
                int yRect = 0;
                int xRect = 0;
                float y1 = 0;
                float y2 = 0;
                int i = 1;
                Rectangle rect;
                int fila = 1;
                int r = 1;

                //Dibujar un rectangulo
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                switch (cboDiseñoImpresion.SelectedIndex)
                { 
                    case 0:
                        #region NORMAL
                        printDocument1.PrinterSettings.PrinterName = printName;
                        paperZ = printDocument1.DefaultPageSettings.PaperSize;
                        e.PageSettings.PaperSize = paperZ;

                        // Calculamos el número de líneas que caben en cada página.
                        printFont = new Font("Arial", 12);
                        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                        colPerPage = e.MarginBounds.Width;
                        lenghCuadro = colPerPage / 3;

                        // Create font and brush.                         
                        drawFont = new Font("Arial", 12);
                        drawFontPrecio = new Font("Eras Bold ITC", 28, FontStyle.Bold);

                        drawBrush = new SolidBrush(Color.Black);

                        y1 = 28.0F;//30.0F;
                        y2 = 75.0F;
                        lenghCuadro = e.Graphics.MeasureString("12345678901234567890123456789", drawFont).Width;

                        while (fila <= 8 && cnt < dtGView.RowCount)
                        {

                            if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[9].Value))
                            {
                                drawArticulo = dtGView.Rows[cnt].Cells[4].Value.ToString();
                                drawImporte = "$ " + Math.Round(Convert.ToDecimal((dtGView.Rows[cnt].Cells[6].Value)), 2).ToString();
                                if (i > 3)
                                {
                                    int borrar1 = r;
                                    i = 1;
                                    yRect += 130;
                                    y1 += 130.0F;
                                    y2 += 130.0F;
                                    fila++;
                                }

                                if (fila <= 8)
                                {
                                    switch (i)
                                    {
                                        case 1: //Columna 1
                                            xRect = 0;
                                            break;
                                        case 2: //Columna 2
                                            xRect = 275;
                                            break;
                                        case 3: //Columna 3
                                            xRect = 550;
                                            break;

                                    }

                                    // Create rectangle. 
                                    rect = new Rectangle(xRect, yRect, 275, 130);
                                    // Draw rectangle to screen. 
                                    e.Graphics.DrawRectangle(blackPen, rect);


                                    //***************************
                                    //Descripcion Articulo
                                    //***************************
                                    string[] palabras = drawArticulo.Split(' ');
                                    int caracteres = 0;
                                    string frase1 = string.Empty;
                                    string frase2 = string.Empty;
                                    bool saltoLinea = false;

                                    //PARTICIONA EN 2 RENGLONES LA DESCRIPCION DEL PRODUCTO************************
                                    foreach (var palabra in palabras)
                                    {
                                        caracteres += (palabra.Length + 1);
                                        if (caracteres >= 20)
                                        {
                                            frase2 += " " + palabra;
                                        }
                                        else frase1 += " " + palabra;
                                    }

                                    //**********************************************************************
                                    //IMPRIME LA FECHA ACTUAL
                                    //**********************************************************************
                                    PointF drawPoint = new PointF(xRect, y1 - 25.0F);
                                    //e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), drawFont, drawBrush, drawPoint);

                                    //FRASE 1*****************************************************************
                                    float textWidthPxl = e.Graphics.MeasureString(frase1, drawFont).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y1);
                                    e.Graphics.DrawString(frase1, drawFont, drawBrush, drawPoint);

                                    //FRASE 2*******************************************************************
                                    if (!string.IsNullOrEmpty(frase2))
                                    {
                                        if (frase2.Length > 20) frase2 = frase2.Substring(0, 20);
                                        textWidthPxl = e.Graphics.MeasureString(frase2, drawFont).Width;
                                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                        drawPoint = new PointF(x, y1 + 20.0F);
                                        e.Graphics.DrawString(frase2, drawFont, drawBrush, drawPoint);
                                    }

                                    //IMPORTE*************************************************************
                                    textWidthPxl = e.Graphics.MeasureString(drawImporte, drawFontPrecio).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y2);
                                    e.Graphics.DrawString(drawImporte, drawFontPrecio, drawBrush, drawPoint);
                                    //IMPORTE*************************************************************


                                    cnt++;
                                    i++;
                                    r++;
                                }
                            }
                            else cnt++;
                        }
                        #endregion
                        break;
                    case 1:
                        #region OFERTA
                        printDocument1.PrinterSettings.PrinterName = printName;
                        
                        paperZ = printDocument1.DefaultPageSettings.PaperSize;
                        e.PageSettings.PaperSize = paperZ;

                        // Calculamos el número de líneas que caben en cada página.
                        printFont = new Font("Arial", 12);
                        
                        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                        colPerPage = e.MarginBounds.Width;
                        lenghCuadro = colPerPage / 2;

                        // Create font and brush.                         
                        drawFont = new Font("Arial", 12);
                        drawFontFecha = new Font("Arial", 10);
                        drawFontLeyenda = new Font("Eras Bold ITC", 24, FontStyle.Bold);
                        drawFontPrecio = new Font("Eras Bold ITC", 30, FontStyle.Bold);

                        drawBrush = new SolidBrush(Color.Black);

                        y1 = 90.0F;//30.0F;                        
                        y2 = 133.0F;
                        lenghCuadro = e.Graphics.MeasureString("12345678901234567890123456789012345678901234", drawFont).Width;

                        
                        while (fila <= 6 && cnt < dtGView.RowCount)
                        {

                            if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[9].Value))
                            {
                                drawArticulo = dtGView.Rows[cnt].Cells[4].Value.ToString();
                                drawImporte = "$ " + Math.Round(Convert.ToDecimal((dtGView.Rows[cnt].Cells[6].Value)), 2).ToString();
                                if (i > 2)
                                {
                                    int borrar1 = r;
                                    i = 1;
                                    yRect += 193;
                                    y1 += 193.0F;//130.0F;
                                    y2 += 193.0F;//130.0F;
                                    fila++;
                                }

                                if (fila <= 6)
                                {
                                    switch (i)
                                    {
                                        case 1: //Columna 1
                                            xRect = 0;
                                            break;
                                        case 2: //Columna 2
                                            xRect = 412;                                            
                                            break;

                                    }

                                    // Create rectangle. 
                                    //rect = new Rectangle(xRect, yRect, 412, 130);
                                    rect = new Rectangle(xRect, yRect, 412, 193);
                                    // Draw rectangle to screen. 
                                    e.Graphics.DrawRectangle(blackPen, rect);


                                    //***************************
                                    //Descripcion Articulo
                                    //***************************
                                    string[] palabras = drawArticulo.Split(' ');
                                    int caracteres = 0;
                                    string frase1 = string.Empty;
                                    string frase2 = string.Empty;
                                    bool saltoLinea = false;

                                    //PARTICIONA EN 2 RENGLONES LA DESCRIPCION DEL PRODUCTO************************
                                    foreach (var palabra in palabras)
                                    {
                                        caracteres += (palabra.Length + 1);
                                        if (caracteres > 38)
                                        {
                                            frase2 += " " + palabra;
                                        }
                                        else frase1 += " " + palabra;
                                    }

                                    //**********************************************************************
                                    //IMPRIME LA FECHA ACTUAL
                                    //**********************************************************************
                                    PointF drawPoint = new PointF(xRect, y1 - 87.0F);
                                    //e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), drawFontFecha, drawBrush, drawPoint);

                                    //**********************************************************************
                                    //LEYENDA DE OFERTA
                                    //**********************************************************************
                                    drawPoint = new PointF(xRect, y1 - 56.0F);
                                    e.Graphics.DrawString("***** O F E R T A *****", drawFontLeyenda, drawBrush, drawPoint);



                                    //FRASE 1*****************************************************************
                                    float textWidthPxl = e.Graphics.MeasureString(frase1, drawFont).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y1);
                                    e.Graphics.DrawString(frase1, drawFont, drawBrush, drawPoint);

                                    //FRASE 2*******************************************************************
                                    if (!string.IsNullOrEmpty(frase2))
                                    {
                                        if (frase2.Length > 38) frase2 = frase2.Substring(0, 38);
                                        textWidthPxl = e.Graphics.MeasureString(frase2, drawFont).Width;
                                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                        drawPoint = new PointF(x, y1 + 20.0F);
                                        e.Graphics.DrawString(frase2, drawFont, drawBrush, drawPoint);
                                    }

                                    //IMPORTE*************************************************************
                                    textWidthPxl = e.Graphics.MeasureString(drawImporte, drawFontPrecio).Width;
                                    x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                                    drawPoint = new PointF(x, y2);
                                    e.Graphics.DrawString(drawImporte, drawFontPrecio, drawBrush, drawPoint);
                                    //IMPORTE*************************************************************


                                    cnt++;
                                    i++;
                                    r++;
                                }
                            }
                            else cnt++;
                        }
                        #endregion
                        break;
                }

                if (cnt < dtGView.RowCount) e.HasMorePages = true;
                if (!e.HasMorePages)
                    cnt = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error imprimiendo");
            }
        }

        private void checkBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dtGView.Rows)
            {
                fila.Cells[9].Value = checkBoxTodos.Checked;
            }
        }

        private void lblArticulo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("¿Esta seguro de limpiar la selección?","Limpiar registro", MessageBoxButtons.OKCancel);
                switch (dr)
                {
                    case DialogResult.OK:
                            cnt = 0;
                            while (cnt < dtGView.RowCount)
                            {

                                if (Convert.ToBoolean(dtGView.Rows[cnt].Cells[9].Value))
                                {
                                    Bus.SetPrint(Convert.ToInt32(dtGView.Rows[cnt].Cells[0].Value), false);
                                }
                                cnt++;
                            }
                            MessageBox.Show("Limpiar selección finalizada con éxito!");
                            ArticulosParaImprimir();
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error borrando seleccionados");
            }
        }
        
    }
}
