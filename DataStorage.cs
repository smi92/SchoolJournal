using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SchoolJournal.Models;
using System.Text.Json;

namespace SchoolJournal
{
    public static class DataStorage
    {
        private static string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "school_data.json");

        public static void SaveData(List<SchoolClass> classes, List<string> subjects, List<Student> students, List<DateTime> gradeDates)
        {
            try
            {
                var data = new SchoolData
                {
                    Classes = classes,
                    Subjects = subjects,
                    Students = students,
                    GradeDates = gradeDates
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true
                };

                string json = JsonSerializer.Serialize(data, options);
                File.WriteAllText(dataPath, json);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static SchoolData LoadData()
        {
            try
            {
                if (File.Exists(dataPath))
                {
                    string json = File.ReadAllText(dataPath);
                    var options = new JsonSerializerOptions
                    {
                        IncludeFields = true
                    };
                    return JsonSerializer.Deserialize<SchoolData>(json, options);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            return null;
        }
    }

    [Serializable]
    public class SchoolData
    {
        public List<SchoolClass> Classes { get; set; }
        public List<string> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public List<DateTime> GradeDates { get; set; }
    }
}
