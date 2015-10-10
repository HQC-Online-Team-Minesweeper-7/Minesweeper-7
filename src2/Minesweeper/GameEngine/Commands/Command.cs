using System;

namespace GameEngine.Commands
{
    public abstract class Command
    {
        public Engine Engine;

        public Command(Engine engine)
        {
            if(engine == null)
            {
                throw new ArgumentNullException("engine");
            }

            this.Engine = engine;
        }

        internal void Execute()
        {
            this.Engine.Play();
        }
    }
}
