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
            var field = board[this.X, this.Y];
            field.IsView = true;

            if (field.IsMine)
            {
                this.Engine.State = new FailState(Engine);
                this.Engine.State.Play();
            }
            else if(board.IsAllView)
            {
                this.Engine.State = new SuccessState(Engine);
                this.Engine.State.Play();
            }
            else
            {
                this.Engine.Render.ShowBoard(this.Engine.Board);
                this.Engine.Render.SetCommand(this.Engine.CommandFactory);
            }
        }
    }
}
