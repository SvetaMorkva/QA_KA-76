using NUnit.Framework;
using TwoLinkedList;

namespace TwoLinkedList.Test
{
    [TestFixture]
    public class Tests
    {
        private TestForTeamCity _testForTeamCity;

        [SetUp]
        public void Setup()
        {
            _testForTeamCity = new TestForTeamCity();
        }

        [Test]
        public void Test1()
        {
            var result = _testForTeamCity.IsPrime(1);
            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}