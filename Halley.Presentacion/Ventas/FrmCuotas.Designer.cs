namespace Halley.Presentacion.Ventas
{
    partial class FrmCuotas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCuotas));
            this.TxtMonto = new C1.Win.C1Input.C1TextBox();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.TdgCuotas = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnImprimir = new C1.Win.C1Input.C1Button();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.LblMontoTotal = new System.Windows.Forms.Label();
            this.TxtCuotaInicial = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblTotalCuotas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgCuotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCuotaInicial)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtMonto
            // 
            this.TxtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMonto.Location = new System.Drawing.Point(76, 26);
            this.TxtMonto.MaxLength = 17;
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(81, 21);
            this.TxtMonto.TabIndex = 362;
            this.TxtMonto.Tag = null;
            this.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMonto_KeyPress);
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(19, 29);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(51, 15);
            this.LblCantidad.TabIndex = 361;
            this.LblCantidad.Text = "Monto:";
            // 
            // TdgCuotas
            // 
            this.TdgCuotas.AllowDelete = true;
            this.TdgCuotas.CaptionHeight = 17;
            this.TdgCuotas.EmptyRows = true;
            this.TdgCuotas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TdgCuotas.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgCuotas.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgCuotas.Images"))));
            this.TdgCuotas.Location = new System.Drawing.Point(17, 60);
            this.TdgCuotas.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell;
            this.TdgCuotas.Name = "TdgCuotas";
            this.TdgCuotas.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgCuotas.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgCuotas.PreviewInfo.ZoomFactor = 75D;
            this.TdgCuotas.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgCuotas.PrintInfo.PageSettings")));
            this.TdgCuotas.RowHeight = 15;
            this.TdgCuotas.Size = new System.Drawing.Size(457, 137);
            this.TdgCuotas.TabIndex = 410;
            this.TdgCuotas.Text = "c1TrueDBGrid1";
            this.TdgCuotas.AfterDelete += new System.EventHandler(this.TdgCuotas_AfterDelete);
            this.TdgCuotas.AfterUpdate += new System.EventHandler(this.TdgCuotas_AfterUpdate);
            this.TdgCuotas.PropBag = resources.GetString("TdgCuotas.PropBag");
            // 
            // DtpFecha
            // 
            this.DtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(264, 24);
            this.DtpFecha.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(104, 21);
            this.DtpFecha.TabIndex = 412;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.Add_16x16;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(418, 24);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(82, 23);
            this.BtnAgregar.TabIndex = 411;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 21);
            this.label3.TabIndex = 413;
            this.label3.Text = "Generar cuotas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 414;
            this.label1.Text = "Fecha pago:";
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(435, 323);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(90, 34);
            this.BtnImprimir.TabIndex = 415;
            this.BtnImprimir.Text = "Im&primir";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(259, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 416;
            this.label2.Text = "Total comprobante";
            // 
            // LblMontoTotal
            // 
            this.LblMontoTotal.AutoSize = true;
            this.LblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMontoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LblMontoTotal.Location = new System.Drawing.Point(473, 10);
            this.LblMontoTotal.Name = "LblMontoTotal";
            this.LblMontoTotal.Size = new System.Drawing.Size(44, 20);
            this.LblMontoTotal.TabIndex = 417;
            this.LblMontoTotal.Text = "0.00";
            // 
            // TxtCuotaInicial
            // 
            this.TxtCuotaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCuotaInicial.Location = new System.Drawing.Point(124, 66);
            this.TxtCuotaInicial.MaxLength = 17;
            this.TxtCuotaInicial.Name = "TxtCuotaInicial";
            this.TxtCuotaInicial.Size = new System.Drawing.Size(98, 21);
            this.TxtCuotaInicial.TabIndex = 419;
            this.TxtCuotaInicial.Tag = null;
            this.TxtCuotaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCuotaInicial.Value = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 418;
            this.label4.Text = "Adelanto:";
            // 
            // LblTotalCuotas
            // 
            this.LblTotalCuotas.AutoSize = true;
            this.LblTotalCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalCuotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblTotalCuotas.Location = new System.Drawing.Point(473, 41);
            this.LblTotalCuotas.Name = "LblTotalCuotas";
            this.LblTotalCuotas.Size = new System.Drawing.Size(44, 20);
            this.LblTotalCuotas.TabIndex = 421;
            this.LblTotalCuotas.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(259, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 420;
            this.label6.Text = "Total cuotas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpFecha);
            this.groupBox1.Controls.Add(this.BtnAgregar);
            this.groupBox1.Controls.Add(this.TdgCuotas);
            this.groupBox1.Controls.Add(this.TxtMonto);
            this.groupBox1.Controls.Add(this.LblCantidad);
            this.groupBox1.Location = new System.Drawing.Point(19, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 213);
            this.groupBox1.TabIndex = 422;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de cuotas";
            // 
            // FrmCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 360);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblTotalCuotas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtCuotaInicial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblMontoTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCuotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear cuotas";
            this.Load += new System.EventHandler(this.FrmCuotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgCuotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCuotaInicial)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtMonto;
        private System.Windows.Forms.Label LblCantidad;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgCuotas;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private C1.Win.C1Input.C1Button BtnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnImprimir;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label LblMontoTotal;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox TxtCuotaInicial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblTotalCuotas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}