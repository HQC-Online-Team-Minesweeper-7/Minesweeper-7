// ----------------------------------------------------------------------
// <copyright file="BoardRow.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The board row.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board
{
    using System;

    using System.Collections;
    using System.Collections.Generic;

    using Field;

    /// <summary>
    /// The board row.
    /// </summary>
    public class BoardRow : IBoardRow
    {
        /// <summary>
        /// The count of columns.
        /// </summary>
        public readonly int CountOfColumn;

        /// <summary>
        /// The field wrapper row. 
        /// </summary>
        private FieldWrapper[] row;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardRow"/> class.
        /// </summary>
        /// <param name="countOfColumn">The count of column.</param>
        public BoardRow(int countOfColumn)
        {
            if (countOfColumn < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(countOfColumn), "count of column is invalid");
            }

            this.CountOfColumn = countOfColumn;
            this.row = new FieldWrapper[this.CountOfColumn];
        }

        /// <summary>
        /// The field wrapper.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns>The <see cref="FieldWrapper"/>.</returns>
        public FieldWrapper this[int column]
        {
            get
            {
                return this.row[column];
            }

            set
            {
                this.row[column] = value;
            }
        }

        /// <summary>
        /// The IEnumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        public IEnumerator<IField> GetEnumerator()
        {
            foreach (var field in this.row)
            {
                yield return field;
            }
        }

        /// <summary>
        /// The IEnumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
