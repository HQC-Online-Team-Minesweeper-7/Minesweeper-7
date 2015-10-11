namespace GameEngine.Statistic
{
    internal class StatisticStorageDummy : IStatisticStorage
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
