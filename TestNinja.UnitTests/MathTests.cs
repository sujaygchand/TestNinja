using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class MathTests
	{
		private Math _math;

		// SetUp must be public
		// TearDown
		[SetUp]
		public void SetUp()
		{
			_math = new Math();
		} 

		[Test]
		[Ignore("Function is simple and does not need test")]
		public void Add_WhenCalled_ReturnSumOfArgs()
		{
			var result = _math.Add(2, 3);

			Assert.That(result, Is.EqualTo(5));
		}

		[Test]
		[TestCase(2, 1, 2)]
		[TestCase(1, 2, 2)]
		[TestCase(3, 3, 3)]
		public void Max_ArgumentIsGreater_ReturnGreaterArgument(int a, int b, int expectedResult)
		{
			var result = _math.Max(2, 1);

			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		[TestCase(5, new[] { 1, 3, 5 })]
		[TestCase(6, new[] { 1, 3, 5 })]
		[TestCase(9, new[] { 1, 3, 5, 7, 9 })]
		public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersToLimit(int limit, IEnumerable<int> expectedResult)
		{
			var result = _math.GetOddNumbers(limit);

			Assert.That(result, Is.EquivalentTo(expectedResult));
			Assert.That(result, Is.Ordered);
			Assert.That(result, Is.Unique);
		}
	}
}
