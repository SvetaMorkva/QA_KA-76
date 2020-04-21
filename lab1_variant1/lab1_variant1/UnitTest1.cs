using System;
using NUnit.Framework;

namespace lab1_variant1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddNodesToDLL()
        {
            DoublyLinkedList dllNode0 = new DoublyLinkedList(0);
            DoublyLinkedList dllNode1 = dllNode0.Add(1);

            Assert.AreEqual(dllNode1.Value, 1);
        }

        [Test]
        public void GetNextDLLNode()
        {
            DoublyLinkedList dllNode0 = new DoublyLinkedList(0);
            DoublyLinkedList dllNode1 = dllNode0.Add(2);
            DoublyLinkedList dllNode2 = dllNode1.Add(3);
            DoublyLinkedList dllNode3 = dllNode0.Add(1);

            Assert.AreEqual(dllNode0.GetNext, dllNode3);
            Assert.AreEqual(dllNode3.GetNext, dllNode1);
            Assert.AreEqual(dllNode1.GetNext, dllNode2);
        }
    }
}