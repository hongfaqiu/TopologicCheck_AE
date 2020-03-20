using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.OutputUI;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.Geoprocessor;
using System.Runtime.InteropServices;
using System.IO;

namespace MapControlApplication1
{
    public partial class CreateTopology : Form
    {
        ITopology topology; //该拓扑对象为创建拓扑对象时创建的 拓扑对象，供其他同学使用
        IFeatureWorkspace featureWorkspace; //该IfeatureWorkspace两次用于打开相应数据库中的featureClass
        IFeatureDataset featureDataset;
        public String DBPathOut = "";//选择数据后记录数据库的路径
        AxMapControl MapContro1;
        Topology myTopology = new Topology();//为拓扑类创建实体
        public CreateTopology(AxMapControl MapContro)
        {
            InitializeComponent();
            MapContro1 = MapContro;
            this.Show();
            tbAddedFeatureclass.Text = "已添加要素类";
            tbAddedRule.Text = "已添加规则";
        }
                        
        //例子程序,来自官方教程
        public void miCreateTopology()
        {
            // Open the workspace and the required datasets.
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            IWorkspace workspace = workspaceFactory.OpenFromFile(
             "C:\\arcgis\\ArcTutor\\BuildingaGeodatabase\\Montgomery.gdb", 0);// 通过路径应路径打开数据库
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset("Landbase");//通过名称打开相应的数据集
            IFeatureClass blocksFC = featureWorkspace.OpenFeatureClass("Blocks");//通过名称打开相应要素类
            IFeatureClass parcelsFC = featureWorkspace.OpenFeatureClass("Parcels");

            // Attempt to acquire an exclusive schema lock on the feature dataset.
            ISchemaLock schemaLock = (ISchemaLock)featureDataset;
            try
            {
                schemaLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);

                // Create the topology.
                ITopologyContainer2 topologyContainer = (ITopologyContainer2)featureDataset;
                ITopology topology = topologyContainer.CreateTopology("Landbase_Topology",
                    topologyContainer.DefaultClusterTolerance, -1, "");

                // Add feature classes and rules to the topology.
                topology.AddClass(blocksFC, 5, 1, 1, false);
                topology.AddClass(parcelsFC, 5, 1, 1, false);
                myTopology.AddRuleToTopology(topology, esriTopologyRuleType.esriTRTAreaNoOverlap,
                    "No Block Overlap", blocksFC);
               

                // Get an envelope with the topology's extents and validate the topology.
                IGeoDataset geoDataset = (IGeoDataset)topology;
                IEnvelope envelope = geoDataset.Extent;
               // ValidateTopology(topology, envelope); 验证拓扑
            }
            catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "Error creating topology: {0} Message: {1}", comExc.ErrorCode,
                    comExc.Message));
            }
            finally
            {
                schemaLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            }
        }
        //数据集选择状态更改后更新信息
        private void cbDatesetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            String datasetName = cbDatesetName.SelectedItem.ToString();
            featureDataset = featureWorkspace.OpenFeatureDataset(datasetName);//通过名称打开相应的数据集
            //通过featuredataset获取feature
            IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
            IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
            IFeatureClass featureClass = enumFeatureClass.Next();

            while (featureClass != null)
            {
                cbFeatureClass.Items.Add(featureClass.AliasName);
                cbFeatureClass1.Items.Add(featureClass.AliasName);
                cbFeatureClass2.Items.Add(featureClass.AliasName);
                featureClass = enumFeatureClass.Next();
            }
            ITopologyWorkspace TopoWorkSpace = featureWorkspace as ITopologyWorkspace;
            try//若不存在同名拓扑则添加  
            {
                ITopology Topology1 = TopoWorkSpace.OpenTopology(tbTopologyName.Text + "_Topology");
                MessageBox.Show("已存在该拓扑，无法添加！");
            }
            catch
            {
                return;

            }
        }
        ////当数据集被选定后，点击下一页在该数据集创建拓扑
        private void panel1NextBt_Click(object sender, EventArgs e)
        {
            if (tbTopologyName.Text == "")
            {
                MessageBox.Show("拓扑名称不能为空！");
                return;
            }
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            IWorkspace workspace = workspaceFactory.OpenFromFile(DBPathOut, 0);// 通过路径应路径打开数据库
            featureWorkspace = (IFeatureWorkspace)workspace;
            
            //创建topology
            ISchemaLock schemaLock = (ISchemaLock)featureDataset;
            try
            {
                schemaLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);

                // Create the topology.
                ITopologyContainer topologyContainer = (ITopologyContainer)featureDataset;
                String topologyName = tbTopologyName.Text;
                //下一行为测试代码
                // MessageBox.Show(topologyName + "_Topology" + "@" + topologyContainer.DefaultClusterTolerance.ToString());
                topology = topologyContainer.CreateTopology(topologyName + "_Topology",
                    topologyContainer.DefaultClusterTolerance, -1, "");
            }
            catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "拓扑创建失败: {0} 错误信息: {1}", comExc.ErrorCode,
                    comExc.Message));
            }
            finally
            {
                schemaLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            }
            panel1.Visible = false;
            panel2.Visible = true;
        }
        //选择我们需要创建topology的数据库
        private void btChooseDB_Click(object sender, EventArgs e)
        {

            String DBPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C://";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                DBPath = openFileDialog.FileName;
            DBPathOut = DBPath;         

            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            try
            {
                IWorkspace workspace = workspaceFactory.OpenFromFile(DBPath, 0);// 通过路径应路径打开数据库
                //选择数据库后获取所有数据集名称，并添加到复选框
                cbDatesetName.Items.Clear();
                featureWorkspace = (IFeatureWorkspace)workspace;
                IEnumDatasetName enumDatasetName = workspace.DatasetNames[ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTFeatureDataset];
                enumDatasetName.Reset();
                IDatasetName datasetName = enumDatasetName.Next();
                while (datasetName != null)
                {
                    cbDatesetName.Items.Add(datasetName.Name.ToString());
                    datasetName = enumDatasetName.Next();
                }
            }
            catch { return; }
        }
        
        //添加要素类
        private void tbAddFeatueclass_Click(object sender, EventArgs e)
        {//
            try
            {
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(cbFeatureClass.SelectedItem.ToString());
                if (featureClass == null)
                {
                    MessageBox.Show("null");
                    return;
                }
                topology.AddClass(featureClass, int.Parse(tbRank.Text), 1, 1, false);                
                tbAddedFeatureclass.Text += ("\r\n" + featureClass.AliasName + "  " + tbRank.Text);
                tbAddedFeatureclass.Refresh();
            }
            catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "添加要素类失败: {0} 错误信息: {1}", comExc.ErrorCode,
                    comExc.Message));
            }
        }
        //“添加规则” 按钮点击 后的相应函数
        private void btAddRule_Click(object sender, EventArgs e)
        {
            esriTopologyRuleType ruleType = esriTopologyRuleType.esriTRTAreaNoOverlap;
            switch(cbRule.SelectedIndex)
            {
                case 0:ruleType = esriTopologyRuleType.esriTRTAreaNoOverlap;break;
                case 1:ruleType = esriTopologyRuleType.esriTRTAreaNoGaps;break;
                case 2:ruleType = esriTopologyRuleType.esriTRTAreaNoOverlapArea;break;
            }
            IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(cbFeatureClass1.SelectedItem.ToString());
            myTopology.AddRuleToTopology(topology, ruleType,
                   cbRule.SelectedItem.ToString(), featureClass);
            tbAddedRule.Text += ("\r\n" + featureClass.AliasName +" "+ cbRule.SelectedItem.ToString());
            tbAddedRule.Update();
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            //以下为验证拓扑的代码
            // Get an envelope with the topology's extents and validate the topology.
            IGeoDataset geoDataset = (IGeoDataset)topology;
            IEnvelope envelope = geoDataset.Extent;
            try
            {
                myTopology.ValidateTopology(topology, envelope);// 验证拓扑
                //将拓扑结果加载到地图上
                if (topology != null)
                {
                    ITopologyLayer topolayer = new TopologyLayerClass();
                    topolayer.Topology = topology;
                    ILayer layer = topolayer as ILayer;
                    layer.Name = tbTopologyName.Text + "_Topology";
                    MapContro1.Map.AddLayer(layer);
                    MapContro1.Refresh();
                }
                MessageBox.Show("拓扑创建完成！已将拓扑结果添加到图层中！");
                this.Close();
            }
            catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "拓扑验证失败: {0} 错误信息: {1}", comExc.ErrorCode,
                    comExc.Message));
            }
            this.Close();
        }
        
        //下一页相应函数
        private void panel2NextBt_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void panel2BeforeBt_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void panel3BeforeBt_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }

        //输出shape文件
       /* private void PRV_OutPutToShape()
        {
            FeatureClassToShapefile GP_FeatureClassToShape = new FeatureClassToShapefile();
            foreach (IFeatureClass Each_FeatureClass in LI_TopoErrorFeatureClass)
            {
                GP_FeatureClassToShape.Input_Features = Each_FeatureClass;
                GP_FeatureClassToShape.Output_Folder = "E:\\";
                GP_Tool.Execute(GP_FeatureClassToShape, null);
            }

        }*/
    }
}
