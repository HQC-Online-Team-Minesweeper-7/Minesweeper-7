namespace GameEngine.Statistic
{
    using System;
    using Data;

    internal class StatisticStorage : IStatisticStorage
    {
        public readonly IStatisticFactory Factory;
        public readonly IPlayerMementoStorage PlayerMementoStorage;

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

        public void Save(IStatistic statistic)
        {
            foreach (var player in statistic)
            {
                this.PlayerMementoStorage.Add(player.StoreToMemento());
            }
        }
    }
}
