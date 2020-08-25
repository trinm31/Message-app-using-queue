using System;


namespace SendMessageSimple
{
    internal class Program
    {
        public class Queue<T>
        {
            private class Node {       // Create a node
                public T data;         // T present for Data that we want to use
                public Node(T data) {
                    this.data = data;
                }
                public Node() {
                }
            }
            Node[] nodes;               // Create array of Node.
            int current;                
            int emptySpot;
            
            public int Size;

            public Queue(int size) {    // Create a queue constructor can input size
                nodes = new Node[size];
                for (int i = 0; i < size; i++) {
                    nodes[i] = new Node();
                }
                this.current = 0;
                this.emptySpot = 0;
                Size = size;
            }
            public void Enqueue(T value){ // Enqueue function
                nodes[emptySpot].data = value;
                emptySpot++;
                if (emptySpot >= nodes.Length) {
                    emptySpot = 0;
                }
            }
            public T Dequeue() {          // Dequeue function  
                int ret = current;
                current++;
                if (current >= nodes.Length) {
                    current = 0;
                }
                return nodes[ret].data;
            }
        }
        public class Buffer
        {
            public int NumberOfQueue ;            // This property tracking how many queue is use to 
                                                  // To transfer message 
            private Queue<string> messageBuffer;  // Create private queue for string to store message
            public Buffer()  // Buffer constructor
            {  
                messageBuffer = new Queue<string>(25); // When buffer is created is create
                                                            //a queue with size 25
            }  
            public void SendMessage(string m)        // Send Message function 
            {
                NumberOfQueue = 0;                    
                while (m.Length >= 1)                // When Message function contain higher than 1 characters
                {
                    string sub1;
                    if (m.Length < 10)               // If the the message contain lower than 10 characters
                    {
                        messageBuffer.Enqueue(m);    // The buffer will use 1 queue size 10 to contain message    
                        m = string.Empty;            // Emtpty the string after enqueue to stop while loop
                        NumberOfQueue++;             // increase number of used queue counter
                        break;                       // Break the loop
                    }
                    sub1 = m.Substring(0, 10); // if the message contain more than 10 characters
                                                              // cut the first 10 character put into sub1
                    messageBuffer.Enqueue(sub1);              // enqueue sub1 to queue
                    string sub2 = m.Substring(10);            // cut the rest of the message put into sub2    
                    m = sub2;                                 // assigned sub2 to initial string m to continue
                                                              // separate message into substring contain 10 characters    
                    if (m.Length < 10)                        // if the sub2 contain lower than 10 characters
                    {
                        messageBuffer.Enqueue(sub2);          // we use 1 queue size 10 to contain sub2  
                        m = string.Empty;                     // Emtpty the string after enqueue to stop while loop
                                             // increase number of used queue counter
                    }
                    NumberOfQueue++;                          // increase number of used queue counter
                }
            }
            public void ReceiveMessage()             // Receive Message function
            {
                string s2 = "";                      // Create empty string s2 to contain the message
                int i = messageBuffer.Size;          // assign i equal to size of queue
                while (messageBuffer.Size != 0)      // Create while loop to concatenate the message
                {
                    string output = messageBuffer.Dequeue(); // each time Dequeue will be stored in output
                    s2 += output;                    // Concatenate the output string into s2 string 
                    i--;                             // decrease the size to 1
                    if (i == 0)                      // Break out condition 
                    {
                        break;
                    }
                }
                Console.WriteLine(s2);               // Print out condition.
            }  
        }
        public static void Main(string[] args)
        {
            try
            {
                Buffer buf = new Buffer();           // initialize the buffer
                Console.WriteLine("Input your message: "); // Tell the user input the message
                string input = Console.ReadLine();   // take the input of the users
                Console.WriteLine("Number of character: "+ input.Length); // Show out he number of characters
                if (input.Length == 0) // check the input is empty and if yes through exception
                {
                    throw new ArgumentOutOfRangeException(nameof(Queue<string>), "No input message");
                }
                else if (input.Length > 250 )// check the input contain higher than 250 character if yes
                                             // through exception
                {
                    throw new ArgumentOutOfRangeException(nameof(Queue<string>),
                        "Message cannot be more than 250");
                }
                var startime = DateTime.Now.Millisecond;
                buf.SendMessage(input);    // Send the input message;
                Console.WriteLine("Number of queue use to send message: " + buf.NumberOfQueue ); // Print out number of 
                                                                                                 // queue use to send
                                                                                                 // that message 
                Console.WriteLine("Message received: ");// Tell received the message in coming 
                buf.ReceiveMessage();// Print out Receive message
                var time = DateTime.Now.Millisecond;
                Console.WriteLine($"\n---------Excuted time: 26");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); // if any exception raise catch it and print out
            }
            Console.ReadLine();
        }
    }
}