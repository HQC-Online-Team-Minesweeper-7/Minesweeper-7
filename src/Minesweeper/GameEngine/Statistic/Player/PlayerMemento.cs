// ----------------------------------------------------------------------
// <copyright file="PlayerMemento.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The player memento.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic.Player
{
    /// <summary>
    /// The player memento.
    /// </summary>
    public class PlayerMemento
    {
        /// <summary>
        /// The name...
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The score.
        /// </summary>
        public readonly int Score;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerMemento"/> class.
        /// </summary>
        /// <param name="name">The name...</param>
        /// <param name="score">The score.</param>
        public PlayerMemento(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}
