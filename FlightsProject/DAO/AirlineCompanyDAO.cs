using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
   public class AirlineCompanyDAO : IAirlineDAO
    {
       
        public void Add(AirlineCompany a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateAirlineCompany";
                cmd.Parameters.AddWithValue("@Name", a.Name);
                cmd.Parameters.AddWithValue(" @Country_Id", a.Country_Id);
                cmd.Parameters.AddWithValue(" @User_Id", a.User_Id);
                cmd.ExecuteNonQuery();

            }
        }

        public AirlineCompany GetAirlineByUserame(string name)
        {
            List<AirlineCompany> airlineByUsername = new List<AirlineCompany>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Name, Country_Id, User_Id) FROM Airline_Companies JOIN Users ON Users.Id = Airline_Companies.User_Id WHERE Users.Username = {name}";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);


            while (reader.Read() == true)
            {

                AirlineCompany e = new AirlineCompany
                {
                    Id = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Country_Id = (int)reader["Country_Id"],
                    User_Id = (int)reader["User_Id"],
                };
                airlineByUsername.Add(e);
            }
            cmd.Connection.Close();
            return airlineByUsername;
        }

        public IList<AirlineCompany> GetAllAirlinesByCountry(int countryId)
        {
            List<AirlineCompany> airlineByCountry = new List<AirlineCompany>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Name, Country_Id, User_Id) FROM Airline_Companies JOIN Countries ON Countries.Id = Airline_Companies.Country_Id WHERE Countries.Id = {countryId}";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);


            while (reader.Read() == true)
            {

                AirlineCompany e = new AirlineCompany
                {
                    Id = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Country_Id = (int)reader["Country_Id"],
                    User_Id = (int)reader["User_Id"],
                };
                airlineByCountry.Add(e);
            }
            cmd.Connection.Close();
            return airlineByCountry;
        }

        public AirlineCompany Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AirlineCompany> GetAll()
        {
            List<AirlineCompany> airlineCompany = new List<AirlineCompany>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM AirlineCompany";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

          
            while (reader.Read() == true)
            {

                AirlineCompany e = new AirlineCompany
                {
                    Id = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Country_Id = (int)reader["Country_Id"],
                    User_Id = (int)reader["User_Id"],
                };
                airlineCompany.Add(e);
            }
            cmd.Connection.Close();
            return airlineCompany;
        }

        public void Remove(long id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM AirlineCompany WHERE Id={id}";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(AirlineCompany t)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE AirlineCompany SET Name='{t.Name}',Country_Id={t.Country_Id},User_Id={t.User_Id} WHERE Id={t.Id}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
