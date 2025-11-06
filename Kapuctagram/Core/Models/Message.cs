// Kapuctagram/Core/ChatMessage.cs
namespace Kapuctagram.Core
{
    public class ChatMessage
    {
        public char Type { get; set; }
        public string Text { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }

        // Фабричные методы
        public static ChatMessage CreateText(string text)
        {
            return new ChatMessage { Type = 'T', Text = text };
        }

        public static ChatMessage CreateFile(string fileName, long fileSize = 0)
        {
            return new ChatMessage { Type = 'F', FileName = fileName, FileSize = fileSize };
        }
    }
}