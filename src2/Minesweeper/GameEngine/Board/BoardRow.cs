namespace GameEngine.Board
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BoardRow : IEnumerable<Field.Field>
    {
        public readonly int CountOfColumn;

        private Field.Field[] row;

        public BoardRow(int countOfColumn)
        {
            if (countOfColumn < 1)
            {
                throw new ArgumentOutOfRangeException("count of column is invalid");
            }

            this.CountOfColumn = countOfColumn;
            this.row = new Field.Field[this.CountOfColumn];
        }

        public Field.Field this[int column]
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

        public IEnumerator<Field.Field> GetEnumerator()
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
