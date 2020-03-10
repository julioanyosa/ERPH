namespace Halley.Presentacion.Ventas
{
    partial class UseCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseCliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCliente = new C1.Win.C1List.C1Combo();
            this.label11 = new System.Windows.Forms.Label();
            this.cbNombre = new C1.Win.C1List.C1Combo();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRegistrar = new C1.Win.C1Input.C1Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNombre)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbCliente);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Controls.Add(this.cbNombre);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(724, 148);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente :";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(103, 101);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(565, 22);
            this.txtDireccion.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 120;
            this.label1.Text = "Nombre :";
            // 
            // cbCliente
            // 
            this.cbCliente.AddItemSeparator = ';';
            this.cbCliente.Caption = "";
            this.cbCliente.CaptionHeight = 17;
            this.cbCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbCliente.ColumnCaptionHeight = 17;
            this.cbCliente.ColumnFooterHeight = 17;
            this.cbCliente.ColumnHeaders = false;
            this.cbCliente.ContentHeight = 21;
            this.cbCliente.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbCliente.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbCliente.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCliente.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbCliente.EditorHeight = 21;
            this.cbCliente.ExtendRightColumn = true;
            this.cbCliente.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard;
            this.cbCliente.Images.Add(((System.Drawing.Image)(resources.GetObject("cbCliente.Images"))));
            this.cbCliente.ItemHeight = 15;
            this.cbCliente.Location = new System.Drawing.Point(103, 21);
            this.cbCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCliente.MatchEntryTimeout = ((long)(2000));
            this.cbCliente.MaxDropDownItems = ((short)(5));
            this.cbCliente.MaxLength = 32767;
            this.cbCliente.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbCliente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbCliente.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbCliente.Size = new System.Drawing.Size(268, 27);
            this.cbCliente.TabIndex = 115;
            this.cbCliente.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbCliente.SelectedValueChanged += new System.EventHandler(this.cbCliente_SelectedValueChanged);
            this.cbCliente.PropBag = resources.GetString("cbCliente.PropBag");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 114;
            this.label11.Text = "RUC O DNI :";
            // 
            // cbNombre
            // 
            this.cbNombre.AddItemSeparator = ';';
            this.cbNombre.Caption = "";
            this.cbNombre.CaptionHeight = 17;
            this.cbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbNombre.ColumnCaptionHeight = 17;
            this.cbNombre.ColumnFooterHeight = 17;
            this.cbNombre.ColumnHeaders = false;
            this.cbNombre.ContentHeight = 21;
            this.cbNombre.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbNombre.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbNombre.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNombre.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbNombre.EditorHeight = 21;
            this.cbNombre.ExtendRightColumn = true;
            this.cbNombre.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard;
            this.cbNombre.Images.Add(((System.Drawing.Image)(resources.GetObject("cbNombre.Images"))));
            this.cbNombre.ItemHeight = 15;
            this.cbNombre.Location = new System.Drawing.Point(103, 57);
            this.cbNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbNombre.MatchEntryTimeout = ((long)(2000));
            this.cbNombre.MaxDropDownItems = ((short)(5));
            this.cbNombre.MaxLength = 32767;
            this.cbNombre.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbNombre.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbNombre.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbNombre.Size = new System.Drawing.Size(567, 27);
            this.cbNombre.TabIndex = 116;
            this.cbNombre.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbNombre.PropBag = resources.GetString("cbNombre.PropBag");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 105);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 117;
            this.label10.Text = "Direccion :";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.Perfil_16x16;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(408, 21);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(101, 28);
            this.btnRegistrar.TabIndex = 118;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // UseCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UseCliente";
            this.Size = new System.Drawing.Size(739, 159);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNombre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public C1.Win.C1List.C1Combo cbCliente;
        private System.Windows.Forms.Label label11;
        public C1.Win.C1List.C1Combo cbNombre;
        private System.Windows.Forms.Label label10;
        public C1.Win.C1Input.C1Button btnRegistrar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDireccion;
    }
}
