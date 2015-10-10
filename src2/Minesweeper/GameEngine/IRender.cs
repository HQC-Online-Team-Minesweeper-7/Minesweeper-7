using GameEngine.Board;
using GameEngine.Commands;
using GameEngine.Statistic;

namespace GameEngine
{
    public interface IRender
    {
        void ShowWelcomeScreen();

        void ShowBoard(IBoard board);

        Command SetCommand(CommandFactory commandFactory);

        void ShowInvalidMoveMessage();

        void ShowSuccessScreen();

        void ShowFailScreen();

        string SetName();

        void ShowHighScore(IStatistic statistic);

        void Exit();
    }
}
