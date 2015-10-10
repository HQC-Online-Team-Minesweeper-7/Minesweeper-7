namespace GameEngine.Board
{
    using Field;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BoardRow : IBoardRow
    {
        public readonly int CountOfColumn;

        private FieldWrapper[] row;

        public BoardRow(int countOfColumn)
        {
            if (countOfColumn < 1)
            {
                throw new ArgumentOutOfRangeException("count of column is invalid");
            }

            this.CountOfColumn = countOfColumn;
            this.row = new FieldWrapper[this.CountOfColumn];
        }

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

        public IEnumerator<IField> GetEnumerator()
        {
            foreach (var field in this.row)
            {
                yield return field;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
