using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using telelingo;
using Telelingo.DataContext;

var botClient = new TelegramBotClient("");

using CancellationTokenSource cts = new();

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>(),
};

using var db = new DataContext();
Console.WriteLine($"Database path: {db.DbPath}.");


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

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Message is not { } message)
        return;
    if (message.Text is not { } messageText)
        return;


    var chatId = message.Chat.Id;

    JsonParser parser = new("words.json");
    words = parser.GetWordsDictionary();

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
            text: valuePair.Value,
            replyToMessageId: messageId,
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }
    else
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
       {
            new KeyboardButton[] { "Показати відповідь" },
            new KeyboardButton[] { "Назад" },
        })
        {
            ResizeKeyboard = true,
        };

        Random rand = new Random();

        valuePair = words.ElementAt(rand.Next(0, words.Count));

        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: valuePair.Key,
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
        messageId = sentMessage.MessageId;
    }
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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