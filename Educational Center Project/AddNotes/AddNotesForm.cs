using Educational_Center_Project.OverallProps;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Educational_Center_Project.AddNotes
{
    public partial class AddNotesForm : Form
    {
        public AddNotesForm()
        {
            InitializeComponent();
            addDates_panel.Visible = false;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addDates_panel.Visible = true;
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard form = new Dashboard();
            form.Show();
        }
        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DateTime date = start_date.Value;
            if (note_txb.Text != "" && recur_comb.SelectedItem != null)
            {
                NoteDatas note = new NoteDatas()
                {
                    Note = note_txb.Text,
                    NoteStartDay = Convert.ToDateTime(start_date.Value.ToShortDateString()),
                    Recur = recur_comb.SelectedItem.ToString(),
                    StartingWeekDay = date.DayOfWeek.ToString(),
                    LastDoneDate = DateTime.Today.AddDays(-1),
                    SkipWeekends = skip_weekends.Checked.ToString()
                };
                BaseDB.OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[notes] VALUES (@note,@noteStartDay,@recur,@startingWeekDay,@skipWeekends,@lastDoneDate)", BaseDB.GetConnection);
                command.Parameters.Add("@note", SqlDbType.Text).Value = note.Note;
                command.Parameters.Add("@noteStartDay", SqlDbType.DateTime).Value = note.NoteStartDay;
                command.Parameters.Add("@recur", SqlDbType.VarChar).Value = note.Recur;
                command.Parameters.Add("@startingWeekDay", SqlDbType.VarChar).Value = note.StartingWeekDay;
                command.Parameters.Add("@skipWeekends", SqlDbType.VarChar).Value = note.SkipWeekends.ToString();
                command.Parameters.Add("@lastdoneDate", SqlDbType.DateTime).Value = note.LastDoneDate;

                command.ExecuteNonQuery();
                BaseDB.CloseConnection();

                this.Hide();
                Dashboard form = new Dashboard();
                form.Show();
            }
        }
    }
}
