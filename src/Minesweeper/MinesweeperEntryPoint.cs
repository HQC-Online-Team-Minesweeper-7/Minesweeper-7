using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Minesweeper.ConsoleGame;
using Minesweeper.GameModel;
using Minesweeper.Utils;
// taiz igra sym ya igral na 8 godinki kato biah u lqlq stefka na komputera v bibliotekata

namespace Minesweeper
{
    public class Minesweeper
    {
        static char[,] matrica;
        static char[,] playerMatrix;
        static bool gameInProgress;
        static bool emptyScoreboard = true;
        static bool playerAddedToScoreboard = false;
        static int cellsOpened = 0;
        static List<string> topListNames = new List<string>();
        static List<int> topListCellsOpened = new List<int>();



        static void PrintMatrix(char[,] matrix)
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

        static char[,] GenerateMinesweeperMatrix()
        {
           
        }

        
        static void Commands()
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
                NovaIgra();
                return;
            }

            if (input == "top")
            {
                Top();
                return;
            }

            if (input.Length != 3)
            {
                Console.WriteLine("Illegal input!");
                return;
            }

            if (input[1] != ' ')
            {
                Console.WriteLine("Illegal input!");
                return;
            }

            bool proverka;
            int rowInput;
            proverka = int.TryParse(input[0].ToString(), out rowInput);
            if (!proverka)
            {
                Console.WriteLine("Illegal input!");
                return;
            }

            int colInput;
            proverka =
                int.TryParse(
                input[2].ToString(),
                out colInput);
            if (!proverka)
            {
                Console.WriteLine("Illegal input!");
                return;
            }

            DoMove(rowInput, colInput);
        }
        static void Exit()
        {
            Environment.Exit(1);
        }

        static void Top()
        {
            Scoreboard(topListNames, topListCellsOpened);
        }
        static void DoMove(int row, int col)
        {//tuka sme na pyt da se premestim
            if (playerMatrix[row, col] != '?')
            {

                //proverqvam dali moga da mrydna
                Console.WriteLine("Illegal move!");
                return;
            }

            if (matrica[row, col] == '*')
            {
                for (int i = 0; i < matrica.GetLength(0); i++)
                {
                    for (int j = 0; j < matrica.GetLength(1); j++)
                    {
                        if (matrica[i, j] == '*')
                        {
                            playerMatrix[i, j] = '*';
                            continue;
                        }

                        if (playerMatrix[i, j] == '?')
                        {
                            playerMatrix[i, j] = '-';
                        }
                    }
                }

                PrintMatrix(playerMatrix);
                gameInProgress = false;
                Console.WriteLine();
                //oh izgyrmq
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
                NovaIgra();
            }
            else
            {
                cellsOpened++;
                if (cellsOpened == 35)
                {
                    PrintMatrix(matrica);
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
                    NovaIgra();
                    return;
                }

                playerMatrix[row, col] = matrica[row, col];
                PrintMatrix(playerMatrix);
            }
        }

        static void Scoreboard(List<string> playerNames, List<int> openedCells)
        {
            Console.WriteLine();
            Console.WriteLine("Scoreboard:");
                       
            for (int i = 0; i < playerNames.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} Cells", i + 1, playerNames[i], openedCells[i]);
                Console.WriteLine();
            }
        }

        static void Main()
        {
            var consoleRenderer = new ConsoleRenderer();

            var engine = new ConsoleMinesweeperEngine(consoleRenderer);
            engine.Start();
            NovaIgra();
        }
    }
}
