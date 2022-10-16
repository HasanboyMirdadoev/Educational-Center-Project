using Educational_Center_Project.OverallProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Educational_Center_Project.TotalResultFile
{
    public partial class TotalResult : Form
    {
        TotalResultAdmin admin;
        MakeCharts makeCharts;
        RefreshAll refresh;
        public TotalResult()
        {
            InitializeComponent();
            totalResult_panel.Visible = false;

            monthes_list.DataSource = BaseDB.GetMonthOutcomeTable();
            year_list.DataSource = BaseDB.GetYearOutcomeTable();

            DisplayTotals();

            makeCharts = new MakeCharts();
            makeCharts.MakeMonthChart(monthChart);
            makeCharts.MakeMonthSeries(monthChart);

            makeCharts.MakeYearChart(year_chart);
            makeCharts.MakeYearSeries(year_chart);
        }
        public TotalResult(int key)
        {
            InitializeComponent();
            totalResult_panel.Visible = false;

            refresh = new RefreshAll();
            refresh.AddNewMonthResult();

            DisplayTotals();

            monthes_list.DataSource = BaseDB.GetMonthOutcomeTable();
            year_list.DataSource = BaseDB.GetYearOutcomeTable();

            makeCharts = new MakeCharts();
            makeCharts.MakeMonthChart(monthChart);
            makeCharts.MakeMonthSeries(monthChart);

            makeCharts.MakeYearChart(year_chart);
            makeCharts.MakeYearSeries(year_chart);
        }
        private void DisplayTotals()
        {
            List<StudentsWithDeptDatas> deptDatas = new List<StudentsWithDeptDatas>();

            admin = new TotalResultAdmin();
            List<StudentTotalDatas> students = admin.DisplayStudentsTotal(student_list, studentsWithDept_list, deptDatas);
            List<GroupTotalDatas> groups = admin.DisplayGroupTotal(group_list);
            List<TeacherTotalDatas> teachers = admin.DisplayTeacherTotal(teacher_list);

            DisplayMonthTotal(students, deptDatas, groups, teachers);
        }
        private void DisplayMonthTotal(List<StudentTotalDatas> students, List<StudentsWithDeptDatas> deptDatas, List<GroupTotalDatas> groups, List<TeacherTotalDatas> teachers)
        {
            studentTotalNumber.Text = $"Total number of students: {students.Count}";
            groupTotalNumber.Text = $"Total number of groups: {groups.Count}";
            teacherTotalNumber.Text = $"Total number of teachers: {teachers.Count}";
            GetStatuses(students.Count, groups.Count, teachers.Count);

            DisplayProfit(teachers);
        }
        private void GetStatuses(int studentCurrenCount, int groupCurrentCount, int teacherCurrentCount)
        {
            string s_status;
            string g_status;
            string t_status;
            DataTable table = BaseDB.GetMonthOutcomeTable();
            if (table.Rows.Count != 0)
            {
                DataRow lastMonth = table.Rows[table.Rows.Count - 1];
                int lastStudentCount = Convert.ToInt32(lastMonth["StudentCount"]);
                int lastGroupCount = Convert.ToInt32(lastMonth["GroupCount"]);
                int lastTeacherCount = Convert.ToInt32(lastMonth["TeacherCount"]);

                int int_s_status = studentCurrenCount - lastStudentCount;
                int int_g_status = groupCurrentCount - lastGroupCount;
                int int_t_status = teacherCurrentCount - lastTeacherCount;

                if (int_s_status > 0) s_status = $"+{int_s_status}";
                else s_status = int_s_status.ToString();

                if (int_g_status > 0) g_status = $"+{int_g_status}";
                else g_status = int_g_status.ToString();

                if (int_t_status > 0) t_status = $"+{int_t_status}";
                else t_status = int_t_status.ToString();
            }
            else
            {
                s_status = $"+{studentCurrenCount}";
                g_status = $"+{groupCurrentCount}";
                t_status = $"+{teacherCurrentCount}";
            }
            studentStatus.Text = s_status;
            groupStatus.Text = g_status;
            teacherStatus.Text = t_status;
        }

        private void DisplayProfit(List<TeacherTotalDatas> teachers)
        {
            double totalProf = 0;
            double teachersSalary = 0;
            foreach (var teacher in teachers)
            {
                totalProf += teacher.Profit;
                teachersSalary += teacher.Salary;
            }
            double pureProf = totalProf - teachersSalary;

            totalProfit_lbl.Text = $"Total Profit: {totalProf}";
            teachersSalary_lbl.Text = $"Tteachers Salary: {teachersSalary}";
            pureProfit_lbl.Text = $"Pure Profit: {pureProf}";

            GetProfStatuses(totalProf, teachersSalary, pureProf);
        }
        private void GetProfStatuses(double currentTotalProfit, double currentTeacherSalary, double currentPureProfit)
        {
            string profit_status;
            string teacherSalary_status;
            string pureProfit_stat;
            DataTable table = BaseDB.GetMonthOutcomeTable();
            if (table.Rows.Count != 0)
            {
                DataRow lastMonth = table.Rows[table.Rows.Count - 1];
                double lastTotalProfit = Convert.ToInt32(lastMonth["TotalProfit"]);
                double lastTeacherSalary = Convert.ToInt32(lastMonth["TotalTeacherSalary"]);
                double lastPureProfit = Convert.ToInt32(lastMonth["PureProfit"]);

                double double_profit_status = currentTotalProfit - lastTotalProfit;
                double double_teacherSalary_status = currentTeacherSalary - lastTeacherSalary;
                double double_pureProfit_status = currentPureProfit - lastPureProfit;

                if (double_profit_status > 0) profit_status = $"+{double_profit_status}";
                else profit_status = double_profit_status.ToString();

                if (double_teacherSalary_status > 0) teacherSalary_status = $"+{double_teacherSalary_status}";
                else teacherSalary_status = double_teacherSalary_status.ToString();

                if (double_pureProfit_status > 0) pureProfit_stat = $"+{double_pureProfit_status}";
                else pureProfit_stat = double_pureProfit_status.ToString();
            }
            else
            {
                profit_status = $"+{currentTotalProfit}";
                teacherSalary_status = $"+{currentTeacherSalary}";
                pureProfit_stat = $"+{currentPureProfit}";
            }
            totalProfit_status.Text = profit_status;
            teachersSalaray_status.Text = teacherSalary_status;
            pureProfit_status.Text = pureProfit_stat;
        }

        private void thisMonth_result_Click(object sender, EventArgs e)
        {
            underButton_line.Left = thisMonth_result.Left;
            thisMonthResult_panel.Visible = true;
            totalResult_panel.Visible = false;

        }
        private void total_result_Click(object sender, EventArgs e)
        {
            underButton_line.Left = total_result.Left;
            thisMonthResult_panel.Visible = true;
            totalResult_panel.Visible = true;
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard form1 = new Dashboard();
            form1.Show();
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
