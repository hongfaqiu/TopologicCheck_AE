namespace MapControlApplication1
{
    partial class MapQuery
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbQueryName1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQueryText1 = new System.Windows.Forms.TextBox();
            this.tbQueryText2 = new System.Windows.Forms.TextBox();
            this.btQuery = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbQueryName2 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(536, 315);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询图层1";
            // 
            // lbQueryName1
            // 
            this.lbQueryName1.FormattingEnabled = true;
            this.lbQueryName1.ItemHeight = 12;
            this.lbQueryName1.Location = new System.Drawing.Point(71, 9);
            this.lbQueryName1.Name = "lbQueryName1";
            this.lbQueryName1.Size = new System.Drawing.Size(120, 16);
            this.lbQueryName1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "查询条件1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "查询条件2";
            // 
            // tbQueryText1
            // 
            this.tbQueryText1.Location = new System.Drawing.Point(294, 6);
            this.tbQueryText1.Name = "tbQueryText1";
            this.tbQueryText1.Size = new System.Drawing.Size(127, 21);
            this.tbQueryText1.TabIndex = 5;
            // 
            // tbQueryText2
            // 
            this.tbQueryText2.Location = new System.Drawing.Point(294, 33);
            this.tbQueryText2.Name = "tbQueryText2";
            this.tbQueryText2.Size = new System.Drawing.Size(127, 21);
            this.tbQueryText2.TabIndex = 6;
            // 
            // btQuery
            // 
            this.btQuery.Location = new System.Drawing.Point(449, 31);
            this.btQuery.Name = "btQuery";
            this.btQuery.Size = new System.Drawing.Size(75, 23);
            this.btQuery.TabIndex = 7;
            this.btQuery.Text = "确认查询";
            this.btQuery.UseVisualStyleBackColor = true;
            this.btQuery.Click += new System.EventHandler(this.btQuery_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "查询图层2";
            // 
            // lbQueryName2
            // 
            this.lbQueryName2.FormattingEnabled = true;
            this.lbQueryName2.ItemHeight = 12;
            this.lbQueryName2.Location = new System.Drawing.Point(71, 36);
            this.lbQueryName2.Name = "lbQueryName2";
            this.lbQueryName2.Size = new System.Drawing.Size(120, 16);
            this.lbQueryName2.TabIndex = 9;
            // 
            // MapQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 376);
            this.Controls.Add(this.lbQueryName2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btQuery);
            this.Controls.Add(this.tbQueryText2);
            this.Controls.Add(this.tbQueryText1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbQueryName1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MapQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图查询";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbQueryName1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbQueryText1;
        private System.Windows.Forms.TextBox tbQueryText2;
        private System.Windows.Forms.Button btQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbQueryName2;
    }
}