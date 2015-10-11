// ----------------------------------------------------------------------
// <copyright file="ConsoleRenderSingleton.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The console render Singleton.
// </summary>
// ----------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;
    using GameEngine;
    using GameEngine.Board;
    using GameEngine.Commands;
    using GameEngine.Statistic;

    /// <summary>
    /// Console renderer use Singleton.
    /// </summary>
    public class ConsoleRenderSingleton : IRender
    {
        /// <summary>
        /// The IRender.
        /// </summary>
        private static IRender instance;

        /// <summary>
        /// The field visualizer.
        /// </summary>
        private FieldVisualator fieldVisualator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleRenderSingleton"/> class.
        /// </summary>
        private ConsoleRenderSingleton()
        {
            this.fieldVisualator = new FieldVisualator();
        }

        /// <summary>
        /// Gets IRender instance.
        /// </summary>
        /// <value>The IRender instance.</value>
        public static IRender Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleRenderSingleton();
                }

                return instance;
            }
        }

        /// <summary>
        /// Use Exit commands.
        /// </summary>
        public void Exit()
        {
            Environment.Exit(1);
        }

        /// <summary>
        /// Use commands.
        /// </summary>
        /// <param name="commandFactory">
        /// The console command.
        /// </param>
        /// <returns>
        /// The <see cref="Command"/>.
        /// </returns>
        public Command SetCommand(CommandFactory commandFactory)
        {
            Console.WriteLine();
            Console.Write("Enter row and column: ");
            string input = Console.ReadLine().Trim();

            switch (input)
            {
                case "top":
                    return commandFactory.CreateShowStatistiCommand();
                case "exit":
                    return commandFactory.CreateExitCommand();
                case "restart":
                    return commandFactory.CreateRestartCommand();
            }

            if (input.Length != 3)
            {
                this.ShowInvalidMoveMessage();

                return this.SetCommand(commandFactory);
            }

            if (input[1] != ' ')
            {
                this.ShowInvalidMoveMessage();

                return this.SetCommand(commandFactory);
            }

            bool isSuccessParse;
            int rowInput;
            isSuccessParse = int.TryParse(input[0].ToString(), out rowInput);

            if (!isSuccessParse)
            {
                this.ShowInvalidMoveMessage();
                return this.SetCommand(commandFactory);
            }

            int columnInput;
            isSuccessParse = int.TryParse(input[2].ToString(), out columnInput);

            if (!isSuccessParse)
            {
                this.ShowInvalidMoveMessage();
                return this.SetCommand(commandFactory);
            }

            return commandFactory.CreateMoveCommand(rowInput, columnInput);
        }

        /// <summary>
        /// Enter name for player.
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public string SetName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");

            string playerName = Console.ReadLine();

            return playerName;
        }

        /// <summary>
        /// Show game board.
        /// </summary>
        /// <param name="board">The board.</param>
        public void ShowBoard(IBoard board)
        {
            Console.WriteLine();
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ----------------------");
            int counter = 0;
            foreach (var row in board)
            {
                Console.Write("{0} | ", counter++);

                foreach (var field in row)
                {
                    var uiElement = "?";

                    if (field.IsView)
                    {
                        uiElement = this.fieldVisualator.GetUIElement(field.Content);
                    }

                    Console.Write("{0} ", uiElement);
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ----------------------");
        }

        /// <summary>
        /// Show fill screen.
        /// </summary>
        /// <param name="countOfOpenField">The count of open field.</param>
        public void ShowFailScreen(int countOfOpenField)
        {
            Console.WriteLine();
            Console.WriteLine("Booooom! You were killed by a mine. You revealed {0} cells without mines.", countOfOpenField);
        }

        /// <summary>
        /// Show scoreboard.
        /// </summary>
        /// <param name="statistic">The statistic.</param>
        public void ShowHighScore(IStatistic statistic)
        {
            Console.WriteLine();
            Console.WriteLine("Scoreboard:");
            int place = 1;
            foreach (var player in statistic)
            {
                Console.WriteLine("{0}. {1} --> {2} Cells", place++, player.Name, player.Score);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Show invalid move message.
        /// </summary>
        public void ShowInvalidMoveMessage()
        {
            Console.WriteLine("Illegal input!");
        }

        /// <summary>
        /// Show success screen.
        /// </summary>
        public void ShowSuccessScreen()
        {
            Console.WriteLine("Congratulations! You revealed all cells without mines!");
        }

        /// <summary>
        /// Show welcome screen.
        /// </summary>
        public void ShowWelcomeScreen()
        {
            Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines. " +
                              "Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' " +
                              "to quit the game.");
            Console.WriteLine();
        }
    }
}
