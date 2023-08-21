using CourseProject.Models;
using CourseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace CourseProject.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private readonly WordsBoard wordsBoard = new(17, 17);
        private readonly BasePlayers basePlayers = new("Players.json");
        private Difficulty levelDifficulty;
        private Level level;
        private event EventDelegate? EventCreate;
        private readonly string Login;
        private readonly string Password;
        private bool flag = false;
        private char[,] boardToCheck;
        private List<string> tempLevelWords = new List<string>();
        private readonly List<TextBlock> textBlocks = new();
        private readonly List<char> wordsLetters = new();
        public GameWindow(string login, string password)
        {
            InitializeComponent();
            DataContext = new GameWindowViewModel(login, password);
            Login = login;
            Password = password;
            EventCreate = StartLoadingNewWordList;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(((CheckBox)e.OriginalSource).Name == "EasyCheckBox")
            {
                levelDifficulty = Difficulty.Easy;
                MidCheckBox.IsChecked = false;
                HardCheckBox.IsChecked = false;
            }
            else if(((CheckBox)e.OriginalSource).Name == "MidCheckBox")
            {
                levelDifficulty = Difficulty.Mid;
                EasyCheckBox.IsChecked = false;
                HardCheckBox.IsChecked = false;
            }
            else if (((CheckBox)e.OriginalSource).Name == "HardCheckBox")
            {
                levelDifficulty = Difficulty.Hard;
                EasyCheckBox.IsChecked = false;
                MidCheckBox.IsChecked = false;
            }
        }
        private void GenerateButton(object sender, RoutedEventArgs e)
        {
            if (EasyCheckBox.IsChecked == false && MidCheckBox.IsChecked == false && HardCheckBox.IsChecked == false)
                levelDifficulty = Difficulty.None;
            if (levelDifficulty != Difficulty.None)
            {
                Message.Text = string.Empty;
                Word.Text = string.Empty;
                gridBoard.Children.Clear();
                textBlocks.Clear();
                Letters.Children.Clear();
                wordsLetters.Clear();
                level = new Level(Login, EventCreate!, levelDifficulty);
                level.WordsLetters.ForEach(wl => 
                {
                    wordsLetters.Add(wl);
                    var tb = new TextBlock
                    {
                        Text = wl.ToString(),
                        Width = 25,
                        Height = 25,
                        Margin = new Thickness(5),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Background = Brushes.MediumPurple,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 15,
                        Foreground = Brushes.White,
                        FontWeight = FontWeights.Bold
                    };
                    Letters.Children.Add(tb);
                });
                wordsBoard.Reset();
                wordsBoard.inRTL = false;
                flag = true;
                level.LevelWords.ForEach(lw => wordsBoard.AddWord(lw));
                tempLevelWords = level.LevelWords;
                boardToCheck = new char[17, 17];
                for (int i = 0; i < wordsBoard.N; i++)
                {
                    for (int j = 0; j < wordsBoard.M; j++)
                    {
                        var tb = new TextBlock
                        {
                            Margin = new Thickness(1),
                            Background = Brushes.AliceBlue,
                            TextAlignment = TextAlignment.Center,
                            FontSize = 15,
                            Text = wordsBoard.GetBoard[i, j].ToString()
                        };
                        if (tb.Text == "*") tb.Text = " ";
                        if(tb.Text != " ")
                        {
                            tb.Background = Brushes.MediumPurple;
                            tb.Foreground = Brushes.White;
                            tb.FontWeight = FontWeights.Bold;
                        }
                        tb.Text = "";
                        Grid.SetRow(tb, i);
                        Grid.SetColumn(tb, j);
                        gridBoard.Children.Add(tb);
                        textBlocks.Add(tb);
                        boardToCheck[i, j] = ' ';
                    }
                }
            }
            else
                MessageBox.Show("Не вибрано складність рівня!\nВиберіть складність у розділі Select difficulty!");
        }
        private void CheckWord(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                bool isGuessed = false;
                for (int i = 0; i < tempLevelWords.Count; i++)
                {
                    if (tempLevelWords[i] == Word.Text)
                    {
                        tempLevelWords.RemoveAt(i);
                        var thisPlayer = basePlayers.GetPlayer(Login, Password);
                        int rankForWord = 0;
                        int rankForLevel = 0;
                        switch (levelDifficulty)
                        {
                            case Difficulty.Easy:
                                rankForWord = 3;
                                rankForLevel = 15;
                                break;
                            case Difficulty.Mid:
                                rankForWord = 6;
                                rankForLevel = 40;
                                break;
                            case Difficulty.Hard:
                                rankForWord = 9;
                                rankForLevel = 100;
                                break;
                        }
                        basePlayers.ChangeSkill(Login, ++thisPlayer.GuessedWords, thisPlayer.CompletedLevels, thisPlayer.Rank + rankForWord);
                        var charsWord = Word.Text.ToCharArray().ToList();
                        var tempBoard = new char[17, 17];
                        bool wasFound = true;
                        int firstCounter = 0;
                        int rowIndex = 0;
                        gridBoard.Children.Clear();
                        for (int n = 0; n < 17; n++)
                            for (int m = 0; m < 17; m++)
                            {
                                tempBoard[n, m] = wordsBoard.GetBoard[n, m];
                                if (tempBoard[n, m] == '*')
                                    tempBoard[n, m] = ' ';
                            }
                        for (int n = 0; n < 17; n++)
                        {
                            firstCounter = 0;
                            var tempRow = new List<char>();
                            for (int m = 0; m < 17; m++)
                                tempRow.Add(tempBoard[n, m]);
                            int startIndex = 0;
                            for (int m = 0; m < 16; m++)
                                if (tempRow[m] != ' ' && tempRow[m + 1] != ' ')
                                {
                                    startIndex = m;
                                    break;
                                }
                            for (int m = 0; m < charsWord.Count; m++)
                            {
                                int k = startIndex + m;
                                if (k <= tempRow.Count)
                                {
                                    if (!(tempRow[k] == charsWord[m]))
                                        break;
                                    else
                                    {
                                        firstCounter++;
                                        rowIndex = n;
                                    }
                                }
                                else
                                    break;
                            }
                            if(firstCounter == charsWord.Count)
                            {
                                wasFound = true;
                                break;
                            }
                            else
                                wasFound = false;
                        }
                        if (wasFound)
                        {
                            for (int n = 0; n < 17; n++)
                                for (int m = 0; m < 17; m++)
                                {
                                    if (n != rowIndex)
                                        tempBoard[n, m] = ' ';
                                    if (boardToCheck[n, m] == ' ')
                                        boardToCheck[n, m] = tempBoard[n, m];
                                }  
                        }
                        else
                        {
                            for (int n = 0; n < 17; n++)
                                for (int m = 0; m < 17; m++)
                                {
                                    tempBoard[n, m] = wordsBoard.GetBoard[n, m];
                                    if (tempBoard[n, m] == '*')
                                        tempBoard[n, m] = ' ';
                                }
                            int secondCounter = 0;
                            int colIndex = 0;
                            for (int n = 0; n < 17; n++)
                            {
                                secondCounter = 0;
                                var tempCol = new List<char>();
                                for (int m = 0; m < 17; m++)
                                    tempCol.Add(tempBoard[m, n]);
                                int startIndex = 0;
                                for (int m = 0; m < 16; m++)
                                    if (tempCol[m] != ' ' && tempCol[m + 1] != ' ')
                                    {
                                        startIndex = m;
                                        break;
                                    }
                                for (int m = 0; m < charsWord.Count; m++)
                                {
                                    int k = startIndex + m;
                                    if (k <= tempCol.Count)
                                    {
                                        if (!(tempCol[k] == charsWord[m]))
                                            break;
                                        else
                                        {
                                            secondCounter++;
                                            colIndex = n;
                                        }
                                    }
                                    else
                                        break;
                                }
                                if (secondCounter == charsWord.Count)
                                    break;
                            }
                            for (int n = 0; n < 17; n++)
                                for (int m = 0; m < 17; m++)
                                {
                                    if (m != colIndex)
                                        tempBoard[n, m] = ' ';
                                    if (boardToCheck[n, m] == ' ')
                                        boardToCheck[n, m] = tempBoard[n, m];
                                }  
                        }
                        int iter = 0;
                        for (int n = 0; n < 17; n++)
                            for (int m = 0; m < 17; m++)
                            {
                                textBlocks[iter].Text = boardToCheck[n, m].ToString();
                                iter++;
                            }
                        textBlocks.ForEach(tb => gridBoard.Children.Add(tb));
                        Message.FontSize = 20;
                        Message.Foreground = Brushes.SeaGreen;
                        Message.Text = $"Успіх! Ви вгадали слово {Word.Text}!";
                        isGuessed = true;
                        if(tempLevelWords.Count == 0)
                        {
                            flag = false;
                            basePlayers.ChangeSkill(Login, thisPlayer.GuessedWords, ++thisPlayer.CompletedLevels, thisPlayer.Rank + rankForLevel + rankForWord);
                            MessageBox.Show("Перемога! Рівень повністю пройдено!");
                            Message.Text = string.Empty;
                        }
                        break;
                    }
                }
                if (!isGuessed)
                {
                    Message.FontSize = 15;
                    Message.Foreground = Brushes.Red;
                    Message.Text = $"Ви не вгадали слово, або воно вже було відгадане!";
                }
            }
            else
                MessageBox.Show("Не згенеровано рівень, або пройдено попередній!\nНатисніть кнопку Generate щоб згенерувати рівень.");
        }
        private void Hint(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                if (MessageBox.Show("Ви впевнені що хочете взяти підказку?\nЦе буде коштувати 2 очкa вашого рейтингу!", "Hint", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var thisPlayer = basePlayers.GetPlayer(Login, Password);
                    if (thisPlayer.Rank > 1)
                        basePlayers.ChangeSkill(Login, thisPlayer.GuessedWords, thisPlayer.CompletedLevels, thisPlayer.Rank - 2);
                    gridBoard.Children.Clear();
                    var rnd = new Random();
                    var tempBoard = new char[17, 17];
                    var tempBoardNow = new char[17, 17];
                    var indexesX = new List<int>();
                    var indexesY = new List<int>();
                    for (int i = 0; i < 17; i++)
                        for (int j = 0; j < 17; j++)
                        {
                            tempBoardNow[i, j] = boardToCheck[i, j];
                            tempBoard[i, j] = wordsBoard.GetBoard[i, j];
                            if (tempBoard[i, j] == '*')
                                tempBoard[i, j] = ' ';
                            if (tempBoardNow[i, j] != ' ')
                                tempBoard[i, j] = ' ';
                            if (tempBoard[i, j] != ' ')
                            {
                                indexesX.Add(i);
                                indexesY.Add(j);
                            }
                        }                         
                    var randomValue = rnd.Next(0, indexesX.Count);
                    var x = indexesX[randomValue];
                    var y = indexesY[randomValue];
                    int iter = 0;
                    for (int i = 0; i < 17; i++)
                        for (int j = 0; j < 17; j++)
                        {
                            if (i == x && j == y)
                                tempBoardNow[i, j] = tempBoard[i, j];
                            boardToCheck[i, j] = tempBoardNow[i, j];
                            textBlocks[iter].Text = tempBoardNow[i, j].ToString();
                            iter++;
                        }
                    textBlocks.ForEach(tb => gridBoard.Children.Add(tb));
                }
            }
            else
                MessageBox.Show("Не згенеровано рівень, або пройдено попередній!\nНатисніть кнопку Generate щоб згенерувати рівень.");
        }
        private void ShowWords(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                if (MessageBox.Show("Ви впевнені що хочете відкрити всі слова?\nЯкщо ви відкриєте слова, їх більше не можна буде вгадати!", "Show", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    gridBoard.Children.Clear();
                    for (int i = 0; i < wordsBoard.N; i++)
                    {
                        for (int j = 0; j < wordsBoard.M; j++)
                        {
                            var tb = new TextBlock
                            {
                                Margin = new Thickness(1),
                                Background = Brushes.AliceBlue,
                                TextAlignment = TextAlignment.Center,
                                FontSize = 15,
                                Text = wordsBoard[i, j].ToString()
                            };
                            if (tb.Text == "*") tb.Text = " ";
                            if (tb.Text != " ")
                            {
                                tb.Background = Brushes.MediumPurple;
                                tb.Foreground = Brushes.White;
                                tb.FontWeight = FontWeights.Bold;
                            }
                            Grid.SetRow(tb, i);
                            Grid.SetColumn(tb, j);
                            gridBoard.Children.Add(tb);
                        }
                    }
                    Message.Text = string.Empty;
                    flag = false;
                }
            }
            else
                MessageBox.Show("Не згенеровано рівень, або пройдено попередній!\nНатисніть кнопку Generate щоб згенерувати рівень.");
        }
        public void StartLoadingNewWordList()
        {
            if (Directory.Exists(Login))
                Directory.Delete(Login, true);
            var loadingWindow = new LoadingWindow();
            loadingWindow.Show();
            CreateNewWordList(Login);
        }
        public static async void CreateNewWordList(string catalogPath) => await Task.Run(() => { var wordList = new WordList(catalogPath); });
        private void ShuffleLetters(object sender, RoutedEventArgs e)
        {
            if(flag)
            {
                var rnd = new Random();
                for (int i = wordsLetters.Count - 1; i >= 1; i--)
                {
                    int j = rnd.Next(i + 1);
                    (wordsLetters[i], wordsLetters[j]) = (wordsLetters[j], wordsLetters[i]);
                }
                Letters.Children.Clear();
                wordsLetters.ForEach(wl => 
                {
                    var tb = new TextBlock
                    {
                        Text = wl.ToString(),
                        Width = 25,
                        Height = 25,
                        Margin = new Thickness(5),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Background = Brushes.MediumPurple,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 15,
                        Foreground = Brushes.White,
                        FontWeight = FontWeights.Bold
                    };
                    Letters.Children.Add(tb);
                });
            }
            else
                MessageBox.Show("Не згенеровано рівень, або пройдено попередній!\nНатисніть кнопку Generate щоб згенерувати рівень.");
        }
    }
}
