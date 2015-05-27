using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    static class Extensions
    {
        public static void PrintLetters(this string str, int timeOut, ConsoleColor foreground = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            foreach (char ch in str)
            {
                Console.Write(ch);
                System.Threading.Thread.Sleep(timeOut);
            }
        }
    }
}
