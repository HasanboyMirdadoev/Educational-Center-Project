using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Educational_Center_Project.OverallProps;
using Educational_Center_Project.HistoryFolder;

namespace Educational_Center_Project.Students
{
    class StudentDB : BaseDB
    {
        static HistoryAdmin historyAdmin = new HistoryAdmin();
        public static void SaveChanges(List<StudentDatas> lastStudents, List<StudentDatas> newStudents)
        {
            foreach (var lastStudent in lastStudents)
            {
                var list = from s in newStudents
                           where s.Id == lastStudent.Id
                           select s;
                if (list.Count() == 0)
                {
                    DeleteStudents(lastStudent);
                }
                else
                {
                    UpdateStudent(list.First());
                }
            }
            List<int> addedStudentIndexes = new List<int>();
            int counter = -1;
            foreach (var newStudent in newStudents)
            {
                counter++;
                var list = from s in lastStudents
                           where s.Id == newStudent.Id
                           select s;

                if (list.Count() == 0)
                {
                    AddStudent(newStudent);
                    addedStudentIndexes.Add(counter);
                }
            }

            DataTable data = BaseDB.GetStudentDatasTable();
            TableSaver saver = new TableSaver(1);
            saver.AddTable(data);
            List<StudentDatas> students = (List<StudentDatas>)saver.GetCurrentTableList();
            foreach (var index in addedStudentIndexes)
            {
                historyAdmin.StudentAdded(students[index]);
            }
        }
        public static void AddStudent(StudentDatas student)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[studentdatas] VALUES (@name,@surname,@phoneNumber,@language,@level,@group,@age,@bonus,@comment,@lastPaymet,@hasToPay,@paid,@stock,@lastExamScore)", GetConnection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = student.Name;
            command.Parameters.Add("@surname", SqlDbType.VarChar).Value = student.Surname;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = student.PhoneNumber;
            command.Parameters.Add("@language", SqlDbType.VarChar).Value = student.Language;
            command.Parameters.Add("@level", SqlDbType.VarChar).Value = student.Level;
            command.Parameters.Add("@group", SqlDbType.VarChar).Value = student.Group;
            command.Parameters.Add("@age", SqlDbType.VarChar).Value = student.Age;
            command.Parameters.Add("@bonus", SqlDbType.VarChar).Value = student.Bonus;
            command.Parameters.Add("@comment", SqlDbType.VarChar).Value = student.Comment;
            command.Parameters.Add("@lastPaymet", SqlDbType.DateTime).Value = student.LastPaymet;
            command.Parameters.Add("@hasToPay", SqlDbType.Float).Value = student.HasToPay;
            command.Parameters.Add("@paid", SqlDbType.Float).Value = student.Paid;
            command.Parameters.Add("@stock", SqlDbType.Float).Value = student.Stock;
            command.Parameters.Add("@lastExamScore", SqlDbType.Int).Value = student.LastExamScore;

            command.ExecuteNonQuery();
            CloseConnection();
        }
        private static void UpdateStudent(StudentDatas student)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("Update [dbo].[studentdatas] set Name= @name, Surname= @surname, PhoneNumber= @phoneNumber, Language= @language, Level= @level, [Group]= @group, Age= @age, Bonus= @bonus, Comment= @comment, LastPayment= @lastPaymet, HasToPay= @hasToPay, Paid= @paid, Stock= @stock, LastExamScore= @lastExamScore Where Id=@id", GetConnection);
            command.Parameters.AddWithValue("@id", student.Id);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = student.Name;
            command.Parameters.Add("@surname", SqlDbType.VarChar).Value = student.Surname;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = student.PhoneNumber;
            command.Parameters.Add("@language", SqlDbType.VarChar).Value = student.Language;
            command.Parameters.Add("@level", SqlDbType.VarChar).Value = student.Level;
            command.Parameters.Add("@group", SqlDbType.VarChar).Value = student.Group;
            command.Parameters.Add("@age", SqlDbType.VarChar).Value = student.Age;
            command.Parameters.Add("@bonus", SqlDbType.VarChar).Value = student.Bonus;
            command.Parameters.Add("@comment", SqlDbType.VarChar).Value = student.Comment;
            command.Parameters.Add("@lastPaymet", SqlDbType.DateTime).Value = student.LastPaymet;
            command.Parameters.Add("@hasToPay", SqlDbType.Float).Value = student.HasToPay;
            command.Parameters.Add("@paid", SqlDbType.Float).Value = student.Paid;
            command.Parameters.Add("@stock", SqlDbType.Float).Value = student.Stock;
            command.Parameters.Add("@lastExamScore", SqlDbType.Int).Value = student.LastExamScore;
            int a = command.ExecuteNonQuery();
            CloseConnection();
        }
        private static void DeleteStudents(StudentDatas student)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("DELETE [dbo].[studentdatas] where Id=@id", GetConnection);
            command.Parameters.AddWithValue("@id", student.Id);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public static void UpdateStudent(StudentDatas student, int index)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("UPDATE studentdatas SET Name= @name, Surname= @surname, PhoneNumber= @phoneNumber, Language= @language, Level= @level, [Group]= @group, Age= @age, Bonus= @bonus, Comment= @comment, LastPayment= @lastPaymet, HasToPay= @hasToPay, Paid= @paid, Stock= @stock, LastExamScore= @lastExamScore WHERE Id=@id", GetConnection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = student.Name;
            command.Parameters.Add("@surname", SqlDbType.VarChar).Value = student.Surname;
            command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = student.PhoneNumber;
            command.Parameters.Add("@language", SqlDbType.VarChar).Value = student.Language;
            command.Parameters.Add("@level", SqlDbType.VarChar).Value = student.Level;
            command.Parameters.Add("@group", SqlDbType.VarChar).Value = student.Group;
            command.Parameters.Add("@age", SqlDbType.VarChar).Value = student.Age;
            command.Parameters.Add("@bonus", SqlDbType.VarChar).Value = student.Bonus;
            command.Parameters.Add("@comment", SqlDbType.VarChar).Value = student.Comment;
            command.Parameters.Add("@lastPaymet", SqlDbType.DateTime).Value = student.LastPaymet;
            command.Parameters.Add("@hasToPay", SqlDbType.Float).Value = student.HasToPay;
            command.Parameters.Add("@paid", SqlDbType.Float).Value = student.Paid;
            command.Parameters.Add("@stock", SqlDbType.Float).Value = student.Stock;
            command.Parameters.Add("@lastExamScore", SqlDbType.Int).Value = student.LastExamScore;
            command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;

            command.ExecuteNonQuery();
            CloseConnection();
        }

    }
}
