namespace Minesweeper.ConsoleGame
{
    using GameModel.Interfaces;
    using System;
    using System.Collections.Generic;

    using GameModel;
    using Utils;

    internal class ConsoleMinesweeperEngine
    {
        private ScoreBoard scoreBoard;
        private ICollection<Player> topList;
        private IRenderer renderer;
        private int cellsOpened;
        private char[,] playerMatrix;
        private char[,] matrix;
        private bool emptyScoreboard;
        private bool playerAddedToScoreboard;
        private bool gameInProgress;

        public ConsoleMinesweeperEngine(IRenderer renderer)
        {
            this.scoreBoard = new ScoreBoard(renderer);
            this.renderer = renderer;
            this.cellsOpened = 0;
            this.topList = new List<Player>();
            this.emptyScoreboard = true;
            this.playerAddedToScoreboard = false;
            this.gameInProgress = true;
        }

        public void Start()
        {
            //gameInProgress = true;
            // cellsOpened = 0;

            this.playerMatrix = new char[Constants.MatrixRow, Constants.MatrixColumn];
            this.matrix = new char[Constants.MatrixRow, Constants.MatrixColumn];

            matrix = MinesGenerator.GenerateMinesweeperInMatrix(matrix, minesSimbol: Constants.MinesSymbol);

            matrix = MatrixGenerator.GenerateMatrix(matrix, symbolToSkip: Constants.MinesSymbol);
            for (int i = 0; i < playerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < playerMatrix.GetLength(1); j++)
                {
                    playerMatrix[i, j] = Constants.Symbol;
                }
            }
            renderer.WriteLine(String.Empty);
            renderer.WriteLine(String.Empty);
            renderer.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines. " +
                              "Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' " +
                              "to quit the game.");
            renderer.WriteLine(String.Empty);

            PrintMatrix(playerMatrix);

            while (gameInProgress)
            {
                Commands();
            }
        }

        public void Commands()
        {
            renderer.WriteLine(String.Empty);
            renderer.Write("Enter row and column: ");
            string input = Console.ReadLine();
            input.Trim();

            if (input == "exit")
            {
                Exit();
                return;
            }

            if (input == "restart")
            {
                Start();
                return;
            }

            if (input == "top")
            {
                Top();
                return;
            }

            if (input.Length != Constants.InputLength || input[1] != ' ')
            {
                renderer.WriteLine("Illegal input!");
                return;
            }

            int rowInput = ChekInputValue(input, 0);

            int colInput = ChekInputValue(input, 2);

            MakeMove(rowInput, colInput);
        }


        public void Exit()
        {
            Environment.Exit(1);
        }

        public void Top()
        {
            scoreBoard.Print();
        }

        public void MakeMove(int row, int col)
        {
            if (playerMatrix[row, col] != Constants.Symbol)
            {
                renderer.WriteLine("Illegal move!");
                return;
            }

            if (matrix[row, col] == Constants.MinesSymbol)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == Constants.MinesSymbol)
                        {
                            playerMatrix[i, j] = Constants.MinesSymbol;
                            continue;
                        }

                        if (playerMatrix[i, j] == Constants.Symbol)
                        {
                            playerMatrix[i, j] = Constants.EmptySymbol;
                        }
                    }
                }

                PrintMatrix(playerMatrix);
                gameInProgress = false;

                renderer.WriteLine("");
                renderer.WriteLine(String.Format("Booooom! You were killed by a mine. You revealed {0} cells without mines.", cellsOpened));

                if (scoreBoard.TopListCount() == 0)
                {
                    var newPlayer = new Player(String.Empty, new int());
                    scoreBoard.AddPlayer(newPlayer);
                    topList.Add(newPlayer);
                    emptyScoreboard = false;
                    //gameInProgress = true;

                }
                else
                {
                    var newPlayer = new Player(String.Empty, new int());
                    newPlayer.Place = topList.Count;
                    scoreBoard.AddPlayer(newPlayer);
                    emptyScoreboard = false;
                    topList.Add(newPlayer);

                    //player.Place++;
                }

                foreach (var player in topList)
                {
                    if (cellsOpened >= player.Score)
                    {

                        player.Score = cellsOpened;

                        renderer.Write("Please enter your name for the top scoreboard: ");
                        string playerName = Console.ReadLine();

                        player.Name = playerName;

                        if (emptyScoreboard || scoreBoard.TopListCount() == 6)
                        {
                            scoreBoard.RemovePlayer(scoreBoard.TopListCount() - 1);
                            emptyScoreboard = false;
                        }

                        playerAddedToScoreboard = true;
                        gameInProgress = true;
                        break;
                    }
                }

                foreach (var player in topList)
                {
                    if (!playerAddedToScoreboard && player.Score < 5)
                    {
                        player.Score = cellsOpened;
                        renderer.Write("Please enter your name for the top scoreboard: ");
                        string playerName = Console.ReadLine();
                        player.Name = playerName;
                    }
                }

                playerAddedToScoreboard = false;
                scoreBoard.Print();
                Start();
            }
            else
            {
                cellsOpened++;
                if (cellsOpened == Constants.MaxScore)
                {
                    PrintMatrix(matrix);
                    renderer.WriteLine("Congratulations! You revealed all cells without mines!");

                    gameInProgress = false;

                    renderer.Write("Please enter your name for the top scoreboard: ");
                    string playerName = Console.ReadLine();
                    topList.Add(new Player(playerName, Constants.MaxScore));

                    if (scoreBoard.GetPlayers().Count == 6)
                    {
                        scoreBoard.RemovePlayer(5);
                    }

                    scoreBoard.Print();
                    Start();
                    return;
                }

                playerMatrix[row, col] = matrix[row, col];
                PrintMatrix(playerMatrix);
            }
        }
        private void PrintMatrix(char[,] matrix)
        {
            renderer.WriteLine(String.Empty);
            renderer.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            renderer.WriteLine("   ----------------------");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                renderer.Write(String.Format("{0} | ", i));

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    renderer.Write(String.Format("{0} ", matrix[i, j]));
                }

                renderer.WriteLine("|");
            }

            renderer.WriteLine("   ----------------------");
        }

        private int ChekInputValue(string input, int position)
        {
            int result;
            bool isTrue = int.TryParse(input[position].ToString(), out result);
            if (!isTrue)
            {
                renderer.WriteLine("Illegal input!");
                Commands();
            }

            return result;
        }
    }
}
