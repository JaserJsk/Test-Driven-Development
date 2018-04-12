using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionApp
{
    public class Booking
    {
        public Tour TourObject { get; set; }

        public Passenger PassengerObject { get; set; }
    }

    public class Passenger
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class BookingSystem
    {
        private ITourSchedule tourSchedule;
        private List<Booking> bookings = new List<Booking>();

        public BookingSystem(ITourSchedule tourSchedule)
        {
            this.tourSchedule = tourSchedule;
        }

        public List<Booking> GetBookingsFor(Passenger passenger)
        {
            return bookings.Where(b => b.PassengerObject == passenger).ToList();
        }

        public void CreateBooking(string name , DateTime date , Passenger passenger)
        {
            var tour = tourSchedule.GetToursFor(date).FirstOrDefault(x => x.TourName == name);
            var bookingCount = bookings.Count(b => b.TourObject == tour);
            if (tour == null || tour.TourAvailableSeats == bookingCount)
            {
                throw new NoTourExistsEception();
            }

            Booking newBooking = new Booking
            {
                TourObject = tour,
                PassengerObject = passenger,
            };
            bookings.Add(newBooking);
        }
    }
}
