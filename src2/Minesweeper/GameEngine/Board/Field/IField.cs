namespace GameEngine.Board.Field
{
    public interface IField
    {
        int Content { get; }

        bool IsMine { get; }

        bool IsView { get; }
    }
}
