using CourseProject.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;

namespace CourseProject.Models
{
    public class WordList
    {
        protected StringBuilder shortWordsBuilder = new();
        protected StringBuilder midWordsBuilder = new();
        protected StringBuilder longWordsBuilder = new();

        protected List<string> jsonPathes = new();
        protected string CatalogPath { get; set; }
        protected string[] letters = { "%D0%B0", "%D0%B1", "%D0%B2", "%D0%B3", "%D0%B4", "%D0%B5", "%D0%B6",
                            "%D0%B7", "%D0%B9", "%D0%BA", "%D0%BB", "%D0%BC", "%D0%BD", "%D0%BE",
                            "%D0%BF", "%D1%80", "%D1%81", "%D1%82", "%D1%83", "%D1%84", "%D1%85",
                            "%D1%86", "%D1%87", "%D1%88", "%D1%89", "%D1%8E", "%D1%8F", "%D1%94",
                            "%D1%96", "%D1%97", "%D2%91" };
        protected char[] vowels = { 'а', 'е', 'и', 'о', 'у', 'ю', 'я', 'є', 'і', 'ї' };
        public WordList(string catalogPath)
        {
            CatalogPath = catalogPath;
            Directory.CreateDirectory(catalogPath);
            var strings = new List<string> { "short", "mid", "long" };
            strings.ForEach(s => jsonPathes.Add($@"{catalogPath}\{s}Words.json"));
            jsonPathes.ForEach(jp => { if (!File.Exists(jp)) using (var stream = File.Create(jp)) { } });
            var jsonReaders = new List<string>();
            jsonPathes.ToList().ForEach(jp => jsonReaders.Add(File.ReadAllText(jp)));
            if (jsonReaders.Any(jr => jr == ""))
            {
                var words = new List<string>();
                var web = new WebClient();
                web.Proxy = new WebProxy();
                Counter.ResetCount();
                for (int i = 0; i < letters.Length; i++)
                {
                    string[] webStrings = web.DownloadString($"http://uk.words-finder.com/index.php?begin={letters[i]}")
                        .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var tempWords = webStrings[77].Split("<br>").ToList();
                    tempWords.ForEach(tw => tw.Trim(' '));
                    tempWords = tempWords.Where(tw => tw.StartsWith(HttpUtility.UrlDecode(letters[i]))).ToList();
                    tempWords.ForEach(tw => words.Add(tw));
                    Counter.IncreaseCount(1);
                }
                words = ShuffleListWords(words);
                AddWordsToList(words, shortWordsBuilder, 3, 5, sw => vowels.Any(c => sw.Contains(c)), 8000);
                AddWordsToList(words, midWordsBuilder, 5, 7, null, 8000);
                AddWordsToList(words, longWordsBuilder, 7, 9, null, 8000);
                var jsonWriters = new List<string> { shortWordsBuilder.ToString(), midWordsBuilder.ToString(), longWordsBuilder.ToString() };
                for (int i = 0; i < jsonPathes.Count; i++)
                {
                    string jsonData = JsonSerializer.Serialize(jsonWriters[i]);
                    File.WriteAllText(jsonPathes[i], jsonData);
                }
            }
        }

        public List<string>? ShortWords { get => shortWordsBuilder.Length > 0 ? ParseWordList(shortWordsBuilder) : JsonSerializer.Deserialize<List<string>>(File.ReadAllText(jsonPathes[0])); }
        public List<string>? MidWords { get => midWordsBuilder.Length > 0 ? ParseWordList(midWordsBuilder) : JsonSerializer.Deserialize<List<string>>(File.ReadAllText(jsonPathes[1])); }
        public List<string>? LongWords { get => longWordsBuilder.Length > 0 ? ParseWordList(longWordsBuilder) : JsonSerializer.Deserialize<List<string>>(File.ReadAllText(jsonPathes[2])); }
        private static void AddWordsToList(List<string> words, StringBuilder builder, int minLength, int maxLength, Func<string, bool>? condition, int count)
        {
            int addedCount = 0;
            foreach (string word in words)
            {
                if (word.Length >= minLength && word.Length <= maxLength && (condition == null || condition(word)))
                {
                    builder.AppendLine(word);
                    addedCount++;
                    if (addedCount == count)
                        break;
                }
            }
        }
        private static List<string> ParseWordList(StringBuilder builder) => builder.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        private static List<string> ShuffleListWords(List<string> strings)
        {
            var rnd = new Random();
            for (int i = strings.Count - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                (strings[i], strings[j]) = (strings[j], strings[i]);
            }
            return strings;
        }
    }
}
