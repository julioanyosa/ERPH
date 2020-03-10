namespace Halley.Presentacion.Ventas
{
    partial class FrmAdelantos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdelantos));
            this.TdgAdelantosCliente = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnAceptar = new C1.Win.C1Input.C1Button();
            this.BtnQuitar = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c1SuperTooltip1 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            this.c1List1 = new C1.Win.C1List.C1List();
            ((System.ComponentModel.ISupportInitialize)(this.TdgAdelantosCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgAdelantosCliente
            // 
            this.TdgAdelantosCliente.AllowDelete = true;
            this.TdgAdelantosCliente.AllowUpdate = false;
            this.TdgAdelantosCliente.CaptionHeight = 17;
            this.TdgAdelantosCliente.EmptyRows = true;
            this.TdgAdelantosCliente.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgAdelantosCliente.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgAdelantosCliente.Images"))));
            this.TdgAdelantosCliente.Location = new System.Drawing.Point(12, 43);
            this.TdgAdelantosCliente.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgAdelantosCliente.Name = "TdgAdelantosCliente";
            this.TdgAdelantosCliente.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgAdelantosCliente.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgAdelantosCliente.PreviewInfo.ZoomFactor = 75D;
            this.TdgAdelantosCliente.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgAdelantosCliente.PrintInfo.PageSettings")));
            this.TdgAdelantosCliente.RowHeight = 15;
            this.TdgAdelantosCliente.Size = new System.Drawing.Size(665, 150);
            this.TdgAdelantosCliente.TabIndex = 0;
            this.TdgAdelantosCliente.Text = "c1TrueDBGrid1";
            this.TdgAdelantosCliente.PropBag = resources.GetString("TdgAdelantosCliente.PropBag");
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(595, 14);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(82, 23);
            this.BtnAceptar.TabIndex = 221;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c1SuperTooltip1.SetToolTip(this.BtnAceptar, resources.GetString("BtnAceptar.ToolTip"));
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitar.Location = new System.Drawing.Point(498, 14);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(82, 23);
            this.BtnQuitar.TabIndex = 220;
            this.BtnQuitar.Text = "Quitar";
            this.BtnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c1SuperTooltip1.SetToolTip(this.BtnQuitar, resources.GetString("BtnQuitar.ToolTip"));
            this.BtnQuitar.UseVisualStyleBackColor = true;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 25);
            this.label1.TabIndex = 223;
            this.label1.Text = "Adelantos realizados por el cliente";
            // 
            // c1SuperTooltip1
            // 
            this.c1SuperTooltip1.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Blue;
            this.c1SuperTooltip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip1.ForeColor = System.Drawing.Color.Black;
            this.c1SuperTooltip1.Images.Add(new C1.Win.C1SuperTooltip.ImageEntry("Pollos_32x32.gif", ((System.Drawing.Image)(resources.GetObject("c1SuperTooltip1.Images")))));
            this.c1SuperTooltip1.Images.Add(new C1.Win.C1SuperTooltip.ImageEntry("pollito32x32.gif", ((System.Drawing.Image)(resources.GetObject("c1SuperTooltip1.Images1")))));
            this.c1SuperTooltip1.Images.Add(new C1.Win.C1SuperTooltip.ImageEntry("Generate_32x32.gif", ((System.Drawing.Image)(resources.GetObject("c1SuperTooltip1.Images2")))));
            this.c1SuperTooltip1.IsBalloon = true;
            // 
            // c1List1
            // 
            this.c1List1.AddItemSeparator = ';';
            this.c1List1.CaptionHeight = 19;
            this.c1List1.ColumnCaptionHeight = 19;
            this.c1List1.ColumnFooterHeight = 19;
            this.c1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark;
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images"))));
            this.c1List1.ItemHeight = 17;
            this.c1List1.Location = new System.Drawing.Point(411, 14);
            this.c1List1.MatchEntryTimeout = ((long)(2000));
            this.c1List1.Name = "c1List1";
            this.c1List1.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1List1.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1List1.Size = new System.Drawing.Size(75, 23);
            this.c1List1.TabIndex = 224;
            this.c1List1.Text = "c1List1";
            this.c1List1.PropBag = resources.GetString("c1List1.PropBag");
            // 
            // FrmAdelantos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 203);
            this.Controls.Add(this.c1List1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnQuitar);
            this.Controls.Add(this.TdgAdelantosCliente);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAdelantos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adelantos realizados por el cliente";
            this.Load += new System.EventHandler(this.FrmAdelantos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgAdelantosCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgAdelantosCliente;
        private C1.Win.C1Input.C1Button BtnAceptar;
        private C1.Win.C1Input.C1Button BtnQuitar;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip1;
        private C1.Win.C1List.C1List c1List1;
    }
}