// ----------------------------------------------------------------------
// <copyright file="IStatisticFactory.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic factory.
// </summary>
// ----------------------------------------------------------------------

namespace GameEngine.Statistic
{
    using GameEngine.Statistic.Player;

    /// <summary>
    /// The statistic factory.
    /// </summary>
    public interface IStatisticFactory
    {
        /// <summary>
        /// Create statistic.
        /// </summary>
        /// <returns>The <see cref="IStatistic"/>.</returns>
        IStatistic CreateStatistic();

        /// <summary>
        /// Create player.
        /// </summary>
        /// <param name="name">The name...</param>
        /// <param name="score">The score.</param>
        /// <returns>The <see cref="IPlayer"/>.</returns>
        IPlayer CreatePlayer(string name, int score = 0);
    }
}
