using Lab1_BasicKnowledge;
using NUnit.Framework;
using System;

namespace Lab1Tests
{
	class VersionTests
	{

		[TestCase("1", "1.0.0")]
		[TestCase("1.1", "1.1.0")]
		[TestCase("1.1.1", "1.1.1")]
		[TestCase("1,1,1", "1.1.1")]
		public void TestCtor_ShouldReturn_expectedAnswer(string version, string expectedAnswer)
		{
			MyVersion v = new MyVersion(version);
			Assert.AreEqual(v.Value, expectedAnswer);
		}

		[TestCase("1", "1.0", 0)]
		[TestCase("1.2", "1.0", 1)]
		[TestCase("1.0.1", "1.1", -1)]
		[TestCase("2.1.1", "1.1.0", 1)]
		[TestCase("2.1.1", "12.0", -1)]
		[TestCase("1.0.1", "1.0", 1)]
		[TestCase("1.0.1", "1.0.3", -1)]
		[TestCase("4.2.1", "4.2.1", 0)]
		[TestCase("3.1.1", "3.0.1", 1)]
		public void TestCompare_ShouldReturn_Result(string vers1, string vers2, int res)
		{
			var version1 = new MyVersion(vers1);
			var version2 = new MyVersion(vers2);
			var expected = res;
			var actual = version1.CompareTo(version2);
			Assert.AreEqual(expected, actual);

		}

	}
}
