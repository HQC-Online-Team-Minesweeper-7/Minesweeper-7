namespace GameEngine.Board.Field
{
    using System;

    public class Field
    {
        public const int MineContent = -1;

        public Field(int content)
        {
            if (content < MineContent || 8 < content)
            {
                throw new ArgumentOutOfRangeException(nameof(content), "content is invalid");
            }

            this.Content = content;
        }

        public int Content { get; private set; }

        public bool IsMine
        {
            get
            {
                return this.Content == MineContent;
            }
        }

        public bool IsView { get; set; }
    }
}
