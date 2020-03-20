namespace MapControlApplication1
{
    partial class AddFeatCla
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
            this.cbDataSet = new System.Windows.Forms.ComboBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnSelectDB = new System.Windows.Forms.Button();
            this.addShp = new System.Windows.Forms.Button();
            this.tbxAddShp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbDataSet
            // 
            this.cbDataSet.FormattingEnabled = true;
            this.cbDataSet.Location = new System.Drawing.Point(157, 38);
            this.cbDataSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDataSet.Name = "cbDataSet";
            this.cbDataSet.Size = new System.Drawing.Size(151, 23);
            this.cbDataSet.TabIndex = 1;
            this.cbDataSet.SelectedIndexChanged += new System.EventHandler(this.cbDataSet_SelectedIndexChanged);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(133, 161);
            this.btnSure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 32);
            this.btnSure.TabIndex = 3;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.Location = new System.Drawing.Point(27, 36);
            this.btnSelectDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(113, 26);
            this.btnSelectDB.TabIndex = 4;
            this.btnSelectDB.Text = "选择数据库";
            this.btnSelectDB.UseVisualStyleBackColor = true;
            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            // 
            // addShp
            // 
            this.addShp.Location = new System.Drawing.Point(27, 97);
            this.addShp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addShp.Name = "addShp";
            this.addShp.Size = new System.Drawing.Size(115, 31);
            this.addShp.TabIndex = 5;
            this.addShp.Text = "添加要素类";
            this.addShp.UseVisualStyleBackColor = true;
            this.addShp.Click += new System.EventHandler(this.addShp_Click);
            // 
            // tbxAddShp
            // 
            this.tbxAddShp.Location = new System.Drawing.Point(157, 97);
            this.tbxAddShp.Name = "tbxAddShp";
            this.tbxAddShp.Size = new System.Drawing.Size(151, 25);
            this.tbxAddShp.TabIndex = 6;
            // 
            // AddFeatCla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 206);
            this.Controls.Add(this.tbxAddShp);
            this.Controls.Add(this.addShp);
            this.Controls.Add(this.btnSelectDB);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.cbDataSet);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddFeatCla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddFeatCla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDataSet;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnSelectDB;
        private System.Windows.Forms.Button addShp;
        private System.Windows.Forms.TextBox tbxAddShp;
    }
}