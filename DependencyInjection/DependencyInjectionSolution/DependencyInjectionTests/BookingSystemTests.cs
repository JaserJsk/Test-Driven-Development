using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DependencyInjectionApp;

namespace DependencyInjectionTests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub tourScheduleStub;
        private BookingSystem sut;

        [SetUp]
        public void BookingSystem()
        {
            tourScheduleStub = new TourScheduleStub();
            sut = new BookingSystem(tourScheduleStub);
        }
        [Test]
        public void CanCreateBooking()
        {
            tourScheduleStub.tours = new List<Tour>
            {
                new Tour{TourName = "Safari", TourDate = new DateTime(2015, 06, 17), TourAvailableSeats = 1},
            };

            Passenger passenger = new Passenger();
            passenger.FirstName = "Indiana";
            passenger.LastName = "Jones";

            sut.CreateBooking(tourScheduleStub.tours[0].TourName, new DateTime(2015, 06, 17) , passenger);
            var result = sut.GetBookingsFor(passenger);
            Assert.AreEqual(1 , result.Count);
            Assert.AreEqual(tourScheduleStub.tours[0], result[0].TourObject);
            Assert.AreEqual(passenger, result[0].PassengerObject);
        }
        [Test]
        public void CanNotCreateBooking()
        {
            tourScheduleStub.tours = new List<Tour>
            {
                //new Tour{TourName = "Safari", TourDate = new DateTime(2015, 06, 17), TourAvailableSeats = 1},
            };

            Passenger passenger = new Passenger();
            passenger.FirstName = "Indiana";
            passenger.LastName = "Jones";

            Assert.Throws<NoTourExistsEception>(() =>
            {
                sut.CreateBooking("Safari", new DateTime(2015, 06, 17) , passenger);
            });
 
        }
        [Test]
        public void NotEnoughSeats()
        {
            tourScheduleStub.tours = new List<Tour>
            {
                new Tour{TourName = "Safari", TourDate = new DateTime(2015, 06, 17), TourAvailableSeats = 1},
            };

            Passenger passenger1 = new Passenger();
            passenger1.FirstName = "Indiana";
            passenger1.LastName = "Jones";

            Passenger passenger2 = new Passenger();
            passenger2.FirstName = "Mary";
            passenger2.LastName = "Jane";

            sut.CreateBooking("Safari", new DateTime(2015, 06, 17), passenger1);

            Assert.Throws<NoTourExistsEception>(() =>
            {
                sut.CreateBooking("Safari", new DateTime(2015, 06, 17), passenger2);
            });

        }

    }
}
