// Kapuctagram/UI/ChatForm.cs
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kapuctagram.Core;
using Kapuctagram.Network;

namespace Kapuctagram.UI
{
    public partial class ChatForm : Form
    {
        private readonly ClientConnection _connection;

        public ChatForm(string historyPath)
        {
            InitializeComponent();
            _connection = new ClientConnection(historyPath);
            _connection.OnMessageReceived += (msg) =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<ChatMessage>(OnMessageReceived), msg);
                }
                else
                {
                    OnMessageReceived(msg);
                }
            };
        }

        public void ConnectToServer(string ip, int port)
        {
            // Запускаем подключение асинхронно
            _ = Task.Run(async () =>
            {
                try
                {
                    await _connection.ConnectAsync(ip, port);
                    AppendToChat("✅ Подключено к серверу.\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            });
        }

        private void OnMessageReceived(ChatMessage msg)
        {
            if (msg.Type == 'T')
            {
                AppendToChat($"[Текст] {msg.Text}\n");
            }
            else if (msg.Type == 'F')
            {
                AppendToChat($"[Файл] {msg.FileName} (на сервере)\n");
            }
        }

        private void AppendToChat(string text)
        {
            if (ChatBox.InvokeRequired)
            {
                ChatBox.Invoke(new Action<string>(AppendToChat), text);
            }
            else
            {
                ChatBox.AppendText(text);
                ChatBox.SelectionStart = ChatBox.Text.Length;
                ChatBox.ScrollToCaret();
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            string text = MessageTB.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                await _connection.SendTextAsync(text);
                MessageTB.Clear();
            }
        }

        private async void SendFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await _connection.SendFileAsync(ofd.FileName);
                        AppendToChat($"[Файл отправлен] {Path.GetFileName(ofd.FileName)}\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка отправки: {ex.Message}");
                    }
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _connection?.Dispose();
            base.OnFormClosed(e);
        }
    }
}