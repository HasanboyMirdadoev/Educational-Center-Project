using Educational_Center_Project.HistoryFolder;
using Educational_Center_Project.Students;
using Educational_Center_Project.TotalResultFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Educational_Center_Project.OverallProps.DashHelpers.StudentExamScoreFile
{
    public partial class StudentExamScores : Form
    {
        StudentExamScoreAdmin admin = new StudentExamScoreAdmin();
        List<StudentExamScoreDatas> students;
        public StudentExamScores()
        {
            InitializeComponent();
            DisplayStudentList();
            searchBy_comb.SelectedItem = "Student Name";
            processing_panel.Visible = false;
        }
        private void DisplayStudentList()
        {
            students = admin.GetStudents();
            student_list.DataSource = students;
            student_list.ColumnHeadersHeight = 21;
        }
        private void search_txb_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager manager = (CurrencyManager)BindingContext[student_list.DataSource];
            manager.SuspendBinding();

            foreach (DataGridViewRow row in student_list.Rows)
            {
                row.Visible = true;
            }

            if (searchBy_comb.SelectedItem.ToString() == "Student Name")
            {
                foreach (DataGridViewRow row in student_list.Rows)
                {
                    if (!row.Cells[1].Value.ToString().Contains(search_txb.Text))
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in student_list.Rows)
                {
                    if (!row.Cells[3].Value.ToString().Contains(search_txb.Text))
                    {
                        row.Visible = false;
                    }
                }
            }
            manager.ResumeBinding();
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit without changes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Dashboard form1 = new Dashboard();
                form1.Show();
            }
        }
        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                for (int i = 0; i < student_list.RowCount; i++)
                {
                    students[i].ExamScore = Convert.ToDouble(student_list.Rows[i].Cells[4].Value);
                }

                if (admin.UpdateStudents(students))
                {
                    processing_panel.Visible = true;
                    Thread.Sleep(1000);
                    MessageBox.Show("Exam scores updated succesfully now lets make total result!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    CallMonthEnded();

                    TotalResult totalResult = new TotalResult(1);
                    totalResult.Show();
                }
                else
                {
                    processing_panel.Visible = true;
                    Thread.Sleep(1000);
                    MessageBox.Show("Something wrong here. Students ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    Dashboard form1 = new Dashboard();
                    form1.Show();
                }
            }
            else
            {
                MessageBox.Show("You have to write scores for all students ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CallMonthEnded()
        {
            DataTable dataTable = BaseDB.GetStudentDatasTable();
            TableSaver saver = new TableSaver(1);
            saver.AddTable(dataTable);

            HistoryAdmin admin = new HistoryAdmin();
            admin.MonthEnded((List<StudentDatas>)saver.GetCurrentTableList());
        }
        bool Check()
        {
            foreach (DataGridViewRow row in student_list.Rows)
            {
                if (Convert.ToInt32(row.Cells[4].Value) == 0)
                    return false;
            }
            return true;
        }
    }
}
