using CheckersProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheckersProject.Model
{

    public enum PlayerTeam
    {
        Green,
        Blue,
        None
    }

    public class PlayerModel : ViewModelBase
    {
        public string _name { get; set; }
        public PlayerTeam _team { get; set; }

        public int _wins { get; set; }
        public int _losses { get; set; } 

        private int _numberPieces;
        public int NumberPieces
        {
            get { return _numberPieces; }
            set
            {
                _numberPieces = value;
                OnPropertyChanged(nameof(NumberPieces));
            }
        
        }

        public PlayerModel(string name, int wins, int losses)
        {
            _name = name;
            _wins = wins;
            _losses = losses;
        }
        public PlayerModel(string name, PlayerTeam team)
        {
            _name = name;
            _team = team;
            NumberPieces = 12;
            _wins = 0;
            _losses = 0;
        }
    }



}
