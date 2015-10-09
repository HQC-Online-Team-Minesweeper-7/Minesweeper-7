namespace Minesweeper.GameModel.Board
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using GameEngine.Board;

    public class Board : IEnumerable<Field.Field>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        private BoardRow[] rows;

        public Board(int rowCount, int columnCount)
        {
            if (rowCount < 1)
            {
                throw new ArgumentOutOfRangeException("rowCount");
            }

            if (columnCount < 1)
            {
                throw new ArgumentOutOfRangeException("columnCount");
            }

            this.RowCount = rowCount;
            this.ColumnCount = columnCount;

            this.rows = new BoardRow[this.RowCount];

            for (int i = 0; i < this.RowCount; i++)
            {
                this.rows[i] = new BoardRow(this.ColumnCount);
            }
        }

        public Field.Field this[int row, int column]
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

        public IEnumerator<Field.Field> GetEnumerator()
        {
            foreach (var row in this.rows)
            {
                foreach (var field in row)
                {
                    yield return field;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
