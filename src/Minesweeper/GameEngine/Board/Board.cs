// ----------------------------------------------------------------------
// <copyright file="Board.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The board.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Validator;
    using Field;

    public class Board : IBoard
    {
        public readonly int RowCount;

        public readonly int ColumnCount;

        private BoardRow[] rows;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="rowCount">The row counter.</param>
        /// <param name="columnCount">The column counter.</param>
        public Board(int rowCount, int columnCount)
        {
            Validator.CheckIfSmallerThanOne(rowCount, nameof(rowCount));

            Validator.CheckIfSmallerThanOne(columnCount, nameof(columnCount));

            this.RowCount = rowCount;
            this.ColumnCount = columnCount;

            this.rows = new BoardRow[this.RowCount];

            for (int i = 0; i < this.RowCount; i++)
            {
                this.rows[i] = new BoardRow(this.ColumnCount);
            }
        }

        /// <summary>
        /// Gets a value indicating whether is all view.
        /// </summary>
        /// <value>Get is all view.</value>       
        public bool IsAllView
        {
            get
            {
                return this.rows.All(row => row.All(field => field.IsView));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is field wrapper.
        /// </summary>
        /// <param name="row">The rows...</param>
        /// <param name="column">The columns.</param>
        /// <returns>The <see cref="FieldWrapper"/>.</returns>
        public FieldWrapper this[int row, int column]
        {
            get
            {
                return this.rows[row][column];
            }

            set
            {

                this.rows[row][column] = value;
            }
        }

        /// <summary>
        /// Check the correct position.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <returns>Is correct position <see cref="bool"/>.</returns>
        public bool IsCorrectPosition(int x, int y)
        {
            if (x < 0 || this.ColumnCount - 1 < x)
            {
                return false;
            }

            if (y < 0 || this.RowCount - 1 < y)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The enumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        public IEnumerator<IBoardRow> GetEnumerator()
        {
            foreach (var row in this.rows)
            {
                yield return row;
            }
        }

        /// <summary>
        /// The enumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
