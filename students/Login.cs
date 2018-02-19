using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace students
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private string StringtoMD5(string Content)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider M5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] ByteString = System.Text.Encoding.ASCII.GetBytes(Content);
            ByteString = M5.ComputeHash(ByteString);
            string FinalString = null;
            foreach (byte bt in ByteString)
            {
                FinalString += bt.ToString("x2");
            }
            return FinalString.ToUpper();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\Documents\Visual Studio 2017\Projects\students\students\students.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                //insert into admins (username, password) values (@username, @password) -- select * from admins where username = @username and password= @password

                //username: adisazhar123
                //password: skateboard123

                using (SqlCommand cmd = new SqlCommand("select * from admins where username = @username and password= @password", con))
                {
                    cmd.Parameters.AddWithValue("@username", usernameBox.Text);
                    cmd.Parameters.AddWithValue("@password", StringtoMD5(passwordBox.Text));
                    //cmd.ExecuteNonQuery();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        this.Close();
                        UserInfos.setUserId(99);
                        int a = UserInfos.getUserId();
                        MessageBox.Show("Login Success! with id" + Convert.ToString(a));
                    }
                    else
                    {
                        MessageBox.Show("Invalid!");
                    }
                }
            }
        }
    }

    static class UserInfos
    {
        private static int userId;
        public static void setUserId(int a)
        {
            userId = a;
        }
        public static int getUserId()
        {
            return userId;
        }
    }
}