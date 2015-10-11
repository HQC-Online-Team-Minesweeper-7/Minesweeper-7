// ----------------------------------------------------------------------
// <copyright file="ExitState.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The exit state.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.State
{
    using System;

    /// <summary>
    /// The exit state.
    /// </summary>
    internal class ExitState : State
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitState"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public ExitState(Engine engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Override the play.
        /// </summary>
        public override void Play()
        {
            this.Engine.Render.Exit();
        }
    }
}
