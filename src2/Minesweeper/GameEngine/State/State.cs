namespace GameEngine.State
{
    using System;

    internal abstract class State
    {
        public readonly Engine Engine;

        public State(Engine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            this.Engine = engine;
        }

        public abstract void Play();
    }
}
