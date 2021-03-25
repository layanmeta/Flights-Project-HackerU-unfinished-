using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    public class AirlineCompany : IPoco, IUser
    {
        public AirlineCompany()
        {

        }
        public AirlineCompany(string name, int country_Id, long user_Id)
        {
            Name = name;
            Country_Id = country_Id;
            User_Id = user_Id;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public int Country_Id { get; set; }

        public long User_Id { get; set; }


        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(AirlineCompany a1, AirlineCompany a2)
        {
            return a1.Id == a2.Id;
        }

        public static bool operator !=(AirlineCompany a1, AirlineCompany a2)
        {
            return a1.Id == a2.Id;
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((AirlineCompany)obj).Id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
