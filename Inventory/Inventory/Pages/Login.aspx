<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inventory.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 30px">
            <h1>Sign in
            </h1>
            <table>
                <tr>
                    <td>Username
                    </td>
                    <td>
                        <asp:TextBox ID="txt_username" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password:
                    </td>
                    <td style="margin-left: 40px">
                        <asp:TextBox ID="txt_password" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td />
                    <td>
                        <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lab_login_message" runat="server" Style="color: red"></asp:Label>
                    </td>
                </tr>
            </table>
            <p>
                <br />
                <asp:LinkButton ID="btn_create_account" runat="server" OnClick="btn_create_account_Click" Class="btn">Create Account</asp:LinkButton>
            </p>

            <asp:Table ID="tbl_create_account" Visible="false" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                Employee ID
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txt_employee_id" runat="server" MaxLength="8"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
               Desired Username
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txt_new_username" runat="server" MaxLength="50"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                Desired Password
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txt_new_password" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                Confirm Password
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txt_confirm_password" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" Class="btn" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btn_submit_account" runat="server" Text="Create Account" OnClick="btn_submit_account_Click" Class="btn" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Label ID="lab_sign_up_message" runat="server" Style="color: red"></asp:Label>
        </div>
    </form>
</body>
</html>
