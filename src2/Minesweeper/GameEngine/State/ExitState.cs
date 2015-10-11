namespace GameEngine.State
{
    using System;

    internal class ExitState : State
    {
        public ExitState(Engine engine)
            : base(engine)
        {
        }

        public override void Play()
        {
            this.Engine.Render.Exit();
        }
    }
}
