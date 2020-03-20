namespace MapControlApplication1
{
    partial class FeildStatistic
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
            this.LayerName = new System.Windows.Forms.Label();
            this.lbLayerName = new System.Windows.Forms.ListBox();
            this.FeildName = new System.Windows.Forms.Label();
            this.lbFeildName = new System.Windows.Forms.ListBox();
            this.btStatistic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LayerName
            // 
            this.LayerName.AutoSize = true;
            this.LayerName.Location = new System.Drawing.Point(12, 9);
            this.LayerName.Name = "LayerName";
            this.LayerName.Size = new System.Drawing.Size(53, 12);
            this.LayerName.TabIndex = 0;
            this.LayerName.Text = "图层名称";
            // 
            // lbLayerName
            // 
            this.lbLayerName.FormattingEnabled = true;
            this.lbLayerName.ItemHeight = 12;
            this.lbLayerName.Location = new System.Drawing.Point(71, 9);
            this.lbLayerName.Name = "lbLayerName";
            this.lbLayerName.Size = new System.Drawing.Size(120, 16);
            this.lbLayerName.TabIndex = 1;
            this.lbLayerName.SelectedIndexChanged += new System.EventHandler(this.lbLayerName_SelectedIndexChanged);
            // 
            // FeildName
            // 
            this.FeildName.AutoSize = true;
            this.FeildName.Location = new System.Drawing.Point(12, 51);
            this.FeildName.Name = "FeildName";
            this.FeildName.Size = new System.Drawing.Size(41, 12);
            this.FeildName.TabIndex = 2;
            this.FeildName.Text = "字段名";
            // 
            // lbFeildName
            // 
            this.lbFeildName.FormattingEnabled = true;
            this.lbFeildName.ItemHeight = 12;
            this.lbFeildName.Location = new System.Drawing.Point(71, 51);
            this.lbFeildName.Name = "lbFeildName";
            this.lbFeildName.Size = new System.Drawing.Size(120, 16);
            this.lbFeildName.TabIndex = 3;
            // 
            // btStatistic
            // 
            this.btStatistic.Location = new System.Drawing.Point(116, 94);
            this.btStatistic.Name = "btStatistic";
            this.btStatistic.Size = new System.Drawing.Size(75, 23);
            this.btStatistic.TabIndex = 4;
            this.btStatistic.Text = "统计";
            this.btStatistic.UseVisualStyleBackColor = true;
            this.btStatistic.Click += new System.EventHandler(this.btStatistic_Click);
            // 
            // FeildStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 129);
            this.Controls.Add(this.btStatistic);
            this.Controls.Add(this.lbFeildName);
            this.Controls.Add(this.FeildName);
            this.Controls.Add(this.lbLayerName);
            this.Controls.Add(this.LayerName);
            this.Name = "FeildStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字段统计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LayerName;
        private System.Windows.Forms.ListBox lbLayerName;
        private System.Windows.Forms.Label FeildName;
        private System.Windows.Forms.ListBox lbFeildName;
        private System.Windows.Forms.Button btStatistic;
    }
}