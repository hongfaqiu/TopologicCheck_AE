﻿namespace MapControlApplication1
{
    partial class CreateDB
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
            this.tbxDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxDBName
            // 
            this.tbxDBName.Location = new System.Drawing.Point(70, 29);
            this.tbxDBName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxDBName.Name = "tbxDBName";
            this.tbxDBName.Size = new System.Drawing.Size(104, 21);
            this.tbxDBName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据库名";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(78, 70);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(56, 18);
            this.btnSure.TabIndex = 4;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // CreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 98);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDBName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreateDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSure;
    }
}