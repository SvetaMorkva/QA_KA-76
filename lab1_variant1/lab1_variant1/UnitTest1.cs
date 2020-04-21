using System;
using NUnit.Framework;

namespace lab1_variant1
{
    [TestFixture]
    public class TestsDLL
    {

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

        [Test]
        public void GetPrevDLLNode()
        {
            DoublyLinkedList dllNode0 = new DoublyLinkedList(0);
            DoublyLinkedList dllNode1 = dllNode0.Add(1);

            Assert.AreEqual(dllNode1.GetPrev, dllNode0);
        }

    }



    [TestFixture]
    public class TestsCompareVersions
    {

        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("3", "3.0.1", -1)]
        [TestCase("4.7.1", "0", 1)]
        [TestCase("0.0", "0", 0)]

        public void VersionCompare_Compare(string v1, string v2, int trueResult)
        {
            CompareVersions comparer = new CompareVersions(v1, v2);
            int predResult = comparer.Compare;
            Assert.AreEqual(trueResult, predResult);
        }

    }
}