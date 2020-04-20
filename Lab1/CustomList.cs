using System;
namespace Lab1
{
    public class CustomList<T>
    {

        public CustomList()
        {
            Length = 0;
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.Head == null)
            {
                Head = newNode;
                return;
            }

            Node<T> lastNode = LastNode();
            lastNode.Next = newNode;
            Length++;
        }

        public T GetCurrent(int index)
        {
            if (index < 0 || index > Length)
            {
                Console.WriteLine("ERROR: Invalid index");
                return default;
            }

            Node<T> current = Head;
            for (int i = 0; i <= Length; i++)
            {
                if (i == index)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            Console.WriteLine("WARNING: return default");
            return default;
        }

        public T GetNext(int index)
        {
            return GetCurrent(++index);
        }


        private Node<T> LastNode()
        {
            Node<T> iterator = this.Head;
            while (iterator.Next != null)
            {
                iterator = iterator.Next;
            }
            return iterator;
        }

        public int Length { get; set; }
        private Node<T> Head = null;
    }

    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Next = null;
        public T Value { get; }
    }
}
