using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    public class UserDAO : IUserDAO
    {
        public void Add(User a)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateUser";
                cmd.Parameters.AddWithValue("@Username", a.Username);
                cmd.Parameters.AddWithValue(" @Password", a.Password);
                cmd.Parameters.AddWithValue(" @Email", a.Email);
                cmd.Parameters.AddWithValue(" @User_Role", a.User_Role);
                cmd.ExecuteNonQuery();

            }
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {

            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM User";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            
            while (reader.Read() == true)
            {

                User e = new User
                {
                    Username = (string)reader["Username"],
                    Password = (string)reader["Password"],
                    Email = (string)reader["Email"],
                    User_Role = (int)reader["User_Role"],
                };
                users.Add(e);
            }
            cmd.Connection.Close();
            return users;
        }

        public void Remove(long id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Users WHERE Id={id}";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(User t)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Users SET Username='{t.Username}',Password='{t.Password}',Email='{t.Email}',User_Role={t.User_Role} WHERE Id={t.Id}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
