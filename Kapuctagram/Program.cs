using System;
using System.Windows.Forms;
using Kapuctagram;
using Kapuctagram.UI;

namespace KAPUCTAgram
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Показываем форму подключения к серверу
            var connectionForm = new ConnectionForm();
            var result = connectionForm.ShowDialog();

            // Если пользователь нажал "Подключиться" и подключение прошло успешно
            if (result == DialogResult.OK)
            {
                // Передаём IP и порт в форму регистрации/входа
                var registerForm = new RegisterForm(connectionForm.ServerIP, connectionForm.ServerPort);
                Application.Run(registerForm);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}