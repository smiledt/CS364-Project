<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Inventory.Pages.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inventory Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 30px">
            <h1>Item Search</h1>
            <table cellspacing="10px" >
                <tr> 
                    <td> Asset Tag:
                        <asp:TextBox ID="txt_asset_tag" runat="server" MaxLength="8"></asp:TextBox>
                    </td>
                    <td style="padding-left: 30px">Serial Number:
                        <asp:TextBox ID="txt_serial_number" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="padding-left: 30px">Model:<asp:DropDownList ID="list_model" runat="server">
                        <asp:ListItem>Monitor</asp:ListItem>
                        <asp:ListItem>Laptop</asp:ListItem>
                        <asp:ListItem>Desktop</asp:ListItem>
                        <asp:ListItem>Docking Station</asp:ListItem>
                        <asp:ListItem>Printer</asp:ListItem>
                        <asp:ListItem>Phone</asp:ListItem>
                        </asp:DropDownList>
                    </td> 
                </tr>

                <tr>
                   <td>Employee:
                        <asp:TextBox ID="txt_employee" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="padding-left: 85px">Cube:
                        <asp:TextBox ID="txt_cube" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="padding-left: 30px">Warehouse: 
                        <asp:DropDownList ID="list_warehouse" runat="server" DataSourceID="SqlDataSource1" DataTextField="Warehouse_Name" DataValueField="Warehouse_Name">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <p>
                <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click" />
            </p>
            <p>
                <br />
                <asp:LinkButton ID="btn_add_item" runat="server" OnClick="btn_add_item_Click" Class="btn">Add a new item</asp:LinkButton>
            </p>
            <asp:Label ID="lab_search_message" runat="server" style="color: red"></asp:Label>

            <!-- ADD ITEM fields start here -->

            <asp:Table ID="tbl_add_item" runat="server" Visible="false" CellSpacing="20">
                <asp:TableRow>
                    <asp:TableCell>Serial Number:
                        <asp:TextBox ID="txt_new_serial" runat="server" MaxLength="50"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>Model:
                        <asp:DropDownList ID="list_new_model" runat="server">
                            <asp:ListItem>Monitor</asp:ListItem>
                            <asp:ListItem>Laptop</asp:ListItem>
                            <asp:ListItem>Desktop</asp:ListItem>
                            <asp:ListItem>Docking Station</asp:ListItem>
                            <asp:ListItem>Printer</asp:ListItem>
                            <asp:ListItem>Phone</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>Notes:
                        <asp:TextBox ID="txt_new_note" runat="server" MaxLength="255"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Employee:
                        <asp:TextBox ID="txt_new_emp" runat="server" MaxLength="255"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>Warehouse:
                        <asp:DropDownList ID="list_new_warehouse" runat="server" DataSourceID="SqlDataSource1" DataTextField="Warehouse_Name" DataValueField="Warehouse_Name">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button ID="btn_cancel_item" runat="server" Text="Cancel" OnClick="btn_cancel_item_Click" Class="btn"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btn_submit_item" runat="server" Text="Submit" OnClick="btn_submit_item_Click" CssClass="btn" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            
            <asp:Label ID="lab_add_item_message" runat="server" style="color: red"></asp:Label>

        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs364ConnectionString %>" SelectCommand="SELECT Warehouse_Name
FROM Warehouse
ORDER BY Warehouse_Name ASC
"></asp:SqlDataSource>
    </form>
</body>
</html>
