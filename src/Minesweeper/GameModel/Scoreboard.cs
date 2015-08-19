namespace Minesweeper.GameModel
{
    using System.Collections.Generic;

    using GameModel.Interfaces;
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
            return this.players.Count;
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
