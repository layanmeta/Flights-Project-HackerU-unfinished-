using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    interface ILoggedInAdministratorFacade
    {
        IList<Customer> GetAllCustomers(LoginToken<Administrators> token);
        void CreateNewAirline(LoginToken<Administrators> token, AirlineCompany airline);
        void UpdateAirlineDetails(LoginToken<Administrators> token, AirlineCompany customer);
        void RemoveAirline(LoginToken<Administrators> token, AirlineCompany airline);
        void CreateNewCustomer(LoginToken<Administrators> token, Customer customer);
        void UpdateCustomerDetails(LoginToken<Administrators> token, Customer customer);
        void RemoveCustomer(LoginToken<Administrators> token, Customer customer);
        void CreateAdmin(LoginToken<Administrators> token, Administrators admin);
        void UpdateAdmin(LoginToken<Administrators> token, Administrators admin);
        void RemoveAdmin(LoginToken<Administrators> token, Administrators admin);
    }
}
