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
    public partial class bookLend : Form
    {
        public bookLend()
        {
            InitializeComponent();
        }

        private void bookLend_Load(object sender, EventArgs e)
        {
            Table();
        }
        #region 从数据库读取全部数据并放到表格中
        public void Table()
        {
            dataGridView1.Rows.Clear(); //清空一行中的旧数据
            Dao dao = new Dao();
            //string sql = $"select no,bid,datetime from lend where uid='{Data.UID}'";

            string sql = $"select user.id, user.`name`, books.`name`, books.author, books.press, lend.datetime from books , user, lend  where lend.bid=books.id and user.id=lend.uid";
            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(),dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }

        #endregion
    }
}
