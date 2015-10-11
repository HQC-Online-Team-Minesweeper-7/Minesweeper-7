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
            var render = Engine.Render;
            render.ShowBoard(Engine.Board);
            render.ShowFailScreen(Engine.CountOfMove);

            if (Engine.CountOfMove > 0)
            {
                var name = render.SetName();
                var player = Engine.StatisticFactory.CreatePlayer(name, Engine.CountOfMove);
                var statistic = Engine.Statistic;
                statistic.Add(player);
                Engine.StatisticStorage.Save(statistic);
                render.ShowHighScore(statistic);
            }

            Engine.State = new StartState(Engine);
            Engine.Play();
        }
    }
}
