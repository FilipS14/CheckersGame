using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CheckersProject.Model
{
    public class CellModel
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public bool _isOccupied;

        public PieceColor _piece;

        public int _column;

        public int _row;
        public CellModel(PieceColor piece, bool occupied, int row, int column)
        {
            _piece = piece;
            _isOccupied = occupied;
            _row = row;
            _column = column;
        }

    }
}
