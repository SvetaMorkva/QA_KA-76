using System;
using NUnit.Framework;

namespace Lab1
{
    [TestFixture]
    class ListTests
    {
        [Test]
        public void AddBooksAndCountTest()
        {
            Mock.AddBooks();
            Assert.AreEqual(5, Mock.books.Count);
        }

        [Test]
        public void TestGetCurrent()
        {
            Assert.That(Mock.books.GetCurrent(0).author, Is.EqualTo("Pushkin"));
            Assert.That(Mock.books.GetCurrent(3).title, Is.EqualTo("Atlant"));
            Assert.That(Mock.books.GetCurrent(2).author, Is.EqualTo("Lermontov"));
            Assert.That(() => Mock.books.GetCurrent(-1), Throws.ArgumentException);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.That(Mock.books.GetNext(0).author, Is.EqualTo("Hytler"));
            Assert.That(Mock.books.GetNext(3).title, Is.EqualTo("BehavioralEconomic"));
            Assert.That(Mock.books.GetNext(2).author, Is.EqualTo("Rend"));
            Assert.That(() => Mock.books.GetNext(7), Throws.ArgumentException); 
        }
    }

    [TestFixture]
    class ComparatorTests
    {
        [TestCase("3.0", "1.0.0", 1)]
        [TestCase("2.0.0.0.0", "2", 0)]
        [TestCase("3.0.0.3", "3.3", -1)]
        [TestCase("3.0.0.0.1", "3", 1)]
        public static void ReturnComparatorValueTest(string version1, string version2, int expectedValue)
        {
            int currentValue = Comparator.CompareVersions(version1, version2);
            Assert.AreEqual(expectedValue, currentValue);
        }
    }
}