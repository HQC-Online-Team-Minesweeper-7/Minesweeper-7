namespace Minesweeper.GameModel.Interfaces
{
    using System;

    internal interface IPlayer: IComparable
    {
        string Name { get; set; }

        int Score { get; set; }
    }
}