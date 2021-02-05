using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class CustomerDAO : ICustomerDAO
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
        public void Add(Customer a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@First_Name", a.First_Name);
                cmd.Parameters.AddWithValue(" @Last_Name", a.Last_Name);
                cmd.Parameters.AddWithValue(" @Address", a.Address);
                cmd.Parameters.AddWithValue(" @Credit_Card_No", a.Credit_Card_No);
                cmd.Parameters.AddWithValue(" @User_Id", a.User_Id);
                cmd.Parameters.AddWithValue(" @Phone_No", a.Phone_No);

                cmd.ExecuteNonQuery();

            }
        }

        public Customer GetCustomerByUserame(string name)
        {
            throw new NotImplementedException();
        }

        public Customer Get()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
