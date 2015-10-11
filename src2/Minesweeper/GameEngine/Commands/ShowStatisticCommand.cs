// ----------------------------------------------------------------------
// <copyright file="ShowStatisticCommand.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The statistic command.
// </summary>
// ----------------------------------------------------------------------

namespace GameEngine.Commands
{
    using GameEngine.State;

    /// <summary>
    /// The statistic command.
    /// </summary>
    internal class ShowStatisticCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowStatisticCommand"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public ShowStatisticCommand(Engine engine)
            : base(engine)
        {
            Engine.State = new ShowStatisticState(Engine);
            Engine.Play();
        }
    }
}
