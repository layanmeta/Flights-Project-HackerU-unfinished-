using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class User : IPoco
    {
        public User(string username, string password, string email, int user_Role)
        {
            Username = username;
            Password = password;
            Email = email;
            User_Role = user_Role;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int User_Role { get; set; }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(User u1, User u2)
        {
            return u1.Id == u2.Id;
        }

        public static bool operator !=(User u1, User u2)
        {
            return u1.Id == u2.Id;
        }


        public override bool Equals(object obj)
        {
            return this.Id == ((User)obj).Id;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
