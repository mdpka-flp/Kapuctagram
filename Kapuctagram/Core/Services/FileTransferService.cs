using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapuctagram.Core.Models;

namespace Kapuctagram.Core.Services
{
    public class FileTransferService
    {
        public async Task SendFileAsync(string filePath, User currentUser, string targetId)
        {
            // 1. Отправить метаданные: F|...|filename|size
            // 2. Отправить байты блоками через _connection.Stream
        }
    }
}
