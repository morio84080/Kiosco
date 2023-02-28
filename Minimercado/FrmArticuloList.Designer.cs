namespace Minimercado
{
    partial class FrmArticuloList
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
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dtGView = new System.Windows.Forms.DataGridView();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAccion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.checkBoxTodos = new System.Windows.Forms.CheckBox();
            this.cboRubroAccion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.AccessibleDescription = "";
            this.cmdEliminar.AccessibleName = "";
            this.cmdEliminar.BackColor = System.Drawing.Color.Blue;
            this.cmdEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEliminar.ForeColor = System.Drawing.Color.White;
            this.cmdEliminar.Location = new System.Drawing.Point(909, 457);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(145, 35);
            this.cmdEliminar.TabIndex = 7;
            this.cmdEliminar.Tag = "";
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.UseVisualStyleBackColor = false;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "";
            this.btnNuevo.AccessibleName = "";
            this.btnNuevo.BackColor = System.Drawing.Color.Blue;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(758, 457);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(145, 35);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Tag = "";
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AccessibleDescription = "";
            this.btnModificar.AccessibleName = "";
            this.btnModificar.BackColor = System.Drawing.Color.Blue;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(1060, 457);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(145, 35);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Tag = "";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // dtGView
            // 
            this.dtGView.AllowUserToAddRows = false;
            this.dtGView.AllowUserToDeleteRows = false;
            this.dtGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGView.BackgroundColor = System.Drawing.Color.White;
            this.dtGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGView.GridColor = System.Drawing.Color.DarkGray;
            this.dtGView.Location = new System.Drawing.Point(12, 36);
            this.dtGView.Name = "dtGView";
            this.dtGView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGView.Size = new System.Drawing.Size(1193, 406);
            this.dtGView.TabIndex = 4;
            this.dtGView.DoubleClick += new System.EventHandler(this.dtGView_DoubleClick);
            this.dtGView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtGView_KeyPress);
            this.dtGView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtGView_PreviewKeyDown);
            // 
            // cboRubro
            // 
            this.cboRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRubro.BackColor = System.Drawing.Color.White;
            this.cboRubro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(77, 454);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(223, 23);
            this.cboRubro.TabIndex = 39;
            this.cboRubro.SelectedIndexChanged += new System.EventHandler(this.cboRubro_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(17, 457);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 18);
            this.label14.TabIndex = 40;
            this.label14.Text = "Rubro";
            // 
            // lblArticulo
            // 
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.ForeColor = System.Drawing.Color.Navy;
            this.lblArticulo.Location = new System.Drawing.Point(891, 10);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(231, 23);
            this.lblArticulo.TabIndex = 87;
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 88;
            this.label1.Text = "Cód. Barra";
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.Location = new System.Drawing.Point(402, 457);
            this.txtCodBarra.MaxLength = 20;
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(199, 21);
            this.txtCodBarra.TabIndex = 89;
            this.txtCodBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodBarra_KeyPress);
            // 
            // txtValor
            // 
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(402, 484);
            this.txtValor.MaxLength = 20;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(199, 21);
            this.txtValor.TabIndex = 93;
            this.txtValor.GotFocus += new System.EventHandler(this.txtValor_GotFocus);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.LostFocus += new System.EventHandler(this.txtValor_LostFocus);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 92;
            this.label2.Text = "Valor";
            // 
            // cboAccion
            // 
            this.cboAccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccion.BackColor = System.Drawing.Color.White;
            this.cboAccion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccion.FormattingEnabled = true;
            this.cboAccion.Items.AddRange(new object[] {
            "Precio de Costo",
            "Precio de Venta",
            "Aumenta en % el Costo",
            "Aumenta en % el Precio de Vta.",
            "Cambiar Rubro"});
            this.cboAccion.Location = new System.Drawing.Point(77, 481);
            this.cboAccion.Name = "cboAccion";
            this.cboAccion.Size = new System.Drawing.Size(223, 23);
            this.cboAccion.TabIndex = 90;
            this.cboAccion.SelectedIndexChanged += new System.EventHandler(this.cboAccion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 91;
            this.label3.Text = "Acción";
            // 
            // btnAplicar
            // 
            this.btnAplicar.AccessibleDescription = "";
            this.btnAplicar.AccessibleName = "";
            this.btnAplicar.BackColor = System.Drawing.Color.Black;
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.Lime;
            this.btnAplicar.Location = new System.Drawing.Point(608, 481);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(102, 27);
            this.btnAplicar.TabIndex = 94;
            this.btnAplicar.Tag = "";
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // checkBoxTodos
            // 
            this.checkBoxTodos.AutoSize = true;
            this.checkBoxTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTodos.Location = new System.Drawing.Point(1128, 6);
            this.checkBoxTodos.Name = "checkBoxTodos";
            this.checkBoxTodos.Size = new System.Drawing.Size(77, 24);
            this.checkBoxTodos.TabIndex = 95;
            this.checkBoxTodos.Text = "Todos";
            this.checkBoxTodos.UseVisualStyleBackColor = true;
            this.checkBoxTodos.CheckedChanged += new System.EventHandler(this.checkBoxTodos_CheckedChanged);
            // 
            // cboRubroAccion
            // 
            this.cboRubroAccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRubroAccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRubroAccion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRubroAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRubroAccion.FormattingEnabled = true;
            this.cboRubroAccion.Location = new System.Drawing.Point(402, 482);
            this.cboRubroAccion.Name = "cboRubroAccion";
            this.cboRubroAccion.Size = new System.Drawing.Size(200, 23);
            this.cboRubroAccion.TabIndex = 96;
            this.cboRubroAccion.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 97;
            this.label4.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtBuscar.Location = new System.Drawing.Point(77, 6);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(583, 29);
            this.txtBuscar.TabIndex = 98;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.GotFocus += new System.EventHandler(this.txtBuscar_GotFocus);
            this.txtBuscar.LostFocus += new System.EventHandler(this.txtBuscar_LostFocus);
            // 
            // FrmArticuloList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1217, 516);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboRubroAccion);
            this.Controls.Add(this.checkBoxTodos);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboAccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodBarra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.cboRubro);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtGView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArticuloList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Articulos";
            this.Activated += new System.EventHandler(this.FrmArticuloList_Activated);
            this.Load += new System.EventHandler(this.FrmArticuloList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmArticuloList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dtGView;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.CheckBox checkBoxTodos;
        private System.Windows.Forms.ComboBox cboRubroAccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}