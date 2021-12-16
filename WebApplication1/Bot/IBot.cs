using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.Model;

namespace WebApplication1.TelegramBot
{
    public interface IBot
    {
        Task SendMessageToChat(ChatMessage chatMessage);
    }
}
