// ----------------------------------------------------------------------
// <copyright file="MoveState.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The move state.
// </summary>
// ----------------------------------------------------------------------

namespace GameEngine.State
{
    using System;

    /// <summary>
    /// The move state.
    /// </summary>
    internal class MoveState : State
    {
        /// <summary>
        /// The x position.
        /// </summary>
        public readonly int X;

        /// <summary>
        /// The y position.
        /// </summary>
        public readonly int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveState"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public MoveState(Engine engine, int x, int y)
            : base(engine)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Override the play.
        /// </summary>
        public override void Play()
        {
            var board = this.Engine.Board;
            var render = this.Engine.Render;

            if (board.IsCorrectPosition(this.X, this.Y))
            {
                var field = board[this.Y, this.X];
                field.IsView = true;

                if (field.IsMine)
                {
                    Engine.State = new FailState(Engine);
                    Engine.Play();
                }
                else if (board.IsAllView)
                {
                    Engine.State = new SuccessState(Engine);
                    Engine.Play();
                }
            }
            else
            {
                render.ShowInvalidMoveMessage();
            }

            Engine.CountOfMove++;
            render.ShowBoard(this.Engine.Board);
            var command = render.SetCommand(this.Engine.CommandFactory);
            command.Execute();
        }
    }
}
