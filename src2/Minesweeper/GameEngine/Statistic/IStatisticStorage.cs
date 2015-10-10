namespace GameEngine.Statistic
{
    using GameEngine.Data;

    public interface IStatisticStorage
    {
        void Save(IStatistic statistic, IPlayerMementoStorage playerMementoStorage);
        IStatistic Restore(IPlayerMementoStorage playerMementoStorage);
    }
}
