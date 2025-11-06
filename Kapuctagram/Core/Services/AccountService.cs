using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapuctagram.Core.Models;

namespace Kapuctagram.Core.Services
{
    public class AccountService
    {
        private readonly string _appDataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "KAPUCTAgram"
        );

        public User LoadSavedAccount()
        {
            string accountFile = Path.Combine(_appDataPath, "current_account.txt");

            if (!File.Exists(accountFile))
                return new User(); // пустой аккаунт

            try
            {
                string line = File.ReadAllLines(accountFile)[0];
                string[] parts = line.Split('|');
                if (parts.Length >= 2)
                {
                    return new User
                    {
                        Password = parts[0],
                        Name = parts[1],
                        ID = parts.Length > 2 ? parts[2] : string.Empty
                    };
                }
            }
            catch (Exception)
            {
                // Игнорируем ошибки
            }

            return new User(); // пустой аккаунт в случае ошибки
        }

        public void SaveAccount(User user)
        {
            // Сохраняет в current_account.txt
        }
    }
}
