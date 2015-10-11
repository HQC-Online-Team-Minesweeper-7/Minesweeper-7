// ----------------------------------------------------------------------
// <copyright file="IBoard.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The board interface.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board
{
    using System.Collections.Generic;

    /// <summary>
    /// The board interface.
    /// </summary>
    public interface IBoard : IEnumerable<IBoardRow>
    {
    }
}
