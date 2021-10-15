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
		private Booking _existingBooking;
		private Mock<IBookingRepository> _repository;

		[SetUp]
		public void SetUp()
		{
			_existingBooking = new Booking
			{
				Id = 2,
				ArrivalDate = BookingDate(2017, 1, 15),
				DepartureDate = BookingDate(2017, 1, 20, false),
				Reference = "a"
			};

			_repository = new Mock<IBookingRepository>();
			_repository.Setup(k => k.GetActiveBookings(1)).Returns(new List<Booking>
			{
				_existingBooking
			}.AsQueryable());
		}

		[Test]
		public void BookingStartsAndFinishesBeforeExistingBooking_ReturnsEmptyString()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking { 
				Id = 1,
				ArrivalDate = NewDateOffsetByDays(_existingBooking.ArrivalDate, -5),
				DepartureDate = NewDateOffsetByDays(_existingBooking.ArrivalDate, -1),
				Reference = "b"
			}, _repository.Object);

			Assert.That(result, Is.Empty);
		}

		[Test]
		public void BookingStartsBeforeAndFinishesDuringExistingBooking_ReturnsExistingBookings ()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = NewDateOffsetByDays(_existingBooking.ArrivalDate, -5),
				DepartureDate = NewDateOffsetByDays(_existingBooking.DepartureDate, -2),
				Reference = "b"
			}, _repository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsBeforeAndFinishesAfterExistingBooking_ReturnsExistingBookings()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = NewDateOffsetByDays(_existingBooking.ArrivalDate, -5),
				DepartureDate = NewDateOffsetByDays(_existingBooking.DepartureDate, 2),
				Reference = "b"
			}, _repository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsDuringAndFinishesDuringExistingBooking_ReturnsExistingBookings()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = NewDateOffsetByDays(_existingBooking.ArrivalDate, 1),
				DepartureDate = NewDateOffsetByDays(_existingBooking.DepartureDate, -2),
				Reference = "b"
			}, _repository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsDuringAndFinishesAfterExistingBooking_ReturnsExistingBookings()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = NewDateOffsetByDays(_existingBooking.ArrivalDate, 1),
				DepartureDate = NewDateOffsetByDays(_existingBooking.DepartureDate, 2),
				Reference = "b"
			}, _repository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsAndFinishesAfterExistingBooking_ReturnsEmptyString()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = NewDateOffsetByDays(_existingBooking.DepartureDate, 1),
				DepartureDate = NewDateOffsetByDays(_existingBooking.DepartureDate, 6),
				Reference = "b"
			}, _repository.Object);

			Assert.That(result, Is.EqualTo(string.Empty));
		}

		[Test]
		public void BookingsOverlapButNewBookingIsCancelled_ReturnsExistingBookings()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = NewDateOffsetByDays(_existingBooking.ArrivalDate, -5),
				DepartureDate = NewDateOffsetByDays(_existingBooking.DepartureDate, 2),
				Reference = "b",
				Status = "Cancelled"
			}, _repository.Object);

			Assert.That(result, Is.EqualTo(string.Empty));
		}

		private DateTime NewDateOffsetByDays(DateTime dateTime, int daysOffset)
		{
			return dateTime.AddDays(daysOffset);
		}

		private DateTime BookingDate(int year, int month, int day, bool isArrival = true)
		{
			return new DateTime(year, month, day, isArrival ? 14 : 10, 0, 0);
		}
	}
}
