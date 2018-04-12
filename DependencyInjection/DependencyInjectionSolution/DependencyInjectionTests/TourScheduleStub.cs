using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionApp;

namespace DependencyInjectionTests
{
    class TourScheduleStub : ITourSchedule
    {
        public List<Tour> tours = new List<Tour>();

        public void CreateTour(string name, DateTime date, int availableSeats)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetToursFor(DateTime date)
        {
            return tours;
        }
    }
}
