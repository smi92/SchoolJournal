using System;
using System.Windows.Forms;

namespace SchoolJournal
{
    public partial class GradeDialog : Form
    {
        public int GradeValue { get; private set; }

        public GradeDialog(string subject)
        {
            InitializeComponent();
            this.Text = $"Добавление оценки - {subject}";  // Название окна показывает предмет
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGrade.Text, out int grade) && grade >= 2 && grade <= 5)
            {
                GradeValue = grade;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Введите оценку от 2 до 5!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
