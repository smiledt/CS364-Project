<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWarehouse.aspx.cs" Inherits="Inventory.Pages.AddWarehouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a Warehouse</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 30px">
            <h1>Add a Warehouse</h1>
            <table>
               <tr>
                    <td>Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_warehouse_name" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Street Address:
                    </td>
                    <td style="margin-left: 40px">
                        <asp:TextBox ID="txt_street_address" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>City:
                    </td>
                    <td style="margin-left: 40px">
                        <asp:TextBox ID="txt_warehouse_city" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <!-- Change this one - Needs to be a dropdown, not a text box -->
                <tr>
                    <td>State:
                    </td>
                    <td style="margin-left: 40px">
                        <asp:DropDownList ID="list_state" runat="server">
	                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
	                        <asp:ListItem Value="AK">Alaska</asp:ListItem>
	                        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
	                        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
	                        <asp:ListItem Value="CA">California</asp:ListItem>
	                        <asp:ListItem Value="CO">Colorado</asp:ListItem>
	                        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
	                        <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	                        <asp:ListItem Value="DE">Delaware</asp:ListItem>
	                        <asp:ListItem Value="FL">Florida</asp:ListItem>
	                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
	                        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
	                        <asp:ListItem Value="ID">Idaho</asp:ListItem>
	                        <asp:ListItem Value="IL">Illinois</asp:ListItem>
	                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
	                        <asp:ListItem Value="IA">Iowa</asp:ListItem>
	                        <asp:ListItem Value="KS">Kansas</asp:ListItem>
	                        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
	                        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
	                        <asp:ListItem Value="ME">Maine</asp:ListItem>
	                        <asp:ListItem Value="MD">Maryland</asp:ListItem>
	                        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
	                        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
	                        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
	                        <asp:ListItem Value="MO">Missouri</asp:ListItem>
	                        <asp:ListItem Value="MT">Montana</asp:ListItem>
	                        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
	                        <asp:ListItem Value="NV">Nevada</asp:ListItem>
	                        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	                        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	                        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
	                        <asp:ListItem Value="NY">New York</asp:ListItem>
	                        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
	                        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
	                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
	                        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	                        <asp:ListItem Value="OR">Oregon</asp:ListItem>
	                        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	                        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	                        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
	                        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
	                        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
	                        <asp:ListItem Value="TX">Texas</asp:ListItem>
	                        <asp:ListItem Value="UT">Utah</asp:ListItem>
	                        <asp:ListItem Value="VT">Vermont</asp:ListItem>
	                        <asp:ListItem Value="VA">Virginia</asp:ListItem>
	                        <asp:ListItem Value="WA">Washington</asp:ListItem>
	                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
	                        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	                        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Zip Code:
                    </td>
                    <td style="margin-left: 40px">
                        <asp:TextBox ID="txt_zip" runat="server" MaxLength="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td />
                    <td>
                        <asp:Button ID="btn_submit_warehouse" runat="server" Text="Submit Warehouse" OnClick="btn_submit_warehouse_Click" Class="btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lab_add_warehouse_message" runat="server" Style="color: red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
