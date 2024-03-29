﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    interface ILoggedInAdministratorFacade
    {
        void CreateNewAirline(LoginToken<Administrator> token, AirLineCompany airline);
        void UpdateAirlineDetails(LoginToken<Administrator> token, AirLineCompany customer);
        void RemoveAirline(LoginToken<Administrator> token, AirLineCompany airline);
        void CreateNewCustomer(LoginToken<Administrator> token, Customer customer);
        void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer);
        void RemoveCustomer(LoginToken<Administrator> token, Customer customer);
    }
}
