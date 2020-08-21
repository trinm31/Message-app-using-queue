using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            while (input.Length >= 5)
            {
                string sub1 = input.Substring(0, 5);
                Console.WriteLine(sub1);
                string sub2 = input.Substring(5);
                input = sub2;
                if (input.Length < 50)
                {
                    Console.WriteLine(sub2);
                }
            }
        }
    }
}