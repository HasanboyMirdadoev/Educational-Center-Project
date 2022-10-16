using Educational_Center_Project.OverallProps;
using Educational_Center_Project.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Educational_Center_Project.Teachers
{
    public partial class TeacherForm : Form
    {
        Dictionary<int, string> messages;
        int messageIndex = 0;
        TableSaver saver;
        int index = 0;
        public TeacherForm()
        {
            InitializeComponent();

            teacher_list.ColumnHeadersHeight = 21;

            backward.Enabled = false;
            forward.Enabled = false;
            add_panel.Visible = false;
            exit_button.Left = background.Right - 36;
            exit_button.Top = background.Top + 1;
            processing_panel.Visible = false;

            saver = new TableSaver(3);
            DisplayTeacherList();
            CultuvateIndex();

            DataTable table = saver.ConvertToTable(teacher_list);
            saver.AddTable(table);

            messages = new Dictionary<int, string>();
        }
        bool Check()
        {
            try
            {
                bool istrue = name_txb.Text != "" && surname_txb.Text != "" && phoneNumber_txb.Text != "" && language_txb.Text != "";
                int salary = Convert.ToInt32(salaryPercenet_txb.Text);
                return istrue;
            }
            catch (Exception)
            {
                return false;
            }
        }
        void CultuvateIndex()
        {
            for (int i = 0; i < teacher_list.Rows.Count; i++)
            {
                if (teacher_list.Rows[i].Cells[0].Value != null && Convert.ToInt32(teacher_list.Rows[i].Cells[0].Value) > index)
                {
                    index = Convert.ToInt32(teacher_list.Rows[i].Cells[0].Value);
                }
            }
            index++;
        }
        void Clear()
        {
            name_txb.Text = surname_txb.Text = phoneNumber_txb.Text = language_txb.Text = salaryPercenet_txb.Text = "";
            add_panel.Visible = false;
            exit_button.Left = background.Right - 36;
            exit_button.Top = background.Top + 1;
        }
        bool CheckChange()
        {
            try
            {
                bool istrue = change_name.Text != "" && change_surname.Text != "" && change_phoneNumber.Text != "" && change_language.Text != "";
                int salary = Convert.ToInt32(change_salaryPercent.Text);
                return istrue;
            }
            catch (Exception)
            {
                return false;
            }
        }
        bool CheckEquality()
        {
            if (change_name.Text == teacher_list.CurrentRow.Cells[1].Value.ToString() &&
                change_surname.Text == teacher_list.CurrentRow.Cells[2].Value.ToString() &&
                change_phoneNumber.Text == teacher_list.CurrentRow.Cells[3].Value.ToString() &&
                change_language.Text == teacher_list.CurrentRow.Cells[4].Value.ToString() &&
                change_salaryPercent.Text == teacher_list.CurrentRow.Cells[5].Value.ToString())
            {
                return false;
            }
            else return true;
        }
        void DisplayTeacherList()
        {
            DataTable table = BaseDB.GetTeacherDatasTable();
            teacher_list.DataSource = table;
            StudentAdmin.TableColor(teacher_list);
        }

        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            add_panel.Visible = false;
            change_panel.Visible = false;
            processing_panel.Visible = true;
            this.Enabled = false;

            exit_button.Left = background.Right - 36;
            exit_button.Top = background.Top + 1;

            List<TeacherDatas> teachers = (List<TeacherDatas>)saver.GetCurrentTableList();

            TeacherDB.DeleteAll();
            TeacherDB.AddAll(teachers);

            List<string> mess = new List<string>();
            foreach (var message in messages.Values)
            {
                mess.Add(message);
            }
            TeacherDB.AddMessages(mess);

            Thread.Sleep(3000);

            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }

        private void open_add_Click(object sender, EventArgs e)
        {
            add_panel.Visible = true;
            exit_button.Location = new Point(989, 3);
            change_panel.Visible = false;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    DataTable table = saver.ConvertToTable(teacher_list);
                    table.Rows.Add(index, name_txb.Text, surname_txb.Text, phoneNumber_txb.Text, language_txb.Text, salaryPercenet_txb.Text, 0, 0, 0, 0);
                    teacher_list.DataSource = table;
                    saver.AddTable(table);
                    backward.Enabled = true;
                    forward.Enabled = false;
                    index++;
                    Clear();
                    MessageBox.Show("Teacher added succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Fill places correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void change_btn_Click(object sender, EventArgs e)
        {
            if (CheckChange())
            {
                if (CheckEquality())
                {
                    teacher_list.CurrentRow.Cells[1].Value = change_name.Text;
                    teacher_list.CurrentRow.Cells[2].Value = change_surname.Text;
                    teacher_list.CurrentRow.Cells[3].Value = change_phoneNumber.Text;
                    teacher_list.CurrentRow.Cells[4].Value = change_language.Text;
                    teacher_list.CurrentRow.Cells[5].Value = change_salaryPercent.Text;

                    DataTable table = saver.ConvertToTable(teacher_list);
                    saver.AddTable(table);
                    backward.Enabled = true;
                    forward.Enabled = false;
                    MessageBox.Show("Teacher changed succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                exit_button.Left = background.Right - 36;
                exit_button.Top = background.Top + 1;
                change_panel.Visible = false;
                add_panel.Visible = false;
            }
            else MessageBox.Show("Fill places correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to remove this teacher?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                teacher_list.Rows.Remove(teacher_list.CurrentRow);
                DataTable table = saver.ConvertToTable(teacher_list);
                saver.AddTable(table);
                exit_button.Left = background.Right - 36;
                exit_button.Top = background.Top + 1;
                change_panel.Visible = false;
                add_panel.Visible = false;
                MessageBox.Show("Teacher deleted succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void teacher_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            add_panel.Visible = true;
            change_panel.Visible = true;
            exit_button.Location = new Point(989, 3);

            change_name.Text = teacher_list.CurrentRow.Cells[1].Value.ToString();
            change_surname.Text = teacher_list.CurrentRow.Cells[2].Value.ToString();
            change_phoneNumber.Text = teacher_list.CurrentRow.Cells[3].Value.ToString();
            change_language.Text = teacher_list.CurrentRow.Cells[4].Value.ToString();
            change_salaryPercent.Text = teacher_list.CurrentRow.Cells[5].Value.ToString();

        }
        private void backward_Click(object sender, EventArgs e)
        {
            bool value = true;
            teacher_list.DataSource = saver.BackWard(ref value);
            if (value == false)
                backward.Enabled = false;
            forward.Enabled = true;
            foreach (int index in messages.Keys)
            {
                if (saver.index == index - 1)
                {
                    messageIndex--;
                }
            }
        }
        private void forward_Click(object sender, EventArgs e)
        {
            bool value = true;
            teacher_list.DataSource = saver.Forward(ref value);
            if (value == false)
                forward.Enabled = false;
            backward.Enabled = true;

            foreach (int index in messages.Keys)
            {
                if (saver.index == index)
                    messageIndex++;
            }
        }
        private void search_txb_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager manager = (CurrencyManager)BindingContext[teacher_list.DataSource];
            manager.SuspendBinding();

            ChangeVisible();
            for (int i = 0; i < teacher_list.Rows.Count; i++)
            {
                if (teacher_list.Rows[i].Cells[1].Value != null && !teacher_list.Rows[i].Cells[1].Value.ToString().Contains(search_txb.Text))
                {
                    teacher_list.Rows[i].Visible = false;
                }
            }

            if (search_txb.Text == "")
                ChangeVisible();

            manager.ResumeBinding();
        }
        void ChangeVisible()
        {
            foreach (DataGridViewRow row in teacher_list.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
