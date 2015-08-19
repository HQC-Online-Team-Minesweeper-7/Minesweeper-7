namespace Minesweeper.GameModel
{
    using System;
    using System.Text;

    using GameModel.Interfaces;

    public class Player : IPlayer
    {
        public Player(string playerName, int score)
        {
            this.Name = playerName;
            this.Score = score;
        }

        public string Name { get; set; }

        public int Score { get; set; }

        public int Place { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Player))
            {
                throw new ArgumentException("Compare Object is not ScoreRecord!");
            }

            return -1 * this.Score.CompareTo(((Player)obj).Score);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(String.Format("{0}. {1} --> {2} Cells", this.Place, this.Name, this.Score));
            result.AppendLine();

            return result.ToString();
        }
    }
}
