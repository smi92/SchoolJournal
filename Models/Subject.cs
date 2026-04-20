using SchoolJournal.Interfaces;    // <-- ОБЯЗАТЕЛЬНО!
using SchoolJournal.Models;

namespace SchoolJournal.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HoursPerWeek { get; set; }
        public string TeacherName { get; set; }

        public Subject() { }

        public Subject(int id, string name, int hoursPerWeek, string teacherName)
        {
            Id = id;
            Name = name;
            HoursPerWeek = hoursPerWeek;
            TeacherName = teacherName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
