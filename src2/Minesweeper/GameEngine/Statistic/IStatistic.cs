namespace GameEngine.Statistic
{
    using System.Collections.Generic;
    using GameEngine.Statistic.Player;

    public interface IStatistic : IEnumerable<IPlayer>
    {
        IComparer<IPlayer> BackComparer { get; set; }

        void Add(IPlayer player);

        void Remove(IPlayer player);

        void Clear();
    }
}
