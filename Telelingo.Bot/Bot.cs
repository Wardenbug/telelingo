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

        public Bot(ChatRepository chatRepository, WordRepository wordRepository, ChatWordRepository chatWordRepository)
        {
            _userState = new UserState();
            _chatRepository = chatRepository;
            _wordRepository = wordRepository;
            _chatWordRepository = chatWordRepository;

        }
        public async Task Start()
        {
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

            var chatId = message.Chat.Id;

            await _chatRepository.CreateIfNoExitsAsync(chatId);

            try
            {
                switch (messageText)
                {
                    case "Назад":
                        await HandleBackCommandAsync(botClient, chatId, cancellationToken);
                        break;
                    case "/start":
                        await HandleStartCommandAsync(botClient, chatId, cancellationToken);
                        break;
                    case "Показати відповідь":
                        await HandleShowAnswerCommandAsync(botClient, chatId, cancellationToken);
                        break;
                    case "Не знаю":
                        await HandleDontKnowCommandAsync(botClient, chatId, cancellationToken);
                        break;
                    case "Важко":
                        await HandleHardCommandAsync(botClient, chatId, cancellationToken);
                        break;
                    case "Добре":
                        await HandleGoodCommandAsync(botClient, chatId, cancellationToken);
                        break;
                    case "Легко":
                        await HandleEasyCommandAsync(botClient, chatId, cancellationToken);
                        break;
                    default:
                        await HandleDefaultCommandAsync(botClient, chatId, cancellationToken);
                        break;
                }
            }
            catch (Exception ex)
            {
                await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "На сьогодні все",
                cancellationToken: cancellationToken);
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

        private async Task<Message> HandleBackCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
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

            return sentMessage;
        }

        private async Task<Message> HandleStartCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task HandleShowAnswerCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
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

        private async Task HandleDontKnowCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            var chatWord = await _chatWordRepository.GetByIdAsync(chatId, _userState.word.WordId);
            var newLearningRate = LearningRateCalculator.CalculateNextLearningRate(chatWord.LearningRate, Commands.None);
            var newShowOnDate = LearningRateCalculator.GetNextShowOnDate(chatWord.ShowOn, newLearningRate);

            chatWord.ShowOn = newShowOnDate;
            chatWord.LearningRate = newLearningRate;
            await _chatWordRepository.SaveAllAsync();

            await HandleDefaultCommandAsync(botClient, chatId, cancellationToken);
        }
        private async Task HandleHardCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            var chatWord = await _chatWordRepository.GetByIdAsync(chatId, _userState.word.WordId);
            var newLearningRate = LearningRateCalculator.CalculateNextLearningRate(chatWord.LearningRate, Commands.Hard);
            var newShowOnDate = LearningRateCalculator.GetNextShowOnDate(chatWord.ShowOn, newLearningRate);

            chatWord.ShowOn = newShowOnDate;
            chatWord.LearningRate = newLearningRate;
            await _chatWordRepository.SaveAllAsync();

            await HandleDefaultCommandAsync(botClient, chatId, cancellationToken);
        }
        private async Task HandleGoodCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            var chatWord = await _chatWordRepository.GetByIdAsync(chatId, _userState.word.WordId);
            var newLearningRate = LearningRateCalculator.CalculateNextLearningRate(chatWord.LearningRate, Commands.Good);
            var newShowOnDate = LearningRateCalculator.GetNextShowOnDate(chatWord.ShowOn, newLearningRate);

            chatWord.ShowOn = newShowOnDate;
            chatWord.LearningRate = newLearningRate;
            await _chatWordRepository.SaveAllAsync();

            await HandleDefaultCommandAsync(botClient, chatId, cancellationToken);
        }

        private async Task HandleEasyCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            var chatWord = await _chatWordRepository.GetByIdAsync(chatId, _userState.word.WordId);
            var newLearningRate = LearningRateCalculator.CalculateNextLearningRate(chatWord.LearningRate, Commands.Easy);
            var newShowOnDate = LearningRateCalculator.GetNextShowOnDate(chatWord.ShowOn, newLearningRate);

            chatWord.ShowOn = newShowOnDate;
            chatWord.LearningRate = newLearningRate;
            await _chatWordRepository.SaveAllAsync();

            await HandleDefaultCommandAsync(botClient, chatId, cancellationToken);
        }

        private async Task HandleDefaultCommandAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
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

            var lowestPriorityWord = await _wordRepository.GetByLowestPriorityAsync(chatId);

            _userState.word = lowestPriorityWord;

            await _chatWordRepository.CreateAsync(chatId, lowestPriorityWord.WordId);

            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Нове слово \n \n *{lowestPriorityWord.Key}*",
                parseMode: ParseMode.MarkdownV2,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);

            _userState.messageId = sentMessage.MessageId;
        }
    }
}
