using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory.Database
{
    public class DBItems
    {
        public static String Submit_Item(String serial, String model, String note, String emp, String warehouse)
        {

            //Open database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = Properties.Resources.Submit_Item,
                    //cmd.CommandType = System.Data.CommandType.Text;
                    Connection = conn
                };
                //conn.Open();

                cmd.Parameters.AddWithValue("@Serial_Number", serial);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Note", note);
                cmd.Parameters.AddWithNullableValue("@Employee_ID", emp);
                cmd.Parameters.AddWithNullableValue("@Warehouse_ID", warehouse);

                cmd.ExecuteNonQuery();


                return "Item add successfully.";


            }

            catch (Exception e)
            {
                String error = e.ToString();
                return "Error: Unable to add item \n " + error;
            }
            //Close the connection
            finally
            {
                conn.Close();
            }


        }
    }
}