using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public class MyStack<T>
    {
        private T[] items;
        private int count;
        const int n = 10;

        public MyStack()
        {
            count = 0;
            items = new T[n];
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public int Count
        {
            get { return count; }
        }

        public T Peek()
        {
            return items[count - 1];
        }

        public void Push(T item)
        {

            if (count == items.Length) Array.Resize(ref items, items.Length + 10);

            items[count++] = item;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The Stack is empty");
            T item = items[--count];
            items[count] = default(T); 
            return item;
        }
        

    }
}
