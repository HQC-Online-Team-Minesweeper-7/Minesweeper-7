namespace GameEngine.Validator
{
    using System;

    class Validator
    {
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfFieldContentValueIsValid(int content, string message)
        {
            if (-1 > content || content > 8)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void CheckIfSmallerThanOne(int value, string message)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void CheckIfNullOrWhiteSpace(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("invalid filename");
            }
        }
    }
}
