using NUnit.Framework;

namespace Laba_1
{
    public class UnitTest2
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1.2.8", "1.2.7", 1)]
        [TestCase("3.2.1.4.5.6", "3.2.1.4.5.6", 0)]
        [TestCase("1.2.7", "1.3.1", -1)]
        public void Test_VersionCompare(string firstString, string secondString, int expectedResult)
        {
            VersionComparator versionComparator = new VersionComparator();
            int actualResult = versionComparator.CompareVersions(firstString, secondString);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}