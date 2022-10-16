using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Educational_Center_Project.AddNotes
{
    public partial class Note : UserControl
    {
        public DashSortNotes DashSort;
        NoteDatas currentNote;
        public Note(int index, DashSortNotes dashSortNotes, NoteDatas note)
        {
            InitializeComponent();
            note_txb.Text = note.Note;
            DashSort = dashSortNotes;
            TexboxColor(index);
            currentNote = note;
        }
        void TexboxColor(int i)
        {
            switch (i % 4)
            {
                case 0:
                    note_txb.FillColor = Color.Red;
                    break;
                case 1:
                    note_txb.FillColor = Color.FromArgb(0, 192, 192);
                    break;
                case 2:
                    note_txb.FillColor = Color.Fuchsia;
                    break;
                case 3:
                    note_txb.FillColor = Color.Yellow;
                    note_txb.ForeColor = Color.Black;
                    break;
            }
        }
        private void done_btn_Click(object sender, EventArgs e)
        {
            DashSort.AddAnotherNote(this, currentNote);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DashSort.RemoveNote(this, currentNote);
        }
    }
}
