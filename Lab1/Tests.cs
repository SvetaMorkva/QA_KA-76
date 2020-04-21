using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Lab1
{
    [TestFixture]
    public class TestsForVersionCompare
    {
        [TestCase("1.0.0.0.1", "1", 1)]
        [TestCase("1.0.0.0.0", "1", 0)]
        [TestCase("1.0.0.0.1", "1.1", -1)]
        public static void VersionCompare_ShouldReturn(string version1, string version2, int expectedValue)
        {
            int actualValue = Comparer.CompareVersions(version1, version2);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }

    [TestFixture]
    public class TestForMyQueue
    {
        [Test]
        public static void Count_ShouldReturn2()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(6);
            Assert.AreEqual(2, queue.Count);
        }

        [TestCase(10, 10)]
        [TestCase(-12, -12)]
        public static void Dequeue_ShouldReturnInt(int value, int expectedValue)
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(value);
            Assert.AreEqual(expectedValue, queue.Dequeue());
        }
        
        [TestCase("123", "123")]
        [TestCase("", "")]
        public static void Dequeue_ShouldReturnString(string value, string expectedValue)
        {
            MyQueue<string> queue = new MyQueue<string>();
            queue.Enqueue(value);
            Assert.AreEqual(expectedValue, queue.Dequeue());
        }

        [Test]
        public static void Peek_ShouldReturn10()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(-23);
            queue.Enqueue(111);
            Assert.AreEqual(10, queue.Peek());
        }

        [Test]
        public static void Clear_ShouldClear()
        {
            MyQueue<bool> queue = new MyQueue<bool>();
            queue.Enqueue(true);
            queue.Enqueue(true);
            queue.Enqueue(false);
            queue.Enqueue(true);
            queue.Enqueue(false);
            queue.Clear();
            Assert.AreEqual(0, queue.Count);
        }
        
    }
}