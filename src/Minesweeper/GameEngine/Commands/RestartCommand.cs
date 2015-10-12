// ----------------------------------------------------------------------
// <copyright file="RestartCommand.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The restart command.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Commands
{
    using System;

    using State;

    /// <summary>
    /// The restart command.
    /// </summary>
    public class RestartCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestartCommand"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public RestartCommand(Engine engine)
            : base(engine)
        {
            Engine.State = new StartState(Engine);
        }
    }
}
