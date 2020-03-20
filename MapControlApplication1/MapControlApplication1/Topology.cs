using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapControlApplication1
{
    class Topology
    {
        
        //功能：添加拓扑规则————单个图层
        //参数： 要添加规则的topology
        //      要添加的规则和规则名称
        //      相应图层
        public void AddRuleToTopology(ITopology topology, esriTopologyRuleType ruleType,
                                       String ruleName, IFeatureClass featureClass0)
        {
            // Create a topology rule.
            ITopologyRule topologyRule = new TopologyRuleClass();
            topologyRule.TopologyRuleType = ruleType;
            topologyRule.Name = ruleName;
            topologyRule.OriginClassID = featureClass0.FeatureClassID;
            topologyRule.AllOriginSubtypes = true;

            // Cast the topology to the ITopologyRuleContainer interface and add the rule.
            ITopologyRuleContainer topologyRuleContainer = (ITopologyRuleContainer)topology;
            if (topologyRuleContainer.get_CanAddRule(topologyRule))
            {
                topologyRuleContainer.AddRule(topologyRule);
            }
            else
            {
                MessageBox.Show("不能添加特殊规则！");
                return;
            }
        }

        //添加拓扑规则——两个图层
        public void AddRuleToTopology(ITopology topology, esriTopologyRuleType ruleType,
                                       String ruleName, IFeatureClass originClass, int originSubtype, IFeatureClass
                                        destinationClass, int destinationSubtype)
        {
            // Create a topology rule.
            ITopologyRule topologyRule = new TopologyRuleClass();
            topologyRule.TopologyRuleType = ruleType;
            topologyRule.Name = ruleName;
            topologyRule.OriginClassID = originClass.FeatureClassID;
            topologyRule.AllOriginSubtypes = false;
            topologyRule.OriginSubtype = originSubtype;
            topologyRule.DestinationClassID = destinationClass.FeatureClassID;
            topologyRule.AllDestinationSubtypes = false;
            topologyRule.DestinationSubtype = destinationSubtype;

            // Cast the topology to the ITopologyRuleContainer interface and add the rule.
            ITopologyRuleContainer topologyRuleContainer = (ITopologyRuleContainer)topology;
            if (topologyRuleContainer.get_CanAddRule(topologyRule))
            {
                topologyRuleContainer.AddRule(topologyRule);
            }
            else
            {
                MessageBox.Show("不能添加特殊规则！");
                return;
            }
        }

        public void ValidateTopology(ITopology topology, IEnvelope envelope)
        {
            // Get the dirty area within the provided envelope.
            IPolygon locationPolygon = new PolygonClass();
            ISegmentCollection segmentCollection = (ISegmentCollection)locationPolygon;
            segmentCollection.SetRectangle(envelope);
            IPolygon polygon = topology.get_DirtyArea(locationPolygon);

            // If a dirty area exists, validate the topology.
            if (!polygon.IsEmpty)
            {
                // Define the area to validate and validate the topology.
                IEnvelope areaToValidate = polygon.Envelope;
                IEnvelope areaValidated = topology.ValidateTopology(areaToValidate);
            }
        }
        //打开拓扑
        public ITopology OpenTopologyFromFeatureWorkspace(IFeatureWorkspace featureWorkspace,
            String featureDatasetName, String topologyName)
        {
            //打开数据集
            IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(featureDatasetName);
            //获取拓扑容器
            ITopologyContainer topologyContainer = (ITopologyContainer)featureDataset;
            //打开拓扑
            ITopology topology = topologyContainer.get_TopologyByName(topologyName);
            return topology;
        }

        //显示拓扑规则
        public void DisplayTypesForEachRule(ITopology topology)
        {
            ITopologyRuleContainer topologyRuleContainer = (ITopologyRuleContainer)topology;
            IEnumRule enumRule = topologyRuleContainer.Rules;
            // 遍历拓扑规则.    
            enumRule.Reset();
            IRule rule = null;
            while ((rule = enumRule.Next()) != null)
            {
                ITopologyRule topologyRule = (ITopologyRule)rule;
                Console.WriteLine("Rule type: {0}", topologyRule.TopologyRuleType);
            }
        }

        //给定拓扑和拓扑规则类型，返回指定规则的错误要素信息
        public DataTable DisplayErrorFeatureByRuleType(ITopology topology, esriTopologyRuleType ruleType,IEnvelope searchExtent)
        {
            //获取坐标系
            IErrorFeatureContainer errorFeatureContainer = (IErrorFeatureContainer)topology;
            IGeoDataset geoDataset = (IGeoDataset)topology;
            ISpatialReference spatialReference = geoDataset.SpatialReference;
            ITopologyRuleContainer topologyRuleContainer = (ITopologyRuleContainer)topology;

            //遍历拓扑规则
            IEnumRule enumRule = topologyRuleContainer.Rules;
            enumRule.Reset();
            IRule rule = null;
            DataRow dataRow;
            int i = 1;
            DataTable dataTable = new DataTable();
            DataColumn dataColunm = new DataColumn();
            dataColunm.ColumnName = "序号";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "错误ID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "规则类型";
            dataColunm.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "形状";
            dataColunm.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "原要素集ID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "原OID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "目标要素集ID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "目标OID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            while ((rule = enumRule.Next()) != null)
            {
                //获取当前拓扑规则的拓扑错误并遍历
                ITopologyRule topologyRule = (ITopologyRule)rule;
                IEnumTopologyErrorFeature enumTopologyErrorFeature = errorFeatureContainer.get_ErrorFeatures(spatialReference, topologyRule, searchExtent, true, true);

                ITopologyErrorFeature topologyErrorFeature = null;
                while ((topologyErrorFeature = enumTopologyErrorFeature.Next()) != null&&
                    topologyErrorFeature.TopologyRuleType==ruleType)
                {
                    dataRow = dataTable.NewRow();
                    dataRow[0] = i++;
                    dataRow[1] = topologyErrorFeature.ErrorID;
                    dataRow[2] = topologyErrorFeature.TopologyRuleType;
                    dataRow[3] = topologyErrorFeature.ShapeType;
                    dataRow[4] = topologyErrorFeature.OriginClassID;
                    dataRow[5] = topologyErrorFeature.OriginOID;
                    dataRow[6] = topologyErrorFeature.DestinationClassID;
                    dataRow[7] = topologyErrorFeature.DestinationOID;
                    dataTable.Rows.Add(dataRow);
                }
            }
            return dataTable;
        }

        //显示所有错误要素
        public DataTable DisplayAllErrorFeatures(ITopology topology, IEnvelope searchExtent)
        {
            //获取坐标系
            IErrorFeatureContainer errorFeatureContainer = (IErrorFeatureContainer)topology;
            IGeoDataset geoDataset = (IGeoDataset)topology;
            ISpatialReference spatialReference = geoDataset.SpatialReference;
            ITopologyRuleContainer topologyRuleContainer = (ITopologyRuleContainer)topology;

            //遍历拓扑规则
            IEnumRule enumRule = topologyRuleContainer.Rules;
            enumRule.Reset();
            IRule rule = null;
            DataRow dataRow;
            int i = 1;
            DataTable dataTable = new DataTable();
            DataColumn dataColunm = new DataColumn();
            dataColunm.ColumnName = "序号";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "错误ID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName =  "规则类型";
            dataColunm.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName =  "形状";
            dataColunm.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "原要素集ID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName =  "原OID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "目标要素集ID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            dataColunm = new DataColumn();
            dataColunm.ColumnName = "目标OID";
            dataColunm.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColunm);
            while ((rule = enumRule.Next()) != null)
            {
                //获取当前拓扑规则的拓扑错误并遍历
                ITopologyRule topologyRule = (ITopologyRule)rule;
                IEnumTopologyErrorFeature enumTopologyErrorFeature = errorFeatureContainer.get_ErrorFeatures(spatialReference, topologyRule, searchExtent, true, true);

                ITopologyErrorFeature topologyErrorFeature = null;
                while ((topologyErrorFeature = enumTopologyErrorFeature.Next()) != null)
                {
                    dataRow = dataTable.NewRow();
                    dataRow[0] = i++;
                    dataRow[1] = topologyErrorFeature.ErrorID;
                    dataRow[2] = topologyErrorFeature.TopologyRuleType;
                    dataRow[3] = topologyErrorFeature.ShapeType;
                    dataRow[4] = topologyErrorFeature.OriginClassID;
                    dataRow[5] = topologyErrorFeature.OriginOID;
                    dataRow[6] = topologyErrorFeature.DestinationClassID;
                    dataRow[7] = topologyErrorFeature.DestinationOID;
                    dataTable.Rows.Add(dataRow);
                }
            }
            return dataTable;
        }
        //返回指定错误序号的错误要素
        public IFeature GetErrorFeatureByID(ITopology topology, int errorID)
        {
            IFeature feature=null;
            //获取坐标系
            IErrorFeatureContainer errorFeatureContainer = (IErrorFeatureContainer)topology;
            IGeoDataset geoDataset = (IGeoDataset)topology;
            ISpatialReference spatialReference = geoDataset.SpatialReference;
            ITopologyRuleContainer topologyRuleContainer = (ITopologyRuleContainer)topology;

            //遍历拓扑规则
            IEnumRule enumRule = topologyRuleContainer.Rules;
            enumRule.Reset();
            IRule rule = null;
            while ((rule = enumRule.Next()) != null)
            {
                //获取当前拓扑规则的拓扑错误并遍历
                ITopologyRule topologyRule = (ITopologyRule)rule;
                IEnumTopologyErrorFeature enumTopologyErrorFeature = errorFeatureContainer.get_ErrorFeatures(spatialReference, topologyRule, geoDataset.Extent, true, true);

                ITopologyErrorFeature topologyErrorFeature = null;
                while ((topologyErrorFeature = enumTopologyErrorFeature.Next()) != null)
                {
                    if (topologyErrorFeature.ErrorID == errorID)
                    {
                        feature = (IFeature)topologyErrorFeature;
                        break;
                    }
                }
            }
            return feature;
        }

        //提取指定错误类型的拓扑错误并导出为要素类
        public IFeatureClass PRV_GetErrorFeature(ITopology TP_MainTopology, IFeatureDataset FDS_MainFeatureDataset, ITopologyRule IN_TopologyRule)
        {
            IFeatureClass featureClass = null; 
            IEnvelope Temp_Envolope = (TP_MainTopology as IGeoDataset).Extent;
            IErrorFeatureContainer Temp_ErrorContainer = TP_MainTopology as IErrorFeatureContainer;
            //获取该种错误所有的错误要素  
            IEnumTopologyErrorFeature Temp_EnumErrorFeature = Temp_ErrorContainer.get_ErrorFeatures(((IGeoDataset)FDS_MainFeatureDataset).SpatialReference, IN_TopologyRule, Temp_Envolope, true, true);
            //提取一个错误要素  
            ITopologyErrorFeature Temp_ErrorFeature = Temp_EnumErrorFeature.Next();
            if (Temp_ErrorFeature != null)
            {
                //作为搭建模型的要素  
                IFeature Temp_MoudleFeature = Temp_ErrorFeature as IFeature;
                //生成要素类需要CLSID和EXCLSID  
                IFeatureClassDescription Temp_FeatureClassDescription = new FeatureClassDescriptionClass();
                IObjectClassDescription Temp_ObjectClassDescription = (IObjectClassDescription)Temp_FeatureClassDescription;
                //以模型要素为模板构建一个要素类  
                FDS_MainFeatureDataset.CreateFeatureClass(IN_TopologyRule.ToString(), Temp_MoudleFeature.Fields, Temp_ObjectClassDescription.InstanceCLSID, Temp_ObjectClassDescription.ClassExtensionCLSID, Temp_MoudleFeature.FeatureType, "Shape", "");
                //打开生成的目标要素类并加入集合留待输出时使用  
                IFeatureClass Temp_TargetFeatureClass = (FDS_MainFeatureDataset.Workspace as IFeatureWorkspace).OpenFeatureClass(IN_TopologyRule.ToString());
                featureClass=Temp_TargetFeatureClass;
                //将所有错误要素添加进目标要素类  
                IWorkspaceEdit Temp_WorkspaceEdit = (IWorkspaceEdit)FDS_MainFeatureDataset.Workspace;
                Temp_WorkspaceEdit.StartEditing(true);
                Temp_WorkspaceEdit.StartEditOperation();
                IFeatureBuffer Temp_FeatureBuffer = Temp_TargetFeatureClass.CreateFeatureBuffer();
                //在目标要素类中插入所有错误要素  
                IFeatureCursor featureCursor = Temp_TargetFeatureClass.Insert(true); ;
                while (Temp_ErrorFeature != null)
                {
                    IFeature Temp_Feature = Temp_ErrorFeature as IFeature;
                    //给目标要素附属性  
                    Temp_FeatureBuffer.set_Value(1, Temp_ErrorFeature.OriginClassID);
                    Temp_FeatureBuffer.set_Value(2, Temp_ErrorFeature.OriginOID);
                    Temp_FeatureBuffer.set_Value(5, Temp_ErrorFeature.TopologyRuleType);
                    Temp_FeatureBuffer.Shape = Temp_Feature.Shape;
                    object featureOID = featureCursor.InsertFeature(Temp_FeatureBuffer);
                    featureCursor.Flush();//保存要素  
                    Temp_ErrorFeature = Temp_EnumErrorFeature.Next();
                }
                Temp_WorkspaceEdit.StopEditOperation();
                Temp_WorkspaceEdit.StopEditing(true);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
            }
            return featureClass;
        }

        //提取指定几何类型的拓扑错误并导出为要素类
        public IFeatureClass PRV_GetErrorFeature(ITopology TP_MainTopology, IFeatureDataset FDS_MainFeatureDataset,esriGeometryType esriGeometryType)
        {
            IFeatureClass featureClass=null;
            IEnvelope Temp_Envolope = (TP_MainTopology as IGeoDataset).Extent;
            IErrorFeatureContainer Temp_ErrorContainer = TP_MainTopology as IErrorFeatureContainer;
            //获取该种错误所有的错误要素  
            //获取当前几何类型的拓扑错误并遍历
            IEnumTopologyErrorFeature Temp_EnumErrorFeature = Temp_ErrorContainer.ErrorFeaturesByGeometryType[((IGeoDataset)FDS_MainFeatureDataset).SpatialReference, esriGeometryType, true];
            //提取一个错误要素  
            ITopologyErrorFeature Temp_ErrorFeature = Temp_EnumErrorFeature.Next();
                if (Temp_ErrorFeature != null)
                {
                    //作为搭建模型的要素  
                    IFeature Temp_MoudleFeature = Temp_ErrorFeature as IFeature;
                    //生成要素类需要CLSID和EXCLSID  
                    IFeatureClassDescription Temp_FeatureClassDescription = new FeatureClassDescriptionClass();
                    IObjectClassDescription Temp_ObjectClassDescription = (IObjectClassDescription)Temp_FeatureClassDescription;
                    //以模型要素为模板构建一个要素类  
                    FDS_MainFeatureDataset.CreateFeatureClass(esriGeometryType.ToString(), Temp_MoudleFeature.Fields, Temp_ObjectClassDescription.InstanceCLSID, Temp_ObjectClassDescription.ClassExtensionCLSID, Temp_MoudleFeature.FeatureType, "Shape", "");
                    //打开生成的目标要素类并加入集合留待输出时使用  
                    IFeatureClass Temp_TargetFeatureClass = (FDS_MainFeatureDataset.Workspace as IFeatureWorkspace).OpenFeatureClass(esriGeometryType.ToString());
                    featureClass = Temp_TargetFeatureClass;
                    //将所有错误要素添加进目标要素类  
                    IWorkspaceEdit Temp_WorkspaceEdit = (IWorkspaceEdit)FDS_MainFeatureDataset.Workspace;
                    Temp_WorkspaceEdit.StartEditing(true);
                    Temp_WorkspaceEdit.StartEditOperation();
                    IFeatureBuffer Temp_FeatureBuffer = Temp_TargetFeatureClass.CreateFeatureBuffer();
                    //在目标要素类中插入所有错误要素  
                    IFeatureCursor featureCursor = Temp_TargetFeatureClass.Insert(true); ;
                    while (Temp_ErrorFeature != null)
                    {
                        IFeature Temp_Feature = Temp_ErrorFeature as IFeature;
                        //给目标要素附属性  
                        Temp_FeatureBuffer.set_Value(1, Temp_ErrorFeature.OriginClassID);
                        Temp_FeatureBuffer.set_Value(2, Temp_ErrorFeature.OriginOID);
                        Temp_FeatureBuffer.set_Value(5, Temp_ErrorFeature.TopologyRuleType);
                        Temp_FeatureBuffer.Shape = Temp_Feature.Shape;
                        object featureOID = featureCursor.InsertFeature(Temp_FeatureBuffer);
                        featureCursor.Flush();//保存要素  
                    Temp_ErrorFeature = Temp_EnumErrorFeature.Next();
                    }
                    Temp_WorkspaceEdit.StopEditOperation();
                    Temp_WorkspaceEdit.StopEditing(true);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
                }
            return featureClass;
        }

    }
}
