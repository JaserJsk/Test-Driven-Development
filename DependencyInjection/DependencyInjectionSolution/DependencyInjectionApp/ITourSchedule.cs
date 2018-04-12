using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionApp
{
    public interface ITourSchedule
    {
        void CreateTour(string name, DateTime date, int availableSeats);

        List<Tour> GetToursFor(DateTime date);
    }
}
