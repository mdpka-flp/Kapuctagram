// Kapuctagram/UI/ConnectionForm.cs
using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Kapuctagram.Network;

namespace Kapuctagram.UI
{
    public partial class ConnectionForm : Form
    {
        public string ServerIP { get; private set; }
        public int ServerPort { get; private set; }

        public ConnectionForm()
        {
            InitializeComponent();
            PortTB.Text = "1337";
        }

        private async void ConnectB_Click(object sender, EventArgs e)
        {
            string ip = IPTB.Text.Trim();
            if (!int.TryParse(PortTB.Text, out int port) || port <= 0 || port > 65535)
            {
                MessageBox.Show("Некорректный порт");
                return;
            }

            try
            {
                var testClient = new TcpClient();
                await testClient.ConnectAsync(ip, port);
                testClient.Close();

                ServerIP = ip;
                ServerPort = port;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключиться:\n{ex.Message}");
            }
        }
    }
}