// ----------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The player interface.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic.Player
{
    /// <summary>
    /// The player interface.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets a value indicating whether is name.
        /// </summary>
        /// <value>Get the name.</value>
        string Name { get; }

        /// <summary>
        /// Gets or sets a value indicating whether is score.
        /// </summary>
        /// <value>Get or set score.</value>
        int Score { get; set; }

        /// <summary>
        /// The store to memento.
        /// </summary>
        /// <returns>The <see cref="PlayerMemento"/>.</returns>
        PlayerMemento StoreToMemento();

        /// <summary>
        /// The restore from memento.
        /// </summary>
        /// <param name="memento">The memento.</param>
        void RestoreFromMemento(PlayerMemento memento);
    }
}
