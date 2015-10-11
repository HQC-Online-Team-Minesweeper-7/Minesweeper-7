namespace ConsoleMinesweeper
{   
    using GameEngine;
    internal class Program
    {
        private static void Main()
        {
            var engine = new Engine(ConsoleRenderSingleton.Instance);
            engine.Play();
        }
    }
}
