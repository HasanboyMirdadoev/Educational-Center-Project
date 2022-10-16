using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Educational_Center_Project.Students;
using Educational_Center_Project.Groups;
using Educational_Center_Project.Teachers;

namespace Educational_Center_Project.OverallProps
{
    public class TableSaver
    {
        List<DataTable> tables = new List<DataTable>();
        public int index = -1;
        bool called = false;
        int key;
        public TableSaver(int key)
        {
            this.key = key;
        }
        public void AddTable(DataTable grid)
        {
            if (called)
            {
                for (int i = tables.Count - 1; i > index; i--)
                    tables.RemoveAt(i);

                DataTable newTable = CopyTable(grid);
                tables.Add(newTable);
                index++;
            }
            else
            {
                DataTable newTable = CopyTable(grid);
                tables.Add(newTable);
                index++;
            }
        }
        public DataTable CopyTable(DataTable table)
        {
            DataTable newTable;
            if (key == 1)
            {
                newTable = StudentDB.GetStudentDatasTable();
            }
            else if (key == 2)
            {
                newTable = StudentDB.GetGroupTable();
            }
            else
            {
                newTable = StudentDB.GetTeacherDatasTable();
            }

            int rowCount = newTable.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                newTable.Rows.RemoveAt(0);
            }

            if (key == 1)
            {
                foreach (DataRow row in table.Rows)
                {
                    newTable.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14]);
                }
            }
            else if (key == 2)
            {
                foreach (DataRow row in table.Rows)
                {
                    newTable.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13]);
                }
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    newTable.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9]);
                }
            }
            return newTable;
        }
        public DataTable ConvertToTable(DataGridView grid)
        {
            DataTable table;
            if (key == 1)
            {
                table = StudentDB.GetStudentDatasTable();
            }
            else if (key == 2)
            {
                table = StudentDB.GetGroupTable();
            }
            else
            {
                table = StudentDB.GetTeacherDatasTable();
            }

            int rowCount = table.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                table.Rows.RemoveAt(0);
            }

            if (key == 1)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    table.Rows.Add(grid.Rows[i].Cells[0].Value, grid.Rows[i].Cells[1].Value, grid.Rows[i].Cells[2].Value, grid.Rows[i].Cells[3].Value, grid.Rows[i].Cells[4].Value, grid.Rows[i].Cells[5].Value, grid.Rows[i].Cells[6].Value, grid.Rows[i].Cells[7].Value, grid.Rows[i].Cells[8].Value, grid.Rows[i].Cells[9].Value, grid.Rows[i].Cells[10].Value, grid.Rows[i].Cells[11].Value, grid.Rows[i].Cells[12].Value, grid.Rows[i].Cells[13].Value, grid.Rows[i].Cells[14].Value);
                }
            }
            else if (key == 2)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    table.Rows.Add(grid.Rows[i].Cells[0].Value, grid.Rows[i].Cells[1].Value, grid.Rows[i].Cells[2].Value, grid.Rows[i].Cells[3].Value, grid.Rows[i].Cells[4].Value, grid.Rows[i].Cells[5].Value, grid.Rows[i].Cells[6].Value, grid.Rows[i].Cells[7].Value, grid.Rows[i].Cells[8].Value, grid.Rows[i].Cells[9].Value, grid.Rows[i].Cells[10].Value, grid.Rows[i].Cells[11].Value, grid.Rows[i].Cells[12].Value, grid.Rows[i].Cells[13].Value);
                }
            }
            else
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    table.Rows.Add(grid.Rows[i].Cells[0].Value, grid.Rows[i].Cells[1].Value, grid.Rows[i].Cells[2].Value, grid.Rows[i].Cells[3].Value, grid.Rows[i].Cells[4].Value, grid.Rows[i].Cells[5].Value, grid.Rows[i].Cells[6].Value, grid.Rows[i].Cells[7].Value, grid.Rows[i].Cells[8].Value, grid.Rows[i].Cells[9].Value);
                }
            }
            return table;
        }
        public DataTable BackWard(ref bool value)
        {
            index--;
            called = true;
            if (index == 0)
                value = false;
            return CopyTable(tables[index]);

        }
        public DataTable Forward(ref bool value)
        {
            index++;
            if (index == tables.Count - 1)
            {
                value = false;
                called = false;
            }
            else called = true;
            return CopyTable(tables[index]);
        }
        public object GetCurrentTableList()
        {
            if (key == 1)
            {
                return GetStudentTable();
            }
            else if (key == 2)
            {
                return GetGroupTable();
            }
            else
            {
                return GetTeacherTable();
            }
        }
        List<StudentDatas> GetStudentTable()
        {
            List<StudentDatas> datas = new List<StudentDatas>();
            foreach (DataRow row in tables[index].Rows)
            {
                if (row["Id"] != DBNull.Value)
                {
                    StudentDatas student = new StudentDatas();
                    student.Id = Convert.ToInt32(row[0]);
                    student.Name = row[1].ToString();
                    student.Surname = row[2].ToString();
                    student.PhoneNumber = row[3].ToString();
                    student.Language = row[4].ToString();
                    student.Level = row[5].ToString();
                    student.Group = row[6].ToString();
                    student.Age = Convert.ToInt32(row[7]);
                    student.Bonus = Convert.ToInt32(row[8]);
                    student.Comment = row[9].ToString();
                    student.LastPaymet = Convert.ToDateTime(row[10]);
                    student.HasToPay = Convert.ToDouble(row[11]);
                    student.Paid = Convert.ToDouble(row[12]);
                    student.Stock = Convert.ToDouble(row[13]);
                    student.LastExamScore = Convert.ToInt32(row[14]);
                    datas.Add(student);
                }
            }
            return datas;
        }
        List<GroupDatas> GetGroupTable()
        {
            List<GroupDatas> datas = new List<GroupDatas>();
            for (int i = 0; i < tables[index].Rows.Count; i++)
            {
                if (tables[index].Rows[i]["Id"] != DBNull.Value)
                {
                    GroupDatas group = new GroupDatas();
                    group.Id = Convert.ToInt32(tables[index].Rows[i]["Id"]);
                    group.Name = tables[index].Rows[i]["Name"].ToString();
                    group.Level = tables[index].Rows[i]["Level"].ToString();
                    group.LessonDays = tables[index].Rows[i]["LessonDays"].ToString();
                    group.Cost = Convert.ToInt32(tables[index].Rows[i]["Cost"]);
                    group.Class = tables[index].Rows[i]["Class"].ToString();
                    group.LessonTime = tables[index].Rows[i]["LessonTime"].ToString();
                    group.Language = tables[index].Rows[i]["Language"].ToString();
                    group.TeacherId = Convert.ToInt32(tables[index].Rows[i]["TeacherId"]);
                    group.Teacher = tables[index].Rows[i]["Teacher"].ToString();
                    group.StudentCount = Convert.ToInt32(tables[index].Rows[i]["StudentCount"].ToString());
                    group.Income = Convert.ToDouble(tables[index].Rows[i]["Income"].ToString());
                    group.LessonCount = Convert.ToInt32(tables[index].Rows[i]["LessonCount"].ToString());
                    group.OpeningDate = Convert.ToDateTime(tables[index].Rows[i]["OpeningDate"].ToString());
                    datas.Add(group);
                }
            }
            return datas;
        }
        List<TeacherDatas> GetTeacherTable()
        {
            List<TeacherDatas> datas = new List<TeacherDatas>();
            for (int i = 0; i < tables[index].Rows.Count; i++)
            {
                if (tables[index].Rows[i]["Id"] != DBNull.Value)
                {
                    TeacherDatas teacher = new TeacherDatas();
                    teacher.Id = Convert.ToInt32(tables[index].Rows[i]["Id"]);
                    teacher.Name = tables[index].Rows[i]["Name"].ToString();
                    teacher.Surname = tables[index].Rows[i]["Surname"].ToString();
                    teacher.PhoneNumber = tables[index].Rows[i]["PhoneNumber"].ToString();
                    teacher.Language = tables[index].Rows[i]["Language"].ToString();
                    teacher.SalaryPercent = Convert.ToInt32(tables[index].Rows[i]["SalaryPercent"]);
                    teacher.StudentCount = Convert.ToInt32(tables[index].Rows[i]["Studentcount"]);
                    teacher.GroupCount = Convert.ToInt32(tables[index].Rows[i]["GroupCount"]);
                    teacher.LessonCount = Convert.ToInt32(tables[index].Rows[i]["Lessoncount"]);
                    teacher.Income = Convert.ToDouble(tables[index].Rows[i]["Income"]);

                    datas.Add(teacher);
                }
            }
            return datas;
        }
        public DataTable GetTable()
        {
            return CopyTable(tables[index]);
        }

        public int Length {
            get
            {
                return tables.Count;
            }
        } 
        public List<StudentDatas> this[int index]
        {
            get 
            {
                TableSaver saver = new TableSaver(1);
                saver.AddTable(tables[index]);
                return (List<StudentDatas>)saver.GetCurrentTableList();
            }
        }
    }
}
