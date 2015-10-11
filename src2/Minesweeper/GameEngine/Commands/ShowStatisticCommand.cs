using GameEngine.State;

namespace GameEngine.Commands
{
    internal class ShowStatisticCommand : Command
    {
        public ShowStatisticCommand(Engine engine)
            :base(engine)
        {
            base.Engine.State = new ShowStatisticState(base.Engine);
            base.Engine.Play();
        }
    }
}
