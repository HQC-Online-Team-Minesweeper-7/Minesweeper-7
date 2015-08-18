namespace Minesweeper.GameModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameModel.Interfaces;

    public class Scoreboard : IComparable, IScoreBoard
    {
        public Scoreboard(string playerName, int score)
        {
            this.PlayerName = playerName;
            this.Score = score;
        }

        public string PlayerName { get; set; }

        public int Score { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Scoreboard))
            {
                throw new ArgumentException("Compare Object is not ScoreRecord!");
            }

            return -1 * this.Score.CompareTo(((Scoreboard)obj).Score);
        }
    }
}
