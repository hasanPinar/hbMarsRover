using System;

namespace MarsRover.UI
{
    public static class ConsoleTextColor
    {
        /// <summary>
        /// Red text color 
        /// </summary>
        /// <param name="value">Text</param>
        public static void ErrorText(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Green text color 
        /// </summary>
        /// <param name="value">Text</param>
        public static void InfoText(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// White text color 
        /// </summary>
        /// <param name="value">Text</param>
        public static void NormalText(string value)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
        }

        /// <summary>
        /// DarkYellow text color 
        /// </summary>
        /// <param name="value">Text</param>
        public static void WarningText(string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}