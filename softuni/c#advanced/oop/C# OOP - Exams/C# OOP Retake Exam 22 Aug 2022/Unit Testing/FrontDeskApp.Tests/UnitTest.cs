using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Security.AccessControl;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new("Radison", 5);
        }

        [Test]
        public void ConstructorSetsFullNameAndCattegoryCorrectly()
        {
            string expectedFullName = "Radison";
            int expectedCategory = 5;

            Hotel hotel = new(expectedFullName, expectedCategory);

            Assert.AreEqual(expectedFullName, hotel.FullName);
            Assert.AreEqual(expectedCategory, hotel.Category);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void FullNameSetterThrowsExceptionIfValueIsNullOrWhiteSpace(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, 5));
        }

        [Test]
        [TestCase(6)]
        [TestCase(-5)]
        public void CattegorySetterThrowsExceptionIfValueOutOfRange(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Radison", category));
        }

        [Test]
        public void AddRoomAddsRoomsCorrectly()
        {
            Room room = new Room(3, 100);
            hotel.AddRoom(room);
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoomThrowsExceptionWhenThereAreNoAdults(int adults)
        {
            Room room = new Room(3, 100);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2, 3, 200));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-1)]
        public void BookRoomThrowsExceptionWhenChildrenAreLessThanZero(int children)
        {
            Room room = new Room(3, 100);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, children, 3, 200));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoomThrowsExceptionWhenResidenceDurationIsLessThanOne(int duration)
        {
            Room room = new Room(3, 100);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, 3, duration, 200));
        }

        [Test]
        public void BookRoomNoTurnOver()
        {
            Room room = new Room(3, 100);
            hotel.AddRoom(room);
            hotel.BookRoom(4, 1, 2, 100);

            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomNoBookingWhenBudgetTooLow()
        {
            Room room = new Room(5, 70);
            hotel.AddRoom(room);
            hotel.BookRoom(4, 2, 2, 100);

            double expectedTurnover = 0;

            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(expectedTurnover, Is.EqualTo(0));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void BookRoomsBooksCorrectly()
        {
            Room room = new Room(5, 70);
            hotel.AddRoom(room);
            hotel.BookRoom(4, 1, 2, 150);

            double expectedTurnover = 140;

            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }
    }
}