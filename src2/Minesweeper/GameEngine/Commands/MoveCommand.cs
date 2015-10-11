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

            Engine.State = new MoveState(Engine, this.X, this.Y);
        }
    }
}
