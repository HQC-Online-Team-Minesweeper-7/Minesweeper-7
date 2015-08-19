namespace Minesweeper.ConsoleGame
{
    using System;

    using GameModel.Interfaces;

    internal class ConsoleRenderer : IRenderer
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}