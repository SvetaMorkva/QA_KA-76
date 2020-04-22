using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class StackCustom
    {
        static readonly int MAX = 1000;
        int top;
        int[] stack = new int[MAX];


        public StackCustom()
        {
            top = -1;

        }

        public int Count()
        {
            return top + 1;
        }
        public bool Push(int data)
        {
            if (top >= MAX)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                top++;
                stack[top] = data;
                return true;
            }
        }

        public int Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                int value = stack[top];
                top--;
                return value;
            }
        }

        public int Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
                return stack[top];
        }
    }
}
