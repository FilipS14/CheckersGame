using CheckersProject.Model;
using CheckersProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.IO;


namespace CheckersProject.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private const string SaveFileName = "C:\\Users\\Filip\\Desktop\\facultate\\anul2\\sem2\\RC\\CheckersProject\\CheckersProject\\game_state.txt";
        private const string SavePlayerStateFile = "C:\\Users\\Filip\\Desktop\\facultate\\anul2\\sem2\\RC\\CheckersProject\\CheckersProject\\leaderboard.txt";

        public ICommand SaveCommand { get; set; }
        public ICommand LoadGameCommand {  get; set; } 
        public ICommand ToggleMultipleJumpCommand { get; }
        public ICommand MouseLeftButtonDownCommand { get; set; }
        public BoardModel _board { get; set; }
        public ObservableCollection<PieceModel> Pieces { get; set; }

        private static bool multipleJumpInProgress;

        private bool ok = false;

        private static bool _multipleJump;

        
        
        private bool _isBluePlayerTurn;
        public bool IsBluePlayerTurn
        {
            get { return _isBluePlayerTurn; }
            set
            {
                _isBluePlayerTurn = value;
                OnPropertyChanged(nameof(IsBluePlayerTurn));
            }
        }

        private bool _isGreenPlayerTurn;
        public bool IsGreenPlayerTurn
        {
            get{return _isGreenPlayerTurn;}
            set 
            { 
                _isGreenPlayerTurn = value;
                OnPropertyChanged(nameof(IsGreenPlayerTurn));
            }
        }


        public bool MultipleJump
        {
            get { return _multipleJump; }
            set
            {
                _multipleJump = value;
                OnPropertyChanged(nameof(MultipleJump));
            }
        }
        private void ToggleMultipleJump(object parameter)
        {
            if (MultipleJump == true)
                multipleJumpInProgress = true;
            else
                multipleJumpInProgress = false;
            MessageBox.Show(multipleJumpInProgress.ToString());
            OnPropertyChanged(nameof(MultipleJump));
        }
        public GameViewModel()
        {
            LoadGameCommand = new RelayCommand(LoadGameState);
            SaveCommand = new RelayCommand(SaveGameState);
            ToggleMultipleJumpCommand = new RelayCommand(ToggleMultipleJump);
            MouseLeftButtonDownCommand = new RelayCommand(HandleMouseLeftButtonDown);
            _board = new BoardModel();
            Pieces = new ObservableCollection<PieceModel>();
            GreenPlayer = new PlayerModel(GreenPlayerName, PlayerTeam.Green);
            BluePlayer = new PlayerModel(BluePlayerName, PlayerTeam.Blue);

            CurrentPlayer = BluePlayer;
            IsBluePlayerTurn = true;
            IsGreenPlayerTurn = false;
            for (int row = 0; row < BoardModel.BoardSize; row++)
            {
                for (int col = 0; col < BoardModel.BoardSize; col++)
                {
                    CellModel cell = _board.GetCell(row, col);

                    if (cell._piece == PieceColor.None)
                        continue;

                    SolidColorBrush colorBrush = cell._piece == PieceColor.Blue ? Brushes.Blue : Brushes.Green;
                    int x = 189 + col * 56;
                    int y = 99 + row * 57;

                    if (cell._piece == PieceColor.Green)
                    {
                        Pieces.Add(new PieceModel(
                    colorBrush,
                    PieceType.Normal,
                    PieceColor.Green,
                    row,
                    col,
                    x,
                    y
                    ));
                    }
                    else
                    {
                        Pieces.Add(new PieceModel(
                        colorBrush,
                        PieceType.Normal,
                        PieceColor.Blue,
                        row,
                        col,
                        x,
                        y
                        ));
                    }

                }
            }
            OnPropertyChanged(nameof(Pieces));
        }



        //player -> begin

        private PlayerModel _greenPlayer;
        public PlayerModel GreenPlayer
        {
            get { return _greenPlayer; }
            set
            {
                _greenPlayer = value;
                OnPropertyChanged(nameof(GreenPlayer));
            }
        }

        private PlayerModel _bluePlayer;
        public PlayerModel BluePlayer
        {
            get { return _bluePlayer; }

            set
            {
                _bluePlayer = value;
                OnPropertyChanged(nameof(BluePlayer));
            }
        }

        private PlayerModel _currentPlayer;
        public PlayerModel CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        private void SwitchPlayer()
        {
            if(CurrentPlayer == BluePlayer)
            {
                CurrentPlayer = GreenPlayer;
                IsBluePlayerTurn = false;
                IsGreenPlayerTurn = true;
            }
            else
            {
                CurrentPlayer = BluePlayer;
                IsBluePlayerTurn = true;
                IsGreenPlayerTurn = false;
            }
            CheckForWinner();
            OnPropertyChanged(nameof(CurrentPlayer));
            OnPropertyChanged(nameof(IsBluePlayerTurn));
        }

        //player -> end

        //game logic -> begin
        private PieceModel _selectedPiece;
        public PieceModel SelectedPiece
        {
            get { return _selectedPiece; }
            set
            {
                _selectedPiece = value;
                OnPropertyChanged(nameof(SelectedPiece));
            }
        }

        private static string _greenPlayerName;
        public string GreenPlayerName
        {
            get { return _greenPlayerName; }
            set
            {
                _greenPlayerName = value;
                OnPropertyChanged(nameof(GreenPlayerName));
            }
        }

        private static string _bluePlayerName;
        public string BluePlayerName
        {
            get { return _bluePlayerName; }
            set
            {
                _bluePlayerName = value;
                OnPropertyChanged(nameof(BluePlayerName));
            }
        }
        private void ResetGame()
        {
            _board = new BoardModel();
            IsGreenPlayerTurn = false;
            IsBluePlayerTurn = true;
            Pieces.Clear();
            for (int row = 0; row < BoardModel.BoardSize; row++)
            {
                for (int col = 0; col < BoardModel.BoardSize; col++)
                {
                    CellModel cell = _board.GetCell(row, col);

                    if (cell._piece == PieceColor.None)
                        continue;

                    SolidColorBrush colorBrush = cell._piece == PieceColor.Blue ? Brushes.Blue : Brushes.Green;
                    int x = 189 + col * 56;
                    int y = 99 + row * 57;

                    if (cell._piece == PieceColor.Green)
                    {
                        Pieces.Add(new PieceModel(
                            colorBrush,
                            PieceType.Normal,
                            PieceColor.Green,
                            row,
                            col,
                            x,
                            y
                        ));
                    }
                    else
                    {
                        Pieces.Add(new PieceModel(
                            colorBrush,
                            PieceType.Normal,
                            PieceColor.Blue,
                            row,
                            col,
                            x,
                            y
                        ));
                    }
                }
            }
            BluePlayer.NumberPieces = 12;
            GreenPlayer.NumberPieces = 12;
            CurrentPlayer = BluePlayer;
            SelectedPiece = null;
            OnPropertyChanged(nameof(Pieces));
        }


        private void CheckForWinner()
        {
            if (BluePlayer.NumberPieces == 0)
            {
                MessageBox.Show("Jucătorul Verde a câștigat! Felicitări!");
                GreenPlayer._wins++;
                BluePlayer._losses++;
                SavePlayerStateForLeaderBoard();
                ResetGame();
            }
            else if (GreenPlayer.NumberPieces == 0)
            {
                MessageBox.Show("Jucătorul Albastru a câștigat! Felicitări!");
                BluePlayer._wins++;
                GreenPlayer._losses++;
                SavePlayerStateForLeaderBoard();
                ResetGame();
            }
        }

        private void HandleMouseLeftButtonDown(object obj)
        {
            if (_selectedPiece != null)
            {
                if (obj is Point positionMove)
                {
                    double tolerance = 30;
                    ok = false;
                    foreach (var move in SelectedPiece.ValidMovePositions)
                    {
                        double distance = Math.Sqrt(Math.Pow(positionMove.X - move.X, 2) + Math.Pow(positionMove.Y - move.Y, 2));
                        if (distance < tolerance)
                        {

                            int rowOfCapturedPiece = (_selectedPiece.Row + move.Row) / 2;
                            int colOfCapturedPiece = (_selectedPiece.Column + move.Column) / 2;


                            if (_board.GetCell(rowOfCapturedPiece, colOfCapturedPiece)._piece != PieceColor.None &&
                                _board.GetCell(rowOfCapturedPiece, colOfCapturedPiece)._piece != _selectedPiece.PieceColor)
                            {
                                _board.SetCell(rowOfCapturedPiece, colOfCapturedPiece, new CellModel(PieceColor.None, false, rowOfCapturedPiece, colOfCapturedPiece));
                                GetOpponentPlayer().NumberPieces--;
                                Pieces.Remove(Pieces.First(piece => piece.Row == rowOfCapturedPiece && piece.Column == colOfCapturedPiece));

                                if (multipleJumpInProgress)
                                {
                                    ok = true;
                                }
                            }
                            PieceModel copySelectPiece = _selectedPiece;
                            _board.UpdatePieceColor(_selectedPiece.Row, _selectedPiece.Column, PieceColor.None);
                            _selectedPiece.X = (int)move.X;
                            _selectedPiece.Y = (int)move.Y;
                            _selectedPiece.Row = (int)move.Row;
                            _selectedPiece.Column = (int)move.Column;
                            _board.UpdatePieceColor(_selectedPiece.Row, _selectedPiece.Column, _selectedPiece.PieceColor);
                            if ((_selectedPiece.Row == 7 && _selectedPiece.Color == Brushes.Blue) ||
                                _selectedPiece.Row == 0 && _selectedPiece.Color == Brushes.Green)
                            {
                                _selectedPiece.Type = PieceType.King;
                            }
                            if (ok == true)
                            {
                                List<PieceModel> captureMoves = CalculateCaptureMoves(_selectedPiece);
                                if (captureMoves.Count > 0)
                                {
                                    _selectedPiece.ValidMovePositions = captureMoves;
                                }
                                else
                                {
                                    ok = false;
                                    SwitchPlayer();
                                    _selectedPiece = null;
                                }
                            }
                            else
                            {
                                SwitchPlayer();
                                _selectedPiece = null;
                            }
                            OnPropertyChanged(nameof(SelectedPiece));
                            break;
                        }
                    }
                }

            }

            if (obj is Point position)
            {
                double tolerance = 30;
                SolidColorBrush currentPlayerColor = GetCurrentPlayerColor();
                foreach (PieceModel piece in Pieces)
                {
                    double distance = Math.Sqrt(Math.Pow(position.X - piece.X, 2) + Math.Pow(position.Y - piece.Y, 2));
                    if (distance <= tolerance && piece.Color == currentPlayerColor)
                    {
                        SelectedPiece = piece;
                        SelectedPiece.ValidMovePositions = CalculateValidMovePositions(SelectedPiece);
                        break;
                    }
                }
            }
            OnPropertyChanged(nameof(Pieces));
        }
        private PlayerModel GetOpponentPlayer()
        {
            return CurrentPlayer == BluePlayer ? GreenPlayer : BluePlayer;
        }

        private SolidColorBrush GetCurrentPlayerColor()
        {
            switch (CurrentPlayer._team)
            {
                case PlayerTeam.Blue:
                    return Brushes.Blue;
                case PlayerTeam.Green:
                    return Brushes.Green;
                default:
                    return Brushes.Gray;
            }
        }

        private List<PieceModel> CalculateCaptureMoves(PieceModel selectedPiece)
        {
            List<PieceModel> validMovePositions = new List<PieceModel>();
            if (selectedPiece.Type == PieceType.Normal)
            {
                if (CurrentPlayer._team == PlayerTeam.Blue && selectedPiece.PieceColor == PieceColor.Blue)
                {
                    //dreapta jos
                    if (IsPieceInsideBoard(selectedPiece.Row + 1, selectedPiece.Column + 1) && _board.GetCell(selectedPiece.Row + 1, selectedPiece.Column + 1)._piece == PieceColor.Green)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row + 2, selectedPiece.Column + 2) && _board.GetCell(selectedPiece.Row + 2, selectedPiece.Column + 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 2, selectedPiece.Column + 2, selectedPiece.X + 114, selectedPiece.Y + 114));
                        }

                    }
                    //stanga jos
                    if (IsPieceInsideBoard(selectedPiece.Row + 1, selectedPiece.Column - 1) && _board.GetCell(selectedPiece.Row + 1, selectedPiece.Column - 1)._piece == PieceColor.Green)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row + 2, selectedPiece.Column - 2) && _board.GetCell(selectedPiece.Row + 2, selectedPiece.Column - 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 2, selectedPiece.Column - 2, selectedPiece.X - 114, selectedPiece.Y + 114));
                        }

                    }
                }
                if (CurrentPlayer._team == PlayerTeam.Green && selectedPiece.PieceColor == PieceColor.Green)
                {
                    //dreapta sus
                    if (IsPieceInsideBoard(selectedPiece.Row - 1, selectedPiece.Column + 1) && _board.GetCell(selectedPiece.Row - 1, selectedPiece.Column + 1)._piece == PieceColor.Blue)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row - 2, selectedPiece.Column + 2) && _board.GetCell(selectedPiece.Row - 2, selectedPiece.Column + 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 2, selectedPiece.Column + 2, selectedPiece.X + 114, selectedPiece.Y - 114));
                        }

                    }
                    //stanga sus
                    if (IsPieceInsideBoard(selectedPiece.Row - 1, selectedPiece.Column - 1) && _board.GetCell(selectedPiece.Row - 1, selectedPiece.Column - 1)._piece == PieceColor.Blue)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row - 2, selectedPiece.Column - 2) && _board.GetCell(selectedPiece.Row - 2, selectedPiece.Column - 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 2, selectedPiece.Column - 2, selectedPiece.X - 114, selectedPiece.Y - 114));
                        }

                    }
                }
            }
            else // King
            {
                //pentru regele albastru
                if (CurrentPlayer._team == PlayerTeam.Blue && selectedPiece.PieceColor == PieceColor.Blue)
                {
                    //dreapta sus
                    if (IsPieceInsideBoard(selectedPiece.Row - 1, selectedPiece.Column + 1) && _board.GetCell(selectedPiece.Row - 1, selectedPiece.Column + 1)._piece == PieceColor.Green)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row - 2, selectedPiece.Column + 2) && _board.GetCell(selectedPiece.Row - 2, selectedPiece.Column + 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 2, selectedPiece.Column + 2, selectedPiece.X + 114, selectedPiece.Y - 114));
                        }
                    }
                    //stanga sus
                    if (IsPieceInsideBoard(selectedPiece.Row - 1, selectedPiece.Column - 1) && _board.GetCell(selectedPiece.Row - 1, selectedPiece.Column - 1)._piece == PieceColor.Green)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row - 2, selectedPiece.Column - 2) && _board.GetCell(selectedPiece.Row - 2, selectedPiece.Column - 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 2, selectedPiece.Column - 2, selectedPiece.X - 114, selectedPiece.Y - 114));
                        }
                    }
                }
                if (CurrentPlayer._team == PlayerTeam.Green && selectedPiece.PieceColor == PieceColor.Green)
                {
                    //dreapta jos
                    if (IsPieceInsideBoard(selectedPiece.Row + 1, selectedPiece.Column + 1) && _board.GetCell(selectedPiece.Row + 1, selectedPiece.Column + 1)._piece == PieceColor.Blue)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row + 2, selectedPiece.Column + 2) && _board.GetCell(selectedPiece.Row + 2, selectedPiece.Column + 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 2, selectedPiece.Column + 2, selectedPiece.X + 114, selectedPiece.Y + 114));
                        }

                    }
                    //stanga jos
                    if (IsPieceInsideBoard(selectedPiece.Row + 1, selectedPiece.Column - 1) && _board.GetCell(selectedPiece.Row + 1, selectedPiece.Column - 1)._piece == PieceColor.Blue)
                    {
                        if (IsPieceInsideBoard(selectedPiece.Row + 2, selectedPiece.Column - 2) && _board.GetCell(selectedPiece.Row + 2, selectedPiece.Column - 2)._piece == PieceColor.None)
                        {
                            validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 2, selectedPiece.Column - 2, selectedPiece.X - 114, selectedPiece.Y + 114));
                        }

                    }
                }
            }

            return validMovePositions;
        }

        private List<PieceModel> CalculateValidMovePositions(PieceModel selectedPiece)
        {
            //normal piece
            List<PieceModel> validMovePositions = new List<PieceModel>();
            if (selectedPiece.Color == Brushes.Blue)
            {
                validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 1, selectedPiece.Column + 1, selectedPiece.X + 57, selectedPiece.Y + 57));//right
                validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 1, selectedPiece.Column - 1, selectedPiece.X - 57, selectedPiece.Y + 57));//left
            }
            else
            {
                validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 1, selectedPiece.Column + 1, selectedPiece.X + 57, selectedPiece.Y - 57));//right
                validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 1, selectedPiece.Column - 1, selectedPiece.X - 57, selectedPiece.Y - 57));//left
            }

            //king piece
            if (selectedPiece.Type == PieceType.King)
            {
                if (selectedPiece.Color == Brushes.Blue)
                {
                    //calculez pozitiile din spatele pentru o piesa aplbastra
                    validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 1, selectedPiece.Column + 1, selectedPiece.X + 57, selectedPiece.Y - 57));//right
                    validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row - 1, selectedPiece.Column - 1, selectedPiece.X - 57, selectedPiece.Y - 57));//left
                }
                else
                {
                    validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 1, selectedPiece.Column + 1, selectedPiece.X + 57, selectedPiece.Y + 57));//right
                    validMovePositions.Add(new PieceModel(selectedPiece.Color, selectedPiece.Type, selectedPiece.PieceColor, selectedPiece.Row + 1, selectedPiece.Column - 1, selectedPiece.X - 57, selectedPiece.Y + 57));//left
                }
            }

            validMovePositions.AddRange(CalculateCaptureMoves(selectedPiece));

            validMovePositions.RemoveAll(position =>
            position.X < 159 || position.X >= 600 || position.Y < 99 || position.Y >= 550 ||
             Pieces.Any(piece => piece.Row == position.Row && piece.Column == position.Column));

            return validMovePositions;

        }

        private bool IsPieceInsideBoard(int row, int col)
        {
            return row >= 0 && row < BoardModel.BoardSize && col >= 0 && col < BoardModel.BoardSize;
        }
        //game logic -> end

        //save game
        private void SavePlayerStateForLeaderBoard()
        {
            using (StreamWriter writer = new StreamWriter(SavePlayerStateFile, append: true))
            {
                writer.WriteLine($"{BluePlayerName},{BluePlayer._wins},{BluePlayer._losses}");
                writer.WriteLine($"{GreenPlayerName},{GreenPlayer._wins},{GreenPlayer._losses}");
            }
        }

        private void SaveGameState(object parameter)
        {
            using (StreamWriter writer = new StreamWriter(SaveFileName))
            {
                writer.WriteLine($"Current Player: {CurrentPlayer._team}");
                writer.WriteLine($"Blue Player Name: {BluePlayerName}");
                writer.WriteLine($"Green Player Name: {GreenPlayerName}");
                writer.WriteLine($"Number of Blue Pieces: {BluePlayer.NumberPieces}");
                writer.WriteLine($"Number of Green Pieces: {GreenPlayer.NumberPieces}");

                foreach (PieceModel piece in Pieces)
                {
                    writer.WriteLine($"Piece: Color={piece.Color}, Type={piece.Type}, PieceColor={piece.PieceColor}, Row={piece.Row}, Column={piece.Column}, X={piece.X}, Y={piece.Y}");
                }

                for (int row = 0; row < BoardModel.BoardSize; row++)
                {
                    for (int col = 0; col < BoardModel.BoardSize; col++)
                    {
                        CellModel cell = _board.GetCell(row, col);
                        writer.Write($"Board: PieceColor={cell._piece}, Occupied={cell._isOccupied}, Row={cell._row}, Column={cell._column}");
                        writer.WriteLine();
                    }
                }

            }
            MessageBox.Show("save successfully");
        }


        private void LoadGameState(object parameter)
        {
            if (File.Exists(SaveFileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(SaveFileName))
                    {
                        Pieces.Clear();
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(':');
                            if (parts.Length == 2)
                            {
                                string key = parts[0].Trim();
                                string value = parts[1].Trim();

                                switch (key)
                                {
                                    case "Current Player":

                                        if (value == "Blue")
                                        {
                                            _currentPlayer = BluePlayer;
                                            IsBluePlayerTurn = true;
                                            IsGreenPlayerTurn = false;
                                        } 
                                        else if (value == "Green")
                                        {
                                            _currentPlayer = GreenPlayer;
                                            IsGreenPlayerTurn = true;
                                            IsBluePlayerTurn = false;
                                        }
                                        OnPropertyChanged(nameof(IsGreenPlayerTurn));
                                        OnPropertyChanged(nameof(IsBluePlayerTurn));
                                        OnPropertyChanged(nameof(CurrentPlayer));
                                        break;
                                    case "Blue Player Name":

                                        BluePlayerName = value;
                                        BluePlayer._name = value;
                                        OnPropertyChanged(nameof(BluePlayerName));
                                        OnPropertyChanged(nameof(BluePlayer));
                                        break;
                                    case "Green Player Name":

                                        GreenPlayerName = value;
                                        GreenPlayer._name = value;
                                        OnPropertyChanged(nameof(GreenPlayerName));
                                        OnPropertyChanged(nameof(GreenPlayer));
                                        break;
                                    case "Number of Blue Pieces":

                                        int bluePieces;
                                        if (int.TryParse(value, out bluePieces))
                                            BluePlayer.NumberPieces = bluePieces;
                                        OnPropertyChanged();
                                        break;
                                    case "Number of Green Pieces":

                                        int greenPieces;
                                        if (int.TryParse(value, out greenPieces))
                                            GreenPlayer.NumberPieces = greenPieces;
                                        OnPropertyChanged();
                                        break;
                                    case "Piece":

                                        string[] pieceParts = value.Split(',');
                                        if (pieceParts.Length == 7)
                                        {
                                            string color = pieceParts[0].Trim().Split('=')[1];
                                            string type = pieceParts[1].Trim().Split('=')[1];
                                            string pieceColorString = pieceParts[2].Trim().Split('=')[1];
                                            string row = pieceParts[3].Trim().Split('=')[1];
                                            string column = pieceParts[4].Trim().Split('=')[1];
                                            string x = pieceParts[5].Trim().Split('=')[1];
                                            string y = pieceParts[6].Trim().Split('=')[1];

                                            PieceType pieceType = (PieceType)Enum.Parse(typeof(PieceType), type);
                                            SolidColorBrush colorP;
                                            if(color == "#FF0000FF")
                                            {
                                                colorP = Brushes.Blue;
                                            }
                                            else
                                                colorP = Brushes.Green;
                                            PieceColor piecePieceColor = pieceColorString == "Blue" ? PieceColor.Blue : PieceColor.Green;
                                            int pieceRow = int.Parse(row);
                                            int pieceColumn = int.Parse(column);
                                            int pieceX = int.Parse(x);
                                            int pieceY = int.Parse(y);

                                            Pieces.Add(new PieceModel(
                                                colorP,
                                                pieceType,
                                                piecePieceColor,
                                                pieceRow,
                                                pieceColumn,
                                                pieceX,
                                                pieceY
                                            ));
                                        }
                                        break;
                                    case "Board":

                                        string[] boardParts = value.Split(',');
                                        if (boardParts.Length == 4)
                                        {
                                            string pieceColorString = boardParts[0].Trim().Split('=')[1];
                                            bool isOccupied = bool.Parse(boardParts[1].Trim().Split('=')[1]);
                                            int row = int.Parse(boardParts[2].Trim().Split('=')[1]);
                                            int column = int.Parse(boardParts[3].Trim().Split('=')[1]);

                                            PieceColor pieceColor;
                                            if(pieceColorString == "Blue")
                                            {
                                                pieceColor = PieceColor.Blue;
                                            }
                                            else if(pieceColorString == "Green")
                                            {
                                                pieceColor = PieceColor.Green;
                                            }
                                            else
                                                pieceColor = PieceColor.None;
                                            _board.SetCell(row, column, new CellModel(pieceColor, isOccupied,row, column));
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la încărcarea stării jocului: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Fișierul de stare a jocului nu a fost găsit.");
            }
            
        }

        

    }
}

