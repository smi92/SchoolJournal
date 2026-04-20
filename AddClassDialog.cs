using System;
using System.Windows.Forms;

namespace SchoolJournal
{
    public partial class AddClassDialog : Form
    {
        public int GradeLevel { get; private set; }
        public string ClassLetter { get; private set; }
        public string ClassName { get; private set; }

        public AddClassDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGradeLevel.Text, out int gradeLevel) && gradeLevel >= 1 && gradeLevel <= 11)
            {
                if (!string.IsNullOrWhiteSpace(txtClassLetter.Text))
                {
                    GradeLevel = gradeLevel;
                    ClassLetter = txtClassLetter.Text.Trim().ToUpper();
                    ClassName = $"{GradeLevel}-{ClassLetter}";
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Введите букву класса (А, Б, В и т.д.)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите номер класса от 1 до 11!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
