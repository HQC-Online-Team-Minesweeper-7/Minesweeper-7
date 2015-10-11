using GameEngine.Board;
using GameEngine.State;
using GameEngine.Statistic;
using System;

namespace GameEngine
{
    public class Engine
    {
        public readonly IRender Render;
        public readonly IStatisticFactory StatisticFactory;
        public readonly IStatisticStorage StatisticStorage;

        internal int RowCount = 5;
        internal int ColumnCount = 10;
        internal int MineCount = 15;
        internal State.State State;
        internal Board.Board Board;
        internal IStatistic Statistic;
        internal readonly CommandFactory CommandFactory;

        internal int CountOfMove;

        public Engine(IRender render, IStatisticFactory statisticFactory, IStatisticStorage statisticStorage)
        {
            if (render == null)
            {
                throw new ArgumentNullException("render");
            }

            if (statisticFactory == null)
            {
                throw new ArgumentNullException("statisticFactory");
            }

            if (statisticStorage == null)
            {
                throw new ArgumentNullException("statisticStorage");
            }

            this.Render = render;
            this.StatisticFactory = statisticFactory;
            this.StatisticStorage = statisticStorage;

            this.State = new StartState(this);
            this.CommandFactory = new CommandFactory(this);
            this.Statistic = StatisticFactory.CreateStatistic();
        }

        public Engine(IRender render)
            : this(render, new StatisticFactory(), new StatisticStorageDummy())
        {
        }

        public void Play()
        {
            this.State.Play();
        }
    }
}
