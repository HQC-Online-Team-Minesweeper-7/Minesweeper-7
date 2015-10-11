namespace GameEngine.Board
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;

    using Field;

    public class Board : IBoard
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        private BoardRow[] rows;

        public Board(int rowCount, int columnCount)
        {
            if (rowCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rowCount));
            }

            if (columnCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(columnCount));
            }

            this.RowCount = rowCount;
            this.ColumnCount = columnCount;

            this.rows = new BoardRow[this.RowCount];

            for (int i = 0; i < this.RowCount; i++)
            {
                this.rows[i] = new BoardRow(this.ColumnCount);
            }
        }

        public bool IsAllView
        {
            get
            {
                return this.rows.All(row => row.All(field => field.IsView));
            }
        }

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

        public bool IsCorrectPosition(int x, int y)
        {
            if (x < 0 || this.ColumnCount - 1 < x)
            {
                return false;
            }

            if (y < 0 || this.ColumnCount - 1 < y)
            {
                return false;
            }

            return true;
        }

        public IEnumerator<IBoardRow> GetEnumerator()
        {
            foreach (var row in this.rows)
            {
                yield return row;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
