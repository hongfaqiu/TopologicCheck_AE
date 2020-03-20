using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MapControlApplication1
{
    class DataBaseOperator
    {

         //在指定位置创建数据库，位置在函数中指定
        public IWorkspace CreateAccessWorkspace(String databasename)
        {
            //选择数据库存储的位置
            String path = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择所要创建数据库的位置";
            folderBrowserDialog.ShowNewFolderButton = false;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                path = folderBrowserDialog.SelectedPath;
            Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance(factoryType);
            IWorkspaceName workspaceName = workspaceFactory.Create(path, databasename+".mdb", null, 0);

            IName name = (IName)workspaceName;
            IWorkspace workspace = (IWorkspace)name.Open();
            return workspace;
        }

        //在指定IWorkspace中创建数据集 ，返回创建的数据集
        public IFeatureDataset CreateFeatureDataset(IWorkspace workspace,
                                                     string fdsName, ISpatialReference fdsSR)
        {
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            return featureWorkspace.CreateFeatureDataset(fdsName, fdsSR);
        }
        //向指定数据集中添加要素类
        public void AddFeatureClassToSet(IFeatureDataset ds,IFeatureClass featureClass,string name)
        {
            Geoprocessor GP_Tool = new Geoprocessor();
            //实现添加的函数
            try
            {
                FeatureClassToFeatureClass Temp_FCToFC = new FeatureClassToFeatureClass(featureClass, ds, name);
                GP_Tool.Execute(Temp_FCToFC, null);
                MessageBox.Show("要素集添加成功！");
            }
            catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "要素集添加失败: {0} 错误信息: {1}", comExc.ErrorCode,
                    comExc.Message));
            }
        }

        //向指定数据集中添加shp 其中shp位置在函数中指定
        public void AddFeatureClassToSet( IFeatureDataset ds)
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

            IFeatureDataset FDS_Featuredataset = ds;//目标featuredataset

            Geoprocessor GP_Tool = new Geoprocessor();
            string Temp_Direction = System.IO.Path.GetDirectoryName(IN_ShapePath);//该Shp文件的目录
            FileInfo fi = new FileInfo(IN_ShapePath);
            string Temp_Name = fi.Name; // 该shp的文件名
            String Temp_Name2 = System.IO.Path.GetFileNameWithoutExtension(IN_ShapePath);//无扩展名的shp名称

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();

            IWorkspace workspace = workspaceFactory.OpenFromFile(Temp_Direction, 0);//打开存储shapefile的文件夹
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            IFeatureClass feature = featureWorkspace.OpenFeatureClass(Temp_Name);//通过名称打开featureclass，名字需要完整

            //实现添加的函数
           try
            {
                FeatureClassToFeatureClass Temp_FCToFC = new FeatureClassToFeatureClass(feature, FDS_Featuredataset, Temp_Name2);
                GP_Tool.Execute(Temp_FCToFC, null);
                MessageBox.Show("要素集添加成功！");
            }
           catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "要素集添加失败: {0} 错误信息: {1}", comExc.ErrorCode,
                    comExc.Message));
            }
        }

        //向指定数据集中添加shp 其中shp位置在函数中指定
        //同时返回shp的路径字符串。
        //该函数与public void AddFeatureClassToSet( IFeatureDataset ds)结果类似，返回值不同
        public String AddShpToSet(IFeatureDataset ds)
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

            IFeatureDataset FDS_Featuredataset = ds;//目标featuredataset

            Geoprocessor GP_Tool = new Geoprocessor();
            string Temp_Direction = System.IO.Path.GetDirectoryName(IN_ShapePath);//该Shp文件的目录
            FileInfo fi = new FileInfo(IN_ShapePath);
            string Temp_Name = fi.Name; // 该shp的文件名
            String Temp_Name2 = System.IO.Path.GetFileNameWithoutExtension(IN_ShapePath);//无扩展名的shp名称

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();

            IWorkspace workspace = workspaceFactory.OpenFromFile(Temp_Direction, 0);//打开存储shapefile的文件夹
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            IFeatureClass feature = featureWorkspace.OpenFeatureClass(Temp_Name);//通过名称打开featureclass，名字需要完整

            //实现添加的函数
            try
            {
                FeatureClassToFeatureClass Temp_FCToFC = new FeatureClassToFeatureClass(feature, FDS_Featuredataset, Temp_Name2);
                GP_Tool.Execute(Temp_FCToFC, null);
                MessageBox.Show("要素集添加成功！");
                return openFileDialog.FileName;
            }
            catch (COMException comExc)
            {
                MessageBox.Show(String.Format(
                    "要素集添加失败: {0} 错误信息: {1}", comExc.ErrorCode,
                    comExc.Message));
                return null;
            }
        }
        //打开一个个人数据库，返回IFeatureWorkspace ，用于打开数据集等操作
        public IFeatureWorkspace GetFeatureWorkspaceByChoosePath()
        {
            IFeatureWorkspace featureWorkspace;
            String DBPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C://";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "选择需要打开数据库的位置";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                DBPath = openFileDialog.FileName;
         

            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            try
            {
                IWorkspace workspace = workspaceFactory.OpenFromFile(DBPath, 0);// 通过路径应路径打开数据库
                featureWorkspace = (IFeatureWorkspace)workspace;
                return featureWorkspace;
            }
            catch
            {
                return null;
            }
             
        }
        //从路径打开个人数据库
        public IFeatureWorkspace GetFeatureWorkspaceByPath(string DBPath)
        {
            IFeatureWorkspace featureWorkspace;
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            IWorkspace workspace = workspaceFactory.OpenFromFile(
                                                                   DBPath, 0);// 通过路径应路径打开数据库
            featureWorkspace = (IFeatureWorkspace)workspace;
            return featureWorkspace;
        }

        //通过IFeatureWorkspace获得数据集名称
        public IEnumDatasetName getIEnumDatasetNameByWorkspace(IFeatureWorkspace featureWorkspace)
        {
            IWorkspace workspace = (IWorkspace)featureWorkspace;

            IEnumDatasetName enumDatasetName = workspace.DatasetNames[ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTFeatureDataset];
            enumDatasetName.Reset();
           
            return enumDatasetName;
        }
    }
}
