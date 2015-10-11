namespace GameEngine.State
{
    using Board;
    using System;

    internal class StartState : State
    {
        public StartState(Engine engine)
            :base(engine)
        {
            base.Engine.CountOfMove = 0;
        }

        public override void Play()
        {
            this.Engine.Render.ShowWelcomeScreen();
            BoardBuilder boardBuilder = new BoardBuilder(this.Engine.RowCount, this.Engine.ColumnCount);
            this.Engine.Board = boardBuilder.Generate(this.Engine.MineCount);
            this.Engine.Render.ShowBoard(this.Engine.Board);
            var command = this.Engine.Render.SetCommand(this.Engine.CommandFactory);
            command.Execute();
        }
    }
}
