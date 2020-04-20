using System;
using NUnit.Framework;

namespace Lab1
{
    public class TestVersion
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1.0", "1", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1.2.7.4.5.6", "1.2.7.4.5.4.5.6", 1)]
        [TestCase("5.2.7.4.5.6", "1.2.7.4.5.6", 1)]
        [TestCase("1.2.7.4.5.6", "1.3.1", -1)]
        static public void Test_VersionCompare(string firstString, string secondString, int expectedResult)
        {
            int actualResult = VersionComparator.Compare(firstString, secondString);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
