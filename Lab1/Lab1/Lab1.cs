using System;
using System.Collections.Generic;
using System.Linq;

namespace QA_Lab1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
        }
    }
    public class Queue<T>
    {
        public void IsNullCheck(T item, string str = "queue is empty!")
        {
            if (item == null)
            {
                throw new NullReferenceException("Invalid action: " + str);
            }
        }
        public void Enqueue(T item)
        {
            IsNullCheck(item, "trying to add unacceptable item!");
            queue.Add(item);
        }

        public T Dequeue()
        {
            var item = queue.FirstOrDefault();

            IsNullCheck(item);
            queue.Remove(item);

            return item;
        }

        public T Peek()
        {
            var item = queue.FirstOrDefault();
            IsNullCheck(item);

            return item;
        }

        public void Clear()
        {
            queue.Clear();
        }
        public int Count => queue.Count;
        private List<T> queue = new List<T>();
    }

    public class VersionCompare
    {
        public static int Compare(string vers1, string vers2)
        {
            int[] arrVers1 = Array.ConvertAll(vers1.Split('.'), int.Parse);
            int[] arrVers2 = Array.ConvertAll(vers2.Split('.'), int.Parse);
            if (arrVers1.Length < arrVers2.Length)
                AlignLength(arrVers1, arrVers2.Length);
            else
                AlignLength(arrVers2, arrVers1.Length);
            for (int i = 0; i < arrVers1.Length; i++)
            {
                if (arrVers1[i] == arrVers2[i])
                {
                    continue;
                }
                if (arrVers1[i] > arrVers2[i])
                {
                    return 1;
                }
                return -1;
            }
            return 0;
        }

        private static void AlignLength(int[] array, int size)
        {
            int previousSize = array.Length;
            Array.Resize<int>(ref array, size);
            for (int i = previousSize; i < size; i++)
            {
                array[i] = 0;
            }
        }
    }
}
