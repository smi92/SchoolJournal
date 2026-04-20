using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SchoolJournal.Models;
using SchoolJournal.Interfaces;

namespace SchoolJournal
{
    public partial class FormMain : Form
    {
        private string userRole;
        private IGradeRepository _gradeRepository;
        private List<Student> students;
        private List<SchoolClass> classes;
        private List<string> subjects;
        private Student selectedStudent;
        private int currentClassId;
        private string currentClassName = "";
        private string currentSubject = "";
        private List<DateTime> gradeDates;

        public FormMain(string role)
        {
            InitializeComponent();
            userRole = role;
            _gradeRepository = new GradeRepository();
            InitializeData();
            SetupMenu();
            ApplyPermissions();
        }

        private void InitializeData()
        {
            classes = _gradeRepository.GetAllClasses();
            subjects = _gradeRepository.GetAllSubjects();
            students = _gradeRepository.GetAllStudents();
            gradeDates = _gradeRepository.GetAllDates();
        }

        private void SetupMenu()
        {
            // Меню классов
            var classesMenuItem = new ToolStripMenuItem("Выбор классов");
            foreach (var classItem in classes)
            {
                var item = new ToolStripMenuItem(classItem.Name);
                item.Click += (s, e) => LoadStudentsByClass(classItem.Id, classItem.Name);
                classesMenuItem.DropDownItems.Add(item);
            }
            menuStrip1.Items.Add(classesMenuItem);

            // Меню предметов
            var subjectsMenuItem = new ToolStripMenuItem("Предметы");
            foreach (var subject in subjects)
            {
                var item = new ToolStripMenuItem(subject);
                item.Click += (s, e) => LoadGradesBySubject(subject);
                subjectsMenuItem.DropDownItems.Add(item);
            }
            menuStrip1.Items.Add(subjectsMenuItem);
        }

        private void LoadStudentsByClass(int classId, string className)
        {
            var classStudents = _gradeRepository.GetStudentsByClass(classId);
            lstStudents.Items.Clear();
            foreach (var student in classStudents)
            {
                lstStudents.Items.Add(student);
            }
            lblCurrentClass.Text = $"Класс: {className}";
            currentClassId = classId;
            currentClassName = className;

            if (lstStudents.Items.Count > 0)
                lstStudents.SelectedIndex = 0;
        }

        private void LoadGradesBySubject(string subject)
        {
            currentSubject = subject;
            lblCurrentSubject.Text = $"Предмет: {subject}";

            if (selectedStudent != null)
            {
                UpdateGradesGrid(selectedStudent, subject);
            }
            else if (lstStudents.Items.Count > 0)
            {
                lstStudents.SelectedIndex = 0;
            }
        }

        private void UpdateGradesGrid(Student student, string subject)
        {
            dgvGrades.Rows.Clear();
            dgvGrades.Columns.Clear();

            // Добавляем колонку для имени ученика
            dgvGrades.Columns.Add("StudentName", "Ученик");
            dgvGrades.Columns[0].Width = 200;
            dgvGrades.Columns[0].Frozen = true;

            // Добавляем колонки для каждой даты
            foreach (var date in gradeDates)
            {
                dgvGrades.Columns.Add(date.ToString("dd.MM.yyyy"), date.ToString("dd.MM.yyyy"));
                dgvGrades.Columns[dgvGrades.Columns.Count - 1].Width = 90;
            }

            // Добавляем колонку для среднего балла
            dgvGrades.Columns.Add("Average", "Средний балл");
            dgvGrades.Columns[dgvGrades.Columns.Count - 1].Width = 100;

            // Получаем всех учеников текущего класса
            var classStudents = _gradeRepository.GetStudentsByClass(currentClassId);

            foreach (var stud in classStudents)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvGrades);

                // Имя ученика
                row.Cells[0].Value = stud.FullName;

                double totalGrade = 0;
                int gradeCount = 0;

                // Оценки по датам
                for (int i = 0; i < gradeDates.Count; i++)
                {
                    int grade = stud.GetGrade(subject, gradeDates[i]);

                    if (grade > 0)
                    {
                        row.Cells[i + 1].Value = grade.ToString();
                        totalGrade += grade;
                        gradeCount++;

                        // Раскраска оценок
                        if (grade == 5)
                            row.Cells[i + 1].Style.ForeColor = System.Drawing.Color.Green;
                        else if (grade == 4)
                            row.Cells[i + 1].Style.ForeColor = System.Drawing.Color.Blue;
                        else if (grade == 3)
                            row.Cells[i + 1].Style.ForeColor = System.Drawing.Color.Orange;
                        else if (grade == 2)
                            row.Cells[i + 1].Style.ForeColor = System.Drawing.Color.Red;

                        row.Cells[i + 1].Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells[i + 1].Value = "";
                    }
                }

                // Средний балл
                double average = gradeCount > 0 ? totalGrade / gradeCount : 0;
                row.Cells[gradeDates.Count + 1].Value = average.ToString("F2");

                if (average >= 4.5)
                    row.Cells[gradeDates.Count + 1].Style.ForeColor = System.Drawing.Color.Green;
                else if (average >= 3.5)
                    row.Cells[gradeDates.Count + 1].Style.ForeColor = System.Drawing.Color.Blue;
                else if (average >= 2.5)
                    row.Cells[gradeDates.Count + 1].Style.ForeColor = System.Drawing.Color.Orange;
                else if (average > 0)
                    row.Cells[gradeDates.Count + 1].Style.ForeColor = System.Drawing.Color.Red;

                row.Cells[gradeDates.Count + 1].Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                dgvGrades.Rows.Add(row);

                if (stud.Id == selectedStudent?.Id)
                {
                    lblAverage.Text = $"Средний балл {stud.FullName}: {average:F2}";
                }
            }

            // Настройка внешнего вида
            dgvGrades.RowHeadersVisible = false;
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.ReadOnly = true;
            dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvGrades.Columns[0].Frozen = true;
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudents.SelectedItem != null)
            {
                selectedStudent = (Student)lstStudents.SelectedItem;
                lblStudentInfo.Text = $"Выбран: {selectedStudent.FullName}";
                if (!string.IsNullOrEmpty(currentSubject))
                {
                    UpdateGradesGrid(selectedStudent, currentSubject);
                }
            }
        }

        private void ApplyPermissions()
        {
            if (userRole == "user")
            {
                btnAddGrade.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnAddStudent.Enabled = false;
                btnAddClass.Enabled = false;
                btnAddSubject.Enabled = false;
                btnAddDate.Enabled = false;
                lblRole.Text = "Роль: Ученик (только просмотр)";
            }
            else
            {
                btnAddGrade.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAddStudent.Enabled = true;
                btnAddClass.Enabled = true;
                btnAddSubject.Enabled = true;
                btnAddDate.Enabled = true;
                lblRole.Text = "Роль: Администратор (полный доступ)";
            }
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Выберите ученика!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentSubject))
            {
                MessageBox.Show("Выберите предмет в меню 'Предметы'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Выбор даты
            var dateDialog = new DateDialog(gradeDates);
            if (dateDialog.ShowDialog() == DialogResult.OK)
            {
                var gradeDialog = new GradeDialog(currentSubject);
                if (gradeDialog.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем оценку для конкретной даты
                    _gradeRepository.AddGrade(selectedStudent.Id, currentSubject, dateDialog.SelectedDate, gradeDialog.GradeValue);
                    UpdateGradesGrid(selectedStudent, currentSubject);
                    MessageBox.Show($"Оценка {gradeDialog.GradeValue} за {dateDialog.SelectedDate:dd.MM.yyyy} успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var addDialog = new AddStudentDialog(classes);
            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                int newId = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
                var newStudent = new Student(newId, addDialog.StudentName, addDialog.ClassId);
                _gradeRepository.AddStudent(newStudent);
                students = _gradeRepository.GetAllStudents(); // Обновляем список
                LoadStudentsByClass(currentClassId, currentClassName);
                MessageBox.Show("Ученик успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            var addClassDialog = new AddClassDialog();
            if (addClassDialog.ShowDialog() == DialogResult.OK)
            {
                int newId = classes.Count + 1;
                var newClass = new SchoolClass(newId, addClassDialog.ClassName, addClassDialog.GradeLevel, addClassDialog.ClassLetter);
                _gradeRepository.AddClass(newClass);
                classes = _gradeRepository.GetAllClasses(); // Обновляем список

                // Обновляем меню классов
                UpdateClassesMenu();

                MessageBox.Show($"Класс {addClassDialog.ClassName} успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            var addSubjectDialog = new AddSubjectDialog();
            if (addSubjectDialog.ShowDialog() == DialogResult.OK)
            {
                _gradeRepository.AddSubject(addSubjectDialog.SubjectName);
                subjects = _gradeRepository.GetAllSubjects(); // Обновляем список

                // Обновляем меню предметов
                UpdateSubjectsMenu();

                MessageBox.Show($"Предмет {addSubjectDialog.SubjectName} успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
            var addDateDialog = new AddDateDialog();
            if (addDateDialog.ShowDialog() == DialogResult.OK)
            {
                _gradeRepository.AddDate(addDateDialog.NewDate);
                gradeDates = _gradeRepository.GetAllDates(); // Обновляем список

                // Обновляем таблицу
                if (selectedStudent != null && !string.IsNullOrEmpty(currentSubject))
                {
                    UpdateGradesGrid(selectedStudent, currentSubject);
                }

                MessageBox.Show($"Дата {addDateDialog.NewDate:dd.MM.yyyy} успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Выберите ученика!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editDialog = new EditStudentDialog(selectedStudent, classes);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                _gradeRepository.UpdateStudent(selectedStudent);
                LoadStudentsByClass(currentClassId, currentClassName);
                MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Выберите ученика!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы действительно хотите удалить запись об ученике {selectedStudent.FullName}?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _gradeRepository.DeleteStudent(selectedStudent.Id);
                students = _gradeRepository.GetAllStudents(); // Обновляем список
                LoadStudentsByClass(currentClassId, currentClassName);
                dgvGrades.Rows.Clear();
                selectedStudent = null;
                MessageBox.Show("Запись успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Школьный журнал - система учета успеваемости\n\n" +
                "Версия: 2.0\n" +
                "Разработчик: Кириллов Данил Романович\n" +
                "Донецкий государственный университет\n\n" +
                "Функции:\n" +
                "- Ведение учета успеваемости по датам\n" +
                "- Автоматический расчет среднего балла\n" +
                "- Разграничение прав доступа (admin/user)\n" +
                "- Добавление/редактирование/удаление учеников\n" +
                "- Добавление новых классов\n" +
                "- Добавление новых предметов\n" +
                "- Добавление новых дат занятий\n" +
                "- Автоматическое сохранение данных в файл\n\n" ,
                
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateClassesMenu()
        {
            var classesMenuItem = menuStrip1.Items[0] as ToolStripMenuItem;
            if (classesMenuItem != null)
            {
                classesMenuItem.DropDownItems.Clear();
                foreach (var classItem in classes)
                {
                    var item = new ToolStripMenuItem(classItem.Name);
                    item.Click += (s, e) => LoadStudentsByClass(classItem.Id, classItem.Name);
                    classesMenuItem.DropDownItems.Add(item);
                }
            }
        }

        private void UpdateSubjectsMenu()
        {
            var subjectsMenuItem = menuStrip1.Items[1] as ToolStripMenuItem;
            if (subjectsMenuItem != null)
            {
                subjectsMenuItem.DropDownItems.Clear();
                foreach (var subject in subjects)
                {
                    var item = new ToolStripMenuItem(subject);
                    item.Click += (s, e) => LoadGradesBySubject(subject);
                    subjectsMenuItem.DropDownItems.Add(item);
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gradeRepository.SaveChanges();
            Application.Exit();
        }
    }
}
