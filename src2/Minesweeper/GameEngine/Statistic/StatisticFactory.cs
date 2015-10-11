// ----------------------------------------------------------------------
// <copyright file="StatisticFactory.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic factory.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic
{
    using System;

    using GameEngine.Statistic.Player;

    /// <summary>
    /// The statistic factory.
    /// </summary>
    public class StatisticFactory : IStatisticFactory
    {
        /// <summary>
        /// Create player.
        /// </summary>
        /// <param name="name">The name...</param>
        /// <param name="score">The score.</param>
        /// <returns>The <see cref="IPlayer"/>.</returns>
        public IPlayer CreatePlayer(string name, int score = 0)
        {
            return new Player.Player(name, score);
        }

        /// <summary>
        /// Create statistic.
        /// </summary>
        /// <returns>The <see cref="IStatistic"/>.</returns>
        public IStatistic CreateStatistic()
        {
            return new Statistic();
        }
    }
}
