// ----------------------------------------------------------------------
// <copyright file="FieldFactory.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The field factory.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board.Field
{
    using System.Collections.Generic;

    /// <summary>
    /// The field factory.
    /// </summary>
    public class FieldFactory
    {
        /// <summary>
        /// The fields.
        /// </summary>
        private Dictionary<int, Field> Fields = new Dictionary<int, Field>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldFactory"/> class.
        /// </summary>
        /// <param name="content">The field content.</param>
        /// <returns>The <see cref="FieldWrapper"/>.</returns>
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
