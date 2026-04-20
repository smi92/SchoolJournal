using SchoolJournal.Models;  // <-- ДОБАВИТЬ ЭТО!
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SchoolJournal
{
    public partial class AddStudentDialog : Form
    {
        public string StudentName { get; private set; }
        public int ClassId { get; private set; }

        public AddStudentDialog(List<SchoolClass> classes)
        {
            InitializeComponent();
            cmbClass.DataSource = classes;
            cmbClass.DisplayMember = "Name";
            cmbClass.ValueMember = "Id";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите ФИО ученика!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StudentName = txtName.Text.Trim();
            ClassId = (int)cmbClass.SelectedValue;
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
