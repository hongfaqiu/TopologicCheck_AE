using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
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
    public partial class FeildStatistic : Form
    {
        IMap m_map;
        public FeildStatistic(IMap map)
        {
            m_map = map;
            InitializeComponent();
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                lbLayerName.Items.Add(m_map.get_Layer(i).Name);
            }
            DataOperator dataOperator = new DataOperator(m_map);
            lbLayerName.Text = m_map.get_Layer(0).Name;
            //定义并根据图层名称获取图层对象
            IFeatureLayer featureLayer = (IFeatureLayer)dataOperator.GetLayerByName(lbLayerName.Text);
            IFeature feature;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            feature = featureCursor.NextFeature();
            lbFeildName.Items.Clear();
            for (int i = 0; i < feature.Fields.FieldCount; i++)
            {
                lbFeildName.Items.Add(feature.Fields.get_Field(i).AliasName);
            }
        }

        private void btStatistic_Click(object sender, EventArgs e)
        {
            MapAnalysis mapAnalysis = new MapAnalysis();
            MessageBox.Show(mapAnalysis.Statistic(lbLayerName.Text, lbFeildName.Text, m_map));
        }
        //选中图层改变后刷新字段列表
        private void lbLayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(m_map);
            IFeatureLayer featureLayer = (IFeatureLayer)dataOperator.GetLayerByName(lbLayerName.Text);
            IFeature feature;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            feature = featureCursor.NextFeature();
            lbFeildName.Items.Clear();
            for (int i = 0; i < feature.Fields.FieldCount; i++)
            {
                lbFeildName.Items.Add(feature.Fields.get_Field(i).AliasName);
            }
        }
    }
}
