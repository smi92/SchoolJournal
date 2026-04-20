using System;
using System.Windows.Forms;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;

namespace SchoolJournal
{
    public partial class FormAuth : Form
    {
        private IAuthenticationService _authService;

        public FormAuth()
        {
            InitializeComponent();
            _authService = new AuthenticationService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (_authService.Login(login, password))
            {
                string role = _authService.GetUserRole(login);
                FormMain mainForm = new FormMain(role);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("�������� ����� ��� ������!\n",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("������� ����� � ������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ���������, ���������� �� ��� ����� ������������
            if (_authService.UserExists(login))
            {
                MessageBox.Show("������������ � ����� ������� ��� ����������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ������������ ������ ������������ � ����� "user"
            if (_authService.Register(login, password, "user"))
            {
                MessageBox.Show("����������� �������! ������ �� ������ �����.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogin.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("������ �����������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
