namespace Halley.Presentacion.Ventas.Administracion
{
    partial class NotaCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaCredito));
            this.label7 = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultarListado = new C1.Win.C1Input.C1Button();
            this.DtpFechaFinListado = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaIniListado = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnImprimir = new C1.Win.C1Input.C1Button();
            this.TdgComprobantes = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.GbAnular = new System.Windows.Forms.GroupBox();
            this.TxtNumeroAnulacion = new C1.Win.C1Input.C1TextBox();
            this.TxtSerieAnulacion = new C1.Win.C1Input.C1TextBox();
            this.BtnNotaCredito = new C1.Win.C1Input.C1Button();
            this.label27 = new System.Windows.Forms.Label();
            this.TxtMotivoEliminacion = new C1.Win.C1Input.C1TextBox();
            this.Cboempresa2 = new C1.Win.C1List.C1Combo();
            this.label16 = new System.Windows.Forms.Label();
            this.cbComprobante = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            this.CboTipoComprobanteListado = new C1.Win.C1List.C1Combo();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.TxtFormato = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).BeginInit();
            this.GbAnular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumeroAnulacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerieAnulacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMotivoEliminacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cboempresa2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobanteListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 435;
            this.label7.Text = "Nota de Crédito";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 453;
            this.label1.Text = "Comprobante :";
            // 
            // BtnConsultarListado
            // 
            this.BtnConsultarListado.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.BtnConsultarListado.Location = new System.Drawing.Point(297, 212);
            this.BtnConsultarListado.Name = "BtnConsultarListado";
            this.BtnConsultarListado.Size = new System.Drawing.Size(90, 23);
            this.BtnConsultarListado.TabIndex = 451;
            this.BtnConsultarListado.Text = "Consultar";
            this.BtnConsultarListado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConsultarListado.UseVisualStyleBackColor = true;
            this.BtnConsultarListado.Click += new System.EventHandler(this.BtnConsultarListado_Click);
            // 
            // DtpFechaFinListado
            // 
            this.DtpFechaFinListado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFinListado.Location = new System.Drawing.Point(203, 210);
            this.DtpFechaFinListado.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFinListado.Name = "DtpFechaFinListado";
            this.DtpFechaFinListado.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaFinListado.TabIndex = 450;
            // 
            // DtpFechaIniListado
            // 
            this.DtpFechaIniListado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIniListado.Location = new System.Drawing.Point(111, 210);
            this.DtpFechaIniListado.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIniListado.Name = "DtpFechaIniListado";
            this.DtpFechaIniListado.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaIniListado.TabIndex = 448;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 449;
            this.label6.Text = "Fechas:";
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(743, 207);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(80, 25);
            this.BtnImprimir.TabIndex = 447;
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
            this.TdgComprobantes.Location = new System.Drawing.Point(15, 238);
            this.TdgComprobantes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell;
            this.TdgComprobantes.Name = "TdgComprobantes";
            this.TdgComprobantes.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgComprobantes.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgComprobantes.PreviewInfo.ZoomFactor = 75D;
            this.TdgComprobantes.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgComprobantes.PrintInfo.PageSettings")));
            this.TdgComprobantes.RowHeight = 27;
            this.TdgComprobantes.Size = new System.Drawing.Size(817, 328);
            this.TdgComprobantes.TabIndex = 446;
            this.TdgComprobantes.Text = "c1TrueDBGrid1";
            this.TdgComprobantes.PropBag = resources.GetString("TdgComprobantes.PropBag");
            // 
            // GbAnular
            // 
            this.GbAnular.Controls.Add(this.TxtNumeroAnulacion);
            this.GbAnular.Controls.Add(this.TxtSerieAnulacion);
            this.GbAnular.Controls.Add(this.BtnNotaCredito);
            this.GbAnular.Controls.Add(this.label27);
            this.GbAnular.Controls.Add(this.TxtMotivoEliminacion);
            this.GbAnular.Controls.Add(this.Cboempresa2);
            this.GbAnular.Controls.Add(this.label16);
            this.GbAnular.Controls.Add(this.cbComprobante);
            this.GbAnular.Controls.Add(this.label2);
            this.GbAnular.Controls.Add(this.label11);
            this.GbAnular.Location = new System.Drawing.Point(15, 41);
            this.GbAnular.Name = "GbAnular";
            this.GbAnular.Size = new System.Drawing.Size(817, 117);
            this.GbAnular.TabIndex = 454;
            this.GbAnular.TabStop = false;
            this.GbAnular.Text = "GENERAR";
            // 
            // TxtNumeroAnulacion
            // 
            this.TxtNumeroAnulacion.Location = new System.Drawing.Point(465, 50);
            this.TxtNumeroAnulacion.MaxLength = 8;
            this.TxtNumeroAnulacion.Name = "TxtNumeroAnulacion";
            this.TxtNumeroAnulacion.Size = new System.Drawing.Size(113, 22);
            this.TxtNumeroAnulacion.TabIndex = 425;
            this.TxtNumeroAnulacion.Tag = null;
            this.TxtNumeroAnulacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtSerieAnulacion
            // 
            this.TxtSerieAnulacion.Location = new System.Drawing.Point(383, 50);
            this.TxtSerieAnulacion.MaxLength = 4;
            this.TxtSerieAnulacion.Name = "TxtSerieAnulacion";
            this.TxtSerieAnulacion.Size = new System.Drawing.Size(68, 22);
            this.TxtSerieAnulacion.TabIndex = 424;
            this.TxtSerieAnulacion.Tag = null;
            this.TxtSerieAnulacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnNotaCredito
            // 
            this.BtnNotaCredito.Image = global::Halley.Presentacion.Properties.Resources.GuiaT_16x16;
            this.BtnNotaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNotaCredito.Location = new System.Drawing.Point(601, 71);
            this.BtnNotaCredito.Name = "BtnNotaCredito";
            this.BtnNotaCredito.Size = new System.Drawing.Size(94, 29);
            this.BtnNotaCredito.TabIndex = 423;
            this.BtnNotaCredito.Text = "Generar";
            this.BtnNotaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNotaCredito.UseVisualStyleBackColor = true;
            this.BtnNotaCredito.Click += new System.EventHandler(this.BtnNotaCredito_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(24, 79);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(79, 13);
            this.label27.TabIndex = 422;
            this.label27.Text = "Motivo Sunat:";
            // 
            // TxtMotivoEliminacion
            // 
            this.TxtMotivoEliminacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMotivoEliminacion.Location = new System.Drawing.Point(109, 79);
            this.TxtMotivoEliminacion.MaxLength = 200;
            this.TxtMotivoEliminacion.Name = "TxtMotivoEliminacion";
            this.TxtMotivoEliminacion.Size = new System.Drawing.Size(392, 22);
            this.TxtMotivoEliminacion.TabIndex = 421;
            this.TxtMotivoEliminacion.Tag = null;
            this.TxtMotivoEliminacion.Value = "Baja por anulación";
            // 
            // Cboempresa2
            // 
            this.Cboempresa2.AddItemSeparator = ';';
            this.Cboempresa2.AutoCompletion = true;
            this.Cboempresa2.AutoDropDown = true;
            this.Cboempresa2.Caption = "";
            this.Cboempresa2.CaptionHeight = 17;
            this.Cboempresa2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Cboempresa2.ColumnCaptionHeight = 17;
            this.Cboempresa2.ColumnFooterHeight = 17;
            this.Cboempresa2.ColumnHeaders = false;
            this.Cboempresa2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.Cboempresa2.ContentHeight = 17;
            this.Cboempresa2.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.Cboempresa2.DisplayMember = "NomEmpresa";
            this.Cboempresa2.EditorBackColor = System.Drawing.SystemColors.Window;
            this.Cboempresa2.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cboempresa2.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.Cboempresa2.EditorHeight = 17;
            this.Cboempresa2.Images.Add(((System.Drawing.Image)(resources.GetObject("Cboempresa2.Images"))));
            this.Cboempresa2.ItemHeight = 15;
            this.Cboempresa2.Location = new System.Drawing.Point(109, 21);
            this.Cboempresa2.MatchEntryTimeout = ((long)(2000));
            this.Cboempresa2.MaxDropDownItems = ((short)(10));
            this.Cboempresa2.MaxLength = 32767;
            this.Cboempresa2.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.Cboempresa2.Name = "Cboempresa2";
            this.Cboempresa2.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.Cboempresa2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.Cboempresa2.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.Cboempresa2.Size = new System.Drawing.Size(160, 23);
            this.Cboempresa2.TabIndex = 419;
            this.Cboempresa2.ValueMember = "EmpresaID";
            this.Cboempresa2.PropBag = resources.GetString("Cboempresa2.PropBag");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(47, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 420;
            this.label16.Text = "Empresa:";
            // 
            // cbComprobante
            // 
            this.cbComprobante.AddItemSeparator = ';';
            this.cbComprobante.Caption = "";
            this.cbComprobante.CaptionHeight = 17;
            this.cbComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbComprobante.ColumnCaptionHeight = 17;
            this.cbComprobante.ColumnFooterHeight = 17;
            this.cbComprobante.ColumnHeaders = false;
            this.cbComprobante.ColumnWidth = 100;
            this.cbComprobante.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbComprobante.ContentHeight = 17;
            this.cbComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbComprobante.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbComprobante.EditorHeight = 17;
            this.cbComprobante.ExtendRightColumn = true;
            this.cbComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("cbComprobante.Images"))));
            this.cbComprobante.ItemHeight = 15;
            this.cbComprobante.Location = new System.Drawing.Point(109, 50);
            this.cbComprobante.MatchEntryTimeout = ((long)(2000));
            this.cbComprobante.MaxDropDownItems = ((short)(5));
            this.cbComprobante.MaxLength = 32767;
            this.cbComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbComprobante.Size = new System.Drawing.Size(160, 23);
            this.cbComprobante.TabIndex = 414;
            this.cbComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbComprobante.PropBag = resources.GetString("cbComprobante.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 415;
            this.label2.Text = "Comprobante :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(292, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 411;
            this.label11.Text = "Serie-Número:";
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
            this.c1cboCia.Location = new System.Drawing.Point(112, 181);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(188, 23);
            this.c1cboCia.TabIndex = 455;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.SelectedValueChanged += new System.EventHandler(this.c1cboCia_SelectedValueChanged);
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 456;
            this.label3.Text = "Empresa:";
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
            this.CboTipoComprobanteListado.Location = new System.Drawing.Point(419, 181);
            this.CboTipoComprobanteListado.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobanteListado.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobanteListado.MaxLength = 32767;
            this.CboTipoComprobanteListado.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobanteListado.Name = "CboTipoComprobanteListado";
            this.CboTipoComprobanteListado.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobanteListado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobanteListado.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobanteListado.Size = new System.Drawing.Size(188, 23);
            this.CboTipoComprobanteListado.TabIndex = 452;
            this.CboTipoComprobanteListado.PropBag = resources.GetString("CboTipoComprobanteListado.PropBag");
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // TxtFormato
            // 
            this.TxtFormato.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormato.Location = new System.Drawing.Point(830, 3);
            this.TxtFormato.MaxLength = 17;
            this.TxtFormato.Name = "TxtFormato";
            this.TxtFormato.Size = new System.Drawing.Size(79, 19);
            this.TxtFormato.TabIndex = 457;
            this.TxtFormato.Tag = null;
            this.TxtFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFormato.Visible = false;
            // 
            // NotaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtFormato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.GbAnular);
            this.Controls.Add(this.CboTipoComprobanteListado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultarListado);
            this.Controls.Add(this.DtpFechaFinListado);
            this.Controls.Add(this.DtpFechaIniListado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.TdgComprobantes);
            this.Controls.Add(this.label7);
            this.Name = "NotaCredito";
            this.Size = new System.Drawing.Size(923, 594);
            this.Load += new System.EventHandler(this.NotaCredito_Load);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.TdgComprobantes, 0);
            this.Controls.SetChildIndex(this.BtnImprimir, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.DtpFechaIniListado, 0);
            this.Controls.SetChildIndex(this.DtpFechaFinListado, 0);
            this.Controls.SetChildIndex(this.BtnConsultarListado, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CboTipoComprobanteListado, 0);
            this.Controls.SetChildIndex(this.GbAnular, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.TxtFormato, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).EndInit();
            this.GbAnular.ResumeLayout(false);
            this.GbAnular.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumeroAnulacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerieAnulacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMotivoEliminacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cboempresa2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobanteListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnConsultarListado;
        private System.Windows.Forms.DateTimePicker DtpFechaFinListado;
        private System.Windows.Forms.DateTimePicker DtpFechaIniListado;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1Button BtnImprimir;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgComprobantes;
        private System.Windows.Forms.GroupBox GbAnular;
        private C1.Win.C1Input.C1TextBox TxtNumeroAnulacion;
        private C1.Win.C1Input.C1TextBox TxtSerieAnulacion;
        private C1.Win.C1Input.C1Button BtnNotaCredito;
        private System.Windows.Forms.Label label27;
        private C1.Win.C1Input.C1TextBox TxtMotivoEliminacion;
        private C1.Win.C1List.C1Combo Cboempresa2;
        private System.Windows.Forms.Label label16;
        private C1.Win.C1List.C1Combo cbComprobante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1List.C1Combo c1cboCia;
        private C1.Win.C1List.C1Combo CboTipoComprobanteListado;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private C1.Win.C1Input.C1TextBox TxtFormato;
    }
}
