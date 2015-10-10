namespace GameEngine.Statistic
{
    using System;
    using GameEngine.Statistic.Player;

    public class StatisticFactory : IStatisticFactory
    {
        public IPlayer CreatePlayer(string name, int score = 0)
        {
            return new Player.Player(name, score);
        }

        public IStatistic CreateStatistic()
        {
            return new Statistic();
        }
    }
}
