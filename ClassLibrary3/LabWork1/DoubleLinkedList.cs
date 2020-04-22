using System;
namespace ClassLibrary3
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Data = value;
        }
    }

    public class DoubleLinkedList<T>
    {
        private Node<T> Head { get; set; }


        public void Add(T value)
        {
            if (Head == null)
            {
                Node<T> newNode = new Node<T>(value);
                newNode.Next = null;
                newNode.Previous = null;

                Head = newNode;
            }
            else
            {
                Node<T> CurrentNode = Head;
                while (CurrentNode.Next != null)
                {
                    CurrentNode = CurrentNode.Next;
                }
                Node<T> newNode = new Node<T>(value);
                newNode.Next = null;
                newNode.Previous = CurrentNode;
                CurrentNode.Next = newNode;
            }
        }

        public Node<T> GetCurrent(int index)
        {
            if (index < 0)
            {
                throw new Exception("Provide a valid index.");
            }
            Node<T> CurrentNode = Head;
            for (int i = 0; i < index; i++)
            {
                if (CurrentNode.Next != null)
                {
                    CurrentNode = CurrentNode.Next;
                }
                else if ((CurrentNode.Next == null) && (i == index))
                {
                    return CurrentNode;
                }
                else
                {
                    throw new Exception("Provide a valid index.");
                }
            }
            return CurrentNode;
        }
        public Node<T> GetPrevious(int index)
        {
            return GetCurrent(index - 1);
        }
        public Node<T> GetNext(int index)
        {
            return GetCurrent(index + 1);
        }

    }
}