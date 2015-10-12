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
    using Validator;
    using Data;

    /// <summary>
    /// The statistic storage.
    /// </summary>
    public class StatisticStorage : IStatisticStorage
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
            Validator.CheckIfNull(factory, nameof(factory));

            Validator.CheckIfNull(playerMementoStorage, nameof(playerMementoStorage));

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
