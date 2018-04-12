using System;
using NUnit.Framework;
using TravelAgencyApp;

namespace TravelAgencyTests
{
    [TestFixture]
    public class TourScheduleTests
    {
        [Test]
        public void CanCreateNewTour()
        {
            var sut = new TourSchedule();
            sut.CreateTour("Safari" , new DateTime(2015, 06, 17), 20);
            var result = sut.GetToursFor(new DateTime(2015, 06, 17));
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void GetToursForGivenDayOnly()
        {
            var sut = new TourSchedule();
            sut.CreateTour("Safari", new DateTime(2015, 06, 17), 20);
            sut.CreateTour("Caribbean", new DateTime(2013, 03, 07), 6);
            sut.CreateTour("Sightseeing", new DateTime(2016, 10, 25), 12);
            var result = sut.GetToursFor(new DateTime(2015, 06, 17));
            Assert.AreEqual(1, result.Count);
        }

    }

}
