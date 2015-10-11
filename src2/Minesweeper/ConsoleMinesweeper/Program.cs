// ----------------------------------------------------------------------
// <copyright file="Program.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The entry point of the program.
// </summary>
// ---------------------------------------------------------------------
namespace ConsoleMinesweeper
{   
    using GameEngine;

    /// <summary>
    /// The console game.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main program.
        /// </summary>
        private static void Main()
        {
            var engine = new Engine(ConsoleRenderSingleton.Instance);
            engine.Play();
        }
    }
}
