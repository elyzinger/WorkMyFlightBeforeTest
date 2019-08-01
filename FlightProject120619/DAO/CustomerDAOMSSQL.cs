using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject120619
{
    public class CustomerDAOMSSQL : ICustomerDAO
    {
        public void ADD(Customer t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"INSERT INTO Csutomres(FIRST_NAME, LAST_NAME, USER_NAME, PASSWORD, ADDRESS, PHONE_NUMBER, CREDIT_CARD_NUMBER)");
                sb.Append($"values ({t.FirstName},{t.LastName},{t.UserName},{t.Password},{t.Address},{t.PhoneNumber},{t.CreditCardNumber})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public Customer Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                Customer customer = new Customer();
                sb.Append($"SELECT * FROM Csutomres");
                sb.Append($"WHERE(ID = {id})");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Customer a = new Customer
                        {
                            ID = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            Address = (string)reader["ADDRESS"],
                            PhoneNumber = (string)reader["PHONE_NUMBER"],
                            CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"]

                        };


                        customer = a;
                    }
                }
                return customer;
            }
        }

        public IList<Customer> GetAll()
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                IList<Customer> customers = new List<Customer>();
                sb.Append($"SELECT * FROM Csutomres");

                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                //using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Customer a = new Customer
                        {
                            ID = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            Address = (string)reader["ADDRESS"],
                            PhoneNumber = (string)reader["PHONE_NUMBER"],
                            CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"]

                        };


                        customers.Add(a);
                    }
                }
                return customers;
            }
        }

        public Customer GetCustomerByUserName(string username)
        {
            Customer c = null;
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"SELECT * FROM customers WHERE USER_NAME = '{username}'");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //SqlDataReader sqlDataReader = cmd.ExecuteReader();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Customer a = new Customer
                        {

                            ID = (long)reader["ID"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Address = (string)reader["ADDRESS"],
                            PhoneNumber = (string)reader["PHONE_NO"],
                            CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"]
                        };
                    }
                }
            }

                if (c != null)
                {
                    return c;
                }
                else
                {
                    return null;
                }
      
        }
        

        public void Remove(Customer t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {
                sb.Append($"DELETE FROM Tickets WHERE Tickets.CUSTOMER_ID = {t.ID}");
                sb.Append($"DELETE FROM Customers WHERE (ID = {t.ID} )");
                
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }

        public void Update(Customer t)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.DAO_CON))
            {

                sb.Append($"UPDATE Countries SET FIRST_NAME = '{t.FirstName}',LAST_NAME = '{t.LastName}',USER_NAME = '{t.UserName}',PASSWORD = '{t.Password}',ADDRESS = '{t.Address}',PHONE_NUMBER = '{t.PhoneNumber}',CREDIT_CARD_NUMBER = '{t.CreditCardNumber}', ");

                sb.Append($"WHERE(ID = {t.ID} ) ");
                string SQL = sb.ToString();
                SqlCommand cmd = new SqlCommand(SQL, conn);
            }
        }
    }
}
