using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class Flight : IPoco
    {
        public Int64 ID { get; set; }
        public Int64 AirLineCompanyID { get; set; }
        public Int64 OriginCountryCode { get; set; }
        public Int64 DestinationCountryCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int RemaniningTickets { get; set; }
        public Flight()
        {
        }

        public static bool operator ==(Flight a, Flight b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            if (a.ID == b.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Flight a, Flight b)
        {
            return !(a.ID == b.ID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Flight country = obj as Flight;
            return this.ID == country.ID;
        }

        public override int GetHashCode()
        {
            return (int)this.ID;
        }
    }
}
