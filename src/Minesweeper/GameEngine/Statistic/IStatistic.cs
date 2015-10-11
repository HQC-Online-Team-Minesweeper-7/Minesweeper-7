// ----------------------------------------------------------------------
// <copyright file="IStatistic.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic interface.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic
{
    using System.Collections.Generic;

    using GameEngine.Statistic.Player;

    /// <summary>
    /// The statistic interface.
    /// </summary>
    public interface IStatistic : IEnumerable<IPlayer>
    {
        /// <summary>
        /// Gets or sets a value indicating whether is BackComparer.
        /// </summary>
        /// <value>Gets or sets BackComparer.</value>
        IComparer<IPlayer> BackComparer { get; set; }

        /// <summary>
        /// Add players.
        /// </summary>
        /// <param name="player">The player.</param>
        void Add(IPlayer player);

        /// <summary>
        /// Remove players.
        /// </summary>
        /// <param name="player">The player.</param>
        void Remove(IPlayer player);

        /// <summary>
        /// The clear.
        /// </summary>
        void Clear();
    }
}
