using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Utils
{
    static class MinesGenerator
    {
        public static char[,] GenerateMinesweeperInMatrix(char[,] matrix,  char minesSimbol)
        {            

            Random random = new Random();
            int minesToInsert = Constants.MinesToInsert;

            while (minesToInsert > 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (minesToInsert == 0)
                    {
                        break;
                    }

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (minesToInsert == 0)
                        {
                            break;
                        }

                        int randomNumber = random.Next(0, 3);
                        if (randomNumber == 1)
                        {
                            matrix[i, j] = Constants.MinesSymbol;
                            minesToInsert--;
                        }
                    }
                }
            }

            return matrix;
        }
    }
}
