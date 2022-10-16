using Educational_Center_Project.OverallProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Educational_Center_Project.TotalResultFile
{
    class RefreshAll
    {
        TotalResultAdmin admin;

        public object MysqlCommand { get; private set; }

        public RefreshAll()
        {
            admin = new TotalResultAdmin();
        }
        public void AddNewMonthResult()
        {
            List<TeacherTotalDatas> teachers = admin.DisplayTeacherTotal();
            int lessonCount = 0;
            double totalProfit = 0;
            double teachersSalary = 0;
            double pureProfit = 0;
            int studentCount = 0;
            int groupCount = 0;
            int teacherCount = 0;
            foreach (var teacher in teachers)
            {
                lessonCount += teacher.LessonCount;
                totalProfit += teacher.Profit;
                teachersSalary += teacher.Salary;
                studentCount += teacher.StudentCount;
                groupCount += teacher.GroupCount;
                teacherCount++;
            }
            pureProfit = totalProfit - teachersSalary;
            TotalMonthDatas totalMonth = new TotalMonthDatas()
            {
                Date = GetDate(),
                LessonCount = lessonCount,
                StudentCount = studentCount,
                GroupCount = groupCount,
                TeacherCount = teacherCount,
                TotalProfit = totalProfit,
                TeachersSalary = teachersSalary,
                PureProfit = pureProfit
            };
            SaveToDataBase(totalMonth);
            UpdateAll();
        }
        private void SaveToDataBase(TotalMonthDatas monthDatas)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[monthoutcome] VALUES (@date,@lessonCount,@studentCount,@groupCount,@teacherCount,@totalProfit,@teacherSalary,@pureProfit)", BaseDB.GetConnection);
            command.Parameters.Add("@date", SqlDbType.VarChar).Value = monthDatas.Date;
            command.Parameters.Add("@lessonCount", SqlDbType.Int).Value = monthDatas.LessonCount;
            command.Parameters.Add("@studentCount", SqlDbType.Int).Value = monthDatas.StudentCount;
            command.Parameters.Add("@groupCount", SqlDbType.Int).Value = monthDatas.GroupCount;
            command.Parameters.Add("@teacherCount", SqlDbType.Int).Value = monthDatas.TeacherCount;
            command.Parameters.Add("@totalProfit", SqlDbType.Float).Value = monthDatas.TotalProfit;
            command.Parameters.Add("@teacherSalary", SqlDbType.Float).Value = monthDatas.TeachersSalary;
            command.Parameters.Add("@pureProfit", SqlDbType.Float).Value = monthDatas.PureProfit;

            BaseDB.OpenConnection();
            command.ExecuteNonQuery();
            BaseDB.CloseConnection();
        }
        private string GetDate()
        {
            DataTable table = BaseDB.GetMonthOutcomeTable();
            if (table.Rows.Count != 0)
            {
                string lastDate = table.Rows[table.Rows.Count - 1]["Date"].ToString();
                int lastMonth = Convert.ToInt32(lastDate.Split('.')[0]);
                int lastYear = Convert.ToInt32(lastDate.Split('.')[1]);

                if (lastMonth == 12)
                {
                    AddNewYear(lastYear);
                    return $"1.{lastYear++}";
                }
                else
                {
                    lastMonth++;
                    return $"{lastMonth}.{lastYear}";
                }
            }
            else
            {
                return $"{DateTime.Now.Month}.{DateTime.Now.Year}";
            }
        }
        private void AddNewYear(int lastYear)
        {
            DataTable table = BaseDB.GetMonthOutcomeTable();
            int lessonCount = 0;
            double totalProfit = 0;
            double teacherSalary = 0;
            double pureProfit = 0;
            foreach (DataRow row in table.Rows)
            {
                string date = row["Date"].ToString();
                int year = Convert.ToInt32(date.Split('.')[1]);
                if (year == lastYear)
                {
                    lessonCount += Convert.ToInt32(row["LessonCount"]);
                    totalProfit += Convert.ToDouble(row["TotalProfit"]);
                    teacherSalary += Convert.ToDouble(row["TotalTeacherSalary"]);
                    pureProfit += Convert.ToDouble(row["PureProfit"]);
                }
            }
            TotalYearDatas yearDatas = new TotalYearDatas()
            {
                Year = lastYear,
                LessonCount = lessonCount,
                TotalProfit = totalProfit,
                TeacherSalary = teacherSalary,
                PureProfit = pureProfit
            };
            AddToYearDataBase(yearDatas);
        }
        private void AddToYearDataBase(TotalYearDatas yearDatas)
        {

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[yearoutcome] VALUES (@year,@lessonCount,@totalProfit,@teacherSalary,@pureProfit)", BaseDB.GetConnection);
            command.Parameters.Add("@year", SqlDbType.VarChar).Value = yearDatas.Year;
            command.Parameters.Add("@lessonCount", SqlDbType.Int).Value = yearDatas.LessonCount;
            command.Parameters.Add("@totalProfit", SqlDbType.Float).Value = yearDatas.TotalProfit;
            command.Parameters.Add("@teacherSalary", SqlDbType.Float).Value = yearDatas.TeacherSalary;
            command.Parameters.Add("@pureProfit", SqlDbType.Float).Value = yearDatas.PureProfit;

            BaseDB.OpenConnection();
            command.ExecuteNonQuery();
            BaseDB.CloseConnection();
        }
        public void UpdateAll()
        {
            UpdateStudents();
            UpdateGroups();
            UpdateTeachers();
        }
        public void UpdateStudents()
        {
            DataTable table = BaseDB.GetStudentDatasTable();
            foreach (DataRow row in table.Rows)
            {
                BaseDB.OpenConnection();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[studentdatas] SET HasToPay=@hasToPay,Paid=@paid,Stock=0 WHERE Id=@id", BaseDB.GetConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(row["Id"]);
                command.Parameters.Add("@hasToPay", SqlDbType.Float).Value = 0;
                command.Parameters.Add("@paid", SqlDbType.Float).Value = 0;

                command.ExecuteNonQuery();
                BaseDB.CloseConnection();
            }

        }
        public void UpdateGroups()
        {
            DataTable table = BaseDB.GetGroupTable();
            foreach (DataRow row in table.Rows)
            {
                SqlCommand command = new SqlCommand("UPDATE [dbo].[groupdatas] SET Income=@income,LessonCount=@lessonCount WHERE Id=@id", BaseDB.GetConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(row["Id"]);
                command.Parameters.Add("@income", SqlDbType.Float).Value = 0;
                command.Parameters.Add("@lessonCount", SqlDbType.Float).Value = 0;

                BaseDB.OpenConnection();
                command.ExecuteNonQuery();
                BaseDB.CloseConnection();
            }
        }
        public void UpdateTeachers()
        {
            DataTable table = BaseDB.GetTeacherDatasTable();
            foreach (DataRow row in table.Rows)
            {
                SqlCommand command = new SqlCommand("UPDATE [dbo].[teacherdatas] SET LessonCount=@lessonCount,Income=@income WHERE Id=@id", BaseDB.GetConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(row["Id"]);
                command.Parameters.Add("@income", SqlDbType.Float).Value = 0;
                command.Parameters.Add("@lessonCount", SqlDbType.Float).Value = 0;

                BaseDB.OpenConnection();
                command.ExecuteNonQuery();
                BaseDB.CloseConnection();
            }
        }
    }
}
