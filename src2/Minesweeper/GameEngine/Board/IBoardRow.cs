using GameEngine.Board.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Board
{
    public interface IBoardRow : IEnumerable<IField>
    {
    }
}
