namespace GameEngine.State
{
    internal class SuccessState : State
    {
        public SuccessState(Engine engine)
            : base(engine)
        {
        }

        public override void Play()
        {
            var render = Engine.Render;

            render.ShowSuccessScreen();
            var name = render.SetName();
            var player = Engine.StatisticFactory.CreatePlayer(name, Engine.CountOfMove);
            var statistic = Engine.Statistic;
            statistic.Add(player);
            Engine.StatisticStorage.Save(statistic);
            render.ShowHighScore(statistic);

            Engine.State = new StartState(Engine);
            Engine.Play();
        }
    }
}
