using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Educational_Center_Project.OverallProps.DashHelpers.StudentExamScoreFile
{
    class StudentExamScoreAdmin
    {
        public List<StudentExamScoreDatas> GetStudents()
        {
            List<StudentExamScoreDatas> students = new List<StudentExamScoreDatas>();
            DataTable table = BaseDB.GetStudentDatasTable();
            foreach (DataRow row in table.Rows)
            {
                StudentExamScoreDatas student = new StudentExamScoreDatas();
                student.Id = Convert.ToInt32(row["Id"]);
                student.Name = row["Name"].ToString();
                student.Surname = row["Surname"].ToString();
                student.Group = row["Group"].ToString();
                student.ExamScore = 0;
                students.Add(student);
            }
            return students;
        }
        public bool UpdateStudents(List<StudentExamScoreDatas> students)
        {
            foreach (var student in students)
            {
                int bonus = 0;
                string comment = "";
                if (student.ExamScore >= 95)
                {
                    bonus = 50;
                    comment = "Exam 95+";
                }
                else if (student.ExamScore >= 90)
                {
                    bonus = 25;
                    comment = "Exam 90+";
                }
                SqlCommand command = new SqlCommand("UPDATE [dbo].[studentdatas] SET LastExamScore=@examScore,Bonus=@bonus,Comment=@comment WHERE Id=@id", BaseDB.GetConnection);
                command.Parameters.Add("@examSCore", SqlDbType.Float).Value = student.ExamScore;
                command.Parameters.Add("@bonus", SqlDbType.Int).Value =bonus;
                command.Parameters.Add("@comment", SqlDbType.VarChar).Value = comment;
                command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;

                BaseDB.OpenConnection();
                if (command.ExecuteNonQuery() != 1)
                {
                    BaseDB.CloseConnection();
                    return false;
                }
            }
            return true;
        }
    }
}
