using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class Customer : IPoco, IUser
    {
        public Customer(string first_Name, string last_Name, string address, int credit_Card_No, int user_Id, int phone_No)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Address = address;
            Credit_Card_No = credit_Card_No;
            User_Id = user_Id;
            Phone_No = phone_No;
        }

        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Address { get; set; }

        public int Credit_Card_No { get; set; }

        public int User_Id { get; set; }

        public int Phone_No { get; set; }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Id == c2.Id;
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return c1.Id == c2.Id;
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Customer)obj).Id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
