// ----------------------------------------------------------------------
// <copyright file="IBoardRow.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The board row interface.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board
{
    using System.Collections.Generic;

    using GameEngine.Board.Field;

    /// <summary>
    /// The board row interface.
    /// </summary>
    public interface IBoardRow : IEnumerable<IField>
    {
    }
}
