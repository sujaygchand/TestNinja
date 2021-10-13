using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class HtmlFormatterTests
	{
		[Test]
		public void FormatAsBold_WhenCalled_ShouldEncloseWithStringElement()
		{
			var formatter = new HtmlFormatter();
			string input = "abcde";

			var result = formatter.FormatAsBold(input);

			Assert.That(result, Is.EqualTo($"<strong>{input}</strong>").IgnoreCase);
		}
	}
}
