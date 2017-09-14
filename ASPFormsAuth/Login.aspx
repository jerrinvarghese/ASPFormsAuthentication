<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASPFormsAuth.Login" %>

<!DOCTYPE html>  
<html  
    xmlns="http://www.w3.org/1999/xhtml">  
    <head runat="server">  
        <title></title>  
        <style type="text/css">
            .auto-style1 {
                width: 100%;
            }
        </style>
    </head>  
    <body>  
        <form id="form1" runat="server">  
            <h3>  
                &nbsp;</h3>  
              
            <br />
            <table class="auto-style1">
                <tr>
                    <td>User Name</td>
                    <td>  
                        <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="UserName_TextChanged" />  
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>  
                        <asp:TextBox ID="txtPwd" TextMode="Password"   
             runat="server" />  
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>  
            <asp:Button ID="Submit1" OnClick="Login_Click" Text="Login"   
       runat="server" />  
                    </td>
                </tr>
                <tr>
                    <td>Remember me? <asp:CheckBox ID="chkboxPersist" runat="server" />  
                    </td>
                    <td>
                        <asp:Label ID="AttemptsLbl" runat="server" Text="Label"></asp:Label>
&nbsp; Attempts Left</td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register/Register.aspx">Sign Up</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <p>  
                <asp:Label ID="Msg" ForeColor="red" runat="server" />  
            </p>  
        </form>  
    </body>  
</html>  
