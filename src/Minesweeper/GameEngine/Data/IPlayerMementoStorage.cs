// ----------------------------------------------------------------------
// <copyright file="IPlayerMementoStorage.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The player memento storage interface.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Data
{
    using System.Collections.Generic;
    using GameEngine.Statistic.Player;

    /// <summary>
    /// The player memento storage interface.
    /// </summary>
    public interface IPlayerMementoStorage : IEnumerable<PlayerMemento>
    {
        /// <summary>
        /// Add players.
        /// </summary>
        /// <param name="player">The player.</param>
        void Add(PlayerMemento player);

        /// <summary>
        /// Gets a value indicating whether is index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="PlayerMemento"/>.</returns>
        PlayerMemento Get(int index);
    }
}
