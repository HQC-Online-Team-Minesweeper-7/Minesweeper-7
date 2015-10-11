// ----------------------------------------------------------------------
// <copyright file="IStatisticStorage.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic storage.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic
{
    using GameEngine.Data;

    /// <summary>
    /// The statistic storage.
    /// </summary>
    public interface IStatisticStorage
    {
        /// <summary>
        /// The save...
        /// </summary>
        /// <param name="statistic">The statistic.</param>
        void Save(IStatistic statistic);

        /// <summary>
        /// The restore.
        /// </summary>
        /// <returns>The <see cref="IStatistic"/>.</returns>
        IStatistic Restore();
    }
}
