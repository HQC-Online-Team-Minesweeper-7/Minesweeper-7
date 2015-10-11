// ----------------------------------------------------------------------
// <copyright file="MoveCommand.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The move commands.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Commands
{
    using GameEngine.State;

    /// <summary>
    /// The move commands.
    /// </summary>
    internal class MoveCommand : Command
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
        /// Initializes a new instance of the <see cref="MoveCommand"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public MoveCommand(Engine engine, int x, int y)
            : base(engine)
        {
            this.X = x;
            this.Y = y;

            Engine.State = new MoveState(Engine, this.X, this.Y);
        }
    }
}
