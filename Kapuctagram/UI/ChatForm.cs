using System;
using System.Drawing;
using System.Windows.Forms;
using Kapuctagram.Core.Models;
using Kapuctagram.Core.Services;
using Kapuctagram.Network;
using Kapuctagram.Core.Models;
using Kapuctagram.Core.Services;
using Kapuctagram.Network;

namespace KAPUCTAgram
{
    public partial class ChatForm : Form
    {
        private readonly User _currentUser;
        private ClientConnection _connection;
        private ChatService _chatService;

        public ChatForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            Text = $"KAPUCTAgram — {_currentUser.Name}";

            // Создаём подключение и сервис
            _connection = new ClientConnection();
            _chatService = new ChatService(_connection);

            // Подписываемся на события
            _connection.OnMessageReceived += OnMessageReceived;
            _connection.OnError += (error) => AppendMessage($"❌ {error}");
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            try
            {
                AppendMessage("🔌 Подключение к серверу...");
                bool connected = await _connection.ConnectAsync("127.0.0.1", 8888, _currentUser);
                if (!connected)
                {
                    MessageBox.Show("Не удалось подключиться к серверу.");
                    Close();
                    return;
                }

                AppendMessage("✅ Подключено!");
            }
            catch (Exception ex)
            {
                AppendMessage($"❌ Ошибка: {ex.Message}");
                Close();
            }
        }

        private void OnMessageReceived(Kapuctagram.Core.Models.Message message)
        {
            // Форматируем сообщение для отображения
            string displayText;
            switch (message.Type)
            {
                case MessageType.Public:
                    displayText = $"{message.SenderName}: {message.Content}";
                    break;
                case MessageType.Private:
                    displayText = $"[ЛС] {message.SenderName}: {message.Content}";
                    break;
                default:
                    displayText = $"[Неизвестно] {message.Content}";
                    break;
            }

            AppendMessage(displayText);
        }

        private async void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageTB.Text)) return;

            try
            {
                await _chatService.SendPublicMessage(MessageTB.Text, _currentUser);
                MessageTB.Clear();
            }
            catch (Exception ex)
            {
                AppendMessage($"❌ Ошибка отправки: {ex.Message}");
            }
        }

        private void MessageTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                SendMessageButton_Click(sender, e);
            }
        }

        private void AppendMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMessage), message);
                return;
            }
            ChatBox.AppendText($"{message}{Environment.NewLine}");
            ChatBox.ScrollToCaret();
        }

        private void MessageTB_TextChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(AdjustInputBoxHeight));
        }

        private void AdjustInputBoxHeight()
        {
            const int maxHeight = 120;
            const int padding = 8;

            string text = MessageTB.Text;
            int lineCount = 1;

            if (!string.IsNullOrEmpty(text))
            {
                lineCount = text.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length;
                if (text.EndsWith("\r\n"))
                    lineCount++;
            }

            int newHeight = (MessageTB.Font.Height * lineCount) + padding;
            newHeight = Math.Max(newHeight, MessageTB.Font.Height + padding);
            newHeight = Math.Min(newHeight, maxHeight);

            int bottom = MessageTB.Top + MessageTB.Height;
            MessageTB.Height = newHeight;
            MessageTB.Top = bottom - MessageTB.Height;
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection?.Dispose();
        }
    }
}