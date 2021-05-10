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
    public partial class userLend : Form
    {
        public userLend()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userlend_Load(object sender, EventArgs e)
        {
            Table();
        }


        #region 从数据库读取全部数据并放到表格中
        public void Table()
        {
            dataGridView1.Rows.Clear(); //清空一行中的旧数据
            Dao dao = new Dao();
            string sql = $"select *from books";
            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }

        #endregion


        #region 书名查询方法构造 模糊查询
        public void TableName()
        {
            dataGridView1.Rows.Clear(); //清空一行中的旧数据
            Dao dao = new Dao();
            string sql = $"select *from books where name like '%{inquirebookname.Text}%'";
            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
        #endregion


        #region 书号查询 模糊查询
        public void TableID()
        {
            dataGridView1.Rows.Clear(); //清空一行中的旧数据
            Dao dao = new Dao();
            string sql = $"select *from books where id like '%{inquirebookid.Text}%'";
            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
        #endregion


        #region 借书操作
        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取书号
            string bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //获取书名
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());    //获取库存
            if(number < 1)
            {
                MessageBox.Show("库存不足，请重新选择！");
            }
            else
            {
                string sql = $"insert into lend (uid,bid,datetime) values('{Data.UID}','{id}',now());update books set number = number - 1 where id='{id}'";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 1)   //执行两条sql，大于1才是成功
                {
                    MessageBox.Show($"用户{Data.UName}成功借出{bname}！");
                    Table();    
                }
            }
        }
        #endregion


        #region 书号查询
        private void button4_Click(object sender, EventArgs e)
        {
            TableID();
        }

        #endregion


        #region 书名查询
        private void button5_Click(object sender, EventArgs e)
        {
            TableName();
        }
        #endregion


        #region 刷新
        private void button6_Click(object sender, EventArgs e)
        {
            Table();    //刷新

            //清空两个文本框的信息
            inquirebookname.Text = "";
            inquirebookid.Text = "";
        }
        #endregion

        #region 选中一行
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text =  dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //点击一行之后显示书名
        }
        #endregion
    }
}
