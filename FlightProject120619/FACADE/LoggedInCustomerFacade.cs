using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    
    class LoggedInCustomerFacade : AnonymousUserFacade,ILoggedInCustomerFacade, IFacade 
    {
        // delete all tickets for customer in database
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (ValidUserToken(token))
            {
                _ticketDAO.Remove(ticket);
            }
        }
        // get a list of all the customer flights
        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token )
        {
            IList<Flight> customerflights = new List<Flight>();
            if (ValidUserToken(token))
            {
                customerflights =  _flightDAO.GetFlightByCustomer(token.User);
                
            }
            return customerflights;
        }
        // create a new ticket on database
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            Ticket ticket = null;
            if (ValidUserToken(token))
            {
                if (flight.RemaniningTickets > 0)
                {
                    ticket = new Ticket()
                    {
                        FlightID = flight.ID,
                        CustomerID = token.User.ID
                    };
                    _ticketDAO.ADD(ticket);
                    flight.RemaniningTickets--;
                    return ticket;
                }
                throw new NoMoreTicketsException("no more tickets left");
            }
            return ticket;
            
        }
        // cheack for real customer every func
        public bool ValidUserToken(LoginToken<Customer> token)
        {
            if (token != null && token.User != null)
                return true;
            else
                return false;
        }
    }
}
