using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class AdministratorsDAO
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
    }
}

