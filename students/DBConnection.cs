using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace students
{
    class DBConnection
    {
        public MySqlConnection con;
        public string connectionString;
        public DBConnection()
        {
            connectionString = "SERVER=fiona.rapidplex.com; DATABASE=adisazha_exam_system;UID=adisazha_adis;PASSWORD=skateboard;";
        }
        public bool openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    this.con.Open();
                    //MessageBox.Show("Connected");
                    return true;

                }
                catch (MySqlException ex)
                {
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            //MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            //MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                    //MessageBox.Show("False");
                    return false;
                }
            }
            return true;

        }
    }
}
