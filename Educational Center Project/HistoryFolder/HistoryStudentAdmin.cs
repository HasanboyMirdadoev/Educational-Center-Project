using Educational_Center_Project.OverallProps;
using Educational_Center_Project.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Educational_Center_Project.HistoryFolder
{
    class HistoryStudentAdmin
    {
        public bool RemoveStudent(int studentId)
        {
            RemoveFromMonthlyHistory(studentId);
            return RemoveFromStudentHistory(studentId);
        }
        bool RemoveFromStudentHistory(int studentId)
        {
            bool removedSuccessfully = false;
            HistoryDB.OpenConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM [dbo].[historydatas] Where StudentId=@id", HistoryDB.GetConnection);
            cmd.Parameters.AddWithValue("@id", studentId);
            if (cmd.ExecuteNonQuery() == 1)
            {
                removedSuccessfully = true;
            }
            HistoryDB.CloseConnection();
            return removedSuccessfully;
        }
        private void RemoveFromMonthlyHistory(int studentId)
        {
            HistoryDB.OpenConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM [dbo].[MonthDatas] Where StudentId=@id", HistoryDB.GetConnection);
            cmd.Parameters.AddWithValue("@id", studentId);
            HistoryDB.CloseConnection();
        }
        public bool ReAddStudent(HistoryStudentDatas studentDatas)
        {
            StudentDatas student = new StudentDatas()
            {
                Name = studentDatas.Name,
                Surname = studentDatas.Surname,
                PhoneNumber = studentDatas.PhoneNumber,
                Language = studentDatas.Language,
                Level = "",
                Group = "",
                Age = 0,
                Bonus = 0,
                Comment = "",
                LastPaymet = DateTime.Today,
                HasToPay = studentDatas.HadToPay,
                Paid = 0,
                Stock = 0,
                LastExamScore = 0
            };
            StudentDB.AddStudent(student);

            DataTable table = BaseDB.GetStudentDatasTable();
            TableSaver saver = new TableSaver(1);
            saver.AddTable(table);
            List<StudentDatas> students = (List<StudentDatas>)saver.GetCurrentTableList();
            int newId = students[students.Count - 1].Id;

            HistoryDB.OpenConnection();
            SqlCommand command = new SqlCommand("Update [dbo].[historydatas] set StudentId=@id,NowState=@nowState,HadToPay=@hadToPay Where StudentId=@studentId", HistoryDB.GetConnection);
            command.Parameters.AddWithValue("@id", newId);
            command.Parameters.AddWithValue("@studentId", studentDatas.StudentId);
            command.Parameters.AddWithValue("@nowState", "Coming"); 
            command.Parameters.AddWithValue("@hadToPay", 0);

            bool addedSuccessfuly = command.ExecuteNonQuery() == 1;
            HistoryDB.CloseConnection();

            return addedSuccessfuly;
        }
    }
}
