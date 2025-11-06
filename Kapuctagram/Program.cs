using System;
using System.Windows.Forms;
using Kapuctagram;
using Kapuctagram.UI; // ← важно: пространство имён, где лежат ConnectionForm и RegisterForm

namespace KAPUCTAgram
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Шаг 1: Показываем форму подключения к серверу
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
                // Пользователь закрыл окно подключения — завершаем приложение
                Application.Exit();
            }
        }
    }
}