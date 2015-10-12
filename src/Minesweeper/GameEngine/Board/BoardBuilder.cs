// ----------------------------------------------------------------------
// <copyright file="BoardBuilder.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The board builder.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board
{
    using System;

    using GameEngine.Board.Field;

    /// <summary>
    /// The board builder.
    /// </summary>
    public class BoardBuilder
    {
        /// <summary>
        /// The RowCount.
        /// </summary>
        public readonly int RowCount;

        /// <summary>
        /// The ColumnCount.
        /// </summary>
        public readonly int ColumnCount;

        /// <summary>
        /// The board.
        /// </summary>
        private Board board;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardBuilder"/> class.
        /// </summary>
        /// <param name="rowCount">The row counter.</param>
        /// <param name="columnCount">The column counter.</param>
        public BoardBuilder(int rowCount, int columnCount)
        {
            
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;

            this.board = new Board(this.RowCount, this.ColumnCount);
        }

        /// <summary>
        /// The board generator.
        /// </summary>
        /// <param name="mineCount">The mines counter.</param>
        /// <returns>The <see cref="Board"/>.</returns>
        public Board Generate(int mineCount)
        {
            if (mineCount < 1 || this.ColumnCount * this.RowCount < mineCount)
            {
                throw new ArgumentException("invalid mine count");
            }

            var fieldFactory = new FieldFactory();
            int countOfPlacedMine = 0;
            var chanceToMine = new Random();

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
                            this.board[rowIndex, columnIndex] = fieldFactory.GetField(Field.Field.MineContent);
                            countOfPlacedMine++;
                        }
                    }
                }
            }

            for (int rowIndex = 0; rowIndex < this.RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.ColumnCount; columnIndex++)
                {
                    if (this.board[rowIndex, columnIndex] != null)
                    {
                        continue;
                    }

                    int neighbourMinesCount = this.GetNeighbourMinesCount(rowIndex, columnIndex);
                    this.board[rowIndex, columnIndex] = fieldFactory.GetField(neighbourMinesCount);
                }
            }

            return this.board;
        }

        /// <summary>
        /// Count neighbor mines.
        /// </summary>
        /// <param name="row">The rows...</param>
        /// <param name="col">The columns.</param>
        /// <returns>The <see cref="Board"/>.</returns>
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

                var field = this.board[currentNeighbourRow, currentNeighbourCol];

                if (field != null && field.IsMine)
                {
                    minesCount++;
                }
            }

            return minesCount;
        }
    }
}
