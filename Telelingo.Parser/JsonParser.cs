using Newtonsoft.Json;

namespace telelingo
{
    public class JsonParser
    {
        private readonly string _jsonFilePath;
        public JsonParser(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public Dictionary<string, string> GetWordsDictionary()
        {
            using StreamReader reader = new(_jsonFilePath);
            var json = reader.ReadToEnd();

            Dictionary<string, string> words = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return words;
        }
    }
}
