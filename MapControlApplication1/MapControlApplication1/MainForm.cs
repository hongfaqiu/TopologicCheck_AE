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

        //������ǩ 
        //���룺sBookmarkName �Ǵ������ǩ����
        //������ռ�
        //�����ˣ�qhf
        //����ʱ�䣺2019.3.8
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
        //���Ҫ����Ⱦ��ťʱ��ʼ��������
        private void FeatureRenderer_Click(object sender, EventArgs e)
        {
            IMap m_map = axMapControl1.Map;
            tbFeatureRender.Items.Clear();
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                tbFeatureRender.Items.Add(m_map.get_Layer(i).Name);
            }
        }
        //ѡ����������ͼ��ʱ�Ը�ͼ����м���Ⱦ
        private void tbFeatureRender_SelectedIndexChanged(object sender, EventArgs e)
        {

            FeatureRenderer featureRenderer = new FeatureRenderer(axMapControl1.Map);
            featureRenderer.Render(tbFeatureRender.Text);
            axTOCControl1.Update();
            axMapControl1.ActiveView.Refresh();
        }


        private void miMap_Click(object sender, EventArgs e)
        {
            //�л�����ͼ��ͼ           
            miMap.Checked = true;
            miPagelayout.Checked = false;
            axToolbarControl1.SetBuddyControl(axMapControl1);
            axMapControl1.Visible = true;
            axPageLayoutControl1.Visible = false;
        }

        private void miPagelayout_Click(object sender, EventArgs e)
        {
            //�л�����ӡ��ͼ
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
            //ʹ��IHookHelper�ӿڸ��Ƶ�ǰ�ĵ�ͼ��ͼ���󣬲�����Export����
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
            //���ñ����ļ�����
            SaveFileDialog sa = new SaveFileDialog();
            sa.Filter = "SHP�ļ�(.shp)|*.shp";
            sa.ShowDialog();
            sa.CreatePrompt = true;
            string ExportShapeFileName = sa.FileName;
            // string StrFilter = "SHP�ļ�(.shp)|*.shp";
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
                MessageBox.Show("����Shape�ļ�ʧ�ܣ�");
                return;
            }
            //��Ҫ������ӵ���ͼ�У���ͼ����Ϊ�� Observation Stations�����۲�վ��,����¼������
            //��Ϊtrue����������ͼ�㡱��ť���ã���Ϣ����ʾ���������ؿա�
            bool bRes = dataOperator.AddFeatureClassToMap(featureClass, sFileName, axMapControl1.Map);
            if (bRes)
            {
                return;
            }
            else
            {
                MessageBox.Show("���½�shape�ļ������ͼʧ�ܣ�");
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
            
            //�����Ҫ�ز˵����ѡʱ���������²���
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
                //ͨ��IFeatureLayer�ӿڷ��ʻ�ȡ����ͼ�㣬����һ����ȡ��Ҫ��
                IFeatureLayer featureLayer = layer as IFeatureLayer;
                IFeatureClass featureClass = featureLayer.FeatureClass;

                //��ͼ�����Դ�����ͬ���͵�geometry
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

        //�������ݿ�
        //����CreateDB����
        private void miCreateDB_Click(object sender, EventArgs e)
        {
            CreateDB createDB = new CreateDB(this);
            createDB.Show();
        }

        //�������ݿ�
        public void createDB(String dbName)
        {
            //���´���Ϊ�������ݿ�
            DataBaseOperator dataBaseOperator = new DataBaseOperator();
            //�������ݿ�
            IWorkspace workspace = dataBaseOperator.CreateAccessWorkspace(dbName);
        }

        //����CreateDS����
        private void miAddDataSet_Click(object sender, EventArgs e)
        {
            CreateDS createDS = new CreateDS(this);
            createDS.Show();
        }

        //������ݼ�
        public void AddDataSet(String dsName, ISpatialReference spRef, IWorkspace workSpace, Boolean haveSpaRef)
        {
            DataBaseOperator dataBaseOperator = new DataBaseOperator();
            if (haveSpaRef == false)
            {
                spRef = axMapControl1.Map.SpatialReference;
            }
            //�������ݼ�
            IFeatureDataset featureDataset = dataBaseOperator.CreateFeatureDataset(
                workSpace, dsName, spRef);
        }
        //����AddFeatCla�������Ҫ����
        private void miAddFeatClass_Click(object sender, EventArgs e)
        {
            AddFeatCla addFeatCla = new AddFeatCla();
            addFeatCla.Show();
        }

    }
}