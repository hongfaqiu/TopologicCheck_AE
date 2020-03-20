using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;

namespace MapControlApplication1
{
    class MapAnalysis
    {
        public bool QueryIntersect(string tgLayerName,string srcLayerName, string QueryText1, string QueryText2,IMap iMap,esriSpatialRelationEnum spatialRel)
        {
            if (srcLayerName == null || tgLayerName == null)
            {
                MessageBox.Show("该图层不存在！");
                return false;
            }
            DataOperator dataOperator = new DataOperator(iMap);
            //定义并根据图层名称获取图层对象
            IFeatureLayer iSrcLayer = (IFeatureLayer)dataOperator.GetLayerByName(srcLayerName);
            IFeatureLayer iTgtLayer = (IFeatureLayer)dataOperator.GetLayerByName(tgLayerName);

            //通过查询过滤查询图层1中条件1的几何
            IFeature feature;
            IFeatureCursor featCursor;
            IFeatureClass srcFeatClass;
            IQueryFilter queryFilter = new QueryFilter();
            srcFeatClass = iSrcLayer.FeatureClass;
            queryFilter.WhereClause = QueryText1;//设置查询条件1
            //通过查询过滤获取图层1中满足条件1的几何图形
            try
            {
                featCursor = iTgtLayer.FeatureClass.Search(queryFilter, false);
            }
            catch
            {
                MessageBox.Show("查询条件1出错！");
                return false;
            }

            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.SpatialRel = (ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum)spatialRel;
            spatialFilter.WhereClause = QueryText2;//设置查询条件2
            //定义要素选择对象，并初始化
            IFeatureSelection featSelect = (IFeatureSelection)iSrcLayer;
            featSelect.Clear();
            //获取查询条件1的几何图形
            List<IGeometry> polygonList = new List<IGeometry>();
            while (true)
            {
                feature = featCursor.NextFeature();
                if (feature == null)
                    break;
                polygonList.Add(feature.Shape);
            }

            for (int i = 0; i < polygonList.Count; i++)
            {
                //根据所选择的几何图形对图层2进行属性与空间过滤
                spatialFilter.Geometry = polygonList[i];
                //以空间过滤器对要素进行选择，并添加进选择集
                try
                {
                    featSelect.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                }
                catch
                {
                    MessageBox.Show("查询条件2出错！");
                    return false;
                }
            }
            return true;
        }

        public bool BufferQuery(string tgLayerName, string srcLayerName, string bfLayerName,string QueryText1, string QueryText2, string QueryText3,string size, IMap iMap, esriSpatialRelationEnum spatialRel)
        {

            if (srcLayerName == null || tgLayerName == null||bfLayerName == null)
            {
                MessageBox.Show("有图层不存在！");
                return false;
            }
            double buffersize;
            try
            {
                buffersize = Convert.ToInt32(size);
            }
            catch
            {
                MessageBox.Show("缓冲区大小出错！");
                return false;
            }

            DataOperator dataOperator = new DataOperator(iMap);
            //定义并根据图层名称获取图层对象
            IFeatureLayer iSrcLayer = (IFeatureLayer)dataOperator.GetLayerByName(srcLayerName);
            IFeatureLayer iTgtLayer = (IFeatureLayer)dataOperator.GetLayerByName(tgLayerName);
            IFeatureLayer bfLayer = (IFeatureLayer)dataOperator.GetLayerByName(bfLayerName);

            //通过查询过滤查询图层1中条件1的几何
            IFeature feature;
            IFeatureCursor featCursor;
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.WhereClause = QueryText1;//设置查询条件1
            //通过查询过滤获取图层1中满足条件1的几何图形
            try
            {
                featCursor = iTgtLayer.FeatureClass.Search(queryFilter, false);
                
            }
            catch
            {
                MessageBox.Show("查询条件1出错！");
                return false;
            }

            //通过查询过滤缓冲区查询图层中满足缓冲区条件的几何
            IFeature bffeature;
            IFeatureCursor bffeatCursor;
            IQueryFilter bfqueryFilter = new QueryFilter();
            bfqueryFilter.WhereClause = QueryText3;//设置缓冲区查询条件
            try
            {
                bffeatCursor = bfLayer.FeatureClass.Search(bfqueryFilter, false);
            }
            catch
            {
                MessageBox.Show("缓冲区查询条件出错！");
                return false;
            }

            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.SpatialRel = (ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum)spatialRel;
            spatialFilter.WhereClause = QueryText2;//设置查询条件2
            //定义要素选择对象，并初始化
            IFeatureSelection featSelect = (IFeatureSelection)iSrcLayer;
            featSelect.Clear();

            List<IGeometry> pIntersectList = new List<IGeometry>();
            List<IGeometry> NewPolygonList = new List<IGeometry>();
            while (true)
            {
                feature = featCursor.NextFeature();
                if (feature == null)
                    break;
                pIntersectList.Add(feature.Shape);
            }

            while (true)
            {
                bffeature = bffeatCursor.NextFeature();
                if (bffeature == null)
                    break;
                NewPolygonList.Add(bffeature.Shape);
            }

            for(int i=0;i< pIntersectList.Count;i++)
            {
                for (int j = 0; j < NewPolygonList.Count; j++)
                {
                    //将几何1与buffer后的几何取交集
                    ITopologicalOperator ipTO = (ITopologicalOperator)NewPolygonList[j];

                    ipTO = (ITopologicalOperator)ipTO.Buffer(buffersize);
                    NewPolygonList[j].SpatialReference = pIntersectList[i].SpatialReference;
                    IGeometry outputgeom =ipTO.Intersect(pIntersectList[i], esriGeometryDimension.esriGeometry2Dimension);

                    //根据所选择的几何图形对图层2进行属性与空间过滤
                    spatialFilter.Geometry = outputgeom;
                    //以空间过滤器对要素进行选择，并添加进选择集
                    try
                    {
                        featSelect.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    }
                    catch
                    {
                        MessageBox.Show("查询条件2出错！");
                        return false;
                    }
                }
            }
            return true;
        }
        //以表格形式输出地图中选中的要素数据
        public DataTable QueryData(IMap iMap)
        {
            //获取地图中选中的要素集
            ISelection selection = iMap.FeatureSelection;
            IEnumFeatureSetup iEnumFeatureSetup = (IEnumFeatureSetup)selection;
            iEnumFeatureSetup.AllFields = true;
            IEnumFeature enumFeature = (IEnumFeature)iEnumFeatureSetup;
            enumFeature.Reset();
            IFeature feature = enumFeature.Next();
            if (feature == null)
            {
                return null;
            }

            //新建数据表
            DataTable dataTable = new DataTable();
            //新建数据列，分别保存当前图层的字段名称，并将数据列添加到数据表中
            DataColumn dataColumn0 = new DataColumn();
            dataColumn0.ColumnName = "序号";
            dataTable.Columns.Add(dataColumn0);
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
            int sum = 1;
            while (feature != null)
            {
                dataRow = dataTable.NewRow();
                dataRow[0] = sum;
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
                        dataRow[i+1] = geotype;
                    }
                    else
                        dataRow[i+1] = feature.get_Value(i);
                }
                dataTable.Rows.Add(dataRow);
                feature = enumFeature.Next();
                sum++;
            }
            return dataTable;
        }

        
        public string Statistic(string layerName, string fieldName, IMap iMap)
        {
            DataOperator dataOperator = new DataOperator(iMap);
            //定义并根据图层名称获取图层对象
            IFeatureLayer featLayer = (IFeatureLayer)dataOperator.GetLayerByName(layerName);

            //获取图层的数据统计对象
            IFeatureClass featClass = featLayer.FeatureClass;
            IDataStatistics dataStatistics = new DataStatistics();
            IFeatureCursor featCursor = featClass.Search(null, false);
            ICursor cursor = (ICursor)featCursor;
            dataStatistics.Cursor = cursor;

            //统计字段的最大、最小、平均值
            dataStatistics.Field = fieldName;
            IStatisticsResults statResult;
            statResult = dataStatistics.Statistics;

            double dMax;
            double dMin;
            double dMean;

            dMax = statResult.Maximum;
            dMin = statResult.Minimum;
            dMean = statResult.Mean;

            string sResult;
            sResult = "字段"+fieldName+":最大值为" + dMax.ToString() + ";最小值为" + dMin.ToString() + ";平均值为" + dMean.ToString();
            return sResult;
        }

    }
}
