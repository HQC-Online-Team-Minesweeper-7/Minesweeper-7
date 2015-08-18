using Minesweeper.GameModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.ConsoleGame
{
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
