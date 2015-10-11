namespace ConsoleMinesweeper
{
    using System;
    using GameEngine;
    using GameEngine.Board;
    using GameEngine.Commands;
    using GameEngine.Statistic;

    public class ConsoleRenderSingleton : IRender
    {
        private static IRender instance;
        private FieldVisualator FieldVisualator;

        private ConsoleRenderSingleton()
        {
            this.FieldVisualator = new FieldVisualator();
        }

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

        public void Exit()
        {
            Environment.Exit(1);
        }

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
            isSuccessParse =int.TryParse(input[2].ToString(), out columnInput);

            if (!isSuccessParse)
            {
                this.ShowInvalidMoveMessage();
                return this.SetCommand(commandFactory);
            }

            return commandFactory.CreateMoveCommand(rowInput, columnInput);
        }

        public string SetName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");

            string playerName = Console.ReadLine();

            return playerName;
        }

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
                        uiElement = this.FieldVisualator.GetUIElement(field.Content);
                    }

                    Console.Write("{0} ", uiElement);
                }

                Console.WriteLine("|");
            }
            Console.WriteLine("   ----------------------");
        }

        public void ShowFailScreen(int countOfOpenField)
        {
            Console.WriteLine();
            Console.WriteLine("Booooom! You were killed by a mine. You revealed {0} cells without mines.", countOfOpenField);
        }

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

        public void ShowInvalidMoveMessage()
        {
            Console.WriteLine("Illegal input!");
        }

        public void ShowSuccessScreen()
        {
            Console.WriteLine("Congratulations! You revealed all cells without mines!");
        }

        public void ShowWelcomeScreen()
        {
            Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines. " +
                              "Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' " +
                              "to quit the game.");
            Console.WriteLine();
        }
    }
}
