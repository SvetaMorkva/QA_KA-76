using System;

namespace lab1
{
    public class Node

    {
        /*
            Helper class for DoublyLinkedList class.
        */
        int key;
        internal Node prev;
        internal Node next;

        public Node(int key)
        {
            this.key = key;
            this.prev = null;
            this.next = null;
        }

        public int getKey()
        {
            return this.key;
        }

        public Node getNext()
        {
            return this.next;
        }

        public Node getPrev()
        {
            return this.prev;
        }
        public void print()
        {
            Console.WriteLine(this.getKey());
        }
    }

    public class DoublyLinkedList
    {
        internal Node head;
        public DoublyLinkedList(int key)
        {
            Node node = new Node(key);
            this.head = node;
        }
   
        public void Add(int key)
        {
            /*
                Add element to the head of the doubly linked list.
            */
            Node node = new Node(key);
            node.prev = this.head;
            this.head.next = node;
            this.head = node;
        }

        public Node GetCurrent(int key)
        {
            /*
                Get the element with a given key.
            */
            Node h = this.head;
            while(h != null && h.getKey() != key)
            {
                h = h.prev;
                Console.WriteLine(h == null);
            }
            return h;
        }

        public Node getHead()
        {
            return this.head;
        }
    }
}
