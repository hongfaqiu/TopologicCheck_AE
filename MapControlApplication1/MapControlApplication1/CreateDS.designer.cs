namespace MapControlApplication1
{
    partial class CreateDS
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
            this.tbxDSName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnSetSpaRef = new System.Windows.Forms.Button();
            this.tbxSpaRef = new System.Windows.Forms.TextBox();
            this.btnSelectDB = new System.Windows.Forms.Button();
            this.tbxSelectDB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxDSName
            // 
            this.tbxDSName.Location = new System.Drawing.Point(97, 15);
            this.tbxDSName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxDSName.Name = "tbxDSName";
            this.tbxDSName.Size = new System.Drawing.Size(187, 21);
            this.tbxDSName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据集名称";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(121, 152);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(56, 18);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnSetSpaRef
            // 
            this.btnSetSpaRef.Location = new System.Drawing.Point(19, 107);
            this.btnSetSpaRef.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetSpaRef.Name = "btnSetSpaRef";
            this.btnSetSpaRef.Size = new System.Drawing.Size(74, 20);
            this.btnSetSpaRef.TabIndex = 4;
            this.btnSetSpaRef.Text = "空间参考系";
            this.btnSetSpaRef.UseVisualStyleBackColor = true;
            this.btnSetSpaRef.Click += new System.EventHandler(this.btnSetSpaRef_Click);
            // 
            // tbxSpaRef
            // 
            this.tbxSpaRef.Location = new System.Drawing.Point(97, 106);
            this.tbxSpaRef.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxSpaRef.Name = "tbxSpaRef";
            this.tbxSpaRef.Size = new System.Drawing.Size(187, 21);
            this.tbxSpaRef.TabIndex = 5;
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.Location = new System.Drawing.Point(19, 58);
            this.btnSelectDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(74, 21);
            this.btnSelectDB.TabIndex = 6;
            this.btnSelectDB.Text = "选择数据库";
            this.btnSelectDB.UseVisualStyleBackColor = true;
            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            // 
            // tbxSelectDB
            // 
            this.tbxSelectDB.Location = new System.Drawing.Point(97, 58);
            this.tbxSelectDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxSelectDB.Name = "tbxSelectDB";
            this.tbxSelectDB.Size = new System.Drawing.Size(187, 21);
            this.tbxSelectDB.TabIndex = 7;
            // 
            // CreateDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 199);
            this.Controls.Add(this.tbxSelectDB);
            this.Controls.Add(this.btnSelectDB);
            this.Controls.Add(this.tbxSpaRef);
            this.Controls.Add(this.btnSetSpaRef);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDSName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreateDS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateDS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDSName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnSetSpaRef;
        private System.Windows.Forms.TextBox tbxSpaRef;
        private System.Windows.Forms.Button btnSelectDB;
        private System.Windows.Forms.TextBox tbxSelectDB;
    }
}