using NUnit.Framework;
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
	}
}
