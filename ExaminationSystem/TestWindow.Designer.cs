namespace ExaminationSystem
{
    partial class TestWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.getDataBtn = new System.Windows.Forms.Button();
            this.userId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerLbl = new System.Windows.Forms.Label();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ansD = new System.Windows.Forms.RadioButton();
            this.ansC = new System.Windows.Forms.RadioButton();
            this.ansA = new System.Windows.Forms.RadioButton();
            this.ansB = new System.Windows.Forms.RadioButton();
            this.questionNolbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.questionBox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.submitBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.submitBtn);
            this.panel1.Controls.Add(this.getDataBtn);
            this.panel1.Controls.Add(this.userId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.timerLbl);
            this.panel1.Controls.Add(this.prevBtn);
            this.panel1.Controls.Add(this.nextBtn);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.questionNolbl);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1900, 981);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // getDataBtn
            // 
            this.getDataBtn.Location = new System.Drawing.Point(572, 367);
            this.getDataBtn.Name = "getDataBtn";
            this.getDataBtn.Size = new System.Drawing.Size(136, 28);
            this.getDataBtn.TabIndex = 15;
            this.getDataBtn.Text = "Get Data";
            this.getDataBtn.UseVisualStyleBackColor = true;
            this.getDataBtn.Click += new System.EventHandler(this.getDataBtn_Click);
            // 
            // userId
            // 
            this.userId.AutoSize = true;
            this.userId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userId.Location = new System.Drawing.Point(1199, 19);
            this.userId.Name = "userId";
            this.userId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userId.Size = new System.Drawing.Size(0, 29);
            this.userId.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1647, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "seconds remaining";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timerLbl
            // 
            this.timerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLbl.AutoSize = true;
            this.timerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLbl.Location = new System.Drawing.Point(1628, 44);
            this.timerLbl.Name = "timerLbl";
            this.timerLbl.Size = new System.Drawing.Size(27, 29);
            this.timerLbl.TabIndex = 5;
            this.timerLbl.Text = "5";
            // 
            // prevBtn
            // 
            this.prevBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevBtn.Enabled = false;
            this.prevBtn.Location = new System.Drawing.Point(218, 865);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(122, 60);
            this.prevBtn.TabIndex = 12;
            this.prevBtn.Text = "Previous";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(1301, 865);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(122, 60);
            this.nextBtn.TabIndex = 11;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ansD, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ansC, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ansA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ansB, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(129, 401);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 425);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // ansD
            // 
            this.ansD.AutoSize = true;
            this.ansD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansD.Location = new System.Drawing.Point(3, 120);
            this.ansD.Name = "ansD";
            this.ansD.Size = new System.Drawing.Size(170, 33);
            this.ansD.TabIndex = 11;
            this.ansD.TabStop = true;
            this.ansD.Text = "radioButton4";
            this.ansD.UseVisualStyleBackColor = true;
            this.ansD.Click += new System.EventHandler(this.ansD_Click);
            // 
            // ansC
            // 
            this.ansC.AutoSize = true;
            this.ansC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansC.Location = new System.Drawing.Point(3, 81);
            this.ansC.Name = "ansC";
            this.ansC.Size = new System.Drawing.Size(170, 33);
            this.ansC.TabIndex = 10;
            this.ansC.TabStop = true;
            this.ansC.Text = "radioButton1";
            this.ansC.UseVisualStyleBackColor = true;
            this.ansC.Click += new System.EventHandler(this.ansC_Click);
            // 
            // ansA
            // 
            this.ansA.AutoSize = true;
            this.ansA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansA.Location = new System.Drawing.Point(3, 3);
            this.ansA.Name = "ansA";
            this.ansA.Size = new System.Drawing.Size(170, 33);
            this.ansA.TabIndex = 8;
            this.ansA.TabStop = true;
            this.ansA.Text = "radioButton2";
            this.ansA.UseVisualStyleBackColor = true;
            this.ansA.Click += new System.EventHandler(this.ansA_Click);
            // 
            // ansB
            // 
            this.ansB.AutoSize = true;
            this.ansB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansB.Location = new System.Drawing.Point(3, 42);
            this.ansB.Name = "ansB";
            this.ansB.Size = new System.Drawing.Size(170, 33);
            this.ansB.TabIndex = 9;
            this.ansB.TabStop = true;
            this.ansB.Text = "radioButton3";
            this.ansB.UseVisualStyleBackColor = true;
            this.ansB.Click += new System.EventHandler(this.ansB_Click);
            // 
            // questionNolbl
            // 
            this.questionNolbl.AutoSize = true;
            this.questionNolbl.BackColor = System.Drawing.SystemColors.Info;
            this.questionNolbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.questionNolbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.questionNolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNolbl.Location = new System.Drawing.Point(42, 88);
            this.questionNolbl.Name = "questionNolbl";
            this.questionNolbl.Size = new System.Drawing.Size(28, 31);
            this.questionNolbl.TabIndex = 5;
            this.questionNolbl.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.questionBox);
            this.groupBox1.Location = new System.Drawing.Point(90, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1446, 285);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // questionBox
            // 
            this.questionBox.BackColor = System.Drawing.Color.White;
            this.questionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionBox.Location = new System.Drawing.Point(3, 18);
            this.questionBox.Name = "questionBox";
            this.questionBox.ReadOnly = true;
            this.questionBox.Size = new System.Drawing.Size(1440, 264);
            this.questionBox.TabIndex = 3;
            this.questionBox.Text = resources.GetString("questionBox.Text");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.submitBtn.Location = new System.Drawing.Point(692, 853);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(210, 84);
            this.submitBtn.TabIndex = 16;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "TestWindow";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox questionBox;
        private System.Windows.Forms.Label questionNolbl;
        private System.Windows.Forms.RadioButton ansB;
        private System.Windows.Forms.RadioButton ansA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton ansD;
        private System.Windows.Forms.RadioButton ansC;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timerLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userId;
        private System.Windows.Forms.Button getDataBtn;
        private System.Windows.Forms.Button submitBtn;
    }
}