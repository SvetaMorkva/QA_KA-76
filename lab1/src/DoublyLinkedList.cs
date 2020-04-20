using System;

namespace lab1
{
    public class Node

    {
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

        public bool hasNext()
        {
            if(this.next == null)
            {
                return false;
            }
            return true;
        }

        public bool hasPrev()
        {
            if(this.prev == null)
            {
                return false;
            }
            return true;
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
            Node node = new Node(key);
            node.prev = this.head;
            this.head.next = node;
            this.head = node;
            Console.WriteLine("Element added");
        }

        public Node GetCurrent(int key)
        {
            Node h = this.head;
            while(h != null && h.getKey() != key)
            {
                h = h.prev;
                Console.WriteLine(h == null);
            }
            Console.WriteLine("Current element returned");
            return h;
        }

        public Node getHead()
        {
            return this.head;
        }

        public void print()
        {
           
        }
    }
}
