namespace Minimercado
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablasGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraArticuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajusteManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaArtículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaCorrienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recuperarRegistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirPreciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testImpresoraFiscalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesAFIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testFactElectrónicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cierresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCompra = new System.Windows.Forms.Button();
            this.btnCtaCte = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnArticulos = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnRubro = new System.Windows.Forms.Button();
            this.btnVendedor = new System.Windows.Forms.Button();
            this.btnLocalidad = new System.Windows.Forms.Button();
            this.lblUserOnline = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAjusteManual = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnRecRegistros = new System.Windows.Forms.Button();
            this.btnInformes = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.tablasGeneralesToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.cuentaCorrienteToolStripMenuItem,
            this.cajaToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.administraciónToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1111, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tablasGeneralesToolStripMenuItem
            // 
            this.tablasGeneralesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rubrosToolStripMenuItem,
            this.vendedoresToolStripMenuItem,
            this.localidadesToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.articulosToolStripMenuItem,
            this.proveedoresToolStripMenuItem1});
            this.tablasGeneralesToolStripMenuItem.Name = "tablasGeneralesToolStripMenuItem";
            this.tablasGeneralesToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.tablasGeneralesToolStripMenuItem.Text = "Tablas Generales";
            // 
            // rubrosToolStripMenuItem
            // 
            this.rubrosToolStripMenuItem.Name = "rubrosToolStripMenuItem";
            this.rubrosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.rubrosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.rubrosToolStripMenuItem.Text = "Rubros";
            this.rubrosToolStripMenuItem.Click += new System.EventHandler(this.rubrosToolStripMenuItem_Click);
            // 
            // vendedoresToolStripMenuItem
            // 
            this.vendedoresToolStripMenuItem.Name = "vendedoresToolStripMenuItem";
            this.vendedoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.vendedoresToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.vendedoresToolStripMenuItem.Text = "Operadores";
            this.vendedoresToolStripMenuItem.Click += new System.EventHandler(this.vendedoresToolStripMenuItem_Click);
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.localidadesToolStripMenuItem.Text = "Localidades";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.proveedoresToolStripMenuItem.Text = "Clientes";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.articulosToolStripMenuItem.Text = "Artículos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.artículosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem1
            // 
            this.proveedoresToolStripMenuItem1.Name = "proveedoresToolStripMenuItem1";
            this.proveedoresToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.proveedoresToolStripMenuItem1.Text = "Proveedores";
            this.proveedoresToolStripMenuItem1.Click += new System.EventHandler(this.proveedoresToolStripMenuItem1_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compraArticuloToolStripMenuItem,
            this.ajusteManualToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // compraArticuloToolStripMenuItem
            // 
            this.compraArticuloToolStripMenuItem.Name = "compraArticuloToolStripMenuItem";
            this.compraArticuloToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.compraArticuloToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.compraArticuloToolStripMenuItem.Text = "Compra Articulo";
            this.compraArticuloToolStripMenuItem.Click += new System.EventHandler(this.compraArticuloToolStripMenuItem_Click);
            // 
            // ajusteManualToolStripMenuItem
            // 
            this.ajusteManualToolStripMenuItem.Name = "ajusteManualToolStripMenuItem";
            this.ajusteManualToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.ajusteManualToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ajusteManualToolStripMenuItem.Text = "Ajuste Manual";
            this.ajusteManualToolStripMenuItem.Click += new System.EventHandler(this.ajusteManualToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventaArtículosToolStripMenuItem,
            this.listarVentasToolStripMenuItem});
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // ventaArtículosToolStripMenuItem
            // 
            this.ventaArtículosToolStripMenuItem.Name = "ventaArtículosToolStripMenuItem";
            this.ventaArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ventaArtículosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ventaArtículosToolStripMenuItem.Text = "Venta Artículos";
            this.ventaArtículosToolStripMenuItem.Click += new System.EventHandler(this.ventaArtículosToolStripMenuItem_Click);
            // 
            // listarVentasToolStripMenuItem
            // 
            this.listarVentasToolStripMenuItem.Name = "listarVentasToolStripMenuItem";
            this.listarVentasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.listarVentasToolStripMenuItem.Text = "Listar Ventas";
            this.listarVentasToolStripMenuItem.Click += new System.EventHandler(this.listarVentasToolStripMenuItem_Click);
            // 
            // cuentaCorrienteToolStripMenuItem
            // 
            this.cuentaCorrienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagosToolStripMenuItem,
            this.obtenerCuentaToolStripMenuItem});
            this.cuentaCorrienteToolStripMenuItem.Name = "cuentaCorrienteToolStripMenuItem";
            this.cuentaCorrienteToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.cuentaCorrienteToolStripMenuItem.Text = "Cuenta Corriente";
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.pagosToolStripMenuItem.Text = "Pagos";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // obtenerCuentaToolStripMenuItem
            // 
            this.obtenerCuentaToolStripMenuItem.Name = "obtenerCuentaToolStripMenuItem";
            this.obtenerCuentaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.obtenerCuentaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.obtenerCuentaToolStripMenuItem.Text = "Obtener Cuenta";
            this.obtenerCuentaToolStripMenuItem.Click += new System.EventHandler(this.obtenerCuentaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // generarToolStripMenuItem
            // 
            this.generarToolStripMenuItem.Name = "generarToolStripMenuItem";
            this.generarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.generarToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.generarToolStripMenuItem.Text = "Generar";
            this.generarToolStripMenuItem.Click += new System.EventHandler(this.generarToolStripMenuItem_Click);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recuperarRegistrosToolStripMenuItem,
            this.imprimirPreciosToolStripMenuItem,
            this.testImpresoraFiscalToolStripMenuItem,
            this.filesAFIPToolStripMenuItem,
            this.testFactElectrónicaToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            this.administraciónToolStripMenuItem.Visible = false;
            // 
            // recuperarRegistrosToolStripMenuItem
            // 
            this.recuperarRegistrosToolStripMenuItem.Name = "recuperarRegistrosToolStripMenuItem";
            this.recuperarRegistrosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.recuperarRegistrosToolStripMenuItem.Text = "Impresora Fiscal";
            this.recuperarRegistrosToolStripMenuItem.Click += new System.EventHandler(this.recuperarRegistrosToolStripMenuItem_Click);
            // 
            // imprimirPreciosToolStripMenuItem
            // 
            this.imprimirPreciosToolStripMenuItem.Name = "imprimirPreciosToolStripMenuItem";
            this.imprimirPreciosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.imprimirPreciosToolStripMenuItem.Text = "Imprimir Precios";
            this.imprimirPreciosToolStripMenuItem.Click += new System.EventHandler(this.imprimirPreciosToolStripMenuItem_Click);
            // 
            // testImpresoraFiscalToolStripMenuItem
            // 
            this.testImpresoraFiscalToolStripMenuItem.Name = "testImpresoraFiscalToolStripMenuItem";
            this.testImpresoraFiscalToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.testImpresoraFiscalToolStripMenuItem.Text = "Test Impresora Fiscal";
            this.testImpresoraFiscalToolStripMenuItem.Click += new System.EventHandler(this.testImpresoraFiscalToolStripMenuItem_Click);
            // 
            // filesAFIPToolStripMenuItem
            // 
            this.filesAFIPToolStripMenuItem.Name = "filesAFIPToolStripMenuItem";
            this.filesAFIPToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.filesAFIPToolStripMenuItem.Text = "Files AFIP";
            this.filesAFIPToolStripMenuItem.Click += new System.EventHandler(this.filesAFIPToolStripMenuItem_Click);
            // 
            // testFactElectrónicaToolStripMenuItem
            // 
            this.testFactElectrónicaToolStripMenuItem.Name = "testFactElectrónicaToolStripMenuItem";
            this.testFactElectrónicaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.testFactElectrónicaToolStripMenuItem.Text = "Test Fact Electrónica";
            this.testFactElectrónicaToolStripMenuItem.Click += new System.EventHandler(this.testFactElectrónicaToolStripMenuItem_Click);
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cajaToolStripMenuItem1,
            this.cierresToolStripMenuItem});
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cajaToolStripMenuItem.Text = "Caja";
            // 
            // cajaToolStripMenuItem1
            // 
            this.cajaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresoToolStripMenuItem,
            this.egresoToolStripMenuItem,
            this.movimientosToolStripMenuItem});
            this.cajaToolStripMenuItem1.Name = "cajaToolStripMenuItem1";
            this.cajaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cajaToolStripMenuItem1.Text = "Caja";
            // 
            // ingresoToolStripMenuItem
            // 
            this.ingresoToolStripMenuItem.Name = "ingresoToolStripMenuItem";
            this.ingresoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.ingresoToolStripMenuItem.Text = "Ingreso";
            this.ingresoToolStripMenuItem.Click += new System.EventHandler(this.ingresoToolStripMenuItem_Click);
            // 
            // egresoToolStripMenuItem
            // 
            this.egresoToolStripMenuItem.Name = "egresoToolStripMenuItem";
            this.egresoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.egresoToolStripMenuItem.Text = "Egreso";
            this.egresoToolStripMenuItem.Click += new System.EventHandler(this.egresoToolStripMenuItem_Click);
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.movimientosToolStripMenuItem.Text = "Movimientos";
            this.movimientosToolStripMenuItem.Click += new System.EventHandler(this.movimientosToolStripMenuItem_Click);
            // 
            // cierresToolStripMenuItem
            // 
            this.cierresToolStripMenuItem.Name = "cierresToolStripMenuItem";
            this.cierresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cierresToolStripMenuItem.Text = "Cierres";
            this.cierresToolStripMenuItem.Click += new System.EventHandler(this.cierresToolStripMenuItem_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompra.BackColor = System.Drawing.Color.White;
            this.btnCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompra.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompra.Location = new System.Drawing.Point(742, 146);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(363, 110);
            this.btnCompra.TabIndex = 7;
            this.btnCompra.Text = "F6 - Compras";
            this.btnCompra.UseVisualStyleBackColor = false;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCtaCte.BackColor = System.Drawing.Color.White;
            this.btnCtaCte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnCtaCte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnCtaCte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCtaCte.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCtaCte.Location = new System.Drawing.Point(742, 262);
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.Size = new System.Drawing.Size(363, 110);
            this.btnCtaCte.TabIndex = 8;
            this.btnCtaCte.Text = "F9 - Cuenta Corriente";
            this.btnCtaCte.UseVisualStyleBackColor = false;
            this.btnCtaCte.Click += new System.EventHandler(this.btnCtaCte_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVenta.BackColor = System.Drawing.Color.Red;
            this.btnVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.Color.White;
            this.btnVenta.Location = new System.Drawing.Point(374, 262);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(362, 110);
            this.btnVenta.TabIndex = 6;
            this.btnVenta.Text = "F8 - Ventas";
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnArticulos
            // 
            this.btnArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArticulos.BackColor = System.Drawing.Color.White;
            this.btnArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnArticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulos.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulos.Location = new System.Drawing.Point(374, 146);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.Size = new System.Drawing.Size(362, 110);
            this.btnArticulos.TabIndex = 5;
            this.btnArticulos.Text = "F5 - Artículos";
            this.btnArticulos.UseVisualStyleBackColor = false;
            this.btnArticulos.Click += new System.EventHandler(this.btnArticulos_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCliente.BackColor = System.Drawing.Color.White;
            this.btnCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Location = new System.Drawing.Point(6, 146);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(362, 110);
            this.btnCliente.TabIndex = 4;
            this.btnCliente.Text = "F4 - Clientes";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnRubro
            // 
            this.btnRubro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRubro.BackColor = System.Drawing.Color.White;
            this.btnRubro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnRubro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRubro.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRubro.Location = new System.Drawing.Point(6, 30);
            this.btnRubro.Name = "btnRubro";
            this.btnRubro.Size = new System.Drawing.Size(362, 110);
            this.btnRubro.TabIndex = 0;
            this.btnRubro.Text = "F1 - Rubros";
            this.btnRubro.UseVisualStyleBackColor = false;
            this.btnRubro.Click += new System.EventHandler(this.btnRubro_Click);
            // 
            // btnVendedor
            // 
            this.btnVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVendedor.BackColor = System.Drawing.Color.White;
            this.btnVendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnVendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendedor.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendedor.Location = new System.Drawing.Point(374, 30);
            this.btnVendedor.Name = "btnVendedor";
            this.btnVendedor.Size = new System.Drawing.Size(362, 110);
            this.btnVendedor.TabIndex = 1;
            this.btnVendedor.Text = "F2 - Operadores";
            this.btnVendedor.UseVisualStyleBackColor = false;
            this.btnVendedor.Click += new System.EventHandler(this.btnVendedor_Click);
            // 
            // btnLocalidad
            // 
            this.btnLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalidad.BackColor = System.Drawing.Color.White;
            this.btnLocalidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnLocalidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalidad.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalidad.Location = new System.Drawing.Point(742, 30);
            this.btnLocalidad.Name = "btnLocalidad";
            this.btnLocalidad.Size = new System.Drawing.Size(363, 110);
            this.btnLocalidad.TabIndex = 3;
            this.btnLocalidad.Text = "F3 - Localidades";
            this.btnLocalidad.UseVisualStyleBackColor = false;
            this.btnLocalidad.Click += new System.EventHandler(this.btnLocalidad_Click);
            // 
            // lblUserOnline
            // 
            this.lblUserOnline.AutoSize = true;
            this.lblUserOnline.BackColor = System.Drawing.Color.Transparent;
            this.lblUserOnline.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserOnline.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserOnline.ForeColor = System.Drawing.Color.White;
            this.lblUserOnline.Location = new System.Drawing.Point(6, 3);
            this.lblUserOnline.Name = "lblUserOnline";
            this.lblUserOnline.Size = new System.Drawing.Size(362, 24);
            this.lblUserOnline.TabIndex = 2;
            this.lblUserOnline.Text = "lblUserOnline";
            this.lblUserOnline.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3311F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel1.Controls.Add(this.btnAjusteManual, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblUserOnline, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnVendedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRubro, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnVenta, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCtaCte, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnLocalidad, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCliente, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnArticulos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCompra, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPagos, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnRecRegistros, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnInformes, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.00095F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.74976F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.74976F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.74976F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.74976F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1111, 498);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAjusteManual
            // 
            this.btnAjusteManual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjusteManual.BackColor = System.Drawing.Color.White;
            this.btnAjusteManual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnAjusteManual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnAjusteManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjusteManual.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjusteManual.Location = new System.Drawing.Point(6, 378);
            this.btnAjusteManual.Name = "btnAjusteManual";
            this.btnAjusteManual.Size = new System.Drawing.Size(362, 114);
            this.btnAjusteManual.TabIndex = 12;
            this.btnAjusteManual.Text = "F10 - Imprimir Precios";
            this.btnAjusteManual.UseVisualStyleBackColor = false;
            this.btnAjusteManual.Click += new System.EventHandler(this.btnAjusteManual_Click);
            // 
            // btnPagos
            // 
            this.btnPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagos.BackColor = System.Drawing.Color.White;
            this.btnPagos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnPagos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagos.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagos.Location = new System.Drawing.Point(6, 262);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(362, 110);
            this.btnPagos.TabIndex = 11;
            this.btnPagos.Text = "F7 - Pagos Clientes";
            this.btnPagos.UseVisualStyleBackColor = false;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnRecRegistros
            // 
            this.btnRecRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecRegistros.BackColor = System.Drawing.Color.White;
            this.btnRecRegistros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnRecRegistros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnRecRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecRegistros.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecRegistros.Location = new System.Drawing.Point(742, 378);
            this.btnRecRegistros.Name = "btnRecRegistros";
            this.btnRecRegistros.Size = new System.Drawing.Size(363, 114);
            this.btnRecRegistros.TabIndex = 10;
            this.btnRecRegistros.Text = "F12 - Impresora Fiscal";
            this.btnRecRegistros.UseVisualStyleBackColor = false;
            this.btnRecRegistros.Click += new System.EventHandler(this.btnRecRegistros_Click);
            // 
            // btnInformes
            // 
            this.btnInformes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInformes.BackColor = System.Drawing.Color.White;
            this.btnInformes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnInformes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformes.Location = new System.Drawing.Point(374, 378);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(362, 114);
            this.btnInformes.TabIndex = 9;
            this.btnInformes.Text = "F11 - Informes";
            this.btnInformes.UseVisualStyleBackColor = false;
            this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1111, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablasGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraArticuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajusteManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaArtículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentaCorrienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obtenerCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recuperarRegistrosToolStripMenuItem;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnCtaCte;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnArticulos;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnRubro;
        private System.Windows.Forms.Button btnVendedor;
        private System.Windows.Forms.Button btnLocalidad;
        private System.Windows.Forms.Label lblUserOnline;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.ToolStripMenuItem generarToolStripMenuItem;
        private System.Windows.Forms.Button btnRecRegistros;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnAjusteManual;
        private System.Windows.Forms.ToolStripMenuItem imprimirPreciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testImpresoraFiscalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ingresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem egresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cierresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesAFIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testFactElectrónicaToolStripMenuItem;
    }
}

