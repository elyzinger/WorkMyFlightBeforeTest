using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class AirlineDAOMSSQL : IAirlineDAO
    {
        
        public void ADD(AirLineCompany t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
               
                sb.Append($"INSERT INTO AirlineCompanies(AIRLINE_NAME, USER_NAME, PASSWORD, COUNTRY_CODE)");
                sb.Append($"values ({t.AirLineName}, {t.UserName}, {t.Password}, {t.CountryCode})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public AirLineCompany Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                AirLineCompany airLineCompany = new AirLineCompany ();
                sb.Append($"SELECT * FROM AirlineCompanies");
                sb.Append($"WHERE(ID = {id})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
       
                        AirLineCompany a = new AirLineCompany
                        {
                            ID = (Int64)reader["ID"],
                            AirLineName = (string)reader["AIRLINE_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            CountryCode = (Int64)reader["COUNTRY_CODE"]
                            
                        };


                        airLineCompany = a;
                    }
                }
                return airLineCompany;
            }
        }

        public AirLineCompany GetAirlineByUsername(string username)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                AirLineCompany airLineCompany = new AirLineCompany();
                sb.Append($"SELECT * FROM AirlineCompanies");
                sb.Append($"WHERE(USER_NAME = {username})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        AirLineCompany a = new AirLineCompany
                        {
                            ID = (Int64)reader["ID"],
                            AirLineName = (string)reader["AIRLINE_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            CountryCode = (Int64)reader["COUNTRY_CODE"]

                        };


                        airLineCompany = a;
                    }
                }
                return airLineCompany;
            }
        }

        public IList<AirLineCompany> GetAll()
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList< AirLineCompany> airLineCompanys = new List<AirLineCompany>();
                sb.Append($"SELECT * FROM AirlineCompanies");

                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
                //using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        AirLineCompany airLineCompany = new AirLineCompany
                        {
                            ID = (Int64)reader["ID"],
                            AirLineName = (string)reader["AIRLINE_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            CountryCode = (Int64)reader["COUNTRY_CODE"]

                        };


                        airLineCompanys.Add(airLineCompany);
                    }
                }
                return airLineCompanys;
            }
        }
    

        public IList<AirLineCompany> GetAllAirlineByCountry(int countryid)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<AirLineCompany> airLineCompanys = new List<AirLineCompany>();
                sb.Append($"SELECT * FROM AirlineCompanies");
                sb.Append($"WHERE(COUNTRY_CODE = {countryid}) ");

                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default))
                //using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        AirLineCompany airLineCompany = new AirLineCompany
                        {
                            ID = (Int64)reader["ID"],
                            AirLineName = (string)reader["AIRLINE_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            CountryCode = (Int64)reader["COUNTRY_CODE"]

                        };


                        airLineCompanys.Add(airLineCompany);
                    }
                }
                return airLineCompanys;
            }
        }

        public void Remove(AirLineCompany airlinecompany)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                sb.Append($"DELETE FROM Tickets WHERE Tickets.FLIGHT_ID = (select Flights.ID from Flights WHERE Flights.AIRLINE_COMPANY_ID = {airlinecompany.ID}");
                sb.Append($"DELETE FROM Flights WHERE Flights.AIRLINE_COMPANY_ID = {airlinecompany.ID}");
                sb.Append($"DELETE FROM AirlineCompanies WHERE (ID = {airlinecompany.ID} )");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public void Update(AirLineCompany t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"UPDATE AirlineCompanies SET AIRLINE_NAME = '{t.AirLineName}', USER_NAME = '{t.UserName}', PASSWORD = '{t.Password}', COUNTRY_CODE = {t.CountryCode}");
                sb.Append($"WHERE(ID = {t.ID} ) ");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }
        public void ChangePassword(AirLineCompany airlinecompany)
        {

        }
    }
}
