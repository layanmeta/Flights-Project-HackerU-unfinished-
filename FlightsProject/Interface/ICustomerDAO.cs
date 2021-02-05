using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    interface ICustomerDAO :IBasicDB<Customer>
    {
        Customer GetCustomerByUserame(string name);
    }
}
