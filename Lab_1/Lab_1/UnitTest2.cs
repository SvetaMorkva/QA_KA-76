using NUnit.Framework;

namespace Lab_1
{
    [TestFixture]
    class UnitTest2
    {

        [Test]
        public void AddScheduleReturnsLength()
        {
            testData.AddSchedule();
            Assert.AreEqual(5, testData.schedule.count);
        }

        [Test]
        public void TestGetCurrent()
        {
            Assert.That(testData.schedule.GetCurrent(0).credits, Is.EqualTo(2));
            Assert.That(testData.schedule.GetCurrent(2).credits, Is.EqualTo(3));
            Assert.That(testData.schedule.GetCurrent(2).title, Is.EqualTo("Text Mining"));
            Assert.That(() => testData.schedule.GetCurrent(-1), Throws.ArgumentException);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.That(testData.schedule.GetNext(0).credits, Is.EqualTo(4));
            Assert.That(testData.schedule.GetNext(1).credits, Is.EqualTo(3));
            Assert.That(testData.schedule.GetNext(1).title, Is.EqualTo("Text Mining"));
            Assert.That(() => testData.schedule.GetNext(10), Throws.ArgumentException);
        }
    }
}