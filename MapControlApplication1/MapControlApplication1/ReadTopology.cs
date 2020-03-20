using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace MapControlApplication1
{
    public partial class ReadTopology : Form
    {
        IFeature feature;//当前选中的要素
        Topology top = new Topology();
        ITopology topology;
        AxMapControl MapContro1;
        IFeatureWorkspace featureWorkspace;
        public ReadTopology(AxMapControl MapContro)
        {
            MapContro1 = MapContro;
            InitializeComponent();
            GridView1.MultiSelect = false;
            cbTopologyRule.Text = "All Rules";
            
        }

        //点击打开数据库按钮
        private void btOpenDB_Click(object sender, EventArgs e)
        {
            String DBPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C://";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                DBPath = openFileDialog.FileName;
            string DBName = openFileDialog.SafeFileName;
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            IWorkspace workspace = workspaceFactory.OpenFromFile(DBPath, 0);// 通过路径应路径打开数据库
            //选择数据库后获取所有数据集名称，并添加到复选框
            tbDBName.Clear();
            cbDSName.Items.Clear();
            cbTPName.Items.Clear();
            tbDBName.Text = DBName;
            featureWorkspace = (IFeatureWorkspace)workspace;
            IEnumDatasetName enumDatasetName = workspace.DatasetNames[ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTFeatureDataset];
            enumDatasetName.Reset();
            IDatasetName datasetName = enumDatasetName.Next();
            while (datasetName != null)
            {
                cbDSName.Items.Add(datasetName.Name.ToString());
                datasetName = enumDatasetName.Next();
            }
        }
        //切换数据集时更新featureclass数据
        private void cbDSName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTPName.Items.Clear();
            //通过名称打开相应的数据集
            IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(cbDSName.SelectedItem.ToString());
            //获取数据集中的拓扑名称
            IFeatureDatasetName2 featureDatasetNames = featureDataset.FullName as IFeatureDatasetName2;
            IEnumDatasetName enumDatasetName= featureDatasetNames.TopologyNames;
            IDatasetName datasetName = enumDatasetName.Next();
            if (datasetName != null)
            {
                if(datasetName.Name!=null)
                cbTPName.Items.Add(datasetName.Name);
            }
        }
        //点击加载拓扑
        private void btLoadTopology_Click(object sender, EventArgs e)
        {
            if (featureWorkspace == null || cbDSName.Text == "" || cbTPName.Text == "")
            {
                MessageBox.Show("数据为空！");
                return;
            }
            try
            {
                topology = top.OpenTopologyFromFeatureWorkspace(featureWorkspace, cbDSName.Text, cbTPName.Text);              
            }
            catch
            {
                MessageBox.Show("未找到该拓扑！");
                return;
            }
            //将拓扑结果加载到地图上
            if (topology != null)
            {
                ITopologyLayer topolayer = new TopologyLayerClass();
                topolayer.Topology = topology;
                ILayer layer = topolayer as ILayer;
                layer.Name = cbTPName.Text;
                int i;
                for ( i= 0; i < MapContro1.Map.LayerCount; i++)
                {
                    string name = MapContro1.Map.Layer[i].Name;
                    if (name == layer.Name)
                        break;
                }
                if (i == MapContro1.Map.LayerCount)
                {
                    MapContro1.Map.AddLayer(layer);
                    MapContro1.Refresh();
                }
            }
            try
            {
                //通过名称打开相应的数据集
                IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(cbDSName.SelectedItem.ToString());
                IErrorFeatureContainer errorFeatureContainer = (IErrorFeatureContainer)topology;
                Topology myTopology = new Topology();
                top.DisplayTypesForEachRule(topology);
                DataTable dataTable = new DataTable();
                // dataTable = to.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoGaps);
                IGeoDataset g = (IGeoDataset)topology;
                IEnvelope env = g.Extent;
                dataTable = top.DisplayAllErrorFeatures(topology, env);
                GridView1.DataSource = dataTable;
                ZoomToEnvelope(env, MapContro1.ActiveView);
                //初始化错误类型列表
                ITopologyRuleContainer topologyRuleContainer = (ITopologyRuleContainer)topology;
                IEnumRule enumRule = topologyRuleContainer.Rules;
                // 遍历拓扑规则.    
                enumRule.Reset();
                IRule rule = null;
                while ((rule = enumRule.Next()) != null)
                {
                    ITopologyRule topologyRule = (ITopologyRule)rule;
                    cbTopologyRule.Items.Add(topologyRule.TopologyRuleType);
                }
            }
            catch
            {
                MessageBox.Show("拓扑错误未加载！");
                return;
            }
        }

        private void btErrorSearch_Click(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            // dataTable = to.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoGaps);
            IGeoDataset g = (IGeoDataset)topology;
            IEnvelope env;
            if (cbCurrentExtent.Checked)
            {
                env = MapContro1.ActiveView.Extent;
            }
            else env = g.Extent;

            //实时验证框被勾选后进行实时验证
            if (cbvaliTopo.Checked)
            {
                top.ValidateTopology(topology, env);
                MapContro1.Refresh();
            }
                
            switch (cbTopologyRule.Text)
            {
                case "esriTRTAreaNoOverlap":
                    dataTable = top.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoOverlap, env);
                    break;
                case "esriTRTAreaNoGaps":
                    dataTable = top.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoGaps, env);
                    break;
                case "esriTRTAreaNoOverlapArea":
                    dataTable = top.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoOverlapArea, env);
                    break;
                default:
                    dataTable = top.DisplayAllErrorFeatures(topology, env);
                    break;

            }
            GridView1.DataSource = dataTable;
            ZoomToEnvelope(env, MapContro1.ActiveView);
        }

        //右键缩放及闪烁
        private void ZoomToLayer_Click(object sender, EventArgs e)
        {

            if (GridView1.CurrentRow == null) return;
            DataGridViewRow dgvr = GridView1.CurrentRow;
            int errorID = Convert.ToInt32(dgvr.Cells["错误ID"].Value.ToString());
            feature = top.GetErrorFeatureByID(topology, errorID);
            if (feature == null)
            {
                MessageBox.Show("未能获取到要素！");
                return;
            }
            ZoomToGeometry(feature.Shape, MapContro1.ActiveView);
            ITopologicalOperator ipTO = (ITopologicalOperator)feature.Shape;
            IGeometry geometry = ipTO.Buffer(0.5);
            MapContro1.FlashShape(geometry, 2, 300, null);
        }

        //缩放到要素
        public static void ZoomToGeometry(IGeometry geometry, IActiveView activeView)
        {
            if (geometry == null)
            {
                MessageBox.Show("未能获取到要素！");
                return;
            }
            IEnvelope env = geometry.Envelope;
            env.Expand(2, 2, true);
            activeView.Extent = env;
            activeView.Refresh();
            activeView.ScreenDisplay.UpdateWindow();
        }
        //缩放到指定范围
        public static void ZoomToEnvelope(IEnvelope env, IActiveView activeView)
        {
            activeView.Extent = env;
            activeView.Refresh();
            activeView.ScreenDisplay.UpdateWindow();
        }

        //选中表格内容进行闪烁
        private void GridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView1.CurrentRow == null) return;
            DataGridViewRow dgvr = GridView1.CurrentRow;
            int errorID = Convert.ToInt32(dgvr.Cells["错误ID"].Value.ToString());
            try
            {
                feature = top.GetErrorFeatureByID(topology, errorID);
            }
            catch
            {
                return;
            }
            if (feature == null)
                return;
            else
            {
                ITopologicalOperator ipTO = (ITopologicalOperator)feature.Shape;
                IGeometry geometry = ipTO.Buffer(0.5);
                MapContro1.FlashShape(geometry, 2, 300, null);
            }
        }

        public void ZoneCheck(IEnvelope env)
        {
            DataTable dataTable = new DataTable();
            // dataTable = to.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoGaps);
            IGeoDataset g = (IGeoDataset)topology;
            if (cbCurrentExtent.Checked)
            {
                cbCurrentExtent.Checked = false;
            }

            //实时验证框被勾选后进行实时验证
            if (cbvaliTopo.Checked)
            {
                top.ValidateTopology(topology, env);
                MapContro1.Refresh();
            }
                
            switch (cbTopologyRule.Text)
            {
                case "esriTRTAreaNoOverlap":
                    dataTable = top.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoOverlap, env);
                    break;
                case "esriTRTAreaNoGaps":
                    dataTable = top.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoGaps, env);
                    break;
                case "esriTRTAreaNoOverlapArea":
                    dataTable = top.DisplayErrorFeatureByRuleType(topology, esriTopologyRuleType.esriTRTAreaNoOverlapArea, env);
                    break;
                default:
                    dataTable = top.DisplayAllErrorFeatures(topology, env);
                    break;

            }
            GridView1.DataSource = dataTable;
            ZoomToEnvelope(env, MapContro1.ActiveView);
        }

        public bool check=false;
        private void cbZoneCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZoneCheck.Checked)
                check = true;
            else check = false;

        }
    }

}
