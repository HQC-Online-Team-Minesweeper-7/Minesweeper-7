// ----------------------------------------------------------------------
// <copyright file="Field.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The console field.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Board.Field
{
    using System;
    using Validator;

    /// <summary>
    /// The console field.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// The constants.
        /// </summary>
        public const int MineContent = -1;
        private int content;
        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="content">The field content.</param>
        public Field(int content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Gets a value indicating whether is content.
        /// </summary>
        /// <value>The content.</value>
        public int Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                Validator.CheckIfFieldContentValueIsValid(value,
                    String.Format(nameof(value), "content is invalid"));

                this.content = value;
            }
        }

        public bool IsMine
        {
            get
            {
                return this.Content == MineContent;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is view.
        /// </summary>
        /// <value>The view...</value>
        public bool IsView { get; set; }
    }
}
