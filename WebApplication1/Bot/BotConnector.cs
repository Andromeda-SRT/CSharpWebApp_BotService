using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Model;
using WebApplication1.Repository;
using WebApplication1.Service;
using WebApplication1.TelegramBot;
using Confluent.Kafka;
using Newtonsoft.Json;
using WebApplication1.AccessTokens;

namespace TelegramBot.Bot
{
    public class BotConnector : IBot, IHostedService
    {

        private readonly ILogger<BotConnector> _logger;//Логгер для красивого логирования
        private readonly TelegramBotClient _botClient = new
            TelegramBotClient(myTokens.TelegramToken); //For create telegram-bot - need past your token

        //
        private readonly Dictionary<string, IProducer<Null, string>> _producers = new Dictionary<string, IProducer<Null, string>>();

        //
        private readonly IServiceScopeFactory _services;


        public BotConnector(IServiceScopeFactory services, ILogger<BotConnector> logger)
        {
            //
            this._services = services;

            this._logger = logger; // Забираем логгер с помощью ASP.NET Dependency Injection
        }


        public Task StartAsync(CancellationToken cancellationToken)
        { //Запускается при запуске IHostedService, при регистрации
            using var cts = new CancellationTokenSource();

            _botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                cancellationToken: cts.Token); //Начинаем получать и обрабатывать сообщения/обновления в методах HandleUpdateAsync и
                                               //HandleErrorAsync

            _logger.LogInformation("Bot init"); //Логируем
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task SendMessageToChat(long chatId, String text)
        {// Метод для отправки сообщения в чат
            await _botClient.SendTextMessageAsync(
            chatId: chatId,
            text: text
            ); //Асинхронная отправка сообщения с укзанием ИД чата и самим текстом
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        { //Поимка ошибок API и вывод их в лог
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{ apiRequestException.ErrorCode}]\n{ apiRequestException.Message}",
                _ => exception.ToString()
            }; // Распаковываем содержимое ошибки, получая сообщение ошибки

            _logger.LogError("Error on Telegram Api", exception); //Логируем ошибку
            return Task.CompletedTask; // Завершаем поток
        }


        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
            { //Если полученное изменение в чате не сообщение - пропускаем
                return;
            }
            if (update.Message.Type != MessageType.Text)
            {//Если это не текст - пропускаем
                return;
            }

            var chatId = update.Message.Chat.Id; //Получаем ИД чата
            _logger.LogInformation($"Получено '{update.Message.Text}' в чате {chatId}."); // Для удобства
                                                                                          // логируем пришедшее
                                                                                          // сообщение
            var scope = _services.CreateScope(); //Создаем сокуп
            var dbContext = scope.ServiceProvider.GetService<MyMegaBotContext>(); //Получаем из скоупа контекст для БД
            var repository = new CommandRepository(dbContext); // Создаем репозиторий на основе контекста
            var chatService = new chatService(repository); // Создаем сервис команд на основе репозитория
            chatService.registerBot(this);

            ChatMessage msg = new ChatMessage("telegram", chatId, update.Message.Text);

            //Обрабатываем сообщение
            chatService.processMessage(msg);

            //await SendMessageToChat(chatId, $"{resAnsver}"); //Отправляем ответ
            await Task.CompletedTask;
        }

        //Метод отправляющий ответы после обработки сообщения из IChatService 
        public async Task SendMessageToChat(ChatMessage chatMessage)
        {
            //throw new NotImplementedException();

            //Непосредственно отправщик
            await SendMessageToChat(chatMessage.ChatId, $"{chatMessage.Message}");
        }
    }
}
