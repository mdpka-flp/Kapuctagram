using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapuctagram.Core.Models;
using Kapuctagram.Network;

namespace Kapuctagram.Core.Services
{
    public class ChatService
    {
        private readonly ClientConnection _connection;
        private readonly List<Message> _history = new List<Message>();

        public ChatService(ClientConnection connection)
        {
            _connection = connection;
            _connection.OnMessageReceived += OnMessage;
        }

        private void OnMessage(Message msg)
        {
            _history.Add(msg);
            // Уведомить UI через событие
        }

        public async Task SendPublicMessage(string text, User currentUser)
        {
            var msg = new Message
            {
                Type = MessageType.Public,
                SenderId = currentUser.ID,
                Content = text
            };
            await _connection.SendMessageAsync(msg);
        }

        public async Task SendPrivateMessage(string text, User currentUser, string targetId)
        {
            // аналогично
        }
    }
}
