using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kapuctagram.Core.Models;

namespace Kapuctagram.Core.Protocol
{
    public static class MessageBuilder
    {
        public static string Build(Kapuctagram.Core.Models.Message msg)
        {
            switch (msg.Type)
            {
                case MessageType.Public:
                    return $"T|{msg.SenderId}|{msg.Content}";
                case MessageType.Private:
                    return $"P|{msg.SenderId}|{msg.TargetId}|{msg.Content}";
                case MessageType.File:
                    return $"F|{msg.SenderId}|{msg.TargetId}|{msg.Content}|{msg.FileData?.Length ?? 0}";
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
