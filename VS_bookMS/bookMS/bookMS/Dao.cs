using System.Data.SqlClient;    //引入数据库的包
using MySql.Data;
using MySql.Data.MySqlClient;

namespace bookMS
{
    class Dao
    {
        MySqlConnection sc;

        public MySqlConnection connect()
        {
            string str = "server=localhost; user=root; database=BookMS; port=3306; password=root;Charset=utf8";  //数据库链接字符串
             sc = new MySqlConnection(str);  //创建数据库链接对象
            sc.Open();  //打开数据库 
            return sc;  //返回数据库链接对象
        }

        public MySqlCommand command(string sql)   //  
        {
            MySqlCommand cmd = new MySqlCommand(sql, connect());
            return cmd;
        }

        public int Execute(string sql)  //更新操作
        {
            return command(sql).ExecuteNonQuery();
        }

        public MySqlDataReader reader(string sql)   //读取操作
        {
            return command(sql).ExecuteReader();
        }

        public void DaoClose()
        {
            sc.Close();
        }
    }
}
