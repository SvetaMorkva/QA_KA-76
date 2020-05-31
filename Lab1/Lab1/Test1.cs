using NUnit.Framework;

namespace Lab1
{
    class Test1
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1.0", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1.2.0", "1.3.1", -1)]
        [TestCase("1.4.0", "1.3.1", 1)]
        public void Test_VersionCompare(string firstString, string secondString, int expectedResult)
        {
            Comparator versionComparator = new Comparator();
            int actualResult = versionComparator.CompareVersions(firstString, secondString);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
