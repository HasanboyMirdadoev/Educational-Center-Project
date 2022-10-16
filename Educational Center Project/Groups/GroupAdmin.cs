using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Educational_Center_Project.Teachers;
using Educational_Center_Project.OverallProps;

namespace Educational_Center_Project.Groups
{
    class GroupAdmin
    {
        public static void UpdateGroups(List<GroupDatas> groups)
        {
            GroupDB.DeleteAll();
            List<TeacherDatas> teachers = UpdateTeachers(groups);
            TeacherDB.DeleteAll();
            TeacherDB.AddAll(teachers);
        }
        public static List<TeacherDatas> UpdateTeachers(List<GroupDatas> groups)
        {
            List<TeacherDatas> teachers = GetTeachersList();
            int counter = 0;
            foreach (var teacher in teachers)
            {
                int studentCount = 0;
                int groupCount = 0;
                double income = 0;
                int lessonCount = 0;
                foreach (var group in groups)
                {
                    if (teacher.Id == group.TeacherId)
                    {
                        studentCount += group.StudentCount;
                        groupCount++;
                        income += group.Income;
                        lessonCount += group.LessonCount;
                        if (counter == 0)
                            GroupDB.AddGroup(group);
                    }
                }
                teacher.StudentCount = studentCount;
                teacher.GroupCount = groupCount;
                teacher.Income = income;
                teacher.LessonCount = lessonCount;
                counter++;
            }
            return teachers;
        }
        public static DataTable DisplayGroupList(DataGridView group_list, string comm)
        {
            DataTable table = BaseDB.GetGroupTable();
            group_list.DataSource = table;
            TableColor(group_list);
            return table;
        }
        static void TableColor(DataGridView table)
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
        static List<TeacherDatas> GetTeachersList()
        {
            TableSaver saver = new TableSaver(3);
            DataTable table = BaseDB.GetTeacherDatasTable();
            saver.AddTable(table);
            List<TeacherDatas> teachers = (List<TeacherDatas>)saver.GetCurrentTableList();
            return teachers;
        }
        public static string FindUpTeacher(int id)
        {
            DataTable table = BaseDB.GetTeacherDatasTable();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == id)
                {
                    return row["Name"].ToString();
                }
            }
            return "";
        }
    }
}
