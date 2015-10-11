// ----------------------------------------------------------------------
// <copyright file="Statistic.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using GameEngine.Statistic.Player;

    /// <summary>
    /// The statistic.
    /// </summary>
    public class Statistic : IStatistic
    {
        /// <summary>
        /// The players.
        /// </summary>
        public readonly List<IPlayer> Players = new List<IPlayer>();

        /// <summary>
        /// The back comparer.
        /// </summary>
        private IComparer<IPlayer> backComparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Statistic"/> class.
        /// </summary>
        /// <param name="backComparer">The back comparer.</param>
        public Statistic(IComparer<IPlayer> backComparer)
        {
            this.BackComparer = backComparer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Statistic"/> class.
        /// </summary>
        public Statistic()
            : this(new PlayerBackwardComparer())
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether is BackComparer.
        /// </summary>
        /// <value>Gets or sets BackComparer.</value>
        public IComparer<IPlayer> BackComparer
        {
            get
            {
                return this.backComparer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "comparer");
                }

                if (this.backComparer != value)
                {
                    this.Players.Sort(value);
                }

                this.backComparer = value;
            }
        }

        /// <summary>
        /// Add player.
        /// </summary>
        /// <param name="player">The player.</param>
        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            this.Players.Add(player);
            this.Players.Sort(this.BackComparer);
        }

        /// <summary>
        /// Remove player.
        /// </summary>
        /// <param name="player">The player.</param>
        public void Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            this.Players.Remove(player);
        }

        /// <summary>
        /// The clear...
        /// </summary>
        public void Clear()
        {
            this.Players.Clear();
        }

        /// <summary>
        /// The IEnumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        public IEnumerator<IPlayer> GetEnumerator()
        {
            return this.Players.GetEnumerator();
        }

        /// <summary>
        /// The IEnumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
