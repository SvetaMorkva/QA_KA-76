using System;
using NUnit.Framework;
using TwoLinkedList;

namespace TwoLinkedList
{
    [TestFixture]
    class NUnitTest
    {
        private int _n;
        private int[] _array;
        private TwoLinkedList<int> _list;
        [SetUp]
        public void SetUp()
        {
            _n = 5;
            _list = new TwoLinkedList<int>();
            _array = new int[_n];
            for(int i = 0; i < _n; i++)
            {
                Node<int> node = new Node<int>(i);
                _array[i] = i;
                _list.Add(node);
            }
        }

        [Test]
        public void GetCurrent_InputVoid_ReturnCurrentElement()
        {
            int currentElement = _array[4];
            Assert.AreEqual(currentElement, _list.GetCurrent().Element);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void GetNext_InputVoid_ReturnNextElement(int step)
        {
            var list = (TwoLinkedList<int>)_list.Clone();
            for(int i = 1; i <= step; i++)
            {
                list.SetNext();
            }

            int element =_array[_n - step - 1];
            Assert.AreEqual(element, list.GetCurrent().Element);

        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void GetPrevious_InputVoid_ReturnPreviousElement(int step)
        {
            var list = (TwoLinkedList<int>)_list.Clone();
            for (int i = 0; i < _n; i++)
            {
                list.SetNext();
            }

            for (int i = 1; i <= step; i++)
            {
                list.SetPrevious();
            }

            int element = _array[step];
            Assert.AreEqual(element, list.GetCurrent().Element);

        }
    }
}
