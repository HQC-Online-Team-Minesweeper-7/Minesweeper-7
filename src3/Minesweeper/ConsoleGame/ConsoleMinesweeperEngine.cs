﻿namespace Minesweeper.ConsoleGame
{
    using Utils;
    using System;
    using System.Collections.Generic;

    internal class ConsoleMinesweeperEngine
    {
        static char[,] matrix;
        static char[,] playerMatrix;
        static bool gameInProgress;
        static bool emptyScoreboard = true;
        static bool playerAddedToScoreboard = false;
        static int cellsOpened = 0;
        static List<string> topListNames = new List<string>();
        static List<int> topListCellsOpened = new List<int>();



        //static char[,] GenerateMinesweeperMatrix()
        //{
        //    char[,] matrix = new char[5, 10];

            //var random = new Random();
            //int minesToInsert = 15;

            //while (minesToInsert > 0)
            //{
            //    for (int i = 0; i < matrix.GetLength(0); i++)
            //    {
            //        if (minesToInsert == 0)
            //        {
            //            break;
            //        }

            //        for (int j = 0; j < matrix.GetLength(1); j++)
            //        {
            //            if (minesToInsert == 0)
            //            {
            //                break;
            //            }

            //            int randomNumber = random.Next(0, 3);
            //            if (randomNumber == 1)
            //            {
            //                matrix[i, j] = '*';
            //                minesToInsert--;
            //            }
            //        }
            //    }
            //}

        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            if (matrix[i, j] == Constants.MinesSymbol)
        //            {
        //                continue;
        //            }

        //            int neighbourMinesCount = GetNeighbourMinesCount(matrix, i, j);
        //            matrix[i, j] = (neighbourMinesCount.ToString()[0]);
        //        }
        //    }

        //    return matrix;
        //}

        //static int GetNeighbourMinesCount(char[,] matrix, int row, int col)
        //{
        //    int minesCount = 0;
        //    int[] rowPositions = { -1, -1, -1, 0, 1, 1, 1, 0 };
        //    int[] colPositions = { -1, 0, 1, 1, 1, 0, -1, -1 };
        //    int currentNeighbourRow = 0;
        //    int currentNeighbourCol = 0;

        //    for (int position = 0; position < 8; position++)
        //    {

        //        currentNeighbourRow = row + rowPositions[position];

        //        currentNeighbourCol = col + colPositions[position];


        //        if (currentNeighbourRow < 0 ||
        //            currentNeighbourRow >= matrix.GetLength(0) ||
        //            currentNeighbourCol < 0 ||
        //            currentNeighbourCol >= matrix.GetLength(1))
        //        {
        //            continue;
        //        }

        //        if (matrix[currentNeighbourRow, currentNeighbourCol] == '*')
        //        {
        //            minesCount++;
        //        }

        //    }
        //    return minesCount;
        //}

        private static void Commands()
        {
            Console.WriteLine();
            Console.Write("Enter row and column: ");
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
                Console.WriteLine("Illegal input!");
                return;
            }

            int rowInput = CheckInputValue(input, 0);

            int colInput = CheckInputValue(input, 2);            

            MakeMove(rowInput, colInput);
        }

        private static int CheckInputValue(string input, int position)
        {
            int result;
            bool isTrue = int.TryParse(input[position].ToString(), out result);

            if (!isTrue)
            {
                Console.WriteLine("Illegal input!");
                Commands();
            }

            return result;
        }

            static void Exit()
        {
            Environment.Exit(1);
        }

        public static void Start()
        {
            gameInProgress = true;
            cellsOpened = 0;

            playerMatrix = new char[Constants.MatrixRow, Constants.MatrixColumn];
            matrix = new char[Constants.MatrixRow, Constants.MatrixColumn];

            matrix = MinesGenerator.GenerareMinesweeperInMatrix(matrix);
            for (int i = 0; i < playerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < playerMatrix.GetLength(1); j++)
                {
                    playerMatrix[i, j] = Constants.Symbol;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines. " +
                              "Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' " +
                              "to quit the game.");
            Console.WriteLine();

            PrintMatrix(playerMatrix);

            while (gameInProgress)
            {
                Commands();
            }
        }

        public static void Top()
        {
            Scoreboard(topListNames, topListCellsOpened);
        }

        public static void MakeMove(int row, int col)
        {
            if (playerMatrix[row, col] != Constants.Symbol)
            {
                Console.WriteLine("Illegal move!");
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

                Console.WriteLine();                
                Console.WriteLine("Booooom! You were killed by a mine. You revealed {0} cells without mines.", cellsOpened);

                if (topListCellsOpened.Count == 0)
                {
                    topListCellsOpened.Add(new int());
                    topListNames.Add(String.Empty);
                }

                for (int i = 0; i < topListCellsOpened.Count; i++)
                {
                    if (cellsOpened >= topListCellsOpened[i])
                    {
                        topListCellsOpened.Insert(i, cellsOpened);

                        Console.Write("Please enter your name for the top scoreboard: ");
                        string igrach = Console.ReadLine();
                        topListNames.Insert(i, igrach);
                        if (emptyScoreboard || topListCellsOpened.Count == 6)
                        {
                            topListCellsOpened.RemoveAt(topListCellsOpened.Count - 1);
                            topListNames.RemoveAt(topListNames.Count - 1);
                            emptyScoreboard = false;
                        }
                        playerAddedToScoreboard = true;
                        break;
                    }
                }
                if (!playerAddedToScoreboard && topListCellsOpened.Count < 5)
                {
                    topListCellsOpened.Add(cellsOpened);
                    Console.Write("Please enter your name for the top scoreboard: ");
                    string playerName = Console.ReadLine();
                    topListNames.Add(playerName);
                }

                playerAddedToScoreboard = false;
                Scoreboard(topListNames, topListCellsOpened);
                Start();
            }
            else
            {
                cellsOpened++;
                if (cellsOpened == 35)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine("Congratulations! You revealed all cells without mines!");
                    gameInProgress = false;
                    Console.Write("Please enter your name for the top scoreboard: ");
                    string playerName = Console.ReadLine();
                    topListNames.Insert(0, playerName);
                    topListCellsOpened.Insert(0, 35);

                    if (topListCellsOpened.Count == 6)
                    {
                        topListCellsOpened.RemoveAt(5);
                        topListNames.RemoveAt(5);
                    }
                    Scoreboard(topListNames, topListCellsOpened);
                    Start();
                    return;
                }
                playerMatrix[row, col] = matrix[row, col];
                PrintMatrix(playerMatrix);
            }
        }

        public static void Scoreboard(List<string> playerNames, List<int> openedCells)
        {
            Console.WriteLine();
            Console.WriteLine("Scoreboard:");
            for (int i = 0; i < playerNames.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} Cells", i + 1, playerNames[i], openedCells[i]);
                Console.WriteLine();
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            Console.WriteLine();
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ----------------------");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }

                Console.WriteLine("|");
            }
            Console.WriteLine("   ----------------------");
        }

    }
}
