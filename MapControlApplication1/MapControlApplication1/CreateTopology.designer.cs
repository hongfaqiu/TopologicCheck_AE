namespace MapControlApplication1
{
    partial class CreateTopology
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
            this.btChooseDB = new System.Windows.Forms.Button();
            this.cbDatesetName = new System.Windows.Forms.ComboBox();
            this.cbFeatureClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRank = new System.Windows.Forms.TextBox();
            this.tbAddFeatueclass = new System.Windows.Forms.Button();
            this.tbTopologyName = new System.Windows.Forms.TextBox();
            this.lbTopologyName = new System.Windows.Forms.Label();
            this.cbRule = new System.Windows.Forms.ComboBox();
            this.cbFeatureClass1 = new System.Windows.Forms.ComboBox();
            this.cbFeatureClass2 = new System.Windows.Forms.ComboBox();
            this.btAddRule = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1NextBt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2BeforeBt = new System.Windows.Forms.Button();
            this.tbAddedFeatureclass = new System.Windows.Forms.TextBox();
            this.panel2NextBt = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel3BeforeBt = new System.Windows.Forms.Button();
            this.tbAddedRule = new System.Windows.Forms.TextBox();
            this.btDone = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btChooseDB
            // 
            this.btChooseDB.Location = new System.Drawing.Point(11, 64);
            this.btChooseDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btChooseDB.Name = "btChooseDB";
            this.btChooseDB.Size = new System.Drawing.Size(101, 20);
            this.btChooseDB.TabIndex = 0;
            this.btChooseDB.TabStop = false;
            this.btChooseDB.Text = "点击选择数据库";
            this.btChooseDB.UseVisualStyleBackColor = true;
            this.btChooseDB.Click += new System.EventHandler(this.btChooseDB_Click);
            // 
            // cbDatesetName
            // 
            this.cbDatesetName.FormattingEnabled = true;
            this.cbDatesetName.Location = new System.Drawing.Point(130, 65);
            this.cbDatesetName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDatesetName.Name = "cbDatesetName";
            this.cbDatesetName.Size = new System.Drawing.Size(97, 20);
            this.cbDatesetName.TabIndex = 1;
            this.cbDatesetName.Text = "选择数据集";
            this.cbDatesetName.SelectedIndexChanged += new System.EventHandler(this.cbDatesetName_SelectedIndexChanged);
            // 
            // cbFeatureClass
            // 
            this.cbFeatureClass.FormattingEnabled = true;
            this.cbFeatureClass.Location = new System.Drawing.Point(11, 22);
            this.cbFeatureClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFeatureClass.Name = "cbFeatureClass";
            this.cbFeatureClass.Size = new System.Drawing.Size(144, 20);
            this.cbFeatureClass.TabIndex = 2;
            this.cbFeatureClass.Text = "选择要素";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "等级";
            // 
            // tbRank
            // 
            this.tbRank.Location = new System.Drawing.Point(206, 22);
            this.tbRank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRank.Name = "tbRank";
            this.tbRank.Size = new System.Drawing.Size(76, 21);
            this.tbRank.TabIndex = 4;
            // 
            // tbAddFeatueclass
            // 
            this.tbAddFeatueclass.Location = new System.Drawing.Point(314, 25);
            this.tbAddFeatueclass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAddFeatueclass.Name = "tbAddFeatueclass";
            this.tbAddFeatueclass.Size = new System.Drawing.Size(76, 20);
            this.tbAddFeatueclass.TabIndex = 5;
            this.tbAddFeatueclass.Text = "添加要素类";
            this.tbAddFeatueclass.UseVisualStyleBackColor = true;
            this.tbAddFeatueclass.Click += new System.EventHandler(this.tbAddFeatueclass_Click);
            // 
            // tbTopologyName
            // 
            this.tbTopologyName.Location = new System.Drawing.Point(86, 20);
            this.tbTopologyName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbTopologyName.Name = "tbTopologyName";
            this.tbTopologyName.Size = new System.Drawing.Size(76, 21);
            this.tbTopologyName.TabIndex = 6;
            // 
            // lbTopologyName
            // 
            this.lbTopologyName.AutoSize = true;
            this.lbTopologyName.Location = new System.Drawing.Point(8, 20);
            this.lbTopologyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTopologyName.Name = "lbTopologyName";
            this.lbTopologyName.Size = new System.Drawing.Size(77, 12);
            this.lbTopologyName.TabIndex = 7;
            this.lbTopologyName.Text = "输入拓扑名称";
            // 
            // cbRule
            // 
            this.cbRule.FormattingEnabled = true;
            this.cbRule.Items.AddRange(new object[] {
            "Must Not Overlap",
            "Must Not Have Gaps",
            "Must Not Overlap With"});
            this.cbRule.Location = new System.Drawing.Point(130, 21);
            this.cbRule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRule.Name = "cbRule";
            this.cbRule.Size = new System.Drawing.Size(120, 20);
            this.cbRule.TabIndex = 8;
            this.cbRule.Text = "选择拓扑规则";
            // 
            // cbFeatureClass1
            // 
            this.cbFeatureClass1.FormattingEnabled = true;
            this.cbFeatureClass1.Location = new System.Drawing.Point(20, 21);
            this.cbFeatureClass1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFeatureClass1.Name = "cbFeatureClass1";
            this.cbFeatureClass1.Size = new System.Drawing.Size(92, 20);
            this.cbFeatureClass1.TabIndex = 9;
            this.cbFeatureClass1.Text = "选择要素类";
            // 
            // cbFeatureClass2
            // 
            this.cbFeatureClass2.FormattingEnabled = true;
            this.cbFeatureClass2.Location = new System.Drawing.Point(270, 21);
            this.cbFeatureClass2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFeatureClass2.Name = "cbFeatureClass2";
            this.cbFeatureClass2.Size = new System.Drawing.Size(92, 20);
            this.cbFeatureClass2.TabIndex = 10;
            this.cbFeatureClass2.Text = "选择要素类";
            // 
            // btAddRule
            // 
            this.btAddRule.Location = new System.Drawing.Point(377, 21);
            this.btAddRule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddRule.Name = "btAddRule";
            this.btAddRule.Size = new System.Drawing.Size(68, 20);
            this.btAddRule.TabIndex = 11;
            this.btAddRule.Text = "添加规则";
            this.btAddRule.UseVisualStyleBackColor = true;
            this.btAddRule.Click += new System.EventHandler(this.btAddRule_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel1NextBt);
            this.panel1.Controls.Add(this.lbTopologyName);
            this.panel1.Controls.Add(this.cbDatesetName);
            this.panel1.Controls.Add(this.btChooseDB);
            this.panel1.Controls.Add(this.tbTopologyName);
            this.panel1.Location = new System.Drawing.Point(43, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 101);
            this.panel1.TabIndex = 12;
            // 
            // panel1NextBt
            // 
            this.panel1NextBt.Location = new System.Drawing.Point(314, 64);
            this.panel1NextBt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1NextBt.Name = "panel1NextBt";
            this.panel1NextBt.Size = new System.Drawing.Size(59, 20);
            this.panel1NextBt.TabIndex = 8;
            this.panel1NextBt.Text = "下一步";
            this.panel1NextBt.UseVisualStyleBackColor = true;
            this.panel1NextBt.Click += new System.EventHandler(this.panel1NextBt_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel2BeforeBt);
            this.panel2.Controls.Add(this.tbAddedFeatureclass);
            this.panel2.Controls.Add(this.panel2NextBt);
            this.panel2.Controls.Add(this.cbFeatureClass);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbRank);
            this.panel2.Controls.Add(this.tbAddFeatueclass);
            this.panel2.Location = new System.Drawing.Point(43, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 223);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
            // 
            // panel2BeforeBt
            // 
            this.panel2BeforeBt.Location = new System.Drawing.Point(270, 181);
            this.panel2BeforeBt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2BeforeBt.Name = "panel2BeforeBt";
            this.panel2BeforeBt.Size = new System.Drawing.Size(56, 23);
            this.panel2BeforeBt.TabIndex = 8;
            this.panel2BeforeBt.Text = "上一步";
            this.panel2BeforeBt.UseVisualStyleBackColor = true;
            this.panel2BeforeBt.Click += new System.EventHandler(this.panel2BeforeBt_Click);
            // 
            // tbAddedFeatureclass
            // 
            this.tbAddedFeatureclass.Location = new System.Drawing.Point(11, 59);
            this.tbAddedFeatureclass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAddedFeatureclass.Multiline = true;
            this.tbAddedFeatureclass.Name = "tbAddedFeatureclass";
            this.tbAddedFeatureclass.Size = new System.Drawing.Size(218, 145);
            this.tbAddedFeatureclass.TabIndex = 7;
            // 
            // panel2NextBt
            // 
            this.panel2NextBt.Location = new System.Drawing.Point(354, 181);
            this.panel2NextBt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2NextBt.Name = "panel2NextBt";
            this.panel2NextBt.Size = new System.Drawing.Size(56, 23);
            this.panel2NextBt.TabIndex = 6;
            this.panel2NextBt.Text = "下一步";
            this.panel2NextBt.UseVisualStyleBackColor = true;
            this.panel2NextBt.Click += new System.EventHandler(this.panel2NextBt_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel3BeforeBt);
            this.panel3.Controls.Add(this.tbAddedRule);
            this.panel3.Controls.Add(this.btDone);
            this.panel3.Controls.Add(this.cbFeatureClass1);
            this.panel3.Controls.Add(this.cbRule);
            this.panel3.Controls.Add(this.cbFeatureClass2);
            this.panel3.Controls.Add(this.btAddRule);
            this.panel3.Location = new System.Drawing.Point(43, 16);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(468, 154);
            this.panel3.TabIndex = 14;
            this.panel3.Visible = false;
            // 
            // panel3BeforeBt
            // 
            this.panel3BeforeBt.Location = new System.Drawing.Point(306, 112);
            this.panel3BeforeBt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3BeforeBt.Name = "panel3BeforeBt";
            this.panel3BeforeBt.Size = new System.Drawing.Size(56, 23);
            this.panel3BeforeBt.TabIndex = 17;
            this.panel3BeforeBt.Text = "上一步";
            this.panel3BeforeBt.UseVisualStyleBackColor = true;
            this.panel3BeforeBt.Click += new System.EventHandler(this.panel3BeforeBt_Click);
            // 
            // tbAddedRule
            // 
            this.tbAddedRule.Location = new System.Drawing.Point(20, 64);
            this.tbAddedRule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAddedRule.Multiline = true;
            this.tbAddedRule.Name = "tbAddedRule";
            this.tbAddedRule.Size = new System.Drawing.Size(266, 66);
            this.tbAddedRule.TabIndex = 16;
            // 
            // btDone
            // 
            this.btDone.Location = new System.Drawing.Point(386, 110);
            this.btDone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(59, 27);
            this.btDone.TabIndex = 15;
            this.btDone.Text = "完成";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // CreateTopology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 276);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreateTopology";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建拓扑";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btChooseDB;
        private System.Windows.Forms.ComboBox cbDatesetName;
        private System.Windows.Forms.ComboBox cbFeatureClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRank;
        private System.Windows.Forms.Button tbAddFeatueclass;
        private System.Windows.Forms.TextBox tbTopologyName;
        private System.Windows.Forms.Label lbTopologyName;
        private System.Windows.Forms.ComboBox cbRule;
        private System.Windows.Forms.ComboBox cbFeatureClass1;
        private System.Windows.Forms.ComboBox cbFeatureClass2;
        private System.Windows.Forms.Button btAddRule;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.Button panel1NextBt;
        private System.Windows.Forms.Button panel2NextBt;
        private System.Windows.Forms.TextBox tbAddedFeatureclass;
        private System.Windows.Forms.TextBox tbAddedRule;
        private System.Windows.Forms.Button panel2BeforeBt;
        private System.Windows.Forms.Button panel3BeforeBt;
    }
}