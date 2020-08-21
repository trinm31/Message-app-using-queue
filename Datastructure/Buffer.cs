using System;

namespace Datastructure
{
    internal class Buffer
    {
        private FixedQueue messageBuffer; 
        public Buffer()  
        {  
            messageBuffer = new FixedQueue(10);  
        }  
        public void SendMessage(string m)
        {
            while (m.Length >= 1)
            {
                string sub1;
                if (m.Length < 10 )
                {
                    messageBuffer.Enqueue(m);
                    m = string.Empty;
                    break;
                }
                sub1 = m.Substring(0, 10);
                messageBuffer.Enqueue(sub1);
                string sub2 = m.Substring(10);
                m = sub2;
                if (m.Length < 10)
                {
                    messageBuffer.Enqueue(sub2);
                    m = string.Empty;
                }
            }
        }

        
        public void ReceiveMessage()
        {
            string s2 = "";
            while (messageBuffer.Count != 0)
            {
                string output = messageBuffer.Dequeue();
                s2 += output;
                if (messageBuffer.Count == 0)
                {
                    break;
                }
            }
            Console.WriteLine(s2);  
        }  
        
    }
}