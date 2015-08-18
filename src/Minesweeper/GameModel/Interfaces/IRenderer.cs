using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameModel.Interfaces
{
    interface IRenderer
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
