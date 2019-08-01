using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class CountryDAOMSSQL : ICountryDAO
    {
        public void ADD(Country t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"INSERT INTO Countries(COUNTRY_NAME)");
                sb.Append($"values ({t.CountryName})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public Country Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                Country country = new Country();
                sb.Append($"SELECT * FROM Countries");
                sb.Append($"WHERE(ID = {id})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Country a = new Country
                        {
                            ID = (Int64)reader["ID"],
                            CountryName = (string)reader["COUNTRY_NAME"],
                        };


                        country = a;
                    }
                }
                return country;
            }
        }

        public IList<Country> GetAll()
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                
                IList<Country> countries = new List<Country>();
                sb.Append($"SELECT * FROM Countries");
               
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Country a = new Country
                        {
                            ID = (Int64)reader["ID"],
                            CountryName = (string)reader["COUNTRY_NAME"],
                        };


                        countries.Add(a);
                    }
                }
                return countries;
            }
        }

        public void Remove(Country t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"DELETE FROM Countries");
                sb.Append($"WHERE (ID = {t.ID} )");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public void Update(Country t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"UPDATE Countries SET COUNTRY_NAME = '{t.CountryName}' ");
               
                sb.Append($"WHERE(ID = {t.ID} ) ");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }
    }
}
