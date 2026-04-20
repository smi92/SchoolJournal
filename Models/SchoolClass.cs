using System.Collections.Generic;
using SchoolJournal.Interfaces;    // <-- ОБЯЗАТЕЛЬНО!
using SchoolJournal.Models;

namespace SchoolJournal.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeLevel { get; set; } // 1-11
        public string ClassLetter { get; set; } // А, Б, В
        public int TeacherId { get; set; }

        public SchoolClass() { }

        public SchoolClass(int id, string name, int gradeLevel, string classLetter)
        {
            Id = id;
            Name = name;
            GradeLevel = gradeLevel;
            ClassLetter = classLetter;
        }

        public string GetFullName()
        {
            return $"{GradeLevel}-{ClassLetter}";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}