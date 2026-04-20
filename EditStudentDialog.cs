using SchoolJournal.Models;  // <-- ДОБАВИТЬ ЭТО!
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SchoolJournal
{
    public partial class EditStudentDialog : Form
    {
        private Student _student;
        private List<SchoolClass> _classes;

        public EditStudentDialog(Student student, List<SchoolClass> classes)
        {
            InitializeComponent();
            _student = student;
            _classes = classes;

            txtName.Text = student.FullName;
            cmbClass.DataSource = classes;
            cmbClass.DisplayMember = "Name";
            cmbClass.ValueMember = "Id";
            cmbClass.SelectedValue = student.ClassId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите ФИО ученика!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _student.FullName = txtName.Text.Trim();
            _student.ClassId = (int)cmbClass.SelectedValue;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
