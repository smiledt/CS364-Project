using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace Inventory.Database
{
    public class DBFunctions
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
        public static String User_Login(String Username, String Passwd)
        {
           // return true;

            //Create a database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT Username, Pass FROM Users",

                    Connection = conn
                };

                conn.Open();

                //Instantiate the reader
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string user = (string)reader["Username"];
                    string pass = (string)reader["Pass"];

                    Console.Write("{0,-25}", user);
                    Console.Write("{0,-20}", pass);
                }

                //Close the reader
                reader.Close();

                //Close the database connection
                conn.Close();

                return "Success!";

            }
            catch (Exception e)
            {
                return "There was an error! \n" + e.ToString();
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
                    CommandText = "INSERT INTO Users (User_ID, Username, Pass) "
                                        + "VALUES (@User_ID, @Username, @Passwd)",
                    //cmd.CommandType = System.Data.CommandType.Text;
                    Connection = conn
                };
                //conn.Open();

                cmd.Parameters.AddWithValue("@User_ID", Emp_ID);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Passwd", Passwd);

                cmd.ExecuteNonQuery();

                //close connection
                //conn.Close();

                return "User created successfully.";

            }

            catch (Exception e)
            {
                String error = e.ToString();
                return "Error: Unable to create account \n " + error;
            }
        }
    }
}