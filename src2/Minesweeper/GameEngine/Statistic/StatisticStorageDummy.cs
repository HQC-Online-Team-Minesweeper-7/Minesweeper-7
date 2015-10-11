namespace GameEngine.Statistic
{
    using Data;

    class StatisticStorageDummy : IStatisticStorage
    {
        public IStatistic Restore()
        {
            return new Statistic();
        }

        public void Save(IStatistic statistic)
        {
        }
    }
}
