﻿// ----------------------------------------------------------------------
// <copyright file="Command.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The commands.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Commands
{
    using System;
    using Validator;
    /// <summary>
    /// The commands.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// The engine.
        /// </summary>
        public Engine Engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public Command(Engine engine)
        {
            Validator.CheckIfNull(engine, nameof(engine));

            this.Engine = engine;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        internal void Execute()
        {
            this.Engine.Play();
        }
    }
}
