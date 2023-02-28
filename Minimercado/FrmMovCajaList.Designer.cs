namespace Minimercado
{
    partial class FrmMovCajaList
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
            this.btnCierre = new System.Windows.Forms.Button();
            this.dtGView = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnEgreso = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cboCondicion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCierre
            // 
            this.btnCierre.AccessibleDescription = "";
            this.btnCierre.AccessibleName = "";
            this.btnCierre.BackColor = System.Drawing.Color.Blue;
            this.btnCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierre.ForeColor = System.Drawing.Color.White;
            this.btnCierre.Location = new System.Drawing.Point(341, 491);
            this.btnCierre.Name = "btnCierre";
            this.btnCierre.Size = new System.Drawing.Size(159, 35);
            this.btnCierre.TabIndex = 102;
            this.btnCierre.Tag = "";
            this.btnCierre.Text = "Cierre Caja";
            this.btnCierre.UseVisualStyleBackColor = false;
            this.btnCierre.Click += new System.EventHandler(this.btnCierre_Click);
            // 
            // dtGView
            // 
            this.dtGView.AllowUserToAddRows = false;
            this.dtGView.AllowUserToDeleteRows = false;
            this.dtGView.BackgroundColor = System.Drawing.Color.White;
            this.dtGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGView.GridColor = System.Drawing.Color.DarkGray;
            this.dtGView.Location = new System.Drawing.Point(12, 34);
            this.dtGView.MultiSelect = false;
            this.dtGView.Name = "dtGView";
            this.dtGView.ReadOnly = true;
            this.dtGView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGView.Size = new System.Drawing.Size(978, 451);
            this.dtGView.TabIndex = 101;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleDescription = "";
            this.btnCancelar.AccessibleName = "";
            this.btnCancelar.BackColor = System.Drawing.Color.Blue;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(506, 491);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(159, 35);
            this.btnCancelar.TabIndex = 100;
            this.btnCancelar.Tag = "";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.AccessibleDescription = "";
            this.btnIngreso.AccessibleName = "";
            this.btnIngreso.BackColor = System.Drawing.Color.Navy;
            this.btnIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.ForeColor = System.Drawing.Color.White;
            this.btnIngreso.Location = new System.Drawing.Point(176, 491);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(159, 35);
            this.btnIngreso.TabIndex = 103;
            this.btnIngreso.Tag = "";
            this.btnIngreso.Text = "Ingreso";
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnEgreso
            // 
            this.btnEgreso.AccessibleDescription = "";
            this.btnEgreso.AccessibleName = "";
            this.btnEgreso.BackColor = System.Drawing.Color.Navy;
            this.btnEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEgreso.ForeColor = System.Drawing.Color.White;
            this.btnEgreso.Location = new System.Drawing.Point(671, 491);
            this.btnEgreso.Name = "btnEgreso";
            this.btnEgreso.Size = new System.Drawing.Size(159, 35);
            this.btnEgreso.TabIndex = 104;
            this.btnEgreso.Tag = "";
            this.btnEgreso.Text = "Egreso";
            this.btnEgreso.UseVisualStyleBackColor = false;
            this.btnEgreso.Click += new System.EventHandler(this.btnEgreso_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(725, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 17);
            this.lblTotal.TabIndex = 105;
            this.lblTotal.Text = "Total $";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Black;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Lime;
            this.txtTotal.Location = new System.Drawing.Point(790, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(200, 23);
            this.txtTotal.TabIndex = 106;
            // 
            // cboCondicion
            // 
            this.cboCondicion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCondicion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCondicion.BackColor = System.Drawing.Color.GhostWhite;
            this.cboCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicion.FormattingEnabled = true;
            this.cboCondicion.Items.AddRange(new object[] {
            "Todas",
            "Efectivo",
            "Mercado Pago"});
            this.cboCondicion.Location = new System.Drawing.Point(122, 6);
            this.cboCondicion.Name = "cboCondicion";
            this.cboCondicion.Size = new System.Drawing.Size(291, 23);
            this.cboCondicion.TabIndex = 208;
            this.cboCondicion.SelectedIndexChanged += new System.EventHandler(this.cboCondicion_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 209;
            this.label7.Text = "Condición";
            // 
            // FrmMovCajaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 538);
            this.Controls.Add(this.cboCondicion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEgreso);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.btnCierre);
            this.Controls.Add(this.dtGView);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMovCajaList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos Caja";
            this.Activated += new System.EventHandler(this.FrmMovCajaList_Activated);
            this.Load += new System.EventHandler(this.FrmMovCajaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCierre;
        private System.Windows.Forms.DataGridView dtGView;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnEgreso;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cboCondicion;
        private System.Windows.Forms.Label label7;
    }
}