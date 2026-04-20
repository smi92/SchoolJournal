using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace SchoolJournal
{
    public partial class AddDateDialog : Form
    {
        public DateTime NewDate { get; private set; }

        public AddDateDialog()
        {
            InitializeComponent();
            dtpDate.Value = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            NewDate = dtpDate.Value.Date;
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
