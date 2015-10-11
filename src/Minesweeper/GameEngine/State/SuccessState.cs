// ----------------------------------------------------------------------
// <copyright file="SuccessState.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The success state.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.State
{
    /// <summary>
    /// The success state.
    /// </summary>
    internal class SuccessState : State
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessState"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public SuccessState(Engine engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Override the play.
        /// </summary>
        public override void Play()
        {
            var render = Engine.Render;

            render.ShowSuccessScreen();
            var name = render.SetName();
            var player = Engine.StatisticFactory.CreatePlayer(name, Engine.CountOfMove);
            var statistic = Engine.Statistic;
            statistic.Add(player);
            Engine.StatisticStorage.Save(statistic);
            render.ShowHighScore(statistic);

            Engine.State = new StartState(Engine);
            Engine.Play();
        }
    }
}
