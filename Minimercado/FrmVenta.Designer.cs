namespace Minimercado
{
    partial class FrmVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRecibido = new System.Windows.Forms.TextBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxImprime = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCondicion = new System.Windows.Forms.ComboBox();
            this.picNuevoCobrador = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.autoCompleteTxtCliente = new Minimercado.AutoCompleteTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoFact = new System.Windows.Forms.ComboBox();
            this.checkBoxCalculadora = new System.Windows.Forms.CheckBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.pBoxArticulos = new System.Windows.Forms.PictureBox();
            this.txtRetira = new System.Windows.Forms.TextBox();
            this.txtIdArticulo = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtGView = new System.Windows.Forms.DataGridView();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnElminar = new System.Windows.Forms.Button();
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.btnNoFiscal = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panelError = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNuevoCobrador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).BeginInit();
            this.panelDerecho.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            this.panelError.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRecibido);
            this.groupBox1.Controls.Add(this.lblVuelto);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblCantidad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 171);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Venta";
            // 
            // txtRecibido
            // 
            this.txtRecibido.BackColor = System.Drawing.Color.White;
            this.txtRecibido.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.txtRecibido.ForeColor = System.Drawing.Color.DarkRed;
            this.txtRecibido.Location = new System.Drawing.Point(218, 57);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.Size = new System.Drawing.Size(252, 38);
            this.txtRecibido.TabIndex = 90;
            this.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecibido.Click += new System.EventHandler(this.txtRecibido_Click);
            this.txtRecibido.TextChanged += new System.EventHandler(this.txtRecibido_TextChanged);
            this.txtRecibido.GotFocus += new System.EventHandler(this.txtRecibido_GotFocus);
            this.txtRecibido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecibido_KeyPress);
            // 
            // lblVuelto
            // 
            this.lblVuelto.CausesValidation = false;
            this.lblVuelto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.ForeColor = System.Drawing.Color.Green;
            this.lblVuelto.Location = new System.Drawing.Point(211, 92);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(259, 37);
            this.lblVuelto.TabIndex = 89;
            this.lblVuelto.Text = "0";
            this.lblVuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.CausesValidation = false;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(13, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 37);
            this.label9.TabIndex = 88;
            this.label9.Text = "Vuelto     $";
            // 
            // label7
            // 
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(13, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 37);
            this.label7.TabIndex = 87;
            this.label7.Text = "Recibido $";
            // 
            // lblCantidad
            // 
            this.lblCantidad.CausesValidation = false;
            this.lblCantidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCantidad.Location = new System.Drawing.Point(288, 127);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(182, 37);
            this.lblCantidad.TabIndex = 86;
            this.lblCantidad.Text = "0";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.CausesValidation = false;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 37);
            this.label3.TabIndex = 85;
            this.label3.Text = "Cant. Art.";
            // 
            // lblTotal
            // 
            this.lblTotal.CausesValidation = false;
            this.lblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTotal.Location = new System.Drawing.Point(218, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(260, 55);
            this.lblTotal.TabIndex = 84;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 55);
            this.label2.TabIndex = 83;
            this.label2.Text = "Total  $";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(12, 2);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(1137, 23);
            this.lblMensaje.TabIndex = 90;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Navy;
            this.label21.Location = new System.Drawing.Point(12, 202);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(1135, 23);
            this.label21.TabIndex = 118;
            this.label21.Text = "Artículo(s) Seleccionados";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxImprime);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboCondicion);
            this.groupBox3.Controls.Add(this.picNuevoCobrador);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.autoCompleteTxtCliente);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboTipoFact);
            this.groupBox3.Controls.Add(this.checkBoxCalculadora);
            this.groupBox3.Controls.Add(this.lblCliente);
            this.groupBox3.Controls.Add(this.txtCliente);
            this.groupBox3.Controls.Add(this.cboCliente);
            this.groupBox3.Controls.Add(this.pBoxArticulos);
            this.groupBox3.Controls.Add(this.txtRetira);
            this.groupBox3.Controls.Add(this.txtIdArticulo);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtPrecioUnitario);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lblArticulo);
            this.groupBox3.Controls.Add(this.txtCodBarra);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(509, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(637, 171);
            this.groupBox3.TabIndex = 117;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle Venta";
            // 
            // checkBoxImprime
            // 
            this.checkBoxImprime.AutoSize = true;
            this.checkBoxImprime.Checked = true;
            this.checkBoxImprime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxImprime.Location = new System.Drawing.Point(302, 121);
            this.checkBoxImprime.Name = "checkBoxImprime";
            this.checkBoxImprime.Size = new System.Drawing.Size(59, 17);
            this.checkBoxImprime.TabIndex = 205;
            this.checkBoxImprime.Text = "Print?";
            this.checkBoxImprime.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 204;
            this.label5.Text = "Condición";
            // 
            // cboCondicion
            // 
            this.cboCondicion.FormattingEnabled = true;
            this.cboCondicion.Location = new System.Drawing.Point(337, 29);
            this.cboCondicion.Name = "cboCondicion";
            this.cboCondicion.Size = new System.Drawing.Size(133, 21);
            this.cboCondicion.TabIndex = 203;
            this.cboCondicion.SelectedIndexChanged += new System.EventHandler(this.cboCondicion_SelectedIndexChanged);
            // 
            // picNuevoCobrador
            // 
            this.picNuevoCobrador.Image = ((System.Drawing.Image)(resources.GetObject("picNuevoCobrador.Image")));
            this.picNuevoCobrador.Location = new System.Drawing.Point(608, 92);
            this.picNuevoCobrador.Name = "picNuevoCobrador";
            this.picNuevoCobrador.Size = new System.Drawing.Size(23, 23);
            this.picNuevoCobrador.TabIndex = 202;
            this.picNuevoCobrador.TabStop = false;
            this.picNuevoCobrador.Click += new System.EventHandler(this.picNuevoCobrador_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 143;
            this.label4.Text = "Cliente";
            // 
            // autoCompleteTxtCliente
            // 
            this.autoCompleteTxtCliente.CaseSensitive = false;
            this.autoCompleteTxtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoCompleteTxtCliente.Location = new System.Drawing.Point(302, 94);
            this.autoCompleteTxtCliente.MinTypedCharacters = 2;
            this.autoCompleteTxtCliente.Name = "autoCompleteTxtCliente";
            this.autoCompleteTxtCliente.SelectedIndex = -1;
            this.autoCompleteTxtCliente.Size = new System.Drawing.Size(300, 21);
            this.autoCompleteTxtCliente.TabIndex = 142;
            this.autoCompleteTxtCliente.Click += new System.EventHandler(this.autoCompleteTxtCliente_Click);
            this.autoCompleteTxtCliente.TextChanged += new System.EventHandler(this.autoCompleteTxtCliente_TextChanged);
            this.autoCompleteTxtCliente.GotFocus += new System.EventHandler(this.autoCompleteTxtCliente_GotFocus);
            this.autoCompleteTxtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.autoCompleteTxtCliente_KeyPress);
            this.autoCompleteTxtCliente.LostFocus += new System.EventHandler(this.autoCompleteTxtCliente_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Tipo de Ticket";
            // 
            // cboTipoFact
            // 
            this.cboTipoFact.FormattingEnabled = true;
            this.cboTipoFact.Items.AddRange(new object[] {
            "Factura B",
            "Factura A"});
            this.cboTipoFact.Location = new System.Drawing.Point(476, 29);
            this.cboTipoFact.Name = "cboTipoFact";
            this.cboTipoFact.Size = new System.Drawing.Size(155, 21);
            this.cboTipoFact.TabIndex = 140;
            // 
            // checkBoxCalculadora
            // 
            this.checkBoxCalculadora.AutoSize = true;
            this.checkBoxCalculadora.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxCalculadora.Location = new System.Drawing.Point(176, 9);
            this.checkBoxCalculadora.Name = "checkBoxCalculadora";
            this.checkBoxCalculadora.Size = new System.Drawing.Size(93, 17);
            this.checkBoxCalculadora.TabIndex = 139;
            this.checkBoxCalculadora.Text = "Calculadora";
            this.checkBoxCalculadora.UseVisualStyleBackColor = true;
            this.checkBoxCalculadora.Visible = false;
            this.checkBoxCalculadora.CheckedChanged += new System.EventHandler(this.checkBoxCalculadora_CheckedChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCliente.Location = new System.Drawing.Point(354, 97);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(278, 25);
            this.lblCliente.TabIndex = 138;
            this.lblCliente.Visible = false;
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(302, 95);
            this.txtCliente.MaxLength = 2;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(46, 26);
            this.txtCliente.TabIndex = 137;
            this.txtCliente.Visible = false;
            this.txtCliente.Click += new System.EventHandler(this.txtCliente_Click);
            this.txtCliente.GotFocus += new System.EventHandler(this.txtCliente_GotFocus);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            this.txtCliente.LostFocus += new System.EventHandler(this.txtCliente_LostFocus);
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboCliente.CausesValidation = false;
            this.cboCliente.Enabled = false;
            this.cboCliente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(302, 94);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(329, 28);
            this.cboCliente.TabIndex = 135;
            this.cboCliente.Visible = false;
            // 
            // pBoxArticulos
            // 
            this.pBoxArticulos.Image = global::Minimercado.Properties.Resources.buscar3;
            this.pBoxArticulos.Location = new System.Drawing.Point(301, 25);
            this.pBoxArticulos.Name = "pBoxArticulos";
            this.pBoxArticulos.Size = new System.Drawing.Size(27, 27);
            this.pBoxArticulos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxArticulos.TabIndex = 106;
            this.pBoxArticulos.TabStop = false;
            this.pBoxArticulos.Click += new System.EventHandler(this.pBoxArticulos_Click);
            // 
            // txtRetira
            // 
            this.txtRetira.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRetira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetira.Enabled = false;
            this.txtRetira.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetira.Location = new System.Drawing.Point(302, 128);
            this.txtRetira.MaxLength = 60;
            this.txtRetira.Name = "txtRetira";
            this.txtRetira.Size = new System.Drawing.Size(236, 26);
            this.txtRetira.TabIndex = 136;
            this.txtRetira.Visible = false;
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdArticulo.Location = new System.Drawing.Point(211, 96);
            this.txtIdArticulo.MaxLength = 5;
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(23, 21);
            this.txtIdArticulo.TabIndex = 105;
            this.txtIdArticulo.Visible = false;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(113, 128);
            this.txtCantidad.MaxLength = 2;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(92, 26);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Click += new System.EventHandler(this.txtCantidad_Click);
            this.txtCantidad.GotFocus += new System.EventHandler(this.txtCantidad_GotFocus);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.LostFocus += new System.EventHandler(this.txtCantidad_LostFocus);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.CausesValidation = false;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 131);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 20);
            this.label20.TabIndex = 101;
            this.label20.Text = "Cantidad";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioUnitario.Location = new System.Drawing.Point(113, 96);
            this.txtPrecioUnitario.MaxLength = 7;
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(92, 26);
            this.txtPrecioUnitario.TabIndex = 3;
            this.txtPrecioUnitario.Click += new System.EventHandler(this.txtPrecioUnitario_Click);
            this.txtPrecioUnitario.TextChanged += new System.EventHandler(this.txtPrecioUnitario_TextChanged);
            this.txtPrecioUnitario.GotFocus += new System.EventHandler(this.txtPrecioUnitario_GotFocus);
            this.txtPrecioUnitario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecioUnitario_KeyDown);
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            this.txtPrecioUnitario.LostFocus += new System.EventHandler(this.txtPrecioUnitario_LostFocus);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.CausesValidation = false;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(5, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(97, 20);
            this.label19.TabIndex = 99;
            this.label19.Text = "P/Unidad $";
            // 
            // lblArticulo
            // 
            this.lblArticulo.CausesValidation = false;
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.ForeColor = System.Drawing.Color.Navy;
            this.lblArticulo.Location = new System.Drawing.Point(113, 55);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(519, 23);
            this.lblArticulo.TabIndex = 93;
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.Location = new System.Drawing.Point(113, 26);
            this.txtCodBarra.MaxLength = 20;
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(182, 26);
            this.txtCodBarra.TabIndex = 0;
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
            this.label10.CausesValidation = false;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 20);
            this.label10.TabIndex = 85;
            this.label10.Text = "Cód. Barras";
            // 
            // dtGView
            // 
            this.dtGView.AllowUserToAddRows = false;
            this.dtGView.AllowUserToDeleteRows = false;
            this.dtGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtGView.Location = new System.Drawing.Point(12, 229);
            this.dtGView.Name = "dtGView";
            this.dtGView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGView.Size = new System.Drawing.Size(1135, 339);
            this.dtGView.TabIndex = 115;
            this.dtGView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGView_CellClick);
            this.dtGView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGView_CellContentClick);
            // 
            // panelDerecho
            // 
            this.panelDerecho.Controls.Add(this.lblStatus);
            this.panelDerecho.Controls.Add(this.btnElminar);
            this.panelDerecho.Location = new System.Drawing.Point(517, 568);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(631, 41);
            this.panelDerecho.TabIndex = 124;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Location = new System.Drawing.Point(5, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(447, 22);
            this.lblStatus.TabIndex = 122;
            this.lblStatus.Text = "Estado Impresora Fiscal";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnElminar
            // 
            this.btnElminar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnElminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElminar.ForeColor = System.Drawing.Color.White;
            this.btnElminar.Location = new System.Drawing.Point(456, 5);
            this.btnElminar.Name = "btnElminar";
            this.btnElminar.Size = new System.Drawing.Size(175, 30);
            this.btnElminar.TabIndex = 121;
            this.btnElminar.Text = "Eliminar";
            this.btnElminar.UseVisualStyleBackColor = false;
            this.btnElminar.Click += new System.EventHandler(this.btnElminar_Click);
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.Controls.Add(this.btnNoFiscal);
            this.panelIzquierdo.Controls.Add(this.btnCancelar);
            this.panelIzquierdo.Controls.Add(this.btnAceptar);
            this.panelIzquierdo.Location = new System.Drawing.Point(3, 568);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(513, 41);
            this.panelIzquierdo.TabIndex = 123;
            // 
            // btnNoFiscal
            // 
            this.btnNoFiscal.BackColor = System.Drawing.Color.Blue;
            this.btnNoFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoFiscal.ForeColor = System.Drawing.Color.White;
            this.btnNoFiscal.Location = new System.Drawing.Point(362, 4);
            this.btnNoFiscal.Name = "btnNoFiscal";
            this.btnNoFiscal.Size = new System.Drawing.Size(136, 32);
            this.btnNoFiscal.TabIndex = 126;
            this.btnNoFiscal.Text = "Presupuesto (F12)";
            this.btnNoFiscal.UseVisualStyleBackColor = false;
            this.btnNoFiscal.Click += new System.EventHandler(this.btnNoFiscal_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Blue;
            this.btnCancelar.Location = new System.Drawing.Point(191, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(136, 32);
            this.btnCancelar.TabIndex = 125;
            this.btnCancelar.Text = "Salir (F5)";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Blue;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(8, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(136, 32);
            this.btnAceptar.TabIndex = 124;
            this.btnAceptar.Text = "Ticket (F1)";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panelError
            // 
            this.panelError.BackColor = System.Drawing.Color.Red;
            this.panelError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelError.Controls.Add(this.btnCerrar);
            this.panelError.Controls.Add(this.label6);
            this.panelError.Location = new System.Drawing.Point(163, 86);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(948, 401);
            this.panelError.TabIndex = 125;
            this.panelError.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Black;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.Red;
            this.btnCerrar.Location = new System.Drawing.Point(360, 250);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(181, 54);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(104, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(754, 70);
            this.label6.TabIndex = 0;
            this.label6.Text = "Error Producto Inexistente!!!";
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1158, 613);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelIzquierdo);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dtGView);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmVenta_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVenta_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVenta_FormClosed);
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVenta_KeyDown);
            this.Resize += new System.EventHandler(this.FrmVenta_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNuevoCobrador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).EndInit();
            this.panelDerecho.ResumeLayout(false);
            this.panelIzquierdo.ResumeLayout(false);
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pBoxArticulos;
        private System.Windows.Forms.TextBox txtIdArticulo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtGView;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnElminar;
        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.Button btnNoFiscal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.TextBox txtRetira;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.CheckBox checkBoxCalculadora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoFact;
        private AutoCompleteTextbox autoCompleteTxtCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picNuevoCobrador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCondicion;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox checkBoxImprime;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
    }
}