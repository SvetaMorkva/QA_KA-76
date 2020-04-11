using System.Collections.Generic;

namespace Lab_1
{
    // Implements a queue with type T objects
    public class CustomQueue<T>: List<T>
    {
        // is used to get an object that can be used to synchronize access to the Array
        private object SyncRoot = new object();

        // Adds an object to the end of the CustomQueue
        public void Enqueue(T item)
        {
            lock (SyncRoot)
                Add(item);
        }

        // Removes and returns the object at the beginning of the CustomQueue
        public T Dequeue()
        {
            T item = default(T);

            lock (SyncRoot)
                if (Count > 0)
                {
                    item = this[0];
                    RemoveAt(0);
                }
            return (item);
        }

        // Returns the object at the beginning of the CustomQueue without removing it.
        public T Peek()
        {
            T item = default(T);

            lock (SyncRoot)
                if (Count > 0)
                    item = this[0];
            return (item);
        }
    }
}
