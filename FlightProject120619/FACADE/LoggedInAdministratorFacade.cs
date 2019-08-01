using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade, IFacade
    {
        /// <summary>
        /// Creates a new airline company and adds it to the table in the DB.
        /// </summary>
        public void CreateNewAirline(LoginToken<Administrator> token, AirLineCompany airline)
        {     
            if (ValidUserToken(token))
            {
                _airlineDAO.ADD(airline);
            }         
        }
        // create new customer and add it to the table
        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (ValidUserToken(token))
            {
                _customerDAO.ADD(customer);
            }
        }
        // delete an existing airline from the system
        // first delete from ticktes after that from flights and at the end from airline
        // remove from data base
        public void RemoveAirline(LoginToken<Administrator> token, AirLineCompany airline)
        {
            if (ValidUserToken(token))
            {
                //IList<Flight> flights = _flightDAO.GetAll();
                //IList<Ticket> tickets = _ticketDAO.GetAll();
                //foreach (Flight f in flights)
                //{
                //    if (f.AirLineCompanyID == airline.ID)
                //    {

                //        foreach (Ticket t in tickets)
                //        {
                //            if (t.FlightID == f.ID)
                //            {
                //                _ticketDAO.Remove(t);
                //            }

                //        }
                //        _flightDAO.Remove(f);
                //    }
                //} ANOTHER WAY BUT TO HEAVY

                _airlineDAO.Remove(airline);
            }
        
        }
        // delete an existing customer
        // first delete from ticktes after delete the customer
        // remove from data base
        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (ValidUserToken(token))
            {
                IList<Ticket> tickets = _ticketDAO.GetAll();
                foreach (Ticket t in tickets)
                {
                    if(t.CustomerID == customer.ID)
                    {
                        _ticketDAO.Remove(t);
                    }
                }
                _customerDAO.Remove(customer);
            }
        }
        //// updating the info of an airline company in the system
        // updating the table in the database
        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirLineCompany airline)
        {
            if (ValidUserToken(token))
            {
                _airlineDAO.Update(airline);
            }
        }
        // updating the info of a customer the system
        // updating the table in the database
        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            if (ValidUserToken(token))
            {
                _customerDAO.Update(customer);
            }
        }
        // cheack for real admin every func
        public bool ValidUserToken(LoginToken<Administrator> token)
        {
            if (token != null && token.User != null)
                return true;
            else
                return false;
        }
    }
}
