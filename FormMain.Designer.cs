using System.Drawing;
using System.Windows.Forms;

namespace SchoolJournal
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ListBox lstStudents;
        private DataGridView dgvGrades;
        private Button btnAddGrade;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnAddStudent;
        private Button btnAddClass;
        private Button btnAddSubject;
        private Button btnAddDate;
        private Button btnInfo;
        private Label lblRole;
        private Label lblCurrentClass;
        private Label lblCurrentSubject;
        private Label lblAverage;
        private Label lblStudentInfo;
        private Panel panelTop;
        private Panel panelLeft;
        private Panel panelRight;
        private Panel panelBottom;
        private Panel panelClassSubject;
        private Panel panelButtons;
        private Panel panelStudentBottom;
        private FlowLayoutPanel flowTopPanel;
        private SplitContainer splitContainer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            lstStudents = new ListBox();
            dgvGrades = new DataGridView();
            btnAddGrade = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnAddStudent = new Button();
            btnAddClass = new Button();
            btnAddSubject = new Button();
            btnAddDate = new Button();
            btnInfo = new Button();
            lblRole = new Label();
            lblCurrentClass = new Label();
            lblCurrentSubject = new Label();
            lblAverage = new Label();
            lblStudentInfo = new Label();
            panelTop = new Panel();
            flowTopPanel = new FlowLayoutPanel();
            panelClassSubject = new Panel();
            panelButtons = new Panel();
            panelLeft = new Panel();
            panelStudentBottom = new Panel();
            panelRight = new Panel();
            panelBottom = new Panel();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dgvGrades).BeginInit();
            panelTop.SuspendLayout();
            flowTopPanel.SuspendLayout();
            panelClassSubject.SuspendLayout();
            panelButtons.SuspendLayout();
            panelLeft.SuspendLayout();
            panelStudentBottom.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(967, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // lstStudents
            // 
            lstStudents.Dock = DockStyle.Fill;
            lstStudents.Font = new Font("Microsoft Sans Serif", 10F);
            lstStudents.FormattingEnabled = true;
            lstStudents.Location = new Point(0, 0);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(219, 415);
            lstStudents.TabIndex = 0;
            lstStudents.SelectedIndexChanged += lstStudents_SelectedIndexChanged;
            // 
            // dgvGrades
            // 
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.AllowUserToDeleteRows = false;
            dgvGrades.BackgroundColor = Color.White;
            dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrades.Dock = DockStyle.Fill;
            dgvGrades.Location = new Point(0, 0);
            dgvGrades.Name = "dgvGrades";
            dgvGrades.ReadOnly = true;
            dgvGrades.RowHeadersWidth = 51;
            dgvGrades.RowTemplate.Height = 30;
            dgvGrades.Size = new Size(744, 395);
            dgvGrades.TabIndex = 0;
            // 
            // btnAddGrade
            // 
            btnAddGrade.BackColor = Color.FromArgb(46, 204, 113);
            btnAddGrade.FlatStyle = FlatStyle.Flat;
            btnAddGrade.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnAddGrade.ForeColor = Color.White;
            btnAddGrade.Location = new Point(9, 21);
            btnAddGrade.Name = "btnAddGrade";
            btnAddGrade.Size = new Size(101, 33);
            btnAddGrade.TabIndex = 0;
            btnAddGrade.Text = "Добавить";
            btnAddGrade.UseVisualStyleBackColor = false;
            btnAddGrade.Click += btnAddGrade_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(118, 21);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(101, 33);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(228, 21);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 33);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.FromArgb(46, 204, 113);
            btnAddStudent.Dock = DockStyle.Top;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(0, 0);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(219, 28);
            btnAddStudent.TabIndex = 0;
            btnAddStudent.Text = "+ Добавить ученика";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnAddClass
            // 
            btnAddClass.BackColor = Color.FromArgb(46, 204, 113);
            btnAddClass.FlatStyle = FlatStyle.Flat;
            btnAddClass.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnAddClass.ForeColor = Color.White;
            btnAddClass.Location = new Point(9, 28);
            btnAddClass.Name = "btnAddClass";
            btnAddClass.Size = new Size(88, 26);
            btnAddClass.TabIndex = 1;
            btnAddClass.Text = "+ Класс";
            btnAddClass.UseVisualStyleBackColor = false;
            btnAddClass.Click += btnAddClass_Click;
            // 
            // btnAddSubject
            // 
            btnAddSubject.BackColor = Color.FromArgb(52, 152, 219);
            btnAddSubject.FlatStyle = FlatStyle.Flat;
            btnAddSubject.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnAddSubject.ForeColor = Color.White;
            btnAddSubject.Location = new Point(114, 28);
            btnAddSubject.Name = "btnAddSubject";
            btnAddSubject.Size = new Size(96, 26);
            btnAddSubject.TabIndex = 3;
            btnAddSubject.Text = "+ Предмет";
            btnAddSubject.UseVisualStyleBackColor = false;
            btnAddSubject.Click += btnAddSubject_Click;
            // 
            // btnAddDate
            // 
            btnAddDate.BackColor = Color.FromArgb(155, 89, 182);
            btnAddDate.FlatStyle = FlatStyle.Flat;
            btnAddDate.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnAddDate.ForeColor = Color.White;
            btnAddDate.Location = new Point(228, 28);
            btnAddDate.Name = "btnAddDate";
            btnAddDate.Size = new Size(96, 26);
            btnAddDate.TabIndex = 4;
            btnAddDate.Text = "+ Дата занятия";
            btnAddDate.UseVisualStyleBackColor = false;
            btnAddDate.Click += btnAddDate_Click;
            // 
            // btnInfo
            // 
            btnInfo.BackColor = Color.White;
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnInfo.ForeColor = Color.Black;
            btnInfo.Location = new Point(923, 23);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(31, 33);
            btnInfo.TabIndex = 99;
            btnInfo.Text = "?";
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += btnInfo_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Microsoft Sans Serif", 8F);
            lblRole.ForeColor = Color.FromArgb(241, 196, 15);
            lblRole.Location = new Point(9, 56);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(117, 13);
            lblRole.TabIndex = 5;
            lblRole.Text = "Роль: Администратор";
            // 
            // lblCurrentClass
            // 
            lblCurrentClass.AutoSize = true;
            lblCurrentClass.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblCurrentClass.ForeColor = Color.White;
            lblCurrentClass.Location = new Point(9, 8);
            lblCurrentClass.Name = "lblCurrentClass";
            lblCurrentClass.Size = new Size(64, 15);
            lblCurrentClass.TabIndex = 0;
            lblCurrentClass.Text = "Класс: --";
            // 
            // lblCurrentSubject
            // 
            lblCurrentSubject.AutoSize = true;
            lblCurrentSubject.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblCurrentSubject.ForeColor = Color.White;
            lblCurrentSubject.Location = new Point(114, 8);
            lblCurrentSubject.Name = "lblCurrentSubject";
            lblCurrentSubject.Size = new Size(85, 15);
            lblCurrentSubject.TabIndex = 2;
            lblCurrentSubject.Text = "Предмет: --";
            // 
            // lblAverage
            // 
            lblAverage.BackColor = Color.FromArgb(52, 73, 94);
            lblAverage.Dock = DockStyle.Bottom;
            lblAverage.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblAverage.ForeColor = Color.White;
            lblAverage.Location = new Point(0, 395);
            lblAverage.Name = "lblAverage";
            lblAverage.Size = new Size(744, 38);
            lblAverage.TabIndex = 1;
            lblAverage.Text = "Средний балл: --";
            lblAverage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.Dock = DockStyle.Bottom;
            lblStudentInfo.Font = new Font("Microsoft Sans Serif", 9F);
            lblStudentInfo.ForeColor = Color.White;
            lblStudentInfo.Location = new Point(0, 28);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(219, 28);
            lblStudentInfo.TabIndex = 1;
            lblStudentInfo.Text = "Выберите ученика";
            lblStudentInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 73, 94);
            panelTop.Controls.Add(btnInfo);
            panelTop.Controls.Add(flowTopPanel);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 24);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(967, 75);
            panelTop.TabIndex = 1;
            // 
            // flowTopPanel
            // 
            flowTopPanel.Controls.Add(panelClassSubject);
            flowTopPanel.Controls.Add(panelButtons);
            flowTopPanel.Dock = DockStyle.Left;
            flowTopPanel.Location = new Point(0, 0);
            flowTopPanel.Name = "flowTopPanel";
            flowTopPanel.Size = new Size(919, 75);
            flowTopPanel.TabIndex = 0;
            // 
            // panelClassSubject
            // 
            panelClassSubject.BackColor = Color.FromArgb(52, 73, 94);
            panelClassSubject.Controls.Add(lblCurrentClass);
            panelClassSubject.Controls.Add(btnAddClass);
            panelClassSubject.Controls.Add(lblCurrentSubject);
            panelClassSubject.Controls.Add(btnAddSubject);
            panelClassSubject.Controls.Add(btnAddDate);
            panelClassSubject.Controls.Add(lblRole);
            panelClassSubject.Location = new Point(3, 3);
            panelClassSubject.Name = "panelClassSubject";
            panelClassSubject.Size = new Size(569, 69);
            panelClassSubject.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(52, 73, 94);
            panelButtons.Controls.Add(btnAddGrade);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Location = new Point(578, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(332, 69);
            panelButtons.TabIndex = 1;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(236, 240, 241);
            panelLeft.Controls.Add(lstStudents);
            panelLeft.Controls.Add(panelStudentBottom);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(219, 471);
            panelLeft.TabIndex = 0;
            // 
            // panelStudentBottom
            // 
            panelStudentBottom.BackColor = Color.FromArgb(52, 73, 94);
            panelStudentBottom.Controls.Add(btnAddStudent);
            panelStudentBottom.Controls.Add(lblStudentInfo);
            panelStudentBottom.Dock = DockStyle.Bottom;
            panelStudentBottom.Location = new Point(0, 415);
            panelStudentBottom.Name = "panelStudentBottom";
            panelStudentBottom.Size = new Size(219, 56);
            panelStudentBottom.TabIndex = 1;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(dgvGrades);
            panelRight.Controls.Add(lblAverage);
            panelRight.Controls.Add(panelBottom);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(744, 471);
            panelRight.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(236, 240, 241);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 433);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(744, 38);
            panelBottom.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 99);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelLeft);
            splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelRight);
            splitContainer1.Size = new Size(967, 471);
            splitContainer1.SplitterDistance = 219;
            splitContainer1.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 570);
            Controls.Add(splitContainer1);
            Controls.Add(panelTop);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(702, 471);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Школьный журнал - Главное окно";
            FormClosing += FormMain_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvGrades).EndInit();
            panelTop.ResumeLayout(false);
            flowTopPanel.ResumeLayout(false);
            panelClassSubject.ResumeLayout(false);
            panelClassSubject.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelStudentBottom.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
