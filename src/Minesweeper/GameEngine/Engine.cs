// ----------------------------------------------------------------------
// <copyright file="Engine.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The Engine.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine
{
    using System;

    using GameEngine.State;
    using GameEngine.Statistic;

    /// <summary>
    /// The Engine.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// The Render.
        /// </summary>
        public readonly IRender Render;

        /// <summary>
        /// The statistic factory.
        /// </summary>
        public readonly IStatisticFactory StatisticFactory;

        /// <summary>
        /// The statistic storage.
        /// </summary>
        public readonly IStatisticStorage StatisticStorage;

        /// <summary>
        /// The RowCount.
        /// </summary>
        internal readonly int RowCount = 5;

        /// <summary>
        /// The ColumnCount.
        /// </summary>
        internal readonly int ColumnCount = 10;

        /// <summary>
        /// The MineCount.
        /// </summary>
        internal readonly int MineCount = 15;

        /// <summary>
        /// The CommandFactory.
        /// </summary>
        internal readonly CommandFactory CommandFactory;

        /// <summary>
        /// The Statistic.
        /// </summary>
        internal readonly IStatistic Statistic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        /// <param name="render">The render.</param>
        /// <param name="statisticFactory">The statisticFactory.</param>
        /// <param name="statisticStorage">The statisticStorage.</param>
        public Engine(IRender render, IStatisticFactory statisticFactory, IStatisticStorage statisticStorage)
        {
            if (render == null)
            {
                throw new ArgumentNullException(nameof(render));
            }

            if (statisticFactory == null)
            {
                throw new ArgumentNullException(nameof(statisticFactory));
            }

            if (statisticStorage == null)
            {
                throw new ArgumentNullException(nameof(statisticStorage));
            }

            this.Render = render;
            this.StatisticFactory = statisticFactory;
            this.StatisticStorage = statisticStorage;

            this.State = new StartState(this);
            this.CommandFactory = new CommandFactory(this);
            this.Statistic = this.StatisticFactory.CreateStatistic();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        /// <param name="render">The render.</param>
        public Engine(IRender render)
            : this(render, new StatisticFactory(), new StatisticStorageDummy())
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether is state.
        /// </summary>
        internal State.State State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is board.
        /// </summary>
        internal Board.Board Board { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is CountOfMove.
        /// </summary>
        internal int CountOfMove { get; set; }

        /// <summary>
        /// The play...
        /// </summary>
        public void Play()
        {
            this.State.Play();
        }
    }
}
