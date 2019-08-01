using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade, IFacade
    {
        // delete a flight from data base and his tickets
        public void CancelFlight(LoginToken<AirLineCompany> token, Flight flight)
        {
            if (ValidUserToken(token))
            {
                //IList<Ticket> tickets = _ticketDAO.GetAll();
                //foreach (Ticket t in tickets)
                //{
                //    if (t.FlightID == flight.ID)
                //    {
                //        _ticketDAO.Remove(t);
                //    }
                //} ANOTHER WAY BUT TO HEAVY
                _flightDAO.Remove(flight);
            }
        }
        // change the password in the database
        public void ChangeMyPassword(LoginToken<AirLineCompany> token, string oldPassword, string newPassword)
        {
            
            if (ValidUserToken(token) && oldPassword == token.User.Password)
            {
             
                token.User = new AirLineCompany()
                {
                    AirLineName = token.User.AirLineName,
                    UserName = token.User.UserName,
                    Password = newPassword.ToUpper(),
                    CountryCode = token.User.CountryCode
                };
                _airlineDAO.Update(token.User);

            }
       
        }
        // create a new flight for airline in db
        public void CreateFlight(LoginToken<AirLineCompany> token, Flight flight)
        {
            if (ValidUserToken(token))
            {
                _flightDAO.ADD(flight);
            }
        }
        // get all airline flights from db
        public IList<Flight> GetAllFlights(LoginToken<AirLineCompany> token)
        {

            IList<Flight> allFlights = new List<Flight>();
            IList<Flight> companyFlights = new List<Flight>();
            if (ValidUserToken(token))
            {
                {
                    allFlights = _flightDAO.GetAll();
                    foreach (Flight f in allFlights)
                    {
                        if (token.User.ID == f.AirLineCompanyID)
                        {
                            companyFlights.Add(f);
                        }
                    }
                }
            }
            return companyFlights;
        }
        // get all airline tickets from db
        public IList<Ticket> GetAllTickets(LoginToken<AirLineCompany> token)
        {
           
            IList<Ticket> companyTickets = new List<Ticket>();
            if (ValidUserToken(token))
            {
                companyTickets = _ticketDAO.GetTicketByAirlineID(token.User.ID);
            }
            return companyTickets;
        }
        //// update airline details in db
        public void MofidyAirlineDetails(LoginToken<AirLineCompany> token, AirLineCompany airline)
        {
            if (ValidUserToken(token))
            {
                _airlineDAO.Update(airline);
            }
        }
        // update flight for airline in db
        public void UpdateFlight(LoginToken<AirLineCompany> token, Flight flight)
        {
            if (ValidUserToken(token))
            {
                _flightDAO.Update(flight);
            }
            
        }
        // cheack for real airline every func
        public bool ValidUserToken(LoginToken<AirLineCompany> token)
        {
            if (token != null && token.User != null)
                return true;
            else
                return false;
        }
    }
}
