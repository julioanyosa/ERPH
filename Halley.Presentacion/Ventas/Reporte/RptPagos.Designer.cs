﻿namespace Halley.Presentacion.Ventas.Reporte
{
    partial class RptPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptPagos));
            this.CrvVendedores = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnMostrar = new C1.Win.C1Input.C1Button();
            this.useCliente1 = new Halley.Presentacion.Ventas.UseCliente();
            this.LstCreditos = new C1.Win.C1List.C1List();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LstCreditos)).BeginInit();
            this.SuspendLayout();
            // 
            // CrvVendedores
            // 
            this.CrvVendedores.ActiveViewIndex = -1;
            this.CrvVendedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvVendedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVendedores.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVendedores.Location = new System.Drawing.Point(3, 138);
            this.CrvVendedores.Name = "CrvVendedores";
            this.CrvVendedores.Size = new System.Drawing.Size(986, 258);
            this.CrvVendedores.TabIndex = 348;
            this.CrvVendedores.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Image = global::Halley.Presentacion.Properties.Resources.Perfil_16x16;
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrar.Location = new System.Drawing.Point(987, 96);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(82, 23);
            this.btnMostrar.TabIndex = 349;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // useCliente1
            // 
            this.useCliente1.Location = new System.Drawing.Point(82, 3);
            this.useCliente1.Name = "useCliente1";
            this.useCliente1.Size = new System.Drawing.Size(554, 129);
            this.useCliente1.TabIndex = 350;
            this.useCliente1.ComboValueChange += new Halley.Presentacion.Ventas.UseCliente.Del(this.useCliente1_ComboValueChange);
            // 
            // LstCreditos
            // 
            this.LstCreditos.AddItemSeparator = ';';
            this.LstCreditos.Caption = "Créditos";
            this.LstCreditos.CaptionHeight = 17;
            this.LstCreditos.ColumnCaptionHeight = 17;
            this.LstCreditos.ColumnFooterHeight = 17;
            this.LstCreditos.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark;
            this.LstCreditos.EmptyRows = true;
            this.LstCreditos.FetchRowStyles = true;
            this.LstCreditos.Images.Add(((System.Drawing.Image)(resources.GetObject("LstCreditos.Images"))));
            this.LstCreditos.ItemHeight = 15;
            this.LstCreditos.Location = new System.Drawing.Point(642, 14);
            this.LstCreditos.MatchEntryTimeout = ((long)(2000));
            this.LstCreditos.Name = "LstCreditos";
            this.LstCreditos.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstCreditos.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstCreditos.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstCreditos.Size = new System.Drawing.Size(339, 105);
            this.LstCreditos.TabIndex = 351;
            this.LstCreditos.FetchRowStyle += new C1.Win.C1List.FetchRowStyleEventHandler(this.LstCreditos_FetchRowStyle);
            this.LstCreditos.PropBag = resources.GetString("LstCreditos.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 42);
            this.label3.TabIndex = 396;
            this.label3.Text = "Reporte\r\nde pagos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RptPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LstCreditos);
            this.Controls.Add(this.useCliente1);
            this.Controls.Add(this.CrvVendedores);
            this.Controls.Add(this.btnMostrar);
            this.Name = "RptPagos";
            this.Size = new System.Drawing.Size(1061, 434);
            this.Load += new System.EventHandler(this.RptVendedor_Load);
            this.Controls.SetChildIndex(this.btnMostrar, 0);
            this.Controls.SetChildIndex(this.CrvVendedores, 0);
            this.Controls.SetChildIndex(this.useCliente1, 0);
            this.Controls.SetChildIndex(this.LstCreditos, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LstCreditos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVendedores;
        private C1.Win.C1Input.C1Button btnMostrar;
        private UseCliente useCliente1;
        private C1.Win.C1List.C1List LstCreditos;
        private System.Windows.Forms.Label label3;
    }
}
