using Educational_Center_Project.HistoryFolder;
using Educational_Center_Project.OverallProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Educational_Center_Project.Students
{
    public partial class StudentForm : Form
    {
        TableSaver saver;
        int index = 0;
        List<StudentDatas> firstStudents;
        public StudentForm()
        {
            InitializeComponent();
            student_list.ColumnHeadersHeight = 21;
            processing_panel.Visible = false;
            exit_button.Top = this.Top + 1;
            exit_button.Left = this.Right - 36;
            backward.Enabled = false;
            forward.Enabled = false;
            LocateIt();
            change_panel.Visible = false;
            DataTable table = StudentAdmin.DisplayStudentList(student_list);
            saver = new TableSaver(1);
            saver.AddTable(table);
            firstStudents = (List<StudentDatas>)saver.GetCurrentTableList();
            GetIndex();
        }
        void GetIndex()
        {
            foreach (DataGridViewRow row in student_list.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) > index)
                    index = Convert.ToInt32(row.Cells[0].Value);
            }
            index++;
        }
        bool Check()
        {
            if (nameTxb.Text != String.Empty && surnameTxb.Text != String.Empty && phoneNumberTxb.Text != String.Empty
                && ageTxb.Text != String.Empty && levelTxb.Text != String.Empty
                && groupTxb.Text != String.Empty)
            {
                try
                {
                    int.Parse(bonusTxb.Text);
                    int.Parse(cameLessonsTxb.Text);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else return false;
        }
        void ClearIt()
        {
            nameTxb.Text = surnameTxb.Text = phoneNumberTxb.Text = languageTxb.Text = ageTxb.Text = levelTxb.Text = commentTxb.Text = groupTxb.Text = string.Empty;
            bonusTxb.Text = cameLessonsTxb.Text = "0";
        }
        bool Check_Change()
        {
            if (changeName.Text != String.Empty && changeSurname.Text != String.Empty && changePhoneNumber.Text != String.Empty
               && changeLanguage.Text != String.Empty && changeAge.Text != String.Empty && changeLevel.Text != String.Empty
                && changeGroup.Text != String.Empty)
            {
                try
                {
                    int.Parse(changeBonus.Text);
                    int.Parse(changeCameLessons.Text);
                    int.Parse(paymentTxb.Text);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else return false;
        }
        void LocateIt()
        {
            add_panel.Visible = false;
            open_add.Left = this.Left + 15;
            backward.Left = open_add.Right + 15;
            forward.Left = backward.Right + 15;
        }
        void LocateAfterAdding()
        {
            exit_button.Top = this.Top - 170;
            exit_button.Left = student_list.Right + 215;
            open_add.Visible = true;
            add_panel.Visible = false;
            open_add.Left = student_list.Left + 15;
            backward.Left = open_add.Right + 15;
            forward.Left = backward.Right + 15;
        }
        void Locate()
        {
            open_add.Visible = false;
            add_panel.Visible = true;
            backward.Left = student_list.Left + 15;
            forward.Left = backward.Right + 15;
            exit_button.Location = new Point(989, 1);
        }
        bool CheckChanged()
        {
            if (changeName.Text != student_list.CurrentRow.Cells[1].Value.ToString() || changeSurname.Text != student_list.CurrentRow.Cells[2].Value.ToString() || changePhoneNumber.Text != student_list.CurrentRow.Cells[3].Value.ToString()
               || changeLanguage.Text != student_list.CurrentRow.Cells[4].Value.ToString() || changeAge.Text != student_list.CurrentRow.Cells[7].Value.ToString() || changeLevel.Text != student_list.CurrentRow.Cells[5].Value.ToString()
                || changeGroup.Text != student_list.CurrentRow.Cells[6].Value.ToString() || changeCameLessons.Text != "0" || paymentTxb.Text != "0")
            {
                return true;
            }
            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            exit_button.Top = this.Top + 1;
            exit_button.Left = this.Right - 36;
            add_panel.Visible = false;
            change_panel.Visible = false;
            processing_panel.Visible = true;
            this.Enabled = false;

            List<StudentDatas> students = (List<StudentDatas>)saver.GetCurrentTableList();

            StudentAdmin.SaveAll(students, firstStudents);

            Thread.Sleep(3000);

            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }
        private void open_add_Click(object sender, EventArgs e)
        {
            Locate();
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }

        private void add_student_btn_Click(object sender, EventArgs e)
        {
            LocateAfterAdding();
            try
            {
                if (Check())
                {
                    DataTable table = saver.ConvertToTable(student_list);
                    table.Rows.Add(index, nameTxb.Text, surnameTxb.Text, phoneNumberTxb.Text, languageTxb.Text, levelTxb.Text, groupTxb.Text, ageTxb.Text, bonusTxb.Text, commentTxb.Text, DateTime.Now.Date, StudentAdmin.CultivateDept(Convert.ToDouble(cameLessonsTxb.Text), 0, groupTxb.Text, Convert.ToDouble(bonusTxb.Text)), 0, 0, 0);
                    index++;
                    student_list.DataSource = table;
                    saver.AddTable(table);
                    backward.Enabled = true;
                    forward.Enabled = false;
                    ClearIt();
                }
                else MessageBox.Show("Fill places correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cameLessonsTxb.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void changeStudent_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check_Change())
                {
                    if (CheckChanged())
                    {
                        change_panel.Visible = false;

                        double lastDept = Convert.ToDouble(student_list.CurrentRow.Cells[11].Value);
                        double newDept;
                        student_list.CurrentRow.Cells[11].Value = newDept = StudentAdmin.CultivateDept(Convert.ToInt32(changeCameLessons.Text), lastDept, changeGroup.Text, Convert.ToDouble(changeBonus.Text));

                        double lastStock = Convert.ToDouble(student_list.CurrentRow.Cells[13].Value);
                        double currentStock = Convert.ToDouble(paymentTxb.Text);
                        double allStock = lastStock + currentStock;

                        double paid = Convert.ToDouble(student_list.CurrentRow.Cells[12].Value);
                        StudentAdmin.CultivatePaid(ref allStock, ref paid, newDept);

                        student_list.CurrentRow.Cells[12].Value = paid;
                        student_list.CurrentRow.Cells[13].Value = allStock;

                        student_list.CurrentRow.Cells[1].Value = changeName.Text;
                        student_list.CurrentRow.Cells[2].Value = changeSurname.Text;
                        student_list.CurrentRow.Cells[3].Value = changePhoneNumber.Text;
                        student_list.CurrentRow.Cells[4].Value = changeLanguage.Text;
                        student_list.CurrentRow.Cells[7].Value = changeAge.Text;
                        student_list.CurrentRow.Cells[5].Value = changeLevel.Text;
                        student_list.CurrentRow.Cells[8].Value = changeBonus.Text;
                        student_list.CurrentRow.Cells[9].Value = changeComment.Text;
                        student_list.CurrentRow.Cells[6].Value = changeGroup.Text;

                        DataTable table = saver.ConvertToTable(student_list);
                        saver.AddTable(table);
                        backward.Enabled = true;
                        forward.Enabled = false;
                    }
                }
                else
                    MessageBox.Show("Fill the places correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LocateAfterAdding();
                changeCameLessons.Text = "0";
                paymentTxb.Text = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("Group not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void deleteStudent_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to remove this student?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            int studentId = Convert.ToInt32(student_list.CurrentRow.Cells[0].Value);
            List<StudentDatas> students = saver[saver.Length - 1];

            if (dialogResult == DialogResult.Yes)
            {
                student_list.Rows.Remove(student_list.CurrentRow);
                DataTable table = saver.ConvertToTable(student_list);
                saver.AddTable(table);
                LocateAfterAdding();
                backward.Enabled = true;
                forward.Enabled = false;

                HistoryAdmin admin = new HistoryAdmin();
                StudentDatas student = new StudentDatas();
                foreach (var s in students)
                {
                    if (s.Id == studentId)
                    {
                        student = s;
                        break;
                    }
                }
                admin.StudentRemoved(student);
            }
        }

        private void backward_Click(object sender, EventArgs e)
        {
            List<StudentDatas> lastStudents = GetLastTable();

            bool value = true;
            student_list.DataSource = saver.BackWard(ref value);
            if (value == false)
                backward.Enabled = false;
            forward.Enabled = true;

            List<StudentDatas> newStudents = (List<StudentDatas>)saver.GetCurrentTableList();
            if (newStudents.Count > lastStudents.Count)
            {
                foreach (var newStudent in newStudents)
                {
                    var students = from lS in lastStudents
                                   where lS.Id == newStudent.Id
                                   select lS;
                    if (students.Count() == 0)
                    {
                        HistoryAdmin admin = new HistoryAdmin();
                        admin.StudentBackward(newStudent);
                        break;
                    }
                }
                
            }
        }
        private List<StudentDatas> GetLastTable()
        {
            TableSaver saver = new TableSaver(1);
            saver.AddTable(saver.ConvertToTable(student_list));
            return (List<StudentDatas>)saver.GetCurrentTableList();
        }
        private void forward_Click(object sender, EventArgs e)
        {
            bool value = true;
            student_list.DataSource = saver.Forward(ref value);
            if (value == false)
                forward.Enabled = false;
            backward.Enabled = true;
        }

        private void searchGroup2_Click_1(object sender, EventArgs e)
        {
            string language = changeLanguage.Text;
            string level = changeLevel.Text;
            List<string> groups = StudentAdmin.SearchForGroup(language, level);
            foreach (var group in groups)
            {
                changeGroup.Items.Add(group);
                changeGroup.Text = group;
            }
        }
        private void searchGroup_btn_Click(object sender, EventArgs e)
        {
            string language = languageTxb.Text;
            string level = levelTxb.Text;
            List<string> groups = StudentAdmin.SearchForGroup(language, level);
            foreach (var group in groups)
            {
                groupTxb.Items.Add(group);
                groupTxb.Text = group;
            }
        }
        private void student_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            add_panel.Visible = true;
            change_panel.Visible = true;
            Locate();
            changeName.Text = student_list.CurrentRow.Cells[1].Value.ToString();
            changeSurname.Text = student_list.CurrentRow.Cells[2].Value.ToString();
            changePhoneNumber.Text = student_list.CurrentRow.Cells[3].Value.ToString();
            changeLanguage.Text = student_list.CurrentRow.Cells[4].Value.ToString();
            changeAge.Text = student_list.CurrentRow.Cells[7].Value.ToString();
            changeLevel.Text = student_list.CurrentRow.Cells[5].Value.ToString();
            changeBonus.Text = student_list.CurrentRow.Cells[8].Value.ToString();
            changeComment.Text = student_list.CurrentRow.Cells[9].Value.ToString();
            changeGroup.Text = student_list.CurrentRow.Cells[6].Value.ToString();
        }
        private void search_txb_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager manager = (CurrencyManager)BindingContext[student_list.DataSource];
            manager.SuspendBinding();

            ChangeVisible();

            if (choose_search.Text == "Group Name")
            {
                for (int i = 0; i < student_list.Rows.Count; i++)
                {
                    if (student_list.Rows[i].Cells[6].Value != null && !student_list.Rows[i].Cells[6].Value.ToString().Contains(search_txb.Text))
                    {
                        student_list.Rows[i].Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < student_list.Rows.Count; i++)
                {
                    if (student_list.Rows[i].Cells[1].Value != null && !student_list.Rows[i].Cells[1].Value.ToString().Contains(search_txb.Text))
                    {
                        student_list.Rows[i].Visible = false;
                    }
                }
            }

            if (search_txb.Text == "")
                ChangeVisible();

            manager.ResumeBinding();
        }
        private void ChangeVisible()
        {
            for (int i = 0; i < student_list.Rows.Count; i++)
            {
                student_list.Rows[i].Visible = true;
            }
        }
    }
}
