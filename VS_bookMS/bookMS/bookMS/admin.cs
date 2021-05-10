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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookManager bookmanager = new bookManager();
            bookmanager.ShowDialog();
        }

        private void 图书借阅情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookLend booklend = new bookLend();
            booklend.ShowDialog();
        }

        private void 读者管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userManager userManager = new userManager();
            userManager.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
