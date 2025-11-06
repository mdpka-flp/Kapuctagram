using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapuctagram.Core.Models;

namespace Kapuctagram.Core.Protocol
{
    public static class MessageParser
    {
        public static Message Parse(string rawMessage)
        {
            if (string.IsNullOrEmpty(rawMessage))
                throw new ArgumentException("Сообщение не может быть пустым", nameof(rawMessage));

            string[] parts = rawMessage.Split('|');
            if (parts.Length < 3)
                throw new FormatException("Неверный формат сообщения: недостаточно частей");

            Message message = new Message();

            switch (parts[0])
            {
                case "T":
                    if (parts.Length < 3) throw new FormatException("Недостаточно данных для публичного сообщения");
                    message.Type = MessageType.Public;
                    message.SenderId = parts[1];
                    message.Content = parts[2];
                    break;

                case "P":
                    if (parts.Length < 4) throw new FormatException("Недостаточно данных для личного сообщения");
                    message.Type = MessageType.Private;
                    message.SenderId = parts[1];
                    message.TargetId = parts[2];
                    message.Content = parts[3];
                    break;

                case "F":
                    if (parts.Length < 5) throw new FormatException("Недостаточно данных для файла");
                    message.Type = MessageType.File;
                    message.SenderId = parts[1];
                    message.TargetId = parts[2];
                    message.Content = parts[3]; // имя файла
                                                // parts[4] — длина файла (можно сохранить как long)
                    if (long.TryParse(parts[4], out long fileSize))
                    {
                        // Можно добавить свойство FileSize в Message, если нужно
                    }
                    break;

                default:
                    throw new NotSupportedException($"Неизвестный тип сообщения: {parts[0]}");
            }

            return message;
        }
    }
}
