using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExaminationSystem
{
    public partial class TestWindow : Form
    {
        DBConnection dbc;
        private int ticks=75;
        List<QuestionData> myList;
        List<string> myListofAnswers;
        List<int> questionId;
        QuestionData myQuestions;
        private int questionNo=0;
        private int[] isQuestionAnswered;
        int packet_id;

        //  UNTUK MENYIMPAN JAWABAN DAN QUESTION ID SOAL
        //List<(string ans, int question_id)> myListofAnswers2;

        public TestWindow()
        {
            InitializeComponent();
            dbc = new DBConnection();
            dbc.con = new MySqlConnection(dbc.connectionString);
            dbc.openConnection();
            timer1.Start();
            myList = new List<QuestionData>();
            questionId = new List<int>();

            myListofAnswers = new List<string>();
            isQuestionAnswered = new int[100];
            Array.Clear(isQuestionAnswered, 0, isQuestionAnswered.Length);
 
                using (MySqlDataAdapter sda = new MySqlDataAdapter("select * from soal_tes where ep_id = 1", dbc.con))
                {                   
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach(DataRow row in dt.Rows)
                    {
                        myQuestions = new QuestionData();
                        myQuestions.question = row["question"].ToString();
                        myQuestions.ans1 = row["ans1"].ToString();
                        myQuestions.ans2 = row["ans2"].ToString();
                        myQuestions.ans3 = row["ans3"].ToString();
                        myQuestions.rightAns = row["rightAns"].ToString();
                        myQuestions.question_id = Convert.ToInt32(row["id"].ToString());
                        packet_id = Convert.ToInt32(row["ep_id"].ToString());
                        myList.Add(myQuestions);

                    }
                }
            
            questionBox.Text = myList[questionNo].question;
            ansA.Text = myList[questionNo].ans1;
            ansB.Text = myList[questionNo].ans2;
            ansC.Text = myList[questionNo].ans3;
            ansD.Text = myList[questionNo].rightAns;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(questionNolbl.Text);
            no++;
            questionNolbl.Text = Convert.ToString(no);
            questionNo++;
            questionBox.Text = myList[questionNo].question;
            ansA.Text = myList[questionNo].ans1;
            ansB.Text = myList[questionNo].ans2;
            ansC.Text = myList[questionNo].ans3;
            ansD.Text = myList[questionNo].rightAns;

            if (!myList[questionNo].ansForQuestion)
            {
                ansA.Checked = false;
                ansB.Checked = false;
                ansC.Checked = false;
                ansD.Checked = false;
            }
            else
            {
                if (myList[questionNo].selectedAns.Equals('A')) ansA.Checked = true;
                else if (myList[questionNo].selectedAns.Equals('B')) ansB.Checked = true;
                else if (myList[questionNo].selectedAns.Equals('C')) ansC.Checked = true;
                else if (myList[questionNo].selectedAns.Equals('D')) ansD.Checked = true;

            }
            
            if (questionNo == 0) prevBtn.Enabled = false;
            else prevBtn.Enabled = true;
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(questionNolbl.Text);
            if (no > 1)
            {
                no--;
                questionNolbl.Text = Convert.ToString(no);
                questionNo--;

                questionBox.Text = myList[questionNo].question;
                ansA.Text = myList[questionNo].ans1;
                ansB.Text = myList[questionNo].ans2;
                ansC.Text = myList[questionNo].ans3;
                ansD.Text = myList[questionNo].rightAns;


                if (!myList[questionNo].ansForQuestion)
                {
                    ansA.Checked = false;
                    ansB.Checked = false;
                    ansC.Checked = false;
                    ansD.Checked = false;
                }
                else
                {
                    if (myList[questionNo].selectedAns.Equals('A')) ansA.Checked = true;
                    else if (myList[questionNo].selectedAns.Equals('B')) ansB.Checked = true;
                    else if (myList[questionNo].selectedAns.Equals('C')) ansC.Checked = true;
                    else if (myList[questionNo].selectedAns.Equals('D')) ansD.Checked = true;
                }
            }

            if (questionNo == 0) prevBtn.Enabled = false;
            else prevBtn.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int menit, detik;
            menit = ticks / 60;
            detik = ticks % 60;
            ticks--;
            timerLbl.Text = menit.ToString();
            label1.Text = ": " + detik.ToString();
            userId.Text = Convert.ToString(UserInfos.getUserId());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getDataBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                MessageBox.Show(myList[i].question + " "+ myList[i].rightAns);
            }
        }
        
        private void ansA_Click(object sender, EventArgs e)
        {
            myList[questionNo].ansForQuestion = true;
            myList[questionNo].selectedAns = 'A';

            if (Convert.ToBoolean(isQuestionAnswered[questionNo]))
            {
                myListofAnswers[questionNo] = ansA.Text;
                
            }
            else
            {
                myListofAnswers.Add(ansA.Text);
                questionId.Add(myList[questionNo].question_id);
                isQuestionAnswered[questionNo] = 1;
            }
        }

            private void ansB_Click(object sender, EventArgs e)
        {
            myList[questionNo].ansForQuestion = true;
            myList[questionNo].selectedAns = 'B';
            if (Convert.ToBoolean(isQuestionAnswered[questionNo]))
                myListofAnswers[questionNo] = ansB.Text;
            else
            {
                myListofAnswers.Add(ansB.Text);
                questionId.Add(myList[questionNo].question_id);
                isQuestionAnswered[questionNo] = 1;
            }
        }

        private void ansC_Click(object sender, EventArgs e)
        {
            myList[questionNo].ansForQuestion = true;
            myList[questionNo].selectedAns = 'C';

            if (Convert.ToBoolean(isQuestionAnswered[questionNo]))
                myListofAnswers[questionNo] = ansC.Text;
            else
            {
                myListofAnswers.Add(ansC.Text);
                questionId.Add(myList[questionNo].question_id);
                isQuestionAnswered[questionNo] = 1;

            }
        }

        private void ansD_Click(object sender, EventArgs e)
        {
            myList[questionNo].ansForQuestion = true;
            myList[questionNo].selectedAns = 'D';

            if (Convert.ToBoolean(isQuestionAnswered[questionNo]))
                myListofAnswers[questionNo] = ansD.Text;

            else
            {

                myListofAnswers.Add(ansD.Text);
                questionId.Add(myList[questionNo].question_id);
                isQuestionAnswered[questionNo] = 1;

            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to submit?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                timer1.Stop();
                submitAnswers();
                MessageBox.Show("mylistofanswers is " + myListofAnswers.Count().ToString());
                MessageBox.Show("mylistofquestion_id is " + questionId.Count().ToString());
                myListofAnswers.Clear();
                questionId.Clear();
            }
        }

        private void submitAnswers()
        {
            dbc.openConnection();
            using (MySqlCommand cmd = new MySqlCommand("insert into student_answers (ans, question_id, packet_id) values (@my_ans, @question_id, @packet_id)", dbc.con))
            {
                for (int i = 0; i < myListofAnswers.Count(); i++)
                {
                    cmd.Parameters.AddWithValue("@my_ans", myListofAnswers[i]);
                    cmd.Parameters.AddWithValue("@question_id", questionId[i]);
                    cmd.Parameters.AddWithValue("@packet_id", packet_id);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            MessageBox.Show("Submitted!");
        }
    }
}
