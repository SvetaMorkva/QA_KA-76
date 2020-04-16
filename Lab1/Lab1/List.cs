using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int count { get; set; }
        
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        public T GetCurrent(int index)
        {
            if (index < 0)
                throw new ArgumentException("The index is not in the list");

            Node<T> current = head;

            if (index == 0)
                return current.Data;

            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            if (current == null)
                throw new ArgumentException("The index is not in the list");

            return current.Data;
        }

        public T GetNext(int index)
        {
            return GetCurrent(++index);
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
    }
}
