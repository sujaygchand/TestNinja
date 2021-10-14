using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class StackTests
	{
		private Fundamentals.Stack<string> _stringStack;

		private static readonly object[] _stringSourceLists =
		{
		new object[] {new List<string> {"1"}},   //case 1
		new object[] {new List<string> {"1", "2"}}, //case 2
		new object[] {new List<string> {"one", "two" ,"Three", "four"}}, //case 3
		new object[] {new List<string> { "one", "two", "Three", "four", "five", "six", "seven"} } //case 4
		};

		private static readonly object[] _stringLastElementSourceLists =
{
		new object[] {new List<string> {"1"}, "1", 1},   //case 1
		new object[] {new List<string> {"1", "2"}, "2", 2}, //case 2
		new object[] {new List<string> {"one", "two" ,"Three", "four"}, "four", 4}, //case 3
		new object[] {new List<string> { "one", "two", "Three", "four", "five", "six", "seven"}, "seven", 7 } //case 4
		};

		[SetUp]
		public void Setup()
		{
			_stringStack = new Fundamentals.Stack<string>();
		}

		[Test]
		[TestCaseSource("_stringSourceLists")]
		public void Push_WhenStringStackCalled_AddElementsToList(List<string> inputList)
		{
			foreach (var item in inputList)
			{
				_stringStack.Push(item);
			}

			Assert.That(_stringStack.List, Is.EquivalentTo(inputList));
		}

		[Test]
		public void Push_AddNullToStack_ThrowArgumentNullException()
		{

			Assert.That( () => _stringStack.Push(null), Throws.ArgumentNullException);
		}

		[Test]
		[TestCaseSource("_stringLastElementSourceLists")]
		public void Pop_WhenCalled_ReturnLastResult(List<string> inputList, string expectedResult, int listLength)
		{
			foreach (var item in inputList)
			{
				_stringStack.Push(item);
			}

			var result = _stringStack.Pop();

			Assert.That(result, Is.EqualTo(expectedResult));
			Assert.That(_stringStack.Count, Is.EqualTo(listLength - 1));
		}

		[Test]
		public void Pop_StackListIsEmpty_ThrowInvalidOperationException()
		{

			Assert.That(() => _stringStack.Pop(), Throws.InvalidOperationException);
		}

		[Test]
		[TestCaseSource("_stringLastElementSourceLists")]
		public void Peek_WhenCalled_ReturnLastResult(List<string> inputList, string expectedResult, int listLength)
		{
			foreach (var item in inputList)
			{
				_stringStack.Push(item);
			}

			var result = _stringStack.Peek();

			Assert.That(result, Is.EqualTo(expectedResult));
			Assert.That(_stringStack.Count, Is.EqualTo(listLength));
		}

		[Test]
		public void Peek_StackListIsEmpty_ThrowInvalidOperationException()
		{
			Assert.That(() => _stringStack.Peek(), Throws.InvalidOperationException);
		}
	}
}
