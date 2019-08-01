using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    interface ILoggedInAirlineFacade
    {
        IList<Ticket> GetAllTickets(LoginToken<AirLineCompany> token);
        IList<Ticket> GetAllFlights(LoginToken<AirLineCompany> token);
        void CancelFlight(LoginToken<AirLineCompany> token, Flight flight);
        void CreateFlight(LoginToken<AirLineCompany> token, Flight flight);
        void UpdateFlight(LoginToken<AirLineCompany> token, Flight flight);
        void ChangeMyPassword(LoginToken<AirLineCompany> token, string oldPassword, string newPassword);
        void MofidyAirlineDetails(LoginToken<AirLineCompany> token, AirLineCompany airline);
    }
}
