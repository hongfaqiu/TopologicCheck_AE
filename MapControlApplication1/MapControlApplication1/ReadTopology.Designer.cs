namespace MapControlApplication1
{
    partial class ReadTopology
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTopologyRule = new System.Windows.Forms.ComboBox();
            this.btErrorSearch = new System.Windows.Forms.Button();
            this.cbCurrentExtent = new System.Windows.Forms.CheckBox();
            this.GridView1 = new System.Windows.Forms.DataGridView();
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ZoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.lbOpeanDB = new System.Windows.Forms.Label();
            this.btOpenDB = new System.Windows.Forms.Button();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.cbDSName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTPName = new System.Windows.Forms.ComboBox();
            this.btLoadTopology = new System.Windows.Forms.Button();
            this.cbvaliTopo = new System.Windows.Forms.CheckBox();
            this.cbZoneCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(55, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "显示";
            // 
            // cbTopologyRule
            // 
            this.cbTopologyRule.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTopologyRule.FormattingEnabled = true;
            this.cbTopologyRule.Items.AddRange(new object[] {
            "All Rules"});
            this.cbTopologyRule.Location = new System.Drawing.Point(112, 85);
            this.cbTopologyRule.Name = "cbTopologyRule";
            this.cbTopologyRule.Size = new System.Drawing.Size(138, 24);
            this.cbTopologyRule.TabIndex = 2;
            // 
            // btErrorSearch
            // 
            this.btErrorSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btErrorSearch.Location = new System.Drawing.Point(285, 86);
            this.btErrorSearch.Name = "btErrorSearch";
            this.btErrorSearch.Size = new System.Drawing.Size(75, 23);
            this.btErrorSearch.TabIndex = 3;
            this.btErrorSearch.Text = "搜索";
            this.btErrorSearch.UseVisualStyleBackColor = true;
            this.btErrorSearch.Click += new System.EventHandler(this.btErrorSearch_Click);
            // 
            // cbCurrentExtent
            // 
            this.cbCurrentExtent.AutoSize = true;
            this.cbCurrentExtent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCurrentExtent.Location = new System.Drawing.Point(393, 89);
            this.cbCurrentExtent.Name = "cbCurrentExtent";
            this.cbCurrentExtent.Size = new System.Drawing.Size(124, 18);
            this.cbCurrentExtent.TabIndex = 4;
            this.cbCurrentExtent.Text = "只搜索当前范围";
            this.cbCurrentExtent.UseVisualStyleBackColor = true;
            // 
            // GridView1
            // 
            this.GridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView1.ContextMenuStrip = this.RightClickMenu;
            this.GridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GridView1.Location = new System.Drawing.Point(0, 126);
            this.GridView1.Name = "GridView1";
            this.GridView1.ReadOnly = true;
            this.GridView1.RowTemplate.Height = 23;
            this.GridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView1.Size = new System.Drawing.Size(800, 281);
            this.GridView1.TabIndex = 5;
            this.GridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView1_CellClick);
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomToLayer});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.Size = new System.Drawing.Size(137, 26);
            // 
            // ZoomToLayer
            // 
            this.ZoomToLayer.Name = "ZoomToLayer";
            this.ZoomToLayer.Size = new System.Drawing.Size(136, 22);
            this.ZoomToLayer.Text = "缩放至图层";
            this.ZoomToLayer.Click += new System.EventHandler(this.ZoomToLayer_Click);
            // 
            // lbOpeanDB
            // 
            this.lbOpeanDB.AutoSize = true;
            this.lbOpeanDB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOpeanDB.Location = new System.Drawing.Point(282, 37);
            this.lbOpeanDB.Name = "lbOpeanDB";
            this.lbOpeanDB.Size = new System.Drawing.Size(77, 14);
            this.lbOpeanDB.TabIndex = 6;
            this.lbOpeanDB.Text = "选择数据集";
            // 
            // btOpenDB
            // 
            this.btOpenDB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenDB.Location = new System.Drawing.Point(25, 31);
            this.btOpenDB.Name = "btOpenDB";
            this.btOpenDB.Size = new System.Drawing.Size(87, 24);
            this.btOpenDB.TabIndex = 7;
            this.btOpenDB.Text = "选择数据库";
            this.btOpenDB.UseVisualStyleBackColor = true;
            this.btOpenDB.Click += new System.EventHandler(this.btOpenDB_Click);
            // 
            // tbDBName
            // 
            this.tbDBName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDBName.Location = new System.Drawing.Point(127, 34);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(123, 23);
            this.tbDBName.TabIndex = 8;
            // 
            // cbDSName
            // 
            this.cbDSName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDSName.FormattingEnabled = true;
            this.cbDSName.Location = new System.Drawing.Point(375, 33);
            this.cbDSName.Name = "cbDSName";
            this.cbDSName.Size = new System.Drawing.Size(97, 24);
            this.cbDSName.TabIndex = 9;
            this.cbDSName.SelectedIndexChanged += new System.EventHandler(this.cbDSName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(500, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "选择拓扑";
            // 
            // cbTPName
            // 
            this.cbTPName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTPName.FormattingEnabled = true;
            this.cbTPName.Location = new System.Drawing.Point(578, 34);
            this.cbTPName.Name = "cbTPName";
            this.cbTPName.Size = new System.Drawing.Size(97, 24);
            this.cbTPName.TabIndex = 11;
            // 
            // btLoadTopology
            // 
            this.btLoadTopology.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btLoadTopology.Location = new System.Drawing.Point(698, 34);
            this.btLoadTopology.Name = "btLoadTopology";
            this.btLoadTopology.Size = new System.Drawing.Size(75, 23);
            this.btLoadTopology.TabIndex = 12;
            this.btLoadTopology.Text = "加载拓扑";
            this.btLoadTopology.UseVisualStyleBackColor = true;
            this.btLoadTopology.Click += new System.EventHandler(this.btLoadTopology_Click);
            // 
            // cbvaliTopo
            // 
            this.cbvaliTopo.AutoSize = true;
            this.cbvaliTopo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cbvaliTopo.Location = new System.Drawing.Point(539, 90);
            this.cbvaliTopo.Margin = new System.Windows.Forms.Padding(2);
            this.cbvaliTopo.Name = "cbvaliTopo";
            this.cbvaliTopo.Size = new System.Drawing.Size(82, 18);
            this.cbvaliTopo.TabIndex = 14;
            this.cbvaliTopo.Text = "实时验证";
            this.cbvaliTopo.UseVisualStyleBackColor = true;
            // 
            // cbZoneCheck
            // 
            this.cbZoneCheck.AutoSize = true;
            this.cbZoneCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cbZoneCheck.Location = new System.Drawing.Point(657, 91);
            this.cbZoneCheck.Margin = new System.Windows.Forms.Padding(2);
            this.cbZoneCheck.Name = "cbZoneCheck";
            this.cbZoneCheck.Size = new System.Drawing.Size(110, 18);
            this.cbZoneCheck.TabIndex = 15;
            this.cbZoneCheck.Text = "区域框选搜索";
            this.cbZoneCheck.UseVisualStyleBackColor = true;
            this.cbZoneCheck.CheckedChanged += new System.EventHandler(this.cbZoneCheck_CheckedChanged);
            // 
            // ReadTopology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 407);
            this.Controls.Add(this.cbZoneCheck);
            this.Controls.Add(this.cbvaliTopo);
            this.Controls.Add(this.btLoadTopology);
            this.Controls.Add(this.cbTPName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDSName);
            this.Controls.Add(this.tbDBName);
            this.Controls.Add(this.btOpenDB);
            this.Controls.Add(this.lbOpeanDB);
            this.Controls.Add(this.GridView1);
            this.Controls.Add(this.cbCurrentExtent);
            this.Controls.Add(this.btErrorSearch);
            this.Controls.Add(this.cbTopologyRule);
            this.Controls.Add(this.label1);
            this.Name = "ReadTopology";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "错误检查器";
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTopologyRule;
        private System.Windows.Forms.Button btErrorSearch;
        private System.Windows.Forms.CheckBox cbCurrentExtent;
        private System.Windows.Forms.DataGridView GridView1;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem ZoomToLayer;
        private System.Windows.Forms.Label lbOpeanDB;
        private System.Windows.Forms.Button btOpenDB;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.ComboBox cbDSName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTPName;
        private System.Windows.Forms.Button btLoadTopology;
        private System.Windows.Forms.CheckBox cbvaliTopo;
        private System.Windows.Forms.CheckBox cbZoneCheck;
    }
}