﻿namespace Halley.Presentacion.Ventas.VentasPavo
{
    partial class ListGenerarVales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListGenerarVales));
            this.btnBuscar = new C1.Win.C1Input.C1Button();
            this.txtNumComprobante = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTipoComporbante = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.TxtBarra = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblSedeID = new System.Windows.Forms.Label();
            this.tdbgVentas = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNomSede = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.CboTipoComprobante = new C1.Win.C1List.C1Combo();
            this.label9 = new System.Windows.Forms.Label();
            this.imprimirEnHojaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pd = new System.Drawing.Printing.PrintDocument();
            this.BtnEnHoja = new C1.Win.C1Input.C1Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.TxtDesde = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblHasta = new System.Windows.Forms.Label();
            this.LblValesEncontrados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumComprobante)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgVentas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDesde)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(404, 47);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 34);
            this.btnBuscar.TabIndex = 148;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNumComprobante
            // 
            this.txtNumComprobante.Location = new System.Drawing.Point(187, 48);
            this.txtNumComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumComprobante.MaxLength = 300;
            this.txtNumComprobante.Name = "txtNumComprobante";
            this.txtNumComprobante.Size = new System.Drawing.Size(209, 26);
            this.txtNumComprobante.TabIndex = 147;
            this.txtNumComprobante.Tag = null;
            this.txtNumComprobante.TextChanged += new System.EventHandler(this.txtNumComprobante_TextChanged);
            this.txtNumComprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumComprobante_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 146;
            this.label3.Text = "Num Comprobante :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTipoComporbante);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.TxtBarra);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbl);
            this.groupBox1.Controls.Add(this.lblDocumento);
            this.groupBox1.Controls.Add(this.lblSedeID);
            this.groupBox1.Location = new System.Drawing.Point(33, 77);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(752, 158);
            this.groupBox1.TabIndex = 149;
            this.groupBox1.TabStop = false;
            // 
            // lblTipoComporbante
            // 
            this.lblTipoComporbante.BackColor = System.Drawing.Color.White;
            this.lblTipoComporbante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoComporbante.Location = new System.Drawing.Point(136, 114);
            this.lblTipoComporbante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoComporbante.Name = "lblTipoComporbante";
            this.lblTipoComporbante.Size = new System.Drawing.Size(241, 30);
            this.lblTipoComporbante.TabIndex = 126;
            this.lblTipoComporbante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 125;
            this.label6.Text = "Comprobante :";
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Location = new System.Drawing.Point(136, 23);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(607, 30);
            this.lblCliente.TabIndex = 122;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtBarra
            // 
            this.TxtBarra.Font = new System.Drawing.Font("MRV Code39extMA", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBarra.Location = new System.Drawing.Point(405, 63);
            this.TxtBarra.Margin = new System.Windows.Forms.Padding(4);
            this.TxtBarra.MaxLength = 300;
            this.TxtBarra.Name = "TxtBarra";
            this.TxtBarra.Size = new System.Drawing.Size(196, 115);
            this.TxtBarra.TabIndex = 158;
            this.TxtBarra.Tag = null;
            this.TxtBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtBarra.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 19);
            this.label5.TabIndex = 121;
            this.label5.Text = "Cliente :";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(85, 75);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(39, 19);
            this.lbl.TabIndex = 123;
            this.lbl.Text = "Nro :";
            // 
            // lblDocumento
            // 
            this.lblDocumento.BackColor = System.Drawing.Color.White;
            this.lblDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDocumento.Location = new System.Drawing.Point(136, 63);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(241, 30);
            this.lblDocumento.TabIndex = 124;
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSedeID
            // 
            this.lblSedeID.BackColor = System.Drawing.Color.White;
            this.lblSedeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSedeID.Location = new System.Drawing.Point(631, 108);
            this.lblSedeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSedeID.Name = "lblSedeID";
            this.lblSedeID.Size = new System.Drawing.Size(99, 30);
            this.lblSedeID.TabIndex = 152;
            this.lblSedeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSedeID.Visible = false;
            // 
            // tdbgVentas
            // 
            this.tdbgVentas.AllowUpdate = false;
            this.tdbgVentas.Caption = "REGISTRO DE VENTAS";
            this.tdbgVentas.CaptionHeight = 17;
            this.tdbgVentas.CausesValidation = false;
            this.tdbgVentas.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgVentas.EmptyRows = true;
            this.tdbgVentas.ExtendRightColumn = true;
            this.tdbgVentas.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgVentas.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgVentas.Images"))));
            this.tdbgVentas.Location = new System.Drawing.Point(33, 244);
            this.tdbgVentas.Margin = new System.Windows.Forms.Padding(4);
            this.tdbgVentas.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgVentas.Name = "tdbgVentas";
            this.tdbgVentas.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgVentas.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgVentas.PreviewInfo.ZoomFactor = 75D;
            this.tdbgVentas.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgVentas.PrintInfo.PageSettings")));
            this.tdbgVentas.RowHeight = 18;
            this.tdbgVentas.Size = new System.Drawing.Size(1309, 413);
            this.tdbgVentas.TabIndex = 150;
            this.tdbgVentas.Text = "Productos Genéricos";
            this.tdbgVentas.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgVentas.PropBag = resources.GetString("tdbgVentas.PropBag");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNomSede);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblCajero);
            this.groupBox2.Controls.Add(this.lblVendedor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(793, 77);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(549, 158);
            this.groupBox2.TabIndex = 151;
            this.groupBox2.TabStop = false;
            // 
            // lblNomSede
            // 
            this.lblNomSede.BackColor = System.Drawing.Color.White;
            this.lblNomSede.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNomSede.Location = new System.Drawing.Point(99, 26);
            this.lblNomSede.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomSede.Name = "lblNomSede";
            this.lblNomSede.Size = new System.Drawing.Size(441, 30);
            this.lblNomSede.TabIndex = 130;
            this.lblNomSede.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 129;
            this.label1.Text = "Sede :";
            // 
            // lblCajero
            // 
            this.lblCajero.BackColor = System.Drawing.Color.White;
            this.lblCajero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCajero.Location = new System.Drawing.Point(99, 121);
            this.lblCajero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(441, 30);
            this.lblCajero.TabIndex = 128;
            this.lblCajero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVendedor
            // 
            this.lblVendedor.BackColor = System.Drawing.Color.White;
            this.lblVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVendedor.Location = new System.Drawing.Point(99, 75);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(441, 30);
            this.lblVendedor.TabIndex = 118;
            this.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 117;
            this.label2.Text = "Vendedor :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 126);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 19);
            this.label14.TabIndex = 127;
            this.label14.Text = "Cajero :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1247, 666);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 34);
            this.btnCancelar.TabIndex = 153;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.CboTipoComprobante.ContentHeight = 21;
            this.CboTipoComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobante.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobante.EditorHeight = 21;
            this.CboTipoComprobante.ExtendRightColumn = true;
            this.CboTipoComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobante.Images"))));
            this.CboTipoComprobante.ItemHeight = 15;
            this.CboTipoComprobante.Location = new System.Drawing.Point(187, 9);
            this.CboTipoComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.CboTipoComprobante.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobante.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobante.MaxLength = 32767;
            this.CboTipoComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.Size = new System.Drawing.Size(209, 27);
            this.CboTipoComprobante.TabIndex = 154;
            this.CboTipoComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CboTipoComprobante.PropBag = resources.GetString("CboTipoComprobante.PropBag");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 19);
            this.label9.TabIndex = 155;
            this.label9.Text = "Comprobante :";
            // 
            // imprimirEnHojaToolStripMenuItem
            // 
            this.imprimirEnHojaToolStripMenuItem.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.imprimirEnHojaToolStripMenuItem.Name = "imprimirEnHojaToolStripMenuItem";
            this.imprimirEnHojaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.imprimirEnHojaToolStripMenuItem.Text = "Imprimir en Hoja";
            // 
            // Pd
            // 
            this.Pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Pd_PrintPage);
            // 
            // BtnEnHoja
            // 
            this.BtnEnHoja.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnEnHoja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEnHoja.Location = new System.Drawing.Point(1157, 25);
            this.BtnEnHoja.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEnHoja.Name = "BtnEnHoja";
            this.BtnEnHoja.Size = new System.Drawing.Size(104, 34);
            this.BtnEnHoja.TabIndex = 156;
            this.BtnEnHoja.Text = "En Hoja";
            this.BtnEnHoja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEnHoja.UseVisualStyleBackColor = true;
            this.BtnEnHoja.Click += new System.EventHandler(this.BtnEnHoja_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // TxtDesde
            // 
            this.TxtDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDesde.Location = new System.Drawing.Point(919, 20);
            this.TxtDesde.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDesde.MaxLength = 300;
            this.TxtDesde.Name = "TxtDesde";
            this.TxtDesde.Size = new System.Drawing.Size(125, 34);
            this.TxtDesde.TabIndex = 159;
            this.TxtDesde.Tag = null;
            this.TxtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtDesde.TextChanged += new System.EventHandler(this.TxtDesde_TextChanged);
            this.TxtDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDesde_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(835, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 38);
            this.label4.TabIndex = 160;
            this.label4.Text = "Comienza\r\ndesde:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblHasta
            // 
            this.LblHasta.AutoSize = true;
            this.LblHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHasta.Location = new System.Drawing.Point(1052, 20);
            this.LblHasta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblHasta.Name = "LblHasta";
            this.LblHasta.Size = new System.Drawing.Size(63, 38);
            this.LblHasta.TabIndex = 161;
            this.LblHasta.Text = "Hasta el\r\n0";
            this.LblHasta.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblValesEncontrados
            // 
            this.LblValesEncontrados.AutoSize = true;
            this.LblValesEncontrados.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValesEncontrados.Location = new System.Drawing.Point(660, 25);
            this.LblValesEncontrados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblValesEncontrados.Name = "LblValesEncontrados";
            this.LblValesEncontrados.Size = new System.Drawing.Size(62, 38);
            this.LblValesEncontrados.TabIndex = 162;
            this.LblValesEncontrados.Text = "Desde 0\r\nHasta 0";
            this.LblValesEncontrados.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ListGenerarVales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblValesEncontrados);
            this.Controls.Add(this.LblHasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDesde);
            this.Controls.Add(this.BtnEnHoja);
            this.Controls.Add(this.CboTipoComprobante);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tdbgVentas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNumComprobante);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListGenerarVales";
            this.Size = new System.Drawing.Size(1417, 756);
            this.PrintClick += new Halley.Presentacion.UITemplateAccess.delegatePrintClick(this.ListGenerarVales_PrintClick);
            this.Load += new System.EventHandler(this.ListGenerarVales_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNumComprobante, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.tdbgVentas, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.CboTipoComprobante, 0);
            this.Controls.SetChildIndex(this.BtnEnHoja, 0);
            this.Controls.SetChildIndex(this.TxtDesde, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.LblHasta, 0);
            this.Controls.SetChildIndex(this.LblValesEncontrados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumComprobante)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgVentas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDesde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button btnBuscar;
        private C1.Win.C1Input.C1TextBox txtNumComprobante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblDocumento;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgVentas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTipoComporbante;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNomSede;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSedeID;
        private C1.Win.C1Input.C1Button btnCancelar;
        private C1.Win.C1List.C1Combo CboTipoComprobante;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem imprimirEnHojaToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument Pd;
        private C1.Win.C1Input.C1Button BtnEnHoja;
        private System.Windows.Forms.PrintDialog printDialog1;
        private C1.Win.C1Input.C1TextBox TxtBarra;
        private C1.Win.C1Input.C1TextBox TxtDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblHasta;
        private System.Windows.Forms.Label LblValesEncontrados;
    }
}
