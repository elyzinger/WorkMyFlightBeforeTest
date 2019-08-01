using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public interface IAirlineDAO : IBasicDB<AirLineCompany>
    {
        AirLineCompany GetAirlineByUsername(string username);
        IList<AirLineCompany> GetAllAirlineByCountry(int countryid);
    }
}
