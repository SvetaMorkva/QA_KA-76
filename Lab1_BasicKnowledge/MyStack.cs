using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_BasicKnowledge
{
	public class MyStack<T> 
	{
		StackElement<T> head;
		int elementCount;
		public MyStack()
		{
			head = null;
			elementCount = 0;
		}
		public int Count => elementCount;

		public void Push(T value)
		{
			elementCount++;
			var node = new StackElement<T>(value);
			if (head == null)
				head = node;
			else
			{
				var temp = new StackElement<T>(head.Value);
				temp.Next = head.Next;
				head = node;
				head.Next = temp;
			}
		}
		public T Pop()
		{
			elementCount--;
			if (head == null)
				throw new NullReferenceException("Stack is empty");
			else
			{
				var temp = new StackElement<T>(head.Value);
				head = head.Next;
				return temp.Value;
			}

		}
		public T Peek()
		{
			if (head == null)
				throw new NullReferenceException("Stack is empty");
			else
			{
				return head.Value;
			}
		}

		public bool IsEmpty()
		{
			if (head == null)
				return true;
			else
				return false;
		}
	
	}

	internal class StackElement<T>
	{
		public T Value { get; set; }
		public StackElement<T> Next;

		public StackElement()
		{
			Value = default(T);
			Next = null;
		}
		public StackElement(T value)
		{
			this.Value = value;
			Next = null;
		}
	}
}
