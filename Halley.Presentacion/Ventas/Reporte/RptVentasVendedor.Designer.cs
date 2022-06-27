namespace Halley.Presentacion.Ventas.Reporte
{
    partial class RptVentasVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptVentasVendedor));
            this.CrvVentasSede = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSede = new C1.Win.C1List.C1Combo();
            this.RbResumido = new System.Windows.Forms.RadioButton();
            this.RbDetallado = new System.Windows.Forms.RadioButton();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.RbProducto = new System.Windows.Forms.RadioButton();
            this.RbProductosVendedor = new System.Windows.Forms.RadioButton();
            this.CboHoraFin = new C1.Win.C1List.C1Combo();
            this.CboHoraIni = new C1.Win.C1List.C1Combo();
            this.CboMinIni = new C1.Win.C1List.C1Combo();
            this.CboMinFin = new C1.Win.C1List.C1Combo();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboHoraIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboMinIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboMinFin)).BeginInit();
            this.SuspendLayout();
            // 
            // CrvVentasSede
            // 
            this.CrvVentasSede.ActiveViewIndex = -1;
            this.CrvVentasSede.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvVentasSede.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVentasSede.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVentasSede.Location = new System.Drawing.Point(25, 111);
            this.CrvVentasSede.Name = "CrvVentasSede";
            this.CrvVentasSede.Size = new System.Drawing.Size(762, 309);
            this.CrvVentasSede.TabIndex = 5;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(702, 79);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(82, 26);
            this.btnGenerar.TabIndex = 347;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 357;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 356;
            this.label1.Text = "Entre:";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(458, 79);
            this.DtpFechaFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaFin.TabIndex = 355;
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(177, 79);
            this.DtpFechaIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaIni.TabIndex = 354;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 42);
            this.label3.TabIndex = 358;
            this.label3.Text = "Ventas por\r\nvendedores";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(404, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 389;
            this.label8.Text = "Sede:";
            // 
            // CboSede
            // 
            this.CboSede.AddItemSeparator = ';';
            this.CboSede.AutoCompletion = true;
            this.CboSede.AutoDropDown = true;
            this.CboSede.Caption = "Seleccione Sede";
            this.CboSede.CaptionHeight = 17;
            this.CboSede.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboSede.ColumnCaptionHeight = 17;
            this.CboSede.ColumnFooterHeight = 17;
            this.CboSede.ColumnHeaders = false;
            this.CboSede.ContentHeight = 17;
            this.CboSede.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSede.DisplayMember = "NomEmpresa";
            this.CboSede.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSede.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSede.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSede.EditorHeight = 17;
            this.CboSede.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSede.Images"))));
            this.CboSede.ItemHeight = 15;
            this.CboSede.Location = new System.Drawing.Point(440, 54);
            this.CboSede.MatchEntryTimeout = ((long)(2000));
            this.CboSede.MaxDropDownItems = ((short)(10));
            this.CboSede.MaxLength = 32767;
            this.CboSede.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSede.Name = "CboSede";
            this.CboSede.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSede.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSede.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSede.Size = new System.Drawing.Size(344, 23);
            this.CboSede.TabIndex = 388;
            this.CboSede.ValueMember = "EmpresaID";
            this.CboSede.PropBag = resources.GetString("CboSede.PropBag");
            // 
            // RbResumido
            // 
            this.RbResumido.AutoSize = true;
            this.RbResumido.Checked = true;
            this.RbResumido.Location = new System.Drawing.Point(124, 17);
            this.RbResumido.Name = "RbResumido";
            this.RbResumido.Size = new System.Drawing.Size(76, 17);
            this.RbResumido.TabIndex = 390;
            this.RbResumido.TabStop = true;
            this.RbResumido.Text = "Resumido";
            this.RbResumido.UseVisualStyleBackColor = true;
            // 
            // RbDetallado
            // 
            this.RbDetallado.AutoSize = true;
            this.RbDetallado.Location = new System.Drawing.Point(206, 17);
            this.RbDetallado.Name = "RbDetallado";
            this.RbDetallado.Size = new System.Drawing.Size(75, 17);
            this.RbDetallado.TabIndex = 391;
            this.RbDetallado.Text = "Detallado";
            this.RbDetallado.UseVisualStyleBackColor = true;
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
            this.c1cboCia.Location = new System.Drawing.Point(81, 54);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(292, 23);
            this.c1cboCia.TabIndex = 394;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 395;
            this.label14.Text = "Empresa:";
            // 
            // RbProducto
            // 
            this.RbProducto.AutoSize = true;
            this.RbProducto.Location = new System.Drawing.Point(294, 13);
            this.RbProducto.Name = "RbProducto";
            this.RbProducto.Size = new System.Drawing.Size(73, 30);
            this.RbProducto.TabIndex = 396;
            this.RbProducto.Text = "Producto\r\nresumido";
            this.RbProducto.UseVisualStyleBackColor = true;
            // 
            // RbProductosVendedor
            // 
            this.RbProductosVendedor.AutoSize = true;
            this.RbProductosVendedor.Location = new System.Drawing.Point(385, 13);
            this.RbProductosVendedor.Name = "RbProductosVendedor";
            this.RbProductosVendedor.Size = new System.Drawing.Size(93, 30);
            this.RbProductosVendedor.TabIndex = 397;
            this.RbProductosVendedor.Text = "Producto por\r\nvendedor";
            this.RbProductosVendedor.UseVisualStyleBackColor = true;
            // 
            // CboHoraFin
            // 
            this.CboHoraFin.AddItemSeparator = ';';
            this.CboHoraFin.AutoCompletion = true;
            this.CboHoraFin.AutoDropDown = true;
            this.CboHoraFin.Caption = "";
            this.CboHoraFin.CaptionHeight = 17;
            this.CboHoraFin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboHoraFin.ColumnCaptionHeight = 17;
            this.CboHoraFin.ColumnFooterHeight = 17;
            this.CboHoraFin.ColumnHeaders = false;
            this.CboHoraFin.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboHoraFin.ContentHeight = 17;
            this.CboHoraFin.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboHoraFin.DisplayMember = "descripcion";
            this.CboHoraFin.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboHoraFin.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboHoraFin.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboHoraFin.EditorHeight = 17;
            this.CboHoraFin.Images.Add(((System.Drawing.Image)(resources.GetObject("CboHoraFin.Images"))));
            this.CboHoraFin.ItemHeight = 15;
            this.CboHoraFin.Location = new System.Drawing.Point(544, 79);
            this.CboHoraFin.MatchEntryTimeout = ((long)(2000));
            this.CboHoraFin.MaxDropDownItems = ((short)(10));
            this.CboHoraFin.MaxLength = 32767;
            this.CboHoraFin.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboHoraFin.Name = "CboHoraFin";
            this.CboHoraFin.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboHoraFin.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboHoraFin.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboHoraFin.Size = new System.Drawing.Size(74, 23);
            this.CboHoraFin.TabIndex = 398;
            this.CboHoraFin.ValueMember = "codigo";
            this.CboHoraFin.PropBag = resources.GetString("CboHoraFin.PropBag");
            // 
            // CboHoraIni
            // 
            this.CboHoraIni.AddItemSeparator = ';';
            this.CboHoraIni.AutoCompletion = true;
            this.CboHoraIni.AutoDropDown = true;
            this.CboHoraIni.Caption = "";
            this.CboHoraIni.CaptionHeight = 17;
            this.CboHoraIni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboHoraIni.ColumnCaptionHeight = 17;
            this.CboHoraIni.ColumnFooterHeight = 17;
            this.CboHoraIni.ColumnHeaders = false;
            this.CboHoraIni.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboHoraIni.ContentHeight = 17;
            this.CboHoraIni.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboHoraIni.DisplayMember = "descripcion";
            this.CboHoraIni.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboHoraIni.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboHoraIni.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboHoraIni.EditorHeight = 17;
            this.CboHoraIni.Images.Add(((System.Drawing.Image)(resources.GetObject("CboHoraIni.Images"))));
            this.CboHoraIni.ItemHeight = 15;
            this.CboHoraIni.Location = new System.Drawing.Point(263, 79);
            this.CboHoraIni.MatchEntryTimeout = ((long)(2000));
            this.CboHoraIni.MaxDropDownItems = ((short)(10));
            this.CboHoraIni.MaxLength = 32767;
            this.CboHoraIni.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboHoraIni.Name = "CboHoraIni";
            this.CboHoraIni.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboHoraIni.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboHoraIni.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboHoraIni.Size = new System.Drawing.Size(74, 23);
            this.CboHoraIni.TabIndex = 399;
            this.CboHoraIni.ValueMember = "codigo";
            this.CboHoraIni.PropBag = resources.GetString("CboHoraIni.PropBag");
            // 
            // CboMinIni
            // 
            this.CboMinIni.AddItemSeparator = ';';
            this.CboMinIni.AutoCompletion = true;
            this.CboMinIni.AutoDropDown = true;
            this.CboMinIni.Caption = "";
            this.CboMinIni.CaptionHeight = 17;
            this.CboMinIni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboMinIni.ColumnCaptionHeight = 17;
            this.CboMinIni.ColumnFooterHeight = 17;
            this.CboMinIni.ColumnHeaders = false;
            this.CboMinIni.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboMinIni.ContentHeight = 17;
            this.CboMinIni.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboMinIni.DisplayMember = "descripcion";
            this.CboMinIni.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboMinIni.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboMinIni.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboMinIni.EditorHeight = 17;
            this.CboMinIni.Images.Add(((System.Drawing.Image)(resources.GetObject("CboMinIni.Images"))));
            this.CboMinIni.ItemHeight = 15;
            this.CboMinIni.Location = new System.Drawing.Point(343, 79);
            this.CboMinIni.MatchEntryTimeout = ((long)(2000));
            this.CboMinIni.MaxDropDownItems = ((short)(10));
            this.CboMinIni.MaxLength = 32767;
            this.CboMinIni.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboMinIni.Name = "CboMinIni";
            this.CboMinIni.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboMinIni.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboMinIni.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboMinIni.Size = new System.Drawing.Size(74, 23);
            this.CboMinIni.TabIndex = 400;
            this.CboMinIni.ValueMember = "codigo";
            this.CboMinIni.PropBag = resources.GetString("CboMinIni.PropBag");
            // 
            // CboMinFin
            // 
            this.CboMinFin.AddItemSeparator = ';';
            this.CboMinFin.AutoCompletion = true;
            this.CboMinFin.AutoDropDown = true;
            this.CboMinFin.Caption = "";
            this.CboMinFin.CaptionHeight = 17;
            this.CboMinFin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboMinFin.ColumnCaptionHeight = 17;
            this.CboMinFin.ColumnFooterHeight = 17;
            this.CboMinFin.ColumnHeaders = false;
            this.CboMinFin.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboMinFin.ContentHeight = 17;
            this.CboMinFin.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboMinFin.DisplayMember = "descripcion";
            this.CboMinFin.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboMinFin.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboMinFin.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboMinFin.EditorHeight = 17;
            this.CboMinFin.Images.Add(((System.Drawing.Image)(resources.GetObject("CboMinFin.Images"))));
            this.CboMinFin.ItemHeight = 15;
            this.CboMinFin.Location = new System.Drawing.Point(622, 79);
            this.CboMinFin.MatchEntryTimeout = ((long)(2000));
            this.CboMinFin.MaxDropDownItems = ((short)(10));
            this.CboMinFin.MaxLength = 32767;
            this.CboMinFin.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboMinFin.Name = "CboMinFin";
            this.CboMinFin.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboMinFin.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboMinFin.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboMinFin.Size = new System.Drawing.Size(74, 23);
            this.CboMinFin.TabIndex = 401;
            this.CboMinFin.ValueMember = "codigo";
            this.CboMinFin.PropBag = resources.GetString("CboMinFin.PropBag");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(29, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 402;
            this.label4.Text = "(Formato 24 horas)";
            // 
            // RptVentasVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CboMinFin);
            this.Controls.Add(this.CboMinIni);
            this.Controls.Add(this.CboHoraIni);
            this.Controls.Add(this.CboHoraFin);
            this.Controls.Add(this.RbProductosVendedor);
            this.Controls.Add(this.RbProducto);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.RbDetallado);
            this.Controls.Add(this.RbResumido);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CboSede);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.DtpFechaIni);
            this.Controls.Add(this.CrvVentasSede);
            this.Controls.Add(this.btnGenerar);
            this.Name = "RptVentasVendedor";
            this.Size = new System.Drawing.Size(1034, 453);
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.CrvVentasSede, 0);
            this.Controls.SetChildIndex(this.DtpFechaIni, 0);
            this.Controls.SetChildIndex(this.DtpFechaFin, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.CboSede, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.RbResumido, 0);
            this.Controls.SetChildIndex(this.RbDetallado, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.RbProducto, 0);
            this.Controls.SetChildIndex(this.RbProductosVendedor, 0);
            this.Controls.SetChildIndex(this.CboHoraFin, 0);
            this.Controls.SetChildIndex(this.CboHoraIni, 0);
            this.Controls.SetChildIndex(this.CboMinIni, 0);
            this.Controls.SetChildIndex(this.CboMinFin, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboHoraIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboMinIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboMinFin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVentasSede;
        private C1.Win.C1Input.C1Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSede;
        private System.Windows.Forms.RadioButton RbResumido;
        private System.Windows.Forms.RadioButton RbDetallado;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton RbProducto;
        private System.Windows.Forms.RadioButton RbProductosVendedor;
        private C1.Win.C1List.C1Combo CboHoraFin;
        private C1.Win.C1List.C1Combo CboHoraIni;
        private C1.Win.C1List.C1Combo CboMinIni;
        private C1.Win.C1List.C1Combo CboMinFin;
        private System.Windows.Forms.Label label4;
    }
}
