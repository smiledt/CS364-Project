/*
 *  Author: Derek Smiley 
 *  This class will connect to the SQL database
 *  and return a SQL Connection object which is open.
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory.Database
{
    public static class ConnectToDatabase
    {
        public static SqlConnection getConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["cs364ConnectionString"].ConnectionString;
                conn.Open();
                return conn;
            } catch(Exception e)
            {
                e.ToString(); //for debugger.
                return null;
            }
        }
    }
}