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
    public partial class Exam_Controls : Form
    {
        QustionsControl qc;
        public Exam_Controls()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\Documents\Visual Studio 2017\Projects\students\students\students.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("select * from exam_packets", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    this.dataGridView1.Columns["name"].HeaderText = "NAME";
                }
      
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            string packetName= this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            qc = new QustionsControl(id, packetName);
            qc.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
