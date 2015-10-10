namespace GameEngine.State
{
    using System;

    internal class StartState : State
    {
        public StartState(Engine engine)
            :base(engine)
        {
        }

        public override void NextMove()
        {
            throw new NotImplementedException();
        }
    }
}
