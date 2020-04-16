using NUnit.Framework;
using Lab1;

namespace NUnitTestLab1
{
    public class UnitTestTask2
    {

        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1", "1.0.1", -1)]
        [TestCase("1.0.0", "1", 0)]
        public void TestVersionComparing_ShouldReturn_1_ifBigger_0_ifEqual_minus1_ifLess(string str1, string str2, int expectedResult)
        {
            Task2 task2 = new Task2();
            int actualResult = task2.CompareVersions(str1, str2);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}