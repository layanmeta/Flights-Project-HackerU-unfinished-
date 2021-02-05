using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class FlightDAO : IFlightDAO
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
        public void Add(Flight a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Airline_Company_Id", a.Airline_Company_Id);
                cmd.Parameters.AddWithValue(" @Destination_Country_Id", a.Destination_Country_Id);
                cmd.Parameters.AddWithValue(" @Departure_Time", a.Departure_Time);
                cmd.Parameters.AddWithValue(" @Landing_Time", a.Landing_Time);
                cmd.Parameters.AddWithValue(" @Remaining_Tickets", a.Remaining_Tickets);
                cmd.Parameters.AddWithValue(" @Origin_Country_Id", a.Origin_Country_Id);

                cmd.ExecuteNonQuery();

            }
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Flight Get()
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight t)
        {
            throw new NotImplementedException();
        }
    }
}
