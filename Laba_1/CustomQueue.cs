using System;

namespace Laba_1
{
	class Node<T>
	{
		public T element { get; }
		public Node<T> previous { get; set; }
		public Node<T> next { get; set; }


		public Node(T element)
		{
			this.element = element;
		}
	}

	public class CustomQueue<T>
	{
		private Node<T> head;
		private Node<T> tail;
		public int Count = 0;

		public void Enqueue(T item)
		{
			Node<T> node = new Node<T>(item);
			if (tail == null)
			{
				if (head == null)
				{
					head = node;
					Count = 1;
				}
				else
				{
					head.next = node;
					node.previous = head;
					tail = node;
					Count = 2;
				}
			}
			else
			{
				tail.next = node;
				node.previous = tail;
				tail = node;
				Count++;
			}
		}

		public T Dequeue()
		{
			Node<T> first = head;

			if (Count == 0)
			{
				return first.element;
			}
			else if (Count == 1)
			{
				Count = 0;
				head = null;
			}
			else if (Count == 2)
			{
				Count = 1;
				head = tail;
				tail = null;
				head.previous = null;
			}
			else
			{
				Count--;
				head = head.next;
				head.previous = null;
			}
			return first.element;
		}

		public T Peek()
		{
			return head.element;
		}

		public void Clear()
		{
			Count = 0;
			head = null;
			tail = null;
		}
	}
}