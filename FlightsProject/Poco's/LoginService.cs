using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class LoginService :ILoginService
    {
        private IAirlineDAO _arilineDAO;
        private ICustomerDAO _customerDAO;
        private IAdminDAO adminDAO;

        public bool TryLogin(string userName, string password, out LoginToken<IUser> token)
        {
            throw new NotImplementedException();
        }
    }
}
