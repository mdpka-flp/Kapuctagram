// Kapuctagram/Network/ClientConnection.cs
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kapuctagram.Core;
using Kapuctagram.Core.Models;
using Kapuctagram.Protocol;

namespace Kapuctagram.Network
{
    public class ClientConnection : IDisposable
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private readonly string _historyPath;
        private bool _disposed = false;

        public event Action<ChatMessage> OnMessageReceived;

        public ClientConnection(string historyPath)
        {
            _historyPath = historyPath;
            Directory.CreateDirectory(Path.GetDirectoryName(_historyPath));
        }

        // Подключение без аутентификации — остаётся
        public async Task ConnectAsync(string ip, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(ip, port);
            _stream = _client.GetStream();
        }

        // 🔑 НОВОЕ: аутентификация
        public async Task<User> AuthenticateAsync(string password, string name)
        {
            string authData = $"{password} | {name}";
            await SendRawAsync('A', authData);

            // Ждём ответ от сервера
            var responseMsg = await MessageParser.ReadMessageAsync(_stream);
            if (responseMsg.Type != 'A')
                throw new InvalidOperationException("Сервер не вернул данные аутентификации");

            string[] parts = responseMsg.Text.Split(new string[] { " | " }, StringSplitOptions.None);
            if (parts.Length != 2)
                throw new InvalidDataException("Некорректный ответ сервера");

            string userId = parts[0];
            string finalName = parts[1];

            // Запускаем прослушку сообщений
            _ = ListenAsync();

            return new User { ID = userId, Name = finalName, Password = password };
        }

        // Прослушка — остаётся
        private async Task ListenAsync()
        {
            try
            {
                while (!_disposed && _client.Connected)
                {
                    var msg = await MessageParser.ReadMessageAsync(_stream);
                    File.AppendAllText(_historyPath, $"[{msg.Type}] {DateTime.Now:HH:mm} {msg.Text}\n");
                    OnMessageReceived?.Invoke(new ChatMessage { Type = msg.Type, Text = msg.Text });
                }
            }
            catch (Exception ex)
            {
                if (!_disposed)
                    MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Отправка текста — остаётся
        public async Task SendTextAsync(string text)
        {
            await SendRawAsync('T', text);
        }

        // Отправка файла — остаётся
        public async Task SendFileAsync(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            long fileSize = new FileInfo(filePath).Length;
            if (fileSize > 8L * 1024 * 1024 * 1024)
                throw new InvalidOperationException("Файл >8 ГБ");

            await SendRawAsync('F', fileName);

            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[256 * 1024];
                int bytesRead;
                while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await _stream.WriteAsync(buffer, 0, bytesRead);
                }
            }

            File.AppendAllText(_historyPath, $"[FILE SENT] {DateTime.Now:HH:mm} {fileName}\n");
        }

        // Вспомогательный метод — остаётся
        private async Task SendRawAsync(char type, string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            await _stream.WriteAsync(new byte[] { (byte)type }, 0, 1);
            await _stream.WriteAsync(BitConverter.GetBytes(dataBytes.Length), 0, 4);
            await _stream.WriteAsync(dataBytes, 0, dataBytes.Length);
        }

        // Dispose — остаётся
        public void Dispose()
        {
            _disposed = true;
            _client?.Close();
            _client?.Dispose();
        }
    }
}