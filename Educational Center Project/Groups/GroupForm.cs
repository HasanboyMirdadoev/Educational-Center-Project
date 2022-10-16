using Educational_Center_Project.Groups.GroupHelperClasses;
using Educational_Center_Project.OverallProps;
using Educational_Center_Project.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Educational_Center_Project.Groups
{
    public partial class GroupForm : Form
    {
        List<int> studentCahgedIndexes;
        int index = 0;
        TableSaver saver;
        StudentTickClass studentTick;
        TableSaver saveStudents;
        string groupName;
        string notif;
        List<StudentDatas> lastStudents;
        public GroupForm()
        {
            InitializeComponent();
            group_list.ColumnHeadersHeight = 21;

            saver = new TableSaver(2);
            saveStudents = new TableSaver(1);
            studentCahgedIndexes = new List<int>();

            DataTable table = GroupAdmin.DisplayGroupList(group_list, "SELECT * FROM `groupdatas`");
            saver.AddTable(table);

            DataTable studentTable = BaseDB.GetStudentDatasTable();
            saveStudents.AddTable(studentTable);
            lastStudents = (List<StudentDatas>)saveStudents.GetCurrentTableList();

            GetIndex();

            exit_button.Top = background.Top + 1;
            exit_button.Left = background.Right - 36;

            backward.Enabled = false;
            forward.Enabled = false;
            add_panel.Visible = false;
            change_panel.Visible = false;
            studentTick_panel.Visible = false;
            changeStudents_panel.Visible = false;
            processing_panel.Visible = false;
        }
        public GroupForm(string notif)
        {
            InitializeComponent();
            group_list.ColumnHeadersHeight = 21;

            saver = new TableSaver(2);
            saveStudents = new TableSaver(1);
            studentCahgedIndexes = new List<int>();

            DataTable table = GroupAdmin.DisplayGroupList(group_list, "SELECT * FROM `groupdatas`");
            saver.AddTable(table);

            DataTable studentTable = BaseDB.GetStudentDatasTable();
            saveStudents.AddTable(studentTable);

            GetIndex();
            this.notif = notif;


            exit_button.Top = background.Top + 1;
            exit_button.Left = background.Right - 36;

            backward.Enabled = false;
            forward.Enabled = false;
            add_panel.Visible = false;
            change_panel.Visible = false;
            studentTick_panel.Visible = false;
            changeStudents_panel.Visible = false;
            processing_panel.Visible = false;
        }
        void DoNotif()
        {
            string groupName = notif.Split(' ')[1];
            search_txb.Text = groupName;
        }
        bool Check()
        {
            return name_txb.Text != string.Empty && level_txb.Text != string.Empty && cost_txb.Text != string.Empty && class_txb.Text != string.Empty && lessonTime_txb.Text != string.Empty && language_txb.Text != string.Empty && teacherId_txb.Text != string.Empty && lessonDays_txb.Text != string.Empty;
        }
        void GetIndex()
        {
            foreach (DataGridViewRow row in group_list.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) > index)
                    index = Convert.ToInt32(row.Cells[0].Value);
            }
            index++;
        }
        void ClearAll()
        {
            name_txb.Text = level_txb.Text = lessonDays_txb.Text = language_txb.Text = cost_txb.Text = class_txb.Text = lessonTime_txb.Text = teacherId_txb.Text = teacherName_txb.Text = string.Empty;
        }
        bool CheckEquality()
        {
            if (change_name.Text == group_list.CurrentRow.Cells[1].Value.ToString() &&
                change_level.Text == group_list.CurrentRow.Cells[2].Value.ToString() &&
                change_lessonDays.Text == group_list.CurrentRow.Cells[3].Value.ToString() &&
                change_cost.Text == group_list.CurrentRow.Cells[4].Value.ToString() &&
                change_class.Text == group_list.CurrentRow.Cells[5].Value.ToString() &&
                change_lessonTime.Text == group_list.CurrentRow.Cells[6].Value.ToString() &&
                change_language.Text == group_list.CurrentRow.Cells[7].Value.ToString() &&
                change_teacherId.Text == group_list.CurrentRow.Cells[8].Value.ToString() &&
                change_teacherName.Text == group_list.CurrentRow.Cells[9].Value.ToString() &&
                change_cameLessons.Text == "0")
                return false;
            else return true;
        }
        void LocateAfterAdding()
        {
            add_panel.Visible = false;
            open_add.Visible = true;
            exit_button.Top = background.Top + 1;
            exit_button.Left = background.Right - 36;
        }
        void ChangeVisible()
        {
            for (int i = 0; i < group_list.Rows.Count; i++)
            {
                group_list.Rows[i].Visible = true;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            add_panel.Visible = false;
            change_panel.Visible = false;
            studentTick_panel.Visible = false;
            changeStudents_panel.Visible = false;

            exit_button.Top = background.Top + 1;
            exit_button.Left = background.Right - 36;

            processing_panel.Visible = true;
            this.Enabled = false;
            List<GroupDatas> groups = (List<GroupDatas>)saver.GetCurrentTableList();

            List<StudentDatas> studentDatas = (List<StudentDatas>)saveStudents.GetCurrentTableList();
            StudentAdmin.SaveAll(studentDatas, groups, lastStudents);


            Thread.Sleep(3000);

            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }
        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }
        private void open_add_Click(object sender, EventArgs e)
        {
            add_panel.Visible = true;
            exit_button.Top = group_list.Top - 100;
            exit_button.Left = group_list.Right - 36;
        }

        private void add_student_btn_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                DataTable table = saver.ConvertToTable(group_list);
                table.Rows.Add(index, name_txb.Text, level_txb.Text, lessonDays_txb.Text, cost_txb.Text, class_txb.Text, lessonTime_txb.Text, language_txb.Text, teacherId_txb.Text, teacherName_txb.Text, 0, 0, 0, DateTime.Today.ToString());
                group_list.DataSource = table;
                saver.AddTable(table);
                ClearAll();
                backward.Enabled = true;
                index++;
                MessageBox.Show("Group added succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fill places correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LocateAfterAdding();
        }
        private void change_group_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckEquality())
                {
                    groupName = change_name.Text;
                    group_list.CurrentRow.Cells[1].Value = change_name.Text;
                    group_list.CurrentRow.Cells[2].Value = change_level.Text;
                    group_list.CurrentRow.Cells[3].Value = change_lessonDays.Text;
                    group_list.CurrentRow.Cells[4].Value = change_cost.Text;
                    group_list.CurrentRow.Cells[5].Value = change_class.Text;
                    group_list.CurrentRow.Cells[6].Value = change_lessonTime.Text;
                    group_list.CurrentRow.Cells[7].Value = change_language.Text;
                    group_list.CurrentRow.Cells[8].Value = change_teacherId.Text;
                    group_list.CurrentRow.Cells[9].Value = change_teacherName.Text;

                    try
                    {
                        int lastCount = Convert.ToInt32(group_list.CurrentRow.Cells[12].Value);
                        group_list.CurrentRow.Cells[12].Value = lastCount + Convert.ToInt32(change_cameLessons.Text);
                    }
                    catch (Exception)
                    {

                    }

                    DataTable table = saver.ConvertToTable(group_list);
                    saver.AddTable(table);
                    backward.Enabled = true;
                    forward.Enabled = false;
                }

                if (Convert.ToInt32(change_cameLessons.Text) > 0)
                {
                    studentTick = new StudentTickClass(change_name.Text, Convert.ToInt32(change_cameLessons.Text), ref student_list, saveStudents);
                    changeStudents_panel.Visible = true;
                    studentTick_panel.Visible = true;
                    studentCahgedIndexes.Add(saver.index);
                }
                else
                {
                    change_panel.Visible = false;
                    add_panel.Visible = false;
                }
                change_cameLessons.Text = "0";
                exit_button.Top = background.Top + 1;
                exit_button.Left = background.Right - 36;
            }
            catch (Exception)
            {
                MessageBox.Show("Fill places correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            DataTable table = studentTick.SaveTicks(student_list, saveStudents.GetTable());
            saveStudents.AddTable(table);

            ChangeGroupIncome();

            MessageBox.Show("Group changed succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            change_panel.Visible = false;
            add_panel.Visible = false;
            LocateAfterAdding();
            studentTick_panel.Visible = false;
            changeStudents_panel.Visible = false;
        }
        private void delete_group_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete this group?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                group_list.Rows.Remove(group_list.CurrentRow);

                changeStudents_panel.Visible = true;
                studentTick_panel.Visible = false;
                DeleteOrChangeStudents.FillTable(ref delete_change_list, saveStudents, change_name.Text);

                backward.Enabled = true;
                forward.Enabled = false;
            }
        }
        private void save_deletes_btn_Click(object sender, EventArgs e)
        {
            if (DeleteOrChangeStudents.Check(delete_change_list, group_list, saver))
            {
                DeleteOrChangeStudents.SaveChanges(delete_change_list, saveStudents, group_list, saver);
                ChangeGroupStudentCount();

                DataTable table = saver.ConvertToTable(group_list);
                saver.AddTable(table);
                studentCahgedIndexes.Add(saver.index);

                MessageBox.Show("Group deleted succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                change_panel.Visible = false;
                add_panel.Visible = false;
                LocateAfterAdding();
                studentTick_panel.Visible = false;
                changeStudents_panel.Visible = false;

            }
        }

        private void backward_Click(object sender, EventArgs e)
        {
            bool value = true;
            DataTable table = saver.BackWard(ref value);
            if (!value)
                backward.Enabled = false;
            forward.Enabled = true;
            group_list.DataSource = table;
            foreach (int index in studentCahgedIndexes)
            {
                if (saver.index == index - 1)
                {
                    saveStudents.index--;
                }
            }
        }
        private void forward_Click(object sender, EventArgs e)
        {
            bool value = true;
            DataTable table = saver.Forward(ref value);
            if (value == false)
                forward.Enabled = false;
            backward.Enabled = true;
            group_list.DataSource = table;

            foreach (int index in studentCahgedIndexes)
            {
                if (saver.index == index)
                    saveStudents.index++;
            }
        }

        private void change_teacherId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(change_teacherId.Text);
                string teacherName = GroupAdmin.FindUpTeacher(id);
                change_teacherName.Text = teacherName;
            }
            catch (Exception)
            {
                change_teacherName.Text = "Teacher not found";
            }
        }
        private void teacherId_txb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(teacherId_txb.Text);
                string teacherName = GroupAdmin.FindUpTeacher(id);
                teacherName_txb.Text = teacherName;
            }
            catch (Exception)
            {
                teacherName_txb.Text = "Teacher not found";
            }
        }
        private void search_txb_TextChanged(object sender, EventArgs e)
        {
            SearchGroup();
        }

        void SearchGroup()
        {
            CurrencyManager manager = (CurrencyManager)BindingContext[group_list.DataSource];
            manager.SuspendBinding();

            ChangeVisible();

            if (choose_search.Text == "Group Name")
            {
                for (int i = 0; i < group_list.Rows.Count; i++)
                {
                    if (group_list.Rows[i].Cells[1].Value != null && !group_list.Rows[i].Cells[1].Value.ToString().Contains(search_txb.Text))
                    {
                        group_list.Rows[i].Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < group_list.Rows.Count; i++)
                {
                    if (group_list.Rows[i].Cells[9].Value != null && !group_list.Rows[i].Cells[9].Value.ToString().Contains(search_txb.Text))
                    {
                        group_list.Rows[i].Visible = false;
                    }
                }
            }

            if (search_txb.Text == "")
                ChangeVisible();

            manager.ResumeBinding();
        }

        private void group_list_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            add_panel.Visible = true;
            change_panel.Visible = true;
            exit_button.Location = new Point(987, 4);
            change_name.Text = group_list.CurrentRow.Cells[1].Value.ToString();
            change_level.Text = group_list.CurrentRow.Cells[2].Value.ToString();
            change_lessonDays.Text = group_list.CurrentRow.Cells[3].Value.ToString();
            change_cost.Text = group_list.CurrentRow.Cells[4].Value.ToString();
            change_class.Text = group_list.CurrentRow.Cells[5].Value.ToString();
            change_lessonTime.Text = group_list.CurrentRow.Cells[6].Value.ToString();
            change_language.Text = group_list.CurrentRow.Cells[7].Value.ToString();
            change_teacherId.Text = group_list.CurrentRow.Cells[8].Value.ToString();
            change_teacherName.Text = group_list.CurrentRow.Cells[9].Value.ToString();
        }
        private void ChangeGroupIncome()
        {
            List<StudentDatas> students = (List<StudentDatas>)saveStudents.GetCurrentTableList();
            double income = 0;
            foreach (var student in students)
            {
                if (student.Group == groupName)
                {
                    income += student.Paid;
                }
            }
            foreach (DataGridViewRow row in group_list.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == groupName)
                {
                    row.Cells[11].Value = income;
                }
            }
        }
        private void ChangeGroupStudentCount()
        {
            List<StudentDatas> students = (List<StudentDatas>)saveStudents.GetCurrentTableList();
            double studentCount = 0;
            foreach (var student in students)
            {
                if (student.Group == groupName)
                {
                    studentCount++;
                }
            }
            foreach (DataGridViewRow row in group_list.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == groupName)
                {
                    row.Cells[10].Value = studentCount;
                }
            }
        }
        private void GroupForm_Load(object sender, EventArgs e)
        {
            if (notif != null)
                DoNotif();
        }
    }
}
