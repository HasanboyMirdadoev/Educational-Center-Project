using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Educational_Center_Project.HistoryFolder
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            student_list.DataSource = HistoryDB.GetTable();
            studentSelectedPanel.Visible = false;
            AddRemoveAddButtons();

        }

        void AddRemoveAddButtons()
        {
            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn();
            removeColumn.HeaderText = "Remove";
            removeColumn.Text = "Remove";
            removeColumn.Name = "Remove";
            removeColumn.UseColumnTextForButtonValue = true;
            removeColumn.DefaultCellStyle.BackColor = Color.Red;
            removeColumn.FlatStyle = FlatStyle.Flat;
            student_list.Columns.Add(removeColumn);

            DataGridViewButtonColumn addColumn = new DataGridViewButtonColumn();
            addColumn.HeaderText = "ReAdd";
            addColumn.Name = "ReAdd";
            addColumn.Text = "ReAdd";
            addColumn.UseColumnTextForButtonValue = true;
            addColumn.DefaultCellStyle.BackColor = Color.Green;
            addColumn.FlatStyle = FlatStyle.Flat;
            student_list.Columns.Add(addColumn);
        }

        private void exit_button_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
        private void exit_button_MouseHover(object sender, System.EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, System.EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }
        private void student_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HistoryStudentDatas studentDatas = new HistoryStudentDatas()
            {
                Id = Convert.ToInt32(student_list.CurrentRow.Cells[2].Value),
                Name = student_list.CurrentRow.Cells[3].Value.ToString(),
                Surname = student_list.CurrentRow.Cells[4].Value.ToString(),
                PhoneNumber = student_list.CurrentRow.Cells[5].Value.ToString(),
                Language = student_list.CurrentRow.Cells[6].Value.ToString(),
                NowState = student_list.CurrentRow.Cells[7].Value.ToString(),
                StudentId = Convert.ToInt32(student_list.CurrentRow.Cells[8].Value),
                HadToPay = Convert.ToDouble(student_list.CurrentRow.Cells[9].Value)
            };
            if (student_list.Columns[e.ColumnIndex].Name == "Remove")
            {
                if (studentDatas.NowState == "Not Coming")
                {
                    HistoryStudentAdmin admin = new HistoryStudentAdmin();
                    var result = MessageBox.Show("Do you really want to remove this student?", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (admin.RemoveStudent(Convert.ToInt32(student_list.CurrentRow.Cells[8].Value)))
                            MessageBox.Show("Student removed successfully!!!");
                        else MessageBox.Show("Student not removed successfully");
                        student_list.Rows.Remove(student_list.Rows[e.RowIndex]);
                    }
                }
                else
                {
                    MessageBox.Show("First you have to remove the student from students, then you can remove them from history");

                }
            }
            else
            {

                if (student_list.Columns[e.ColumnIndex].Name == "ReAdd")
                {
                    if (studentDatas.NowState == "Not Coming")
                    {
                        HistoryStudentAdmin admin = new HistoryStudentAdmin();
                        if (admin.ReAddStudent(studentDatas))
                        {
                            MessageBox.Show("Student readded successfully!!!");
                            student_list.DataSource = HistoryDB.GetTable();
                        }
                        else MessageBox.Show("Student not readded successfully");
                    }
                    else MessageBox.Show("Student exists in database");
                }
                else
                {
                    studentSelectedPanel.Visible = true;
                    studentName.Text = studentDatas.Name;
                    surname.Text = studentDatas.Surname;
                    phoneNumber.Text = $"Phone number: {studentDatas.PhoneNumber}";

                    HistoryDB.OpenConnection();
                    SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[MonthDatas] Where StudentId=@id", HistoryDB.GetConnection);
                    command.Parameters.AddWithValue("@id", studentDatas.StudentId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    payments_list.DataSource = table;
                }
            }
        }
        private void exit_button_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }
        private void exit_button_MouseHover_1(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave_1(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentSelectedPanel.Visible = false;
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void student_list_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in student_list.Rows)
            {
                if (row.Cells[7].Value.ToString() == "Not Coming")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                row.DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }
}
