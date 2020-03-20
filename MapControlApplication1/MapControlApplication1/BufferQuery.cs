using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
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
    public partial class BufferQuery : Form
    {
        IMap m_map;
        AxMapControl axMapControl;
        public BufferQuery(AxMapControl axMapControl1)
        {
            m_map = axMapControl1.Map;
            axMapControl = axMapControl1;
            InitializeComponent();
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                lbQueryName1.Items.Add(m_map.get_Layer(i).Name);
                lbQueryName2.Items.Add(m_map.get_Layer(i).Name);
                lbQueryName3.Items.Add(m_map.get_Layer(i).Name);
            }
            lbQueryName1.Text = "Continents";
            lbQueryName2.Text = "World Cities";
            lbQueryName3.Text = "World Cities";
            tbQueryText1.Text = "CONTINENT='Asia'";
            tbQueryText2.Text = "POP_RANK=5";
            tbBufferText.Text = "CITY_NAME='Istanbul'";
            tbBufferSize.Text = "1";
        }
        private void btBufferQuery_Click(object sender, EventArgs e)
        {
            //缓冲区查询结果在地图上显示
            MapAnalysis mapAnalysis = new MapAnalysis();
            mapAnalysis.BufferQuery(lbQueryName1.Text, lbQueryName2.Text, lbQueryName3.Text, tbQueryText1.Text, tbQueryText2.Text, tbBufferText.Text, tbBufferSize.Text, axMapControl.Map, esriSpatialRelationEnum.esriSpatialRelationIntersection);
            IActiveView activeView;
            activeView = axMapControl.ActiveView;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, 0, axMapControl.Extent);
            System.Data.DataTable dataTable = mapAnalysis.QueryData(m_map);
            dataGridView1.DataSource = dataTable;
        }
    }
}
