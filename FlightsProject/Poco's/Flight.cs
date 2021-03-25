using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    public class Flight : IPoco
    {
        public Flight()
        {

        }
        public Flight(int airline_Company_Id, int destination_Country_Id, DateTime departure_Time, DateTime landing_Time, int remaining_Tickets, int origin_Country_Id)
        {
            Airline_Company_Id = airline_Company_Id;
            Destination_Country_Id = destination_Country_Id;
            Departure_Time = departure_Time;
            Landing_Time = landing_Time;
            Remaining_Tickets = remaining_Tickets;
            Origin_Country_Id = origin_Country_Id;
        }

        public int Id { get; set; }

        public int Airline_Company_Id { get; set; }

        public int Destination_Country_Id { get; set; }

        public DateTime Departure_Time { get; set; }

        public DateTime Landing_Time { get; set; }

        public int Remaining_Tickets { get; set; }

        public int Origin_Country_Id { get; set; }


        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Flight f1, Flight f2)
        {
            return f1.Id == f2.Id;
        }

        public static bool operator !=(Flight f1, Flight f2)
        {
            return f1.Id == f2.Id;
        }


        public override bool Equals(object obj)
        {
            return this.Id == ((Flight)obj).Id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
