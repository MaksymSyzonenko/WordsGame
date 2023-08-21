using CourseProject.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace CourseProject.ViewModels
{
    public class RatingWindowViewModel
    {
        public ObservableCollection<Player> Players { get; set; }
        public RatingWindowViewModel()
        {
            Players = new ObservableCollection<Player>();
            BasePlayers basePlayers = new("Players.json");
            var tempPlayers = basePlayers.GetPlayers().OrderByDescending(p => p.Rank);
            foreach(Player player in tempPlayers)
                Players.Add(player);
        }
    }
}
