using Educational_Center_Project.OverallProps;
using System;
using System.Data;
using System.Windows.Forms;

namespace Educational_Center_Project.Groups.GroupHelperClasses
{
    class DeleteOrChangeStudents
    {
        public static void FillTable(ref DataGridView student_list, TableSaver saveStudents, string groupname)
        {
            DataTable table = saveStudents.GetTable();
            RemoveRows(groupname, ref table);
            for (int i = 3; i < table.Columns.Count;)
            {
                table.Columns.RemoveAt(i);
            }
            student_list.DataSource = table;
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.HeaderText = "Delete";
            checkboxColumn.Name = "Delete";
            student_list.Columns.Add(checkboxColumn);
            DataGridViewTextBoxColumn texboxColumn = new DataGridViewTextBoxColumn();
            texboxColumn.HeaderText = "GroupName";
            student_list.Columns.Add(texboxColumn);
        }
        static void RemoveRows(string groupname, ref DataTable table)
        {
            int index = 0;
            while (index < table.Rows.Count)
            {
                if (table.Rows[index]["Group"].ToString() != groupname)
                    table.Rows.RemoveAt(index);
                else
                {
                    index++;
                }
            }
        }
        public static void SaveChanges(DataGridView student_list, TableSaver saveStudent, DataGridView group_list, TableSaver saver)
        {
            bool isGroupChanged = false;
            DataTable allStudents = saveStudent.GetTable();
            for (int i = 0; i < student_list.Rows.Count; i++)
            {
                for (int j = allStudents.Rows.Count - 1; j >= 0; j--)
                {
                    if ((int)student_list.Rows[i].Cells[0].Value == (int)allStudents.Rows[j]["Id"])
                    {
                        if (Convert.ToBoolean(student_list.Rows[i].Cells["Delete"].Value))
                        {
                            allStudents.Rows.RemoveAt(j);
                        }
                        else
                        {
                            allStudents.Rows[j]["Group"] = student_list.Rows[i].Cells[4].Value;
                            isGroupChanged = UpdateGroup(group_list, allStudents.Rows[j]["Group"].ToString(), allStudents.Rows[j]);
                        }
                    }
                }
            }
            if (isGroupChanged)
            {
                DataTable table = saver.ConvertToTable(group_list);
                saver.AddTable(table);
            }

            saveStudent.AddTable(allStudents);

        }
        static bool UpdateGroup(DataGridView groupList, string groupName, DataRow studentRow)
        {
            bool isGroupchanged = false;
            for (int i = 0; i < groupList.Rows.Count; i++)
            {
                if (groupList.Rows[i].Cells[1].Value != null && groupList.Rows[i].Cells[1].Value.ToString() == groupName)
                {
                    int studentCount = (int)groupList.Rows[i].Cells[10].Value;
                    double income = (double)groupList.Rows[i].Cells[11].Value;

                    studentCount++;
                    income += (double)studentRow["Paid"];

                    groupList.Rows[i].Cells[10].Value = studentCount;
                    groupList.Rows[i].Cells[11].Value = income;

                    isGroupchanged = true;
                }
            }
            return isGroupchanged;
        }
        public static bool Check(DataGridView list, DataGridView groupList,TableSaver saver)
        {
            bool isTrue = true;
            foreach (DataGridViewRow row in list.Rows)
            {
                if (row.Cells["Delete"].Value == null && row.Cells[4].Value == null || row.Cells["Delete"].Value != null &&
                    Convert.ToBoolean(row.Cells["Delete"].Value) == true && row.Cells[4].Value != null)
                {
                    isTrue = false;
                    break;
                }
            }
            if (isTrue)
            {
                foreach (DataGridViewRow row in list.Rows)
                {
                    if (row.Cells[4].Value != null && !Exists(row.Cells[4].Value.ToString(), groupList, saver))
                    {
                        isTrue = false;
                        break;
                    }
                }
            }
            return isTrue;
        }
        static bool Exists(string groupname, DataGridView groupList, TableSaver saver)
        {
            DataTable table = saver.ConvertToTable(groupList);
            foreach (DataRow row in table.Rows)
            {
                if (row["Name"].ToString() == groupname)
                    return true;
            }
            return false;
        }
    }
}
