namespace GameEngine.Board.Field
{
    using System.Collections.Generic;

    public class FieldFactory
    {
        private Dictionary<int, Field> Fields = new Dictionary<int, Field>();

        public FieldWrapper GetField(int content)
        {
            Field field;

            if (!this.Fields.TryGetValue(content, out field))
            {
                field = new Field(content);

                this.Fields.Add(content, field);
            }

            return new FieldWrapper(field);
        }
    }
}
