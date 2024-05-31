using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckersProject.Model
{

    public class BoardModel
    {
        public const int BoardSize = 8;
        public List<List<CellModel>> board;

        public BoardModel()
        {
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            board = new List<List<CellModel>>();

            for (int row = 0; row < BoardSize; ++row)
            {
                List<CellModel> rowCells = new List<CellModel>();
                for (int col = 0; col < BoardSize; ++col)
                {
                    if ((row + col) % 2 == 1 && row < 3)
                    {
                        rowCells.Add(new CellModel(PieceColor.Blue, true, row, col));
                    }
                    else if ((row + col) % 2 == 1 && row > 4)
                    {
                        rowCells.Add(new CellModel(PieceColor.Green, true, row, col));
                    }
                    else
                    {
                        rowCells.Add(new CellModel(PieceColor.None, false, row, col));
                    }
                }
                board.Add(rowCells);
            }
        }

        public CellModel GetCell(int row, int col)
        {
            return board[row][col];
        }

        public void UpdatePieceColor(int row, int col, PieceColor color)
        {
            board[row][col]._piece = color;
        }

        public void SetCell(int row, int col, CellModel cell)
        {
            board[row][col] = cell;
        }



    }
}
