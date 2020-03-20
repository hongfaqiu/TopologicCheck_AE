namespace MapControlApplication1
{
    partial class CreatFeatureClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.btCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFeatureName = new System.Windows.Forms.TextBox();
            this.lbFeatureType = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入要素名称：";
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(214, 37);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(75, 23);
            this.btCreate.TabIndex = 1;
            this.btCreate.Text = "确认创建";
            this.btCreate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "输入几何类型：";
            // 
            // txtFeatureName
            // 
            this.txtFeatureName.Location = new System.Drawing.Point(92, 3);
            this.txtFeatureName.Name = "txtFeatureName";
            this.txtFeatureName.Size = new System.Drawing.Size(100, 21);
            this.txtFeatureName.TabIndex = 3;
            // 
            // lbFeatureType
            // 
            this.lbFeatureType.FormattingEnabled = true;
            this.lbFeatureType.ItemHeight = 12;
            this.lbFeatureType.Items.AddRange(new object[] {
            "Point",
            "Line",
            "Polygon"});
            this.lbFeatureType.Location = new System.Drawing.Point(92, 42);
            this.lbFeatureType.Name = "lbFeatureType";
            this.lbFeatureType.Size = new System.Drawing.Size(100, 16);
            this.lbFeatureType.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "保存目录";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CreatFeatureClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 63);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbFeatureType);
            this.Controls.Add(this.txtFeatureName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.label1);
            this.Name = "CreatFeatureClass";
            this.Text = "CreatFeatureClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFeatureName;
        private System.Windows.Forms.ListBox lbFeatureType;
        private System.Windows.Forms.Button button1;
    }
}