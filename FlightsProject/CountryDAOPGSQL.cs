using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class CountryDAOPGSQL : ICountryDAO
    {
        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Countries";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
              
                var e = new
                {
                    name_Country = reader["Name"],
                    Id_Country = reader["Id"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return countries;
        }
        public void Add(Country c)
        {

        }

        public Country Get()
        {
            throw new NotImplementedException();
        }

        public List<Country> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Country t)
        {
            throw new NotImplementedException();
        }

    }

}
