using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapuctagram.Core.Models
{
    public class User
    {
        public string ID { get; set; }       // Уникальный ID пользователя
        public string Name { get; set; }     // Никнейм (может быть изменён)
        public string Password { get; set; } // Пароль
    }
}