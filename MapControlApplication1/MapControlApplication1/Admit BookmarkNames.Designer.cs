namespace MapControlApplication1
{
    partial class AdmitBookmarkNames
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
            this.tbBookMarkName = new System.Windows.Forms.TextBox();
            this.btnButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbBookMarkName
            // 
            this.tbBookMarkName.Location = new System.Drawing.Point(12, 12);
            this.tbBookMarkName.Name = "tbBookMarkName";
            this.tbBookMarkName.Size = new System.Drawing.Size(140, 21);
            this.tbBookMarkName.TabIndex = 0;
            // 
            // btnButton1
            // 
            this.btnButton1.BackColor = System.Drawing.SystemColors.Control;
            this.btnButton1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnButton1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnButton1.Location = new System.Drawing.Point(168, 10);
            this.btnButton1.Name = "btnButton1";
            this.btnButton1.Size = new System.Drawing.Size(75, 23);
            this.btnButton1.TabIndex = 1;
            this.btnButton1.Text = "确认";
            this.btnButton1.UseVisualStyleBackColor = false;
            this.btnButton1.Click += new System.EventHandler(this.btnButton1_Click);
            // 
            // AdmitBookmarkNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 44);
            this.Controls.Add(this.btnButton1);
            this.Controls.Add(this.tbBookMarkName);
            this.Name = "AdmitBookmarkNames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加书签";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBookMarkName;
        private System.Windows.Forms.Button btnButton1;
    }
}