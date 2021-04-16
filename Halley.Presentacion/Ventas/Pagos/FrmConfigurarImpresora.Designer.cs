namespace Halley.Presentacion.Ventas.Pagos
{
    partial class FrmConfigurarImpresora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigurarImpresora));
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnImpresora = new C1.Win.C1Input.C1Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.LblTicketGranja = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblTicketIndustria = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblTicketComercial = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LblTicketPago = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.BtnImpresoraPago = new C1.Win.C1Input.C1Button();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.LblTicketAvicola = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblTicketGanaderiaSantoDomingo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTicketAgropecuaria = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.c1cboCia.Location = new System.Drawing.Point(84, 64);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(379, 23);
            this.c1cboCia.TabIndex = 387;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 401;
            this.label12.Text = "Empresa :";
            // 
            // BtnImpresora
            // 
            this.BtnImpresora.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImpresora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImpresora.Location = new System.Drawing.Point(469, 64);
            this.BtnImpresora.Name = "BtnImpresora";
            this.BtnImpresora.Size = new System.Drawing.Size(105, 23);
            this.BtnImpresora.TabIndex = 419;
            this.BtnImpresora.Text = "Seleccionar";
            this.BtnImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImpresora.UseVisualStyleBackColor = true;
            this.BtnImpresora.Click += new System.EventHandler(this.BtnImpresora_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // LblTicketGranja
            // 
            this.LblTicketGranja.BackColor = System.Drawing.Color.White;
            this.LblTicketGranja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketGranja.Location = new System.Drawing.Point(154, 26);
            this.LblTicketGranja.Name = "LblTicketGranja";
            this.LblTicketGranja.Size = new System.Drawing.Size(408, 21);
            this.LblTicketGranja.TabIndex = 421;
            this.LblTicketGranja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 420;
            this.label6.Text = "Granja :";
            // 
            // LblTicketIndustria
            // 
            this.LblTicketIndustria.BackColor = System.Drawing.Color.White;
            this.LblTicketIndustria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketIndustria.Location = new System.Drawing.Point(154, 62);
            this.LblTicketIndustria.Name = "LblTicketIndustria";
            this.LblTicketIndustria.Size = new System.Drawing.Size(408, 21);
            this.LblTicketIndustria.TabIndex = 424;
            this.LblTicketIndustria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 423;
            this.label8.Text = "Industria:";
            // 
            // LblTicketComercial
            // 
            this.LblTicketComercial.BackColor = System.Drawing.Color.White;
            this.LblTicketComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketComercial.Location = new System.Drawing.Point(154, 99);
            this.LblTicketComercial.Name = "LblTicketComercial";
            this.LblTicketComercial.Size = new System.Drawing.Size(408, 21);
            this.LblTicketComercial.TabIndex = 426;
            this.LblTicketComercial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 425;
            this.label13.Text = "Comercial :";
            // 
            // LblTicketPago
            // 
            this.LblTicketPago.BackColor = System.Drawing.Color.White;
            this.LblTicketPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketPago.Location = new System.Drawing.Point(126, 359);
            this.LblTicketPago.Name = "LblTicketPago";
            this.LblTicketPago.Size = new System.Drawing.Size(343, 21);
            this.LblTicketPago.TabIndex = 428;
            this.LblTicketPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(35, 363);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(85, 13);
            this.lbl.TabIndex = 427;
            this.lbl.Text = "Ticketera pago :";
            // 
            // BtnImpresoraPago
            // 
            this.BtnImpresoraPago.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImpresoraPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImpresoraPago.Location = new System.Drawing.Point(487, 357);
            this.BtnImpresoraPago.Name = "BtnImpresoraPago";
            this.BtnImpresoraPago.Size = new System.Drawing.Size(87, 23);
            this.BtnImpresoraPago.TabIndex = 429;
            this.BtnImpresoraPago.Text = "Seleccionar";
            this.BtnImpresoraPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImpresoraPago.UseVisualStyleBackColor = true;
            this.BtnImpresoraPago.Click += new System.EventHandler(this.BtnImpresoraPago_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(487, 3);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(87, 36);
            this.BtnCerrar.TabIndex = 430;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // LblTicketAvicola
            // 
            this.LblTicketAvicola.BackColor = System.Drawing.Color.White;
            this.LblTicketAvicola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketAvicola.Location = new System.Drawing.Point(154, 137);
            this.LblTicketAvicola.Name = "LblTicketAvicola";
            this.LblTicketAvicola.Size = new System.Drawing.Size(408, 21);
            this.LblTicketAvicola.TabIndex = 432;
            this.LblTicketAvicola.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 431;
            this.label10.Text = "Avicola:";
            // 
            // LblTicketGanaderiaSantoDomingo
            // 
            this.LblTicketGanaderiaSantoDomingo.BackColor = System.Drawing.Color.White;
            this.LblTicketGanaderiaSantoDomingo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketGanaderiaSantoDomingo.Location = new System.Drawing.Point(154, 173);
            this.LblTicketGanaderiaSantoDomingo.Name = "LblTicketGanaderiaSantoDomingo";
            this.LblTicketGanaderiaSantoDomingo.Size = new System.Drawing.Size(408, 21);
            this.LblTicketGanaderiaSantoDomingo.TabIndex = 434;
            this.LblTicketGanaderiaSantoDomingo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 433;
            this.label3.Text = "Ganaderia Santo Domingo";
            // 
            // LblTicketAgropecuaria
            // 
            this.LblTicketAgropecuaria.BackColor = System.Drawing.Color.White;
            this.LblTicketAgropecuaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketAgropecuaria.Location = new System.Drawing.Point(154, 206);
            this.LblTicketAgropecuaria.Name = "LblTicketAgropecuaria";
            this.LblTicketAgropecuaria.Size = new System.Drawing.Size(408, 21);
            this.LblTicketAgropecuaria.TabIndex = 436;
            this.LblTicketAgropecuaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 435;
            this.label5.Text = "Agropecuaria Halley";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblTicketAgropecuaria);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LblTicketGanaderiaSantoDomingo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LblTicketAvicola);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.LblTicketComercial);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.LblTicketIndustria);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.LblTicketGranja);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 240);
            this.groupBox1.TabIndex = 437;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresoras seleccionadas";
            // 
            // FrmConfigurarImpresora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 401);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnImpresoraPago);
            this.Controls.Add(this.LblTicketPago);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.BtnImpresora);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.c1cboCia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmConfigurarImpresora";
            this.Text = "Configurar impresora";
            this.Load += new System.EventHandler(this.FrmConfigurarImpresora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label12;
        private C1.Win.C1Input.C1Button BtnImpresora;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label LblTicketGranja;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblTicketIndustria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblTicketComercial;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblTicketPago;
        private System.Windows.Forms.Label lbl;
        private C1.Win.C1Input.C1Button BtnImpresoraPago;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private System.Windows.Forms.Label LblTicketAvicola;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LblTicketGanaderiaSantoDomingo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTicketAgropecuaria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}