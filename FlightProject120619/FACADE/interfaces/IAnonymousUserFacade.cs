using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    interface IAnonymousUserFacade 
    {
        IList<Flight> GetAllFlights();
        IList<AirLineCompany> GetAllAirlineCompanies();
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(int countryCode);
        IList<Flight> GetFlightsByDestinationCountry(int countryCode);
        IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingDate(DateTime landingDate);
    }
}
