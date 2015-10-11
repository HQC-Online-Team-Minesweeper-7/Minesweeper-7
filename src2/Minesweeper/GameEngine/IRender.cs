namespace GameEngine
{
    using GameEngine.Board;
    using GameEngine.Commands;
    using GameEngine.Statistic;

    public interface IRender
    {
        void ShowWelcomeScreen();

        void ShowBoard(IBoard board);

        Command SetCommand(CommandFactory commandFactory);

        void ShowInvalidMoveMessage();

        void ShowSuccessScreen();

        void ShowFailScreen(int countOfOpenField);

        string SetName();

        void ShowHighScore(IStatistic statistic);

        void Exit();
    }
}
