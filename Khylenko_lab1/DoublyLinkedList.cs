using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khylenko_lab1
{
    public class ListNode<T>
    {
        public T Value { get; private set; }
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PreviousNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    public class DoublyLinkedList<T>
    {

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public T GetCurrent(int index)
        {
            if (index < 0)
                throw new ArgumentException("The index is not in the list");

            ListNode<T> current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.NextNode;
            }

            if (current == null)
                throw new ArgumentException("The index is not in the list");

            return current.Value;
        }

        public T GetNext(int index)
        {
            if (index < 0)
                throw new ArgumentException("The index is not in the list");

            ListNode<T> current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.NextNode;
            }

            if (current == null || current == tail)
                throw new ArgumentException("The index is not in the list");

            return current.NextNode.Value;
        }

        public T GetPrev(int index)
        {
            if (index < 1)
                throw new ArgumentException("The index is not in the list");

            ListNode<T> current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.NextNode;
            }

            if (current == null)
                throw new ArgumentException("The index is not in the list");

            return current.PreviousNode.Value;
        }

    }

}
