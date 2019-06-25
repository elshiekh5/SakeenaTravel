<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="AddUser.aspx.cs"
    Inherits="AdminSitesUsers_Create"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">

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
                            <%= Resources.MemberShip.AccountType%>
                        </td>
                        <td class="Control">
                            
                            <asp:DropDownList ID="ddlAccountType" runat="server">
                                <asp:ListItem>SiteAdmins</asp:ListItem>
                                <asp:ListItem>SiteUsers</asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            <%= Resources.MemberShip.UserName%>
                        </td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtUserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                                 ValidationGroup="SitesUsers_Create">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            <%= Resources.MemberShip.Password%>
                        </td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtPassword" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                                ValidationGroup="SitesUsers_Create">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            <%= Resources.MemberShip.ConfirmPassword%>
                        </td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtConfirmPassword" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="txtConfirmPassword"
                                ValidationGroup="SitesUsers_Create">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            <%= Resources.MemberShip.Email%>
                        </td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="txtEmail"
                                 ValidationGroup="SitesUsers_Create">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                                ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="<%$ Resources:MemberShip,ConfirmPasswordError%>"
                                ValidationGroup="SitesUsers_Create"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trName" runat="server">
                        <td class="text">
                            <%= Resources.MemberShip.Name %>
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="128" ID="txtName" runat="server" CssClass="Controls" ValidationGroup="SitesUsers_Create"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trTelephones" runat="server">
                        <td class="text">
                            <%= Resources.MemberShip.Telephones %>
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="128" ID="txtTelephones" runat="server" CssClass="Controls"
                                ValidationGroup="SitesUsers_Create"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Button ID="btnCreate" runat="server" Width="100px" Text="<%$ Resources:AdminText,Create %>"
                                CssClass="Button" OnClick="btnCreate_Click" ValidationGroup="SitesUsers_Create">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


