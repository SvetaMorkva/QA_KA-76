using NUnit.Framework;

namespace Lab1
{
    [TestFixture]
    class Test2
    {

        [Test]
        public void AddLanguagesReturnsLength()
        {
            Mock.AddLanguages();
            Assert.AreEqual(5, Mock.languages.count);
        }

        [Test]
        public void TestGetCurrent()
        {
            Assert.That(Mock.languages.GetCurrent(0).years, Is.EqualTo(15));
            Assert.That(Mock.languages.GetCurrent(2).years, Is.EqualTo(20));
            Assert.That(Mock.languages.GetCurrent(2).name, Is.EqualTo("JavaScript"));
            Assert.That(() => Mock.languages.GetCurrent(-1), Throws.ArgumentException);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.That(Mock.languages.GetNext(0).years, Is.EqualTo(18));
            Assert.That(Mock.languages.GetNext(1).years, Is.EqualTo(20));
            Assert.That(Mock.languages.GetNext(1).name, Is.EqualTo("JavaScript"));
            Assert.That(() => Mock.languages.GetNext(10), Throws.ArgumentException);
        }
    }
}
