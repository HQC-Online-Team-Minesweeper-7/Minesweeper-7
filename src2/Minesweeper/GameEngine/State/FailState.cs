namespace GameEngine.State
{
    using System;

    internal class FailState : State
    {
        public FailState(Engine engine)
            :base(engine)
        {
        }

        public override void Play()
        {
            throw new NotImplementedException();
        }
    }
}
