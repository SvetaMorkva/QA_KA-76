using NUnit.Framework;


namespace ClassLibrary3
{
    class UnitTests1
    {
        Task1[] mocks = new Task1[2];

        [SetUp]
        public void Setup()
        {
            mocks[0] = new Task1(1);
            mocks[1] = new Task1(-1);

        }

        [Test]
        public void Test_Add()
        {
            DoubleLinkedList<int> testList = mocks[0].TestList;
            testList.Add(60);
            Assert.AreEqual(60, testList.GetCurrent(5).Data);
        }


        [Test]
        public void Test_GetPrevious()
        {
            DoubleLinkedList<int> testList = mocks[1].TestList;
            testList.Add(-60);
            Assert.AreEqual(-50, testList.GetPrevious(5).Data);
        }

        [Test]
        public void Test_GetNext()
        {
            DoubleLinkedList<int> testList = mocks[1].TestList;
            testList.Add(-60);
            Assert.AreEqual(-60, testList.GetNext(4).Data);
        }
    }
}