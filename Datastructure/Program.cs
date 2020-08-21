using System;

namespace Datastructure 
{
    class Messenger  
    {  
        static void Main(string[] args)  
        {
            try
            {
                Buffer buf = new Buffer();
                Console.WriteLine("Input your message: ");
                string input = Console.ReadLine();
                if (input.Length == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(FixedQueue), "No input message");
                }
                buf.SendMessage(input);
                Console.WriteLine("Message received: ");
                buf.ReceiveMessage();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.ReadLine();
        }  
    }  
}