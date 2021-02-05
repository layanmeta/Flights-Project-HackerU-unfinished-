using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class AdministratorsDAO : IAdminDAO
    {
        public List<Administrators> GetAllAdmins()
        {
            List<Administrators> administrators = new List<Administrators>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConfigApp.ConnectionString;
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Administrators";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {

                var e = new
                {
                    ID = reader["ID"],
                    User_Id = reader["User_Id"]
                };
                list.Add(e);
            }
            cmd.Connection.Close();
            return administrators;
        }
        public void Add(Administrators a)
        {
          
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = ConfigApp.ConnectionString;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@First_Name", a.First_Name);
                cmd.Parameters.AddWithValue(" @Last_Name", a.Last_Name);
                cmd.Parameters.AddWithValue(" @User_Id", a.User_Id);
                cmd.Parameters.AddWithValue(" @Level", a.Level);

                cmd.ExecuteNonQuery();

            }
        }

        public Administrators Get()
        {
            throw new NotImplementedException();
        }

        public List<Administrators> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Administrators t)
        {
            throw new NotImplementedException();
        }
    }
}

