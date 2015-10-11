using System;

namespace GameEngine.State
{
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
                    base.Engine.State = new FailState(Engine);
                    base.Engine.Play();
                }
                else if (board.IsAllView)
                {
                    base.Engine.State = new SuccessState(Engine);
                    base.Engine.Play();
                }
            }
            else
            {
                render.ShowInvalidMoveMessage();
            }

            base.Engine.CountOfMove++;
            render.ShowBoard(this.Engine.Board);
            var command = render.SetCommand(this.Engine.CommandFactory);
            command.Execute();
        }
    }
}
