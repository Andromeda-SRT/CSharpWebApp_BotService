using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.Model;
using WebApplication1.TelegramBot;

namespace WebApplication1.Service
{
    public interface IChatIService
    {
        void processMessage(ChatMessage chatMessage);
        void registerBot(IBot bot);
    }
}
