<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserData.ascx.cs" Inherits="Admin_UserData_View" %>

<table class="MainTable" cellspacing="0" cellpadding="0" border="0" width="100%">
    <tr>
        <td>
            <table runat="server" id="tblControls" class="SubTable" cellspacing="0" cellpadding="0"
                border="0" width="100%">
                <tr id="trName" runat="server">
                    <td class="text">
                        <asp:Label ID="Label1" Text="<%$ Resources:UsersData,Name %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trTel" runat="server">
                    <td class="text">
                        <asp:Label ID="Label17" Text="<%$ Resources:UsersData,Tel %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:Label ID="lblTel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trMobile" runat="server">
                    <td class="text">
                        <asp:Label ID="Label19" Text="<%$ Resources:UsersData,Mobile %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:Label ID="lblMobile" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
