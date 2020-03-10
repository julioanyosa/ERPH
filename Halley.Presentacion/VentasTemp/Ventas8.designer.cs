namespace Halley.Presentacion.VentasTemp
{
    partial class Ventas8
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas8));
            this.BtnImprimir = new C1.Win.C1Input.C1Button();
            this.CboClientesNombre = new C1.Win.C1List.C1Combo();
            this.CboSerieGuias = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.CboTipoComprobante = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnNuevoCliente = new C1.Win.C1Input.C1Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboClientesCodigo = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDireccion = new C1.Win.C1Input.C1TextBox();
            this.TxtVentaNeta = new C1.Win.C1Input.C1TextBox();
            this.TxtIGV = new C1.Win.C1Input.C1TextBox();
            this.TxtValorVenta = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnNuevoComprobante = new C1.Win.C1Input.C1Button();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CboCaja = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.c1NELith = new C1.Win.C1Input.C1NumericEdit();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.LblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnConsultar = new System.Windows.Forms.ToolStripButton();
            this.BtnImprimir2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnVistaPrevia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNuevoComprobante2 = new System.Windows.Forms.ToolStripButton();
            this.LblComprobante = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TdgDocumento = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtCanasta = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CboClientesNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSerieGuias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboClientesCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVentaNeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtValorVenta)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NELith)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCanasta)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(887, 111);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(80, 25);
            this.BtnImprimir.TabIndex = 6;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // CboClientesNombre
            // 
            this.CboClientesNombre.AddItemSeparator = ';';
            this.CboClientesNombre.AutoCompletion = true;
            this.CboClientesNombre.AutoDropDown = true;
            this.CboClientesNombre.AutoSelect = true;
            this.CboClientesNombre.Caption = "";
            this.CboClientesNombre.CaptionHeight = 17;
            this.CboClientesNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboClientesNombre.ColumnCaptionHeight = 17;
            this.CboClientesNombre.ColumnFooterHeight = 17;
            this.CboClientesNombre.ColumnHeaders = false;
            this.CboClientesNombre.ContentHeight = 17;
            this.CboClientesNombre.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboClientesNombre.DisplayMember = "NomEmpresa";
            this.CboClientesNombre.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboClientesNombre.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboClientesNombre.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboClientesNombre.EditorHeight = 17;
            this.CboClientesNombre.Images.Add(((System.Drawing.Image)(resources.GetObject("CboClientesNombre.Images"))));
            this.CboClientesNombre.ItemHeight = 15;
            this.CboClientesNombre.Location = new System.Drawing.Point(176, 16);
            this.CboClientesNombre.MatchEntryTimeout = ((long)(2000));
            this.CboClientesNombre.MaxDropDownItems = ((short)(10));
            this.CboClientesNombre.MaxLength = 32767;
            this.CboClientesNombre.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboClientesNombre.Name = "CboClientesNombre";
            this.CboClientesNombre.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboClientesNombre.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboClientesNombre.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboClientesNombre.Size = new System.Drawing.Size(414, 23);
            this.CboClientesNombre.TabIndex = 329;
            this.CboClientesNombre.ValueMember = "EmpresaID";
            this.CboClientesNombre.PropBag = resources.GetString("CboClientesNombre.PropBag");
            // 
            // CboSerieGuias
            // 
            this.CboSerieGuias.AddItemSeparator = ';';
            this.CboSerieGuias.AutoCompletion = true;
            this.CboSerieGuias.AutoDropDown = true;
            this.CboSerieGuias.Caption = "";
            this.CboSerieGuias.CaptionHeight = 17;
            this.CboSerieGuias.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboSerieGuias.ColumnCaptionHeight = 17;
            this.CboSerieGuias.ColumnFooterHeight = 17;
            this.CboSerieGuias.ColumnHeaders = false;
            this.CboSerieGuias.ContentHeight = 17;
            this.CboSerieGuias.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSerieGuias.DisplayMember = "NomEmpresa";
            this.CboSerieGuias.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSerieGuias.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSerieGuias.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSerieGuias.EditorHeight = 17;
            this.CboSerieGuias.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSerieGuias.Images"))));
            this.CboSerieGuias.ItemHeight = 15;
            this.CboSerieGuias.Location = new System.Drawing.Point(541, 108);
            this.CboSerieGuias.MatchEntryTimeout = ((long)(2000));
            this.CboSerieGuias.MaxDropDownItems = ((short)(10));
            this.CboSerieGuias.MaxLength = 32767;
            this.CboSerieGuias.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSerieGuias.Name = "CboSerieGuias";
            this.CboSerieGuias.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSerieGuias.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSerieGuias.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSerieGuias.Size = new System.Drawing.Size(87, 23);
            this.CboSerieGuias.TabIndex = 331;
            this.CboSerieGuias.ValueMember = "EmpresaID";
            this.CboSerieGuias.PropBag = resources.GetString("CboSerieGuias.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 330;
            this.label1.Text = "Serie:";
            // 
            // CboTipoComprobante
            // 
            this.CboTipoComprobante.AddItemSeparator = ';';
            this.CboTipoComprobante.AutoCompletion = true;
            this.CboTipoComprobante.AutoDropDown = true;
            this.CboTipoComprobante.Caption = "";
            this.CboTipoComprobante.CaptionHeight = 17;
            this.CboTipoComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoComprobante.ColumnCaptionHeight = 17;
            this.CboTipoComprobante.ColumnFooterHeight = 17;
            this.CboTipoComprobante.ColumnHeaders = false;
            this.CboTipoComprobante.ColumnWidth = 100;
            this.CboTipoComprobante.ContentHeight = 17;
            this.CboTipoComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobante.DisplayMember = "NomEmpresa";
            this.CboTipoComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobante.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobante.EditorHeight = 17;
            this.CboTipoComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobante.Images"))));
            this.CboTipoComprobante.ItemHeight = 15;
            this.CboTipoComprobante.Location = new System.Drawing.Point(328, 108);
            this.CboTipoComprobante.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobante.MaxDropDownItems = ((short)(10));
            this.CboTipoComprobante.MaxLength = 32767;
            this.CboTipoComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.Size = new System.Drawing.Size(107, 23);
            this.CboTipoComprobante.TabIndex = 333;
            this.CboTipoComprobante.ValueMember = "EmpresaID";
            this.CboTipoComprobante.SelectedValueChanged += new System.EventHandler(this.CboTipoDocumentos_SelectedValueChanged);
            this.CboTipoComprobante.PropBag = resources.GetString("CboTipoComprobante.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 332;
            this.label2.Text = "Tipo de Emisión:";
            // 
            // BtnNuevoCliente
            // 
            this.BtnNuevoCliente.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevoCliente.Location = new System.Drawing.Point(596, 13);
            this.BtnNuevoCliente.Name = "BtnNuevoCliente";
            this.BtnNuevoCliente.Size = new System.Drawing.Size(80, 25);
            this.BtnNuevoCliente.TabIndex = 336;
            this.BtnNuevoCliente.Text = "Nuevo";
            this.BtnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevoCliente.UseVisualStyleBackColor = true;
            this.BtnNuevoCliente.Click += new System.EventHandler(this.BtnNuevoCliente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboClientesCodigo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtDireccion);
            this.groupBox1.Controls.Add(this.BtnNuevoCliente);
            this.groupBox1.Controls.Add(this.CboClientesNombre);
            this.groupBox1.Location = new System.Drawing.Point(6, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 71);
            this.groupBox1.TabIndex = 337;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente:";
            // 
            // CboClientesCodigo
            // 
            this.CboClientesCodigo.AddItemSeparator = ';';
            this.CboClientesCodigo.AutoCompletion = true;
            this.CboClientesCodigo.AutoDropDown = true;
            this.CboClientesCodigo.AutoSelect = true;
            this.CboClientesCodigo.Caption = "";
            this.CboClientesCodigo.CaptionHeight = 17;
            this.CboClientesCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboClientesCodigo.ColumnCaptionHeight = 17;
            this.CboClientesCodigo.ColumnFooterHeight = 17;
            this.CboClientesCodigo.ColumnHeaders = false;
            this.CboClientesCodigo.ContentHeight = 17;
            this.CboClientesCodigo.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboClientesCodigo.DisplayMember = "NomEmpresa";
            this.CboClientesCodigo.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboClientesCodigo.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboClientesCodigo.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboClientesCodigo.EditorHeight = 17;
            this.CboClientesCodigo.Images.Add(((System.Drawing.Image)(resources.GetObject("CboClientesCodigo.Images"))));
            this.CboClientesCodigo.ItemHeight = 15;
            this.CboClientesCodigo.Location = new System.Drawing.Point(7, 15);
            this.CboClientesCodigo.MatchEntryTimeout = ((long)(2000));
            this.CboClientesCodigo.MaxDropDownItems = ((short)(10));
            this.CboClientesCodigo.MaxLength = 32767;
            this.CboClientesCodigo.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboClientesCodigo.Name = "CboClientesCodigo";
            this.CboClientesCodigo.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboClientesCodigo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboClientesCodigo.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboClientesCodigo.Size = new System.Drawing.Size(163, 23);
            this.CboClientesCodigo.TabIndex = 339;
            this.CboClientesCodigo.ValueMember = "EmpresaID";
            this.CboClientesCodigo.SelectedValueChanged += new System.EventHandler(this.CboClientesCodigo_SelectedValueChanged);
            this.CboClientesCodigo.PropBag = resources.GetString("CboClientesCodigo.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 338;
            this.label3.Text = "Dirección:";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.BackColor = System.Drawing.Color.White;
            this.TxtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDireccion.Location = new System.Drawing.Point(73, 45);
            this.TxtDireccion.MaxLength = 150;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(444, 20);
            this.TxtDireccion.TabIndex = 337;
            this.TxtDireccion.Tag = null;
            this.TxtDireccion.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtDireccion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtVentaNeta
            // 
            this.TxtVentaNeta.BackColor = System.Drawing.Color.White;
            this.TxtVentaNeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVentaNeta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVentaNeta.Location = new System.Drawing.Point(421, 15);
            this.TxtVentaNeta.MaxLength = 8;
            this.TxtVentaNeta.Name = "TxtVentaNeta";
            this.TxtVentaNeta.Size = new System.Drawing.Size(100, 27);
            this.TxtVentaNeta.TabIndex = 339;
            this.TxtVentaNeta.Tag = null;
            this.TxtVentaNeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtVentaNeta.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtVentaNeta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtIGV
            // 
            this.TxtIGV.BackColor = System.Drawing.Color.White;
            this.TxtIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtIGV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIGV.Location = new System.Drawing.Point(239, 18);
            this.TxtIGV.MaxLength = 8;
            this.TxtIGV.Name = "TxtIGV";
            this.TxtIGV.Size = new System.Drawing.Size(100, 20);
            this.TxtIGV.TabIndex = 340;
            this.TxtIGV.Tag = null;
            this.TxtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtIGV.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtIGV.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtValorVenta
            // 
            this.TxtValorVenta.BackColor = System.Drawing.Color.White;
            this.TxtValorVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtValorVenta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtValorVenta.Location = new System.Drawing.Point(82, 18);
            this.TxtValorVenta.MaxLength = 8;
            this.TxtValorVenta.Name = "TxtValorVenta";
            this.TxtValorVenta.Size = new System.Drawing.Size(100, 20);
            this.TxtValorVenta.TabIndex = 341;
            this.TxtValorVenta.Tag = null;
            this.TxtValorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtValorVenta.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtValorVenta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 342;
            this.label4.Text = "Valor Venta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 343;
            this.label5.Text = "IGV:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 344;
            this.label6.Text = "Venta Neta:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtValorVenta);
            this.groupBox2.Controls.Add(this.TxtIGV);
            this.groupBox2.Controls.Add(this.TxtVentaNeta);
            this.groupBox2.Location = new System.Drawing.Point(436, 425);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 48);
            this.groupBox2.TabIndex = 345;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totales:";
            // 
            // BtnNuevoComprobante
            // 
            this.BtnNuevoComprobante.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevoComprobante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevoComprobante.Location = new System.Drawing.Point(887, 72);
            this.BtnNuevoComprobante.Name = "BtnNuevoComprobante";
            this.BtnNuevoComprobante.Size = new System.Drawing.Size(80, 25);
            this.BtnNuevoComprobante.TabIndex = 347;
            this.BtnNuevoComprobante.Text = "Nuevo";
            this.BtnNuevoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevoComprobante.UseVisualStyleBackColor = true;
            this.BtnNuevoComprobante.Click += new System.EventHandler(this.BtnNuevoComprobante_Click);
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            this.ErrProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrProvider.Icon")));
            // 
            // CboCaja
            // 
            this.CboCaja.AddItemSeparator = ';';
            this.CboCaja.AutoCompletion = true;
            this.CboCaja.AutoDropDown = true;
            this.CboCaja.Caption = "";
            this.CboCaja.CaptionHeight = 17;
            this.CboCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboCaja.ColumnCaptionHeight = 17;
            this.CboCaja.ColumnFooterHeight = 17;
            this.CboCaja.ColumnHeaders = false;
            this.CboCaja.ContentHeight = 17;
            this.CboCaja.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboCaja.DisplayMember = "NomEmpresa";
            this.CboCaja.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboCaja.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCaja.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboCaja.EditorHeight = 17;
            this.CboCaja.Images.Add(((System.Drawing.Image)(resources.GetObject("CboCaja.Images"))));
            this.CboCaja.ItemHeight = 15;
            this.CboCaja.Location = new System.Drawing.Point(35, 108);
            this.CboCaja.MatchEntryTimeout = ((long)(2000));
            this.CboCaja.MaxDropDownItems = ((short)(10));
            this.CboCaja.MaxLength = 32767;
            this.CboCaja.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboCaja.Name = "CboCaja";
            this.CboCaja.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboCaja.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboCaja.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboCaja.Size = new System.Drawing.Size(141, 23);
            this.CboCaja.TabIndex = 349;
            this.CboCaja.ValueMember = "EmpresaID";
            this.CboCaja.SelectedValueChanged += new System.EventHandler(this.CboCaja_SelectedValueChanged);
            this.CboCaja.PropBag = resources.GetString("CboCaja.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 348;
            this.label7.Text = "Caja:";
            // 
            // c1NELith
            // 
            this.c1NELith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.c1NELith.Calculator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.c1NELith.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.c1NELith.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Black;
            this.c1NELith.DataType = typeof(int);
            this.c1NELith.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1NELith.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1NELith.Location = new System.Drawing.Point(413, 250);
            this.c1NELith.Name = "c1NELith";
            this.c1NELith.Size = new System.Drawing.Size(77, 20);
            this.c1NELith.TabIndex = 350;
            this.c1NELith.Tag = null;
            this.c1NELith.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1NELith.Visible = false;
            this.c1NELith.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblUsuario,
            this.toolStripSeparator2,
            this.BtnConsultar,
            this.BtnImprimir2,
            this.toolStripSeparator1,
            this.BtnVistaPrevia,
            this.toolStripSeparator3,
            this.BtnNuevoComprobante2,
            this.LblComprobante});
            this.toolStrip2.Location = new System.Drawing.Point(6, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(516, 25);
            this.toolStrip2.TabIndex = 351;
            this.toolStrip2.Text = "TsImpresion";
            // 
            // LblUsuario
            // 
            this.LblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(59, 22);
            this.LblUsuario.Text = "LblEstado";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Image = global::Halley.Presentacion.Properties.Resources.Consultar_16x16;
            this.BtnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(130, 22);
            this.BtnConsultar.Text = "Consultar producto";
            this.BtnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // BtnImprimir2
            // 
            this.BtnImprimir2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnImprimir2.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnImprimir2.Name = "BtnImprimir2";
            this.BtnImprimir2.Size = new System.Drawing.Size(23, 22);
            this.BtnImprimir2.Text = "toolStripButton1";
            this.BtnImprimir2.ToolTipText = "Imprimir";
            this.BtnImprimir2.Click += new System.EventHandler(this.BtnImprimir2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnVistaPrevia
            // 
            this.BtnVistaPrevia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnVistaPrevia.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.BtnVistaPrevia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnVistaPrevia.Name = "BtnVistaPrevia";
            this.BtnVistaPrevia.Size = new System.Drawing.Size(23, 22);
            this.BtnVistaPrevia.Text = "toolStripButton2";
            this.BtnVistaPrevia.ToolTipText = "Seleccionar impresora";
            this.BtnVistaPrevia.Click += new System.EventHandler(this.BtnVistaPrevia_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnNuevoComprobante2
            // 
            this.BtnNuevoComprobante2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNuevoComprobante2.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevoComprobante2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNuevoComprobante2.Name = "BtnNuevoComprobante2";
            this.BtnNuevoComprobante2.Size = new System.Drawing.Size(23, 22);
            this.BtnNuevoComprobante2.Text = "toolStripButton1";
            this.BtnNuevoComprobante2.ToolTipText = "Nuevo comprobante";
            this.BtnNuevoComprobante2.Click += new System.EventHandler(this.BtnNuevoComprobante2_Click);
            // 
            // LblComprobante
            // 
            this.LblComprobante.Name = "LblComprobante";
            this.LblComprobante.Size = new System.Drawing.Size(228, 22);
            this.LblComprobante.Text = "Ultimo Comprobante Agregado: Ninguno";
            // 
            // TdgDocumento
            // 
            this.TdgDocumento.AllowAddNew = true;
            this.TdgDocumento.AllowDelete = true;
            this.TdgDocumento.AllowSort = false;
            this.TdgDocumento.CaptionHeight = 17;
            this.TdgDocumento.EmptyRows = true;
            this.TdgDocumento.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgDocumento.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgDocumento.Images"))));
            this.TdgDocumento.Location = new System.Drawing.Point(21, 143);
            this.TdgDocumento.Name = "TdgDocumento";
            this.TdgDocumento.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgDocumento.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgDocumento.PreviewInfo.ZoomFactor = 75D;
            this.TdgDocumento.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgDocumento.PrintInfo.PageSettings")));
            this.TdgDocumento.RowHeight = 15;
            this.TdgDocumento.Size = new System.Drawing.Size(945, 276);
            this.TdgDocumento.TabIndex = 5;
            this.TdgDocumento.Text = "c1TrueDBGrid1";
            this.TdgDocumento.AfterDelete += new System.EventHandler(this.TdgDocumento_AfterDelete);
            this.TdgDocumento.AfterInsert += new System.EventHandler(this.TdgDocumento_AfterInsert);
            this.TdgDocumento.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.TdgDocumento_BeforeColUpdate);
            this.TdgDocumento.BeforeInsert += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.TdgDocumento_BeforeInsert);
            this.TdgDocumento.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.TdgDocumento_BeforeUpdate);
            this.TdgDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TdgDocumento_KeyPress);
            this.TdgDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TdgDocumento_KeyUp);
            this.TdgDocumento.PropBag = resources.GetString("TdgDocumento.PropBag");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(725, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 341;
            this.label8.Text = "Canasta:";
            // 
            // TxtCanasta
            // 
            this.TxtCanasta.BackColor = System.Drawing.Color.White;
            this.TxtCanasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCanasta.Location = new System.Drawing.Point(782, 31);
            this.TxtCanasta.MaxLength = 2;
            this.TxtCanasta.Name = "TxtCanasta";
            this.TxtCanasta.Size = new System.Drawing.Size(45, 20);
            this.TxtCanasta.TabIndex = 340;
            this.TxtCanasta.Tag = null;
            this.TxtCanasta.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtCanasta.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.TxtCanasta);
            this.Controls.Add(this.c1NELith);
            this.Controls.Add(this.CboCaja);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnNuevoComprobante);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CboTipoComprobante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CboSerieGuias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.TdgDocumento);
            this.Name = "Ventas";
            this.Size = new System.Drawing.Size(1050, 526);
            this.Load += new System.EventHandler(this.Ventas_Load);
            this.Controls.SetChildIndex(this.TdgDocumento, 0);
            this.Controls.SetChildIndex(this.BtnImprimir, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CboSerieGuias, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.CboTipoComprobante, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.BtnNuevoComprobante, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.CboCaja, 0);
            this.Controls.SetChildIndex(this.c1NELith, 0);
            this.Controls.SetChildIndex(this.TxtCanasta, 0);
            this.Controls.SetChildIndex(this.toolStrip2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboClientesNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSerieGuias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboClientesCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVentaNeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtValorVenta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NELith)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCanasta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnImprimir;
        private C1.Win.C1List.C1Combo CboClientesNombre;
        private C1.Win.C1List.C1Combo CboSerieGuias;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1List.C1Combo CboTipoComprobante;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1Button BtnNuevoCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox TxtDireccion;
        private C1.Win.C1Input.C1TextBox TxtVentaNeta;
        private C1.Win.C1Input.C1TextBox TxtIGV;
        private C1.Win.C1Input.C1TextBox TxtValorVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1Input.C1Button BtnNuevoComprobante;
        private C1.Win.C1List.C1Combo CboClientesCodigo;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private C1.Win.C1List.C1Combo CboCaja;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1NumericEdit c1NELith;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel LblUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnConsultar;
        private System.Windows.Forms.ToolStripButton BtnImprimir2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnVistaPrevia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnNuevoComprobante2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripLabel LblComprobante;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgDocumento;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Input.C1TextBox TxtCanasta;
    }
}
