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
    public partial class TestWindow : Form
    {
        private int ticks=75;
        List<QuestionData> myList;
        List<string> myListofAnswers;
        QuestionData myQuestions;
        private int questionNo=0;
        private int[] isQuestionAnswered;

        public TestWindow()
        {
            InitializeComponent();
            timer1.Start();
            myList = new List<QuestionData>();
            myListofAnswers = new List<string>();
            isQuestionAnswered = new int[100];
            Array.Clear(isQuestionAnswered, 0, isQuestionAnswered.Length);

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\Documents\Visual Studio 2017\Projects\students\students\students.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("select * from soal_tes where ep_id = 1", con))
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

                        myList.Add(myQuestions);

                    }
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
                myListofAnswers[questionNo] = ansA.Text;
            else
            {

                myListofAnswers.Add(ansA.Text);
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
                isQuestionAnswered[questionNo] = 1;

            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to submit?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                timer1.Stop();
                submitAnswers();
                MessageBox.Show(myListofAnswers.Count().ToString());
                myListofAnswers.Clear();
            }
        }

        private void submitAnswers()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\Documents\Visual Studio 2017\Projects\students\students\students.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("insert into student_answers values (@myAns)", con))
                {
                    for (int i = 0; i < myListofAnswers.Count(); i++)
                    {
                        cmd.Parameters.AddWithValue("@myAns", myListofAnswers[i]);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                MessageBox.Show("Submitted!");
            }
        }

   
    }
}
