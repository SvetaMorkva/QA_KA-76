using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class SingleLinkedList<T>
    {
        internal Node<T> head;
        internal int len;
        public SingleLinkedList(T data)
        {
            head = new Node<T>(data);
            len = 1; 
        }

        public void Add(T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            new_node.next = head;
            head = new_node;
            len += 1;
        }
        public T GetCurrent(int index){
            if (index >= len || index < 0 )
                throw new ArgumentException("The index is not in the list");

            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.next;

            return current.data;
        }
        public T GetNext(int index) { return GetCurrent(++index); }
        public int Length() { return len; }
    }
    internal class Node<T>
    {
        internal T data;
        internal Node<T> next;
        internal Node(T d)
        {
            data = d;
            next = null;
        }

    }
}
