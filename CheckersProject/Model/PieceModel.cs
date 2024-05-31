using CheckersProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CheckersProject.Model
{
    public enum PieceColor
    {
        Green,
        Blue,
        None
    }
    public enum PieceType
    {
        Normal,
        King
    }

    public class PieceModel : ViewModelBase
    {
        // dreapta jos, stanga jos, dreapta sus, stanga sus
        private List<int> _dX = new List<int> { 1, 2, 4, 3 };
        public List<int> DX
        {
            get { return _dX; }
            set
            {
                _dX = value;
            }
        }

        // dreapta jos, stanga jos, dreapta sus, stanga sus
        private List<int> _dY = new List<int> { 1,2,3,4,5};
        public List<int> DY
        {
            get { return _dY; }
            set { _dY = value;}
        }

        private SolidColorBrush _color;
        public SolidColorBrush Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        public PieceColor PieceColor { get; set; }
        public PieceType Type { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        
        private int _x;
        public int X 
        {
            get { return _x; }
            set
            {
                if (_x != value) 
                {
                    _x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                if( _y != value) 
                {
                    _y  = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        private List<PieceModel> _validMovePositions;
        public List<PieceModel> ValidMovePositions
        {
            get { return _validMovePositions; }
            set
            {
                _validMovePositions = value;
                OnPropertyChanged(nameof(ValidMovePositions));
            }
        }

        public PieceModel(SolidColorBrush color, PieceType type ,PieceColor pieceColor ,int row, int column, int x, int y)
        {
            Color = color;
            Type = type;
            PieceColor = pieceColor;    
            Row = row;
            Column = column;
            X = x;
            Y = y;
        }
    }
}
