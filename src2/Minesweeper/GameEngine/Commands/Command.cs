namespace GameEngine.Commands
{
    using System;

    public abstract class Command
    {
        public Engine Engine;

        public Command(Engine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            this.Engine = engine;
        }

        internal void Execute()
        {
            this.Engine.Play();
        }
    }
}
