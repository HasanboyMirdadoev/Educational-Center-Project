using System;

namespace Educational_Center_Project.Students
{
    sealed public class StudentDatas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Language { get; set; }
        public string Level { get; set; }
        public string Group { get; set; }
        public int Age { get; set; }
        public int Bonus { get; set; }
        public string Comment { get; set; }
        public DateTime LastPaymet { get; set; }
        public double HasToPay { get; set; }
        public double Paid { get; set; }
        public double Stock { get; set; }
        public int LastExamScore { get; set; }
    }
}
