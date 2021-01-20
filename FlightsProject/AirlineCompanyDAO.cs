using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class AirlineCompanyDAO
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
    }
}
