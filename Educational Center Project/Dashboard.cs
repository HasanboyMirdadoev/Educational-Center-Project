using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Educational_Center_Project.AddNotes;
using Educational_Center_Project.OverallProps;
using Educational_Center_Project.Groups;
using Educational_Center_Project.Teachers;
using Educational_Center_Project.Students;
using Educational_Center_Project.TimeTables;
using Educational_Center_Project.TotalResultFile;
using Educational_Center_Project.OverallProps.DashHelpers.NotificationsFile;
using Educational_Center_Project.HistoryFolder;
using Educational_Center_Project.RegisterCenter;

namespace Educational_Center_Project
{
    public partial class Dashboard : Form
    {
        DashSortNotes dashSortNotes;
        public Dashboard()
        {
            InitializeComponent();
            dashSortNotes = new DashSortNotes();
            dashSortNotes.GetTodaysNotes(GetPanels(), dashSortNotes);
            notifications_number.Visible = false;
        }
        List<Panel> GetPanels()
        {
            List<Panel> panels = new List<Panel>();
            panels.Add(note1);
            panels.Add(note2);
            panels.Add(note3);
            panels.Add(note4);
            panels.Add(note5);
            panels.Add(note6);
            panels.Add(note7);
            panels.Add(note8);
            panels.Add(note9);

            return panels;
        }
        private void DeleteNotes()
        {
            BaseDB.OpenConnection();
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[messages]", BaseDB.GetConnection);
            command.ExecuteNonQuery();
            BaseDB.CloseConnection();
        }
        private int GetNoneTeacherGroups()
        {
            DeleteNotes();

            DataTable groupTable = BaseDB.GetGroupTable();
            TableSaver groupSaver = new TableSaver(2);
            groupSaver.AddTable(groupTable);
            List<GroupDatas> groups = (List<GroupDatas>)groupSaver.GetCurrentTableList();

            DataTable teachersTable = BaseDB.GetTeacherDatasTable();
            TableSaver teacherSaver = new TableSaver(3);
            teacherSaver.AddTable(teachersTable);
            List<TeacherDatas> teachers = (List<TeacherDatas>)teacherSaver.GetCurrentTableList();

            List<string> messages = new List<string>();
            foreach (var group in groups)
            {
                string notif = "";
                bool hasTeacher = false;
                foreach (var teacher in teachers)
                {
                    if (group.TeacherId == teacher.Id)
                    {
                        hasTeacher = true;
                        break;


                    }
                }
                if (hasTeacher == false)
                {
                    notif += $"Group {group.Name} hasnt teacher";
                    messages.Add(notif);
                }
            }
            if (messages.Count != 0)
            {
                TeacherDB.AddMessages(messages);
            }
            return messages.Count;
        }
        private void student_go_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
        }
        private void group_go_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupForm groupForm = new GroupForm();
            groupForm.Show();
        }
        private void teacher_go_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();
        }
        private void timeTable_go_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTable timeTable = new TimeTable();
            timeTable.Show();
        }
        private void payment_go_Click(object sender, EventArgs e)
        {
            this.Hide();
            TotalResult result = new TotalResult();
            result.Show();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            guna2ShadowDashboard.SetShadowForm(this);
            DataTable table = BaseDB.GetMonthOutcomeTable();
            int counter = 0;
            if (table.Rows.Count != 0)
            {
                string lastMonth = table.Rows[table.Rows.Count - 1]["Date"].ToString();
                string currentMonth = $"{DateTime.Now.Month}.{DateTime.Now.Year}";

                if (DateTime.Now.Day >= 25 && lastMonth != currentMonth)
                {
                    counter++;
                }
            }
            else
            {
                counter++;
            }
            counter += GetNoneTeacherGroups();
            if (counter != 0)
            {
                notifications_number.Visible = true;
                notifications_number.Text = counter.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNotesForm form = new AddNotesForm();
            form.Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notifications notifications = new Notifications();
            notifications.Show();
        }

        private void guna2Button1_MouseHover(object sender, EventArgs e)
        {
            guna2Button1.FillColor = Color.FromArgb(0, 192, 192);
        }
        private void guna2Button1_MouseLeave(object sender, EventArgs e)
        {
            guna2Button1.FillColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HistoryForm historyForm = new HistoryForm();
            historyForm.Show();
        }
    }
}
