using System;
using System.Collections.Generic;
using NUnit.Framework;
using Lab1;

namespace NUnitTestLab1
{
    public class UnitTestTask1
    {
        [TestCase(1)]
        [TestCase(4)]
        public void TestSingleLinkedList_Add_takeNumberOfAddingEl_ShouldReturnSameLength(int number)
        {
            int expectedResult = number;
            SingleLinkedList<int> singleList = new SingleLinkedList<int>(0);
            for (int i = 0; i < number - 1; i++)
                singleList.Add(i);

            int actualResult = singleList.Length();
            Assert.AreEqual(expectedResult, actualResult);
        }


        public void TestSingleLinkedList_GetCurrent_ShouldReturnNodeValue_TestHelper<T>(T[] reversedArray, int index, T expectedResult)
        {
            SingleLinkedList<T> singleList = new SingleLinkedList<T>(reversedArray[0]);
            foreach (T el in reversedArray[1..])
                singleList.Add(el);
            T actualResult = singleList.GetCurrent(index);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(new int[] { 0, 1, 2, 3 }, 3, 0)]
        [TestCase(new int[] { 0, 1, 2, 3 }, 0, 3)]
        [TestCase(new int[] { 0, 1, 2, 3 }, 1, 2)]
        public void TestSingleLinkedList_GetCurrent_takeInt_ShouldReturnNodeValue(int[] reversedArray, int index, int expectedResult)
        {
            TestSingleLinkedList_GetCurrent_ShouldReturnNodeValue_TestHelper<int>(reversedArray, index, expectedResult);
        }
        [TestCase(new double[] { 0, 1, 2, 3 }, 1, 2)]
        public void TestSingleLinkedList_GetCurrent_takeDouble_ShouldReturnNodeValue(double[] reversedArray, int index, double expectedResult)
        {
            TestSingleLinkedList_GetCurrent_ShouldReturnNodeValue_TestHelper<double>(reversedArray, index, expectedResult);
        }
        [TestCase(new char[] { 'a', 'b', 'c', 'd' }, 3, 'a')]
        public void TestSingleLinkedList_GetCurrent_takeChar_ShouldReturnNodeValue(char[] reversedArray, int index, char expectedResult)
        {
            TestSingleLinkedList_GetCurrent_ShouldReturnNodeValue_TestHelper<char>(reversedArray, index, expectedResult);
        }


        [Test]
        public void TestSingleLinkedList_GetCurrent_Exception()
        {
            SingleLinkedList<int> singleList = new SingleLinkedList<int>(0);
            Assert.That(() => singleList.GetCurrent(-1), Throws.ArgumentException);
        }



        [TestCase(new int[] { 0, 1, 2, 3 }, 0, 2)]
        [TestCase(new int[] { 0, 1, 2, 3 }, 1, 1)]
        [TestCase(new int[] { 0, 1, 2, 3 }, 2, 0)]
        public void TestSingleLinkedList_GetNext_ShouldReturnNodeValue(int[] reversedArray, int index, int expectedResult)
        {
            SingleLinkedList<int> singleList = new SingleLinkedList<int>(reversedArray[0]);
            foreach (int el in reversedArray[1..])
                singleList.Add(el);
            int actualResult = singleList.GetNext(index);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TestSingleLinkedList_GetNext_Exception()
        {
            SingleLinkedList<int> singleList = new SingleLinkedList<int>(0);
            Assert.That(() => singleList.GetNext(0), Throws.ArgumentException);
        }



    }
}