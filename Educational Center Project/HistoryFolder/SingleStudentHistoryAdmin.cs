using Educational_Center_Project.Students;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Educational_Center_Project.HistoryFolder
{
    class SingleStudentHistoryAdmin : HistoryDB
    {
        public void MonthEnded(List<StudentDatas> students)
        {
            foreach (var student in students)
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("insert into [dbo].[MonthDatas] Values (@date, @hadToPay, @payment, @examscore, @level, @group,@studentId)", GetConnection);
                command.Parameters.AddWithValue("@studentId", student.Id);
                command.Parameters.AddWithValue("@date", $"{DateTime.Now.Month}.{DateTime.Now.Year}");
                command.Parameters.AddWithValue("@hadToPay", student.HasToPay);
                command.Parameters.AddWithValue("@payment", student.Paid);
                command.Parameters.AddWithValue("@examscore", student.LastExamScore);
                command.Parameters.AddWithValue("@level", student.Level);
                command.Parameters.AddWithValue("@group", student.Group);

                command.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
