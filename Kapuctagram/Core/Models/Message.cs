namespace Kapuctagram.Core
{
    public class ChatMessage
    {
        public char Type { get; set; }            // Тип сообщений (A, T, F)
        public string Text { get; set; }          // Текст для сообщения T
        public string FileName { get; set; }      // Имя файла для отправленного файла
        public long FileSize { get; set; }        // Размер отправленного файла

        // Создание сообщения
        public static ChatMessage CreateText(string text)
        {
            return new ChatMessage { Type = 'T', Text = text };
        }

        // Создание файла
        public static ChatMessage CreateFile(string fileName, long fileSize = 0)
        {
            return new ChatMessage { Type = 'F', FileName = fileName, FileSize = fileSize };
        }
    }
}