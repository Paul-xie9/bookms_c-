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
    public partial class bookChange : Form
    {
        string ID = "";
        public bookChange()
        {
            InitializeComponent();
        }

        public bookChange(string id ,string name,string author,string press,string number)
        {
            InitializeComponent();
            /*传参
             */
            ID = textBoxId.Text = id;
            textBoxName.Text = name;
            textBoxAuthor.Text = author;
            textBoxPress.Text = press;
            textBoxNumber.Text = number;
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string sql = $"update books set id ='{textBoxId.Text}',name ='{textBoxName.Text}',author ='{textBoxAuthor.Text}',press='{textBoxPress.Text}',number = {textBoxNumber.Text} where id ='{ID}'";
            Dao dao = new Dao();
            if(dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功！");
                this.Close();
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

        private void bookChange_Load(object sender, EventArgs e)
        {

        }
    }
}
