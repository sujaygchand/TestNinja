using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class CustomerControllerTests
	{
		CustomerController _controller;

		[SetUp]
		public void Setup()
		{
			_controller = new CustomerController();
		}

		[Test]
		[TestCase(0)]
		[TestCase(-1)]
		public void GetCustomer_IdLessThanOne_ReturnNotFound(int id)
		{
			var result = _controller.GetCustomer(id);

			Assert.That(result, Is.TypeOf<NotFound>());
		}

		[Test]
		[TestCase(1)]
		[TestCase(9)]
		[TestCase(3009)]
		public void GetCustomer_IdGreaterThanZero_ReturnOk(int id)
		{
			var result = _controller.GetCustomer(id);

			Assert.That(result, Is.TypeOf<Ok>());
		}
	}
}
