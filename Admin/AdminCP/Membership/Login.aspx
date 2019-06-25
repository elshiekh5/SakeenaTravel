<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Admin_Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%= Resources.MemberShip.LogIn%></title>
    <link href="<%= Resources.AdminText.AdminCss %>" rel="stylesheet" type="text/css" />
    <link href="/Content/AdminDesign/Styles/AdminGeneral.css" rel="stylesheet" type="text/css" />
</head>
<body heigh="100%">
    <form id="form1" runat="server">
    <table border="0" cellpadding="4" cellspacing="0" style="vertical-align: middle;
        height: 100%; width:100%; border-width: 0;">
        <tr>
            <td align="center">
    <table border="0" cellpadding="4" cellspacing="0" style="vertical-align: middle;
         border-width: 1;">
        <tr>
            <td align="center">
                <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="center" class="text" colspan="1">
                            <%= Resources.MemberShip.LogIn%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="Result" align="center" colspan="2">
                                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text">
                                        <%= Resources.MemberShip.UserName %>
                                    </td>
                                    <td class="Control">
                                        <asp:TextBox CssClass="Controls" ID="txtUserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                                            ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text">
                                        <%= Resources.MemberShip.Password%>
                                    </td>
                                    <td class="Control">
                                        <asp:TextBox CssClass="Controls" TextMode="Password" ID="txtPassword" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                                            ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Control" colspan="2">
                                        <asp:CheckBox ID="cbRememberMe" runat="server" Text="<%$ Resources:MemberShip,RememberMe %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Result" align="center" colspan="2">
                                        <asp:Button ID="btnLogin" runat="server" Text="<%$ Resources:MemberShip,LogIn %>"
                                            ValidationGroup="Login1" CssClass="Button" OnClick="btnLogin_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </td></tr></table>
    </form>
</body>
</html>


