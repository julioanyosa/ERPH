namespace Halley.Presentacion.Ventas.VentasPavo
{
    partial class ListComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListComprobante));
            this.lblTotPagar = new System.Windows.Forms.Label();
            this.lblIGV = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.btnRegistrar = new C1.Win.C1Input.C1Button();
            this.tdbgPedidos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumPedido = new C1.Win.C1Input.C1TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblComentario = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CboTipoComprobante = new C1.Win.C1List.C1Combo();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbSerie = new C1.Win.C1List.C1Combo();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblCaja = new System.Windows.Forms.Label();
            this.cbTipoPago = new C1.Win.C1List.C1Combo();
            this.label18 = new System.Windows.Forms.Label();
            this.cbFormaPago = new C1.Win.C1List.C1Combo();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkExterno = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new C1.Win.C1Input.C1Button();
            this.errValidar = new System.Windows.Forms.ErrorProvider(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPedido)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotPagar
            // 
            this.lblTotPagar.BackColor = System.Drawing.Color.White;
            this.lblTotPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotPagar.Location = new System.Drawing.Point(858, 456);
            this.lblTotPagar.Name = "lblTotPagar";
            this.lblTotPagar.Size = new System.Drawing.Size(139, 21);
            this.lblTotPagar.TabIndex = 116;
            this.lblTotPagar.Text = "0";
            this.lblTotPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIGV
            // 
            this.lblIGV.BackColor = System.Drawing.Color.White;
            this.lblIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIGV.Location = new System.Drawing.Point(635, 457);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(116, 21);
            this.lblIGV.TabIndex = 115;
            this.lblIGV.Text = "0";
            this.lblIGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.White;
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Location = new System.Drawing.Point(460, 458);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(132, 21);
            this.lblSubTotal.TabIndex = 114;
            this.lblSubTotal.Text = "0";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(772, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 111;
            this.label8.Text = "Total a Pagar :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(598, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 110;
            this.label7.Text = "IGV :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "SubTotal :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(925, 486);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 23);
            this.btnCancelar.TabIndex = 108;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.guardar_16x16;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(839, 486);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(80, 23);
            this.btnRegistrar.TabIndex = 107;
            this.btnRegistrar.Text = "Generar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tdbgPedidos
            // 
            this.tdbgPedidos.AllowUpdate = false;
            this.tdbgPedidos.Caption = "REGISTRO DE VENTAS";
            this.tdbgPedidos.CaptionHeight = 17;
            this.tdbgPedidos.CausesValidation = false;
            this.tdbgPedidos.ColumnFooters = true;
            this.tdbgPedidos.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgPedidos.EmptyRows = true;
            this.tdbgPedidos.ExtendRightColumn = true;
            this.tdbgPedidos.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgPedidos.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgPedidos.Images"))));
            this.tdbgPedidos.Location = new System.Drawing.Point(15, 236);
            this.tdbgPedidos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgPedidos.Name = "tdbgPedidos";
            this.tdbgPedidos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgPedidos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgPedidos.PreviewInfo.ZoomFactor = 75D;
            this.tdbgPedidos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgPedidos.PrintInfo.PageSettings")));
            this.tdbgPedidos.RowHeight = 18;
            this.tdbgPedidos.Size = new System.Drawing.Size(982, 215);
            this.tdbgPedidos.TabIndex = 106;
            this.tdbgPedidos.Text = "Productos Genéricos";
            this.tdbgPedidos.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgPedidos.PropBag = resources.GetString("tdbgPedidos.PropBag");
            // 
            // lblVendedor
            // 
            this.lblVendedor.BackColor = System.Drawing.Color.White;
            this.lblVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVendedor.Location = new System.Drawing.Point(90, 15);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(456, 21);
            this.lblVendedor.TabIndex = 118;
            this.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 117;
            this.label2.Text = "Vendedor :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 119;
            this.label3.Text = "Num Pedido :";
            // 
            // txtNumPedido
            // 
            this.txtNumPedido.Location = new System.Drawing.Point(105, 10);
            this.txtNumPedido.MaxLength = 300;
            this.txtNumPedido.Name = "txtNumPedido";
            this.txtNumPedido.Size = new System.Drawing.Size(107, 22);
            this.txtNumPedido.TabIndex = 120;
            this.txtNumPedido.Tag = null;
            this.txtNumPedido.TextChanged += new System.EventHandler(this.txtNumPedido_TextChanged);
            this.txtNumPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPedido_KeyPress);
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Location = new System.Drawing.Point(90, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(456, 21);
            this.lblCliente.TabIndex = 122;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 121;
            this.label5.Text = "Cliente :";
            // 
            // lblDocumento
            // 
            this.lblDocumento.BackColor = System.Drawing.Color.White;
            this.lblDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDocumento.Location = new System.Drawing.Point(90, 42);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(181, 21);
            this.lblDocumento.TabIndex = 124;
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 123;
            this.label11.Text = "Nro :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 125;
            this.label13.Text = "Dirección :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 127;
            this.label14.Text = "Comentario :";
            // 
            // lblComentario
            // 
            this.lblComentario.BackColor = System.Drawing.Color.White;
            this.lblComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComentario.Location = new System.Drawing.Point(90, 41);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(456, 50);
            this.lblComentario.TabIndex = 128;
            // 
            // lblDireccion
            // 
            this.lblDireccion.BackColor = System.Drawing.Color.White;
            this.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDireccion.Location = new System.Drawing.Point(90, 69);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(456, 21);
            this.lblDireccion.TabIndex = 129;
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblDocumento);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(15, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 100);
            this.groupBox1.TabIndex = 130;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblVendedor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblComentario);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(15, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 100);
            this.groupBox2.TabIndex = 131;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 133;
            this.label9.Text = "Comprobante :";
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
            this.CboTipoComprobante.Location = new System.Drawing.Point(127, 12);
            this.CboTipoComprobante.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobante.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobante.MaxLength = 32767;
            this.CboTipoComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.Size = new System.Drawing.Size(284, 23);
            this.CboTipoComprobante.TabIndex = 132;
            this.CboTipoComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CboTipoComprobante.SelectedValueChanged += new System.EventHandler(this.cbComprobante_SelectedValueChanged);
            this.CboTipoComprobante.PropBag = resources.GetString("CboTipoComprobante.PropBag");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(87, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 135;
            this.label16.Text = "Caja :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(83, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 137;
            this.label17.Text = "Serie :";
            // 
            // cbSerie
            // 
            this.cbSerie.AddItemSeparator = ';';
            this.cbSerie.Caption = "";
            this.cbSerie.CaptionHeight = 17;
            this.cbSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbSerie.ColumnCaptionHeight = 17;
            this.cbSerie.ColumnFooterHeight = 17;
            this.cbSerie.ColumnHeaders = false;
            this.cbSerie.ColumnWidth = 100;
            this.cbSerie.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbSerie.ContentHeight = 17;
            this.cbSerie.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbSerie.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbSerie.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSerie.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbSerie.EditorHeight = 17;
            this.cbSerie.ExtendRightColumn = true;
            this.cbSerie.Images.Add(((System.Drawing.Image)(resources.GetObject("cbSerie.Images"))));
            this.cbSerie.ItemHeight = 15;
            this.cbSerie.Location = new System.Drawing.Point(127, 41);
            this.cbSerie.MatchEntryTimeout = ((long)(2000));
            this.cbSerie.MaxDropDownItems = ((short)(5));
            this.cbSerie.MaxLength = 32767;
            this.cbSerie.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbSerie.Size = new System.Drawing.Size(284, 23);
            this.cbSerie.TabIndex = 136;
            this.cbSerie.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbSerie.PropBag = resources.GetString("cbSerie.PropBag");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblCaja);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.CboTipoComprobante);
            this.groupBox3.Controls.Add(this.cbSerie);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(575, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 113);
            this.groupBox3.TabIndex = 138;
            this.groupBox3.TabStop = false;
            // 
            // LblCaja
            // 
            this.LblCaja.BackColor = System.Drawing.Color.White;
            this.LblCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCaja.Location = new System.Drawing.Point(128, 79);
            this.LblCaja.Name = "LblCaja";
            this.LblCaja.Size = new System.Drawing.Size(283, 21);
            this.LblCaja.TabIndex = 129;
            this.LblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.AddItemSeparator = ';';
            this.cbTipoPago.Caption = "";
            this.cbTipoPago.CaptionHeight = 17;
            this.cbTipoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbTipoPago.ColumnCaptionHeight = 17;
            this.cbTipoPago.ColumnFooterHeight = 17;
            this.cbTipoPago.ColumnHeaders = false;
            this.cbTipoPago.ColumnWidth = 100;
            this.cbTipoPago.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbTipoPago.ContentHeight = 17;
            this.cbTipoPago.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbTipoPago.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbTipoPago.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoPago.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbTipoPago.EditorHeight = 17;
            this.cbTipoPago.ExtendRightColumn = true;
            this.cbTipoPago.Images.Add(((System.Drawing.Image)(resources.GetObject("cbTipoPago.Images"))));
            this.cbTipoPago.ItemHeight = 15;
            this.cbTipoPago.Location = new System.Drawing.Point(124, 15);
            this.cbTipoPago.MatchEntryTimeout = ((long)(2000));
            this.cbTipoPago.MaxDropDownItems = ((short)(5));
            this.cbTipoPago.MaxLength = 32767;
            this.cbTipoPago.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbTipoPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbTipoPago.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbTipoPago.Size = new System.Drawing.Size(288, 23);
            this.cbTipoPago.TabIndex = 139;
            this.cbTipoPago.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbTipoPago.SelectedValueChanged += new System.EventHandler(this.cbTipoPago_SelectedValueChanged);
            this.cbTipoPago.PropBag = resources.GetString("cbTipoPago.PropBag");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(45, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 141;
            this.label18.Text = "Forma Pago :";
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.AddItemSeparator = ';';
            this.cbFormaPago.Caption = "";
            this.cbFormaPago.CaptionHeight = 17;
            this.cbFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbFormaPago.ColumnCaptionHeight = 17;
            this.cbFormaPago.ColumnFooterHeight = 17;
            this.cbFormaPago.ColumnHeaders = false;
            this.cbFormaPago.ColumnWidth = 100;
            this.cbFormaPago.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbFormaPago.ContentHeight = 17;
            this.cbFormaPago.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbFormaPago.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbFormaPago.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPago.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbFormaPago.EditorHeight = 17;
            this.cbFormaPago.ExtendRightColumn = true;
            this.cbFormaPago.Images.Add(((System.Drawing.Image)(resources.GetObject("cbFormaPago.Images"))));
            this.cbFormaPago.ItemHeight = 15;
            this.cbFormaPago.Location = new System.Drawing.Point(124, 44);
            this.cbFormaPago.MatchEntryTimeout = ((long)(2000));
            this.cbFormaPago.MaxDropDownItems = ((short)(5));
            this.cbFormaPago.MaxLength = 32767;
            this.cbFormaPago.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbFormaPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbFormaPago.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbFormaPago.Size = new System.Drawing.Size(288, 23);
            this.cbFormaPago.TabIndex = 140;
            this.cbFormaPago.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbFormaPago.SelectedValueChanged += new System.EventHandler(this.cbFormaPago_SelectedValueChanged);
            this.cbFormaPago.PropBag = resources.GetString("cbFormaPago.PropBag");
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(54, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 13);
            this.label19.TabIndex = 142;
            this.label19.Text = "Tipo Pago :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbTipoPago);
            this.groupBox4.Controls.Add(this.cbFormaPago);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(578, 150);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(419, 80);
            this.groupBox4.TabIndex = 142;
            this.groupBox4.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(438, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 144;
            this.label20.Text = "Pedido :";
            // 
            // chkExterno
            // 
            this.chkExterno.AutoSize = true;
            this.chkExterno.Enabled = false;
            this.chkExterno.Location = new System.Drawing.Point(493, 15);
            this.chkExterno.Name = "chkExterno";
            this.chkExterno.Size = new System.Drawing.Size(65, 17);
            this.chkExterno.TabIndex = 143;
            this.chkExterno.Text = "Externo";
            this.chkExterno.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(218, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 23);
            this.btnBuscar.TabIndex = 145;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // errValidar
            // 
            this.errValidar.ContainerControl = this;
            this.errValidar.RightToLeft = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // ListComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chkExterno);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNumPedido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotPagar);
            this.Controls.Add(this.lblIGV);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.tdbgPedidos);
            this.Name = "ListComprobante";
            this.Size = new System.Drawing.Size(1037, 556);
            this.Load += new System.EventHandler(this.ListComprobante_Load);
            this.Controls.SetChildIndex(this.tdbgPedidos, 0);
            this.Controls.SetChildIndex(this.btnRegistrar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblSubTotal, 0);
            this.Controls.SetChildIndex(this.lblIGV, 0);
            this.Controls.SetChildIndex(this.lblTotPagar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNumPedido, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.chkExterno, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPedido)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerie)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errValidar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotPagar;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1Button btnCancelar;
        private C1.Win.C1Input.C1Button btnRegistrar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgPedidos;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtNumPedido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1List.C1Combo CboTipoComprobante;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private C1.Win.C1List.C1Combo cbSerie;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1List.C1Combo cbTipoPago;
        private System.Windows.Forms.Label label18;
        private C1.Win.C1List.C1Combo cbFormaPago;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkExterno;
        private C1.Win.C1Input.C1Button btnBuscar;
        private System.Windows.Forms.ErrorProvider errValidar;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label LblCaja;
    }
}
