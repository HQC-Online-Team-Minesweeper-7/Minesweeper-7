// ----------------------------------------------------------------------
// <copyright file="State.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The state.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.State
{
    using System;

    /// <summary>
    /// The state.
    /// </summary>
    internal abstract class State
    {
        /// <summary>
        /// The engine.
        /// </summary>
        public readonly Engine Engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public State(Engine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            this.Engine = engine;
        }

        /// <summary>
        /// Override the play.
        /// </summary>
        public abstract void Play();
    }
}
