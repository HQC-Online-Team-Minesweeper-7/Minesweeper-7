// ----------------------------------------------------------------------
// <copyright file="FieldWrapper.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The field wrapper.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board.Field
{
    using System;

    /// <summary>
    /// The field wrapper.
    /// </summary>
    public class FieldWrapper : IField
    {
        /// <summary>
        /// The field.
        /// </summary>
        public readonly Field Field;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldWrapper"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        public FieldWrapper(Field field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            this.Field = field;
            this.IsView = false;
        }

        /// <summary>
        /// Gets a value indicating whether is content.
        /// </summary>
        /// <value>The content.</value>
        public int Content
        {
            get
            {
                return this.Field.Content;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is mine.
        /// </summary>
        /// <value>Gets the mine.</value>
        public bool IsMine
        {
            get
            {
                return this.Field.IsMine;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is view.
        /// </summary>
        /// <value>The view...</value>
        public bool IsView { get; set; }
    }
}
