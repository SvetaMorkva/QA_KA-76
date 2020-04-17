using NUnit.Framework;
using Task2;

namespace Task_2
{
    [TestFixture]
    class NUnitTest
    {
        [TestCase ("1.2.3", "1.2.3", 0)]
        [TestCase ("1.2.3", "4.5.6", -1)]
        [TestCase ("1", "1.0", 0)]
        [TestCase ("1.1.0", "1.0.1", 1)]


        public void CompareVersion_InputString_ReturnInt(string version1, string version2, int expected)
        {
            Program program = new Program();
            int result = program.CompareVersions(version1, version2);
            Assert.AreEqual(expected, result);
        }
    }
}
