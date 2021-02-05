using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class Administrators : IPoco, IUser
    {
        public Administrators(string first_Name, string last_Name, int level, int user_Id)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Level = level;
            User_Id = user_Id;
        }

        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public int Level { get; set; }

        public int User_Id { get; set; }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Administrators a1, Administrators a2)
        {
            return a1.Id == a2.Id;
        }

        public static bool operator !=(Administrators a1, Administrators a2)
        {
            return a1.Id == a2.Id;
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Administrators)obj).Id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }


    }
}
