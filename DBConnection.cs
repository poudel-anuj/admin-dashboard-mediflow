using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mediflow
{
    public class DBConnection
    {
        public static string sqlstring = ConfigurationManager.ConnectionStrings["TecCon"].ToString();
        public SqlConnection con;

        public void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TecCon"].ToString();
            con = new SqlConnection(constr);

        }
    }
}