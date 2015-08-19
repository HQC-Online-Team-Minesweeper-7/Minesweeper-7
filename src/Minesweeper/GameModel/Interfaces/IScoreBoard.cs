namespace Minesweeper.GameModel.Interfaces
{
    internal interface IScoreBoard
    {
        string PlayerName { get; set; }

        int Score { get; set; }

        int CompareTo(object obj);
    }
}
