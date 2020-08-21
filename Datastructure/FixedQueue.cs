using System;
using System.Collections.Generic;

namespace Datastructure
{
    public class FixedQueue: Queue<string>
    {
        public int Limit { get; set; }

        public FixedQueue(int limit) : base(limit)
        {
            Limit = limit;
        }

        public new void Enqueue(string item)
        {
            while (Count >= Limit)
            {
                Dequeue();
                throw new ArgumentOutOfRangeException(nameof(FixedQueue), "Message cannot be more than 250");
            }
            base.Enqueue(item);
        }
        
    }
}