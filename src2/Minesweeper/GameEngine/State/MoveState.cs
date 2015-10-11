namespace GameEngine.State
{
    using System;

    internal class MoveState : State
    {
        public readonly int X;
        public readonly int Y;

        public MoveState(Engine engine, int x, int y)
            : base(engine)
        {
            this.X = x;
            this.Y = y;
        }

        public override void Play()
        {
            var board = this.Engine.Board;
            var render = this.Engine.Render;

            if (board.IsCorrectPosition(this.X, this.Y))
            {
                var field = board[this.X, this.Y];
                field.IsView = true;

                if (field.IsMine)
                {
                    Engine.State = new FailState(Engine);
                    Engine.Play();
                }
                else if (board.IsAllView)
                {
                    Engine.State = new SuccessState(Engine);
                    Engine.Play();
                }
            }
            else
            {
                render.ShowInvalidMoveMessage();
            }

            Engine.CountOfMove++;
            render.ShowBoard(this.Engine.Board);
            var command = render.SetCommand(this.Engine.CommandFactory);
            command.Execute();
        }
    }
}
