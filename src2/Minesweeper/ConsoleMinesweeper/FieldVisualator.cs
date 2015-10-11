// ----------------------------------------------------------------------
// <copyright file="FieldVisualator.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The console render Singleton.
// </summary>
// ----------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The field visualizer.
    /// </summary>
    public class FieldVisualator
    {
        /// <summary>
        /// The fields.
        /// </summary>
        private Dictionary<int, string> fields = new Dictionary<int, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldVisualator"/> class.
        /// </summary>
        public FieldVisualator()
        {
            this.fields.Add(-1, "*");
            this.fields.Add(0, "0");
            this.fields.Add(1, "1");
            this.fields.Add(2, "2");
            this.fields.Add(3, "3");
            this.fields.Add(4, "4");
            this.fields.Add(5, "5");
            this.fields.Add(6, "6");
            this.fields.Add(7, "7");
            this.fields.Add(8, "8");
        }

        /// <summary>
        /// Gets UI elements.
        /// </summary>
        /// <param name="content">Gets symbols.</param>
        /// <returns> The <see cref="string"/>.</returns>
        public string GetUIElement(int content)
        {
            string symbol;

            if (!this.fields.TryGetValue(content, out symbol))
            {
                throw new NotSupportedException(content.ToString());
            }

            return symbol;
        }
    }
}
