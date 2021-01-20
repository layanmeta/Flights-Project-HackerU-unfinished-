using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlightsProject
{
    class ConfigApp
    {
        static public SqlConnection ConnectionString = new SqlConnection(@"Data Source=.;Initial Catalog=Project");
    }
}
