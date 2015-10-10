using System;

namespace GameEngine
{
    public abstract class Command
    {
        public readonly Engine Engine;

        public Command(Engine engine)
        {
            if(engine == null)
            {
                throw new ArgumentException("engine");
            }

            Engine = engine;
        }

        public abstract void Execute();
    }
}
