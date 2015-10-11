namespace GameEngine.Commands
{
    using GameEngine.State;

    internal class ExitCommand : Command
    {
        public ExitCommand(Engine engine)
            : base(engine)
        {
            Engine.State = new ExitState(Engine);
        }
    }
}
