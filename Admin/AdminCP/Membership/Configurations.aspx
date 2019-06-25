<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Configurations.aspx.cs" Inherits="Admin_Admin_Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Roles Confguration</title>
    <link href="<%= Resources.AdminText.AdminCss %>" rel="stylesheet" type="text/css" />
    <link href="/Content/AdminDesign/Styles/AdminGeneral.css" rel="stylesheet" type="text/css" />
</head>
<body heigh="100%">
    <form id="form1" runat="server">
    <table border="0" cellpadding="4" cellspacing="0" style="vertical-align: middle;
        height: 100%; width:100%; border-width: 1;">
        <tr>
            <td align="center">
                <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="center" class="text" colspan="1">
                            Roles Confguration
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
                                        Basic Roles
                                    </td>
                                    <td class="Control">
                                        SiteAdmins,SiteUsers,Administrator Account<asp:Button ID="btnCreateBasicRoles" runat="server" Text="Create Basic Roles"
                                            ValidationGroup="CreateBasicRoles" CssClass="Button" 
                                             Width="129px" onclick="btnCreateBasicRoles_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text">

                                        Role Name</td>
                                    <td class="Control">
                                        <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtRoleName"
                                            ValidationGroup="RolesManagement">*</asp:RequiredFieldValidator>
                                        <asp:Button ID="btnAddRoles" runat="server" Text="Add"
                                            ValidationGroup="RolesManagement" CssClass="Button" 
                                             Width="60px" onclick="btnAddRoles_Click" />
                                    </td>
                                </tr>
                                
                                
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>


