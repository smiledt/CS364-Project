using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace Inventory.Database
{
    public class DBUsers
    {
        
        /*
         * Method to log the user into the Inventory system via the database.
         * 
         * Input: Username, Passwd
         * 
         * Function: The method will query the database, and return true if the username both the username and password match a tuple
         * Otherwise the method will return false
         * 
         * Output: a local session boolean with the login status?
         */
        public static Boolean User_Login(String Username, String Passwd)
        {
           // return true;

            //Create a database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = Properties.Resources.Select_User,

                    Connection = conn
                };

                
                //Instantiate the reader
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    //Instantiate local variables
                    String tmp_username = reader["Username"].ToString();
                    String tmp_passwd = reader["Pass"].ToString();

                    if(Username.Equals(tmp_username) && Passwd.Equals(tmp_passwd))
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }


                    //System.Diagnostics.Debug.WriteLine(Convert.ToString(reader[0]));
                    //System.Diagnostics.Debug.WriteLine("TEST!");
                }
                
                //Close the reader
                reader.Close();

                return false;

            }
            catch (Exception e)
            {
                return false;
            }

            //Close the connection
            finally
            {
                conn.Close();
            }

        }

        /* 
         * Method to insert a new user into the database.
         * 
         * Input: Employee_ID, Username, Passwd
         * 
         * Output: Either a success or failure string
         */         
        public static string Create_User(String Employee_ID, String Username, String Passwd)
        {

            //Parse Employee_ID to INT
            int Emp_ID;
        if (Int32.TryParse(Employee_ID, out int Tmp_ID))
            Emp_ID = Tmp_ID;
        else
            return "Invalid Employee ID";

        //Create a database connection
        SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = Properties.Resources.Select_User,
                    Connection = conn
                };
                //conn.Open();

                cmd.Parameters.AddWithValue("@User_ID", Emp_ID);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Passwd", Passwd);

                cmd.ExecuteNonQuery();

                
                return "User created successfully.";

            }

            catch (Exception e)
            {
                String error = e.ToString();
                return "Error: Unable to create account \n " + error;
            }

            //Close the connection
            finally
            {
                conn.Close();
            }
        }

    }
}