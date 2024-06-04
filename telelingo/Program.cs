using Telelingo.Bot;
using Telelingo.DataContext;
using Telelingo.Repositories;

using var db = new SqliteContext();
var chatRepository = new ChatRepository(db);
var wordRepository = new WordRepository(db);
var chatWordRepository = new ChatWordRepository(db);

var bot = new Bot(chatRepository, wordRepository, chatWordRepository);

await bot.Start();