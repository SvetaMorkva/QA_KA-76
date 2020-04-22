using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    [TestFixture]
    class VersionComparatorTests
    {
        [TestCase("1.1", "1")]
        [TestCase("1.0.1", "1")]
        [TestCase("1.1.2", "1.1.1")]
        [TestCase("7.8", "7.7.9")]
        [TestCase("1.2", "1.1")]
        public static void TestLarger(string str1, string str2)
        {
            Assert.AreEqual(1, VersionComparator.CompareVersions(str1, str2));
        }

        [TestCase("1.1", "1")]
        [TestCase("1.0.1", "1")]
        [TestCase("1.1.2", "1.1.1")]
        [TestCase("7.8", "7.7.9")]
        [TestCase("1.2", "1.1")]
        public static void TestSmaller(string str2, string str1)
        {
            Assert.AreEqual(-1, VersionComparator.CompareVersions(str1, str2));
        }

        [TestCase("1.1", "1.1.0")]
        [TestCase("1.0.0", "1")]
        [TestCase("1.1.2", "1.1.2")]
        [TestCase("1.0.0", "1.0")]
        [TestCase("1.2", "1.2.0")]
        public static void TestAreEqual(string str1, string str2)
        {
            Assert.AreEqual(0, VersionComparator.CompareVersions(str1, str2));
        }
    }
}
