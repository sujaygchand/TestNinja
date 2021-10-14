﻿using Moq;
using NUnit.Framework;
using System;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class EmployeeControllerTests
	{
		[Test]
		public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
		{
			var storage = new Mock<IEmployeeStorage>();
			var controller = new EmployeeController(storage.Object);

			controller.DeleteEmployee(1);

			storage.Verify(k => k.DeleteEmployee(1));
		}
	}
}
