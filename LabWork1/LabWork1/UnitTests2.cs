using NUnit.Framework;

namespace LabWork1
{
    class UnitTests2
    {
        [TestCase("1.2.4", "5.2.1", -1)]
        [TestCase("5.2.1", "1.1.1.1.1", 1)]
        [TestCase("1.2", "1.2.1", -1)]
        [TestCase("1.2.4.4.5.6.7.7.1", "1.2", 1)]
        [TestCase("1.2.0.0.0.0.0.0", "1.2", 0)]

        public void TestTask2(string version1, string version2, int result)
        {
            Task2 versionComparator = new Task2();
            int trueResult = versionComparator.CompareVersions(version1, version2);
            Assert.AreEqual(trueResult, result);
        }
    }
}
