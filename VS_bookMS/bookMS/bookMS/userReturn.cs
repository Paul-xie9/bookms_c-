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
    public partial class userReturn : Form
    {
        public userReturn()
        {
            InitializeComponent();
            //Table();
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
           // string sql = $"select no,bid,datetime from lend where uid='{Data.UID}'";

            string sql = $"select user.id, user.`name`, lend.bid, books.`name`, books.author, books.press, lend.datetime, lend.no from books , user, lend  where lend.bid=books.id and lend.uid=user.id  and lend.uid='{Data.UID}'";

            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString(), dataReader[7].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            string no = dataGridView1.Rows[0].Cells[7].Value.ToString();    //获取借书编号 
            string bname = dataGridView1.Rows[0].Cells[3].Value.ToString();    //获取书名
            string bid = dataGridView1.Rows[0].Cells[2].Value.ToString();       //获取书号

            string sql = $"delete from lend where no ={no};update books set number = number + 1 where id = '{bid}'";

            Dao dao = new Dao();
            if(dataGridView1.Rows.Count !=null && dao.Execute(sql) > 1)
            {
                MessageBox.Show($"图书{bname}归还成功！");
                Table();
            }
            else
            {
                MessageBox.Show($"图书{bname}归还失败！");
            }
            
        }
    }
}
