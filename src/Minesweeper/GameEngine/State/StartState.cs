// ----------------------------------------------------------------------
// <copyright file="StartState.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The start state.
// </summary>
// ----------------------------------------------------------------------

namespace GameEngine.State
{
    using System;

    using Board;

    /// <summary>
    /// The start state.
    /// </summary>
    internal class StartState : State
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartState"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public StartState(Engine engine)
            : base(engine)
        {
            Engine.CountOfMove = 0;
        }

        /// <summary>
        /// Override the play.
        /// </summary>
        public override void Play()
        {
            this.Engine.Render.ShowWelcomeScreen();
            var boardBuilder = new BoardBuilder(this.Engine.RowCount, this.Engine.ColumnCount);
            this.Engine.Board = boardBuilder.Generate(this.Engine.MineCount);
            this.Engine.Render.ShowBoard(this.Engine.Board);
            var command = this.Engine.Render.SetCommand(this.Engine.CommandFactory);
            command.Execute();
        }
    }
}
