using Minesweeper.GameModel.Interfaces;
using Minesweeper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.ConsoleGame
{
    class MinesweeperField : IField
    {
        private char[,] field;

        public void Draw(IRenderer renderer)
        {
            throw new NotImplementedException();
        }

        public void GenerateField()
        {
            Random random = new Random();
            int minesToInsert = 15;

            while (minesToInsert > 0)
            {
                for (int i = 0; i < this.field.GetLength(0); i++)
                {
                    if (minesToInsert == 0)
                    {
                        break;
                    }

                    for (int j = 0; j < this.field.GetLength(1); j++)
                    {
                        if (minesToInsert == 0)
                        {
                            break;
                        }

                        int randomNumber = random.Next(0, 3);
                        if (randomNumber == 1)
                        {
                            this.field[i, j] = '*';
                            minesToInsert--;
                        }
                    }
                }
            }

            this.field = MatrixGenerator.GenerateMatrix(this.field, Constants.MinesSymbol);
        }

        public void MakeMove(int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}
