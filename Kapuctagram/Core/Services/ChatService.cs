using System;
using System.Threading.Tasks;
using Kapuctagram.Core;
using Kapuctagram.Network;

namespace Kapuctagram.Services
{
    public class ChatService
    {
        private ClientConnection _connection;

        public event Action<ChatMessage> OnMessageReceived;

        public async Task ConnectAsync(string ip, int port, string historyPath)
        {
            _connection = new ClientConnection(historyPath);
            _connection.OnMessageReceived += msg => OnMessageReceived?.Invoke(msg);
            await _connection.ConnectAsync(ip, port);
        }

        public async Task SendTextAsync(string text)
        {
            await _connection.SendTextAsync(text);
        }

        public async Task SendFileAsync(string filePath)
        {
            await _connection.SendFileAsync(filePath);
        }

        public void Disconnect()
        {
            _connection?.Dispose();
        }
    }
}