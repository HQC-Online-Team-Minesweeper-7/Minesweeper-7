using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace ConsoleMinesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(ConsoleRenderSingleton.Instance);
            engine.Play();
        }
    }
}
