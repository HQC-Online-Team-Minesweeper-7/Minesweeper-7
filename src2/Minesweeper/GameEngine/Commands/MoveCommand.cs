namespace GameEngine.Commands
{
    using GameEngine.State;

    internal class MoveCommand : Command
    {
        public readonly int X;
        public readonly int Y;

        public MoveCommand(Engine engine, int x, int y)
            : base(engine)
        {
            this.X = x;
            this.Y = y;

            base.Engine.State = new MoveState(base.Engine, this.X, this.Y);
        }
    }
}
