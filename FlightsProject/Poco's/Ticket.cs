using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class Ticket : IPoco
    {
        public Ticket(int flight_Id, int customer_Id)
        {
            Flight_Id = flight_Id;
            Customer_Id = customer_Id;
        }

        public int Id { get; set; }

        public int Flight_Id { get; set; }

        public int Customer_Id { get; set; }


        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Ticket t1, Ticket t2)
        {
            return t1.Id == t2.Id;
        }

        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return t1.Id == t2.Id;
        }


        public override bool Equals(object obj)
        {
            return this.Id == ((Ticket)obj).Id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }

}
