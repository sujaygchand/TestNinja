using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class FizzBuzzTests
	{
		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(7)]
		[TestCase(-1)]
		[TestCase(-7)]
		public void GetOutput_NotDivisibleByThreeOrFive_ReturnNumberString(int number)
		{
			var result = FizzBuzz.GetOutput(number);

			Assert.That(result, Is.EqualTo(number.ToString()));
		}

		[Test]
		[TestCase(3)]
		[TestCase(6)]
		[TestCase(9)]
		[TestCase(-3)]
		[TestCase(-9)]
		public void GetOutput_DivisibleByThree_ReturnFizz(int number)
		{
			var result = FizzBuzz.GetOutput(number);

			Assert.That(result, Is.EqualTo("Fizz").IgnoreCase);
		}

		[Test]
		[TestCase(5)]
		[TestCase(10)]
		[TestCase(20)]
		[TestCase(-5)]
		[TestCase(-10)]
		public void GetOutput_DivisibleByFive_ReturnBuzz(int number)
		{
			var result = FizzBuzz.GetOutput(number);

			Assert.That(result, Is.EqualTo("Buzz").IgnoreCase);
		}

		[Test]
		[TestCase(15)]
		[TestCase(30)]
		[TestCase(45)]
		[TestCase(-15)]
		[TestCase(-30)]
		public void GetOutput_DivisibleByThreeAndFive_ReturnFizzBuzz(int number)
		{
			var result = FizzBuzz.GetOutput(number);

			Assert.That(result, Is.EqualTo("FizzBuzz").IgnoreCase);
		}
	}
}
