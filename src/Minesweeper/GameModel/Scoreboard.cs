namespace Minesweeper.GameModel
{
    using System.Collections.Generic;

    using GameModel.Interfaces;
    using System;

    class ScoreBoard
    {
        private IList<Player> players;
        private IRenderer renderer;
        private List<string> topListNames = new List<string>();
        private List<int> topListCellsOpened = new List<int>();

        public ScoreBoard()
        {
            players = new List<Player>();
        }

        public ScoreBoard(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void AddPlayer(Player player)
        {
            if (players == null)
            {
                players = new List<Player>();
            }

            if (topListCellsOpened.Count == 0)
            {
                topListCellsOpened.Add(new int());
                topListNames.Add(String.Empty);
            }
            //Console.WriteLine(player.Place);
            player.Place++;
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
