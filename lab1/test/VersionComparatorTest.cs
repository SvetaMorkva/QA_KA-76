using System;
using Xunit;
using lab1;

public class VersionComparatorTest
{
    /*
        Every method annotated with [Fact] will be marked as a test and run by xUnit.net
        Fact methods cannot have parameters
        The [Theory] attribute denotes a parameterised test
    */
    
    [Theory]
    [InlineData("1.2.3", "4.5.6", -1)]
    [InlineData("1", "1.0", 0)]
    [InlineData("1.1.0", "1.0.1.", 1)]

    public void compareVersionsTest(string version1, string version2, int expected)
    {
        Console.WriteLine("Testing VersionComparator.compareVersions");
        int actual = new VersionComparator().compareVersions(version1, version2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1.2.3", "1.2.3")]
    [InlineData("1", "1.0.0")]
    [InlineData("1.1.0", "1.1.0")]
    [InlineData("1.", "1..0.0")]
    public void completeVersionTest(string version, string expected)
    {
        Console.WriteLine("Testing VersionComparator.compareVersions");
        VersionComparator vc = new VersionComparator();
        string actual = vc.completeVersion(version);
        Assert.Equal(expected, actual);
    }
}
