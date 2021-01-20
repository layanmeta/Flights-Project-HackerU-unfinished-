using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class Country : IPoco
    {
        
        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Country c1, Country c2)
        {
            return c1.Id == c2.Id;
        }

        public static bool operator !=(Country c1, Country c2)
        {
            return c1.Id == c2.Id;
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Country)obj).Id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
