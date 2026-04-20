namespace SchoolJournal
{
    partial class AddDateDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(30, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(47, 16);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new Point(90, 27);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new Size(120, 22);
            this.dtpDate.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new Point(50, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(90, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Добавить";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new Point(150, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            this.ClientSize = new Size(280, 140);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление даты занятия";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
