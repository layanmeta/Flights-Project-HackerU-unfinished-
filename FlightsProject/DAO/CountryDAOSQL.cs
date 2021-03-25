using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    public class CountryDAOSQL : ICountryDAO
    {
        public void Add(Country c)
        {
            //using(SqlConnection conn = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateCountry";
                cmd.Parameters.AddWithValue("@Name", c.Name);

                cmd.ExecuteNonQuery();
            }
        }

        public Country Get(int id)
        {
            Country country = new Country();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM Countries WHERE Id={id}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                country = new Country
                {
                    Name = (string)reader["Name"],
                    Id = (int)reader["Id"]
                };
            }

            cmd.Connection.Close();
            return country;
        }

        public List<Country> GetAll()
        {
            List<Country> countries = new List<Country>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Countries";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                Country c = new Country
                {
                    Name = (string)reader["Name"],
                    Id = (int)reader["Id"]
                };
                countries.Add(c);
            }

            cmd.Connection.Close();
            return countries;
        }

        public void Remove(long id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Countries WHERE Id={id}";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Country t)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Countries SET Name='{t.Name}' WHERE Id={t.Id}";

                cmd.ExecuteNonQuery();
            }
        }

    }

}
