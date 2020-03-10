namespace Halley.Presentacion.Produccion
{
    partial class PlanDeProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanDeProduccion));
            this.TcProduccion = new System.Windows.Forms.TabControl();
            this.TpMicroInsumos = new System.Windows.Forms.TabPage();
            this.TdgMicro = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TpMacroInsumos = new System.Windows.Forms.TabPage();
            this.TdgMacro = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnQuitar = new C1.Win.C1Input.C1Button();
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnMostrarPlan = new C1.Win.C1Input.C1Button();
            this.BtnGrabar = new C1.Win.C1Input.C1Button();
            this.TdgFormuladosBatch = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TdgProductosFormulados = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TcOpciones = new System.Windows.Forms.TabControl();
            this.TpPlanActual = new System.Windows.Forms.TabPage();
            this.TpPlanHistorico = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.DeFechaProduccion = new C1.Win.C1Input.C1DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.LstHistorico = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnProductoTerminado = new C1.Win.C1Input.C1Button();
            this.BtnQuitarHistorico = new C1.Win.C1Input.C1Button();
            this.TdgFormuladosHistorico = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFechaFin = new C1.Win.C1Input.C1DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFechaInicio = new C1.Win.C1Input.C1DateEdit();
            this.BtnExportarExcel = new C1.Win.C1Input.C1Button();
            this.CboEmpresa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TcProduccion.SuspendLayout();
            this.TpMicroInsumos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMicro)).BeginInit();
            this.TpMacroInsumos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMacro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductosFormulados)).BeginInit();
            this.TcOpciones.SuspendLayout();
            this.TpPlanActual.SuspendLayout();
            this.TpPlanHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeFechaProduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).BeginInit();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TcProduccion
            // 
            this.TcProduccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcProduccion.Controls.Add(this.TpMicroInsumos);
            this.TcProduccion.Controls.Add(this.TpMacroInsumos);
            this.TcProduccion.Location = new System.Drawing.Point(15, 9);
            this.TcProduccion.Margin = new System.Windows.Forms.Padding(4);
            this.TcProduccion.Name = "TcProduccion";
            this.TcProduccion.SelectedIndex = 0;
            this.TcProduccion.Size = new System.Drawing.Size(1361, 344);
            this.TcProduccion.TabIndex = 5;
            // 
            // TpMicroInsumos
            // 
            this.TpMicroInsumos.Controls.Add(this.TdgMicro);
            this.TpMicroInsumos.Location = new System.Drawing.Point(4, 28);
            this.TpMicroInsumos.Margin = new System.Windows.Forms.Padding(4);
            this.TpMicroInsumos.Name = "TpMicroInsumos";
            this.TpMicroInsumos.Padding = new System.Windows.Forms.Padding(4);
            this.TpMicroInsumos.Size = new System.Drawing.Size(1353, 312);
            this.TpMicroInsumos.TabIndex = 0;
            this.TpMicroInsumos.Text = "MicroInsumos";
            this.TpMicroInsumos.UseVisualStyleBackColor = true;
            // 
            // TdgMicro
            // 
            this.TdgMicro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TdgMicro.CaptionHeight = 17;
            this.TdgMicro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TdgMicro.EmptyRows = true;
            this.TdgMicro.FetchRowStyles = true;
            this.TdgMicro.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMicro.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMicro.Images"))));
            this.TdgMicro.Location = new System.Drawing.Point(4, 4);
            this.TdgMicro.Margin = new System.Windows.Forms.Padding(4);
            this.TdgMicro.Name = "TdgMicro";
            this.TdgMicro.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMicro.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMicro.PreviewInfo.ZoomFactor = 75D;
            this.TdgMicro.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMicro.PrintInfo.PageSettings")));
            this.TdgMicro.RowHeight = 18;
            this.TdgMicro.Size = new System.Drawing.Size(1345, 304);
            this.TdgMicro.TabIndex = 8;
            this.TdgMicro.Text = "c1TrueDBGrid2";
            this.TdgMicro.FormatText += new C1.Win.C1TrueDBGrid.FormatTextEventHandler(this.TdgMicro_FormatText);
            this.TdgMicro.FetchRowStyle += new C1.Win.C1TrueDBGrid.FetchRowStyleEventHandler(this.TdgMicro_FetchRowStyle);
            this.TdgMicro.PropBag = resources.GetString("TdgMicro.PropBag");
            // 
            // TpMacroInsumos
            // 
            this.TpMacroInsumos.Controls.Add(this.TdgMacro);
            this.TpMacroInsumos.Location = new System.Drawing.Point(4, 28);
            this.TpMacroInsumos.Margin = new System.Windows.Forms.Padding(4);
            this.TpMacroInsumos.Name = "TpMacroInsumos";
            this.TpMacroInsumos.Padding = new System.Windows.Forms.Padding(4);
            this.TpMacroInsumos.Size = new System.Drawing.Size(1353, 312);
            this.TpMacroInsumos.TabIndex = 1;
            this.TpMacroInsumos.Text = "MacroInsumos";
            this.TpMacroInsumos.UseVisualStyleBackColor = true;
            // 
            // TdgMacro
            // 
            this.TdgMacro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TdgMacro.CaptionHeight = 17;
            this.TdgMacro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TdgMacro.EmptyRows = true;
            this.TdgMacro.FetchRowStyles = true;
            this.TdgMacro.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMacro.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMacro.Images"))));
            this.TdgMacro.Location = new System.Drawing.Point(4, 4);
            this.TdgMacro.Margin = new System.Windows.Forms.Padding(4);
            this.TdgMacro.Name = "TdgMacro";
            this.TdgMacro.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMacro.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMacro.PreviewInfo.ZoomFactor = 75D;
            this.TdgMacro.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMacro.PrintInfo.PageSettings")));
            this.TdgMacro.RowHeight = 15;
            this.TdgMacro.Size = new System.Drawing.Size(1345, 304);
            this.TdgMacro.TabIndex = 9;
            this.TdgMacro.Text = "c1TrueDBGrid1";
            this.TdgMacro.FormatText += new C1.Win.C1TrueDBGrid.FormatTextEventHandler(this.TdgMacro_FormatText);
            this.TdgMacro.FetchRowStyle += new C1.Win.C1TrueDBGrid.FetchRowStyleEventHandler(this.TdgMacro_FetchRowStyle);
            this.TdgMacro.PropBag = resources.GetString("TdgMacro.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 28);
            this.label1.TabIndex = 356;
            this.label1.Text = "Plan de Producción";
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.Image = global::Halley.Presentacion.Properties.Resources.previous_16x16;
            this.BtnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitar.Location = new System.Drawing.Point(519, 183);
            this.BtnQuitar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(109, 34);
            this.BtnQuitar.TabIndex = 358;
            this.BtnQuitar.Text = "Quitar";
            this.BtnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuitar.UseVisualStyleBackColor = true;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.next_16x16;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.Location = new System.Drawing.Point(519, 22);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(109, 34);
            this.BtnAgregar.TabIndex = 357;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(1268, 74);
            this.BtnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(109, 34);
            this.BtnNuevo.TabIndex = 355;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnMostrarPlan
            // 
            this.BtnMostrarPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMostrarPlan.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnMostrarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMostrarPlan.Location = new System.Drawing.Point(1268, 134);
            this.BtnMostrarPlan.Margin = new System.Windows.Forms.Padding(4);
            this.BtnMostrarPlan.Name = "BtnMostrarPlan";
            this.BtnMostrarPlan.Size = new System.Drawing.Size(109, 34);
            this.BtnMostrarPlan.TabIndex = 354;
            this.BtnMostrarPlan.Text = "Ver plan";
            this.BtnMostrarPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMostrarPlan.UseVisualStyleBackColor = true;
            this.BtnMostrarPlan.Click += new System.EventHandler(this.BtnMostrarPlan_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGrabar.Image = global::Halley.Presentacion.Properties.Resources.Production_32x32;
            this.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrabar.Location = new System.Drawing.Point(1130, 22);
            this.BtnGrabar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(109, 63);
            this.BtnGrabar.TabIndex = 353;
            this.BtnGrabar.Text = "Crear\r\nhistorial";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // TdgFormuladosBatch
            // 
            this.TdgFormuladosBatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TdgFormuladosBatch.CaptionHeight = 17;
            this.TdgFormuladosBatch.EmptyRows = true;
            this.TdgFormuladosBatch.FilterBar = true;
            this.TdgFormuladosBatch.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgFormuladosBatch.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgFormuladosBatch.Images"))));
            this.TdgFormuladosBatch.Location = new System.Drawing.Point(636, 22);
            this.TdgFormuladosBatch.Margin = new System.Windows.Forms.Padding(4);
            this.TdgFormuladosBatch.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgFormuladosBatch.Name = "TdgFormuladosBatch";
            this.TdgFormuladosBatch.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgFormuladosBatch.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgFormuladosBatch.PreviewInfo.ZoomFactor = 75D;
            this.TdgFormuladosBatch.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgFormuladosBatch.PrintInfo.PageSettings")));
            this.TdgFormuladosBatch.RowHeight = 18;
            this.TdgFormuladosBatch.Size = new System.Drawing.Size(487, 256);
            this.TdgFormuladosBatch.TabIndex = 7;
            this.TdgFormuladosBatch.Text = "c1TrueDBGrid1";
            this.TdgFormuladosBatch.DoubleClick += new System.EventHandler(this.TdgFormuladosBatch_DoubleClick);
            this.TdgFormuladosBatch.PropBag = resources.GetString("TdgFormuladosBatch.PropBag");
            // 
            // TdgProductosFormulados
            // 
            this.TdgProductosFormulados.AllowUpdate = false;
            this.TdgProductosFormulados.CaptionHeight = 17;
            this.TdgProductosFormulados.EmptyRows = true;
            this.TdgProductosFormulados.FilterBar = true;
            this.TdgProductosFormulados.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgProductosFormulados.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgProductosFormulados.Images"))));
            this.TdgProductosFormulados.Location = new System.Drawing.Point(8, 22);
            this.TdgProductosFormulados.Margin = new System.Windows.Forms.Padding(4);
            this.TdgProductosFormulados.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgProductosFormulados.Name = "TdgProductosFormulados";
            this.TdgProductosFormulados.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgProductosFormulados.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgProductosFormulados.PreviewInfo.ZoomFactor = 75D;
            this.TdgProductosFormulados.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgProductosFormulados.PrintInfo.PageSettings")));
            this.TdgProductosFormulados.RowHeight = 18;
            this.TdgProductosFormulados.Size = new System.Drawing.Size(488, 256);
            this.TdgProductosFormulados.TabIndex = 7;
            this.TdgProductosFormulados.Text = "c1TrueDBGrid1";
            this.TdgProductosFormulados.PropBag = resources.GetString("TdgProductosFormulados.PropBag");
            // 
            // TcOpciones
            // 
            this.TcOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcOpciones.Controls.Add(this.TpPlanActual);
            this.TcOpciones.Controls.Add(this.TpPlanHistorico);
            this.TcOpciones.Location = new System.Drawing.Point(9, 46);
            this.TcOpciones.Margin = new System.Windows.Forms.Padding(4);
            this.TcOpciones.Name = "TcOpciones";
            this.TcOpciones.SelectedIndex = 0;
            this.TcOpciones.Size = new System.Drawing.Size(1251, 318);
            this.TcOpciones.TabIndex = 361;
            this.TcOpciones.SelectedIndexChanged += new System.EventHandler(this.TcOpciones_SelectedIndexChanged);
            // 
            // TpPlanActual
            // 
            this.TpPlanActual.Controls.Add(this.TdgProductosFormulados);
            this.TpPlanActual.Controls.Add(this.TdgFormuladosBatch);
            this.TpPlanActual.Controls.Add(this.BtnAgregar);
            this.TpPlanActual.Controls.Add(this.BtnQuitar);
            this.TpPlanActual.Controls.Add(this.BtnGrabar);
            this.TpPlanActual.Location = new System.Drawing.Point(4, 28);
            this.TpPlanActual.Margin = new System.Windows.Forms.Padding(4);
            this.TpPlanActual.Name = "TpPlanActual";
            this.TpPlanActual.Padding = new System.Windows.Forms.Padding(4);
            this.TpPlanActual.Size = new System.Drawing.Size(1243, 286);
            this.TpPlanActual.TabIndex = 0;
            this.TpPlanActual.Text = "Plan Actual";
            this.TpPlanActual.UseVisualStyleBackColor = true;
            // 
            // TpPlanHistorico
            // 
            this.TpPlanHistorico.Controls.Add(this.label7);
            this.TpPlanHistorico.Controls.Add(this.DeFechaProduccion);
            this.TpPlanHistorico.Controls.Add(this.label6);
            this.TpPlanHistorico.Controls.Add(this.LstHistorico);
            this.TpPlanHistorico.Controls.Add(this.label5);
            this.TpPlanHistorico.Controls.Add(this.BtnProductoTerminado);
            this.TpPlanHistorico.Controls.Add(this.BtnQuitarHistorico);
            this.TpPlanHistorico.Controls.Add(this.TdgFormuladosHistorico);
            this.TpPlanHistorico.Controls.Add(this.btnGenerar);
            this.TpPlanHistorico.Controls.Add(this.label2);
            this.TpPlanHistorico.Controls.Add(this.cboFechaFin);
            this.TpPlanHistorico.Controls.Add(this.label3);
            this.TpPlanHistorico.Controls.Add(this.cboFechaInicio);
            this.TpPlanHistorico.Location = new System.Drawing.Point(4, 28);
            this.TpPlanHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.TpPlanHistorico.Name = "TpPlanHistorico";
            this.TpPlanHistorico.Padding = new System.Windows.Forms.Padding(4);
            this.TpPlanHistorico.Size = new System.Drawing.Size(1243, 286);
            this.TpPlanHistorico.TabIndex = 1;
            this.TpPlanHistorico.Text = "Plan Historico";
            this.TpPlanHistorico.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(780, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 19);
            this.label7.TabIndex = 366;
            this.label7.Text = "Fecha producción:";
            // 
            // DeFechaProduccion
            // 
            // 
            // 
            // 
            this.DeFechaProduccion.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeFechaProduccion.Culture = 10250;
            this.DeFechaProduccion.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.DeFechaProduccion.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.DeFechaProduccion.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.DeFechaProduccion.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.DeFechaProduccion.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.DeFechaProduccion.Location = new System.Drawing.Point(926, 9);
            this.DeFechaProduccion.Margin = new System.Windows.Forms.Padding(4);
            this.DeFechaProduccion.Name = "DeFechaProduccion";
            this.DeFechaProduccion.Size = new System.Drawing.Size(159, 26);
            this.DeFechaProduccion.TabIndex = 365;
            this.DeFechaProduccion.Tag = null;
            this.DeFechaProduccion.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(259, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 19);
            this.label6.TabIndex = 364;
            this.label6.Text = "Planes históricos:";
            // 
            // LstHistorico
            // 
            this.LstHistorico.DisplayMember = "AudCrea";
            this.LstHistorico.FormattingEnabled = true;
            this.LstHistorico.ItemHeight = 19;
            this.LstHistorico.Location = new System.Drawing.Point(257, 42);
            this.LstHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.LstHistorico.Name = "LstHistorico";
            this.LstHistorico.Size = new System.Drawing.Size(186, 232);
            this.LstHistorico.TabIndex = 250;
            this.LstHistorico.ValueMember = "MateriaPrimaHistoricoID";
            this.LstHistorico.DoubleClick += new System.EventHandler(this.LstHistorico_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(6, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 57);
            this.label5.TabIndex = 251;
            this.label5.Text = "Hacer doble click en una fecha para\r\nvisualizar el plan de producción \r\nalmacenad" +
                "o.";
            // 
            // BtnProductoTerminado
            // 
            this.BtnProductoTerminado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProductoTerminado.Image = global::Halley.Presentacion.Properties.Resources.green;
            this.BtnProductoTerminado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProductoTerminado.Location = new System.Drawing.Point(1103, 6);
            this.BtnProductoTerminado.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProductoTerminado.Name = "BtnProductoTerminado";
            this.BtnProductoTerminado.Size = new System.Drawing.Size(109, 34);
            this.BtnProductoTerminado.TabIndex = 363;
            this.BtnProductoTerminado.Text = "Producir";
            this.BtnProductoTerminado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProductoTerminado.UseVisualStyleBackColor = true;
            this.BtnProductoTerminado.Click += new System.EventHandler(this.BtnProductoTerminado_Click);
            // 
            // BtnQuitarHistorico
            // 
            this.BtnQuitarHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnQuitarHistorico.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnQuitarHistorico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitarHistorico.Location = new System.Drawing.Point(457, 5);
            this.BtnQuitarHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.BtnQuitarHistorico.Name = "BtnQuitarHistorico";
            this.BtnQuitarHistorico.Size = new System.Drawing.Size(109, 34);
            this.BtnQuitarHistorico.TabIndex = 359;
            this.BtnQuitarHistorico.Text = "Quitar";
            this.BtnQuitarHistorico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuitarHistorico.UseVisualStyleBackColor = true;
            this.BtnQuitarHistorico.Click += new System.EventHandler(this.BtnQuitarHistorico_Click);
            // 
            // TdgFormuladosHistorico
            // 
            this.TdgFormuladosHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TdgFormuladosHistorico.CaptionHeight = 17;
            this.TdgFormuladosHistorico.EmptyRows = true;
            this.TdgFormuladosHistorico.FilterBar = true;
            this.TdgFormuladosHistorico.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgFormuladosHistorico.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgFormuladosHistorico.Images"))));
            this.TdgFormuladosHistorico.Location = new System.Drawing.Point(445, 42);
            this.TdgFormuladosHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.TdgFormuladosHistorico.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgFormuladosHistorico.Name = "TdgFormuladosHistorico";
            this.TdgFormuladosHistorico.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgFormuladosHistorico.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgFormuladosHistorico.PreviewInfo.ZoomFactor = 75D;
            this.TdgFormuladosHistorico.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgFormuladosHistorico.PrintInfo.PageSettings")));
            this.TdgFormuladosHistorico.RowHeight = 15;
            this.TdgFormuladosHistorico.Size = new System.Drawing.Size(766, 232);
            this.TdgFormuladosHistorico.TabIndex = 251;
            this.TdgFormuladosHistorico.Text = "c1TrueDBGrid1";
            this.TdgFormuladosHistorico.AfterUpdate += new System.EventHandler(this.TdgFormuladosHistorico_AfterUpdate);
            this.TdgFormuladosHistorico.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.TdgFormuladosHistorico_BeforeColUpdate);
            this.TdgFormuladosHistorico.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.TdgFormuladosHistorico_BeforeUpdate);
            this.TdgFormuladosHistorico.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.TdgFormuladosHistorico_FetchCellStyle);
            this.TdgFormuladosHistorico.PropBag = resources.GetString("TdgFormuladosHistorico.PropBag");
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(139, 100);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(109, 34);
            this.btnGenerar.TabIndex = 249;
            this.btnGenerar.Text = "Mostrar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 248;
            this.label2.Text = "Hasta:";
            // 
            // cboFechaFin
            // 
            // 
            // 
            // 
            this.cboFechaFin.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaFin.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaFin.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaFin.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaFin.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaFin.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.cboFechaFin.Location = new System.Drawing.Point(89, 57);
            this.cboFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.cboFechaFin.Name = "cboFechaFin";
            this.cboFechaFin.Size = new System.Drawing.Size(159, 26);
            this.cboFechaFin.TabIndex = 247;
            this.cboFechaFin.Tag = null;
            this.cboFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 246;
            this.label3.Text = "Ver desde:";
            // 
            // cboFechaInicio
            // 
            // 
            // 
            // 
            this.cboFechaInicio.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaInicio.Culture = 10250;
            this.cboFechaInicio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaInicio.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaInicio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaInicio.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaInicio.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.cboFechaInicio.Location = new System.Drawing.Point(89, 21);
            this.cboFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.cboFechaInicio.Name = "cboFechaInicio";
            this.cboFechaInicio.Size = new System.Drawing.Size(159, 26);
            this.cboFechaInicio.TabIndex = 245;
            this.cboFechaInicio.Tag = null;
            this.cboFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // BtnExportarExcel
            // 
            this.BtnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExportarExcel.Image = global::Halley.Presentacion.Properties.Resources.excel_16x16;
            this.BtnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExportarExcel.Location = new System.Drawing.Point(1268, 326);
            this.BtnExportarExcel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExportarExcel.Name = "BtnExportarExcel";
            this.BtnExportarExcel.Size = new System.Drawing.Size(109, 34);
            this.BtnExportarExcel.TabIndex = 362;
            this.BtnExportarExcel.Text = "Exportar";
            this.BtnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportarExcel.UseVisualStyleBackColor = true;
            this.BtnExportarExcel.Click += new System.EventHandler(this.BtnExportarExcel_Click);
            // 
            // CboEmpresa
            // 
            this.CboEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CboEmpresa.FormattingEnabled = true;
            this.CboEmpresa.Items.AddRange(new object[] {
            "INDUSTRIA",
            "GRANJA"});
            this.CboEmpresa.Location = new System.Drawing.Point(1018, 12);
            this.CboEmpresa.Name = "CboEmpresa";
            this.CboEmpresa.Size = new System.Drawing.Size(335, 27);
            this.CboEmpresa.TabIndex = 363;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(943, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 364;
            this.label4.Text = "Empresa :";
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.TcOpciones);
            this.pnl1.Controls.Add(this.BtnExportarExcel);
            this.pnl1.Controls.Add(this.label4);
            this.pnl1.Controls.Add(this.BtnNuevo);
            this.pnl1.Controls.Add(this.BtnMostrarPlan);
            this.pnl1.Controls.Add(this.label1);
            this.pnl1.Controls.Add(this.CboEmpresa);
            this.pnl1.Location = new System.Drawing.Point(4, 3);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(1381, 367);
            this.pnl1.TabIndex = 365;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.TcProduccion);
            this.pnl2.Location = new System.Drawing.Point(4, 376);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(1380, 357);
            this.pnl2.TabIndex = 366;
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // PlanDeProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlanDeProduccion";
            this.Size = new System.Drawing.Size(1392, 764);
            this.Load += new System.EventHandler(this.Produccion_Load);
            this.Controls.SetChildIndex(this.pnl1, 0);
            this.Controls.SetChildIndex(this.pnl2, 0);
            this.TcProduccion.ResumeLayout(false);
            this.TpMicroInsumos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TdgMicro)).EndInit();
            this.TpMacroInsumos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TdgMacro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductosFormulados)).EndInit();
            this.TcOpciones.ResumeLayout(false);
            this.TpPlanActual.ResumeLayout(false);
            this.TpPlanHistorico.ResumeLayout(false);
            this.TpPlanHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeFechaProduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).EndInit();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcProduccion;
        private System.Windows.Forms.TabPage TpMicroInsumos;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMicro;
        private System.Windows.Forms.TabPage TpMacroInsumos;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgFormuladosBatch;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnMostrarPlan;
        private C1.Win.C1Input.C1Button BtnGrabar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMacro;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnAgregar;
        private C1.Win.C1Input.C1Button BtnQuitar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgProductosFormulados;
        private System.Windows.Forms.TabControl TcOpciones;
        private System.Windows.Forms.TabPage TpPlanActual;
        private System.Windows.Forms.TabPage TpPlanHistorico;
        private C1.Win.C1Input.C1Button BtnQuitarHistorico;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgFormuladosHistorico;
        private System.Windows.Forms.ListBox LstHistorico;
        private C1.Win.C1Input.C1Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1DateEdit cboFechaFin;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1DateEdit cboFechaInicio;
        private C1.Win.C1Input.C1Button BtnExportarExcel;
        private C1.Win.C1Input.C1Button BtnProductoTerminado;
        private System.Windows.Forms.ComboBox CboEmpresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1DateEdit DeFechaProduccion;
        private System.Windows.Forms.ErrorProvider ErrProvider;
    }
}
