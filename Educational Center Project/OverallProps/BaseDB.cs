using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Educational_Center_Project.OverallProps
{
    abstract class BaseDB
    {
        static readonly string _connectionString = ConfigurationManager.ConnectionStrings["EduCenterDB"].ConnectionString;
        static SqlConnection connect = new SqlConnection(_connectionString);

        public static SqlConnection GetConnection
        {
            get
            {
                return connect;
            }
        }
        public static void OpenConnection()
        {
            connect = new SqlConnection(_connectionString);
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }
        public static void CloseConnection()
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
                connect.Dispose();
            }
        }

        public static DataTable GetGroupTable()
        {
            return GetTable("SELECT * FROM [dbo].[groupdatas]");
        }
        public static DataTable GetMessagesTable()
        {
             return GetTable("SELECT * FROM [dbo].[messages]");
        }
        public static DataTable GetMonthOutcomeTable()
        {
            return GetTable("SELECT * FROM [dbo].[monthoutcome]");
        }
        public static DataTable GetNotesTable()
        {
            return GetTable("SELECT * FROM [dbo].[notes]");
        }
        public static DataTable GetStudentDatasTable()
        {
            return GetTable("SELECT * FROM [dbo].[studentdatas]");
        }
        public static DataTable GetTeacherDatasTable()
        {
            return GetTable("SELECT * FROM [dbo].[teacherdatas]");
        }
        public static DataTable GetYearOutcomeTable()
        {
            return GetTable("SELECT * FROM [dbo].[yearoutcome]");
        }
        public static DataTable GetTable(string comm)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(comm, GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
