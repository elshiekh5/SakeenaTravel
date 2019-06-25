<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubLogin.ascx.cs" Inherits="UserControls_login" %>

<link href="/App_Themes/AdminSite/adminLogin.css" rel="stylesheet" type="text/css" />
<div id="divWarpper" runat="server" class="Warpper">
    <center>
        <div id="divLogin_title" runat="server" class="login_title">
        </div>
        <div id="loginbox">
            <div id="welcome">
                <b><%= Resources.AdminText.Welcome %></b><br />
                <%= Resources.AdminText.LoginBox_Note%>
            </div>
            <div id="row">
                <span class='text'><%= Resources.AdminText.LoginBox_UserName%></span> <span class='='control'>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                        ForeColor="White" ValidationGroup="Login">*</asp:RequiredFieldValidator></span>
            </div>
            <div id="row">
                <span class='text'><%= Resources.AdminText.LoginBox_Password%></span> <span class='='control'>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                        ForeColor="White" ValidationGroup="Login">*</asp:RequiredFieldValidator></span>
            </div>
            <div id="row">
                <div id='rem'>
                    <asp:ImageButton ID="ibtnLogin" runat="server" CssClass="submit" ValidationGroup="Login"
                        ImageUrl="/Content/images/spacer.gif" OnClick="ibtnLogin_Click" />
                </div>
                <div id='button'>
                </div>
            </div>
            <div id="error">
                <asp:Literal ID="ltrFailureText" runat="server" EnableViewState="False"></asp:Literal></div>
        </div>
    </center>
</div>
