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
            var render = base.Engine.Render;

            render.ShowSuccessScreen();
            var name = render.SetName();
            var player = base.Engine.StatisticFactory.CreatePlayer(name, base.Engine.CountOfMove);
            var statistic = base.Engine.Statistic;
            statistic.Add(player);
            base.Engine.StatisticStorage.Save(statistic);
            render.ShowHighScore(statistic);

            base.Engine.State = new StartState(base.Engine);
            base.Engine.Play();
        }
    }
}
