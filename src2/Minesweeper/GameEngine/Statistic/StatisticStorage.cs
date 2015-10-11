// ----------------------------------------------------------------------
// <copyright file="StatisticStorage.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic storage.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic
{
    using System;

    using Data;

    /// <summary>
    /// The statistic storage.
    /// </summary>
    internal class StatisticStorage : IStatisticStorage
    {
        /// <summary>
        /// The factory.
        /// </summary>
        public readonly IStatisticFactory Factory;

        /// <summary>
        /// The player memento storage.
        /// </summary>
        public readonly IPlayerMementoStorage PlayerMementoStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticStorage"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="playerMementoStorage">The playerMementoStorage.</param>
        public StatisticStorage(IStatisticFactory factory, IPlayerMementoStorage playerMementoStorage)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (playerMementoStorage == null)
            {
                throw new ArgumentNullException(nameof(playerMementoStorage));
            }

            this.Factory = factory;
            this.PlayerMementoStorage = playerMementoStorage;
        }

        /// <summary>
        /// Restore player.
        /// </summary>
        /// <returns>The <see cref="IStatistic"/>.</returns>
        public IStatistic Restore()
        {
            var statistic = this.Factory.CreateStatistic();

            foreach (var playerMemento in this.PlayerMementoStorage)
            {
                var player = this.Factory.CreatePlayer(playerMemento.Name, playerMemento.Score);
                statistic.Add(player);
            }

            return statistic;
        }

        /// <summary>
        /// The save...
        /// </summary>
        /// <param name="statistic">The statistic.</param>
        public void Save(IStatistic statistic)
        {
            foreach (var player in statistic)
            {
                this.PlayerMementoStorage.Add(player.StoreToMemento());
            }
        }
    }
}
