using System;


namespace SendMessageSimple
{
    internal class Program
    {
        public class Queue<T>
        {
            private class Node {
                public T data;
                public Node(T data) {
                    this.data = data;
                }
                public Node() {

                }
            }
            Node[] nodes;
            int current;
            int emptySpot;
            public int Size;

            public Queue(int size) {
                nodes = new Node[size];
                for (int i = 0; i < size; i++) {
                    nodes[i] = new Node();
                }
                this.current = 0;
                this.emptySpot = 0;
                Size = size;
            }

            public void Enqueue(T value){
                nodes[emptySpot].data = value;
                emptySpot++;
                if (emptySpot >= nodes.Length) {
                    emptySpot = 0;
                }
            }
            public T Dequeue() {
                int ret = current;
                current++;
                if (current >= nodes.Length) {
                    current = 0;
                }
                return nodes[ret].data;
            }
            public int count()
            {
                return emptySpot;
            }
        }
        public class Buffer
        {
            private Queue<string> messageBuffer; 
            public Buffer()  
            {  
                messageBuffer = new Queue<string>(250);  
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
                int i = messageBuffer.Size;
                while (messageBuffer.Size != 0)
                {
                    string output = messageBuffer.Dequeue();
                    s2 += output;
                    i--;
                    if (i == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine(s2);  
            }  
        }
        public static void Main(string[] args)
        {
            try
            {
                Buffer buf = new Buffer();
                Console.WriteLine("Input your message: ");
                string input = Console.ReadLine();
                if (input.Length == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Queue<string>), "No input message");
                }
                else if (input.Length > 250 )
                {
                    throw new ArgumentOutOfRangeException(nameof(Queue<string>), "Message cannot be more than 250");
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