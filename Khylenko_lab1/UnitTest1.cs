using NUnit.Framework;

namespace Khylenko_lab1
{
    [TestFixture]
    class UnitTest1
    {

        [Test]
        public void AddBooks_ReturnsLength()
        {
            Mock.AddBooks();
            Assert.AreEqual(6, Mock.doublyLinkedList.Count);
        }

        [Test]
        public void TestGetCurrent()
        {
            Assert.That(Mock.doublyLinkedList.GetCurrent(0).author, Is.EqualTo("Thomas Mann"));
            Assert.That(Mock.doublyLinkedList.GetCurrent(2).author, Is.EqualTo("James Joyce"));
            Assert.That(Mock.doublyLinkedList.GetCurrent(2).name, Is.EqualTo("Ulysses"));
            Assert.That(() => Mock.doublyLinkedList.GetCurrent(-1), Throws.ArgumentException);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.That(Mock.doublyLinkedList.GetNext(0).author, Is.EqualTo("Irvine Welsh"));
            Assert.That(Mock.doublyLinkedList.GetNext(2).author, Is.EqualTo("Serhiy Zhadan"));
            Assert.That(Mock.doublyLinkedList.GetNext(2).name, Is.EqualTo("Anarchy in the UKR"));
            Assert.That(() => Mock.doublyLinkedList.GetNext(-1), Throws.ArgumentException);
        }

        [Test]
        public void TestGetPrev()
        {
            Assert.That(Mock.doublyLinkedList.GetPrev(3).author, Is.EqualTo("James Joyce"));
            Assert.That(Mock.doublyLinkedList.GetPrev(4).author, Is.EqualTo("Serhiy Zhadan"));
            Assert.That(Mock.doublyLinkedList.GetPrev(5).name, Is.EqualTo("On the Road"));
            Assert.That(() => Mock.doublyLinkedList.GetPrev(-1), Throws.ArgumentException);
        }

    }
}
