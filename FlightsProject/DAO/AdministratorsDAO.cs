using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    public class AdministratorsDAO : IAdminDAO
    {
       
        public void Add(Administrators a)
        {
          
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateAdministrators";
                cmd.Parameters.AddWithValue("@First_Name", a.First_Name);
                cmd.Parameters.AddWithValue(" @Last_Name", a.Last_Name);
                cmd.Parameters.AddWithValue(" @User_Id", a.User_Id);
                cmd.Parameters.AddWithValue(" @Level", a.Level);

                cmd.ExecuteNonQuery();

            }
        }

        public Administrators Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Administrators> GetAll()
        {
            List<Administrators> administrators = new List<Administrators>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Administrators";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            
            while (reader.Read() == true)
            {

                Administrators e = new Administrators
                {
                    First_Name = (string)reader["First_Name"],
                    Last_Name = (string)reader["Last_Name"],
                    Level = (int)reader["Level"],
                    User_Id = (int)reader["User_Id"],
                    Id = (int)reader["Id"]
                };
                administrators.Add(e);
            }
            cmd.Connection.Close();
            return administrators;
        }

        public void Remove(long id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Administrators WHERE Id={id}";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Administrators t)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Administrators SET First_Name='{t.First_Name}',Last_Name='{t.Last_Name}',Level={t.Level},User_Id={t.User_Id} WHERE Id={t.Id}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}

