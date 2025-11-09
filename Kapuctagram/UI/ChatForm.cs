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
        private readonly string _currentUserName;
        private const int MAX_LINES = 12;
        private readonly int _originalMessageTBHeight;

        public ChatForm(ClientConnection connection, string userName)
        {
            InitializeComponent();
            _connection = connection;
            _currentUserName = userName;
            _originalMessageTBHeight = MessageTB.Height;

            SendB.Click += SendButton_Click;
            MessageTB.KeyDown += MessageTB_KeyDown;
            SendFileB.Click += SendFileButton_Click;
            MessageTB.TextChanged += MessageTB_TextChanged;

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

            AppendToChat("✅ Подключено к серверу.");
        }

        private void OnMessageReceived(ChatMessage msg)
        {
            string displayText = msg.Text;

            if (msg.Type == 'T')
            {
                if (displayText.StartsWith(_currentUserName + ": "))
                {
                    displayText = "Вы: " + displayText.Substring(_currentUserName.Length + 2);
                }
                AppendToChat(displayText);
            }
            else if (msg.Type == 'F')
            {
                if (displayText.StartsWith(_currentUserName + " отправил файл: "))
                {
                    displayText = "Вы отправили файл: " + displayText.Substring((_currentUserName + " отправил файл: ").Length);
                }
                AppendToChat(displayText);
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
                if (!string.IsNullOrEmpty(ChatBox.Text))
                {
                    ChatBox.AppendText(Environment.NewLine);
                }
                ChatBox.AppendText(text);
                ChatBox.SelectionStart = ChatBox.Text.Length;
                ChatBox.ScrollToCaret();
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async Task SendMessageAsync()
        {
            string text = MessageTB.Text.Trim();
            if (!string.IsNullOrEmpty(text) && _connection != null)
            {
                try
                {
                    await _connection.SendTextAsync(text);
                    MessageTB.Clear();

                    ResetMessageTBHeight();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка отправки: {ex.Message}");
                }
            }
        }

        private void MessageTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                {
                    int selectionStart = MessageTB.SelectionStart;
                    MessageTB.Text = MessageTB.Text.Insert(selectionStart, Environment.NewLine);
                    MessageTB.SelectionStart = selectionStart + Environment.NewLine.Length;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    e.SuppressKeyPress = true;
                    _ = SendMessageAsync();
                }
            }
        }

        private void MessageTB_TextChanged(object sender, EventArgs e)
        {
            AdjustMessageTBHeight();
        }

        private void AdjustMessageTBHeight()
        {
            int lineCount = MessageTB.GetLineFromCharIndex(MessageTB.TextLength) + 1;

            if (lineCount <= 1)
            {
                MessageTB.Height = _originalMessageTBHeight;
                MessageTB.ScrollBars = ScrollBars.None;
                MessageTB.Top = 373;
            }
            else if (lineCount <= MAX_LINES)
            {
                int newHeight = _originalMessageTBHeight + (MessageTB.Font.Height * (lineCount - 1));
                MessageTB.Height = newHeight;
                MessageTB.ScrollBars = ScrollBars.None;

                MessageTB.Top = 373 - (newHeight - _originalMessageTBHeight);
            }
            else
            {
                int maxHeight = _originalMessageTBHeight + (MessageTB.Font.Height * (MAX_LINES - 1));
                MessageTB.Height = maxHeight;
                MessageTB.ScrollBars = ScrollBars.Vertical;
                MessageTB.Top = 373 - (maxHeight - _originalMessageTBHeight);
            }
        }

        private void ResetMessageTBHeight()
        {
            MessageTB.Height = _originalMessageTBHeight;
            MessageTB.Top = 373;
            MessageTB.ScrollBars = ScrollBars.None;
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
                        AppendToChat($"Вы отправили файл: {Path.GetFileName(ofd.FileName)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка отправки файла: {ex.Message}");
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