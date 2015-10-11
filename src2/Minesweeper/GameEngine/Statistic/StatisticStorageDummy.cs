// ----------------------------------------------------------------------
// <copyright file="StatisticStorageDummy.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic storage dummy.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic
{
    /// <summary>
    /// The statistic storage dummy.
    /// </summary>
    internal class StatisticStorageDummy : IStatisticStorage
    {
        /// <summary>
        /// The restore statistic.
        /// </summary>
        /// <returns>The <see cref="Restore"/>.</returns>
        public IStatistic Restore()
        {
            return new Statistic();
        }

        /// <summary>
        /// The save...
        /// </summary>
        /// <param name="statistic">The statistic.</param>
        public void Save(IStatistic statistic)
        {
        }
    }
}
