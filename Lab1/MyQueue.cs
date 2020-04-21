using System.Collections.Generic;

namespace Lab1
{
    public class MyQueue<T>
    {
        private List<T> Queue = new List<T>();
        public int Count = 0;

        public void Enqueue(T item)
        {
            Count++;
            Queue.Insert(Count - 1, item);
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
                T value = Queue[0];
                Queue.RemoveAt(0);
                return value;
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
                return Queue[0];
            }
        }

        public void Clear()
        {
            Queue.Clear();
            Count = 0;
        }
    }
}