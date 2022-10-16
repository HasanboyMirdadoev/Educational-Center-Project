using Educational_Center_Project.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Educational_Center_Project.HistoryFolder
{
    class HistoryAdmin : HistoryDB
    {
        SingleStudentHistoryAdmin SingleStudent = new SingleStudentHistoryAdmin();
        public void StudentAdded(StudentDatas student)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("Insert into historydatas (Name,Surname,PhoneNumber,Language,NowState,StudentId,HadToPay) Values (@name,@surname,@phoneNumber,@language,@nowState,@studentId,@hadToPay)", GetConnection);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@phoneNumber", student.PhoneNumber);
            command.Parameters.AddWithValue("@language", student.Language);
            command.Parameters.AddWithValue("@nowState", "Coming");
            command.Parameters.AddWithValue("@studentId", student.Id);
            command.Parameters.AddWithValue("@hadToPay", student.HasToPay);

            command.ExecuteNonQuery();
            CloseConnection();

            int index = GetIndex();
            StudentDB.UpdateStudent(student, index);
        }
        public void StudentRemoved(StudentDatas student)
        {
            Update(student);
        }
        public void StudentBackward(StudentDatas student)
        {
            ReUpdate(student);
        }
        public void MonthEnded(List<StudentDatas> students) => SingleStudent.MonthEnded(students);
        int GetIndex()
        {
            DataTable table = GetTable();
            return Convert.ToInt32(table.Rows[table.Rows.Count - 1][0]);
        }
        void Update(StudentDatas student)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("update [dbo].[historydatas] set NowState=@nowstate, HadToPay=@hadToPay where StudentId=@id", GetConnection);
            command.Parameters.AddWithValue("@nowstate", "Not Coming");
            command.Parameters.AddWithValue("@hadToPay", student.HasToPay - student.Paid);
            command.Parameters.AddWithValue("@id", student.Id);

            command.ExecuteNonQuery();
            CloseConnection();
        }
        void ReUpdate(StudentDatas student)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand("update [dbo].[historydatas] set NowState=@nowstate, HadToPay=@hadToPay where StudentId=@id", GetConnection);
            command.Parameters.AddWithValue("@nowstate", "Coming");
            command.Parameters.AddWithValue("@hadToPay", 0);
            command.Parameters.AddWithValue("@id", student.Id);

            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
