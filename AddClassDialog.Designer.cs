namespace SchoolJournal
{
    partial class AddClassDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtGradeLevel;
        private System.Windows.Forms.TextBox txtClassLetter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblGradeLevel;
        private System.Windows.Forms.Label lblClassLetter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtGradeLevel = new System.Windows.Forms.TextBox();
            this.txtClassLetter = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblGradeLevel = new System.Windows.Forms.Label();
            this.lblClassLetter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGradeLevel
            // 
            this.lblGradeLevel.AutoSize = true;
            this.lblGradeLevel.Location = new System.Drawing.Point(30, 30);
            this.lblGradeLevel.Name = "lblGradeLevel";
            this.lblGradeLevel.Size = new Size(131, 16);
            this.lblGradeLevel.TabIndex = 0;
            this.lblGradeLevel.Text = "Номер класса (1-11):";
            // 
            // txtGradeLevel
            // 
            this.txtGradeLevel.Location = new Point(180, 27);
            this.txtGradeLevel.Name = "txtGradeLevel";
            this.txtGradeLevel.Size = new Size(60, 22);
            this.txtGradeLevel.TabIndex = 1;
            // 
            // lblClassLetter
            // 
            this.lblClassLetter.AutoSize = true;
            this.lblClassLetter.Location = new Point(30, 65);
            this.lblClassLetter.Name = "lblClassLetter";
            this.lblClassLetter.Size = new Size(127, 16);
            this.lblClassLetter.TabIndex = 2;
            this.lblClassLetter.Text = "Буква класса (А, Б):";
            // 
            // txtClassLetter
            // 
            this.txtClassLetter.Location = new Point(180, 62);
            this.txtClassLetter.Name = "txtClassLetter";
            this.txtClassLetter.Size = new Size(60, 22);
            this.txtClassLetter.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new Point(50, 110);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(90, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Добавить";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new Point(150, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            this.ClientSize = new Size(280, 170);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtClassLetter);
            this.Controls.Add(this.lblClassLetter);
            this.Controls.Add(this.txtGradeLevel);
            this.Controls.Add(this.lblGradeLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddClassDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление класса";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
