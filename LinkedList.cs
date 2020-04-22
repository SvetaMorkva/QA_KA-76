using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    public class Item<T>
    {
        public T Data { get; set; }
        public Item<T> Next { get; set; }

        public Item(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            Data = data;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private Item<T> _head = null;
        private Item<T> _tail = null;
        private int _count = 0;

        public int Count
        {
            get => _count;
        }

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var item = new Item<T>(data);
            if (_head == null)
            {
                _head = item;
            }
            else
            {
                _tail.Next = item;
            }

            _tail = item;
            _count++;
        }

        public T GetCurrent(int current_idx)
        {
            if (current_idx < 0)
            {
                throw new ArgumentException("Bad index!");
            }

            Item<T> current = _head;

            if (current_idx == 0)
            {
                return current.Data;
            }

            for (int i = 0; i < current_idx && current != null; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                throw new ArgumentException("Index does not exist!");
            }

            return current.Data;
        }

        public T GetNext(int next_idx)
        {
            return GetCurrent(++next_idx);
        }

        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var current = _head;

            Item<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                { 
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        _head = _head.Next;

                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }

                    _count--;
                    break;
                }

                previous = current;
                current = current.Next;
            }
        }
        
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }

    /*class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(5);
            list.Add(17);
            list.Add(42);
            list.Add(-69);
            
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
        }
    }*/
}