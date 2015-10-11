// ----------------------------------------------------------------------
// <copyright file="Player.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The player.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic.Player
{
    using System;

    /// <summary>
    /// The player.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// The name...
        /// </summary>
        private string name;

        /// <summary>
        /// The score.
        /// </summary>
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name...</param>
        /// <param name="score">The score.</param>
        public Player(string name, int score = 0)
        {
            this.Name = name;
            this.Score = score;
        }

        /// <summary>
        /// Gets a value indicating whether is name.
        /// </summary>
        /// <value>Get the name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name is invalid");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is score.
        /// </summary>
        /// <value>Get the score.</value>
        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("score is less than zero");
                }

                this.score = value;
            }
        }

        /// <summary>
        /// The restore player from memento.
        /// </summary>
        /// <param name="memento">The memento.</param>
        public void RestoreFromMemento(PlayerMemento memento)
        {
            this.Name = memento.Name;
            this.Score = memento.Score;
        }

        /// <summary>
        /// The store player to memento.
        /// </summary>
        /// <returns>The <see cref="PlayerMemento"/>.</returns>
        public PlayerMemento StoreToMemento()
        {
            var memento = new PlayerMemento(this.Name, this.Score);

            return memento;
        }
    }
}
