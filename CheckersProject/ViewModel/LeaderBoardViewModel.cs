using CheckersProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckersProject.ViewModel
{
    public class LeaderBoardViewModel
    {
        public ObservableCollection<PlayerModel> Players { get; set; }
        
        public LeaderBoardViewModel() 
        {
            string filePath = @"C:\Users\Filip\Desktop\facultate\anul2\sem2\RC\CheckersProject\CheckersProject\leaderboard.txt";
            Players = new ObservableCollection<PlayerModel>(LoadPlayerData(filePath)
                                                          .OrderByDescending(player => player._wins));
        }

        private IEnumerable<PlayerModel> LoadPlayerData(string filePath)
        {
            Dictionary<string, PlayerModel> playerDictionary = new Dictionary<string, PlayerModel>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        string name = parts[0];
                        int wins = int.Parse(parts[1]);
                        int losses = int.Parse(parts[2]);

                        if (name == "")
                            continue;
                        if (playerDictionary.ContainsKey(name))
                        {
                            if (wins > playerDictionary[name]._wins)
                            {
                                playerDictionary[name]._wins = wins;
                            }
                        }
                        else
                        {

                            playerDictionary.Add(name, new PlayerModel(name, wins, losses));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading player data: {ex.Message}");
            }

            
            return playerDictionary.Values.OrderByDescending(player => player._wins);
        }
    }
}


