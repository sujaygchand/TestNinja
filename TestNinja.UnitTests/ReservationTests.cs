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
		public void CanBeCancelledBy_UserIsNotAdmin_ReturnsFalse()
		{
			// Arrange
			var reservation = new Reservation();

			// Act
			var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void CanBeCancelledBy_UserIsMadeBy_ReturnsTrue()
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
	}
}
