using NUnit.Framework;

namespace Lab_1
{
    class UnitTest1
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1", "1.0.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1.2.7.4.5.6.7", "1.2.7.4.5.4", 1)]
        [TestCase("1.2.7.4.5.6", "1.2.7.4.5.6", 0)]
        [TestCase("1.3.3.3.5", "1.3.6", -1)]
        [TestCase("1.2.7.4.5.6", "1.3.1", -1)]
        public void Test_VersionCompare(string firstString, string secondString, int expectedResult)
        {
            Comparison versionComparison = new Comparison();
            int actualResult = versionComparison.CompareVersions(firstString, secondString);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
