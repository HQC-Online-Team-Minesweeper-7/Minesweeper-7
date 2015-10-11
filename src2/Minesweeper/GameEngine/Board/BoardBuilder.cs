using GameEngine.Board.Field;
using System;

namespace GameEngine.Board
{
    public class BoardBuilder
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        private Board Board;

        public BoardBuilder(int rowCount, int columnCount)
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
            if (mineCount < 1 || this.ColumnCount * this.RowCount < mineCount)
            {
                throw new ArgumentException("invalid mine count");
            }

            FieldFactory fieldFactory = new FieldFactory();
            int countOfPlacedMine = 0;
            Random chanceToMine = new Random();

            while (mineCount > countOfPlacedMine)
            {
                for (int rowIndex = 0; rowIndex < this.RowCount; rowIndex++)
                {
                    if (countOfPlacedMine == mineCount)
                    {
                        break;
                    }

                    for (int columnIndex = 0; columnIndex < this.ColumnCount; columnIndex++)
                    {
                        if (countOfPlacedMine == mineCount)
                        {
                            break;
                        }

                        int randomNumber = chanceToMine.Next(0, 2);
                        if (randomNumber == 1)
                        {
                            this.Board[rowIndex, columnIndex] = fieldFactory.GetField(Field.Field.MINE_CONTENT);
                            countOfPlacedMine++;
                        }
                    }
                }
            }

            for (int rowIndex = 0; rowIndex < this.RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.ColumnCount; columnIndex++)
                {
                    if (this.Board[rowIndex, columnIndex] != null)
                    {
                        continue;
                    }

                    int neighbourMinesCount = GetNeighbourMinesCount(rowIndex, columnIndex);
                    this.Board[rowIndex, columnIndex] = fieldFactory.GetField(neighbourMinesCount);
                }
            }

            return this.Board;
        }

        private int GetNeighbourMinesCount(int row, int col)
        {
            int minesCount = 0;
            int[] rowPositions = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] colPositions = { -1, 0, 1, 1, 1, 0, -1, -1 };

            for (int position = 0; position < 8; position++)
            {
                int currentNeighbourRow = row + rowPositions[position];
                int currentNeighbourCol = col + colPositions[position];

                if (currentNeighbourRow < 0 || currentNeighbourRow >= this.RowCount || currentNeighbourCol < 0 || currentNeighbourCol >= this.ColumnCount)
                {
                    continue;
                }

                var field = this.Board[currentNeighbourRow, currentNeighbourCol];

                if (field != null && field.IsMine)
                {
                    minesCount++;
                }
            }

            return minesCount;
        }
    }
}
