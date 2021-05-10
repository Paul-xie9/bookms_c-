using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

// global::WindowsFormsApp.Properties.image;

namespace bookMS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
           // this.BackgroundImage = Image.FormFile("Image\\loginbackground.jpg");

        }

     
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * label1.BackColor = Color.Transparent;   //将label1的背景颜色设置成透明的
            label1.Parent = pictureBoxLogin;    //将label1的父颜色设置为背景框的颜色
            label2.BackColor = Color.Transparent;
            label2.Parent = pictureBoxLogin;
            label3.BackColor = Color.Transparent;
            label3.Parent = pictureBoxLogin;
            label4.BackColor = Color.Transparent;
            label4.Parent = pictureBoxLogin;

            radioButtonuser.BackColor = Color.Transparent;
            radioButtonuser.Parent = pictureBoxLogin;

            radioButtonadmin.BackColor = Color.Transparent;
            radioButtonadmin.Parent = pictureBoxLogin;

            button1.BackColor = Color.Transparent;
            button1.Parent = pictureBoxLogin;

            button2.BackColor = Color.Transparent;
            button2.Parent = pictureBoxLogin;
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                         if(textBoxID.Text !="" && textBoxPWD.Text !="")
                        {
                            Login();
                        }
                        else
                        {
                            MessageBox.Show("输入有空项，请重新输入！");
                        }
            }
            catch
            {
                MessageBox.Show("出错啦！");
            }
            
        }


        public void Login()  //登录验证
        {
            
            #region 用户登陆
            //用户
            if (radioButtonuser.Checked == true)
            {
                Dao dao = new Dao();
                //string sql = "select *from user where id= '"+ textBoxID.Text +"' and password= '"+ textBoxPWD.Text +"'";    //这里是根据mysql中对user表的查询的
                //string sql = String.Format("select *from user where id='{0}',password='{1}'",textBoxID.Text,textBoxPWD.Text);
              
                string sql = $"select *from user where id='{textBoxID.Text}'and password='{textBoxPWD.Text}'";
               // MessageBox.Show(sql);
                IDataReader dataReader = dao.reader(sql);
                if (dataReader.Read())
                {
                    Data.UID = dataReader["id"].ToString();
                    Data.UName = dataReader["name"].ToString();

                    MessageBox.Show("用户登录成功！");
                    userMain user = new userMain();
                    this.Hide();    //隐藏旧窗体
                    user.ShowDialog();  //新窗体弹窗
                    this.Show();    //显示新窗体
                 //   return true;
                }
                else
                {
                    MessageBox.Show("用户登录失败！");
                 //   return false;
                }
                dao.DaoClose();
               // MessageBox.Show(dataReader[0].ToString()+dataReader["name"].ToString());
            }
            #endregion

            #region 管理员的登录
            //管理员
            if (radioButtonadmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select *from admin where id='{textBoxID.Text}' and password= '{textBoxPWD.Text}'";
               // MessageBox.Show(sql);
                IDataReader dataReader = dao.reader(sql);

                if (dataReader.Read())
                {
                    MessageBox.Show("管理员登录成功！");
                    admin admin = new admin();
                    this.Hide();    //旧窗体隐藏
                    admin.ShowDialog();
                    this.Show();    //新窗体显示
                 //   return true;  
                }
                else
                {
                    MessageBox.Show("管理员登录失败！");
                 //   return false;
                }
                dao.DaoClose();
            }
            #endregion 

            MessageBox.Show("单选框失效！请选中单选框！");
           // return false;
            //return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxPWD.Text = "";
        }
    }
}
