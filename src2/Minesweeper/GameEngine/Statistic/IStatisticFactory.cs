namespace GameEngine.Statistic
{
    using GameEngine.Statistic.Player;

    public interface IStatisticFactory
    {
        IStatistic CreateStatistic();

        IPlayer CreatePlayer(string name, int score = 0);
    }
}
