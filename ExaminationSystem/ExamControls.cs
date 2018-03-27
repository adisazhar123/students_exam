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

namespace ExaminationSystem
{
    public partial class ExamControls : Form
    {
        DBConnection dbc;
        QuestionsControl qc;

        public ExamControls()
        {
            InitializeComponent();
            dbc = new DBConnection();
            dbc.con = new MySqlConnection(dbc.connectionString);

            dbc.openConnection(); ;
            using (MySqlDataAdapter sda = new MySqlDataAdapter("select * from exam_packets", dbc.con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    this.dataGridView1.Columns["name"].HeaderText = "NAME";
                }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            string packetName= this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            qc = new QuestionsControl(id, packetName);
            qc.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
