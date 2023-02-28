namespace Minimercado
{
    partial class RptArticulo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rptViewer.ServerReport.ReportPath = "/AdministrationBill/Bills";
            this.rptViewer.ServerReport.ReportServerUrl = new System.Uri("http://localhost/ReportServer_SQLEXPRESS2008", System.UriKind.Absolute);
            this.rptViewer.Size = new System.Drawing.Size(484, 267);
            this.rptViewer.TabIndex = 1;
            // 
            // RptArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 267);
            this.Controls.Add(this.rptViewer);
            this.MaximizeBox = false;
            this.Name = "RptArticulo";
            this.Text = "RptArticulo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptArticulo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
    }
}