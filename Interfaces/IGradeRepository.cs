using System;
using System.Collections.Generic;
using SchoolJournal.Models;

namespace SchoolJournal.Interfaces
{
    public interface IGradeRepository
    {
        List<Student> GetAllStudents();
        List<SchoolClass> GetAllClasses();
        List<string> GetAllSubjects();
        List<DateTime> GetAllDates();
        Student GetStudentById(int id);
        List<Student> GetStudentsByClass(int classId);
        void AddGrade(int studentId, string subject, DateTime date, int grade);
        void AddClass(SchoolClass newClass);
        void AddSubject(string subject);
        void AddDate(DateTime date);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        double CalculateAverageGrade(int studentId, string subject);
        void SaveChanges();
    }
}