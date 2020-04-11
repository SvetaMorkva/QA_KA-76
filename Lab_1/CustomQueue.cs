using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class CustomQueue<T>: List<T>
    {
        private object SyncRoot = new object();

        public void Enqueue(T item)
        {
            lock (SyncRoot)
                this.Add(item);
        }

        public T Dequeue()
        {
            T item = default(T);

            lock (SyncRoot)
                if (this.Count > 0)
                {
                    item = this[0];
                    this.RemoveAt(0);
                }
            return (item);
        }

        public T Peek()
        {
            T item = default(T);

            lock (SyncRoot)
                if (this.Count > 0)
                    item = this[0];
            return (item);
        }
    }
}
