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

namespace students
{
    public partial class QuestionsControl : Form
    {
        DBConnection dbc;
        private int ep_id, question_id;
        public QuestionsControl(int ep_id, string name)
        {
            InitializeComponent();
            dbc = new DBConnection();
            dbc.con = new MySqlConnection(dbc.connectionString);
            dbc.openConnection();
            this.ep_id = ep_id;
            label1.Text = "Questions for packet " +name;
            showQuestions();
        }

        private void showQuestions()
        {
                dbc.openConnection();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("select * from soal_tes where ep_id = @ep_id", dbc.con))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@ep_id", ep_id);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            question_id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            questionBox.Text= this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            option1Box.Text= this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            option2Box.Text= this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            option3Box.Text= this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            rightAnsBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            MessageBox.Show(question_id.ToString());
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(questionBox.Text) || String.IsNullOrWhiteSpace(option1Box.Text) || String.IsNullOrWhiteSpace(option2Box.Text) || String.IsNullOrWhiteSpace(option3Box.Text) || String.IsNullOrWhiteSpace(rightAnsBox.Text))
                MessageBox.Show("Cannot be empty!");
            else
            {
                dbc.openConnection();
                    using (MySqlCommand cmd = new MySqlCommand("insert into soal_tes (ep_id, question,ans1,ans2,ans3,rightAns) values (@ep_id,@question, @option1, @option2, @option3,@rightAns)", dbc.con))
                    {
                        cmd.Parameters.AddWithValue("@question", questionBox.Text);
                        cmd.Parameters.AddWithValue("@ep_id", this.ep_id);
                        cmd.Parameters.AddWithValue("@option1", option1Box.Text);
                        cmd.Parameters.AddWithValue("@option2", option2Box.Text);
                        cmd.Parameters.AddWithValue("@option3", option2Box.Text);
                        cmd.Parameters.AddWithValue("@rightAns", rightAnsBox.Text);
                        cmd.ExecuteNonQuery();
                    }
                showQuestions();
            }
            questionBox.Text = ""; option1Box.Text = ""; option2Box.Text = "";
            option3Box.Text = ""; rightAnsBox.Text = "";



        }

        private void deleteQuestion(int id)
        {
                dbc.openConnection();
                using (MySqlCommand cmd = new MySqlCommand("Delete from soal_tes where id = @id", dbc.con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            MessageBox.Show("Deleted");
            showQuestions();
        }
        
        private void updateQuestion(int id, string a, string b, string c, string d,string e)
        {
                dbc.openConnection();
                using (MySqlCommand cmd = new MySqlCommand("update soal_tes set question = @a, ans1 = @b, ans2=@c, ans3 =@d, rightans=@e where id = @question_id", dbc.con))
                {
                    cmd.Parameters.AddWithValue("@a", a);
                    cmd.Parameters.AddWithValue("@b", b);
                    cmd.Parameters.AddWithValue("@c", c);
                    cmd.Parameters.AddWithValue("@d", d);
                    cmd.Parameters.AddWithValue("@e", e);
                    cmd.Parameters.AddWithValue("@question_id", question_id);

                    cmd.ExecuteNonQuery();
                }
            showQuestions();
            MessageBox.Show("Updated");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateQuestion(question_id,questionBox.Text, option1Box.Text, option2Box.Text, option3Box.Text, rightAnsBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteQuestion(question_id);
        }
    }
}