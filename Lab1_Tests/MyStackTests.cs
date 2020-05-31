using Lab1_BasicKnowledge;
using NUnit.Framework;
using System;

namespace Lab1_Tests
{
	public class MyStackTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(5)]
		[TestCase(100)]
		public void TestPush_ShouldReturn_Param(int n)
		{
			//arrange
			MyStack<int> stack = new MyStack<int>();
			Random r = new Random();
			var expected = n;
			//act
			for (int i = 0; i < n; i++)
			{
				stack.Push(r.Next());
			}

			var actual = stack.Count;
			//assert
			Assert.AreEqual(actual, expected);
		}

		[TestCase(0)]
		[TestCase(11)]
		[TestCase(5)]
		[TestCase(100)]
		public void TestPop_ShouldReturn_Param_And_StackShould_BeNull(int param)
		{
			MyStack<int> stack = new MyStack<int>();
			var expected = param;
			stack.Push(param);

			var actual = stack.Pop();

			//assert
			Assert.AreEqual(actual, expected);
			Assert.True(stack.IsEmpty());
		}


		[TestCase(0)]
		[TestCase(1)]
		[TestCase(45)]
		[TestCase(100)]
		public void TestPop_ShouldReturn_Param_And_StackShould_NotBeNull(int param)
		{
			//arrange
			MyStack<int> stack = new MyStack<int>();
			Random r = new Random();
			var expected = param;
			for (int i = 0; i < 3; i++)
			{
				stack.Push(r.Next());
			}

			stack.Push(param);

			var actual = stack.Pop();

			//assert
			Assert.AreEqual(actual, expected);
			Assert.False(stack.IsEmpty());
		}

		[Test]
		public void TestPop_ShouldThrow_Exeption()
		{
			MyStack<int> stack = new MyStack<int>();
			stack.Push(3);
			stack.Pop();

			Assert.Throws<NullReferenceException>(() => stack.Pop());

		}

		[TestCase(1, 2)]
		[TestCase(45, 15)]
		[TestCase(100, 100)]
		public void TestPeek_ShouldReturn_Param1_AndCountAs_Param2(int value, int count)
		{
			MyStack<int> stack = new MyStack<int>();
			Random r = new Random();
			var expected_value = value;
			var expected_count = count;
			//act
			for (int i = 0; i < count-1; i++)
			{
				stack.Push(r.Next());
			}
			stack.Push(value);

			var actual_value = stack.Peek();
			var actual_count = stack.Count;

			Assert.AreEqual(expected_value, actual_value);
			Assert.AreEqual(expected_count, actual_count);
		}
	}
}