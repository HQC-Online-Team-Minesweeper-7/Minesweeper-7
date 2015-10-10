namespace GameEngine.Statistic
{
    using System;
    using Data;

    class StatisticStorage : IStatisticStorage
    {
        public readonly IStatisticFactory Factory;

        public StatisticStorage(IStatisticFactory factory)
        {
            if(factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            Factory = factory;
        }

        public IStatistic Restore(IPlayerMementoStorage playerMementoStorage)
        {
            var statistic = this.Factory.CreateStatistic();

            foreach (var playerMemento in playerMementoStorage)
            {
                var player = this.Factory.CreatePlayer(playerMemento.Name, playerMemento.Score);
                statistic.Add(player);
            }

            return statistic;
        }

        public void Save(IStatistic statistic, IPlayerMementoStorage playerMementoStorage)
        {
            foreach(var player in statistic)
            {
                playerMementoStorage.Add(player.StoreToMemento());
            }
        }
    }
}
