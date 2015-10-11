// ----------------------------------------------------------------------
// <copyright file="FailState.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The fail state.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.State
{
    using System;

    /// <summary>
    /// The fail state.
    /// </summary>
    internal class FailState : State
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailState"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public FailState(Engine engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Override the play.
        /// </summary>
        public override void Play()
        {
            var render = Engine.Render;
            render.ShowBoard(Engine.Board);
            render.ShowFailScreen(Engine.CountOfMove);

            if (Engine.CountOfMove > 0)
            {
                var name = render.SetName();
                var player = Engine.StatisticFactory.CreatePlayer(name, Engine.CountOfMove);
                var statistic = Engine.Statistic;
                statistic.Add(player);
                Engine.StatisticStorage.Save(statistic);
                render.ShowHighScore(statistic);
            }

            Engine.State = new StartState(Engine);
            Engine.Play();
        }
    }
}
