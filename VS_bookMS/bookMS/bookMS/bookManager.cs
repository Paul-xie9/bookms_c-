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
    public partial class bookManager : Form
    {
        public bookManager()
        {
            InitializeComponent();
           
        }

        #region 首次进入默认显示内容
        private void bookmanager_Load(object sender, EventArgs e)
        {  
            Table();    //也可以放在这里 
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //获取书号id和书名
           
        }
        #endregion


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


        #region  删除图书
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取书号id
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information); //弹出删除提示信息
                if(dr == DialogResult.Yes)
                {
                    string sql = $"delete from books where id = '{id}' ";
                    Dao dao = new Dao();
                    if(dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("图书删除成功！");
                        Table();    //更新
                    }
                    else
                    {
                        MessageBox.Show("图书删除失败！"+sql);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("请先选中需要删除的图书！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion


        #region 选中一个单元格
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //点击之后获取书号id和书名
        }
        #endregion


        #region 添加图书
        private void button1_Click(object sender, EventArgs e)
        {
            bookAdd addbook = new bookAdd();
            addbook.ShowDialog();
            Table();
        }
        #endregion


        # region 修改图书
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name  = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                bookChange changebook = new bookChange(id,name,author,press,number);
                changebook.ShowDialog();

                Table();    //刷新数据
            }
            catch
            {
                MessageBox.Show("出错啦！");
            }
        }
        #endregion


        # region 书名查询
        private void button5_Click(object sender, EventArgs e)
        {
            TableName();    //书名查询
        }
        #endregion


        # region 书号查询
        private void button4_Click(object sender, EventArgs e)
        {
            TableID();  //书号查询
        }
        #endregion


        #region 刷新操作
        private void button6_Click(object sender, EventArgs e)
        {
            Table();    //刷新

            //清空两个文本框的信息
            inquirebookname.Text = "";
            inquirebookid.Text = "";
        }
        #endregion

 
    }
}
