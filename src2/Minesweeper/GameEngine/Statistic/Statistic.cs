namespace GameEngine.Statistic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using GameEngine.Statistic.Player;

    public class Statistic : IStatistic
    {
        public readonly List<IPlayer> Players = new List<IPlayer>();

        private IComparer<IPlayer> backComparer;

        public Statistic(IComparer<IPlayer> backComparer)
        {
            this.BackComparer = backComparer;
        }

        public Statistic()
            : this(new PlayerBackwardComparer())
        {
        }

        public IComparer<IPlayer> BackComparer
        {
            get
            {
                return this.backComparer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "comparer");
                }

                if (this.backComparer != value)
                {
                    this.Players.Sort(value);
                }

                this.backComparer = value;
            }
        }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            this.Players.Add(player);
            this.Players.Sort(this.BackComparer);
        }

        public void Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            this.Players.Remove(player);
        }

        public void Clear()
        {
            this.Players.Clear();
        }

        public IEnumerator<IPlayer> GetEnumerator()
        {
            return this.Players.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
