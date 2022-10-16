using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Educational_Center_Project.Groups;
using Educational_Center_Project.OverallProps;

namespace Educational_Center_Project.Students
{
    class StudentAdmin
    {
        public static void SaveAll(List<StudentDatas> newStudents, List<StudentDatas> lastStudents)
        {
            List<GroupDatas> groupDatas = UpdateGroups(newStudents);
            GroupAdmin.UpdateGroups(groupDatas);
            StudentDB.SaveChanges(lastStudents, newStudents);
        }
        public static void SaveAll(List<StudentDatas> newStudents, List<GroupDatas> groups, List<StudentDatas> lastStudents)
        {
            UpdateGroups(newStudents, ref groups);
            GroupAdmin.UpdateGroups(groups);
            StudentDB.SaveChanges(lastStudents, newStudents);
        }
        public static DataTable DisplayStudentList(DataGridView table)
        {
            DataTable tab = StudentDB.GetStudentDatasTable();
            table.DataSource = tab;
            TableColor(table);
            return tab;
        }
        public static void TableColor(DataGridView table)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                var cellStyle = new DataGridViewCellStyle();
                switch (i % 4)
                {
                    case 0:
                        cellStyle.ForeColor = Color.Fuchsia;
                        break;
                    case 1:
                        cellStyle.ForeColor = Color.Red;
                        break;
                    case 2:
                        cellStyle.ForeColor = Color.FromArgb(0, 192, 0);
                        break;
                    case 3:
                        cellStyle.ForeColor = Color.FromArgb(0, 192, 192);
                        break;
                }
                table.Columns[i].DefaultCellStyle = cellStyle;
            }
        }
        public static List<string> SearchForGroup(string language, string level)
        {
            DataTable table = GroupDB.GetGroupTable();
            List<string> names = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                if (row["Language"].ToString() == language && row["Level"].ToString() == level)
                    names.Add(row["Name"].ToString());
            }
            return names;
        }
        public static double CultivateDept(double cameLessons, double lastDept, string groupName, double skidka)
        {
            try
            {
                double cost = GetCost(groupName);
                lastDept += ((cost - skidka) / 12) * cameLessons;
                return lastDept;
            }
            catch (Exception)
            {
                throw new Exception("Group not found");
            }
        }
        public static void CultivatePaid(ref double stock, ref double paid, double newDept)
        {
            if (stock > newDept - paid)
            {
                double change = newDept - paid;
                stock -= change;
                paid += change;
            }
            else
            {
                paid += stock;
                stock = 0;
            }
        }
        static double GetCost(string groupName)
        {
            try
            {
                int cost = 0;
                DataTable table = GroupDB.GetGroupTable();
                foreach (DataRow row in table.Rows)
                {
                    if (row["Name"].ToString() == groupName)
                        cost = Convert.ToInt32(row["Cost"]);
                }
                return cost;
            }
            catch (Exception)
            {
                throw new Exception("Group not found");
            }
        }

        static List<GroupDatas> UpdateGroups(List<StudentDatas> students)
        {
            DataTable table = GroupDB.GetGroupTable();
            TableSaver save = new TableSaver(2);
            save.AddTable(table);
            List<GroupDatas> groups = (List<GroupDatas>)save.GetCurrentTableList();
            foreach (GroupDatas group in groups)
            {
                int studentCount = 0;
                double income = 0;
                foreach (StudentDatas student in students)
                {
                    if (group.Name == student.Group)
                    {
                        studentCount++;
                        income += student.Paid;
                    }
                }
                group.StudentCount = studentCount;
                group.Income = income;
            }
            return groups;
        }
        static List<GroupDatas> UpdateGroups(List<StudentDatas> students, ref List<GroupDatas> groups)
        {
            foreach (GroupDatas group in groups)
            {
                int studentCount = 0;
                double income = 0;
                foreach (StudentDatas student in students)
                {
                    if (group.Name == student.Group)
                    {
                        studentCount++;
                        income += student.Paid;
                    }
                }
                group.StudentCount = studentCount;
                group.Income = income;
            }
            return groups;
        }
    }
}
