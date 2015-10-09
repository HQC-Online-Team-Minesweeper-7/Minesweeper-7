namespace GameEngine.Board
{
    using System;

    public class BoardGenerator
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        private Board Board;

        public BoardGenerator(int rowCount, int columnCount)
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

            this.Board = new Board(RowCount, ColumnCount);
        }

        public Board Generate(int mineCount)
        {
            if (mineCount > this.ColumnCount * this.RowCount)
            {
                throw new ArgumentException("invalid mine count");
            }

            return this.Board;
        }
    }
}
