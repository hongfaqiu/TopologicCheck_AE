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
    public partial class CreatFeatureClass : Form
    {
        public CreatFeatureClass()
        {
            InitializeComponent();
            lbFeatureType.Items.Add("Point");
            lbFeatureType.Items.Add("Line");
            lbFeatureType.Items.Add("Ploygon");

        }
        
    }
}
