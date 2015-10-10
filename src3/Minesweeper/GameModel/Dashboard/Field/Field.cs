namespace Minesweeper.GameModel.Board.Field
{
    using System;
    using Utils;

    public class Field
    {
        public const int MineContent = -1;

        public Field(int content)
        {
            if (content < MineContent || Constants.MatrixColumn < content)
            {
                throw new ArgumentOutOfRangeException("Content is invalid - out fo range");
            }

            this.Content = content;
        }

        public int Content { get; private set; }

        public bool IsMine
        {
            get
            {
                return Content == MineContent;
            }
        }
    }
}
