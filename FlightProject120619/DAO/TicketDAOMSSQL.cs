using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class TicketDAOMSSQL : ITicketDAO
    {
        public void ADD(Ticket t)
        {
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"INSERT INTO Tickets(FLIGHT_ID, CUSTOMER_ID)");
                sb.Append($"values({ t.FlightID}, { t.CustomerID})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public Ticket Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                Ticket ticket = new Ticket();
                sb.Append($"SELECT * FROM Tickets");
                sb.Append($"WHERE(ID = {id})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Ticket a = new Ticket
                        {
                            ID = (Int64)reader["ID"],
                            FlightID = (Int64)reader["FLIGHT_ID"],
                            CustomerID = (Int64)reader["CUSTOMER_ID"]
                        };


                        ticket = a;
                    }
                }
                return ticket;
            }
        }

        public IList<Ticket> GetAll()
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Ticket> alltickets = new List<Ticket>();
                Ticket ticket = new Ticket();
                sb.Append($"SELECT * FROM Tickets");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Ticket a = new Ticket
                        {
                            ID = (Int64)reader["ID"],   
                            FlightID = (Int64)reader["FLIGHT_ID"],
                            CustomerID = (Int64)reader["CUSTOMER_ID"]
                        };


                        alltickets.Add(a);
                    }
                }
                return alltickets;
            }
        }

        public IList<Ticket> GetTicketByAirlineID(Int64 airLineCompanyID)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Ticket> airlineTickets = new List<Ticket>();
                Ticket ticket = new Ticket();
                sb.Append($"SELECT * FROM Tickets WHERE FLIGHT_ID IN (SELECT ID FROM Flights WHERE Flights.AIRLINE_COMPANY_ID = {airLineCompanyID})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Ticket a = new Ticket
                        {
                            ID = (Int64)reader["ID"],
                            FlightID = (Int64)reader["FLIGHT_ID"],
                            CustomerID = (Int64)reader["CUSTOMER_ID"]
                        };


                        airlineTickets.Add(a);
                    }
                }
                return airlineTickets;
            }
        }

        public void Remove(Ticket t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"DELETE FROM Tickets");
                sb.Append($"WHERE (ID = {t.ID} )");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public void Update(Ticket t)
        {

            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"UPDATE Tickets SET FLIGHT_ID = {t.FlightID}, CUSTOMER_ID = {t.CustomerID} ");

                sb.Append($"WHERE(ID = {t.ID} ) ");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }
    }
}
