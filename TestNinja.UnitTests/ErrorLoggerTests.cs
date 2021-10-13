using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class ErrorLoggerTests
	{
		ErrorLogger _logger;

		[SetUp]
		public void Setup()
		{
			_logger = new ErrorLogger();
		}

		[Test]
		public void Log_WhenCalled_SetTheLastErrorProperty()
		{
			var input = "Test text";

			_logger.Log(input);

			Assert.That(_logger.LastError, Is.EqualTo(input));
		}

		[Test]
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Log_InvalidError_SetTheLastErrorProperty(string error)
		{
			Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);
		}

		[Test]
		public void Log_ValidError_RaiseErrorLoggedEvent()
		{
			var id = Guid.Empty;
			_logger.ErrorLogged += (sender, args) => { id = args; };

			var input = "Test text";

			_logger.Log(input);

			Assert.That(id, Is.Not.EqualTo(Guid.Empty));
		}

	}
}
