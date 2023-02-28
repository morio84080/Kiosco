namespace Minimercado
{
    partial class FrmHasar
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
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCierreZ = new System.Windows.Forms.Button();
            this.btnCierreX = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.Location = new System.Drawing.Point(12, 9);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(95, 20);
            this.lblLeyenda.TabIndex = 5;
            this.lblLeyenda.Text = "lblLeyenda";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCierreZ);
            this.groupBox1.Controls.Add(this.btnCierreX);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(16, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 151);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresora Fiscal HASAR SMH/PT-250F";
            // 
            // btnCierreZ
            // 
            this.btnCierreZ.BackColor = System.Drawing.Color.Red;
            this.btnCierreZ.ForeColor = System.Drawing.Color.White;
            this.btnCierreZ.Location = new System.Drawing.Point(7, 90);
            this.btnCierreZ.Name = "btnCierreZ";
            this.btnCierreZ.Size = new System.Drawing.Size(375, 42);
            this.btnCierreZ.TabIndex = 1;
            this.btnCierreZ.Text = "Cierre Z";
            this.btnCierreZ.UseVisualStyleBackColor = false;
            this.btnCierreZ.Click += new System.EventHandler(this.btnCierreZ_Click);
            // 
            // btnCierreX
            // 
            this.btnCierreX.BackColor = System.Drawing.Color.Red;
            this.btnCierreX.Enabled = false;
            this.btnCierreX.ForeColor = System.Drawing.Color.White;
            this.btnCierreX.Location = new System.Drawing.Point(7, 33);
            this.btnCierreX.Name = "btnCierreX";
            this.btnCierreX.Size = new System.Drawing.Size(375, 42);
            this.btnCierreX.TabIndex = 0;
            this.btnCierreX.Text = "Cierre X";
            this.btnCierreX.UseVisualStyleBackColor = false;
            this.btnCierreX.Click += new System.EventHandler(this.btnCierreX_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(16, 186);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(386, 42);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 219);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROCESANDO...";
            // 
            // FrmHasar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 242);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLeyenda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHasar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Impresora Fiscal Hasar";
            this.Load += new System.EventHandler(this.FrmHasar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCierreZ;
        private System.Windows.Forms.Button btnCierreX;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}