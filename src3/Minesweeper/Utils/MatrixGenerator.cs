namespace Minesweeper.Utils
{
    internal class MatrixGenerator
    {
        public static char[,] GenerateMatrix(char[,] matrix, char symbolToSkip)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbolToSkip)
                    {
                        continue;
                    }

                    int neighbourMinesCount = GetNeighbourMinesCount(matrix, i, j);
                    matrix[i, j] = (neighbourMinesCount.ToString()[0]);
                }
            }

            return matrix;
        }

        private static int GetNeighbourMinesCount(char[,] matrix, int row, int col)
        {
            int minesCount = 0;
            int[] rowPositions = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] colPositions = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int currentNeighbourRow = 0;
            int currentNeighbourCol = 0;

            for (int position = 0; position < 8; position++)
            {

                currentNeighbourRow = row + rowPositions[position];

                currentNeighbourCol = col + colPositions[position];


                if (currentNeighbourRow < 0 || currentNeighbourRow >= matrix.GetLength(0) ||
                    currentNeighbourCol < 0 || currentNeighbourCol >= matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[currentNeighbourRow, currentNeighbourCol] == Constants.MinesSymbol)
                {
                    minesCount++;
                }
            }

            return minesCount;
        }
    }
}
