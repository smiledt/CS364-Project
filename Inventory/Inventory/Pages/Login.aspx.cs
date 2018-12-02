using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Database.ConnectToDatabase.getConnection();
            }
        }

        //Sends login info to the database and checks for the email/password combination
        protected void btn_login_Click(object sender, EventArgs e)
        {
            //Clear any leftover output
            lab_login_message.Text = "";
            lab_sign_up_message.Text = "";

            //Sends login info to database and checks for the email/password combination
            if (Database.DBFunctions.User_Login(txt_username.Text, txt_password.Text))
            {
                lab_login_message.Text = "Login Successful.";
                Response.Redirect("Search.aspx");
            }
            else
                lab_login_message.Text = "Login failed.";

        }


        //Shows the create account fields, deactivates the login fields
        protected void btn_create_account_Click(object sender, EventArgs e)
        {
            //Clear any leftover output
            lab_login_message.Text = "";
            lab_sign_up_message.Text = "";

            txt_password.Enabled = false;
            btn_login.Enabled = false;
            btn_create_account.Visible = false;

            //Finally, show the account creation "table."
            tbl_create_account.Visible = true;
        }

        //Attempts to create the account (add it to the database)
        //If it fails, return an error message. 
        protected void btn_submit_account_Click(object sender, EventArgs e)
        {
            //Clear any leftover output
            lab_login_message.Text = "";
            lab_sign_up_message.Text = "";

            //Validate Employee ID field
            if(txt_employee_id.Text.Length != 8)
            {
                lab_sign_up_message.Text = "Please enter your 8-digit Employee ID.";
                return;
            }

            //Validate Desired Password field
            if (txt_new_password.Text.Length == 0)
            {
                lab_sign_up_message.Text = "Please enter your desired password.";
                return;
            }

            //Validate Confirm Password field and check to make sure the two passwords match
            if(!txt_new_password.Text.Equals(txt_confirm_password.Text))
            {
                lab_sign_up_message.Text = "The passwords do not match.";
                return;
            }

            //All Validation Steps complete. 

            String create_status = Database.DBFunctions.Create_User(txt_employee_id.Text, txt_new_username.Text, txt_new_password.Text);
            lab_sign_up_message.Text = create_status;
        }
    }
}