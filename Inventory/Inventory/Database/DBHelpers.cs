using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory.Database
{
    public static class DBHelpers
    {
        //Some of my sql commands inject null values, which the AddWithValue command does not like very much.
        //The following method handles those injections.
        public static SqlParameter AddWithNullableValue(this SqlParameterCollection collection, String Parameter_Name, object value)
        {
            if (value == null)
                return collection.AddWithValue(Parameter_Name, DBNull.Value);
            else
                return collection.AddWithValue(Parameter_Name, value);

        }


    }
}