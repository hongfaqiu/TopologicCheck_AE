using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapControlApplication1
{
    public partial class CreateDS : Form
    {
        public MainForm cDS;
        public CreateDS(MainForm mf)
        {
            InitializeComponent();
            cDS = mf;
        }

        ISpatialReference spaRef;//数据集的空间参考
        IWorkspace workspace;
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (tbxDSName.Text != "" && tbxSelectDB.Text != "" && tbxSpaRef.Text != "")
            {
                cDS.AddDataSet(tbxDSName.Text, spaRef, workspace, true);
                MessageBox.Show("在数据库" + tbxSelectDB.Text + "中创建数据集成功！" + '\n' + "空间参考系为：" + tbxSpaRef.Text);
                this.Close();
            }
            else if (tbxDSName.Text != "" && tbxSelectDB.Text != "" && tbxSpaRef.Text == "")
            {
                cDS.AddDataSet(tbxDSName.Text, spaRef, workspace, false);
                MessageBox.Show("在数据库" + tbxSelectDB.Text + "中创建数据集成功！" + '\n' + "空间参考系为当前地图空间参考系");
                this.Close();
            }
            else if (tbxDSName.Text == "")
                MessageBox.Show("请输入数据集名称！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            else if (tbxSelectDB.Text == "")
                MessageBox.Show("请选择数据库！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        //设置空间参考系
        private void btnSetSpaRef_Click(object sender, EventArgs e)
        {
            //选择要加入数据集的要素
            String IN_ShapePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog(); //选择需要添加的要素的位置
            openFileDialog.Title = "选择要加入数据集的数据";
            openFileDialog.InitialDirectory = "C://";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                IN_ShapePath = openFileDialog.FileName;

            //IFeatureDataset FDS_Featuredataset = ds;//目标featuredataset

            Geoprocessor GP_Tool = new Geoprocessor();
            string Temp_Direction = System.IO.Path.GetDirectoryName(IN_ShapePath);//该Shp文件的目录
            FileInfo fi = new FileInfo(IN_ShapePath);
            string Temp_Name = fi.Name; // 该shp的文件名
            String Temp_Name2 = System.IO.Path.GetFileNameWithoutExtension(IN_ShapePath);//无扩展名的shp名称

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();

            IWorkspace workspace = workspaceFactory.OpenFromFile(Temp_Direction, 0);//打开存储shapefile的文件夹
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            IFeatureClass feature = featureWorkspace.OpenFeatureClass(Temp_Name);

            spaRef = (feature as IGeoDataset).SpatialReference;
            tbxSpaRef.Text = spaRef.Name;
        }

        //选择存放数据集的数据库
        private void btnSelectDB_Click(object sender, EventArgs e)
        {
            DataBaseOperator dataBaseOperator = new DataBaseOperator();
           
            String DBPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C://";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "选择需要打开数据库的位置";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            { 
                DBPath = openFileDialog.FileName;
                int start = DBPath.LastIndexOf('\\');//获取数据库名称开始的字符在DBPath中的位置
                tbxSelectDB.Text = DBPath.Substring(start+1);//把数据库名称添加到tbxSelectDB中
            }               
         
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);

            workspace = workspaceFactory.OpenFromFile(DBPath, 0);// 通过路径应路径打开数据库
                                            
        }
    }
}
