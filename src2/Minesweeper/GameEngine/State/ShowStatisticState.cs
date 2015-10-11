namespace GameEngine.State
{
    internal class ShowStatisticState : State
    {
        public ShowStatisticState(Engine engine)
            : base(engine)
        {
        }

        public override void Play()
        {
            this.Engine.Render.ShowHighScore(this.Engine.Statistic);
            var command = this.Engine.Render.SetCommand(this.Engine.CommandFactory);
            command.Execute();
        }
    }
}
