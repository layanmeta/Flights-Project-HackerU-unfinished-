using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class TicketDAO : ITicketDAO
    {
        public List<Ticket> GetAllTicket()
        {
            List<Ticket> tickets = new List<Ticket>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Tickets";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {

                var e = new
                {
                    ID = reader["ID"],
                    flight_Id = reader["Flight_Id"],
                    customer_Id = reader["Customer_Id"],
                };
                list.Add(e);
            }
            cmd.Connection.Close();
            return tickets;
        }
        public void Add(Ticket a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flight_Id", a.Flight_Id);
                cmd.Parameters.AddWithValue(" @Customer_Id", a.Customer_Id);
                cmd.ExecuteNonQuery();

            }
        }

        public Ticket Get()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket t)
        {
            throw new NotImplementedException();
        }
    }
}
