using Minesweeper.GameModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameModel
{
    class ScoreBoard
    {
        private ICollection<Player> players;
        private IRenderer renderer;

        public ScoreBoard(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void Print()
        {
            foreach (var player in players)
            {
                renderer.WriteLine(player.ToString());
            }
        }
    }
}
