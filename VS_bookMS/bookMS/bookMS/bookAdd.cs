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
    public partial class bookAdd : Form
    {
        public bookAdd()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxId.Text != ""&&
            textBoxAuthor.Text != ""&&
            textBoxName.Text != ""&&
            textBoxPress.Text != ""&&
            textBoxNumber.Text != "")
            {
            
                Dao dao = new Dao();
                string sql = $"insert into books values('{textBoxId.Text}','{textBoxName.Text}','{textBoxAuthor.Text}','{textBoxPress.Text}',{textBoxNumber.Text})";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                     MessageBox.Show("添加图书成功！");
                 }
                else 
                 {
                     MessageBox.Show("添加图书失败！");
                 }

                textBoxId.Text = "";
                 textBoxAuthor.Text = "";
                 textBoxName.Text = "";
                textBoxPress.Text = "";
                textBoxNumber.Text = "";
            }
            else
            {
                MessageBox.Show("输入不能为空值，请重新输入！");
            }
           
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxAuthor.Text = "";
            textBoxName.Text = "";
            textBoxPress.Text = "";
            textBoxNumber.Text = "";
        }

        private void addbook_Load(object sender, EventArgs e)
        {

        }
    }
}
