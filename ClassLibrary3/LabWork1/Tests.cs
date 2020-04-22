using NUnit.Framework;


namespace ClassLibrary3
{
    class UnitTestsForTask1
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

    class UnitTestsForTask2
    {
        [TestCase("1.2.4", "5.2.1", -1)]
        [TestCase("5.2.1", "1.1.1.1.1", 1)]
        [TestCase("1.2", "1.2.1", -1)]
        [TestCase("1.2.4.4.5.6.7.7.1", "1.2", 1)]
        [TestCase("1.2.0.0.0.0.0.0", "1.2", 0)]

        public void TestTask2(string version1, string version2, int result)
        {
            Task2 versionComparator = new Task2();
            int trueResult = versionComparator.CompareVersions(version1, version2);
            Assert.AreEqual(trueResult, result);
        }
    }
}