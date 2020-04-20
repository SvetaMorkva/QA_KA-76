using System;
using Xunit;
using lab1;

// namespace lab1
// {
    public class VersionComparatorTest
    {
        // Every method annotated with Fact will be marked as a test and run by xUnit.net
        // [Fact]
        // Fact methods cannot have parameters
        // The [Theory] attribute denotes a parameterised test
        
        [Theory]
        [InlineData("Pavlo", "Pyvovar", 1)]
        public void CompareVersionsTest(string s1, string s2, int expected)
        {
            Console.WriteLine("I am in the CompareVersionsTest");
            int actual = new VersionComparator().CompareVersions(s1, s2);

            // Assert.AreEqual(expected, actual);
            Assert.Equal(expected, actual);

        }
    }
// }
