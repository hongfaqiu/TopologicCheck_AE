using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapControlApplication1
{
    public partial class AddFeatCla : Form
    {
        public AddFeatCla()
        {
            InitializeComponent();
            this.Show();
        }

        public static IFeatureWorkspace featureWorkspace; 
        public String DBPathOut = "";//选择数据后记录数据库的路径
        
        //选择数据库
        private void btnSelectDB_Click(object sender, EventArgs e)
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
            IWorkspace workspace = workspaceFactory.OpenFromFile(DBPath, 0);// 通过路径应路径打开数据库
            //选择数据库后获取所有数据集名称，并添加到复选框
            featureWorkspace = (IFeatureWorkspace)workspace;
            IEnumDatasetName enumDatasetName = workspace.DatasetNames[ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTFeatureDataset];
            enumDatasetName.Reset();
            IDatasetName datasetName = enumDatasetName.Next();
            while (datasetName != null)
            {
                cbDataSet.Items.Add(datasetName.Name.ToString());
                datasetName = enumDatasetName.Next();
            }
        }

        IFeatureDataset featureDataset;//存放要素类的数据集
        private void cbDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            IWorkspace workspace = workspaceFactory.OpenFromFile(DBPathOut, 0);// 通过路径应路径打开数据库
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            String datasetName = cbDataSet.SelectedItem.ToString();
             featureDataset = featureWorkspace.OpenFeatureDataset(datasetName);//通过名称打开相应的数据集
        }

        //确定了数据库和数据集后，向数据集添加要素类
        private void addShp_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseOperator dataBaseOperator1 = new DataBaseOperator();
                String path = dataBaseOperator1.AddShpToSet(featureDataset);
                int start = path.LastIndexOf('\\');//获取shp文件名开始的字符在path中的位置
                tbxAddShp.Text = path.Substring(start + 1);//把shp名称添加到tbxAddShp中
            }
            catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "添加要素类失败: {0} 错误信息: {1}", comExc.ErrorCode,
                    comExc.Message));
            }
        }

        //关闭窗口
        private void btnSure_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
