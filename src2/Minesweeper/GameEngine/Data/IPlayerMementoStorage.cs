using System.Collections.Generic;
using GameEngine.Statistic.Player;

namespace GameEngine.Data
{
    public interface IPlayerMementoStorage : IEnumerable<PlayerMemento>
    {
        void Add(PlayerMemento player);

        PlayerMemento Get(int index);
    }
}
