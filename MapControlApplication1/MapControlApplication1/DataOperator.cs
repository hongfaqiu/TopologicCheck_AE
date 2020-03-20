using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;

namespace MapControlApplication1
{
    class DataOperator
    {
        public IMap m_map;

        //传入当前地图对象
        public DataOperator(IMap map)
        {
            m_map = map;
        }

        //通过指定图层名从地图对象中返回相应图层
        public ILayer GetLayerByName(string sLayerName)
        {
            //对地图对象中的所有图层进行遍历，若某一图层与指定图层名称相同，则返回该图层
            
            if(sLayerName ==""||m_map ==null)
            {
                return null;
            }

            for (int i=0;i<m_map.LayerCount;i++)
            {
                if (m_map.get_Layer(i).Name == sLayerName)
                    return m_map.get_Layer(i);               
            }
            //否则返回为空
            return null;
        }
        public DataTable GetLayerName(string sLayerName)
        {
            //获取名为sLayerName 的图层，利用IFeatureLayer接口访问，并将图层转换为IFeatureLayer
            //若失败，函数返回为空    
            ILayer layer = GetLayerByName(sLayerName);
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            if(featureLayer == null)
            {
                return null;
            }

            //调用IFeature 接口的Search方法，获取要素指针接口对象
            //用于在之后遍历图层中的所有要素，并判断是否成功获取第一个要素
            //如果失败，函数返回空
            IFeature feature;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            feature = featureCursor.NextFeature();
            if(feature == null)
            {
                return null;
            }

            //新建数据表
            DataTable dataTable = new DataTable();
            //新建数据列，分别保存当前图层的字段名称，并将数据列添加到数据表中

            for (int i = 0; i < feature.Fields.FieldCount; i++)
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = feature.Fields.get_Field(i).AliasName;
                dataTable.Columns.Add(dataColumn);
            }

            //将要素在每个字段上的列属性赋值给DataRow的对应列中
            //为区分string类型的几何信息，使用feature.Shape.GeometryType获取几何类型字段的几何信息
            //使用case语句进行赋值，其它非几何类型字段则使用feature.get_Value方法读取该字段的值
            //将获取到的属性信息添加到表中
            DataRow dataRow;
            while(feature != null)
            {
                dataRow = dataTable.NewRow();               
                for (int i = 0; i < feature.Fields.FieldCount; i++)
                {
                    if (feature.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                {
                    string geotype;
                    switch (feature.Shape.GeometryType)
                    {
                        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                            geotype = "point";
                            break;
                        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                            geotype = "line";
                            break;
                        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                            geotype = "polygon";
                            break;
                        default:
                            geotype = "unknowkn";
                            break;

                    }
                    dataRow[i] = geotype;
                }
                else
                    dataRow[i] = feature.get_Value(i);
                }
                dataTable.Rows.Add(dataRow);
                feature = featureCursor.NextFeature();
            }

            return dataTable;
        }

        public IFeatureClass CreateShapefile(string sParentDirectory,string sWorkspaceName,string sFileName, esriGeometryType pGeometryType)
        {
            //如果指定的路径和文件夹已经存在，则删除此文件夹。
            if (System.IO.Directory.Exists(sParentDirectory+sWorkspaceName))
                System.IO.Directory.Delete(sParentDirectory + sWorkspaceName, true);
            
            //创建一个输出shp文件的工作空间
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspaceName pInWorkspaceName = workspaceFactory.Create(sParentDirectory, sFileName, null, 0);
            ESRI.ArcGIS.esriSystem.IName name = pInWorkspaceName as ESRI.ArcGIS.esriSystem.IName;

            //打开新建的工作空间
            IWorkspace workspace = (IWorkspace)name.Open();
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            //shape文件在概念层次上是一个要素类。创建并编辑该要素类所需的字段集。
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;

            //创建并编辑序号字段
            IFieldEdit fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "OID";
            fieldEdit.AliasName_2 = "序号";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建并编辑名称字段
            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "Name";
            fieldEdit.AliasName_2 = "名称";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建地理定义，设置其空间参考和几何类型，为创建“形状”字段做准备
            IGeometryDefEdit geoDefEdit = new GeometryDefClass();
            ISpatialReference spatialReference = m_map.SpatialReference;
            geoDefEdit.SpatialReference_2 = spatialReference;
            geoDefEdit.GeometryType_2 = pGeometryType;

            //创建并编辑形状字段
            fieldEdit = new FieldClass();
            string sShapefileName = "Shape";
            fieldEdit.Name_2 = sShapefileName;
            fieldEdit.AliasName_2 = "形状";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geoDefEdit;
            fieldsEdit.AddField((IField)fieldEdit);

            //调用IfeatureWorkspace接口的CreateFeatureClass方法，创建要素类，并判断是否创建成功
            IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(sFileName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            if (featureClass == null)
                return null;

            return featureClass;
        }

        public bool AddFeatureClassToMap(IFeatureClass featureClass,String sLayerName,IMap map)
        {
            //判断要素类、图层名和地图对象是否为空。如为空，则函数返回false
            if (featureClass == null || sLayerName == "")
                return false;

            //通过IFeaturelayer接口创建要素图层对象，将要素类以层的形式进行操作。
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = sLayerName;

            //将要素图层转换为一般图层，并判断是否成功。若失败，函数返回false.
            ILayer layer = featureLayer as ILayer;
            if (layer == null)
                return false;

            //将创建好的图层添加至地图对象，将地图对象转化为活动视图，并判断是否成功。
            //若失败，函数返回false.
            map.AddLayer(layer);
            IActiveView activeView = m_map as IActiveView;
            if (activeView == null)
                return false;

            //活动视图进行刷新，新添加的图层将被展示在控件中。函数返回true. 
            activeView.Refresh();
            return true;
        }

    //新增要素
    public bool AddFeatureToLayer(IFeatureClass featureClass, string sFeatureName, IGeometry geometry)
        {
            //判断要素类、要素名称、要素和地图对象是否为空，若为空，函数返回false
            if (featureClass == null || sFeatureName == "" || geometry == null||m_map==null)
                return false;
            //通过IFeature接口访问要素类新创建的要素，并判断是否获取成功，若失败，返回false
            IFeature feature = featureClass.CreateFeature();
            if (feature == null)
                return false;
            //对新创建的要素进行编辑，将其坐标、属性值进行设置。最后保存该要素
            //并判断是否成功，若失败，返回false.
            feature.Shape = geometry;
            int index = feature.Fields.FindField("Name");
            feature.set_Value(index, sFeatureName);           
            feature.Store();
            if (feature == null)
                return false;
            //将地图对象转化为活动视图，并判断是否成功，若失败，返回false。
            IActiveView activeView = m_map as IActiveView;
            if (activeView == null)
                return false;
            //活动视图进行刷新，新添加的要素展示在控件中，函数返回true。
            activeView.Refresh();
            return true;
        }
    }
}
