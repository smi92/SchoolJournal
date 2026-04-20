using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolJournal
{
    public partial class DateDialog : Form
    {
        public DateTime SelectedDate { get; private set; }
        private List<DateTime> availableDates;

        public DateDialog(List<DateTime> dates)
        {
            InitializeComponent();
            availableDates = dates;

            foreach (var date in availableDates)
            {
                cmbDate.Items.Add(date.ToString("dd.MM.yyyy"));
            }
            if (cmbDate.Items.Count > 0)
                cmbDate.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbDate.SelectedIndex >= 0)
            {
                SelectedDate = availableDates[cmbDate.SelectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите дату!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
