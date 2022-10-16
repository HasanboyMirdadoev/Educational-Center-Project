using Educational_Center_Project.OverallProps;
using Educational_Center_Project.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Educational_Center_Project.Groups.GroupHelperClasses
{
    class StudentTickClass
    {
        string groupName;
        Dictionary<int, double> studentLastDepts = new Dictionary<int, double>();
        public StudentTickClass(string groupname, int cameLessons, ref DataGridView student_list, TableSaver saver)
        {
            groupName = groupname;
            DataTable table = saver.GetTable();
            SetTable(ref table, cameLessons);
            student_list.DataSource = table;

            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "Came";
            checkbox.Name = "cameOrNot";
            student_list.Columns.Add(checkbox);
        }
        void SetTable(ref DataTable table, int cameLessons)
        {
            int index = 0;
            while (index < table.Rows.Count)
            {
                if (table.Rows[index]["Group"].ToString() != groupName)
                    table.Rows.RemoveAt(index);
                else
                {
                    index++;
                }
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                studentLastDepts.Add(Convert.ToInt32(table.Rows[i]["Id"]), Convert.ToDouble(table.Rows[i]["HasToPay"]));
            }
            for (int i = 3; i < table.Columns.Count;)
            {
                table.Columns.RemoveAt(i);
            }
            table.Columns.Add("CameLessons");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["CameLessons"] = cameLessons;
            }
        }
        public DataTable SaveTicks(DataGridView list, DataTable table)
        {
            for (int i = 0; i < list.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (Convert.ToInt32(list.Rows[i].Cells[1].Value) == Convert.ToInt32(table.Rows[j]["Id"]) && list.Rows[i].Cells[0].Value != null)
                    {
                        double cameLessons = Convert.ToDouble(list.Rows[i].Cells[4].Value);
                        double lastDept = Convert.ToDouble(table.Rows[j]["HasToPay"]);
                        double bonus = Convert.ToDouble(table.Rows[j]["Bonus"]);
                        double newDept = StudentAdmin.CultivateDept(cameLessons, lastDept, groupName, bonus);

                        double stock = Convert.ToDouble(table.Rows[j]["Stock"]);
                        double paid = Convert.ToDouble(table.Rows[j]["Paid"]);

                        StudentAdmin.CultivatePaid(ref stock, ref paid, newDept);

                        table.Rows[j]["HasToPay"] = newDept;
                        table.Rows[j]["Stock"] = stock;
                        table.Rows[j]["Paid"] = paid;

                    }
                }
            }
            return table;
        }
    }
}
