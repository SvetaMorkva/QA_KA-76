using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
  
    public class Task1
    {
        public DoubleLinkedList<int> TestList { get; }

        public Task1(int n = 1)
        {
            TestList = new DoubleLinkedList<int>();

            if (n == 1)
            {
                TestList.Add(10);
                TestList.Add(20);
                TestList.Add(30);
                TestList.Add(40);
                TestList.Add(50);
            }
            else
            {
                TestList.Add(-10);
                TestList.Add(-20);
                TestList.Add(-30);
                TestList.Add(-40);
                TestList.Add(-50);
            }
        }
    }
  
}