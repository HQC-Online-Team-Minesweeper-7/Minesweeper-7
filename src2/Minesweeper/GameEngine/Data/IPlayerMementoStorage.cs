namespace GameEngine.Data
{
    using System.Collections.Generic;
    using GameEngine.Statistic.Player;

    public interface IPlayerMementoStorage : IEnumerable<PlayerMemento>
    {
        void Add(PlayerMemento player);

        PlayerMemento Get(int index);
    }
}
