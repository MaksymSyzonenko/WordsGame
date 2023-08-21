using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace CourseProject.Models
{
    public enum Difficulty
    {
        None,
        Easy,
        Mid,
        Hard
    }
    public delegate void EventDelegate();
    public class Level : WordList
    {
        public Difficulty difficulty;
        private event EventDelegate? CreateNewWordList = null;
        private readonly List<string> levelWords = new();
        private readonly List<char> wordsLetters = new();
        private readonly char[] consonants = new char[] { 'б', 'в', 'г', 'ґ', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'щ' };
        public Level(string catalogPath, EventDelegate createNewWordList, Difficulty difficulty) : base(catalogPath)
        {
            this.difficulty = difficulty;
            string jsonPath = "";
            var words = new List<string>();
            var rnd = new Random();
            int countWords = 0;
            int countLetters = 0;
            switch (difficulty)
            {
                case Difficulty.Easy:
                    jsonPath = @"\shortWords.json";
                    words = ShortWords;
                    countWords = rnd.Next(3, 5);
                    countLetters = 2;
                    break;
                case Difficulty.Mid:
                    jsonPath = @"\midWords.json";
                    words = MidWords;
                    countWords = rnd.Next(4, 6);
                    countLetters = 3;
                    break;
                case Difficulty.Hard:
                    jsonPath = @"\longWords.json";
                    words = LongWords;
                    countWords = rnd.Next(5, 7);
                    countLetters = 4;
                    break;
            }
            if (words?.Count > 4000)
            {
                while (levelWords?.Count != countWords)
                {
                    levelWords?.Clear();
                    var tempConsonantsLetters = GetRandomLetters(countLetters, consonants);
                    levelWords = words?.Where(tw => tempConsonantsLetters.All(tc => tw.Contains(tc))).Take(countWords).ToList()!;
                }
                words = words?.Except(levelWords).ToList();
                string jsonWriter = JsonSerializer.Serialize(words);
                File.WriteAllText(catalogPath + jsonPath, jsonWriter);
                List<char> tempWordsLetters = new();
                foreach (var word in levelWords)
                    for (int i = 0; i < word.Length; i++)
                        tempWordsLetters.Add(word[i]);
                wordsLetters = tempWordsLetters.Distinct().ToList();
                wordsLetters = ShuffleWordsLetters(wordsLetters);
            }
            else
            {
                MessageBox.Show("Слова для вашого аккаунту скінчились, зараз відбудеться завантаження нових. Чекайте!");
                CreateNewWordList = createNewWordList;
                CreateNewWordList.Invoke();
            }
        }
        public List<string> LevelWords { get => levelWords; }
        public List<char> WordsLetters { get => wordsLetters; }
        private static List<char> GetRandomLetters(int n, char[] chars)
        {
            var rnd = new Random();
            var randoms = Enumerable.Range(0, chars.Length).ToArray();
            var randomLetters = new List<char>();
            for (int i = chars.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                (randoms[i], randoms[j]) = (randoms[j], randoms[i]);
            }
            for (int i = 0; i < n; i++)
                randomLetters.Add(chars[randoms[i]]);
            return randomLetters;
        }
        private static List<char> ShuffleWordsLetters(List<char> chars)
        {
            var rnd = new Random();
            for (int i = chars.Count - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }
            return chars;
        }
    }
}
