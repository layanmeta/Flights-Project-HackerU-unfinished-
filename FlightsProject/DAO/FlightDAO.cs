using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
   public class FlightDAO : IFlightDAO
    {
        public void Add(Flight a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateCustomer";
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

            List<Flight> flightById = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Airline_Company_Id, Departure_Time, Landing_Time, Remaining_Tickets, Origin_Country_Id) FROM Flights WHERE Flights.Id = {id}";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {

                Flight e = new Flight
                {
                    Id = (int)reader["Id"],
                    Airline_Company_Id = (int)reader["Airline_Company_Id"],
                    Destination_Country_Id = (int)reader["Departure_Time"],
                    Landing_Time = (DateTime)reader["Landing_Time"],
                    Remaining_Tickets = (int)reader["Remaining_Tickets"],
                    Origin_Country_Id = (int)reader["Origin_Country_Id"],
                };
                flightById.Add(e);
            }
            cmd.Connection.Close();
            return flightById;
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {

            List<Flight> flightByOriginCountry = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Airline_Company_Id, Departure_Time, Landing_Time, Remaining_Tickets, Origin_Country_Id) FROM Flights WHERE Flights.Origin_Country_Id = {countryCode}";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {

                Flight e = new Flight
                {
                    Id = (int)reader["Id"],
                    Airline_Company_Id = (int)reader["Airline_Company_Id"],
                    Destination_Country_Id = (int)reader["Departure_Time"],
                    Landing_Time = (DateTime)reader["Landing_Time"],
                    Remaining_Tickets = (int)reader["Remaining_Tickets"],
                    Origin_Country_Id = (int)reader["Origin_Country_Id"],
                };
                flightByOriginCountry.Add(e);
            }
            cmd.Connection.Close();
            return flightByOriginCountry;
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            List<Flight> flightByDestinationCountry = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Airline_Company_Id, Departure_Time, Landing_Time, Remaining_Tickets, Origin_Country_Id) FROM Flights WHERE Flights.Destination_Country_Id = {countryCode}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {

                Flight e = new Flight
                {
                    Id = (int)reader["Id"],
                    Airline_Company_Id = (int)reader["Airline_Company_Id"],
                    Destination_Country_Id = (int)reader["Departure_Time"],
                    Landing_Time = (DateTime)reader["Landing_Time"],
                    Remaining_Tickets = (int)reader["Remaining_Tickets"],
                    Origin_Country_Id = (int)reader["Origin_Country_Id"],
                };
                flightByDestinationCountry.Add(e);
            }
            cmd.Connection.Close();
            return flightByDestinationCountry;
        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {

            List<Flight> flightByDepatrureDate = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Airline_Company_Id, Departure_Time, Landing_Time, Remaining_Tickets, Origin_Country_Id) FROM Flights WHERE Flights.Departure_Time = {departureDate}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {

                Flight e = new Flight
                {
                    Id = (int)reader["Id"],
                    Airline_Company_Id = (int)reader["Airline_Company_Id"],
                    Destination_Country_Id = (int)reader["Departure_Time"],
                    Landing_Time = (DateTime)reader["Landing_Time"],
                    Remaining_Tickets = (int)reader["Remaining_Tickets"],
                    Origin_Country_Id = (int)reader["Origin_Country_Id"],
                };
                flightByDepatrureDate.Add(e);
            }
            cmd.Connection.Close();
            return flightByDepatrureDate;
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            List<Flight> flightByLandingDate = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Airline_Company_Id, Departure_Time, Landing_Time, Remaining_Tickets, Origin_Country_Id) FROM Flights WHERE Flights.Landing_Time  = {landingDate}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {

                Flight e = new Flight
                {
                    Id = (int)reader["Id"],
                    Airline_Company_Id = (int)reader["Airline_Company_Id"],
                    Destination_Country_Id = (int)reader["Departure_Time"],
                    Landing_Time = (DateTime)reader["Landing_Time"],
                    Remaining_Tickets = (int)reader["Remaining_Tickets"],
                    Origin_Country_Id = (int)reader["Origin_Country_Id"],
                };
                flightByLandingDate.Add(e);
            }
            cmd.Connection.Close();
            return flightByLandingDate;
        }

        public IList<Flight> GetFlightsByCustomer(Customer customer)
        {
            List<Flight> flightByCustomer = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT (Id, Airline_Company_Id, Departure_Time, Landing_Time, Remaining_Tickets, Origin_Country_Id) FROM Flights JOIN Customers ON Customers.Id = Flights.Id WHERE Customers.Id ={customer} ";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {

                Flight e = new Flight
                {
                    Id = (int)reader["Id"],
                    Airline_Company_Id = (int)reader["Airline_Company_Id"],
                    Destination_Country_Id = (int)reader["Departure_Time"],
                    Landing_Time = (DateTime)reader["Landing_Time"],
                    Remaining_Tickets = (int)reader["Remaining_Tickets"],
                    Origin_Country_Id = (int)reader["Origin_Country_Id"],
                };
                flightByCustomer.Add(e);
            }
            cmd.Connection.Close();
            return flightByCustomer;
        }

        public Flight Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetAll()
        {

            List<Flight> flight = new List<Flight>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Flights";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {

                Flight e = new Flight
                {
                    Id = (int)reader["Id"],
                    Airline_Company_Id = (int)reader["Airline_Company_Id"],
                    Destination_Country_Id = (int)reader["Departure_Time"],
                    Landing_Time = (DateTime)reader["Landing_Time"],
                    Remaining_Tickets = (int)reader["Remaining_Tickets"],
                    Origin_Country_Id = (int)reader["Origin_Country_Id"],
                };
                flight.Add(e);
            }
            cmd.Connection.Close();
            return flight;
        }

        public void Remove(long id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Flights WHERE Id={id}";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Flight t)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Flights SET Airline_Company_Id={t.Airline_Company_Id},Destination_Country_Id={t.Destination_Country_Id},Landing_Time={t.Landing_Time},Remaining_Tickets={t.Remaining_Tickets},Origin_Country_Id={t.Origin_Country_Id} WHERE Id={t.Id}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
