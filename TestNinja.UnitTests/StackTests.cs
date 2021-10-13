using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class StackTests
	{
		private Fundamentals.Stack<int?> _intStack;
		private Fundamentals.Stack<string> _stringStack;

		private static readonly object[] _intSourceLists =
		{
		new object[] {new List<int?> {1}},   //case 1
		new object[] {new List<int?> {1, 2}}, //case 2
		new object[] {new List<int?> {1, 3, 4, 5, 6}}, //case 3
		new object[] {new List<int?> { 1, 3, 4, 5, 7, 34, 6, 11 } } //case 4
		};

		private static readonly object[] _stringSourceLists =
{
		new object[] {new List<string> {"1"}},   //case 1
		new object[] {new List<string> {"1", "2"}}, //case 2
		new object[] {new List<string> {"one", "two" ,"Three", "four"}}, //case 3
		new object[] {new List<string> { "one", "two", "Three", "four", "five", "six", "seven"} } //case 4
		};

		[SetUp]
		public void Setup()
		{
			_intStack = new Fundamentals.Stack<int?>();
			_stringStack = new Fundamentals.Stack<string>();
		}

		[Test]
		[TestCaseSource("_intSourceLists")]
		public void Push_WhenIntStackCalled_AddElementsToList(List<int?> inputList)
		{
			foreach (var item in inputList)
			{
				_intStack.Push(item);
			}

			Assert.That(_intStack.List, Is.EquivalentTo(inputList));
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
	}
}
