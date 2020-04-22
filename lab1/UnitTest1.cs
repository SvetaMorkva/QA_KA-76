using NUnit.Framework;

namespace lab1
{
    public class UnitTest1
    {

        [Test]
        public void Test_Add()
        {
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            string str1 = "test1";
            list.Add(str1);

            Assert.AreEqual(list.GetCurrent(), str1);
        }


        [Test]
        public void Test_GetCurrent()
        {
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            string str1 = "test1";
            string str2 = "test2";
            list.Add(str1);
            list.Add(str2);

            Assert.AreEqual(list.GetCurrent(), str1);
        }


        [Test]
        public void Test_GetNext()
        {
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            string str1 = "test1";
            string str2 = "test2";
            list.Add(str1);
            list.Add(str2);

            Assert.AreEqual(list.GetNext(), str2);
        }


        [Test]
        public void Test_GetPrevious()
        {
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            string str1 = "test1";
            string str2 = "test2";
            list.Add(str1);
            list.Add(str2);
            string skip = list.GetNext();

            Assert.AreEqual(list.GetPrevious(), str1);
        }



        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1.2.7.4.5.6", "1.2.7.4.5.4.5.6", 1)]
        [TestCase("1.2.7.4.5.6", "1.2.7.4.5.6", 0)]
        [TestCase("1.2.7.4.5.6", "1.3.1", -1)]
        public void Test_VersionCompare(string str1, string str2, int expectedResult)
        {
            Task2 comp = new Task2();
            int actualResult = comp.CompareVersions(str1, str2);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}