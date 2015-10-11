namespace GameEngine.State
{
    using System;

    internal class FailState : State
    {
        public FailState(Engine engine)
            : base(engine)
        {
        }

        public override void Play()
        {
            var render = base.Engine.Render;
            render.ShowBoard(base.Engine.Board);
            render.ShowFailScreen(base.Engine.CountOfMove);

            if (base.Engine.CountOfMove > 0)
            {
                var name = render.SetName();
                var player = base.Engine.StatisticFactory.CreatePlayer(name, base.Engine.CountOfMove);
                var statistic = base.Engine.Statistic;
                statistic.Add(player);
                base.Engine.StatisticStorage.Save(statistic);
                render.ShowHighScore(statistic);
            }

            base.Engine.State = new StartState(base.Engine);
            base.Engine.Play();
        }
    }
}
