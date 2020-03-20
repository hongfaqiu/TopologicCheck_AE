using ESRI.ArcGIS.Carto;
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
    public partial class DataBoard : Form
    {
        private IMap my_map;

        public DataBoard()
        {
            InitializeComponent();
        }

        public DataBoard(IMap m_map,System.Data.DataTable dataTable )
        {
            InitializeComponent();
            my_map = m_map;
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                lbDataname.Items.Add(m_map.get_Layer(i).Name);
            }
            dataGridView1.DataSource = dataTable;
        }

        private void lbDataname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string layername = lbDataname.SelectedItem.ToString();
            DataOperator dataOperator = new DataOperator(my_map);
            System.Data.DataTable dataTable = dataOperator.GetLayerName(layername);
            
            dataGridView1.DataSource = dataTable;
        }
        
    }
}
