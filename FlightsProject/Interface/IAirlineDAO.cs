using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    interface IAirlineDAO : IBasicDB<AirlineCompany>
    {
        AirlineCompany GetAirlineByUserame(string name);
        IList<AirlineCompany> GetAllAirlinesByCountry(int countryId);
    }
}
