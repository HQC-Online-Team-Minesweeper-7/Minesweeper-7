// ----------------------------------------------------------------------
// <copyright file="PlayerBackwardComparer.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The player backward comparer.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic.Player
{
    using System.Collections.Generic;

    /// <summary>
    /// The player backward comparer.
    /// </summary>
    public class PlayerBackwardComparer : IComparer<IPlayer>
    {
        /// <summary>
        /// The compare players.
        /// </summary>
        /// <param name="x">The first player.</param>
        /// <param name="y">The second player.</param>
        /// <returns>The return <see cref="int"/>.</returns>
        public int Compare(IPlayer x, IPlayer y)
        {
            return y.Score.CompareTo(x.Score);
        }
    }
}
