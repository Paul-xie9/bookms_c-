using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bookMS
{
    public partial class userMain : Form
    {
        public userMain()
        {
            InitializeComponent();
          //  label2.Text = $"{Data.UName}";
        }

        private void 当前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userReturn userlend = new userReturn();
            userlend.ShowDialog();
        }

        private void 图书查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userLend user = new userLend();
            user.ShowDialog();
        }

        private void userMain_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
