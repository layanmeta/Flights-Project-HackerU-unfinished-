using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    interface ILoginService
    {
        bool TryLogin(string userName, string password, out LoginToken<IUser> token);
    }
}
