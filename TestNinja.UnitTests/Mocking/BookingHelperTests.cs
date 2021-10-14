using Moq;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class BookingHelper_OverlappingBookingsExistTests
	{
		[Test]
		public void BookingStartsAndFinishesBeforeExistingBooking_ReturnsEmptyString()
		{
			var repository = new Mock<IBookingRepository>();
			repository.Setup(k => k.GetActiveBookings(1)).Returns(new List<Booking>
			{
				new Booking
				{
					Id = 2,
					ArrivalDate = new DateTime(2017, 1, 15, 14, 0, 0),
					DepartureDate = new DateTime(2017, 1, 20, 10, 0, 0),
					Reference = "a"
				}
			}.AsQueryable());

			var result = BookingHelper.OverlappingBookingsExist(new Booking { 
				Id = 1,
				ArrivalDate = new DateTime(2017, 1, 10, 14, 0, 0),
				DepartureDate = new DateTime(2017, 1, 14, 10, 0, 0),
				Reference = "b"
			}, repository.Object);

			Assert.That(result, Is.Empty);
		}
	}
}
