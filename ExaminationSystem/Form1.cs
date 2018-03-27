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
using System.Threading;
using MySql.Data.MySqlClient;

namespace ExaminationSystem
{
    public partial class Form1 : Form
    {
        private int id;
        Thread th;
        Login loginForm;
        DBConnection dbc;
        ExamControls examcontrols;


        public Form1()
        {
            InitializeComponent();
            dbc = new DBConnection();
            dbc.con = new MySqlConnection(dbc.connectionString);
            dbc.openConnection();

            displayData();
        }

        private void displayData()
        {
            using (MySqlDataAdapter sda = new MySqlDataAdapter("select * from students", dbc.con))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns["Id"].Visible = false;
            }
                dbc.con.Close();      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                nameBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                departmentBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                facultyBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void save_Click(object sender, EventArgs e)
        {
            dbc.openConnection();

            if (String.IsNullOrWhiteSpace(nameBox.Text) || String.IsNullOrWhiteSpace(departmentBox.Text) || String.IsNullOrWhiteSpace(facultyBox.Text))
            {
                MessageBox.Show("Please choose a student to delete.");
            }
            else
            {
                    using (MySqlCommand cmd = new MySqlCommand("insert into students (name,department,faculty) values (@name, @department, @faculty)", dbc.con))
                    {
                        cmd.Parameters.AddWithValue("@name", nameBox.Text);
                        cmd.Parameters.AddWithValue("@department", departmentBox.Text);
                        cmd.Parameters.AddWithValue("@faculty", facultyBox.Text);
                        cmd.ExecuteNonQuery();
                    }
                

                displayData();
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameBox.Text) || String.IsNullOrWhiteSpace(departmentBox.Text) || String.IsNullOrWhiteSpace(facultyBox.Text))
            {
                MessageBox.Show("Please choose a student to delete.");
            }
            else
            {
                dbc.openConnection();
                using (MySqlCommand cmd = new MySqlCommand("Delete from students where id = @id", dbc.con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted");
                }
                displayData();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
                
                dbc.con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update students set name = @name, department = @department, faculty=@faculty where id = @id", dbc.con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", nameBox.Text);
                    cmd.Parameters.AddWithValue("@department", departmentBox.Text);
                    cmd.Parameters.AddWithValue("@faculty", facultyBox.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                }
                displayData();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
       //     this.Close();
            th = new Thread(runTestApp);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void initTest ()
        {
            TestWindow form2 = new TestWindow();
            form2.Show();
        }
        private void runTestApp(object obj)
        {
            Application.Run(new TestWindow());
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //th = new Thread(runLoginApp);
            //th.SetApartmentState(ApartmentState.STA);
            //th.Start();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void initLogin()
        {
            loginForm = new Login();
            loginForm.Show();
        }

        private void runLoginApp(object obj)
        {
            Application.Run(new Login());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void examPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            examcontrols = new ExamControls();
            examcontrols.Show();
        }
    }
}
