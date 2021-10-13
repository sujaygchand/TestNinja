using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestClass]
	public class ReservationTests
	{
		[TestMethod]
		public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
		{
			// Arrange
			var reservation = new Reservation();
			
			// Act
			var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CanBeCancelledBy_SameUserCalling_ReturnsTrue()
		{
			// Arrange
			var reservation = new Reservation();

			// Act
			var user = new User { IsAdmin = false };
			reservation.MadeBy = user;
			var result = reservation.CanBeCancelledBy(user);

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void CanBeCancelledBy_DifferentUserCancelling_ReturnsFalse()
		{
			// Arrange
			var reservation = new Reservation();

			// Act
			var user = new User { IsAdmin = false };
			reservation.MadeBy = user;
			var result = reservation.CanBeCancelledBy(new User());

			// Assert
			Assert.IsFalse(result);
		}
	}
}
