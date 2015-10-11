namespace GameEngine.Statistic.Player
{
    public interface IPlayer
    {
        string Name { get; }

        int Score { get; set; }

        PlayerMemento StoreToMemento();

        void RestoreFromMemento(PlayerMemento memento);
    }
}
