using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class AirLineCompany: IPoco, IUser
    {
        public Int64 ID { get; set; }
        public string AirLineName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Int64 CountryCode { get; set; }

        public AirLineCompany()
        {
        }

        public static bool operator ==(AirLineCompany a, AirLineCompany b)
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
        public static bool operator !=(AirLineCompany a, AirLineCompany b)
        {
            return !(a.ID == b.ID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            AirLineCompany country = obj as AirLineCompany;
            return this.ID == country.ID;
        }

        public override int GetHashCode()
        {
            return (int)this.ID ;
        }
    }
}
