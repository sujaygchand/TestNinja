using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class ErrorLoggerTests
	{
		[Test]
		public void Log_WhenCalled_SetTheLastErrorProperty()
		{
			var logger = new ErrorLogger();
			var input = "Test text";

			logger.Log(input);

			Assert.That(logger.LastError, Is.EqualTo(input));
		}
	}
}
