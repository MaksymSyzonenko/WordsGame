using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CourseProject.Models
{
    public class BasePlayers
    {
        private List<Player>? players;
        public string jsonPath;
        public BasePlayers(string jsonPath)
        {
            this.jsonPath = jsonPath;
        }
        public List<Player> GetPlayers()
        {
            string jsonReader = File.ReadAllText(jsonPath);
            var playersReader = jsonReader != string.Empty ? JsonSerializer.Deserialize<List<Player>>(jsonReader) : new List<Player>();
            return playersReader!;
        }
        public void WritePlayersToFile()
        {
            string jsonWriter = players?.Count > 0 ? JsonSerializer.Serialize(players) : string.Empty;
            File.WriteAllText(jsonPath, jsonWriter);
        }
        public string RegisterPlayer(Player player)
        {
            players = GetPlayers();
            if (!players.Any(p => p.Login == player.Login))
            {
                if (player.Login != null && player.Password != null)
                {
                    if (Regex.IsMatch(player.Login, @"\b\w\D{3,9}\b"))
                    {
                        if (Regex.IsMatch(player.Password, @"\b\w{5,11}\b"))
                        {
                            players?.Add(player);
                            WritePlayersToFile();
                            return string.Empty;
                        }
                        else
                            return "Пароль повинен містити від 6 до 12 символів!";
                    }
                    else
                        return "Логін повинен містити тільки букви від 4 до 10!";
                }
                else
                    return "Не заповнено поля!";
            }
            else
                return "Користувач з таким логіном вже існує!";
        }
        public bool FindPlayer(string login, string password)
        {
            players = GetPlayers();
            var player = players.Find(p => p.Login == login);
            return player?.Password == password;
        }
        public Player GetPlayer(string login, string password)
        {
            players = GetPlayers();
            return players.Find(p => p.Login == login && p.Password == password)!;
        }
        public void ChangeSkill(string login, int guessedWords, int completedLevels, int rank)
        {
            players = GetPlayers();
            var player = players.Find(p => p.Login == login);
            if (player != null)
            {
                player.GuessedWords = guessedWords;
                player.CompletedLevels = completedLevels;
                player.Rank = rank;
            }
            WritePlayersToFile();
        }
        public string ChangePassword(string login, string oldPassword, string newPassword)
        {
            players = GetPlayers();
            var player = players.Find(p => p.Login == login && p.Password == oldPassword);
            if (player != null)
            {
                if (Regex.IsMatch(newPassword, @"\b\w{5,11}\b"))
                {
                    player.Password = newPassword;
                    WritePlayersToFile();
                    return string.Empty;
                }
                else
                    return "Пароль повинен містити від 6 до 12 символів!";
            }
            else
                return "Хибний пароль!";
        }
        public void RemovePlayer(string login)
        {
            players = GetPlayers();
            var player = players.Find(p => p.Login == login);
            if (player != null)
            {
                if(Directory.Exists(player.Login))
                    Directory.Delete(player.Login, true);
                players.Remove(player);
                WritePlayersToFile();
            }
        }
        public void RemoveAllPlayers()
        {
            players = GetPlayers();
            players.ForEach(p => { if (Directory.Exists(p.Login)) Directory.Delete(p.Login, true); });
            File.WriteAllText(jsonPath, string.Empty);
            players?.Clear();
        }
    }
}
