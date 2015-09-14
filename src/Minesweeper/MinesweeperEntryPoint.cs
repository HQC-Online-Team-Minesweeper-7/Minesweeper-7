namespace Minesweeper
{
    using ConsoleGame;

    internal class Minesweeper
    {
        static void Main()
        {
            var consoleRenderer = new ConsoleRenderer();

            var engine = new ConsoleMinesweeperEngine(consoleRenderer);

            engine.Start();
        }
    }
}
