using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Educational_Center_Project.HistoryFolder
{
    class HistoryDB : IDisposable
    {
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["HistoryDB"].ConnectionString;
        static SqlConnection connection = new SqlConnection(connectionString);

        static public SqlConnection GetConnection
        {
            get
            {
                return connection;
            }
        }

        public static void OpenConnection()
        {
            connection = new SqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public static DataTable GetTable()
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[historydatas]", GetConnection);
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
