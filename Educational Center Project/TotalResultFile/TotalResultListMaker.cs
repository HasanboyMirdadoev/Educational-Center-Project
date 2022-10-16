using Educational_Center_Project.Groups;
using Educational_Center_Project.OverallProps;
using Educational_Center_Project.Students;
using System;
using System.Collections.Generic;
using System.Data;

namespace Educational_Center_Project.TotalResultFile
{
    class TotalResultListMaker
    {
        public List<StudentTotalDatas> GetStudentTotalDatas(DataTable studentTable)
        {
            List<StudentTotalDatas> students = new List<StudentTotalDatas>();
            foreach (DataRow row in studentTable.Rows)
            {
                StudentTotalDatas student = new StudentTotalDatas();
                student.Id = Convert.ToInt32(row["Id"]);
                student.Name = row["Name"].ToString();
                student.Surname = row["Surname"].ToString();
                student.HasToPay = Convert.ToDouble(row["HasToPay"]);
                student.Paid = Convert.ToDouble(row["PAid"]);
                student.Stock = Convert.ToDouble(row["Stock"]);
                students.Add(student);
            }
            return students;
        }
        public List<StudentsWithDeptDatas> GetStudentWithDeptDatas(List<StudentTotalDatas> students)
        {
            List<StudentsWithDeptDatas> deptDatas = new List<StudentsWithDeptDatas>();
            foreach (var student in students)
            {
                if (student.HasToPay > student.Paid)
                {
                    StudentsWithDeptDatas student1 = new StudentsWithDeptDatas();
                    student1.Id = student.Id;
                    student1.Name = student.Name;
                    student1.Surname = student.Surname;
                    student1.Dept = student.HasToPay - student.Paid;
                    deptDatas.Add(student1);
                }
            }
            return deptDatas;
        }
        public List<GroupTotalDatas> GetGroupTotalDatas(DataTable groupTable)
        {
            List<GroupTotalDatas> groups = new List<GroupTotalDatas>();
            foreach (DataRow row in groupTable.Rows)
            {
                GroupTotalDatas group = new GroupTotalDatas();
                group.Id = Convert.ToInt32(row["Id"]);
                group.Name = row["Name"].ToString();
                group.LessonCount = Convert.ToInt32(row["LessonCount"]);
                group.StudentCount = Convert.ToInt32(row["StudentCount"]);
                group.AllPaidStudents = GetAllPaidStudents(GetStudentList(), group.Name);
                group.Profit = Convert.ToDouble(row["Income"]);
                groups.Add(group);
            }
            return groups;
        }
        private int GetAllPaidStudents(List<StudentDatas> students, string group)
        {
            int counter = 0;
            foreach (var student in students)
            {
                if (student.Group == group && student.HasToPay == student.Paid)
                {
                    counter++;
                }
            }
            return counter;
        }
        public List<TeacherTotalDatas> GetTeacherTotalDatas(DataTable teacherTable)
        {
            List<TeacherTotalDatas> teachers = new List<TeacherTotalDatas>();
            foreach (DataRow row in teacherTable.Rows)
            {
                TeacherTotalDatas teacher = new TeacherTotalDatas();
                teacher.Id = Convert.ToInt32(row["Id"]);
                teacher.Name = row["Name"].ToString();
                teacher.Surname = row["Surname"].ToString();
                teacher.StudentCount = Convert.ToInt32(row["StudentCount"]);
                teacher.GroupCount = Convert.ToInt32(row["GroupCount"]);
                teacher.LessonCount = Convert.ToInt32(row["LessonCount"]);
                teacher.AllPaidStudents = GetAllPaidStudentsTeacher(GetGroupList(), teacher.Id);
                teacher.Profit = Convert.ToDouble(row["Income"]);
                teacher.Salary = CultivateTeachersSalary(teacher.Profit, Convert.ToDouble(row["SalaryPercent"]));
                teachers.Add(teacher);
            }
            return teachers;
        }
        private int GetAllPaidStudentsTeacher(List<GroupDatas> groups, int id)
        {
            int counter = 0;
            foreach (var group in groups)
            {
                if (group.TeacherId == id)
                {
                    counter += GetAllPaidStudents(GetStudentList(), group.Name);
                }
            }
            return counter;
        }
        private List<StudentDatas> GetStudentList()
        {
            DataTable table = BaseDB.GetStudentDatasTable();
            TableSaver saver = new TableSaver(1);
            saver.AddTable(table);
            List<StudentDatas> students = (List<StudentDatas>)saver.GetCurrentTableList();
            return students;
        }
        private List<GroupDatas> GetGroupList()
        {
            DataTable table = BaseDB.GetGroupTable();
            TableSaver saver = new TableSaver(2);
            saver.AddTable(table);
            List<GroupDatas> groups = (List<GroupDatas>)saver.GetCurrentTableList();
            return groups;
        }
        private double CultivateTeachersSalary(double profit, double salaryPercent)
        {
            double salary = (profit / 100) * salaryPercent;
            return salary;
        }
    }
}
