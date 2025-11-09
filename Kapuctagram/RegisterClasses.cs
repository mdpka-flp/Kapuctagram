using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapuctagram
{
    public static class StringUtils
    {
        public static int GetLength(string input)
        {
            return input.Length;
        }

        public static int GetUppercaseCount(string input)
        {
            return input.Count(char.IsUpper);
        }

        public static int GetNumbersCount(string input)
        {
            return input.Count(char.IsNumber);
        }

        public static int GetSpecialCharCount(string input)
        {
            return input.Count(c => !char.IsLetterOrDigit(c));
        }


        public static string TestPassword(string input)
        {
            string password = input;

            if (password.Contains(' '))
            {
                return "УБЕРИ ПРОБЕЛ, ЕБАНАТ!!!";
            }
            else if (StringUtils.GetUppercaseCount(password) < 5)
            {
                return "Недостаточно заглавных букв!";
            }
            else if (StringUtils.GetSpecialCharCount(password) < 5)
            {
                return "Недостаточно специальных символов!";
            }
            else if (StringUtils.GetNumbersCount(password) < 5)
            {
                return "Недостаточно цифр!";
            }
            else if (password.Length < 20)
            {
                return "Пароль слишком короткий!";
            }
            else if (password.Length < 34)
            {
                return "Твой пароль херня";
            }
            else
            {
                return "хз пон";
            }

            
        }
    }
}
