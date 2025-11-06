using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kapuctagram.Core.Models;
using Kapuctagram.Core.Services;
using KAPUCTAgram;

namespace Kapuctagram
{
    public partial class RegisterForm : Form
    {
        private string serverIp = "127.0.0.1";
        private const int serverPort = 8888;
        
        public RegisterForm()
        {
            InitializeComponent();
            CheckSavedAccount();
        }

        private void CheckSavedAccount()
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "KAPUCTAgram"
            );
            string accountFile = Path.Combine(appDataPath, "current_account.txt");

            if (File.Exists(accountFile))
            {
                string[] lines = File.ReadAllLines(accountFile);
                if (lines.Length > 0)
                {
                    string[] parts = lines[0].Split('|');
                    if (parts.Length == 2)
                    {
                        // Показываем кнопку быстрого входа
                        AutoLoginB.Text = $"Войти как {parts[1]}";
                        AutoLoginB.Visible = true;

                        // Подписываем кнопку ТОЛЬКО на LoginWithSavedAccount
                        AutoLoginB.Click += (s, e) => LoginWithSavedAccount(parts[0], parts[1]);
                    }
                }
            }
        }

        private void RegisterB_Click(object sender, EventArgs e)
        {
            string password = PasswordTB.Text.Trim();
            string name = $"User_{new Random().Next(1000, 9999)}";

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пароль не может быть пустым!");
                return;
            }

            var user = new User { Name = name, Password = password };
            var accountService = new AccountService();
            accountService.SaveAccount(user);

            var chatForm = new ChatForm(user);
            chatForm.FormClosed += (s, args) => Application.Exit();
            chatForm.Show();
            this.Hide();
        }

        private void LoginWithSavedAccount(string password, string name)
        {
            // Создаём User
            var user = new User { Name = name, Password = password };

            // Сохраняем через сервис
            var accountService = new AccountService();
            accountService.SaveAccount(user);

            // Открываем чат
            var chatForm = new ChatForm(user);
            chatForm.FormClosed += (s, args) => Application.Exit();
            chatForm.Show();
            this.Hide();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            RegisterB.Enabled = false;
        }

        private void PasswordTB_TextChanged(object sender, EventArgs e)
        {
            string password = PasswordTB.Text;

            string resultOfTest = StringUtils.TestPassword(password);
            bool isPasswordOK = false;

            RegisterB.Enabled = false;
            if (resultOfTest == "Твой пароль херня" || resultOfTest == "хз пон")
            {
                isPasswordOK = true;
                RegisterB.Enabled = true;
            }
            ShowError(resultOfTest);
            

        }
        private void ShowError(string message)
        {
            Diff_of_PasswordL.Text = message;
            Diff_of_PasswordL.Visible = true;
        }
    }
}
