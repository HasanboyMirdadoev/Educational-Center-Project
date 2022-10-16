using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Educational_Center_Project.OverallProps;

namespace Educational_Center_Project.AddNotes
{
    public class DashSortNotes
    {
        public List<NoteDatas> noteDatas = new List<NoteDatas>();
        public List<Note> note_controls = new List<Note>();
        List<Panel> dashPanels = new List<Panel>();
        public void GetTodaysNotes(List<Panel> panels, DashSortNotes dashSortNotes)
        {
            dashPanels = panels;
            DataTable table = BaseDB.GetNotesTable();
            foreach (DataRow row in table.Rows)
            {
                NoteDatas note = new NoteDatas()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Note = row["Note"].ToString(),
                    NoteStartDay = Convert.ToDateTime(row["NoteStartDay"]),
                    Recur = row["Recur"].ToString(),
                    StartingWeekDay = row["StartingWeekDay"].ToString(),
                    SkipWeekends = row["SkipWeekends"].ToString(),
                    LastDoneDate = Convert.ToDateTime(row["LastDoneDate"])
                };
                if (note.LastDoneDate != DateTime.Now.Date && note.NoteStartDay.CompareTo(DateTime.Today) == 0 ||
                    note.LastDoneDate != DateTime.Now.Date && DateTime.Now.Date.CompareTo(note.NoteStartDay) > 0 && note.Recur == "Daily" && note.SkipWeekends == "False" ||
                    note.LastDoneDate != DateTime.Now.Date && DateTime.Now.Date.CompareTo(note.NoteStartDay) > 0 && note.Recur == "Daily" && note.SkipWeekends == "True" && DateTime.Now.DayOfWeek.ToString() != "Saturday" && DateTime.Now.DayOfWeek.ToString() != "Sunday" ||
                    note.LastDoneDate != DateTime.Now.Date && DateTime.Now.Date.CompareTo(note.NoteStartDay) > 0 && note.Recur != "Weekly" && note.StartingWeekDay == DateTime.Now.DayOfWeek.ToString() ||
                    note.LastDoneDate != DateTime.Now.Date && DateTime.Now.Date.CompareTo(note.NoteStartDay) > 0 && note.Recur != "Monthly" && DateTime.Now.Date.Day == note.NoteStartDay.Date.Day)
                {
                    noteDatas.Add(note);
                }
            }
            MakeNoteControls(dashSortNotes);
            AddNotes();

        }
        private void MakeNoteControls(DashSortNotes dashSortNotes)
        {
            List<Note> notes = new List<Note>();
            for (int i = 0; i < noteDatas.Count; i++)
            {
                Note note_control = new Note(i, dashSortNotes, noteDatas[i]);

                switch (i % 4)
                {
                    case 0:
                        note_control.BackColor = Color.Red;
                        break;
                    case 1:
                        note_control.BackColor = Color.FromArgb(0, 192, 192);
                        break;
                    case 2:
                        note_control.BackColor = Color.Fuchsia;
                        break;
                    case 3:
                        note_control.BackColor = Color.Yellow;
                        break;
                }

                notes.Add(note_control);
            }
            note_controls = notes;
        }
        void AddNotes()
        {
            if (note_controls.Count <= dashPanels.Count)
            {
                for (int i = 0; i < note_controls.Count; i++)
                {
                    dashPanels[i].Controls.Add(note_controls[i]);
                }
            }
            else
            {
                for (int i = 0; i < dashPanels.Count;)
                {
                    dashPanels[i].Controls.Add(note_controls[i]);
                }
            }
        }
        public void AddAnotherNote(Note last_note, NoteDatas note)
        {
            if (dashPanels.Count <= note_controls.Count)
            {
                for (int i = 0; i < dashPanels.Count; i++)
                {
                    dashPanels[i].Controls.Remove(note_controls[i]);
                }
            }
            else
            {
                for (int i = 0; i < note_controls.Count; i++)
                {
                    dashPanels[i].Controls.Remove(note_controls[i]);
                }
            }

            if (note.Recur == "Never")
            {
                RemoveNote(note.Id);
            }
            else
            {
                note.LastDoneDate = DateTime.Now.Date;
                UpdateNote(note);
            }

            note_controls.Remove(last_note);
            AddNotes();
        }
        private void UpdateNote(NoteDatas note)
        {

            BaseDB.OpenConnection();
            SqlCommand command = new SqlCommand("UPDATE [dbo].[notes] SET Note=@note,NoteStartDay=@noteStartDay,Recur=@recur,StartingWeekDay=@startingWeekDay,SkipWeekends=@skipWeekends,LastDoneDate=@lastDoneDate WHERE Id=@id", BaseDB.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = note.Id;
            command.Parameters.Add("@note", SqlDbType.VarChar).Value = note.Note;
            command.Parameters.Add("@noteStartDay", SqlDbType.DateTime).Value = note.NoteStartDay;
            command.Parameters.Add("@recur", SqlDbType.VarChar).Value = note.Recur;
            command.Parameters.Add("@startingWeekDay", SqlDbType.VarChar).Value = note.StartingWeekDay;
            command.Parameters.Add("@skipWeekends", SqlDbType.VarChar).Value = note.SkipWeekends;
            command.Parameters.Add("@lastDoneDate", SqlDbType.DateTime).Value = note.LastDoneDate;
            command.ExecuteNonQuery();
            BaseDB.CloseConnection();
        }
        void RemoveNote(int id)
        {
            BaseDB.OpenConnection();
            SqlCommand command = new SqlCommand("DELETE [dbo].[notes] WHERE Id=@id", BaseDB.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();
            BaseDB.CloseConnection();
        }
        public void RemoveNote(Note last_note, NoteDatas note)
        {
            if (dashPanels.Count <= note_controls.Count)
            {
                for (int i = 0; i < dashPanels.Count; i++)
                {
                    dashPanels[i].Controls.Remove(note_controls[i]);
                }
            }
            else
            {
                for (int i = 0; i < note_controls.Count; i++)
                {
                    dashPanels[i].Controls.Remove(note_controls[i]);
                }
            }
            RemoveNote(note.Id);
            note_controls.Remove(last_note);
            AddNotes();
        }
    }
}
