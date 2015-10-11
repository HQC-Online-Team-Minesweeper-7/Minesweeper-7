namespace GameEngine.Statistic.Player
{
    public class PlayerMemento
    {
        public readonly string Name;
        public readonly int Score;

        public PlayerMemento(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}
