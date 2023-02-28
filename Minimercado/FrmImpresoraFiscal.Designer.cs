namespace Minimercado
{
    partial class FrmImpresoraFiscal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtZfin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZinicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInformeCierreZ = new System.Windows.Forms.Button();
            this.btnCierreZ = new System.Windows.Forms.Button();
            this.btnCierreX = new System.Windows.Forms.Button();
            this.lblRC = new System.Windows.Forms.Label();
            this.lblFiscal = new System.Windows.Forms.Label();
            this.lblImpresora = new System.Windows.Forms.Label();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtZfin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtZinicio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnInformeCierreZ);
            this.groupBox1.Controls.Add(this.btnCierreZ);
            this.groupBox1.Controls.Add(this.btnCierreX);
            this.groupBox1.Controls.Add(this.lblRC);
            this.groupBox1.Controls.Add(this.lblFiscal);
            this.groupBox1.Controls.Add(this.lblImpresora);
            this.groupBox1.Controls.Add(this.btnEstado);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Lime;
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 305);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresora Fiscal Epson";
            // 
            // txtZfin
            // 
            this.txtZfin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZfin.Location = new System.Drawing.Point(302, 229);
            this.txtZfin.MaxLength = 35;
            this.txtZfin.Name = "txtZfin";
            this.txtZfin.Size = new System.Drawing.Size(91, 21);
            this.txtZfin.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Fin";
            // 
            // txtZinicio
            // 
            this.txtZinicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZinicio.Location = new System.Drawing.Point(114, 231);
            this.txtZinicio.MaxLength = 35;
            this.txtZinicio.Name = "txtZinicio";
            this.txtZinicio.Size = new System.Drawing.Size(91, 21);
            this.txtZinicio.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "Inicio";
            // 
            // btnInformeCierreZ
            // 
            this.btnInformeCierreZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformeCierreZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformeCierreZ.Location = new System.Drawing.Point(24, 258);
            this.btnInformeCierreZ.Name = "btnInformeCierreZ";
            this.btnInformeCierreZ.Size = new System.Drawing.Size(373, 32);
            this.btnInformeCierreZ.TabIndex = 16;
            this.btnInformeCierreZ.Text = "Emitir Informe Cierre Z por nro";
            this.btnInformeCierreZ.UseVisualStyleBackColor = true;
            this.btnInformeCierreZ.Click += new System.EventHandler(this.btnInformeCierreZ_Click);
            // 
            // btnCierreZ
            // 
            this.btnCierreZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierreZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierreZ.Location = new System.Drawing.Point(24, 157);
            this.btnCierreZ.Name = "btnCierreZ";
            this.btnCierreZ.Size = new System.Drawing.Size(373, 32);
            this.btnCierreZ.TabIndex = 15;
            this.btnCierreZ.Text = "Emitir Cierre Z";
            this.btnCierreZ.UseVisualStyleBackColor = true;
            this.btnCierreZ.Click += new System.EventHandler(this.btnCierreZ_Click);
            // 
            // btnCierreX
            // 
            this.btnCierreX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierreX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierreX.Location = new System.Drawing.Point(24, 106);
            this.btnCierreX.Name = "btnCierreX";
            this.btnCierreX.Size = new System.Drawing.Size(373, 32);
            this.btnCierreX.TabIndex = 14;
            this.btnCierreX.Text = "Emitir Cierre X";
            this.btnCierreX.UseVisualStyleBackColor = true;
            this.btnCierreX.Click += new System.EventHandler(this.btnCierreX_Click);
            // 
            // lblRC
            // 
            this.lblRC.Location = new System.Drawing.Point(299, 29);
            this.lblRC.Name = "lblRC";
            this.lblRC.Size = new System.Drawing.Size(98, 25);
            this.lblRC.TabIndex = 13;
            this.lblRC.Text = "RC";
            // 
            // lblFiscal
            // 
            this.lblFiscal.Location = new System.Drawing.Point(161, 29);
            this.lblFiscal.Name = "lblFiscal";
            this.lblFiscal.Size = new System.Drawing.Size(111, 25);
            this.lblFiscal.TabIndex = 12;
            this.lblFiscal.Text = "Fiscal";
            // 
            // lblImpresora
            // 
            this.lblImpresora.Location = new System.Drawing.Point(21, 29);
            this.lblImpresora.Name = "lblImpresora";
            this.lblImpresora.Size = new System.Drawing.Size(108, 25);
            this.lblImpresora.TabIndex = 11;
            this.lblImpresora.Text = "Impresora";
            // 
            // btnEstado
            // 
            this.btnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado.Location = new System.Drawing.Point(24, 57);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(373, 32);
            this.btnEstado.TabIndex = 10;
            this.btnEstado.Text = "Estado";
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(185, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmImpresoraFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(460, 379);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImpresoraFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comandos Impresora Fiscal";
            this.Activated += new System.EventHandler(this.FrmImpresoraFiscal_Activated);
            this.Load += new System.EventHandler(this.FrmImpresoraFiscal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRC;
        private System.Windows.Forms.Label lblFiscal;
        private System.Windows.Forms.Label lblImpresora;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCierreZ;
        private System.Windows.Forms.Button btnCierreX;
        private System.Windows.Forms.Button btnInformeCierreZ;
        private System.Windows.Forms.TextBox txtZfin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZinicio;
        private System.Windows.Forms.Label label5;
    }
}