using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class UserDAO : IUserDAO
    {
        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM User";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {

                var e = new
                {
                    username = reader["Username"],
                    password = reader["Password"],
                    email = reader["Email"],
                    user_Role = reader["User_Role"],
            };
                list.Add(e);
            }
            cmd.Connection.Close();
            return users;
        }
        public void Add(User a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", a.Username);
                cmd.Parameters.AddWithValue(" @Password", a.Password);
                cmd.Parameters.AddWithValue(" @Email", a.Email);
                cmd.Parameters.AddWithValue(" @User_Role", a.User_Role);
                cmd.ExecuteNonQuery();

            }
        }

        public User Get()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
