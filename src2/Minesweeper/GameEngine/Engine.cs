using GameEngine.Board;
using GameEngine.State;
using System;

namespace GameEngine
{
    public class Engine
    {
        internal State.State State;

        public Engine(IRender render)
        {
            if(render == null)
            {
                throw new ArgumentNullException("render");
            }

            State = new StartState(this);
        }
    }
}
