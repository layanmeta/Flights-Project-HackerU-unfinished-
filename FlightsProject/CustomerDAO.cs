using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class CustomerDAO
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customer = new List<Customer>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Customers";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {

                var e = new
                {
                    ID = reader["ID"],
                    first_Name = reader["First_Name"],
                    last_Name = reader["Last_Name"],
                    address = reader["Address"],
                    phone_No = reader["Phone_No"],
                    credit_Card_No = reader["Credit_Card_No"],
                    user_Id = reader["User_Id"],       
            };
                list.Add(e);
            }
            cmd.Connection.Close();
            return customer;
        }
    }
}
