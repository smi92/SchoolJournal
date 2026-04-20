using System;
using System.Collections.Generic;
using System.Linq;
using SchoolJournal.Interfaces;
using System.Text.Json;

namespace SchoolJournal.Models
{
    public class GradeRepository : IGradeRepository
    {
        private List<Student> _students;
        private List<SchoolClass> _classes;
        private List<string> _subjects;
        private List<DateTime> _gradeDates;

        public GradeRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            var savedData = DataStorage.LoadData();

            if (savedData != null && savedData.Classes != null && savedData.Classes.Count > 0)
            {
                // Загружаем сохраненные данные
                _classes = savedData.Classes;
                _subjects = savedData.Subjects ?? new List<string> { "Алгебра", "Геометрия", "Физика", "Химия", "Русский язык", "Литература" };
                _students = savedData.Students ?? new List<Student>();
                _gradeDates = savedData.GradeDates ?? GetDefaultDates();
            }
            else
            {
                // Инициализация данными по умолчанию
                InitializeDefaultData();
            }
        }

        private void InitializeDefaultData()
        {
            // Инициализация классов
            _classes = new List<SchoolClass>
            {
                new SchoolClass(1, "1-А", 1, "А"),
                new SchoolClass(2, "1-Б", 1, "Б"),
                new SchoolClass(3, "2-А", 2, "А"),
                new SchoolClass(4, "2-Б", 2, "Б"),
                new SchoolClass(5, "3-А", 3, "А"),
                new SchoolClass(6, "3-Б", 3, "Б"),
                new SchoolClass(7, "4-А", 4, "А"),
                new SchoolClass(8, "5-А", 5, "А"),
                new SchoolClass(9, "5-Б", 5, "Б"),
                new SchoolClass(10, "6-А", 6, "А"),
                new SchoolClass(11, "7-А", 7, "А"),
                new SchoolClass(12, "8-А", 8, "А"),
                new SchoolClass(13, "9-А", 9, "А"),
                new SchoolClass(14, "10-А", 10, "А"),
                new SchoolClass(15, "11-А", 11, "А"),
                new SchoolClass(16, "11-Б", 11, "Б")
            };

            // Инициализация предметов
            _subjects = new List<string> { "Алгебра", "Геометрия", "Физика", "Химия", "Русский язык", "Литература", "История", "Биология" };

            // Инициализация дат
            _gradeDates = GetDefaultDates();

            // Инициализация учеников
            _students = new List<Student>
            {
                new Student(1, "Иванов Иван Иванович", 1),
                new Student(2, "Петрова Анна Сергеевна", 1),
                new Student(3, "Сидоров Алексей Дмитриевич", 16),
                new Student(4, "Козлова Екатерина Андреевна", 16),
                new Student(5, "Смирнов Дмитрий Олегович", 16),
                new Student(6, "Новикова Мария Владимировна", 16)
            };

            // Добавление тестовых оценок
            var testStudent = _students.FirstOrDefault(s => s.Id == 6);
            if (testStudent != null)
            {
                testStudent.AddGrade("Алгебра", _gradeDates[0], 5);
                testStudent.AddGrade("Алгебра", _gradeDates[1], 4);
                testStudent.AddGrade("Алгебра", _gradeDates[2], 5);
                testStudent.AddGrade("Алгебра", _gradeDates[3], 4);
                testStudent.AddGrade("Алгебра", _gradeDates[4], 5);
            }
        }

        private List<DateTime> GetDefaultDates()
        {
            return new List<DateTime>
            {
                new DateTime(2026, 4, 1),
                new DateTime(2026, 4, 5),
                new DateTime(2026, 4, 8),
                new DateTime(2026, 4, 12),
                new DateTime(2026, 4, 15),
                new DateTime(2026, 4, 18),
                new DateTime(2026, 4, 22),
                new DateTime(2026, 4, 25)
            };
        }

        public void SaveChanges()
        {
            DataStorage.SaveData(_classes, _subjects, _students, _gradeDates);
        }

        public List<Student> GetAllStudents() => _students;
        public List<SchoolClass> GetAllClasses() => _classes;
        public List<string> GetAllSubjects() => _subjects;
        public List<DateTime> GetAllDates() => _gradeDates;

        public Student GetStudentById(int id) => _students.FirstOrDefault(s => s.Id == id);
        public List<Student> GetStudentsByClass(int classId) => _students.Where(s => s.ClassId == classId).ToList();

        public void AddGrade(int studentId, string subject, DateTime date, int grade)
        {
            var student = GetStudentById(studentId);
            student?.AddGrade(subject, date, grade);
            SaveChanges();
        }

        public void AddClass(SchoolClass newClass)
        {
            _classes.Add(newClass);
            SaveChanges();
        }

        public void AddSubject(string subject)
        {
            if (!_subjects.Contains(subject))
            {
                _subjects.Add(subject);
                SaveChanges();
            }
        }

        public void AddDate(DateTime date)
        {
            if (!_gradeDates.Contains(date))
            {
                _gradeDates.Add(date);
                _gradeDates.Sort();
                SaveChanges();
            }
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
            SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var existing = GetStudentById(student.Id);
            if (existing != null)
            {
                existing.FullName = student.FullName;
                existing.ClassId = student.ClassId;
                SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student != null)
            {
                _students.Remove(student);
                SaveChanges();
            }
        }

        public double CalculateAverageGrade(int studentId, string subject)
        {
            var student = GetStudentById(studentId);
            return student?.GetAverageGrade(subject) ?? 0;
        }
    }
}