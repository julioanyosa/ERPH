namespace Halley.Utilitario
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.c1List1 = new C1.Win.C1List.C1List();
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).BeginInit();
            this.SuspendLayout();
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
            this.c1List1.Location = new System.Drawing.Point(58, 132);
            this.c1List1.MatchEntryTimeout = ((long)(2000));
            this.c1List1.Name = "c1List1";
            this.c1List1.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1List1.Size = new System.Drawing.Size(75, 23);
            this.c1List1.TabIndex = 0;
            this.c1List1.Text = "c1List1";
            this.c1List1.PropBag = resources.GetString("c1List1.PropBag");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.c1List1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1List.C1List c1List1;
    }
}