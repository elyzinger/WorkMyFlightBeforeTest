using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public interface ITicketDAO : IBasicDB<Ticket>
    {
        IList<Ticket> GetTicketByAirlineID(Int64 airLineCompanyID);
    }
}
