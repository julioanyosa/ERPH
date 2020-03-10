namespace Halley.Presentacion.VentasTemp
{
    partial class FrmListaProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaProductos));
            this.TdgListaProductos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.TdgListaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgListaProductos
            // 
            this.TdgListaProductos.AllowUpdate = false;
            this.TdgListaProductos.CaptionHeight = 17;
            this.TdgListaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TdgListaProductos.EmptyRows = true;
            this.TdgListaProductos.FilterBar = true;
            this.TdgListaProductos.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgListaProductos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgListaProductos.Images"))));
            this.TdgListaProductos.Location = new System.Drawing.Point(0, 0);
            this.TdgListaProductos.Name = "TdgListaProductos";
            this.TdgListaProductos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgListaProductos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgListaProductos.PreviewInfo.ZoomFactor = 75D;
            this.TdgListaProductos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgDocumento.PrintInfo.PageSettings")));
            this.TdgListaProductos.RowHeight = 15;
            this.TdgListaProductos.Size = new System.Drawing.Size(561, 293);
            this.TdgListaProductos.TabIndex = 6;
            this.TdgListaProductos.Text = "c1TrueDBGrid1";
            this.TdgListaProductos.DoubleClick += new System.EventHandler(this.TdgListaProductos_DoubleClick);
            this.TdgListaProductos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TdgListaProductos_KeyPress);
            this.TdgListaProductos.PropBag = resources.GetString("TdgListaProductos.PropBag");
            // 
            // FrmListaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 293);
            this.Controls.Add(this.TdgListaProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmListaProductos";
            this.Text = "Lista de productos";
            this.Load += new System.EventHandler(this.FrmListaProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgListaProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgListaProductos;
    }
}