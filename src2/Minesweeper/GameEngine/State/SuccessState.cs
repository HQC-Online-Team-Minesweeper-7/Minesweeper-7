namespace GameEngine.State
{
    using System;

    internal class SuccessState : State
    {
        public SuccessState(Engine engine)
            :base(engine)
        {
        }

        public override void Play()
        {
            throw new NotImplementedException();
        }
    }
}
