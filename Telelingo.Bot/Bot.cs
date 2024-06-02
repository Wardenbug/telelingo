using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telelingo.Bot.Interfaces;
using Telelingo.DataContext;
using Telelingo.Repositories;

namespace Telelingo.Bot
{
    public class Bot
    {
        private IUserState _userState;

        public async Task Start()
        {
            _userState = new UserState();

            var botClient = new TelegramBotClient("");

            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
            };


            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;
            if (message.Text is not { } messageText)
                return;

            using var db = new SqliteContext();
            var chatRepository = new ChatRepository(db);
            var wordRepository = new WordRepository(db);
            var chatWordRepository = new ChatWordRepository(db);

            Console.WriteLine($"Database path: {db.DbPath}.");

            var chatId = message.Chat.Id;

            await chatRepository.CreateIfNoExitsAsync(chatId);

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            if (messageText == "Назад")
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
            new KeyboardButton[]{"Старт"}
        });
                Message sentMessage = await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Натисните старт щоб почати вчитися",
               replyMarkup: replyKeyboardMarkup,
               cancellationToken: cancellationToken);
            }
            else if (messageText == "/start")
            {

            }
            //else if (messageText == "Не знаю")
            //{

            //}
            //else if (messageText == "Важко")
            //{

            //}
            //else if (messageText == "Добре")
            //{

            //}
            //else if (messageText == "Легко")
            //{

            //}
            else if (messageText == "Показати відповідь")
            {
                // Echo received message text
                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
            new KeyboardButton[] { "Не знаю", "Важко", "Добре", "Легко" },
            new KeyboardButton[] { "Назад" },
        })
                {
                    ResizeKeyboard = true
                };

                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: _userState.word.Value,
                    replyToMessageId: _userState.messageId,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
            }
            else
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
               {
            new KeyboardButton[] { "Показати відповідь" },
            new KeyboardButton[] { "Вже знаю" },
            new KeyboardButton[] { "Назад" },
        })
                {
                    ResizeKeyboard = true,
                };

                var lowestPriorityWord = await wordRepository.GetByLowestPriorityAsync(chatId);

                _userState.word = lowestPriorityWord;

                await chatWordRepository.CreateAsync(chatId, lowestPriorityWord.WordId);

                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Нове слово \n \n *{lowestPriorityWord.Key}*",
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);

                _userState.messageId = sentMessage.MessageId;

            }
        }

        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
