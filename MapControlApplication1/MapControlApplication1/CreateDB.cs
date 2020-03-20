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
    public partial class CreateDB : Form
    {
        public MainForm cDB;
        public CreateDB(MainForm mf)
        {
            InitializeComponent();
            cDB = mf;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (tbxDBName.Text != "" ) 
            {
                
                cDB.createDB(tbxDBName.Text);
                MessageBox.Show("数据库创建成功！");
                this.Close();
            }
            else MessageBox.Show("请输入名称！");
            
        }


    }
}
