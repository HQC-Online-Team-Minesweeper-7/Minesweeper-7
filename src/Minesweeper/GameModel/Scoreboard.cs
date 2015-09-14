namespace Minesweeper.GameModel
{
    using System.Collections.Generic;

    using GameModel.Interfaces;
    using System;

    class ScoreBoard
    {
        private IList<Player> players;
        private IRenderer renderer;

        public ScoreBoard(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(int position)
        {
            this.players.RemoveAt(position);
        }

        public IList<Player> GetPlayers()
        {
            return this.players;
        }

        public int TopListCount()
        {
            if (players != null)
            {
                return this.players.Count;
            }
            else
            {
                return 0;
            }
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Scoreboard:");

            if (players != null)
            {
                foreach (var player in players)
                {
                    renderer.WriteLine(player.ToString());
                }
            }
        }
    }
}
