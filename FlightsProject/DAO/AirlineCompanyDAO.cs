using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class AirlineCompanyDAO : IAirlineDAO
    {
        public List<AirlineCompany> GetAllAirlineCompanies()
        {
            List<AirlineCompany> airlineCompany = new List<AirlineCompany>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM AirlineCompany";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {

                var e = new
                {
                    ID = reader["ID"],
                    name = reader["Name"],
                    country_Id = reader["Country_Id"],
                    user_Id = reader["User_Id"],
                };
                list.Add(e);
            }
            cmd.Connection.Close();
            return airlineCompany;
        }
        public void Add(AirlineCompany a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", a.Name);
                cmd.Parameters.AddWithValue(" @Country_Id", a.Country_Id);
                cmd.Parameters.AddWithValue(" @User_Id", a.User_Id);
                cmd.ExecuteNonQuery();

            }
        }

        public AirlineCompany GetAirlineByUserame(string name)
        {
            throw new NotImplementedException();
        }

        public IList<AirlineCompany> GetAllAirlinesByCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public AirlineCompany Get()
        {
            throw new NotImplementedException();
        }

        public List<AirlineCompany> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(AirlineCompany t)
        {
            throw new NotImplementedException();
        }
    }
}
