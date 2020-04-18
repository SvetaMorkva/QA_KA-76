using System.Collections.Generic;

namespace Lab1
{
    public class MyQueue<T>
    {
        private List<T> Queue = new List<T>();
        public int Count = 0;

        public void Enqueue(T item)
        {
            Queue.Add(item);
        }
        
        public T Dequeue()
        {
            if (Count == 0)
            {
                return default(T);
            }
            else
            {
                Count--;
                T lastValue = Queue[Queue.Count];
                Queue.RemoveAt(Queue.Count - 1);
                return lastValue;
            }
        }

        public T Peek()
        {
            if (Count == 0)
            {
                return default(T);
            }
            else
            {
                return Queue[Count];
            }
        }

        public void Clear()
        {
            Queue.Clear();
            Count = 0;
        }
    }
}