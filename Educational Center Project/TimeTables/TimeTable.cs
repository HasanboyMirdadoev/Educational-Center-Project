using Educational_Center_Project.Groups;
using Educational_Center_Project.OverallProps;
using Educational_Center_Project.Teachers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Educational_Center_Project.TimeTables
{
    public partial class TimeTable : Form
    {
        object[,] panels = new object[5, 6];
        Dictionary<string, int> classes = new Dictionary<string, int>();
        Dictionary<string, int> days = new Dictionary<string, int>();
        TimeTableMaker maker;
        Dictionary<string, int> otherClasses = new Dictionary<string, int>();
        Dictionary<string, int> otherDays = new Dictionary<string, int>();
        public TimeTable()
        {
            InitializeComponent();

            maker = new TimeTableMaker();

            classes.Add("Mars", 0);
            classes.Add("Jupiter", 1);
            classes.Add("Saturn", 2);
            classes.Add("Mercury", 3);
            classes.Add("Neptune", 4);

            days.Add("Mon", 0);
            days.Add("Tue", 1);
            days.Add("Wed", 2);
            days.Add("Thu", 3);
            days.Add("Fri", 4);
            days.Add("Sat", 5);

            otherClasses.Add("Mars", 4);
            otherClasses.Add("Jupiter", 3);
            otherClasses.Add("Saturn", 2);
            otherClasses.Add("Mercury", 1);
            otherClasses.Add("Neptune", 0);

            otherDays.Add("Mon", 5);
            otherDays.Add("Tue", 4);
            otherDays.Add("Wed", 3);
            otherDays.Add("Thu", 2);
            otherDays.Add("Fri", 1);
            otherDays.Add("Sat", 0);

            Filler();

            DataTable table = BaseDB.GetGroupTable();

            TableSaver saver = new TableSaver(2);
            saver.AddTable(table);
            List<GroupDatas> groups = (List<GroupDatas>)saver.GetCurrentTableList();

            foreach (var group in groups)
            {
                ButtonMaker(group, panels, 0);
            }

            DataTable teacherTable = BaseDB.GetTeacherDatasTable();

            TableSaver tableSaver = new TableSaver(3);
            tableSaver.AddTable(teacherTable);
            List<TeacherDatas> teachers = (List<TeacherDatas>)tableSaver.GetCurrentTableList();

            foreach (var teacher in teachers)
            {
                var page = maker.MakePages(teacher.Name);
                controls.TabPages.Add(page);
                var buttons = maker.MakePanels(teacher.Name, ref page);
                foreach (var group in groups)
                {
                    if (group.TeacherId == teacher.Id)
                    {
                        ButtonMaker(group, buttons, 1);
                    }
                }
            }
        }
        private void Filler()
        {
            panels[0, 0] = panel16;
            panels[0, 1] = panel17;
            panels[0, 2] = panel18;
            panels[0, 3] = panel19;
            panels[0, 4] = panel20;
            panels[0, 5] = panel21;

            panels[1, 0] = panel24;
            panels[1, 1] = panel25;
            panels[1, 2] = panel26;
            panels[1, 3] = panel27;
            panels[1, 4] = panel28;
            panels[1, 5] = panel29;

            panels[2, 0] = panel32;
            panels[2, 1] = panel33;
            panels[2, 2] = panel34;
            panels[2, 3] = panel35;
            panels[2, 4] = panel36;
            panels[2, 5] = panel37;

            panels[3, 0] = panel40;
            panels[3, 1] = panel41;
            panels[3, 2] = panel42;
            panels[3, 3] = panel43;
            panels[3, 4] = panel44;
            panels[3, 5] = panel45;

            panels[4, 0] = panel48;
            panels[4, 1] = panel49;
            panels[4, 2] = panel50;
            panels[4, 3] = panel51;
            panels[4, 4] = panel52;
            panels[4, 5] = panel53;
        }
        Random rnd = new Random();
        private void ButtonMaker(GroupDatas groups, object[,] panels, int keyCode)
        {
            int classIndex;
            if (keyCode == 0)
            {
                classIndex = classes[groups.Class];
            }
            else
            {
                classIndex = otherClasses[groups.Class];
            }
            string[] array = groups.LessonDays.Split('/');
            int[] dayIndexes = new int[array.Length];

            Color color = new Color();
            color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

            for (int i = 0; i < array.Length; i++)
            {
                if (keyCode == 0)
                {
                    dayIndexes[i] = days[array[i]];
                }
                else
                {
                    dayIndexes[i] = otherDays[array[i]];
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Button button = new Button();
                PictureBox leftLine = new PictureBox();
                PictureBox rightLine = new PictureBox();
                PictureBox bottomLine = new PictureBox();

                button.Controls.Add(leftLine);
                button.Controls.Add(rightLine);
                button.Controls.Add(bottomLine);

                leftLine.Dock = DockStyle.Left;
                leftLine.Width = 1;
                leftLine.BackColor = Color.Black;

                rightLine.Dock = DockStyle.Right;
                rightLine.Width = 1;
                rightLine.BackColor = Color.Black;

                bottomLine.Dock = DockStyle.Bottom;
                bottomLine.Height = 1;
                bottomLine.BackColor = Color.Black;

                button.Dock = DockStyle.Top;
                button.ForeColor = Color.White;
                button.BackColor = color;
                button.Text = $"{groups.Name} - {groups.LessonTime} - {groups.Teacher}";
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Century Gothic", 11, FontStyle.Bold);
                button.Height = 60;
                button.Click += new EventHandler(Group_Click);

                ((Panel)panels[classIndex, dayIndexes[i]]).Controls.Add(button);
            }
        }
        private void Group_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text.Split(' ')[1];
            foreach (var page in controls.TabPages)
            {
                if (((TabPage)page).Text == name)
                {
                    controls.SelectedTab = (TabPage)page;
                }
            }
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard form = new Dashboard();
            form.Show();
        }
        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }
    }
}
