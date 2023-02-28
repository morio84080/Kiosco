namespace Minimercado
{
    partial class FrmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaja));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxTipoCtaCaja = new System.Windows.Forms.CheckBox();
            this.cboOrigenDestino = new System.Windows.Forms.ComboBox();
            this.lblOrigenDestino = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboIvaArt = new System.Windows.Forms.ComboBox();
            this.txtNroFact = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.Importe = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.autoCompleteTextbox1 = new Minimercado.AutoCompleteTextbox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxTipoCtaCaja);
            this.groupBox1.Controls.Add(this.cboOrigenDestino);
            this.groupBox1.Controls.Add(this.lblOrigenDestino);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIVA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboIvaArt);
            this.groupBox1.Controls.Add(this.txtNroFact);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDetalle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.Importe);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle";
            // 
            // checkBoxTipoCtaCaja
            // 
            this.checkBoxTipoCtaCaja.AutoSize = true;
            this.checkBoxTipoCtaCaja.Location = new System.Drawing.Point(163, 283);
            this.checkBoxTipoCtaCaja.Name = "checkBoxTipoCtaCaja";
            this.checkBoxTipoCtaCaja.Size = new System.Drawing.Size(62, 17);
            this.checkBoxTipoCtaCaja.TabIndex = 216;
            this.checkBoxTipoCtaCaja.Text = "Tipo 2";
            this.checkBoxTipoCtaCaja.UseVisualStyleBackColor = true;
            this.checkBoxTipoCtaCaja.Visible = false;
            // 
            // cboOrigenDestino
            // 
            this.cboOrigenDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOrigenDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOrigenDestino.BackColor = System.Drawing.Color.GhostWhite;
            this.cboOrigenDestino.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboOrigenDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrigenDestino.FormattingEnabled = true;
            this.cboOrigenDestino.Location = new System.Drawing.Point(163, 46);
            this.cboOrigenDestino.Name = "cboOrigenDestino";
            this.cboOrigenDestino.Size = new System.Drawing.Size(354, 23);
            this.cboOrigenDestino.TabIndex = 1;
            // 
            // lblOrigenDestino
            // 
            this.lblOrigenDestino.AutoSize = true;
            this.lblOrigenDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigenDestino.Location = new System.Drawing.Point(15, 49);
            this.lblOrigenDestino.Name = "lblOrigenDestino";
            this.lblOrigenDestino.Size = new System.Drawing.Size(51, 17);
            this.lblOrigenDestino.TabIndex = 215;
            this.lblOrigenDestino.Text = "Origen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 213;
            this.label5.Text = "% IVA";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.GhostWhite;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(163, 184);
            this.txtTotal.MaxLength = 10;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(354, 21);
            this.txtTotal.TabIndex = 211;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 212;
            this.label4.Text = "Total $";
            // 
            // txtIVA
            // 
            this.txtIVA.BackColor = System.Drawing.Color.GhostWhite;
            this.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(163, 158);
            this.txtIVA.MaxLength = 10;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(354, 21);
            this.txtIVA.TabIndex = 5;
            this.txtIVA.TextChanged += new System.EventHandler(this.txtIVA_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 210;
            this.label3.Text = "Total IVA $";
            // 
            // cboIvaArt
            // 
            this.cboIvaArt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboIvaArt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIvaArt.BackColor = System.Drawing.Color.GhostWhite;
            this.cboIvaArt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboIvaArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIvaArt.FormattingEnabled = true;
            this.cboIvaArt.ItemHeight = 15;
            this.cboIvaArt.Items.AddRange(new object[] {
            "0",
            "10,5",
            "21",
            "27"});
            this.cboIvaArt.Location = new System.Drawing.Point(163, 129);
            this.cboIvaArt.Name = "cboIvaArt";
            this.cboIvaArt.Size = new System.Drawing.Size(97, 23);
            this.cboIvaArt.TabIndex = 4;
            this.cboIvaArt.SelectedIndexChanged += new System.EventHandler(this.cboIvaArti_SelectedIndexChanged);
            this.cboIvaArt.GotFocus += new System.EventHandler(this.cboIvaArt_GotFocus);
            this.cboIvaArt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboIvaArt_KeyDown);
            this.cboIvaArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboIvaArt_KeyPress);
            this.cboIvaArt.LostFocus += new System.EventHandler(this.cboIvaArt_LostFocus);
            // 
            // txtNroFact
            // 
            this.txtNroFact.BackColor = System.Drawing.Color.GhostWhite;
            this.txtNroFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFact.Location = new System.Drawing.Point(163, 75);
            this.txtNroFact.MaxLength = 30;
            this.txtNroFact.Name = "txtNroFact";
            this.txtNroFact.Size = new System.Drawing.Size(354, 21);
            this.txtNroFact.TabIndex = 2;
            this.txtNroFact.Click += new System.EventHandler(this.txtNroFact_Click);
            this.txtNroFact.GotFocus += new System.EventHandler(this.txtNroFact_GotFocus);
            this.txtNroFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroFact_KeyPress);
            this.txtNroFact.LostFocus += new System.EventHandler(this.txtNroFact_LostFocus);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 207;
            this.label2.Text = "Nro Factura";
            // 
            // txtDetalle
            // 
            this.txtDetalle.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.Location = new System.Drawing.Point(163, 211);
            this.txtDetalle.MaxLength = 128;
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(354, 66);
            this.txtDetalle.TabIndex = 6;
            this.txtDetalle.Click += new System.EventHandler(this.txtDetalle_Click);
            this.txtDetalle.GotFocus += new System.EventHandler(this.txtDetalle_GotFocus);
            this.txtDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDetalle_KeyPress);
            this.txtDetalle.LostFocus += new System.EventHandler(this.txtDetalle_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 76;
            this.label1.Text = "Detalle";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(163, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(354, 21);
            this.dtpFecha.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 74;
            this.label9.Text = "Fecha Pago";
            // 
            // txtImporte
            // 
            this.txtImporte.BackColor = System.Drawing.Color.GhostWhite;
            this.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(163, 102);
            this.txtImporte.MaxLength = 10;
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(354, 21);
            this.txtImporte.TabIndex = 3;
            this.txtImporte.Click += new System.EventHandler(this.txtImporte_Click);
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.GotFocus += new System.EventHandler(this.txtImporte_GotFocus);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            this.txtImporte.LostFocus += new System.EventHandler(this.txtImporte_LostFocus);
            // 
            // Importe
            // 
            this.Importe.AutoSize = true;
            this.Importe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Importe.Location = new System.Drawing.Point(14, 104);
            this.Importe.Name = "Importe";
            this.Importe.Size = new System.Drawing.Size(67, 17);
            this.Importe.TabIndex = 73;
            this.Importe.Text = "Importe $";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(292, 337);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(185, 337);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 32);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // autoCompleteTextbox1
            // 
            this.autoCompleteTextbox1.CaseSensitive = false;
            this.autoCompleteTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoCompleteTextbox1.Location = new System.Drawing.Point(-238, -278);
            this.autoCompleteTextbox1.MinTypedCharacters = 2;
            this.autoCompleteTextbox1.Name = "autoCompleteTextbox1";
            this.autoCompleteTextbox1.SelectedIndex = -1;
            this.autoCompleteTextbox1.Size = new System.Drawing.Size(255, 21);
            this.autoCompleteTextbox1.TabIndex = 207;
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 376);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.autoCompleteTextbox1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.Activated += new System.EventHandler(this.FrmCaja_Activated);
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label Importe;
        private System.Windows.Forms.TextBox txtNroFact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private AutoCompleteTextbox autoCompleteTextbox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboIvaArt;
        private System.Windows.Forms.ComboBox cboOrigenDestino;
        private System.Windows.Forms.Label lblOrigenDestino;
        private System.Windows.Forms.CheckBox checkBoxTipoCtaCaja;
    }
}