using System;

namespace Educational_Center_Project.AddNotes
{
    public class NoteDatas
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime NoteStartDay { get; set; }
        public string Recur { get; set; }
        public string StartingWeekDay { get; set; }
        public string SkipWeekends { get; set; }
        public DateTime LastDoneDate { get; set; }
    }
}
