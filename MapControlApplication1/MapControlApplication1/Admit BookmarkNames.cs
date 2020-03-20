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
    
    public partial class AdmitBookmarkNames : Form
    {
        public MainForm m_frmMain;

        public AdmitBookmarkNames(MainForm frm)
        {
            InitializeComponent();
            m_frmMain = frm;           
        }

        private void btnButton1_Click(object sender, EventArgs e)
        {
            if (m_frmMain != null && tbBookMarkName.Text != "")
            {
                m_frmMain.CreatBookmark(tbBookMarkName.Text);
            }
            this.Close();
        }
    }
}
