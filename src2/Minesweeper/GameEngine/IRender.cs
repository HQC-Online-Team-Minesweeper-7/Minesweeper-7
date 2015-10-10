using GameEngine.Statistic;

namespace GameEngine
{
    public interface IRender
    {
        void ShowWelcomeScreen();

        void ShowBoard();

        Command SetCommand();

        void ShowSuccessScreen();

        void ShowFailScreen();

        string SetName();

        void ShowHighScore(IStatistic statistic);
    }
}
