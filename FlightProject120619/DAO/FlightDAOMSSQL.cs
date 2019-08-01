using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class FlightDAOMSSQL : IFlightDAO
    {
        public void ADD(Flight t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"INSERT INTO Flights(AIRLINE_COMPANY_ID, ORIGIN_COUNTRY_CODE, DESTINATION_COUNTRY_CODE, DEPARTURE_TIME, LANDING_TIME, REMANING_TICKETS)");
                sb.Append($"values ({t.AirLineCompanyID},{t.OriginCountryCode},{t.DestinationCountryCode},{t.DepartureTime},{t.LandingTime},{t.RemaniningTickets})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public Flight Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                Flight flight = new Flight();
                sb.Append($"SELECT * FROM Flights");
                sb.Append($"WHERE(ID = {id})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Flight a = new Flight
                        {
                            ID = (Int64)reader["ID"],
                            AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                            OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                            DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                            DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                            LandingTime = (DateTime)reader["LANDING_TIME"],
                            RemaniningTickets = (int)reader["REMANING_TICKETS"]

                        };


                        flight = a;
                    }
                }
                return flight;
            }
        }


        public IList<Flight> GetAll()
        {
                StringBuilder sb = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
                {
                     IList<Flight> flights = new  List<Flight>();
                    sb.Append($"SELECT * FROM Flights");
                    
                    string SQL = sb.ToString();
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Flight a = new Flight
                            {
                                ID = (Int64)reader["ID"],
                                AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                                OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                                DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                                DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                                LandingTime = (DateTime)reader["LANDING_TIME"],
                                RemaniningTickets = (int)reader["REMANING_TICKETS"]

                            };


                            flights.Add(a);
                        }
                    }
                    return flights;
                }

        }
        

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
          
            Dictionary<Flight, int> flightVacancy = new Dictionary<Flight, int>();
            IList<Flight> Flights = GetAll();
            foreach (Flight Flightitem in Flights)
            {
                flightVacancy.Add(Flightitem, Flightitem.RemaniningTickets);
            }
      
                return flightVacancy;
            
        }

        public IList<Flight> GetFlightByCustomer(Customer customer) // inner join !!!!
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Flight> flights = new List<Flight>();
                sb.Append($"SELECT * FROM Tickets");
                sb.Append($"WHERE(FLIGHT_ID  = {customer.ID}) ");

                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
   
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
        
                {
                    while (reader.Read())
                    {

                        Flight f = new Flight
                        {
                            ID = (Int64)reader["ID"],
                            AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                            OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                            DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                            DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                            LandingTime = (DateTime)reader["LANDING_TIME"],
                            RemaniningTickets = (int)reader["REMANING_TICKETS"]

                        };


                        flights.Add(f);
                    }
                }
                return flights;
            }
        }

        public IList<Flight> GetFlightByDepartureDate(DateTime departureDate)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Flight> flights = new List<Flight>();
                sb.Append($"SELECT * FROM Flights");
                sb.Append($"WHERE(DEPARTURE_TIME = {departureDate})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Flight a = new Flight
                        {
                            ID = (Int64)reader["ID"],
                            AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                            OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                            DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                            DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                            LandingTime = (DateTime)reader["LANDING_TIME"],
                            RemaniningTickets = (int)reader["REMANING_TICKETS"]

                        };


                        flights.Add(a);
                    }
                }
                return flights;
            }
        }

        public IList<Flight> GetFlightByDestinationCountry(int destinationcountry)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Flight> flights = new List<Flight>();
                sb.Append($"SELECT * FROM Flights");
                sb.Append($"WHERE(DESTINATION_COUNTRY_CODE = {destinationcountry})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Flight a = new Flight
                        {
                            ID = (Int64)reader["ID"],
                            AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                            OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                            DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                            DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                            LandingTime = (DateTime)reader["LANDING_TIME"],
                            RemaniningTickets = (int)reader["REMANING_TICKETS"]

                        };


                        flights.Add(a);
                    }
                }
                return flights;
            }
        }

        public Flight GetFlightById(int id) 
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                Flight flight = new Flight();
                sb.Append($"SELECT * FROM Flights");
                sb.Append($"WHERE(ID = {id})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Flight a = new Flight
                        {
                            ID = (Int64)reader["ID"],
                            AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                            OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                            DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                            DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                            LandingTime = (DateTime)reader["LANDING_TIME"],
                            RemaniningTickets = (int)reader["REMANING_TICKETS"]

                        };


                        flight = a;
                    }
                }
                return flight;
            }
        }

        public IList<Flight> GetFlightByLandingDate(DateTime landingDate)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Flight> flights = new List<Flight>();
                sb.Append($"SELECT * FROM Flights");
                sb.Append($"WHERE(LANDING_TIME = {landingDate})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Flight a = new Flight
                        {
                            ID = (Int64)reader["ID"],
                            AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                            OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                            DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                            DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                            LandingTime = (DateTime)reader["LANDING_TIME"],
                            RemaniningTickets = (int)reader["REMANING_TICKETS"]

                        };


                        flights.Add(a);
                    }
                }
                return flights;
            }
        }

        public IList<Flight> GetFlightByOriginCountry(int origincountry)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Flight> flights = new List<Flight>();
                sb.Append($"SELECT * FROM Flights");
                sb.Append($"WHERE(ORIGIN_COUNTRY_CODE = {origincountry})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Flight a = new Flight
                        {
                            ID = (Int64)reader["ID"],
                            AirLineCompanyID = (Int64)reader["AIRLINE_COMPANY_ID"],
                            OriginCountryCode = (Int64)reader["ORIGIN_COUNTRY_CODE"],
                            DestinationCountryCode = (Int64)reader["DESTINATION_COUNTRY_CODE"],
                            DepartureTime = (DateTime)reader["DEPARTURE_TIME"],
                            LandingTime = (DateTime)reader["LANDING_TIME"],
                            RemaniningTickets = (int)reader["REMANING_TICKETS"]

                        };


                        flights.Add(a);
                    }
                }
                return flights;
            }
        }

        public void Remove(Flight t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                sb.Append($"DELETE FROM Tickets WHERE Tickets.FLIGHT_ID = {t.ID}");
                sb.Append($"DELETE FROM Flights WHERE (ID = {t.ID} )");
                
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public void Update(Flight t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"UPDATE Flights SET AIRLINE_COMPANY_ID = {t.AirLineCompanyID}, ORIGIN_COUNTRY_CODE = {t.OriginCountryCode}, DESTINATION_COUNTRY_CODE = {t.DestinationCountryCode}, DEPARTURE_TIME = {t.DepartureTime}, LANDING_TIME = {t.LandingTime}, REMANING_TICKETS = {t.RemaniningTickets}");
                sb.Append($"WHERE(ID = {t.ID} ) ");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }
    }
}
