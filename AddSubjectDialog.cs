using System;
using System.Windows.Forms;

namespace SchoolJournal
{
    public partial class AddSubjectDialog : Form
    {
        public string SubjectName { get; private set; }

        public AddSubjectDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                SubjectName = txtSubjectName.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Введите название предмета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
