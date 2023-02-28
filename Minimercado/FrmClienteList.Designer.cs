namespace Minimercado
{
    partial class FrmClienteList
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
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnCtaCte = new System.Windows.Forms.Button();
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
            this.cmdEliminar.Location = new System.Drawing.Point(569, 453);
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
            this.btnNuevo.Location = new System.Drawing.Point(418, 453);
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
            this.btnModificar.Location = new System.Drawing.Point(720, 453);
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
            this.dtGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGView.Location = new System.Drawing.Point(12, 33);
            this.dtGView.Name = "dtGView";
            this.dtGView.ReadOnly = true;
            this.dtGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGView.Size = new System.Drawing.Size(1004, 405);
            this.dtGView.TabIndex = 4;
            this.dtGView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGView_CellContentClick);
            this.dtGView.DoubleClick += new System.EventHandler(this.dtGView_DoubleClick);
            this.dtGView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtGView_KeyPress);
            this.dtGView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtGView_PreviewKeyDown);
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.BackColor = System.Drawing.Color.White;
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(129, 462);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(271, 23);
            this.cboLocalidad.TabIndex = 37;
            this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(this.cboLocalidad_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 465);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 18);
            this.label14.TabIndex = 38;
            this.label14.Text = "Localidad";
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.Navy;
            this.lblCliente.Location = new System.Drawing.Point(12, 7);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(1004, 23);
            this.lblCliente.TabIndex = 86;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.AccessibleDescription = "";
            this.btnCtaCte.AccessibleName = "";
            this.btnCtaCte.BackColor = System.Drawing.Color.DarkBlue;
            this.btnCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCtaCte.ForeColor = System.Drawing.Color.White;
            this.btnCtaCte.Location = new System.Drawing.Point(871, 453);
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.Size = new System.Drawing.Size(145, 35);
            this.btnCtaCte.TabIndex = 87;
            this.btnCtaCte.Tag = "";
            this.btnCtaCte.Text = "Cuenta Corriente";
            this.btnCtaCte.UseVisualStyleBackColor = false;
            // 
            // FrmClienteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1027, 500);
            this.Controls.Add(this.btnCtaCte);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboLocalidad);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtGView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClienteList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Clientes";
            this.Activated += new System.EventHandler(this.FrmClienteList_Activated);
            this.Load += new System.EventHandler(this.FrmClienteList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dtGView;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnCtaCte;
    }
}