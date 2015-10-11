namespace GameEngine.Board.Field
{
    using System;

    public class FieldWrapper : IField
    {
        public readonly Field Field;

        public FieldWrapper(Field field)
        {
            if(field == null)
            {
                throw new ArgumentNullException("field");
            }

            this.Field = field;
            this.IsView = false;
        }

        public int Content
        {
            get
            {
                return this.Field.Content;
            }
        }

        public bool IsMine
        {
            get
            {
                return this.Field.IsMine;
            }
        }

        public bool IsView { get; set; }
    }
}
