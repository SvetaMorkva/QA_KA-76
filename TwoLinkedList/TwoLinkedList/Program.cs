using System;

namespace TwoLinkedList
{
    class Node<T> : ICloneable
    {
        private T _element;
        private Node<T> _next;
        private Node<T> _previous;

        public T Element
        {
            get => _element;
            set => _element = value;
        }
        public Node<T> Previous
        {
            get => _previous;
            set => _previous = value;
        }
        public Node<T> Next
        {
            get => _next;
            set => _next = value;
        }

        public Node()
        {
            this._next = null;
            this._previous = null;
        }
        public Node (T elm)
        {
            this._element = elm;
            this._next = null;
            this._previous = null;
        }

        public Node(T elm, Node<T> n, Node<T> p)
        {
            this._element = elm;
            this._next = n;
            this._previous = p;
        }

        public object Clone()
        {
            Node<T> next;
            Node<T> previous;
            if (this.Next != null)
                next = new Node<T>(this.Next.Element, this.Next.Next, this.Next.Previous);
            else
                next = this.Next;
            if (this.Previous != null)
                previous = new Node<T>(this.Previous.Element, this.Previous.Next, this.Previous.Previous);
            else
                previous = this.Previous;

            return new Node<T> (this._element, next, previous );
        }

    }

    class TwoLinkedList<T> : ICloneable
    {
        private Node<T> _node;

        public TwoLinkedList<T> Add(Node<T> n)
        {
            if (_node == null)
            {
                _node = n;
                return this;
            }

            n.Next = _node;
            _node.Previous = n;
            _node = n;
            return this;
        }

        public Node<T> GetCurrent()
        {
            return _node;
        }

        public Node<T> SetNext()
        {
            if (_node.Next != null)
                _node = _node.Next;
            return _node;
        }

        public Node<T> GetNext()
        {
            return _node;
        }
        public Node<T> SetPrevious()
        {
            if (_node.Previous != null)
                _node = _node.Previous;
            return _node;
        }
        public Node<T> GetPrevious()
        {
            return _node;
        }

        public TwoLinkedList ()
        {
             this._node = null;
        }

        public object Clone()
        {
            return new TwoLinkedList<T> { _node = this._node };
        }
        
    }

    class Program
    {
        static void Main()
        {
            TwoLinkedList<int> list = new TwoLinkedList<int>();
            for(int i = 0; i < 5; i++)
            {
                Node<int> node = new Node<int>(i);
                list.Add(node);
            }
            
            Console.WriteLine(list.GetCurrent().Element);
            var list_test = (TwoLinkedList<int>)list.Clone();
            Console.WriteLine(list_test.GetNext().Element);
            Console.ReadLine();
        }
    }


}
