namespace Halley.Presentacion.Contabilidad.Reportes
{
    partial class ConsolidadoVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsolidadoVentas));
            this.CboAnno = new C1.Win.C1List.C1Combo();
            this.label11 = new System.Windows.Forms.Label();
            this.CboPeriodo = new C1.Win.C1List.C1Combo();
            this.label10 = new System.Windows.Forms.Label();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.btnConsultar = new C1.Win.C1Input.C1Button();
            this.CrvConsolidadoVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.CboTipoComprobante = new C1.Win.C1List.C1Combo();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSeries = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnFiltrar = new C1.Win.C1Input.C1Button();
            this.BtnResumenDiario = new C1.Win.C1Input.C1Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CboTipoComprobanteListado = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnConsultarListado = new C1.Win.C1Input.C1Button();
            this.DtpFechaFinListado = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFechaIniListado = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnImprimir = new C1.Win.C1Input.C1Button();
            this.TdgComprobantes = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TxtFormato = new C1.Win.C1Input.C1TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSeries)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobanteListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).BeginInit();
            this.SuspendLayout();
            // 
            // CboAnno
            // 
            this.CboAnno.AddItemSeparator = ';';
            this.CboAnno.Caption = "";
            this.CboAnno.CaptionHeight = 17;
            this.CboAnno.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboAnno.ColumnCaptionHeight = 17;
            this.CboAnno.ColumnFooterHeight = 17;
            this.CboAnno.ColumnWidth = 54;
            this.CboAnno.ContentHeight = 17;
            this.CboAnno.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAnno.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAnno.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAnno.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAnno.EditorHeight = 17;
            this.CboAnno.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAnno.Images"))));
            this.CboAnno.ItemHeight = 15;
            this.CboAnno.Location = new System.Drawing.Point(344, 6);
            this.CboAnno.MatchEntryTimeout = ((long)(2000));
            this.CboAnno.MaxDropDownItems = ((short)(5));
            this.CboAnno.MaxLength = 32767;
            this.CboAnno.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAnno.Name = "CboAnno";
            this.CboAnno.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAnno.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAnno.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAnno.Size = new System.Drawing.Size(82, 23);
            this.CboAnno.TabIndex = 401;
            this.CboAnno.PropBag = resources.GetString("CboAnno.PropBag");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(287, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 400;
            this.label11.Text = "Año:";
            // 
            // CboPeriodo
            // 
            this.CboPeriodo.AddItemSeparator = ';';
            this.CboPeriodo.Caption = "";
            this.CboPeriodo.CaptionHeight = 17;
            this.CboPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboPeriodo.ColumnCaptionHeight = 17;
            this.CboPeriodo.ColumnFooterHeight = 17;
            this.CboPeriodo.ContentHeight = 17;
            this.CboPeriodo.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboPeriodo.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboPeriodo.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboPeriodo.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboPeriodo.EditorHeight = 17;
            this.CboPeriodo.Images.Add(((System.Drawing.Image)(resources.GetObject("CboPeriodo.Images"))));
            this.CboPeriodo.ItemHeight = 15;
            this.CboPeriodo.Location = new System.Drawing.Point(93, 29);
            this.CboPeriodo.MatchEntryTimeout = ((long)(2000));
            this.CboPeriodo.MaxDropDownItems = ((short)(5));
            this.CboPeriodo.MaxLength = 32767;
            this.CboPeriodo.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboPeriodo.Name = "CboPeriodo";
            this.CboPeriodo.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboPeriodo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboPeriodo.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboPeriodo.Size = new System.Drawing.Size(160, 23);
            this.CboPeriodo.TabIndex = 399;
            this.CboPeriodo.PropBag = resources.GetString("CboPeriodo.PropBag");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 398;
            this.label10.Text = "Periodo:";
            // 
            // c1cboCia
            // 
            this.c1cboCia.AddItemSeparator = ';';
            this.c1cboCia.AutoCompletion = true;
            this.c1cboCia.AutoDropDown = true;
            this.c1cboCia.Caption = "";
            this.c1cboCia.CaptionHeight = 17;
            this.c1cboCia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1cboCia.ColumnCaptionHeight = 17;
            this.c1cboCia.ColumnFooterHeight = 17;
            this.c1cboCia.ColumnHeaders = false;
            this.c1cboCia.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.c1cboCia.ContentHeight = 17;
            this.c1cboCia.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCia.DisplayMember = "NomEmpresa";
            this.c1cboCia.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCia.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCia.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCia.EditorHeight = 17;
            this.c1cboCia.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCia.Images"))));
            this.c1cboCia.ItemHeight = 15;
            this.c1cboCia.Location = new System.Drawing.Point(253, 13);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(188, 23);
            this.c1cboCia.TabIndex = 417;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.SelectedValueChanged += new System.EventHandler(this.c1cboCia_SelectedValueChanged);
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(147, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 418;
            this.label14.Text = "Empresa:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.btnConsultar.Location = new System.Drawing.Point(494, 32);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(90, 23);
            this.btnConsultar.TabIndex = 419;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // CrvConsolidadoVentas
            // 
            this.CrvConsolidadoVentas.ActiveViewIndex = -1;
            this.CrvConsolidadoVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvConsolidadoVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvConsolidadoVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvConsolidadoVentas.Location = new System.Drawing.Point(8, 60);
            this.CrvConsolidadoVentas.Name = "CrvConsolidadoVentas";
            this.CrvConsolidadoVentas.Size = new System.Drawing.Size(814, 323);
            this.CrvConsolidadoVentas.TabIndex = 420;
            this.CrvConsolidadoVentas.ToolPanelWidth = 195;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 17);
            this.label1.TabIndex = 421;
            this.label1.Text = "Consolidado de ventas por periodo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CboTipoComprobante
            // 
            this.CboTipoComprobante.AddItemSeparator = ';';
            this.CboTipoComprobante.Caption = "";
            this.CboTipoComprobante.CaptionHeight = 17;
            this.CboTipoComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoComprobante.ColumnCaptionHeight = 17;
            this.CboTipoComprobante.ColumnFooterHeight = 17;
            this.CboTipoComprobante.ColumnHeaders = false;
            this.CboTipoComprobante.ColumnWidth = 100;
            this.CboTipoComprobante.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboTipoComprobante.ContentHeight = 17;
            this.CboTipoComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobante.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobante.EditorHeight = 17;
            this.CboTipoComprobante.ExtendRightColumn = true;
            this.CboTipoComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobante.Images"))));
            this.CboTipoComprobante.ItemHeight = 15;
            this.CboTipoComprobante.Location = new System.Drawing.Point(93, 8);
            this.CboTipoComprobante.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobante.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobante.MaxLength = 32767;
            this.CboTipoComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.Size = new System.Drawing.Size(188, 23);
            this.CboTipoComprobante.TabIndex = 422;
            this.CboTipoComprobante.PropBag = resources.GetString("CboTipoComprobante.PropBag");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 423;
            this.label9.Text = "Comprobante :";
            // 
            // cboSeries
            // 
            this.cboSeries.AddItemSeparator = ';';
            this.cboSeries.Caption = "";
            this.cboSeries.CaptionHeight = 17;
            this.cboSeries.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboSeries.ColumnCaptionHeight = 17;
            this.cboSeries.ColumnFooterHeight = 17;
            this.cboSeries.ColumnWidth = 54;
            this.cboSeries.ContentHeight = 17;
            this.cboSeries.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cboSeries.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cboSeries.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cboSeries.EditorHeight = 17;
            this.cboSeries.Images.Add(((System.Drawing.Image)(resources.GetObject("cboSeries.Images"))));
            this.cboSeries.ItemHeight = 15;
            this.cboSeries.Location = new System.Drawing.Point(480, 3);
            this.cboSeries.MatchEntryTimeout = ((long)(2000));
            this.cboSeries.MaxDropDownItems = ((short)(5));
            this.cboSeries.MaxLength = 32767;
            this.cboSeries.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cboSeries.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cboSeries.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cboSeries.Size = new System.Drawing.Size(82, 23);
            this.cboSeries.TabIndex = 425;
            this.cboSeries.PropBag = resources.GetString("cboSeries.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 26);
            this.label2.TabIndex = 424;
            this.label2.Text = "Filtrar\r\nserie:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Image = global::Halley.Presentacion.Properties.Resources.filter_16x16;
            this.BtnFiltrar.Location = new System.Drawing.Point(568, 3);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(24, 23);
            this.BtnFiltrar.TabIndex = 426;
            this.BtnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // BtnResumenDiario
            // 
            this.BtnResumenDiario.Image = ((System.Drawing.Image)(resources.GetObject("BtnResumenDiario.Image")));
            this.BtnResumenDiario.Location = new System.Drawing.Point(681, 34);
            this.BtnResumenDiario.Name = "BtnResumenDiario";
            this.BtnResumenDiario.Size = new System.Drawing.Size(99, 20);
            this.BtnResumenDiario.TabIndex = 427;
            this.BtnResumenDiario.Text = "Resumen Diario";
            this.BtnResumenDiario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnResumenDiario.UseVisualStyleBackColor = true;
            this.BtnResumenDiario.Click += new System.EventHandler(this.BtnResumenDiario_Click);
            // 
            // dtpfecha
            // 
            this.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha.Location = new System.Drawing.Point(674, 3);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(101, 22);
            this.dtpfecha.TabIndex = 429;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 428;
            this.label5.Text = "Fecha :";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 43);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 410);
            this.tabControl1.TabIndex = 430;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CboTipoComprobante);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.BtnResumenDiario);
            this.tabPage1.Controls.Add(this.dtpfecha);
            this.tabPage1.Controls.Add(this.CboPeriodo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CrvConsolidadoVentas);
            this.tabPage1.Controls.Add(this.BtnFiltrar);
            this.tabPage1.Controls.Add(this.CboAnno);
            this.tabPage1.Controls.Add(this.cboSeries);
            this.tabPage1.Controls.Add(this.btnConsultar);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(825, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reporte";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CboTipoComprobanteListado);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.BtnConsultarListado);
            this.tabPage2.Controls.Add(this.DtpFechaFinListado);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DtpFechaIniListado);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.BtnImprimir);
            this.tabPage2.Controls.Add(this.TdgComprobantes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(825, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Listado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CboTipoComprobanteListado
            // 
            this.CboTipoComprobanteListado.AddItemSeparator = ';';
            this.CboTipoComprobanteListado.Caption = "";
            this.CboTipoComprobanteListado.CaptionHeight = 17;
            this.CboTipoComprobanteListado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoComprobanteListado.ColumnCaptionHeight = 17;
            this.CboTipoComprobanteListado.ColumnFooterHeight = 17;
            this.CboTipoComprobanteListado.ColumnHeaders = false;
            this.CboTipoComprobanteListado.ColumnWidth = 100;
            this.CboTipoComprobanteListado.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboTipoComprobanteListado.ContentHeight = 17;
            this.CboTipoComprobanteListado.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobanteListado.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobanteListado.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobanteListado.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobanteListado.EditorHeight = 17;
            this.CboTipoComprobanteListado.ExtendRightColumn = true;
            this.CboTipoComprobanteListado.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobanteListado.Images"))));
            this.CboTipoComprobanteListado.ItemHeight = 15;
            this.CboTipoComprobanteListado.Location = new System.Drawing.Point(116, 3);
            this.CboTipoComprobanteListado.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobanteListado.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobanteListado.MaxLength = 32767;
            this.CboTipoComprobanteListado.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobanteListado.Name = "CboTipoComprobanteListado";
            this.CboTipoComprobanteListado.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobanteListado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobanteListado.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobanteListado.Size = new System.Drawing.Size(188, 23);
            this.CboTipoComprobanteListado.TabIndex = 444;
            this.CboTipoComprobanteListado.PropBag = resources.GetString("CboTipoComprobanteListado.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 445;
            this.label7.Text = "Comprobante :";
            // 
            // BtnConsultarListado
            // 
            this.BtnConsultarListado.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.BtnConsultarListado.Location = new System.Drawing.Point(393, 34);
            this.BtnConsultarListado.Name = "BtnConsultarListado";
            this.BtnConsultarListado.Size = new System.Drawing.Size(90, 23);
            this.BtnConsultarListado.TabIndex = 443;
            this.BtnConsultarListado.Text = "Consultar";
            this.BtnConsultarListado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConsultarListado.UseVisualStyleBackColor = true;
            this.BtnConsultarListado.Click += new System.EventHandler(this.BtnConsultarListado_Click);
            // 
            // DtpFechaFinListado
            // 
            this.DtpFechaFinListado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFinListado.Location = new System.Drawing.Point(286, 34);
            this.DtpFechaFinListado.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFinListado.Name = "DtpFechaFinListado";
            this.DtpFechaFinListado.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaFinListado.TabIndex = 441;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 442;
            this.label3.Text = "Fecha final:";
            // 
            // DtpFechaIniListado
            // 
            this.DtpFechaIniListado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIniListado.Location = new System.Drawing.Point(108, 34);
            this.DtpFechaIniListado.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIniListado.Name = "DtpFechaIniListado";
            this.DtpFechaIniListado.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaIniListado.TabIndex = 439;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 440;
            this.label6.Text = "Fecha inicial:";
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(733, 10);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(80, 25);
            this.BtnImprimir.TabIndex = 438;
            this.BtnImprimir.Text = "Im&primir";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // TdgComprobantes
            // 
            this.TdgComprobantes.AllowUpdate = false;
            this.TdgComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TdgComprobantes.CaptionHeight = 17;
            this.TdgComprobantes.FilterBar = true;
            this.TdgComprobantes.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgComprobantes.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgComprobantes.Images"))));
            this.TdgComprobantes.Location = new System.Drawing.Point(8, 63);
            this.TdgComprobantes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell;
            this.TdgComprobantes.Name = "TdgComprobantes";
            this.TdgComprobantes.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgComprobantes.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgComprobantes.PreviewInfo.ZoomFactor = 75D;
            this.TdgComprobantes.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgComprobantes.PrintInfo.PageSettings")));
            this.TdgComprobantes.RowHeight = 27;
            this.TdgComprobantes.Size = new System.Drawing.Size(817, 314);
            this.TdgComprobantes.TabIndex = 437;
            this.TdgComprobantes.Text = "c1TrueDBGrid1";
            this.TdgComprobantes.PropBag = resources.GetString("TdgComprobantes.PropBag");
            // 
            // TxtFormato
            // 
            this.TxtFormato.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormato.Location = new System.Drawing.Point(739, 11);
            this.TxtFormato.MaxLength = 17;
            this.TxtFormato.Name = "TxtFormato";
            this.TxtFormato.Size = new System.Drawing.Size(79, 19);
            this.TxtFormato.TabIndex = 431;
            this.TxtFormato.Tag = null;
            this.TxtFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFormato.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ConsolidadoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtFormato);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Name = "ConsolidadoVentas";
            this.Size = new System.Drawing.Size(848, 483);
            this.Load += new System.EventHandler(this.ConsolidadoVentas_Load);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.TxtFormato, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSeries)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobanteListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1List.C1Combo CboAnno;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1List.C1Combo CboPeriodo;
        private System.Windows.Forms.Label label10;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private C1.Win.C1Input.C1Button btnConsultar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvConsolidadoVentas;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1List.C1Combo CboTipoComprobante;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1List.C1Combo cboSeries;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1Button BtnFiltrar;
        private C1.Win.C1Input.C1Button BtnResumenDiario;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private C1.Win.C1List.C1Combo CboTipoComprobanteListado;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1Button BtnConsultarListado;
        private System.Windows.Forms.DateTimePicker DtpFechaFinListado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFechaIniListado;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1Button BtnImprimir;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgComprobantes;
        private C1.Win.C1Input.C1TextBox TxtFormato;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}
