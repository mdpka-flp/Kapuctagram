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
                return new User();

            try
            {
                string line = File.ReadAllLines(accountFile)[0];
                string[] parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    return new User
                    {
                        Password = parts[0],
                        ID = parts[1],
                        Name = parts[2]
                    };
                }
                else if (parts.Length >= 2)
                {
                    return new User
                    {
                        Password = parts[0],
                        Name = parts[1],
                        ID = string.Empty
                    };
                }
            }
            catch (Exception)
            {

            }

            return new User();
        }

        public void SaveAccount(User user)
        {
            Directory.CreateDirectory(_appDataPath);
            string accountFile = Path.Combine(_appDataPath, "current_account.txt");

            string record = $"{user.Password}|{user.ID}|{user.Name}";
            File.WriteAllText(accountFile, record);
        }
    }
}
