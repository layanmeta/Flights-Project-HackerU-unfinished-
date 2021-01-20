using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class FlightDAO
    {
        public List<Flight> GetAllFlights()
        {
            List<Flight> flight = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Flights";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {

                var e = new
                {
                    ID = reader["ID"],
                    airline_Company_Id = reader["Airline_Company_Id"],
                    destination_Country_Id = reader["Departure_Time"],
                    landing_Time = reader["Landing_Time"],
                    Destination_Country_Id = reader["destination_Country_Id"],
                    remaining_Tickets = reader["Remaining_Tickets"],
                    origin_Country_Id = reader["Origin_Country_Id"],
            };
                list.Add(e);
            }
            cmd.Connection.Close();
            return flight;
        }
    }
}
