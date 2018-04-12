using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionApp;

namespace DependencyInjectionTests
{
    [TestFixture]
    public class TourScheduleTests
    {
        [Test]
        public void CanCreateNewTour()
        {
            var sut = new TourSchedule();
            sut.CreateTour("Safari", new DateTime(2015, 06, 17), 20);
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
