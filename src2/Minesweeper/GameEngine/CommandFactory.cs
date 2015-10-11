namespace GameEngine
{
    using System;
    using Commands;

    public class CommandFactory
    {
        private Engine Engine;

        internal CommandFactory(Engine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            this.Engine = engine;
        }

        public Command CreateRestartCommand()
        {
            return new RestartCommand(this.Engine);
        }

        public Command CreateExitCommand()
        {
            return new ExitCommand(this.Engine);
        }

        public Command CreateMoveCommand(int x, int y)
        {
            return new MoveCommand(this.Engine, x, y);
        }

        public Command CreateShowStatistiCommand()
        {
            return new ShowStatisticCommand(this.Engine);
        }
    }
}
