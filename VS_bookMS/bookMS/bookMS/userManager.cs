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
    public partial class userManager : Form
    {
        public userManager()
        {
            InitializeComponent();
        }

        #region 首次进入默认显示状态
        private void userManager_Load(object sender, EventArgs e)
        {
            Table();    //数据显示
            label2.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + dataGridView2.SelectedRows[0].Cells[1].Value.ToString();    //点击之后获取学号和姓名，默认选中第一行数据
        }
        #endregion


        #region 从数据库读取全部数据并放到表格中
        public void Table()
        {
            dataGridView2.Rows.Clear(); //清空一行中的旧数据
            Dao dao = new Dao();
            string sql = $"select *from user";
            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView2.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
        #endregion


        #region 学号查询方法构造 模糊查询
        public void TableID()
        {
            dataGridView2.Rows.Clear(); //清空一行中的旧数据
            Dao dao = new Dao();
            string sql = $"select *from user where id like '%{inquirebookid.Text}%'";
            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView2.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
        #endregion


        #region 书名查询方法构造 模糊查询
        public void TableName()
        {
            dataGridView2.Rows.Clear(); //清空一行中的旧数据
            Dao dao = new Dao();
            string sql = $"select *from user where name like '%{inquirebookname.Text}%'";
            IDataReader dataReader = dao.reader(sql);

            while (dataReader.Read())
            {
                dataGridView2.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
        #endregion


        #region 选中一个单元格
        private void dataGridView2_Click_1(object sender, EventArgs e)  //需要在事件点击中添加
        {
            label2.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + dataGridView2.SelectedRows[0].Cells[1].Value.ToString();//点击之后获取学号和姓名
        }
        #endregion


        #region 弹出添加用户窗体
        private void button9_Click(object sender, EventArgs e)
        {
            userAdd userAdd = new userAdd();
            userAdd.ShowDialog();
            Table();
        }
        #endregion


        #region 修改用户
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                string sex = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                string password = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();

                userChange userChange = new userChange(id, name, sex, password);
                userChange.ShowDialog();
                Table();    //刷新数据
            }
            catch
            {
                MessageBox.Show("出错啦！");
            }
        }
        #endregion


        #region 删除用户
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();    //获取学号id
                label2.Text = id + dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information); //弹出删除提示信息
                if (dr == DialogResult.Yes)
                {
                    string sql = $"delete from user where id = '{id}' ";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("图书删除成功！");
                        Table();    //更新
                    }
                    else
                    {
                        MessageBox.Show("图书删除失败！" + sql);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("请先选中需要删除的图书！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        #region 学号查询操作  
        private void button7_Click(object sender, EventArgs e)
        {
            TableID();
        }
        #endregion


        #region 书号查询操作
        private void button5_Click(object sender, EventArgs e)
        {
            TableName();
        }
        #endregion


        #region 刷新操作
        private void button6_Click(object sender, EventArgs e)
        {
            Table();    //刷新
            inquirebookid.Text = "";
            inquirebookname.Text = "";
        }

        #endregion

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
