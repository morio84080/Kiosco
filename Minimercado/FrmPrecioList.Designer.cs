namespace Minimercado
{
    partial class FrmPrecioList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrecioList));
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtGView = new System.Windows.Forms.DataGridView();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.checkBoxTodos = new System.Windows.Forms.CheckBox();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cboDiseñoImpresion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxMantenerSeleccion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleDescription = "";
            this.btnPrint.AccessibleName = "";
            this.btnPrint.BackColor = System.Drawing.Color.Blue;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(699, 452);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(145, 35);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Tag = "";
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dtGView
            // 
            this.dtGView.AllowUserToAddRows = false;
            this.dtGView.AllowUserToDeleteRows = false;
            this.dtGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGView.Location = new System.Drawing.Point(12, 36);
            this.dtGView.MultiSelect = false;
            this.dtGView.Name = "dtGView";
            this.dtGView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGView.Size = new System.Drawing.Size(983, 406);
            this.dtGView.TabIndex = 4;
            this.dtGView.DoubleClick += new System.EventHandler(this.dtGView_DoubleClick);
            this.dtGView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtGView_KeyPress);
            this.dtGView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtGView_PreviewKeyDown);
            // 
            // cboRubro
            // 
            this.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRubro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(16, 466);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(209, 23);
            this.cboRubro.TabIndex = 39;
            this.cboRubro.SelectedIndexChanged += new System.EventHandler(this.cboRubro_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 445);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 18);
            this.label14.TabIndex = 40;
            this.label14.Text = "Rubro";
            // 
            // lblArticulo
            // 
            this.lblArticulo.BackColor = System.Drawing.Color.White;
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.ForeColor = System.Drawing.Color.Blue;
            this.lblArticulo.Location = new System.Drawing.Point(12, 10);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(356, 23);
            this.lblArticulo.TabIndex = 87;
            this.lblArticulo.Text = "Seleccionar Artículos para imprimir Precio";
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArticulo.Click += new System.EventHandler(this.lblArticulo_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // checkBoxTodos
            // 
            this.checkBoxTodos.AutoSize = true;
            this.checkBoxTodos.Checked = true;
            this.checkBoxTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTodos.Location = new System.Drawing.Point(918, 10);
            this.checkBoxTodos.Name = "checkBoxTodos";
            this.checkBoxTodos.Size = new System.Drawing.Size(77, 24);
            this.checkBoxTodos.TabIndex = 88;
            this.checkBoxTodos.Text = "Todos";
            this.checkBoxTodos.UseVisualStyleBackColor = true;
            this.checkBoxTodos.CheckedChanged += new System.EventHandler(this.checkBoxTodos_CheckedChanged);
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.Location = new System.Drawing.Point(250, 467);
            this.txtCodBarra.MaxLength = 20;
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(199, 21);
            this.txtCodBarra.TabIndex = 91;
            this.txtCodBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodBarra_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 90;
            this.label1.Text = "Cód. Barra";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "";
            this.button1.AccessibleName = "";
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(850, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 35);
            this.button1.TabIndex = 92;
            this.button1.Tag = "";
            this.button1.Text = "Limpiar Selección";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboDiseñoImpresion
            // 
            this.cboDiseñoImpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiseñoImpresion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDiseñoImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDiseñoImpresion.FormattingEnabled = true;
            this.cboDiseñoImpresion.Items.AddRange(new object[] {
            "Normal",
            "Oferta"});
            this.cboDiseñoImpresion.Location = new System.Drawing.Point(699, 7);
            this.cboDiseñoImpresion.Name = "cboDiseñoImpresion";
            this.cboDiseñoImpresion.Size = new System.Drawing.Size(209, 23);
            this.cboDiseñoImpresion.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(560, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.label2.TabIndex = 94;
            this.label2.Text = "Diseño Impresión";
            // 
            // checkBoxMantenerSeleccion
            // 
            this.checkBoxMantenerSeleccion.AutoSize = true;
            this.checkBoxMantenerSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMantenerSeleccion.ForeColor = System.Drawing.Color.Navy;
            this.checkBoxMantenerSeleccion.Location = new System.Drawing.Point(86, 448);
            this.checkBoxMantenerSeleccion.Name = "checkBoxMantenerSeleccion";
            this.checkBoxMantenerSeleccion.Size = new System.Drawing.Size(139, 17);
            this.checkBoxMantenerSeleccion.TabIndex = 95;
            this.checkBoxMantenerSeleccion.Text = "Mantener Seleccion";
            this.checkBoxMantenerSeleccion.UseVisualStyleBackColor = true;
            this.checkBoxMantenerSeleccion.Visible = false;
            // 
            // FrmPrecioList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 496);
            this.Controls.Add(this.checkBoxMantenerSeleccion);
            this.Controls.Add(this.cboDiseñoImpresion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCodBarra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxTodos);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.cboRubro);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtGView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrecioList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Articulos";
            this.Activated += new System.EventHandler(this.FrmPrecioList_Activated);
            this.Load += new System.EventHandler(this.FrmPrecioList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dtGView;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.CheckBox checkBoxTodos;
        private System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboDiseñoImpresion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxMantenerSeleccion;
    }
}