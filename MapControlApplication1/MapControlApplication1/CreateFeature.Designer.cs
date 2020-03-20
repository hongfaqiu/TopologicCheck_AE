namespace MapControlApplication1
{
    partial class CreateFeature
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
            this.tbFeatureName = new System.Windows.Forms.TextBox();
            this.btCreateFeature = new System.Windows.Forms.Button();
            this.tbFeatureType = new System.Windows.Forms.TextBox();
            this.lbFeatureType = new System.Windows.Forms.Label();
            this.lbFeatureName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbFeatureName
            // 
            this.tbFeatureName.Location = new System.Drawing.Point(105, 56);
            this.tbFeatureName.Name = "tbFeatureName";
            this.tbFeatureName.Size = new System.Drawing.Size(97, 21);
            this.tbFeatureName.TabIndex = 1;
            // 
            // btCreateFeature
            // 
            this.btCreateFeature.Location = new System.Drawing.Point(127, 93);
            this.btCreateFeature.Name = "btCreateFeature";
            this.btCreateFeature.Size = new System.Drawing.Size(75, 23);
            this.btCreateFeature.TabIndex = 2;
            this.btCreateFeature.Text = "确认创建";
            this.btCreateFeature.UseVisualStyleBackColor = true;
            this.btCreateFeature.Click += new System.EventHandler(this.btCreateFeature_Click);
            // 
            // tbFeatureType
            // 
            this.tbFeatureType.Location = new System.Drawing.Point(105, 14);
            this.tbFeatureType.Name = "tbFeatureType";
            this.tbFeatureType.Size = new System.Drawing.Size(97, 21);
            this.tbFeatureType.TabIndex = 4;
            // 
            // lbFeatureType
            // 
            this.lbFeatureType.AutoSize = true;
            this.lbFeatureType.Location = new System.Drawing.Point(12, 17);
            this.lbFeatureType.Name = "lbFeatureType";
            this.lbFeatureType.Size = new System.Drawing.Size(77, 12);
            this.lbFeatureType.TabIndex = 5;
            this.lbFeatureType.Text = "当前要素类型";
            // 
            // lbFeatureName
            // 
            this.lbFeatureName.AutoSize = true;
            this.lbFeatureName.Location = new System.Drawing.Point(12, 59);
            this.lbFeatureName.Name = "lbFeatureName";
            this.lbFeatureName.Size = new System.Drawing.Size(77, 12);
            this.lbFeatureName.TabIndex = 6;
            this.lbFeatureName.Text = "输入要素名称";
            // 
            // CreateFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 133);
            this.Controls.Add(this.lbFeatureName);
            this.Controls.Add(this.lbFeatureType);
            this.Controls.Add(this.tbFeatureType);
            this.Controls.Add(this.btCreateFeature);
            this.Controls.Add(this.tbFeatureName);
            this.Name = "CreateFeature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建要素";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbFeatureName;
        private System.Windows.Forms.Button btCreateFeature;
        private System.Windows.Forms.TextBox tbFeatureType;
        private System.Windows.Forms.Label lbFeatureType;
        private System.Windows.Forms.Label lbFeatureName;
    }
}