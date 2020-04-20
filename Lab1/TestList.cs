using System;
using NUnit.Framework;

namespace Lab1
{
    [TestFixture]
    public class TestList
    {
        [SetUp]
        static public void FillMock()
        {
            Mock.FillMock();
        }


        [Test]
        static public void Add_SixItemsIn_Returns6()
        {
            Assert.AreEqual(4, Mock.list.Length);
        }

        [Test]
        static public void GetCurrent_AddedItems_ItemAtIndex()
        {
            Assert.That(Mock.list.GetCurrent(0).Count, Is.EqualTo(3));
            Assert.That(Mock.list.GetCurrent(1).Count, Is.EqualTo(4));
            Assert.That(Mock.list.GetCurrent(2).Count, Is.EqualTo(1));

            Assert.That(Mock.list.GetCurrent(3).Value, Is.EqualTo("abcdef"));
            Assert.That(Mock.list.GetCurrent(4).Value, Is.EqualTo("1234567890"));

            Assert.That(Mock.list.GetCurrent(-1), Is.EqualTo(default));
        }

        [Test]
        static public void GetNext_AddedItems_NextItem()
        {
            Assert.That(Mock.list.GetNext(0).Count, Is.EqualTo(4));
            Assert.That(Mock.list.GetNext(1).Value, Is.EqualTo("a"));
            Assert.That(Mock.list.GetNext(3).Count, Is.EqualTo(10));
            Assert.That(Mock.list.GetNext(100), Is.EqualTo(default));
        }

    }
}
