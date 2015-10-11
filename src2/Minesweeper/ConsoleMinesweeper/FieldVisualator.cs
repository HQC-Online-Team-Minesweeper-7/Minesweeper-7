namespace ConsoleMinesweeper
{
    using System;
    using System.Collections.Generic;

    public class FieldVisualator
    {
        private Dictionary<int, string> fields = new Dictionary<int, string>();

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
