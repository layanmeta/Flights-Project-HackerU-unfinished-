using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
   public class CustomerDAO : ICustomerDAO
    {
        public void Add(Customer a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateCustomer";
                cmd.Parameters.AddWithValue("@First_Name", a.First_Name);
                cmd.Parameters.AddWithValue(" @Last_Name", a.Last_Name);
                cmd.Parameters.AddWithValue(" @Address", a.Address);
                cmd.Parameters.AddWithValue(" @Credit_Card_No", a.Credit_Card_No);
                cmd.Parameters.AddWithValue(" @User_Id", a.User_Id);
                cmd.Parameters.AddWithValue(" @Phone_No", a.Phone_No);

                cmd.ExecuteNonQuery();

            }
        }

        public Customer GetCustomerByUsername(string name)
        {

            List<Customer> CustomerByUsername = new List<Customer>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, First_Name, Last_Name, Address, Phone_No, Credit_Card_No, User_Id) FROM CustomersJOIN Users ON Users.Id = Customers.User_Id WHERE Users.Username = {name}";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);


            while (reader.Read() == true)
            {

                Customer e = new Customer
                {
                    Id = (int)reader["Id"],
                    First_Name = (string)reader["First_Name"],
                    Last_Name = (string)reader["Last_Name"],
                    Address = (string)reader["Address"],
                    Phone_No = (int)reader["Phone_No"],
                    Credit_Card_No = (int)reader["Credit_Card_No"],
                    User_Id = (int)reader["User_Id"],
                };
                CustomerByUsername.Add(e);
            }
            cmd.Connection.Close();
            return CustomerByUsername;
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {

            List<Customer> customer = new List<Customer>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Customers";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            
            while (reader.Read() == true)
            {

                Customer e = new Customer
                {
                    Id = (int)reader["Id"],
                    First_Name = (string)reader["First_Name"],
                    Last_Name = (string)reader["Last_Name"],
                    Address = (string)reader["Address"],
                    Phone_No = (int)reader["Phone_No"],
                    Credit_Card_No = (int)reader["Credit_Card_No"],
                    User_Id = (int)reader["User_Id"],
                };
                customer.Add(e);
            }
            cmd.Connection.Close();
            return customer;
        }

        public void Remove(long id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Customers WHERE Id={id}";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Customer t)
        {
           using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Customers SET First_Name='{t.First_Name}',Last_Name='{t.Last_Name}',Address='{t.Address}',Phone_No={t.Phone_No},Credit_Card_No={t.Credit_Card_No},User_Id={t.User_Id} WHERE Id={t.Id}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
