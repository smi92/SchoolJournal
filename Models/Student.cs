using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolJournal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ClassId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Новая структура: предмет -> дата -> оценка
        public Dictionary<string, Dictionary<DateTime, int>> GradesByDate { get; set; }

        public Student()
        {
            GradesByDate = new Dictionary<string, Dictionary<DateTime, int>>();
        }

        public Student(int id, string fullName, int classId)
        {
            Id = id;
            FullName = fullName;
            ClassId = classId;
            GradesByDate = new Dictionary<string, Dictionary<DateTime, int>>();
        }

        public void AddGrade(string subject, DateTime date, int grade)
        {
            if (!GradesByDate.ContainsKey(subject))
            {
                GradesByDate[subject] = new Dictionary<DateTime, int>();
            }

            if (grade >= 2 && grade <= 5)
            {
                GradesByDate[subject][date] = grade;
            }
        }

        public int GetGrade(string subject, DateTime date)
        {
            if (GradesByDate.ContainsKey(subject) && GradesByDate[subject].ContainsKey(date))
            {
                return GradesByDate[subject][date];
            }
            return 0;
        }

        public double GetAverageGrade(string subject)
        {
            if (GradesByDate.ContainsKey(subject) && GradesByDate[subject].Count > 0)
            {
                return GradesByDate[subject].Values.Average();
            }
            return 0;
        }

        public List<DateTime> GetDatesWithGrades(string subject)
        {
            if (GradesByDate.ContainsKey(subject))
            {
                return GradesByDate[subject].Keys.ToList();
            }
            return new List<DateTime>();
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}