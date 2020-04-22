using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public static void CountEmptyTest()
        {
            StackCustom myStack = new StackCustom();
            Assert.AreEqual(0, myStack.Count());
        }
        [Test]
        public static void PopEmptyTest()
        {
            StackCustom myStack = new StackCustom();
            Assert.AreEqual(0, myStack.Pop());
        }
        [Test]
        public static void PeekEmptyTest()
        {
            StackCustom myStack = new StackCustom();
            Assert.AreEqual(0, myStack.Peek());
        }
        [Test]
        public static void PushCountTest()
        {
            StackCustom myStack = new StackCustom();
            myStack.Push(32);
            myStack.Push(17);
            Assert.AreEqual(2, myStack.Count());
        }
        [Test]
        public static void PushPeekTest()
        {
            StackCustom myStack = new StackCustom();
            myStack.Push(32);
            myStack.Push(17);
            Assert.AreEqual(17, myStack.Peek());
        }
        [Test]
        public static void PushPopTest1()
        {
            StackCustom myStack = new StackCustom();
            myStack.Push(32);
            myStack.Push(17);
            myStack.Push(3);
            Assert.AreEqual(3, myStack.Pop());
        }

        [Test]
        public static void PushPopTest2()
        {
            StackCustom myStack = new StackCustom();
            myStack.Push(32);
            myStack.Push(17);
            myStack.Push(3);
            int element = myStack.Pop();
            Assert.AreEqual(2, myStack.Count());
        }

    }
}
