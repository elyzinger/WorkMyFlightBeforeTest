using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class Ticket : IPoco
    {
        public Int64 ID { get; set; }
        public Int64 FlightID { get; set; }
        public Int64 CustomerID { get; set; }
        public Ticket()
        {
        }

        public Ticket(long iD, long flightID, long customerID)
        {
            ID = iD;
            FlightID = flightID;
            CustomerID = customerID;
        }

        public static bool operator ==(Ticket a, Ticket b)
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
        public static bool operator !=(Ticket a, Ticket b)
        {
            return !(a.ID == b.ID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Ticket country = obj as Ticket;
            return this.ID == country.ID;
        }

        public override int GetHashCode()
        {
            return (int)this.ID;
        }
    }
}
