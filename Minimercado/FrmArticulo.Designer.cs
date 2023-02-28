namespace Minimercado
{
    partial class FrmArticulo
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
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLastUpdate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecioVta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGanancia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtStockMínimo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Blue;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(254, 383);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Blue;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(141, 383);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 32);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Código Barra";
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.Location = new System.Drawing.Point(162, 95);
            this.txtCodBarra.MaxLength = 20;
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(289, 21);
            this.txtCodBarra.TabIndex = 2;
            this.txtCodBarra.GotFocus += new System.EventHandler(this.txtCodBarra_GotFocus);
            this.txtCodBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodBarra_KeyPress);
            this.txtCodBarra.LostFocus += new System.EventHandler(this.txtCodBarra_LostFocus);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStockMínimo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboMarca);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtLastUpdate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtIVA);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPrecioVta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGanancia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStock);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboRubro);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtPrecioBase);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodBarra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 353);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // cboMarca
            // 
            this.cboMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMarca.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(162, 66);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(289, 23);
            this.cboMarca.TabIndex = 1;
            this.cboMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboMarca_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 54;
            this.label10.Text = "Marca";
            // 
            // txtLastUpdate
            // 
            this.txtLastUpdate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtLastUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastUpdate.Location = new System.Drawing.Point(162, 311);
            this.txtLastUpdate.MaxLength = 10;
            this.txtLastUpdate.Name = "txtLastUpdate";
            this.txtLastUpdate.ReadOnly = true;
            this.txtLastUpdate.Size = new System.Drawing.Size(289, 21);
            this.txtLastUpdate.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 17);
            this.label9.TabIndex = 52;
            this.label9.Text = "Última Act. Precio";
            // 
            // txtIVA
            // 
            this.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(162, 203);
            this.txtIVA.MaxLength = 10;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(289, 21);
            this.txtIVA.TabIndex = 6;
            this.txtIVA.Text = "0";
            this.txtIVA.TextChanged += new System.EventHandler(this.txtIVA_TextChanged);
            this.txtIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIVA_KeyPress);
            this.txtIVA.LostFocus += new System.EventHandler(this.txtIVA_LostFocus);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "% IVA";
            // 
            // txtPrecioVta
            // 
            this.txtPrecioVta.BackColor = System.Drawing.Color.Aquamarine;
            this.txtPrecioVta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVta.Location = new System.Drawing.Point(162, 230);
            this.txtPrecioVta.MaxLength = 10;
            this.txtPrecioVta.Name = "txtPrecioVta";
            this.txtPrecioVta.Size = new System.Drawing.Size(289, 21);
            this.txtPrecioVta.TabIndex = 7;
            this.txtPrecioVta.TextChanged += new System.EventHandler(this.txtPrecioVta_TextChanged);
            this.txtPrecioVta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVta_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 48;
            this.label7.Text = "Precio Venta $";
            // 
            // txtGanancia
            // 
            this.txtGanancia.BackColor = System.Drawing.Color.White;
            this.txtGanancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGanancia.Location = new System.Drawing.Point(162, 176);
            this.txtGanancia.MaxLength = 10;
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGanancia.Size = new System.Drawing.Size(289, 21);
            this.txtGanancia.TabIndex = 5;
            this.txtGanancia.Text = "0";
            this.txtGanancia.TextChanged += new System.EventHandler(this.txtGanancia_TextChanged);
            this.txtGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGanancia_KeyPress);
            this.txtGanancia.LostFocus += new System.EventHandler(this.txtGanancia_LostFocus);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "% Ganancia";
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(162, 257);
            this.txtStock.MaxLength = 10;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(289, 21);
            this.txtStock.TabIndex = 8;
            this.txtStock.Text = "0";
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            this.txtStock.LostFocus += new System.EventHandler(this.txtStock_LostFocus);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Stock Inicial";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(162, 6);
            this.txtCodigo.MaxLength = 3;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(289, 21);
            this.txtCodigo.TabIndex = 41;
            this.txtCodigo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "Código";
            this.label5.Visible = false;
            // 
            // cboRubro
            // 
            this.cboRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRubro.BackColor = System.Drawing.Color.White;
            this.cboRubro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(162, 37);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(289, 23);
            this.cboRubro.TabIndex = 0;
            this.cboRubro.SelectedIndexChanged += new System.EventHandler(this.cboRubro_SelectedIndexChanged);
            this.cboRubro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboRubro_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 17);
            this.label14.TabIndex = 38;
            this.label14.Text = "Rubro";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioBase.Location = new System.Drawing.Point(162, 149);
            this.txtPrecioBase.MaxLength = 10;
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(289, 21);
            this.txtPrecioBase.TabIndex = 4;
            this.txtPrecioBase.Text = "0";
            this.txtPrecioBase.TextChanged += new System.EventHandler(this.txtPrecioBase_TextChanged);
            this.txtPrecioBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioBase_KeyPress);
            this.txtPrecioBase.LostFocus += new System.EventHandler(this.txtPrecioBase_LostFocus);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Costo $";
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(162, 122);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(289, 21);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesc_KeyPress);
            this.txtDesc.LostFocus += new System.EventHandler(this.txtDesc_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Descripción Artículo";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(332, 9);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(156, 13);
            this.lblMensaje.TabIndex = 9;
            this.lblMensaje.Text = "ESC --> PARA CANCELAR";
            this.lblMensaje.Visible = false;
            // 
            // txtStockMínimo
            // 
            this.txtStockMínimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockMínimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockMínimo.Location = new System.Drawing.Point(162, 284);
            this.txtStockMínimo.MaxLength = 10;
            this.txtStockMínimo.Name = "txtStockMínimo";
            this.txtStockMínimo.Size = new System.Drawing.Size(289, 21);
            this.txtStockMínimo.TabIndex = 9;
            this.txtStockMínimo.Text = "0";
            this.txtStockMínimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMínimo_KeyPress);
            this.txtStockMínimo.GotFocus += new System.EventHandler(this.txtStockMínimo_GotFocus);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 56;
            this.label11.Text = "Stock Mínimo";
            // 
            // FrmArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 422);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Articulo";
            this.Activated += new System.EventHandler(this.FrmArticulo_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmArticulo_FormClosing);
            this.Load += new System.EventHandler(this.FrmArticulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmArticulo_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecioVta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGanancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.TextBox txtLastUpdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStockMínimo;
        private System.Windows.Forms.Label label11;
    }
}