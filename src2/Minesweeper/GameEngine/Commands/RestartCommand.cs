namespace GameEngine.Commands
{
    using System;
    using State;

    internal class RestartCommand : Command
    {
        public RestartCommand(Engine engine)
            : base(engine)
        {
            Engine.State = new StartState(Engine);
        }
    }
}
