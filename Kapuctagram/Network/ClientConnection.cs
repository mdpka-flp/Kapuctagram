using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Kapuctagram.Core.Models;
using Kapuctagram.Core.Protocol;

namespace Kapuctagram.Network
{
    public class ClientConnection : IDisposable
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private StreamReader _reader;
        private StreamWriter _writer;

        public event Action<Message> OnMessageReceived;
        public event Action<string> OnError;

        /// <summary>
        /// Подключается к серверу и выполняет аутентификацию
        /// </summary>
        public async Task<bool> ConnectAsync(string ip, int port, User user)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(ip, port); // Асинхронное подключение

                _stream = _client.GetStream();
                _reader = new StreamReader(_stream);
                _writer = new StreamWriter(_stream, Encoding.UTF8) { AutoFlush = true };

                // Отправляем AUTH:password|name|userId
                string authMessage = $"AUTH:{user.Password}|{user.Name}|{user.ID}";
                await _writer.WriteLineAsync(authMessage);

                // Ждём ответ от сервера
                string response = await _reader.ReadLineAsync();
                if (response == "OK")
                {
                    // Запускаем фоновый приём сообщений
                    _ = Task.Run(ReceiveLoop); // Запускаем и не ждём
                    return true;
                }
                else
                {
                    OnError?.Invoke($"Ошибка аутентификации: {response}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Ошибка подключения: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Отправляет сообщение на сервер
        /// </summary>
        public async Task SendMessageAsync(Message message)
        {
            if (_writer == null || _client == null || !_client.Connected)
            {
                OnError?.Invoke("Нет подключения к серверу");
                return;
            }

            try
            {
                string rawMessage = MessageBuilder.Build(message);
                await _writer.WriteLineAsync(rawMessage);
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Ошибка отправки: {ex.Message}");
            }
        }

        /// <summary>
        /// Фоновый цикл приёма сообщений
        /// </summary>
        private async Task ReceiveLoop()
        {
            try
            {
                while (_client != null && _client.Connected && _stream != null)
                {
                    string line = await _reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(line))
                        break;

                    try
                    {
                        Message message = MessageParser.Parse(line);
                        OnMessageReceived?.Invoke(message);
                    }
                    catch (Exception ex)
                    {
                        OnError?.Invoke($"Ошибка парсинга: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Ошибка приёма: {ex.Message}");
            }
            finally
            {
                // Уведомляем, что соединение потеряно
                OnError?.Invoke("Соединение с сервером закрыто");
            }
        }

        /// <summary>
        /// Корректное освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            try
            {
                _writer?.Close();
                _reader?.Close();
                _client?.Close();
            }
            catch { }
            finally
            {
                _writer?.Dispose();
                _reader?.Dispose();
                _client?.Dispose();
            }
        }
    }
}