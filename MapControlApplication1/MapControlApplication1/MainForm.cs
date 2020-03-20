using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace MapControlApplication1
{
    public sealed partial class MainForm : Form
    {

        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        #endregion

        #region class constructor
        public MainForm()
        {
            
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {

            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
            GeoMapLoad.CopyAndOverwriteMap(axMapControl1, axPageLayoutControl1);
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdmitBookmarkNames frmABN = new AdmitBookmarkNames(this);
            frmABN.Show();
        }

        //创建书签 
        //输入：sBookmarkName 是传入的书签名称
        //输出：空间
        //创建人：qhf
        //创建时间：2019.3.8
        public void CreatBookmark(string sBookmarkName)
        {
            IAOIBookmark aoiBookmark = new AOIBookmarkClass();
            //
            if (aoiBookmark!= null)
            {
                aoiBookmark.Location = axMapControl1.ActiveView.Extent;
                aoiBookmark.Name = sBookmarkName;
            }
            
            //add aoiBookmark to map
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            if(bookmarks!= null)
            {
                bookmarks.AddBookmark(aoiBookmark);
            }

            //Add aoiBokmark to the comboxitem
            cbBookmarkList.Items.Add(sBookmarkName);
        }

        private void cbBookmarkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            IEnumSpatialBookmark enumSpatialBookmark = bookmarks.Bookmarks;
            ISpatialBookmark spatialBookmark = enumSpatialBookmark.Next();
            while (spatialBookmark != null)
            {
                if (spatialBookmark.Name == cbBookmarkList.SelectedItem.ToString())
                {
                    spatialBookmark.ZoomTo((IMap)axMapControl1.ActiveView);
                    axMapControl1.ActiveView.Refresh();
                    break;
                }
                spatialBookmark = enumSpatialBookmark.Next();
            }
        }

        private void MiAcessdata_Click(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            DataBoard dataBoard = new DataBoard(axMapControl1.Map, dataOperator.GetLayerName(axMapControl1.Map.get_Layer(1).Name));
            dataBoard.Show();
        }
        //点击要素渲染按钮时初始化下拉框
        private void FeatureRenderer_Click(object sender, EventArgs e)
        {
            IMap m_map = axMapControl1.Map;
            tbFeatureRender.Items.Clear();
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                tbFeatureRender.Items.Add(m_map.get_Layer(i).Name);
            }
        }
        //选中下拉框中图层时对该图层进行简单渲染
        private void tbFeatureRender_SelectedIndexChanged(object sender, EventArgs e)
        {

            FeatureRenderer featureRenderer = new FeatureRenderer(axMapControl1.Map);
            featureRenderer.Render(tbFeatureRender.Text);
            axTOCControl1.Update();
            axMapControl1.ActiveView.Refresh();
        }


        private void miMap_Click(object sender, EventArgs e)
        {
            //切换到地图视图           
            miMap.Checked = true;
            miPagelayout.Checked = false;
            axToolbarControl1.SetBuddyControl(axMapControl1);
            axMapControl1.Visible = true;
            axPageLayoutControl1.Visible = false;
        }

        private void miPagelayout_Click(object sender, EventArgs e)
        {
            //切换到打印视图
            axPageLayoutControl1.ActiveView.Refresh();
            GeoMapLoad.CopyAndOverwriteMap(axMapControl1, axPageLayoutControl1);
            miMap.Checked = false;
            miPagelayout.Checked = true;
            axToolbarControl1.SetBuddyControl(axPageLayoutControl1);
            axMapControl1.Visible = false;
            axPageLayoutControl1.Visible = true;
        }

        private void miExport_Click(object sender, EventArgs e)
        {
            //使用IHookHelper接口复制当前的地图视图对象，并传入Export函数
            IHookHelper layout_hookHelper = new HookHelperClass();
            if(miMap.Checked)
            layout_hookHelper.Hook = axMapControl1.Object;
            else layout_hookHelper.Hook = axPageLayoutControl1.Object;
            Export export = new Export(layout_hookHelper);
            export.Show();
        }
        
        private void tbFeatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            //调用保存文件函数
            SaveFileDialog sa = new SaveFileDialog();
            sa.Filter = "SHP文件(.shp)|*.shp";
            sa.ShowDialog();
            sa.CreatePrompt = true;
            string ExportShapeFileName = sa.FileName;
            // string StrFilter = "SHP文件(.shp)|*.shp";
            // string ExportShapeFileName = SaveFileDialog(StrFilter);
            if (ExportShapeFileName == "")
                return;
            string sFileName = System.IO.Path.GetFileNameWithoutExtension(ExportShapeFileName);
            string sParentDirectory = System.IO.Path.GetDirectoryName(ExportShapeFileName);
            esriGeometryType pGeometryType;
            pGeometryType = esriGeometryType.esriGeometryPoint;
            if (tbFeatureType.Text=="Point")
                pGeometryType = esriGeometryType.esriGeometryPoint;
            else if (tbFeatureType.Text == "Line")
                pGeometryType = esriGeometryType.esriGeometryPolyline;
            else if (tbFeatureType.Text == "Polygon")
                pGeometryType = esriGeometryType.esriGeometryPolygon;
            IFeatureClass featureClass = dataOperator.CreateShapefile(sParentDirectory, sFileName, sFileName, pGeometryType);
            if (featureClass == null)
            {
                MessageBox.Show("创建Shape文件失败！");
                return;
            }
            //将要素类添加到地图中，其图层名为“ Observation Stations”（观测站）,并记录其结果。
            //若为true，将“创建图层”按钮禁用，消息框提示，函数返回空。
            bool bRes = dataOperator.AddFeatureClassToMap(featureClass, sFileName, axMapControl1.Map);
            if (bRes)
            {
                return;
            }
            else
            {
                MessageBox.Show("将新建shape文件加入地图失败！");
                return;
            }
        }

        private void miAddFeature_Click(object sender, EventArgs e)
        {
            
            if (miAddFeature.Checked == false)
                miAddFeature.Checked = true;
            else miAddFeature.Checked = false;
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if(readTopology!=null&&readTopology.check)
            {
                IEnvelope env = axMapControl1.TrackRectangle();
                env.Expand(2, 2, true);
                readTopology.ZoneCheck(env);
            }
            
            //在添加要素菜单项被勾选时，进行以下操作
            if (miAddFeature.Checked==true)
            {
                ILayer layer = null;
                for (int i = 0; i < axMapControl1.LayerCount; i++)
                {
                    layer = axMapControl1.get_Layer(i);
                    if (layer.Name == tbAddFeature.Text)
                    {
                        break;
                    }
                    layer = null;
                }
                //通过IFeatureLayer接口访问获取到的图层，并进一步获取其要素
                IFeatureLayer featureLayer = layer as IFeatureLayer;
                IFeatureClass featureClass = featureLayer.FeatureClass;

                //按图层属性创建不同类型的geometry
                IGeometry geometry;
                switch (featureClass.ShapeType)
                {
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                        IPoint point = new PointClass();
                        point.PutCoords(e.mapX, e.mapY);
                        geometry = point;
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                        IGeometry polyline = axMapControl1.TrackLine();
                        geometry = polyline;
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                        IGeometry polygon = axMapControl1.TrackPolygon();
                        geometry = polygon;
                        break;
                    default:
                        geometry = null;
                        break;

                }
                CreateFeature createFeature = new CreateFeature(axMapControl1.Map, featureClass, geometry);
                createFeature.Show();
                return;
            }
        }

        private void tbAddFeature_Click(object sender, EventArgs e)
        {
            IMap m_map = axMapControl1.Map;
            tbAddFeature.Items.Clear();
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                tbAddFeature.Items.Add(m_map.get_Layer(i).Name);
            }
        }

        private void miSpatialFilter_Click(object sender, EventArgs e)
        {
            MapQuery mapQuery = new MapQuery(axMapControl1);
            mapQuery.Show();
        }

        private void miBuffer_Click(object sender, EventArgs e)
        {
            BufferQuery bufferQuery = new BufferQuery(axMapControl1);
            bufferQuery.Show();
        }

        private void miStatistic_Click(object sender, EventArgs e)
        {
            FeildStatistic feildStatistic = new FeildStatistic(axMapControl1.Map);
            feildStatistic.Show();
        }

        ReadTopology readTopology;
        private void tbReadTopology_Click(object sender, EventArgs e)
        {
            readTopology = new ReadTopology(axMapControl1);                   
            readTopology.Show();
        }
        private void tbCreateTopology_Click(object sender, EventArgs e)
        {
            CreateTopology createTopology = new CreateTopology(axMapControl1);
            createTopology.Show();
        }

        //创建数据库
        //调用CreateDB窗口
        private void miCreateDB_Click(object sender, EventArgs e)
        {
            CreateDB createDB = new CreateDB(this);
            createDB.Show();
        }

        //创建数据库
        public void createDB(String dbName)
        {
            //以下代码为创建数据库
            DataBaseOperator dataBaseOperator = new DataBaseOperator();
            //创建数据库
            IWorkspace workspace = dataBaseOperator.CreateAccessWorkspace(dbName);
        }

        //调用CreateDS窗口
        private void miAddDataSet_Click(object sender, EventArgs e)
        {
            CreateDS createDS = new CreateDS(this);
            createDS.Show();
        }

        //添加数据集
        public void AddDataSet(String dsName, ISpatialReference spRef, IWorkspace workSpace, Boolean haveSpaRef)
        {
            DataBaseOperator dataBaseOperator = new DataBaseOperator();
            if (haveSpaRef == false)
            {
                spRef = axMapControl1.Map.SpatialReference;
            }
            //创建数据集
            IFeatureDataset featureDataset = dataBaseOperator.CreateFeatureDataset(
                workSpace, dsName, spRef);
        }
        //调用AddFeatCla窗口添加要素类
        private void miAddFeatClass_Click(object sender, EventArgs e)
        {
            AddFeatCla addFeatCla = new AddFeatCla();
            addFeatCla.Show();
        }

    }
}