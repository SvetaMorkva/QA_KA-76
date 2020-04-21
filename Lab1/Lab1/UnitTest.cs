using NUnit.Framework;

namespace QA_Lab1
{
    [TestFixture]
    public class TestsQueue
    {

        [Test]
        public void Queue_Enqueue_ShouldReturn2()
        {
            Queue<int> testQueue = new Queue<int>();
            testQueue.Enqueue(-3);
            testQueue.Enqueue(1567);
            Assert.AreEqual(testQueue.Count, 2);
        }

        [Test]
        public void Queue_Dequeue_ShouldReturn3()
        {
            Queue<int> testQueue = new Queue<int>();
            testQueue.Enqueue(-120);
            testQueue.Enqueue(134);
            testQueue.Enqueue(3454);
            testQueue.Enqueue(1312);
            testQueue.Enqueue(-1312);

            testQueue.Dequeue();
            testQueue.Dequeue();
            Assert.AreEqual(testQueue.Count, 3);
        }

        [Test]
        public void Queue_Dequeue_ShouldReturn134()
        {
            Queue<int> testQueue = new Queue<int>();
            testQueue.Enqueue(-120);
            testQueue.Enqueue(134);
            testQueue.Enqueue(3454);
            testQueue.Enqueue(1312);
            testQueue.Enqueue(-1312);

            testQueue.Dequeue();
            int item = testQueue.Dequeue();
            Assert.AreEqual(item, 134);
        }

        [Test]
        public void Queue_Peek_ShouldReturn1000()
        {
            Queue<int> testQueue = new Queue<int>();
            testQueue.Enqueue(1000);
            testQueue.Enqueue(134);
            testQueue.Enqueue(3454);
            testQueue.Enqueue(1312);
            testQueue.Enqueue(-1312);

            testQueue.Peek();
            int item = testQueue.Peek();
            Assert.AreEqual(item, 1000);
        }

        [Test]
        public void Queue_Clear_ShouldReturn5()
        {
            Queue<int> testQueue = new Queue<int>();
            testQueue.Enqueue(-120);
            testQueue.Enqueue(134);
            testQueue.Enqueue(3454);
            testQueue.Enqueue(1312);
            testQueue.Enqueue(-1312);

            testQueue.Clear();
            Assert.AreEqual(testQueue.Count, 0);
        }
    }

    [TestFixture]
    public class TestsVersionCompare
    {
        [TestCase("1.2.8.0", "1.2.7.4", 1)]
        [TestCase("2.2.7.0.4.6", "2.2.7.4.0", -1)]
        [TestCase("8.9.1", "8.9.1.0", 0)]
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        public void VersionCompare_Compare(string firstString, string secondString, int expectedResult)
        {
            int actualResult = VersionCompare.Compare(firstString, secondString);
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}