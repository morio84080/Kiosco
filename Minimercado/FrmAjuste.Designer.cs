namespace Minimercado
{
    partial class FrmAjuste
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdArticulo = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnArticulo = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoBtnEngreso = new System.Windows.Forms.RadioButton();
            this.rdoBtnIngreso = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(255, 328);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(148, 328);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 32);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(163, 184);
            this.txtCantidad.MaxLength = 5;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(285, 21);
            this.txtCantidad.TabIndex = 5;
            this.txtCantidad.Click += new System.EventHandler(this.txtCantidad_Click);
            this.txtCantidad.GotFocus += new System.EventHandler(this.txtCantidad_GotFocus);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBtnEngreso);
            this.groupBox1.Controls.Add(this.rdoBtnIngreso);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIdArticulo);
            this.groupBox1.Controls.Add(this.lblArticulo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtArticulo);
            this.groupBox1.Controls.Add(this.txtRubro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDetalle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnArticulo);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 303);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(6, 109);
            this.txtIdArticulo.MaxLength = 5;
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(104, 21);
            this.txtIdArticulo.TabIndex = 75;
            this.txtIdArticulo.Visible = false;
            // 
            // lblArticulo
            // 
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.ForeColor = System.Drawing.Color.Navy;
            this.lblArticulo.Location = new System.Drawing.Point(165, 155);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(283, 23);
            this.lblArticulo.TabIndex = 74;
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(311, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "Cód. Artículo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArticulo
            // 
            this.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArticulo.Location = new System.Drawing.Point(314, 129);
            this.txtArticulo.MaxLength = 5;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(134, 21);
            this.txtArticulo.TabIndex = 4;
            this.txtArticulo.Click += new System.EventHandler(this.txtArticulo_Click);
            this.txtArticulo.GotFocus += new System.EventHandler(this.txtArticulo_GotFocus);
            this.txtArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArticulo_KeyPress);
            this.txtArticulo.LostFocus += new System.EventHandler(this.txtArticulo_LostFocus);
            // 
            // txtRubro
            // 
            this.txtRubro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRubro.Location = new System.Drawing.Point(166, 129);
            this.txtRubro.MaxLength = 5;
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(134, 21);
            this.txtRubro.TabIndex = 3;
            this.txtRubro.Click += new System.EventHandler(this.txtRubro_Click);
            this.txtRubro.GotFocus += new System.EventHandler(this.txtRubro_GotFocus);
            this.txtRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRubro_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Cód. Rubro";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDetalle
            // 
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.Location = new System.Drawing.Point(163, 211);
            this.txtDetalle.MaxLength = 50;
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(285, 66);
            this.txtDetalle.TabIndex = 6;
            this.txtDetalle.Click += new System.EventHandler(this.txtDetalle_Click);
            this.txtDetalle.GotFocus += new System.EventHandler(this.txtDetalle_GotFocus);
            this.txtDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDetalle_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 69;
            this.label1.Text = "Detalle";
            // 
            // btnArticulo
            // 
            this.btnArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulo.Location = new System.Drawing.Point(163, 76);
            this.btnArticulo.Name = "btnArticulo";
            this.btnArticulo.Size = new System.Drawing.Size(285, 26);
            this.btnArticulo.TabIndex = 2;
            this.btnArticulo.Text = "Selecionar Artículo";
            this.btnArticulo.UseVisualStyleBackColor = true;
            this.btnArticulo.Click += new System.EventHandler(this.btnArticulo_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 17);
            this.label14.TabIndex = 66;
            this.label14.Text = "Artículo";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(163, 29);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(285, 21);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 64;
            this.label9.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Fecha";
            // 
            // rdoBtnEngreso
            // 
            this.rdoBtnEngreso.AutoSize = true;
            this.rdoBtnEngreso.Location = new System.Drawing.Point(253, 56);
            this.rdoBtnEngreso.Name = "rdoBtnEngreso";
            this.rdoBtnEngreso.Size = new System.Drawing.Size(64, 17);
            this.rdoBtnEngreso.TabIndex = 78;
            this.rdoBtnEngreso.Text = "Egreso";
            this.rdoBtnEngreso.UseVisualStyleBackColor = true;
            // 
            // rdoBtnIngreso
            // 
            this.rdoBtnIngreso.AutoSize = true;
            this.rdoBtnIngreso.Checked = true;
            this.rdoBtnIngreso.Location = new System.Drawing.Point(166, 56);
            this.rdoBtnIngreso.Name = "rdoBtnIngreso";
            this.rdoBtnIngreso.Size = new System.Drawing.Size(67, 17);
            this.rdoBtnIngreso.TabIndex = 1;
            this.rdoBtnIngreso.TabStop = true;
            this.rdoBtnIngreso.Text = "Ingreso";
            this.rdoBtnIngreso.UseVisualStyleBackColor = true;
            // 
            // FrmAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(490, 370);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAjuste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste";
            this.Activated += new System.EventHandler(this.FrmAjuste_Activated);
            this.Load += new System.EventHandler(this.FrmAjuste_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdArticulo;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.RadioButton rdoBtnEngreso;
        private System.Windows.Forms.RadioButton rdoBtnIngreso;
        private System.Windows.Forms.Label label5;
    }
}