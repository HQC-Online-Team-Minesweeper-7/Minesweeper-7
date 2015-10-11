namespace GameEngine.Commands
{
    using GameEngine.State;

    internal class ShowStatisticCommand : Command
    {
        public ShowStatisticCommand(Engine engine)
            : base(engine)
        {
            Engine.State = new ShowStatisticState(Engine);
            Engine.Play();
        }
    }
}
