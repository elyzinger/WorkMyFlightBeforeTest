using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619 
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade, IFacade
    {
        public IList<AirLineCompany> GetAllAirlineCompanies()
        {
            return _airlineDAO.GetAll();
        }

        public IList<Flight> GetAllFlights()
        {
            return _flightDAO.GetAll();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            return _flightDAO.GetAllFlightsVacancy();
        }

        public Flight GetFlightById(int id)
        {
            return _flightDAO.GetFlightById(id);
        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            return _flightDAO.GetFlightByDepartureDate(departureDate);
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            return _flightDAO.GetFlightByDestinationCountry(countryCode);
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            return _flightDAO.GetFlightByLandingDate(landingDate);
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            return _flightDAO.GetFlightByOriginCountry(countryCode);
        }
    }
}
