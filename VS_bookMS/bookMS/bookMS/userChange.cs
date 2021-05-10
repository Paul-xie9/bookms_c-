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
    public partial class userChange : Form
    {
        string ID = "";
        public userChange()
        {
            InitializeComponent();
        }

        public userChange(string id,string name,string sex,string password)
        {
            InitializeComponent();
            // textBoxId.Text = id;
            //textBoxType.Text = typename;
           ID = textBoxId.Text = id;
            textBoxName.Text = name;
            textBoxSex.Text = sex;
            textBoxPassword.Text = password;
        }

        private void userChange_Load(object sender, EventArgs e)
        {
            
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            //textBoxType.Text = "";
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxSex.Text = "";
            textBoxPassword.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string sql = $"update user set id ='{textBoxId.Text}',name ='{textBoxName.Text}',sex ='{textBoxSex.Text}',password='{textBoxPassword.Text}' where id ='{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改用户成功！");
                this.Close();
            }
        }
    }
}
