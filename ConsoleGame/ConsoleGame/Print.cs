namespace ConsoleGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Print
    {

        public static void PrintOnPosition(int x, int y, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        public static void PrintHorizontalLine(int x, int y, int length)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i <= length; i++)
            {
                Console.Write("-");
            }
        }

        public static void PrintVerticalLine(int x, int y, int length)
        {

            for (int i = 0; i <= length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("|");
                y++;
            }
        }
    }
}
