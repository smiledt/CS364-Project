using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory.Pages
{
    public partial class AddWarehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Standard Clear_Output method
        protected void Clear_Output()
        {
            lab_add_warehouse_message.Text = "";
        }

        protected void btn_add_warehouse_Click(object sender, EventArgs e)
        {
            Clear_Output();
            
            //Perform Validation Steps
            if(txt_street_address.Text.Length == 0)
            {
                lab_add_warehouse_message.Text = "Please enter a valid street address.";
                return;
            }

            if (txt_warehouse_city.Text.Length == 0)
            {
                lab_add_warehouse_message.Text = "Please enter a valid city name.";
                return;
            }

            if (txt_warehouse_name.Text.Length == 0)
            {
                lab_add_warehouse_message.Text = "Please enter a name for the new warehouse.";
                return;
            }

            int zip_int;

            if (!(txt_zip.Text.Length ==5) || !(Int32.TryParse(txt_zip.Text, out zip_int)))
            {
                lab_add_warehouse_message.Text = "Please enter a valid, 5-digit zip code.";
                return;
            }

            //Validation Complete
            //Insert new warehouse to the database
            //First: Insert the new address
            int address_ID = Database.DBFunctions.Submit_Address(txt_street_address.Text, txt_warehouse_city.Text, list_state.SelectedValue, zip_int);
            string add_warehouse_status = Database.DBFunctions.Submit_Warehouse(txt_warehouse_name.Text, address_ID);
            lab_add_warehouse_message.Text = add_warehouse_status;
            return;
                
        }

    }
}