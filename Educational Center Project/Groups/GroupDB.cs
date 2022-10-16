using System.Data.SqlClient;
using System.Data;
using Educational_Center_Project.OverallProps;

namespace Educational_Center_Project.Groups
{
    class GroupDB : BaseDB
    {
        public static void DeleteAll()
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("DELETE [dbo].[groupdatas]", GetConnection);
            command.ExecuteNonQuery();
            CloseConnection();
        }
        public static void AddGroup(GroupDatas group)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[groupdatas] VALUES (@id,@name,@level,@lessonDays,@cost,@class,@lessonTime,@language,@teacherId,@teacher,@studentCount,@income,@lessonCount,@openingDate)", GetConnection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = group.Name;
            command.Parameters.Add("@level", SqlDbType.VarChar).Value = group.Level;
            command.Parameters.Add("@lessonDays", SqlDbType.VarChar).Value = group.LessonDays;
            command.Parameters.Add("@cost", SqlDbType.Int).Value = group.Cost;
            command.Parameters.Add("@class", SqlDbType.VarChar).Value = group.Class;
            command.Parameters.Add("@lessonTime", SqlDbType.VarChar).Value = group.LessonTime;
            command.Parameters.Add("@language", SqlDbType.VarChar).Value = group.Language;
            command.Parameters.Add("@teacherId", SqlDbType.Int).Value = group.TeacherId;
            command.Parameters.Add("@teacher", SqlDbType.VarChar).Value = group.Teacher;
            command.Parameters.Add("@studentCount", SqlDbType.Int).Value = group.StudentCount;
            command.Parameters.Add("@income", SqlDbType.Float).Value = group.Income;
            command.Parameters.Add("@lessonCount", SqlDbType.Int).Value = group.LessonCount;
            command.Parameters.Add("@openingDate", SqlDbType.DateTime).Value = group.OpeningDate;
            command.Parameters.Add("@id", SqlDbType.Int).Value = group.Id;

            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
