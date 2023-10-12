namespace Minimercado
{
    partial class FrmInformes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.listBoxInformes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Blue;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(237, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 32);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Blue;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(89, 252);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(132, 32);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // listBoxInformes
            // 
            this.listBoxInformes.BackColor = System.Drawing.Color.Black;
            this.listBoxInformes.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxInformes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBoxInformes.FormattingEnabled = true;
            this.listBoxInformes.ItemHeight = 24;
            this.listBoxInformes.Items.AddRange(new object[] {
            "Artículos",
            "Ventas",
            "Resumen Ventas por Condición de Pago",
            "Resumen Ventas por Rubro",
            "Documentos Fiscales",
            "Stock Mínimo",
            "Detalle de Ventas"});
            this.listBoxInformes.Location = new System.Drawing.Point(13, 49);
            this.listBoxInformes.Name = "listBoxInformes";
            this.listBoxInformes.Size = new System.Drawing.Size(432, 196);
            this.listBoxInformes.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccionar un informe y presionar Aceptar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxInformes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInformes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.FrmInformes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ListBox listBoxInformes;
        private System.Windows.Forms.Label label1;
    }
}