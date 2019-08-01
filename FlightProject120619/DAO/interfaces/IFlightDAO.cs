using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public interface IFlightDAO : IBasicDB<Flight>
    {
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightByCustomer(Customer customer);
        IList<Flight> GetFlightByDepartureDate(DateTime Date);
        IList<Flight> GetFlightByDestinationCountry(int destinationcountry);
        IList<Flight> GetFlightByLandingDate(DateTime date);
        IList<Flight> GetFlightByOriginCountry(int origincountry);

    }
}
