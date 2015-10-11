// ----------------------------------------------------------------------
// <copyright file="IRender.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The IRender.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine
{
    using GameEngine.Board;
    using GameEngine.Commands;
    using GameEngine.Statistic;

    /// <summary>
    /// The IRender.
    /// </summary>
    public interface IRender
    {
        /// <summary>
        /// The welcome screen.
        /// </summary>
        void ShowWelcomeScreen();

        /// <summary>
        /// The show board.
        /// </summary>
        /// <param name="board">The board.</param>
        void ShowBoard(IBoard board);

        /// <summary>
        /// The set command.
        /// </summary>
        /// <param name="commandFactory">The commandFactory.</param>
        /// <returns>The <see cref="Command"/>.</returns>
        Command SetCommand(CommandFactory commandFactory);

        /// <summary>
        /// Show invalid move message.
        /// </summary>
        void ShowInvalidMoveMessage();

        /// <summary>
        /// Show success screen.
        /// </summary>
        void ShowSuccessScreen();

        /// <summary>
        /// Show fail screen.
        /// </summary>
        /// <param name="countOfOpenField">The countOfOpenField.</param>
        void ShowFailScreen(int countOfOpenField);

        /// <summary>
        /// Set name...
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        string SetName();

        /// <summary>
        /// Show high score.
        /// </summary>
        /// <param name="statistic">The statistic.</param>
        void ShowHighScore(IStatistic statistic);

        /// <summary>
        /// The exit...
        /// </summary>
        void Exit();
    }
}
