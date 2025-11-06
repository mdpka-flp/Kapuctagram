using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapuctagram.Core.Models
{
    public class Message
    {
        public MessageType Type { get; set; } // Text, File, Private, Group
        public string SenderId { get; set; }  // ID отправителя
        public string SenderName { get; set; } // Имя отправителя
        public string TargetId { get; set; }  // ID получателя (для ЛС) или группы
        public string Content { get; set; }   // Текст или метаданные файла
        public byte[] FileData { get; set; }  // Только при передаче файла
        public DateTime Timestamp { get; set; }
    }

    public enum MessageType
    {
        Public,
        Private,
        Group,
        File
    }
}
