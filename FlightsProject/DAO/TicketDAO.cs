using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class TicketDAO : ITicketDAO
    {
     
        public void Add(Ticket a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateTicket";
                cmd.Parameters.AddWithValue("@Flight_Id", a.Flight_Id);
                cmd.Parameters.AddWithValue(" @Customer_Id", a.Customer_Id);
                cmd.ExecuteNonQuery();

            }
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAll()
        {

            List<Ticket> tickets = new List<Ticket>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Tickets";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);       
            while (reader.Read() == true)
            {

                Ticket e = new Ticket
                {
                    Id = (int)reader["Id"],
                    Flight_Id = (int)reader["Flight_Id"],
                    Customer_Id = (int)reader["Customer_Id"],
                };
                tickets.Add(e);
            }
            cmd.Connection.Close();
            return tickets;
        }

        public void Remove(long id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Flights Tickets Id={id}";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Ticket t)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Tickets SET Flight_Id={t.Flight_Id},Customer_Id={t.Customer_Id}WHERE Id={t.Id}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
