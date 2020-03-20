using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapControlApplication1
{
    public partial class CreateFeature : Form
    {
        IMap m_map;
        IFeatureClass featureClass;
        IGeometry geometry;
        //传入参数,并初始化要素类型为当前图层要素类型，
        //默认初始化要素名称为“当前要素类型+第几个要素”
        public CreateFeature(IMap map,IFeatureClass featureClass1, IGeometry geometry1)
        {
            m_map = map;
            featureClass = featureClass1;
            geometry = geometry1;
            InitializeComponent();
            switch (featureClass.ShapeType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                    tbFeatureType.Text = "点";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    tbFeatureType.Text = "线";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    tbFeatureType.Text = "面";
                    break;
                default:
                    tbFeatureType.Text = featureClass.ShapeType.ToString();
                    break;
            }
            tbFeatureName.Text = tbFeatureType.Text+Convert.ToString(featureClass.FeatureCount(null)+1);
        }

        //在选中的图层中添加要素，自定义要素的名称。
        private void btCreateFeature_Click(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(m_map);
            string sFeatureName;
            sFeatureName = tbFeatureName.Text;
            dataOperator.AddFeatureToLayer(featureClass, sFeatureName, geometry);
            this.Close();
        }
    }
}
