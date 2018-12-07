using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory.Database
{
    public class DBWarehouse
    {
        public static int Submit_Address(String street_address, String city, String state, int zip)
        {
            //Open database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {

                //First command: Insert the address into the Addresses table 
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = Properties.Resources.Submit_Address,
                    
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@Street_Address", street_address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@Zip_Code", zip);

                cmd.ExecuteNonQuery();

                //close the connection so that it can be used again.

                //Second command: Return the auto-generated Address_ID of the address just inserted
                SqlCommand cmd2 = new SqlCommand
                {
                    CommandText = Properties.Resources.Select_Address,

                    Connection = conn
                };

                cmd2.Parameters.AddWithValue("@Street_Address", street_address);

                //Instantiate the reader
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    //Instantiate local variables
                    int tmp_ID;

                    //Parse the returned collumn to tmp_ID 
                    Int32.TryParse(reader["Address_ID"].ToString(), out tmp_ID);

                    //Close the reader, then the connection, then return the Warehouse_ID;
                    reader.Close();
                    conn.Close();
                    return tmp_ID;
                }
                return -1;
            }

            catch (Exception e)
            {
                //String for debugging, will not be used. 
                String error = e.ToString();

                return -1;
            }
            //Close the connection
            finally
            {
                conn.Close();
            }
        }

        public static String Submit_Warehouse(String Warehouse_Name, int Address_ID)
        {
            //Open database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = Properties.Resources.Submit_Warehouse,
                    
                    Connection = conn
                };
                //conn.Open();
                //The connection is already open?

                cmd.Parameters.AddWithValue("@Warehouse_Name", Warehouse_Name);
                cmd.Parameters.AddWithValue("@Address_ID", Address_ID);

                cmd.ExecuteNonQuery();


                return "Warehouse added successfully.";


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