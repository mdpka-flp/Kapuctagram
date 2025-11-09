using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Kapuctagram.Core;

namespace Kapuctagram.Protocol
{
    public static class MessageParser
    {
        public static async Task<ChatMessage> ReadMessageAsync(NetworkStream stream)
        {
            byte[] typeBuf = new byte[1];
            await ReadExactly(stream, typeBuf);
            char type = (char)typeBuf[0];

            byte[] lenBuf = new byte[4];
            await ReadExactly(stream, lenBuf);
            int length = BitConverter.ToInt32(lenBuf, 0);

            if (length < 0 || length > 10_000_000)
                throw new InvalidDataException("Некорректная длина сообщения");

            if (type == 'T') // Текстовое сообщение
            {
                byte[] data = new byte[length];
                await ReadExactly(stream, data);
                string text = Encoding.UTF8.GetString(data);
                return ChatMessage.CreateText(text);
            }
            else if (type == 'F') // Файл
            {
                byte[] data = new byte[length];
                await ReadExactly(stream, data);
                string fileName = Encoding.UTF8.GetString(data);
                return ChatMessage.CreateFile(fileName);
            }
            else if (type == 'A') // Аутентификация
            {
                byte[] data = new byte[length];
                await ReadExactly(stream, data);
                string text = Encoding.UTF8.GetString(data);
                return new ChatMessage { Type = type, Text = text };
            }
            else
            {
                // Пропускаем типы сообщений P/G
                byte[] skip = new byte[length];
                await ReadExactly(stream, skip);
                return new ChatMessage { Type = type, Text = "[Unsupported]" };
            }
        }

        private static async Task ReadExactly(Stream stream, byte[] buffer)
        {
            int total = 0;
            while (total < buffer.Length)
            {
                int read = await stream.ReadAsync(buffer, total, buffer.Length - total);
                if (read == 0)
                    throw new EndOfStreamException("Соединение закрыто");
                total += read;
            }
        }
    }
}