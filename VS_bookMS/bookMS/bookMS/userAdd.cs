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
    public partial class userAdd : Form
    {
        public userAdd()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (
                textBoxId.Text != "" &&
           textBoxName.Text != "" &&
           textBoxSex.Text != "" &&
           textBoxPassword.Text != "")
            {

                Dao dao = new Dao();
                string sql = $"insert into user values('{textBoxId.Text}','{textBoxName.Text}','{textBoxSex.Text}','{textBoxPassword.Text}')";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加用户成功！");
                }
                else
                {
                    MessageBox.Show("添加用户失败！");
                }

              //  textBoxType.Text = "";
                textBoxId.Text = "";
                textBoxName.Text = "";
                textBoxSex.Text = "";
                textBoxPassword.Text = "";
            }
            else
            {
                MessageBox.Show("输入不能为空值，请重新输入！");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
           // textBoxType.Text = "";
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxSex.Text = "";
            textBoxPassword.Text = "";
        }

        private void userAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
