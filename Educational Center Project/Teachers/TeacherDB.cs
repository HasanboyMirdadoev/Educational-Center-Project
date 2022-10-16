using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Educational_Center_Project.OverallProps;

namespace Educational_Center_Project.Teachers
{
    class TeacherDB : BaseDB
    {
        public static void DeleteAll()
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[teacherdatas]", GetConnection);
            command.ExecuteNonQuery();
            CloseConnection();
        }
        public static void AddAll(List<TeacherDatas> teachers)
        {
            foreach (var teacher in teachers)
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[teacherdatas] VALUES (@id,@name,@surname,@phoneNumber,@language,@salaryPercent,@studentCount,@groupCount,@lessonCount,@income)", GetConnection);
                command.Parameters.AddWithValue("@id", teacher.Id);
                command.Parameters.AddWithValue("@name", teacher.Name);
                command.Parameters.AddWithValue("@surname", teacher.Surname);
                command.Parameters.AddWithValue("@phoneNumber", teacher.PhoneNumber);
                command.Parameters.AddWithValue("@language", teacher.Language);
                command.Parameters.AddWithValue("@salaryPercent", teacher.SalaryPercent);
                command.Parameters.AddWithValue("@studentCount", teacher.StudentCount);
                command.Parameters.AddWithValue("@groupCount", teacher.GroupCount);
                command.Parameters.AddWithValue("@lessonCount", teacher.LessonCount);
                command.Parameters.AddWithValue("@income", teacher.Income);

                command.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public static void AddMessages(List<string> messages)
        {
            foreach (var message in messages)
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Messages] VALUES (@message)", GetConnection);
                command.Parameters.Add("@message", SqlDbType.Text).Value = message;
                command.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
