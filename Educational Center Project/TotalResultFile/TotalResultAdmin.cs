using Educational_Center_Project.OverallProps;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Educational_Center_Project.TotalResultFile
{
    class TotalResultAdmin
    {
        TotalResultListMaker listMaker;
        public TotalResultAdmin()
        {
            listMaker = new TotalResultListMaker();
        }
        public List<StudentTotalDatas> DisplayStudentsTotal(DataGridView student_list, DataGridView studentsWithDept_list, List<StudentsWithDeptDatas> depts)
        {
            DataTable table = new DataTable();
            table = BaseDB.GetStudentDatasTable();

            List<StudentTotalDatas> students = listMaker.GetStudentTotalDatas(table);
            List<StudentsWithDeptDatas> deptDatas = listMaker.GetStudentWithDeptDatas(students);

            ChangeStudentList(students, student_list);
            ChangeDeptStudentList(deptDatas, studentsWithDept_list);

            depts = deptDatas;
            return students;
        }
        private void ChangeStudentList(List<StudentTotalDatas> students, DataGridView student_list)
        {
            foreach (var student in students)
            {
                student_list.Rows.Add(student.Id, student.Name, student.Surname, student.HasToPay, student.Paid, student.Stock);
            }
        }
        private void ChangeDeptStudentList(List<StudentsWithDeptDatas> students, DataGridView student_list)
        {
            foreach (var student in students)
            {
                student_list.Rows.Add(student.Id, student.Name, student.Surname, student.Dept);
            }
        }

        public List<GroupTotalDatas> DisplayGroupTotal(DataGridView group_list)
        {
            DataTable table = new DataTable();
            table = BaseDB.GetGroupTable();

            List<GroupTotalDatas> groups = listMaker.GetGroupTotalDatas(table);
            ChangeGroupList(groups, group_list);
            return groups;
        }
        private void ChangeGroupList(List<GroupTotalDatas> groups, DataGridView group_list)
        {
            foreach (var group in groups)
            {
                group_list.Rows.Add(group.Id, group.Name, group.LessonCount, group.StudentCount, group.AllPaidStudents, group.Profit);
            }
        }

        public List<TeacherTotalDatas> DisplayTeacherTotal(DataGridView teacher_list)
        {
            DataTable table = new DataTable();
            table = BaseDB.GetTeacherDatasTable();

            List<TeacherTotalDatas> teachers = listMaker.GetTeacherTotalDatas(table);
            ChangeTeacherList(teachers, teacher_list);
            return teachers;
        }
        public List<TeacherTotalDatas> DisplayTeacherTotal()
        {
            DataTable table = new DataTable();
            table = BaseDB.GetTeacherDatasTable();

            List<TeacherTotalDatas> teachers = listMaker.GetTeacherTotalDatas(table);
            return teachers;
        }
        private void ChangeTeacherList(List<TeacherTotalDatas> teachers, DataGridView teacher_list)
        {
            foreach (var teacher in teachers)
            {
                teacher_list.Rows.Add(teacher.Id, teacher.Name, teacher.Surname, teacher.StudentCount, teacher.GroupCount, teacher.LessonCount, teacher.AllPaidStudents, teacher.Profit, teacher.Salary);
            }
        }

    }
}
