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
    public partial class QustionsControl : Form
    {
        private int ep_id, question_id;
        public QustionsControl(int ep_id, string name)
        {
            InitializeComponent();
            this.ep_id = ep_id;
            label1.Text = "Questions for packet " +name;
            showQuestions();
        }

        private void showQuestions()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\Documents\Visual Studio 2017\Projects\students\students\students.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("select * from soal_tes where ep_id = @ep_id", con))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@ep_id", ep_id);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            question_id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            questionBox.Text= this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            option1Box.Text= this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            option2Box.Text= this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            option3Box.Text= this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            rightAnsBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(questionBox.Text) || String.IsNullOrWhiteSpace(option1Box.Text) || String.IsNullOrWhiteSpace(option2Box.Text) || String.IsNullOrWhiteSpace(option3Box.Text) || String.IsNullOrWhiteSpace(rightAnsBox.Text))
                MessageBox.Show("Cannot be empty!");
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\Documents\Visual Studio 2017\Projects\students\students\students.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("insert into soal_tes (ep_id, question,ans1,ans2,ans3,rightAns) values (@ep_id,@question, @option1, @option2, @option3,@rightAns)", con))
                    {
                        cmd.Parameters.AddWithValue("@question", questionBox.Text);
                        cmd.Parameters.AddWithValue("@ep_id", this.ep_id);
                        cmd.Parameters.AddWithValue("@option1", option1Box.Text);
                        cmd.Parameters.AddWithValue("@option2", option2Box.Text);
                        cmd.Parameters.AddWithValue("@option3", option2Box.Text);
                        cmd.Parameters.AddWithValue("@rightAns", rightAnsBox.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                showQuestions();
            }
        }

        private void deleteQuestion(int id)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\Documents\Visual Studio 2017\Projects\students\students\students.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Delete from soal_tes where id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Deleted");
            showQuestions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteQuestion(question_id);
        }
    }
}
