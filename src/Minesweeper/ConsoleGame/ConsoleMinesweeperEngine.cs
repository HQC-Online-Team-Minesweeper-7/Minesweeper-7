namespace Minesweeper.ConsoleGame
{
    using GameModel.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class ConsoleMinesweeperEngine
    {
        private IScoreBoard scoreBoard;
        private IRenderer renderer;

        public ConsoleMinesweeperEngine(IRenderer renderer)
        {
            this.scoreBoard = scoreBoard;
            this.renderer = renderer;
        }

        public void Start()
        {

        }
    }
}
