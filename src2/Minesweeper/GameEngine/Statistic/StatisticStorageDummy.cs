namespace GameEngine.Statistic
{
    using Data;

    class StatisticStorageDummy : IStatisticStorage
    {
        public IStatistic Restore(IPlayerMementoStorage playerMementoStorage)
        {
            return new Statistic();
        }

        public void Save(IStatistic statistic, IPlayerMementoStorage playerMementoStorage)
        {
        }
    }
}
