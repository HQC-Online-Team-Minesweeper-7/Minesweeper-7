using GameEngine.Board;
using GameEngine.State;
using GameEngine.Statistic;
using System;

namespace GameEngine
{
    public class Engine
    {
        internal int RowCount = 5;
        internal int ColumnCount = 10;
        internal int MineCount = 15;
        internal State.State State;
        internal Board.Board Board;
        internal readonly CommandFactory CommandFactory;

        public readonly IRender Render;
        public readonly IStatisticFactory StatisticFactory;
        public readonly IStatisticStorage StatisticStorage;

        public Engine(IRender render, IStatisticFactory statisticFactory, IStatisticStorage statisticStorage)
        {
            if (render == null)
            {
                throw new ArgumentNullException("render");
            }

            this.State = new StartState(this);
            this.CommandFactory = new CommandFactory(this);
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
