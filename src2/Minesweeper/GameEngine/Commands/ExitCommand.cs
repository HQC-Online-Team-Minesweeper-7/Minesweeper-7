using GameEngine.State;

namespace GameEngine.Commands
{
    internal class ExitCommand : Command
    {
        public ExitCommand(Engine engine)
            :base(engine)
        {
            base.Engine.State = new ExitState(base.Engine);
        }
    }
}
