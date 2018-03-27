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
using MySql.Data.MySqlClient;
using System.Threading;

namespace students
{
    public partial class Login : Form
    {
        Thread th;
        DBConnection dbc;   
        public Login()
        {
            InitializeComponent();
            dbc = new DBConnection();
            dbc.con = new MySqlConnection(dbc.connectionString);

            dbc.openConnection();
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
            //insert into admins (username, password) values (@username, @password) -- select * from admins where username = @username and password= @password

            //username: adisazhar123
            //password: skateboard123
            
            MySqlCommand cmd = new MySqlCommand("select * from admins where username = @username and password = @password", dbc.con);
            cmd.Parameters.AddWithValue("@username", usernameBox.Text);
            cmd.Parameters.AddWithValue("@password", StringtoMD5(passwordBox.Text));

            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                th = new Thread(runForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();


                this.Close();
                UserInfos.setUserId(99);
                int a = UserInfos.getUserId();
                MessageBox.Show("Login Success! with id" + Convert.ToString(a));

            }
            else
            {
                MessageBox.Show("Invalid!");
            }
            sdr.Close();

        }

        private void runForm()
        {
            Application.Run(new Form1());
        }

        private void Login_Load(object sender, EventArgs e)
        {

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