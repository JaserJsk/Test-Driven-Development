using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionApp
{
    public class Tour
    {
        public string TourName { get; set; }

        public DateTime TourDate { get; set; }

        public int TourAvailableSeats { get; set; }
    }

    public class TourSchedule : ITourSchedule
    {
        private List<Tour> tours = new List<Tour>();

        public void CreateTour(string name, DateTime date, int availableSeats)
        {
            Tour newTour = new Tour
            {
                TourName = name,
                TourDate = date,
                TourAvailableSeats = availableSeats,
            };
            tours.Add(newTour);
        }

        public List<Tour> GetToursFor(DateTime date)
        {
            return tours.Where(t => t.TourDate == date).ToList();
        }
    }
}
