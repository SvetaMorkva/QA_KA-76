using NUnit.Framework;

namespace Khylenko_lab1
{
    [TestFixture]
    class UnitTest2
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1.2.7.4.5.6", "1.2.7.4.5.4.5.6", 1)]
        [TestCase("1.2.7.4.5.6", "1.2.7.4.5.6", 0)]
        [TestCase("1.2.7.4.5.6", "1.3.1", -1)]
        public void CompareVersion_InputsVersions_ReturnsResult(string firstString, string secondString, int expectedResult)
        {
            int actualResult = CompareVersions.Versions(firstString, secondString);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
