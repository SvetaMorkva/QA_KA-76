using System;
namespace lab1_variant1
{
    public class DoublyLinkedList
    {
        // напишите свою имплементацию двусвязного списка, метод Add, GetCurrent, GetNext, GetPrevious

        private int nodeValue;
        private DoublyLinkedList prev;
        private DoublyLinkedList next;

        public DoublyLinkedList(int data)
        {
            nodeValue = data;
            prev = null;
            next = null;
        }

        public DoublyLinkedList Add(int data)
        {
            DoublyLinkedList newNode = new DoublyLinkedList(data);

            if (this.next == null)
            {
                newNode.prev = this;
                this.next = newNode;

            }

            else
            {
                DoublyLinkedList nextOfThis = this.next;
                newNode.prev = this;
                newNode.next = nextOfThis;
                this.next = newNode;
                nextOfThis.prev = newNode;
            }

            return newNode;
        }

        public int Value => nodeValue;
        public DoublyLinkedList GetCurrent => this;
        public DoublyLinkedList GetNext => next;
        public DoublyLinkedList GetPrev => prev;
    }
}
