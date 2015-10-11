// ----------------------------------------------------------------------
// <copyright file="IField.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The field interface.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board.Field
{
    /// <summary>
    /// The field interface.
    /// </summary>
    public interface IField
    {
        /// <summary>
        /// Gets a value indicating whether is content.
        /// </summary>
        /// <value>Get the content.</value>
        int Content { get; }

        /// <summary>
        /// Gets a value indicating whether is mine.
        /// </summary>
        /// <value>Get the mine.</value>
        bool IsMine { get; }

        /// <summary>
        /// Gets a value indicating whether is view.
        /// </summary>
        /// <value>Get the view.</value>
        bool IsView { get; }
    }
}
