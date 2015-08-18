using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameModel.Interfaces
{
    interface IField
    {
        void Draw(IRenderer renderer);

        void GenerateField();

        void MakeMove(int row, int col);
    }
}
