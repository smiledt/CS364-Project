using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

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
        public static Boolean User_Login(String Username, String Passwd)
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

        public static String Submit_Item(String serial, String model, String note, String emp, String warehouse)
        {
                        
            //Open database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO Item (Serial_Number, Model, Note, Employee_ID, Warehouse_ID) "
                                        + "VALUES (@Serial_Number, @Model, @Note, @Employee_ID, @Warehouse_ID)",
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

        public int Submit_Address(String street_address, String city, String state, int zip)
        {
            //Open database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {

                //First command: Insert the address into the Addresses table 
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO Addresses (Street_Address, City, State, Zip_Code) "
                                        + "VALUES (@Street_Address, @City, @State, @Zip_Code)",
                    //cmd.CommandType = System.Data.CommandType.Text;
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@Street_Address", street_address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@Zip_Code", zip);

                cmd.ExecuteNonQuery();

                //close the connection so that it can be used again.
                conn.Close();

                //Second command: Return the auto-generated Address_ID of the address just inserted
                SqlCommand cmd2 = new SqlCommand
                {
                    CommandText = "SELECT Address_ID "
                                    + "FROM Addresses "
                                    + "WHERE Street_Address = '@Street_Address'",

                    Connection = conn
                };

                cmd2.Parameters.AddWithValue("@Street_Address", street_address);

                //Instantiate the reader
                SqlDataReader reader = cmd.ExecuteReader();
                
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

        public String Submit_Warehouse(String Warehouse_Name, int Address_ID)
        {
            //Open database connection
            SqlConnection conn = Database.ConnectToDatabase.getConnection();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO Warehouse (Warehouse_Name, Address_ID) "
                                        + "VALUES (@Warehouse_Name, @Address_ID)",
                    //cmd.CommandType = System.Data.CommandType.Text;
                    Connection = conn
                };
                //conn.Open();

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