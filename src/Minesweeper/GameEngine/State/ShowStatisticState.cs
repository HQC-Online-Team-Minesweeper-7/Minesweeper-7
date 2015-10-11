// ----------------------------------------------------------------------
// <copyright file="ShowStatisticState.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic state.
// </summary>
// ----------------------------------------------------------------------

namespace GameEngine.State
{
    /// <summary>
    /// The statistic state.
    /// </summary>
    internal class ShowStatisticState : State
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowStatisticState"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public ShowStatisticState(Engine engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Override the play.
        /// </summary>
        public override void Play()
        {
            this.Engine.Render.ShowHighScore(this.Engine.Statistic);
            var command = this.Engine.Render.SetCommand(this.Engine.CommandFactory);
            command.Execute();
        }
    }
}
