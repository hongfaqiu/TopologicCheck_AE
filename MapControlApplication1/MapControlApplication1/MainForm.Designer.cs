namespace MapControlApplication1
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreatBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.cbBookmarkList = new System.Windows.Forms.ToolStripComboBox();
            this.miDataOperator = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAcessdata = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateShapefile = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFeatureType = new System.Windows.Forms.ToolStripComboBox();
            this.miAddFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddFeature = new System.Windows.Forms.ToolStripComboBox();
            this.FeatureRenderer = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFeatureRender = new System.Windows.Forms.ToolStripComboBox();
            this.miChangeView = new System.Windows.Forms.ToolStripMenuItem();
            this.miMap = new System.Windows.Forms.ToolStripMenuItem();
            this.miPagelayout = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.miGISAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.miSpatialFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.miBuffer = new System.Windows.Forms.ToolStripMenuItem();
            this.miStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.miTopologyCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCreateTopology = new System.Windows.Forms.ToolStripMenuItem();
            this.tbReadTopology = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateDB = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddDataSet = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddFeatClass = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.miCreatBookmark,
            this.cbBookmarkList,
            this.miDataOperator,
            this.FeatureRenderer,
            this.miChangeView,
            this.miExport,
            this.miGISAnalysis,
            this.miTopologyCheck});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(39, 25);
            this.menuFile.Text = "File";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(180, 22);
            this.menuNewDoc.Text = "New Document";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(180, 22);
            this.menuOpenDoc.Text = "Open Document...";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(180, 22);
            this.menuSaveDoc.Text = "SaveDocument";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(180, 22);
            this.menuSaveAs.Text = "Save As...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(180, 22);
            this.menuExitApp.Text = "Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // miCreatBookmark
            // 
            this.miCreatBookmark.Name = "miCreatBookmark";
            this.miCreatBookmark.Size = new System.Drawing.Size(68, 25);
            this.miCreatBookmark.Text = "创建书签";
            this.miCreatBookmark.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cbBookmarkList
            // 
            this.cbBookmarkList.Name = "cbBookmarkList";
            this.cbBookmarkList.Size = new System.Drawing.Size(75, 25);
            this.cbBookmarkList.Text = "书签列表";
            this.cbBookmarkList.SelectedIndexChanged += new System.EventHandler(this.cbBookmarkList_SelectedIndexChanged);
            // 
            // miDataOperator
            // 
            this.miDataOperator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAcessdata,
            this.miCreateShapefile,
            this.miAddFeature});
            this.miDataOperator.Name = "miDataOperator";
            this.miDataOperator.Size = new System.Drawing.Size(68, 25);
            this.miDataOperator.Text = "数据操作";
            // 
            // MiAcessdata
            // 
            this.MiAcessdata.Name = "MiAcessdata";
            this.MiAcessdata.Size = new System.Drawing.Size(136, 22);
            this.MiAcessdata.Text = "访问数据表";
            this.MiAcessdata.Click += new System.EventHandler(this.MiAcessdata_Click);
            // 
            // miCreateShapefile
            // 
            this.miCreateShapefile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFeatureType});
            this.miCreateShapefile.Name = "miCreateShapefile";
            this.miCreateShapefile.Size = new System.Drawing.Size(136, 22);
            this.miCreateShapefile.Text = "新建图层";
            // 
            // tbFeatureType
            // 
            this.tbFeatureType.Items.AddRange(new object[] {
            "Point",
            "Line",
            "Polygon"});
            this.tbFeatureType.Name = "tbFeatureType";
            this.tbFeatureType.Size = new System.Drawing.Size(100, 25);
            this.tbFeatureType.Text = "选择类型";
            this.tbFeatureType.SelectedIndexChanged += new System.EventHandler(this.tbFeatureType_SelectedIndexChanged);
            // 
            // miAddFeature
            // 
            this.miAddFeature.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAddFeature});
            this.miAddFeature.Name = "miAddFeature";
            this.miAddFeature.Size = new System.Drawing.Size(136, 22);
            this.miAddFeature.Text = "新增要素";
            this.miAddFeature.Click += new System.EventHandler(this.miAddFeature_Click);
            // 
            // tbAddFeature
            // 
            this.tbAddFeature.Name = "tbAddFeature";
            this.tbAddFeature.Size = new System.Drawing.Size(100, 25);
            this.tbAddFeature.Text = "选择图层";
            this.tbAddFeature.Click += new System.EventHandler(this.tbAddFeature_Click);
            // 
            // FeatureRenderer
            // 
            this.FeatureRenderer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFeatureRender});
            this.FeatureRenderer.Name = "FeatureRenderer";
            this.FeatureRenderer.Size = new System.Drawing.Size(68, 25);
            this.FeatureRenderer.Text = "要素渲染";
            this.FeatureRenderer.Click += new System.EventHandler(this.FeatureRenderer_Click);
            // 
            // tbFeatureRender
            // 
            this.tbFeatureRender.Name = "tbFeatureRender";
            this.tbFeatureRender.Size = new System.Drawing.Size(121, 25);
            this.tbFeatureRender.Text = "选择图层";
            this.tbFeatureRender.SelectedIndexChanged += new System.EventHandler(this.tbFeatureRender_SelectedIndexChanged);
            // 
            // miChangeView
            // 
            this.miChangeView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMap,
            this.miPagelayout});
            this.miChangeView.Name = "miChangeView";
            this.miChangeView.Size = new System.Drawing.Size(68, 25);
            this.miChangeView.Text = "视图切换";
            // 
            // miMap
            // 
            this.miMap.Checked = true;
            this.miMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miMap.Name = "miMap";
            this.miMap.Size = new System.Drawing.Size(124, 22);
            this.miMap.Text = "地图视图";
            this.miMap.Click += new System.EventHandler(this.miMap_Click);
            // 
            // miPagelayout
            // 
            this.miPagelayout.Name = "miPagelayout";
            this.miPagelayout.Size = new System.Drawing.Size(124, 22);
            this.miPagelayout.Text = "打印视图";
            this.miPagelayout.Click += new System.EventHandler(this.miPagelayout_Click);
            // 
            // miExport
            // 
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(68, 25);
            this.miExport.Text = "导出地图";
            this.miExport.Click += new System.EventHandler(this.miExport_Click);
            // 
            // miGISAnalysis
            // 
            this.miGISAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSpatialFilter,
            this.miBuffer,
            this.miStatistic});
            this.miGISAnalysis.Name = "miGISAnalysis";
            this.miGISAnalysis.Size = new System.Drawing.Size(64, 25);
            this.miGISAnalysis.Text = "GIS分析";
            // 
            // miSpatialFilter
            // 
            this.miSpatialFilter.Name = "miSpatialFilter";
            this.miSpatialFilter.Size = new System.Drawing.Size(136, 22);
            this.miSpatialFilter.Text = "空间查询";
            this.miSpatialFilter.Click += new System.EventHandler(this.miSpatialFilter_Click);
            // 
            // miBuffer
            // 
            this.miBuffer.Name = "miBuffer";
            this.miBuffer.Size = new System.Drawing.Size(136, 22);
            this.miBuffer.Text = "缓冲区分析";
            this.miBuffer.Click += new System.EventHandler(this.miBuffer_Click);
            // 
            // miStatistic
            // 
            this.miStatistic.Name = "miStatistic";
            this.miStatistic.Size = new System.Drawing.Size(136, 22);
            this.miStatistic.Text = "要素统计";
            this.miStatistic.Click += new System.EventHandler(this.miStatistic_Click);
            // 
            // miTopologyCheck
            // 
            this.miTopologyCheck.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbCreateTopology,
            this.tbReadTopology,
            this.miCreateDB,
            this.miAddDataSet,
            this.miAddFeatClass});
            this.miTopologyCheck.Name = "miTopologyCheck";
            this.miTopologyCheck.Size = new System.Drawing.Size(68, 25);
            this.miTopologyCheck.Text = "拓扑检查";
            // 
            // tbCreateTopology
            // 
            this.tbCreateTopology.Name = "tbCreateTopology";
            this.tbCreateTopology.Size = new System.Drawing.Size(136, 22);
            this.tbCreateTopology.Text = "创建拓扑";
            this.tbCreateTopology.Click += new System.EventHandler(this.tbCreateTopology_Click);
            // 
            // tbReadTopology
            // 
            this.tbReadTopology.Name = "tbReadTopology";
            this.tbReadTopology.Size = new System.Drawing.Size(136, 22);
            this.tbReadTopology.Text = "读取拓扑";
            this.tbReadTopology.Click += new System.EventHandler(this.tbReadTopology_Click);
            // 
            // miCreateDB
            // 
            this.miCreateDB.Name = "miCreateDB";
            this.miCreateDB.Size = new System.Drawing.Size(136, 22);
            this.miCreateDB.Text = "创建数据库";
            this.miCreateDB.Click += new System.EventHandler(this.miCreateDB_Click);
            // 
            // miAddDataSet
            // 
            this.miAddDataSet.Name = "miAddDataSet";
            this.miAddDataSet.Size = new System.Drawing.Size(136, 22);
            this.miAddDataSet.Text = "添加数据集";
            this.miAddDataSet.Click += new System.EventHandler(this.miAddDataSet_Click);
            // 
            // miAddFeatClass
            // 
            this.miAddFeatClass.Name = "miAddFeatClass";
            this.miAddFeatClass.Size = new System.Drawing.Size(136, 22);
            this.miAddFeatClass.Text = "添加要素类";
            this.miAddFeatClass.Click += new System.EventHandler(this.miAddFeatClass_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 29);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(859, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(3, 57);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(188, 462);
            this.axTOCControl1.TabIndex = 4;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(466, 278);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 57);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 484);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(3, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(57, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(191, 57);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(668, 462);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(859, 541);
            this.axPageLayoutControl1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 541);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.axPageLayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArcEngine Controls Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ToolStripMenuItem miCreatBookmark;
        private System.Windows.Forms.ToolStripComboBox cbBookmarkList;
        private System.Windows.Forms.ToolStripMenuItem FeatureRenderer;
        private System.Windows.Forms.ToolStripComboBox tbFeatureRender;
        private System.Windows.Forms.ToolStripMenuItem miChangeView;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ToolStripMenuItem miMap;
        private System.Windows.Forms.ToolStripMenuItem miPagelayout;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.ToolStripMenuItem miDataOperator;
        private System.Windows.Forms.ToolStripMenuItem MiAcessdata;
        private System.Windows.Forms.ToolStripMenuItem miCreateShapefile;
        private System.Windows.Forms.ToolStripComboBox tbFeatureType;
        private System.Windows.Forms.ToolStripMenuItem miAddFeature;
        private System.Windows.Forms.ToolStripComboBox tbAddFeature;
        private System.Windows.Forms.ToolStripMenuItem miGISAnalysis;
        private System.Windows.Forms.ToolStripMenuItem miSpatialFilter;
        private System.Windows.Forms.ToolStripMenuItem miBuffer;
        private System.Windows.Forms.ToolStripMenuItem miStatistic;
        private System.Windows.Forms.ToolStripMenuItem miTopologyCheck;
        private System.Windows.Forms.ToolStripMenuItem tbCreateTopology;
        private System.Windows.Forms.ToolStripMenuItem tbReadTopology;
        private System.Windows.Forms.ToolStripMenuItem miCreateDB;
        private System.Windows.Forms.ToolStripMenuItem miAddFeatClass;
        private System.Windows.Forms.ToolStripMenuItem miAddDataSet;
    }
}

