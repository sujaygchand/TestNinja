using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class DemeritPointsCalculatorTests
	{
		DemeritPointsCalculator _calculator;

		[SetUp]
		public void Setup()
		{
			_calculator = new DemeritPointsCalculator();
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(65, 0)]
		[TestCase(67, 0)]
		[TestCase(70, 1)]
		[TestCase(75, 2)]
		[TestCase(80, 3)]
		public void CalculateDemeritPoints_ExceedsSpeedLimit_ReturnDemeritPoints(int speed, int expectedResult)
		{
			var result = _calculator.CalculateDemeritPoints(speed);

			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		[TestCase(0)]
		[TestCase(10)]
		[TestCase(23)]
		[TestCase(65)]
		public void CalculateDemeritPoints_DoesNotExceedsSpeedLimit_ReturnZero(int speed)
		{
			var result = _calculator.CalculateDemeritPoints(speed);

			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		[TestCase(-300)]
		[TestCase(-50)]
		[TestCase(-23)]
		[TestCase(301)]
		[TestCase(500)]
		[TestCase(3000)]
		public void CalculateDemeritPoints_SpeedOutOfBounds_ReturnArgumentOutOfRangeException(int speed)
		{
			Assert.That(() => _calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}
	}
}
