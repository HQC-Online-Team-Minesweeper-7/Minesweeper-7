namespace Minesweeper.GameModel.Board.Field
{
    using System.Collections.Generic;

    public class FieldFactory
    {
        private Dictionary<int, Field> Fields = new Dictionary<int, Field>();

        public Field GetField(int content)
        {
            Field field;

            if (!this.Fields.TryGetValue(content, out field))
            {
                field = new Field(content);
                this.Fields.Add(content, field);
            }

            return field;
        }
    }
}
