namespace GameEngine.Statistic.Player
{
    using System.Collections.Generic;

    public class PlayerBackwardComparer : IComparer<IPlayer>
    {
        public int Compare(IPlayer x, IPlayer y)
        {
            return y.Score.CompareTo(x.Score);
        }
    }
}
