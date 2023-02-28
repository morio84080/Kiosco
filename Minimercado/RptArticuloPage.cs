using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rubros.Business;
using System.Drawing.Printing;
using Articulo.Business;
using Articulo.Entities;

namespace Minimercado
{
    public partial class RptArticuloPage : Form
    {
        public string printName = System.Configuration.ConfigurationSettings.AppSettings["printName"].ToString();
        RubroBusiness rubroBus = new RubroBusiness();
        ArticuloEntity[] articulos;
        int cnt=0;

        // Draw title 
        String drawArticulo = string.Empty;
        String drawImporte = string.Empty;

        String drawArticulo2 = string.Empty;
        String drawImporte2 = string.Empty;

        String drawArticulo3 = string.Empty;
        String drawImporte3 = string.Empty;

        String drawArticulo4 = string.Empty;
        String drawImporte4 = string.Empty;

        public RptArticuloPage()
        {
            InitializeComponent();
            this.LlenarCboRubro();
        }

        private void LlenarCboRubro()
        {
            if (rubroBus.LlenarComboRubro(this.cboRubro) == -1)
                this.Close();

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            GlobalClass.Text = this.cboRubro.SelectedValue.ToString();

            if (chkBoxListadoPrecios.Checked)
            {
                //printDialog1.Document = new PrintDocument();
                //PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();

                //DialogResult result = printDialog1.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                      articulos = new ArticuloBUS().getByCodiRubro(Convert.ToInt32(GlobalClass.Text));
                //    printDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                //    printDialog1.Document.PrintPage += PrintPage;
                //    VistaPrevia.Document = printDialog1.Document;
                //    ((Form)VistaPrevia).WindowState = FormWindowState.Maximized;
                //    VistaPrevia.ShowDialog();
                //    printDialog1.Document.Print();
                //} 

                ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;                
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                RptArticulo rtpArticulo = new RptArticulo();
                rtpArticulo.ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            #region viejo
            //float x = 0;
            //float y = 0;

            //// Calculamos el número de líneas que caben en cada página.
            //Font printFont = new Font("Arial", 12);
            //float linesPerPage = 0;
            //linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            //float colPerPage = 0;
            //colPerPage = ev.MarginBounds.Width;
            //float lenghCuadro = colPerPage / 4;

            //// Draw title 
            //String drawArticulo = string.Empty;
            //String drawImporte = string.Empty;

            //String drawArticulo2 = string.Empty;
            //String drawImporte2 = string.Empty;

            //String drawArticulo3 = string.Empty;
            //String drawImporte3 = string.Empty;

            //String drawArticulo4 = string.Empty;
            //String drawImporte4 = string.Empty;

            //// Create font and brush.                         
            //Font drawFont = new Font("Arial", 12);
            //SolidBrush drawBrush = new SolidBrush(Color.Black);           

            ////Dibujar un rectangulo
            //// Create pen. 
            //Pen blackPen = new Pen(Color.Black, 3);

            //int yRect = 0;
            //int xRect = 0;
            //float y1 = 30.0F;
            //float y2 = 60.0F;
            //lenghCuadro = ev.Graphics.MeasureString("1234567890123456789012", drawFont).Width;

            
            //int i=1;
            //Rectangle rect;
            //int fila = 1;
            //int r = 1;
            //while (fila <= 10 && cnt < articulos.Length)
            //{
            //    drawArticulo = articulos[cnt].DescArti;
            //    drawImporte = "$ " + Math.Round(articulos[cnt].BaseArti,2).ToString();
            //    if (i > 4)
            //    {
            //        int borrar1 = r;
            //        i = 1;
            //        yRect += 117;
            //        y1 += 117.0F;
            //        y2 += 117.0F;
            //        fila++;
            //    }

            //    if (fila <= 10)
            //    {
            //        switch (i)
            //        {
            //            case 1: //Columna 1
            //                xRect = 0;
            //                break;
            //            case 2: //Columna 2
            //                xRect = 206;
            //                break;
            //            case 3: //Columna 3
            //                xRect = 412;
            //                break;
            //            case 4: //Columna 4
            //                xRect = 618;
            //                break;

            //        }

            //        // Create rectangle. 
            //        rect = new Rectangle(xRect, yRect, 206, 117);
            //        // Draw rectangle to screen. 
            //        ev.Graphics.DrawRectangle(blackPen, rect);
            //        // Create point for upper-left corner of drawing.
            //        if (drawArticulo.Length > 22) drawArticulo = drawArticulo.Substring(0, 22);
            //        float textWidthPxl = ev.Graphics.MeasureString(drawArticulo, drawFont).Width;
            //        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
            //        PointF drawPoint = new PointF(x, y1);
            //        ev.Graphics.DrawString(drawArticulo, drawFont, drawBrush, drawPoint);
            //        drawFont = new Font("Arial", 18,FontStyle.Bold);
            //        textWidthPxl = ev.Graphics.MeasureString(drawImporte, drawFont).Width;
            //        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
            //        drawPoint = new PointF(x, y2);                    
            //        ev.Graphics.DrawString(drawImporte, drawFont, drawBrush, drawPoint);
            //        drawFont = new Font("Arial", 12);
            //        cnt++;
            //        i++;
            //        r++;
            //    }                
            //}

            //if (cnt < articulos.Length) ev.HasMorePages = true;
            #endregion

            try
            {
                printDocument1.PrinterSettings.PrinterName = printName;

                float x = 0;
                float y = 0;

                // Calculamos el número de líneas que caben en cada página.
                Font printFont = new Font("Arial", 12);
                float linesPerPage = 0;
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                float colPerPage = 0;
                colPerPage = ev.MarginBounds.Width;
                float lenghCuadro = colPerPage / 3;

                // Create font and brush.                         
                Font drawFont = new Font("Arial", 12);
                Font drawFontPrecio = new Font("Eras Bold ITC", 28, FontStyle.Bold);

                SolidBrush drawBrush = new SolidBrush(Color.Black);

                //Dibujar un rectangulo
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                int yRect = 0;
                int xRect = 0;
                float y1 = 30.0F;
                float y2 = 75.0F;
                lenghCuadro = ev.Graphics.MeasureString("12345678901234567890123456789", drawFont).Width;


                int i = 1;
                Rectangle rect;
                int fila = 1;
                int r = 1;
                while (fila <= 9 && cnt < articulos.Length)
                {
                    drawArticulo = articulos[cnt].DescArti;
                    drawImporte = "$ " + Math.Round(articulos[cnt].BaseArti, 2).ToString();
                    if (i > 3)
                    {
                        int borrar1 = r;
                        i = 1;
                        yRect += 130;
                        y1 += 130.0F;
                        y2 += 130.0F;
                        fila++;
                    }

                    if (fila <= 9)
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
                        // Create point for upper-left corner of drawing.
                        if (drawArticulo.Length > 29) drawArticulo = drawArticulo.Substring(0, 29);
                        float textWidthPxl = ev.Graphics.MeasureString(drawArticulo, drawFont).Width;
                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                        PointF drawPoint = new PointF(x, y1);
                        ev.Graphics.DrawString(drawArticulo, drawFont, drawBrush, drawPoint);
                        textWidthPxl = ev.Graphics.MeasureString(drawImporte, drawFontPrecio).Width;
                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                        drawPoint = new PointF(x, y2);
                        ev.Graphics.DrawString(drawImporte, drawFontPrecio, drawBrush, drawPoint);
                        cnt++;
                        i++;
                        r++;
                    }
                }

                if (cnt < articulos.Length) ev.HasMorePages = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error imprimiendo");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region viejo
            //try
            //{                
            //    printDocument1.PrinterSettings.PrinterName = "HP Deskjet F300 series";

            //    float x = 0;
            //    float y = 0;

            //    // Calculamos el número de líneas que caben en cada página.
            //    Font printFont = new Font("Arial", 12);
            //    float linesPerPage = 0;
            //    linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            //    float colPerPage = 0;
            //    colPerPage = e.MarginBounds.Width;
            //    float lenghCuadro = colPerPage / 4;

            //    // Create font and brush.                         
            //    Font drawFont = new Font("Arial", 12);
            //    Font drawFontPrecio = new Font("Arial", 22, FontStyle.Bold);

            //    SolidBrush drawBrush = new SolidBrush(Color.Black);

            //    //Dibujar un rectangulo
            //    // Create pen. 
            //    Pen blackPen = new Pen(Color.Black, 3);

            //    int yRect = 0;
            //    int xRect = 0;
            //    float y1 = 30.0F;
            //    float y2 = 60.0F;
            //    lenghCuadro = e.Graphics.MeasureString("1234567890123456789012", drawFont).Width;


            //    int i = 1;
            //    Rectangle rect;
            //    int fila = 1;
            //    int r = 1;
            //    while (fila <= 10 && cnt < articulos.Length)
            //    {
            //        drawArticulo = articulos[cnt].DescArti;
            //        drawImporte = "$ " + Math.Round(articulos[cnt].BaseArti, 2).ToString();
            //        if (i > 4)
            //        {
            //            int borrar1 = r;
            //            i = 1;
            //            yRect += 117;
            //            y1 += 117.0F;
            //            y2 += 117.0F;
            //            fila++;
            //        }

            //        if (fila <= 10)
            //        {
            //            switch (i)
            //            {
            //                case 1: //Columna 1
            //                    xRect = 0;
            //                    break;
            //                case 2: //Columna 2
            //                    xRect = 206;
            //                    break;
            //                case 3: //Columna 3
            //                    xRect = 412;
            //                    break;
            //                case 4: //Columna 4
            //                    xRect = 618;
            //                    break;

            //            }

            //            // Create rectangle. 
            //            rect = new Rectangle(xRect, yRect, 206, 117);
            //            // Draw rectangle to screen. 
            //            e.Graphics.DrawRectangle(blackPen, rect);
            //            // Create point for upper-left corner of drawing.
            //            if (drawArticulo.Length > 22) drawArticulo = drawArticulo.Substring(0, 22);
            //            float textWidthPxl = e.Graphics.MeasureString(drawArticulo, drawFont).Width;
            //            x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
            //            PointF drawPoint = new PointF(x, y1);
            //            e.Graphics.DrawString(drawArticulo, drawFont, drawBrush, drawPoint);
            //            textWidthPxl = e.Graphics.MeasureString(drawImporte, drawFontPrecio).Width;
            //            x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
            //            drawPoint = new PointF(x, y2);
            //            e.Graphics.DrawString(drawImporte, drawFontPrecio, drawBrush, drawPoint);
            //            cnt++;
            //            i++;
            //            r++;
            //        }
            //    }

            //    if (cnt < articulos.Length) e.HasMorePages = true;
            //    if (!e.HasMorePages)
            //        cnt = 0;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error imprimiendo");
            //}
            #endregion

            try
            {
                printDocument1.PrinterSettings.PrinterName = printName;

                float x = 0;
                float y = 0;

                // Calculamos el número de líneas que caben en cada página.
                Font printFont = new Font("Arial", 12);
                float linesPerPage = 0;
                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                float colPerPage = 0;
                colPerPage = e.MarginBounds.Width;
                float lenghCuadro = colPerPage / 3;

                // Create font and brush.                         
                Font drawFont = new Font("Arial", 12);
                Font drawFontPrecio = new Font("Eras Bold ITC", 28, FontStyle.Bold);

                SolidBrush drawBrush = new SolidBrush(Color.Black);

                //Dibujar un rectangulo
                // Create pen. 
                Pen blackPen = new Pen(Color.Black, 3);

                int yRect = 0;
                int xRect = 0;
                float y1 = 30.0F;
                float y2 = 75.0F;
                lenghCuadro = e.Graphics.MeasureString("12345678901234567890123456789", drawFont).Width;


                int i = 1;
                Rectangle rect;
                int fila = 1;
                int r = 1;
                while (fila <= 9 && cnt < articulos.Length)
                {
                    drawArticulo = articulos[cnt].DescArti;
                    drawImporte = "$ " + Math.Round(articulos[cnt].BaseArti, 2).ToString();
                    if (i > 3)
                    {
                        int borrar1 = r;
                        i = 1;
                        yRect += 130;
                        y1 += 130.0F;
                        y2 += 130.0F;
                        fila++;
                    }

                    if (fila <= 9)
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
                        // Create point for upper-left corner of drawing.
                        if (drawArticulo.Length > 29) drawArticulo = drawArticulo.Substring(0, 29);
                        float textWidthPxl = e.Graphics.MeasureString(drawArticulo, drawFont).Width;
                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                        PointF drawPoint = new PointF(x, y1);
                        e.Graphics.DrawString(drawArticulo, drawFont, drawBrush, drawPoint);
                        textWidthPxl = e.Graphics.MeasureString(drawImporte, drawFontPrecio).Width;
                        x = ((lenghCuadro - textWidthPxl) / 2) + xRect;
                        drawPoint = new PointF(x, y2);
                        e.Graphics.DrawString(drawImporte, drawFontPrecio, drawBrush, drawPoint);
                        cnt++;
                        i++;
                        r++;
                    }
                }

                if (cnt < articulos.Length) e.HasMorePages = true;
                if (!e.HasMorePages)
                    cnt = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error imprimiendo");
            }
        }

        private void RptArticuloPage_Load(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.PrinterName = printName;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
