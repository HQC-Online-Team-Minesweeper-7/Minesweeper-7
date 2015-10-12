// ----------------------------------------------------------------------
// <copyright file="CommandFactory.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The command factory.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine
{
    using System;
    using Commands;
    
    /// <summary>
    /// The command factory.
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// The engine.
        /// </summary>
        private readonly Engine engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public CommandFactory(Engine engine)
        {
            Validator.Validator.CheckIfNull(engine, nameof(engine));

            this.engine = engine;
        }

        /// <summary>
        /// Create restart command.
        /// </summary>
        /// <returns>The <see cref="Command"/>.</returns>
        public Command CreateRestartCommand()
        {
            return new RestartCommand(this.engine);
        }

        /// <summary>
        /// Create exit command.
        /// </summary>
        /// <returns>The <see cref="Command"/>.</returns>
        public Command CreateExitCommand()
        {
            return new ExitCommand(this.engine);
        }

        /// <summary>
        /// Create move command.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        public Command CreateMoveCommand(int x, int y)
        {
            return new MoveCommand(this.engine, x, y);
        }

        /// <summary>
        /// Create statistic command.
        /// </summary>
        /// <returns>The <see cref="Command"/>.</returns>
        public Command CreateShowStatistiCommand()
        {
            return new ShowStatisticCommand(this.engine);
        }
    }
}
