using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Clear_Ouput()
        {
            lab_add_item_message.Text = "";
            lab_search_message.Text = "";
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Clear_Ouput();
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            Clear_Ouput();
            var tmp = new NotImplementedException();
            throw tmp;
        }

        //Shows the create new item table, disables search options
        protected void btn_add_item_Click(object sender, EventArgs e)
        {
            //Clear leftover output
            Clear_Ouput();

            //Disable search fields
            txt_asset_tag.Enabled = false;
            txt_serial_number.Enabled = false;
            list_model.Enabled = false;
            txt_employee.Enabled = false;
            txt_cube.Enabled = false;
            list_warehouse.Enabled = false;
            btn_search.Enabled = false;

            //Show create new item table
            tbl_add_item.Visible = true;

        }

        //Hides the create new item table, re-enables search options
        protected void btn_cancel_item_Click(object sender, EventArgs e)
        {
            //Clear leftover output
            Clear_Ouput();

            //Clear levtover create item input
            txt_new_serial.Text = "";
            txt_new_note.Text = "";
            txt_new_emp.Text = "";
            //FIND OUT HOW TO RESET DROP DOWN OPTIONS

            //Hide the create new item table
            tbl_add_item.Visible = false;

            //Re-enable search fields
            txt_asset_tag.Enabled = true;
            txt_serial_number.Enabled = true;
            list_model.Enabled = true;
            txt_employee.Enabled = true;
            txt_cube.Enabled = true;
            list_warehouse.Enabled = true;
            btn_search.Enabled = true;

        }

        protected void btn_submit_item_Click(object sender, EventArgs e)
        {
            //Clear leftover output
            Clear_Ouput();
                        
            //Perform Validation Steps
            //Serial Number not null
            if (txt_new_serial.Text.Length == 0)
            {
                lab_add_item_message.Text = "Please enter a valid serial number.";
                return;
            }

            //Employee cannot be empty and Warehouse cannot be "None"
            if(txt_new_emp.Text.Length == 0 && list_new_warehouse.Text.Equals("None"))
            {
                lab_add_item_message.Text = "An item must either reside in a warehouse or be checked out by an employee.";
                return;
            }

            //Likewise, if Employee is filled, Warehouse must be "None"
            else if(!(txt_new_emp.Text.Length ==0) && !list_new_warehouse.Text.Equals("None"))
            {
                lab_add_item_message.Text = "An item cannot be both checked out by an employee and in a warehouse simultaneously.";
                return;
            }

            //Submit by warehouse if nothing is entered in the Employee field
            else if(txt_new_emp.Text.Length == 0)
            {
                lab_add_item_message.Text = Database.DBItems.Submit_Item(
                    txt_new_serial.Text, list_new_model.Text, txt_new_note.Text, null, list_new_warehouse.Text);
                return;
            }

            //Finally, submit by employee 
            else
            {
                lab_add_item_message.Text = Database.DBItems.Submit_Item(
                    txt_new_serial.Text, list_new_model.Text, txt_new_note.Text, txt_new_emp.Text, null);
                return;
            }
            

        }

    }
}