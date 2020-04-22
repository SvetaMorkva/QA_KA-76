using System;

namespace lab1
{
    public class Node<T>
    {
        public T item { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T item)
        {
            this.item = item;
        }
    }

    public class DoubleLinkedList<T>
    {
        private Node<T> head { get; set; }
        private Node<T> tail { get; set; }
        private Node<T> current { get; set; }

        public void Add(T item)
        {
            if (head == null)
            {
                head = new Node<T>(item);
                current = head;
            } 
            else if (tail == null)
            {
                tail = new Node<T>(item);
                head.Next = tail;
                tail.Previous = head;
            }
            else
            {
                Node<T> node = new Node<T>(item);
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }
        }

        public T GetCurrent()
        {
            return current.item;
        }
        public T GetPrevious()
        {
            current = current.Previous;
            return current.item;
        }
        public T GetNext()
        {
            current = current.Next;
            return current.item;
        }

    }
}
