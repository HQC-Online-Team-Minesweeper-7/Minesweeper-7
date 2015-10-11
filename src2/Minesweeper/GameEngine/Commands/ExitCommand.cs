// ----------------------------------------------------------------------
// <copyright file="ExitCommand.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The exit commands.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Commands
{
    using GameEngine.State;

    /// <summary>
    /// The exit commands.
    /// </summary>
    internal class ExitCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand"/> class.
        /// </summary>
        /// <param name="engine">The engine state.</param>
        public ExitCommand(Engine engine)
            : base(engine)
        {
            Engine.State = new ExitState(Engine);
        }
    }
}
