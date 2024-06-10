using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telelingo.Bot.Interfaces;
using Telelingo.Core;
using Telelingo.Repositories;

namespace Telelingo.Bot
{
    public class Bot
    {
        private IUserState _userState;
        private readonly ChatRepository _chatRepository;
        private readonly WordRepository _wordRepository;
        private readonly ChatWordRepository _chatWordRepository;
        private readonly ITelegramBotClient _botClient;

        public Bot(ChatRepository chatRepository,
            WordRepository wordRepository,
            ChatWordRepository chatWordRepository,
            ITelegramBotClient botClient
            )
        {
            _userState = new UserState();
            _chatRepository = chatRepository;
            _wordRepository = wordRepository;
            _chatWordRepository = chatWordRepository;
            _botClient = botClient;

        }
        public async Task StartAsync()
        {
            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
            };


            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            var me = await _botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message || message.Text is not { } messageText)
                return;


            var chatId = message.Chat.Id;

            await _chatRepository.CreateIfNoExitsAsync(chatId);

            try
            {
                await (messageText switch
                {
                    "Назад" => HandleBackCommandAsync(chatId, cancellationToken),
                    "/start" => HandleStartCommandAsync(chatId, cancellationToken),
                    "Показати відповідь" => HandleShowAnswerCommandAsync(chatId, cancellationToken),
                    "Не знаю" => HandleWordLearningAsync(chatId, Commands.None, cancellationToken),
                    "Важко" => HandleWordLearningAsync(chatId, Commands.Hard, cancellationToken),
                    "Добре" => HandleWordLearningAsync(chatId, Commands.Good, cancellationToken),
                    "Легко" => HandleWordLearningAsync(chatId, Commands.Easy, cancellationToken),
                    _ => HandleDefaultCommandAsync(chatId, cancellationToken)
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                await SendTextMessageAsync(_botClient, chatId, "На сьогодні все", CreateKeyboard("Старт"), cancellationToken);
            }

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
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

        private async Task<Message> HandleBackCommandAsync(long chatId, CancellationToken cancellationToken)
        {
            return await SendTextMessageAsync(_botClient, chatId, "Натисните старт щоб почати вчитися", CreateKeyboard("Старт"), cancellationToken);
        }

        private async Task<Message> HandleStartCommandAsync(long chatId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task HandleWordLearningAsync(long chatId, Commands command, CancellationToken cancellationToken)
        {
            var chatWord = await _chatWordRepository.GetByIdAsync(chatId, _userState.word.WordId);
            var newLearningRate = LearningRateCalculator.CalculateNextLearningRate(chatWord.LearningRate, command);
            var newShowOnDate = LearningRateCalculator.GetNextShowOnDate(chatWord.ShowOn, newLearningRate);

            chatWord.ShowOn = newShowOnDate;
            chatWord.LearningRate = newLearningRate;
            await _chatWordRepository.SaveAllAsync();

            await HandleDefaultCommandAsync(chatId, cancellationToken);
        }
        private async Task HandleShowAnswerCommandAsync(long chatId, CancellationToken cancellationToken)
        {
            var replyKeyboardMarkup = CreateKeyboard(new[] { "Не знаю", "Важко", "Добре", "Легко" }, new[] { "Назад" });

            _userState.maxNewWordInDay--;

            await SendTextMessageAsync(_botClient, chatId, _userState.word.Value, replyKeyboardMarkup, cancellationToken);
        }

        private async Task<Message> HandleDefaultCommandAsync(long chatId, CancellationToken cancellationToken)
        {
            var replyKeyboardMarkup = CreateKeyboard(new[] { "Показати відповідь" }, new[] { "Вже знаю" }, new[] { "Назад" });

            var lowestPriorityWord = await _wordRepository.GetByLowestPriorityAsync(chatId);

            if (lowestPriorityWord is not null && _userState.maxNewWordInDay > 0)
            {
                _userState.word = lowestPriorityWord;
                await _chatWordRepository.CreateAsync(chatId, lowestPriorityWord.WordId);

                var message = await SendTextMessageAsync(_botClient, chatId, $"Нове слово \n \n *{lowestPriorityWord.Key}*", replyKeyboardMarkup, cancellationToken);
                _userState.messageId = message.MessageId;

                return message;
            }

            var word = await _chatWordRepository.GetWordByShowOnDate(chatId, DateTime.UtcNow);

            if (word is null)
            {
                throw new Exception("There is no word for today");
            }

            _userState.word = word;
            Console.WriteLine($"{word.WordId} {word.Key} {word.Value}");

            var sentMessage = await SendTextMessageAsync(_botClient, chatId, $"*{word.Key}*", replyKeyboardMarkup, cancellationToken);
            _userState.messageId = sentMessage.MessageId;

            return sentMessage;
        }

        private async Task<Message> SendTextMessageAsync(ITelegramBotClient botClient, long chatId, string text, IReplyMarkup replyMarkup, CancellationToken cancellationToken)
        {
            return await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                parseMode: ParseMode.MarkdownV2,
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken);
        }

        private IReplyMarkup CreateKeyboard(params string[] buttons)
        {
            return new ReplyKeyboardMarkup(buttons.Select(button => new[] { new KeyboardButton(button) }).ToArray())
            {
                ResizeKeyboard = true
            };
        }
        private IReplyMarkup CreateKeyboard(params string[][] buttons)
        {
            return new ReplyKeyboardMarkup(buttons.Select(row => row.Select(button => new KeyboardButton(button)).ToArray()))
            {
                ResizeKeyboard = true
            };
        }
    }
}
