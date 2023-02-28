namespace Minimercado
{
    partial class FrmCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picNuevoCobrador = new System.Windows.Forms.PictureBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboProviders = new System.Windows.Forms.ComboBox();
            this.btnHabilitar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRetenciones = new System.Windows.Forms.TextBox();
            this.Retenciones = new System.Windows.Forms.Label();
            this.cboIVA = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxActualizar = new System.Windows.Forms.CheckBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPorcGanancia = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPorcIVA = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIdArticulo = new System.Windows.Forms.TextBox();
            this.btnElminar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.dtGView = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.pBoxArticulos = new System.Windows.Forms.PictureBox();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNuevoCobrador)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picNuevoCobrador);
            this.groupBox1.Controls.Add(this.txtObs);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboProviders);
            this.groupBox1.Controls.Add(this.btnHabilitar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 138);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // picNuevoCobrador
            // 
            this.picNuevoCobrador.Image = ((System.Drawing.Image)(resources.GetObject("picNuevoCobrador.Image")));
            this.picNuevoCobrador.Location = new System.Drawing.Point(423, 40);
            this.picNuevoCobrador.Name = "picNuevoCobrador";
            this.picNuevoCobrador.Size = new System.Drawing.Size(23, 23);
            this.picNuevoCobrador.TabIndex = 119;
            this.picNuevoCobrador.TabStop = false;
            this.picNuevoCobrador.Click += new System.EventHandler(this.picNuevoCobrador_Click);
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.White;
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.Location = new System.Drawing.Point(112, 71);
            this.txtObs.MaxLength = 50;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObs.Size = new System.Drawing.Size(305, 61);
            this.txtObs.TabIndex = 108;
            this.txtObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 17);
            this.label13.TabIndex = 109;
            this.label13.Text = "Observación";
            // 
            // cboProviders
            // 
            this.cboProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProviders.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProviders.FormattingEnabled = true;
            this.cboProviders.Location = new System.Drawing.Point(112, 40);
            this.cboProviders.Name = "cboProviders";
            this.cboProviders.Size = new System.Drawing.Size(305, 23);
            this.cboProviders.TabIndex = 0;
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.BackColor = System.Drawing.Color.Blue;
            this.btnHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitar.ForeColor = System.Drawing.Color.White;
            this.btnHabilitar.Location = new System.Drawing.Point(423, 102);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(146, 30);
            this.btnHabilitar.TabIndex = 1;
            this.btnHabilitar.Text = "Habilitar Compra";
            this.btnHabilitar.UseVisualStyleBackColor = false;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "Proveedor";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(112, 16);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(99, 21);
            this.dtpFecha.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 73;
            this.label9.Text = "Fecha";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtRetenciones);
            this.groupBox2.Controls.Add(this.Retenciones);
            this.groupBox2.Controls.Add(this.cboIVA);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtIVA);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSubtotal);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(587, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 138);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Compra ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(170, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 96;
            this.label11.Text = "$";
            // 
            // txtRetenciones
            // 
            this.txtRetenciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetenciones.Location = new System.Drawing.Point(191, 73);
            this.txtRetenciones.MaxLength = 8;
            this.txtRetenciones.Name = "txtRetenciones";
            this.txtRetenciones.Size = new System.Drawing.Size(157, 21);
            this.txtRetenciones.TabIndex = 94;
            this.txtRetenciones.Text = "0";
            this.txtRetenciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetenciones.TextChanged += new System.EventHandler(this.txtRetenciones_TextChanged);
            this.txtRetenciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetenciones_KeyPress);
            // 
            // Retenciones
            // 
            this.Retenciones.AutoSize = true;
            this.Retenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Retenciones.Location = new System.Drawing.Point(19, 73);
            this.Retenciones.Name = "Retenciones";
            this.Retenciones.Size = new System.Drawing.Size(87, 17);
            this.Retenciones.TabIndex = 95;
            this.Retenciones.Text = "Retenciones";
            // 
            // cboIVA
            // 
            this.cboIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIVA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIVA.FormattingEnabled = true;
            this.cboIVA.ItemHeight = 15;
            this.cboIVA.Items.AddRange(new object[] {
            "0",
            "10,5",
            "21",
            "27"});
            this.cboIVA.Location = new System.Drawing.Point(191, 44);
            this.cboIVA.Name = "cboIVA";
            this.cboIVA.Size = new System.Drawing.Size(68, 23);
            this.cboIVA.TabIndex = 13;
            this.cboIVA.SelectedIndexChanged += new System.EventHandler(this.cboIVA_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 93;
            this.label3.Text = "$";
            // 
            // txtIVA
            // 
            this.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(280, 45);
            this.txtIVA.MaxLength = 8;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(68, 21);
            this.txtIVA.TabIndex = 14;
            this.txtIVA.Text = "0";
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(170, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 90;
            this.label7.Text = "$";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(191, 102);
            this.txtTotal.MaxLength = 8;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(157, 21);
            this.txtTotal.TabIndex = 15;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 89;
            this.label8.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(170, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 87;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 17);
            this.label6.TabIndex = 86;
            this.label6.Text = "IVA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(170, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 84;
            this.label4.Text = "$";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(191, 19);
            this.txtSubtotal.MaxLength = 8;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(157, 21);
            this.txtSubtotal.TabIndex = 12;
            this.txtSubtotal.Text = "0";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 83;
            this.label1.Text = "Subtotal";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxActualizar);
            this.groupBox3.Controls.Add(this.txtPrecioVenta);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtPorcGanancia);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtPorcIVA);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtIdArticulo);
            this.groupBox3.Controls.Add(this.btnElminar);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.dtGView);
            this.groupBox3.Controls.Add(this.btnAgregar);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtPrecioUnitario);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lblArticulo);
            this.groupBox3.Controls.Add(this.pBoxArticulos);
            this.groupBox3.Controls.Add(this.txtCodBarra);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(950, 328);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle Venta";
            // 
            // checkBoxActualizar
            // 
            this.checkBoxActualizar.AutoSize = true;
            this.checkBoxActualizar.BackColor = System.Drawing.Color.Black;
            this.checkBoxActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxActualizar.ForeColor = System.Drawing.Color.Lime;
            this.checkBoxActualizar.Location = new System.Drawing.Point(11, 292);
            this.checkBoxActualizar.Name = "checkBoxActualizar";
            this.checkBoxActualizar.Size = new System.Drawing.Size(213, 21);
            this.checkBoxActualizar.TabIndex = 112;
            this.checkBoxActualizar.Text = "Actualizar Precio de Lista";
            this.checkBoxActualizar.UseVisualStyleBackColor = false;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(117, 128);
            this.txtPrecioVenta.MaxLength = 7;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.ReadOnly = true;
            this.txtPrecioVenta.Size = new System.Drawing.Size(66, 21);
            this.txtPrecioVenta.TabIndex = 110;
            this.txtPrecioVenta.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 131);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 17);
            this.label15.TabIndex = 111;
            this.label15.Text = "Precio Venta";
            this.label15.Visible = false;
            // 
            // txtPorcGanancia
            // 
            this.txtPorcGanancia.BackColor = System.Drawing.Color.LightCyan;
            this.txtPorcGanancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPorcGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcGanancia.Location = new System.Drawing.Point(117, 101);
            this.txtPorcGanancia.MaxLength = 7;
            this.txtPorcGanancia.Name = "txtPorcGanancia";
            this.txtPorcGanancia.Size = new System.Drawing.Size(66, 21);
            this.txtPorcGanancia.TabIndex = 108;
            this.txtPorcGanancia.Visible = false;
            this.txtPorcGanancia.Click += new System.EventHandler(this.txtPorcGanancia_Click);
            this.txtPorcGanancia.TextChanged += new System.EventHandler(this.txtPorcGanancia_TextChanged);
            this.txtPorcGanancia.GotFocus += new System.EventHandler(this.txtPorcGanancia_GotFocus);
            this.txtPorcGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcGanancia_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 17);
            this.label14.TabIndex = 109;
            this.label14.Text = "% Ganancia";
            this.label14.Visible = false;
            // 
            // txtPorcIVA
            // 
            this.txtPorcIVA.BackColor = System.Drawing.Color.LightCyan;
            this.txtPorcIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPorcIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcIVA.Location = new System.Drawing.Point(117, 74);
            this.txtPorcIVA.MaxLength = 7;
            this.txtPorcIVA.Name = "txtPorcIVA";
            this.txtPorcIVA.Size = new System.Drawing.Size(66, 21);
            this.txtPorcIVA.TabIndex = 106;
            this.txtPorcIVA.Visible = false;
            this.txtPorcIVA.Click += new System.EventHandler(this.txtPorcIVA_Click);
            this.txtPorcIVA.TextChanged += new System.EventHandler(this.txtPorcIVA_TextChanged);
            this.txtPorcIVA.GotFocus += new System.EventHandler(this.txtPorcIVA_GotFocus);
            this.txtPorcIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcIVA_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 17);
            this.label12.TabIndex = 107;
            this.label12.Text = "% IVA";
            this.label12.Visible = false;
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(192, 170);
            this.txtIdArticulo.MaxLength = 5;
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(23, 21);
            this.txtIdArticulo.TabIndex = 105;
            this.txtIdArticulo.Visible = false;
            // 
            // btnElminar
            // 
            this.btnElminar.BackColor = System.Drawing.Color.Blue;
            this.btnElminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElminar.ForeColor = System.Drawing.Color.White;
            this.btnElminar.Location = new System.Drawing.Point(766, 292);
            this.btnElminar.Name = "btnElminar";
            this.btnElminar.Size = new System.Drawing.Size(175, 30);
            this.btnElminar.TabIndex = 10;
            this.btnElminar.Text = "Eliminar";
            this.btnElminar.UseVisualStyleBackColor = false;
            this.btnElminar.Click += new System.EventHandler(this.btnElminar_Click);
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Navy;
            this.label21.Location = new System.Drawing.Point(11, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(933, 23);
            this.label21.TabIndex = 104;
            this.label21.Text = "Artículo(s)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtGView
            // 
            this.dtGView.AllowUserToAddRows = false;
            this.dtGView.AllowUserToDeleteRows = false;
            this.dtGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGView.Location = new System.Drawing.Point(11, 89);
            this.dtGView.Name = "dtGView";
            this.dtGView.ReadOnly = true;
            this.dtGView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGView.Size = new System.Drawing.Size(933, 197);
            this.dtGView.TabIndex = 103;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Blue;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(766, 27);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(175, 30);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Aregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(653, 36);
            this.txtCantidad.MaxLength = 5;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(66, 21);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.Click += new System.EventHandler(this.txtCantidad_Click);
            this.txtCantidad.GotFocus += new System.EventHandler(this.txtCantidad_GotFocus);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(650, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 17);
            this.label20.TabIndex = 101;
            this.label20.Text = "Cantidad";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioUnitario.Location = new System.Drawing.Point(559, 36);
            this.txtPrecioUnitario.MaxLength = 7;
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(75, 21);
            this.txtPrecioUnitario.TabIndex = 5;
            this.txtPrecioUnitario.Click += new System.EventHandler(this.txtPrecioUnitario_Click);
            this.txtPrecioUnitario.TextChanged += new System.EventHandler(this.txtPrecioUnitario_TextChanged);
            this.txtPrecioUnitario.GotFocus += new System.EventHandler(this.txtPrecioUnitario_GotFocus);
            this.txtPrecioUnitario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecioUnitario_KeyDown);
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(556, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 17);
            this.label19.TabIndex = 99;
            this.label19.Text = "P/Unidad $";
            // 
            // lblArticulo
            // 
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.ForeColor = System.Drawing.Color.Navy;
            this.lblArticulo.Location = new System.Drawing.Point(202, 16);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(351, 41);
            this.lblArticulo.TabIndex = 93;
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pBoxArticulos
            // 
            this.pBoxArticulos.Image = global::Minimercado.Properties.Resources.buscar3;
            this.pBoxArticulos.Location = new System.Drawing.Point(169, 32);
            this.pBoxArticulos.Name = "pBoxArticulos";
            this.pBoxArticulos.Size = new System.Drawing.Size(27, 27);
            this.pBoxArticulos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxArticulos.TabIndex = 91;
            this.pBoxArticulos.TabStop = false;
            this.pBoxArticulos.Click += new System.EventHandler(this.pBoxArticulos_Click);
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.BackColor = System.Drawing.Color.White;
            this.txtCodBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.Location = new System.Drawing.Point(11, 36);
            this.txtCodBarra.MaxLength = 20;
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(157, 21);
            this.txtCodBarra.TabIndex = 2;
            this.txtCodBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodBarra.Click += new System.EventHandler(this.txtCodBarra_Click);
            this.txtCodBarra.TextChanged += new System.EventHandler(this.txtCodBarra_TextChanged);
            this.txtCodBarra.GotFocus += new System.EventHandler(this.txtCodBarra_GotFocus);
            this.txtCodBarra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodBarra_KeyDown);
            this.txtCodBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodBarra_KeyPress);
            this.txtCodBarra.LostFocus += new System.EventHandler(this.txtCodBarra_LostFocus);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 17);
            this.label10.TabIndex = 85;
            this.label10.Text = "Cód. Barras";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(517, 512);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Location = new System.Drawing.Point(410, 512);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 32);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(12, 153);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(949, 22);
            this.lblMensaje.TabIndex = 89;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 556);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNuevoCobrador)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.PictureBox pBoxArticulos;
        private System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtGView;
        private System.Windows.Forms.Button btnElminar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnHabilitar;
        private System.Windows.Forms.TextBox txtIdArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.ComboBox cboIVA;
        private System.Windows.Forms.ComboBox cboProviders;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRetenciones;
        private System.Windows.Forms.Label Retenciones;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPorcGanancia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPorcIVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox picNuevoCobrador;
        private System.Windows.Forms.CheckBox checkBoxActualizar;
    }
}