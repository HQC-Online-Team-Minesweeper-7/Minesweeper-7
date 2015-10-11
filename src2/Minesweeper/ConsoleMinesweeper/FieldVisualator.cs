namespace ConsoleMinesweeper
{
    using System;
    using System.Collections.Generic;

    public class FieldVisualator
    {
        private Dictionary<int,string> fields =new Dictionary<int, string>(); 

        public FieldVisualator()
        {
            fields.Add(-1, "*");
            fields.Add(0, "0");
            fields.Add(1, "1");
            fields.Add(2, "2");
            fields.Add(3, "3");
            fields.Add(4, "4");
            fields.Add(5, "5");
            fields.Add(6, "6");
            fields.Add(7, "7");
            fields.Add(8, "8");
        }

        public string GetUIElement(int content)
        {
            string symbol;

            if (!this.fields.TryGetValue(content, out symbol))
            {
                throw  new NotSupportedException(content.ToString());
            }

            return symbol;
        }
    }
}
