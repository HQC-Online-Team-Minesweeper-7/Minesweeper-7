namespace GameEngine.Board.Field
{
    using System;

    public class Field
    {
        public const int MINE_CONTENT = -1;

        public Field(int content)
        {
            if (content < MINE_CONTENT || 8 < content)
            {
                throw  new ArgumentOutOfRangeException("content is invalid");
            }

            this.Content = content;
        }

        public int Content { get; private set; }

        public bool IsMine
        {
            get
            {
                return Content == MINE_CONTENT;
            }
        }
    }
}
